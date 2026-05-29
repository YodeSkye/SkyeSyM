
Imports System.Threading
Imports SkyeSyM.My

Public Class SyMPI

    ' Declarations
    Friend Class ProcessItem
        Public Property DisplayName As String
        Public Property ProcessName As String
        Public Property FilePath As String
        Public Property IsSystem As Boolean
        Public Property Icon As Icon

        Public Overrides Function ToString() As String
            Return DisplayName
        End Function

    End Class
    Private AllProcesses As New List(Of ProcessItem)
    Private FilteredProcesses As New List(Of ProcessItem)
    Private cts As CancellationTokenSource
    Private IsFiltering As Boolean = False
    Friend Event ProcessSelected(item As ProcessItem)

    ' Form Events
    Private Async Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cts = New CancellationTokenSource()

        ' Show placeholder
        LBProcesses.Items.Clear()
        LBProcesses.Items.Add("Loading...")

        ' Start async load
        Await LoadProcessesAsync(cts.Token)
    End Sub
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        cts?.Cancel()
        MyBase.OnFormClosing(e)
    End Sub
    Protected Overrides Sub OnDeactivate(e As EventArgs)
        MyBase.OnDeactivate(e)
        Close()
    End Sub
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    ' Control Events
    Private Sub TxtBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxSearch.TextChanged
        ApplyFilters()
    End Sub
    Private Sub LBProcesses_DrawItem(sender As Object, e As DrawItemEventArgs) Handles LBProcesses.DrawItem
        e.DrawBackground()

        If e.Index < 0 OrElse e.Index >= LBProcesses.Items.Count Then
            Return
        End If

        Dim g = e.Graphics
        Dim item = TryCast(LBProcesses.Items(e.Index), ProcessItem)

        ' If it's a placeholder string like "Loading..."
        If item Is Nothing Then
            TextRenderer.DrawText(g, LBProcesses.Items(e.Index).ToString(),
                              LBProcesses.Font, e.Bounds, Color.Gray,
                              TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
            Return
        End If

        ' Determine text color
        Dim textColor As Color
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            textColor = Color.White
        ElseIf item.IsSystem Then
            textColor = Color.Gray
        Else
            textColor = Color.Black
        End If

        ' Icon rectangle
        Dim iconRect As New Rectangle(e.Bounds.Left + 4, e.Bounds.Top + 3, 16, 16)

        ' Draw icon (fallback if missing)
        If item.Icon IsNot Nothing Then
            g.DrawIcon(item.Icon, iconRect)
        Else
            ControlPaint.DrawBorder(g, iconRect, Color.LightGray, ButtonBorderStyle.Solid)
        End If

        ' Text rectangle
        Dim textRect As New Rectangle(e.Bounds.Left + 24, e.Bounds.Top,
                                  e.Bounds.Width - 24, e.Bounds.Height)

        TextRenderer.DrawText(g, item.DisplayName, LBProcesses.Font,
                          textRect, textColor,
                          TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)

        e.DrawFocusRectangle()
    End Sub
    Private Sub LBProcesses_MouseDown(sender As Object, e As MouseEventArgs) Handles LBProcesses.MouseDown
        Dim index As Integer = LBProcesses.IndexFromPoint(e.Location)
        If index >= 0 AndAlso index < LBProcesses.Items.Count Then

            Dim item = TryCast(LBProcesses.Items(index), ProcessItem)
            If item IsNot Nothing Then
                RaiseEvent ProcessSelected(item)
                Close()
            End If

        End If
    End Sub
    Private Sub LBProcesses_DoubleClick(sender As Object, e As EventArgs) Handles LBProcesses.DoubleClick
        Dim p = TryCast(LBProcesses.SelectedItem, ProcessItem)
        If p IsNot Nothing Then
            RaiseEvent ProcessSelected(p)
            Close()
        End If
    End Sub
    Private Sub ChkBoxShowSystem_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBoxShowSystem.CheckedChanged
        ApplyFilters()
    End Sub

    ' Methods
    Private Async Function LoadProcessesAsync(token As CancellationToken) As Task
        Await Task.Run(Sub()
                           Try
                               For Each p In Process.GetProcesses()

                                   If token.IsCancellationRequested Then Exit Sub

                                   Dim item As ProcessItem = CreateProcessItem(p)

                                   SyncLock AllProcesses
                                       AllProcesses.Add(item)
                                   End SyncLock

                                   If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return

                                   Me.BeginInvoke(Sub()
                                                      AddProcessToUI(item)
                                                  End Sub)

                               Next

                               ' Final cleanup on UI thread
                               Me.BeginInvoke(Sub()
                                                  FinishLoading()
                                              End Sub)

                           Catch ex As Exception
                               ' swallow or log
                           End Try
                       End Sub, token)
    End Function
    Private Function CreateProcessItem(p As Process) As ProcessItem
        Dim filePath As String = String.Empty
        Dim icon As Icon = Nothing
        Dim isSystem As Boolean = False
        Dim key As String = p.ProcessName.ToLowerInvariant()

        ' 1. Try to get file path
        Try
            filePath = p.MainModule.FileName
        Catch
            isSystem = True
        End Try

        ' 2. ICON: check global cache first
        If Not App.SyMProcessIconCache.TryGetValue(key, icon) Then
            ' 3. Extract icon only if not cached
            Try
                icon = Icon.ExtractAssociatedIcon(filePath)
            Catch
                icon = Nothing
            End Try

            ' 4. Store in cache if valid
            If icon IsNot Nothing Then
                App.SyMProcessIconCache(key) = icon
            End If
        End If

        ' 5. Build ProcessItem
        Return New ProcessItem With {
        .DisplayName = p.ProcessName,
        .ProcessName = p.ProcessName,
        .FilePath = filePath,
        .Icon = icon,
        .IsSystem = isSystem
    }
    End Function
    Private Sub AddProcessToUI(item As ProcessItem)
        ' If filtering is happening, don't touch the ListBox
        If IsFiltering Then Return
        If Not MatchesFilters(item) Then Return

        ' Remove placeholder if present
        If LBProcesses.Items.Count = 1 AndAlso LBProcesses.Items(0).ToString() = "Loading..." Then
            LBProcesses.Items.Clear()
        End If

        ' Apply filters (search + system toggle)
        If MatchesFilters(item) Then
            LBProcesses.Items.Add(item)
        End If

    End Sub
    Private Sub FinishLoading()
        ' Sort master list
        AllProcesses = AllProcesses.OrderBy(Function(p) p.DisplayName).ToList()

        ' Reapply filters to rebuild UI cleanly
        ApplyFilters()
    End Sub
    Private Function MatchesFilters(item As ProcessItem) As Boolean
        ' System toggle
        If Not ChkBoxShowSystem.Checked AndAlso item.IsSystem Then
            Return False
        End If

        ' Search
        Dim q = TxtBoxSearch.Text.Trim()
        If q.Length > 0 Then
            If Not item.DisplayName.Contains(q, StringComparison.OrdinalIgnoreCase) AndAlso
           Not item.ProcessName.Contains(q, StringComparison.OrdinalIgnoreCase) Then
                Return False
            End If
        End If

        Return True
    End Function
    Private Sub ApplyFilters()
        IsFiltering = True

        LBProcesses.BeginUpdate()
        LBProcesses.Items.Clear()

        Dim snapshot As List(Of ProcessItem)
        ' ⭐ Prevent loader from modifying AllProcesses during ToList()
        SyncLock AllProcesses
            snapshot = AllProcesses.ToList()
        End SyncLock

        For Each item In snapshot
            If MatchesFilters(item) Then
                LBProcesses.Items.Add(item)
            End If
        Next

        LBProcesses.EndUpdate()

        IsFiltering = False
    End Sub

End Class
