
Imports System.Text
Imports System.Threading
Imports SkyeSyM.My
Imports SkyeSyM.SyMPI

Partial Friend Class SyM

    ' Declarations
    Private mMove As Boolean = False
    Private mOffset, mPosition As System.Drawing.Point
    Private ctsTopMost As New CancellationTokenSource()
    Private QuickHideActive As Boolean = False
    Private Picker As SyMPI
    Private tipInfo As New ToolTip

    ' Form Events
    Friend Sub New()

        'Initialize Locals

        'Initialize Form
        InitializeComponent()
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.Location = My.App.SyMLocation
        Skye.WinAPI.HideFormInTaskSwitcher(Me.Handle)
        Me.TransparencyKey = My.App.SyMColorTransparencyKey
        SetOpacityText()
        SetProcessInstanceImage()
        ResetMonitor()
        RefreshPinnedMenu()
        Me.pbProcessor.Maximum = 100 + AdjustDisplayMaximum(100)
        Me.pbProcessorUser.Maximum = 100 + AdjustDisplayMaximum(100)
        Me.pbProcessorSystem.Maximum = 100 + AdjustDisplayMaximum(100)
        Me.pbMemoryPhysical.Maximum = My.App.SyMMemoryPhysicalMaximum + AdjustDisplayMaximum(My.App.SyMMemoryPhysicalMaximum)
        Me.pbDisk0.Maximum = 100 + AdjustDisplayMaximum(100)
        Me.pbDisk1.Maximum = 100 + AdjustDisplayMaximum(100)
        Me.pbNetworkDownload.Maximum = My.App.SyMNetworkDownloadMaximum + AdjustDisplayMaximum(My.App.SyMNetworkDownloadMaximum)
        Me.pbNetworkUpload.Maximum = My.App.SyMNetworkUploadMaximum + AdjustDisplayMaximum(My.App.SyMNetworkUploadMaximum)
        Me.pbProcessProcessor.Maximum = 100 + AdjustDisplayMaximum(100)
        Me.pbProcessMemoryPhysical.Maximum = My.App.SyMMemoryPhysicalMaximum + AdjustDisplayMaximum(My.App.SyMMemoryPhysicalMaximum)
        Me.tipInfo.SetToolTip(Me.lblProcesses, My.App.SyMGetCounterDescription(My.App.SyMCounters.Processes))
        Me.tipInfo.SetToolTip(Me.lblProcessor, My.App.SyMGetCounterDescription(My.App.SyMCounters.Processor))
        Me.tipInfo.SetToolTip(Me.picboxProcessor, My.App.SyMGetCounterDescription(My.App.SyMCounters.Processor))
        Me.tipInfo.SetToolTip(Me.picboxMemory, My.App.SyMGetCounterDescription(My.App.SyMCounters.Memory))
        Me.tipInfo.SetToolTip(Me.lblMemoryPhysical, My.App.SyMGetCounterDescription(My.App.SyMCounters.MemoryPhysicalGB))
        Me.tipInfo.SetToolTip(Me.lblMemoryPhysicalPercent, My.App.SyMGetCounterDescription(My.App.SyMCounters.MemoryPhysicalPercent))
        Me.tipInfo.SetToolTip(Me.lblDisk0, My.App.SyMGetCounterDescription(My.App.SyMCounters.Disk0))
        Me.tipInfo.SetToolTip(Me.lblDisk1, My.App.SyMGetCounterDescription(My.App.SyMCounters.Disk1))
        Me.tipInfo.SetToolTip(Me.picboxDisk, My.App.SyMGetCounterDescription(My.App.SyMCounters.Disk))
        Me.tipInfo.SetToolTip(Me.picboxNetwork, My.App.SyMGetCounterDescription(My.App.SyMCounters.Network))
        Me.tipInfo.SetToolTip(Me.lblNetworkDownload, My.App.SyMGetCounterDescription(My.App.SyMCounters.NetworkDownload))
        Me.tipInfo.SetToolTip(Me.lblNetworkUpload, My.App.SyMGetCounterDescription(My.App.SyMCounters.NetworkUpload))
        Me.tipInfo.SetToolTip(Me.lblProcessProcessor, My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessProcessor))
        Me.tipInfo.SetToolTip(Me.lblProcessMemoryPhysical, My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessMemoryPhysical))
        Me.tipInfo.SetToolTip(Me.lblProcessMemoryPhysicalPercent, My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessMemoryPhysicalPercent))
        cmSM.Renderer = New Skye.UI.SkyeMenuRenderer
        CMPI.Renderer = New Skye.UI.SkyeMenuRenderer
        cmOpacity.Renderer = New Skye.UI.SkyeMenuRenderer

        'Initialize Colors
        SetForeColor(True)
        Me.pbMemoryPhysical.BackColor = My.App.SyMColor.BarBackground
        Me.pbNetworkDownload.BackColor = My.App.SyMColor.BarBackground
        Me.pbNetworkUpload.BackColor = My.App.SyMColor.BarBackground
        Me.pbProcessMemoryPhysical.BackColor = My.App.SyMColor.BarBackground
        Me.pbProcessor.BackColor = My.App.SyMColor.BarBackground
        Me.pbProcessorSystem.BackColor = My.App.SyMColor.BarBackground
        Me.pbProcessorUser.BackColor = My.App.SyMColor.BarBackground
        Me.pbProcessProcessor.BackColor = My.App.SyMColor.BarBackground
        Me.pbDisk0.ForeColor = My.App.SyMColor.BarForeground
        Me.pbDisk0.BackColor = My.App.SyMColor.BarBackground
        Me.pbDisk1.ForeColor = My.App.SyMColor.BarForeground
        Me.pbDisk1.BackColor = My.App.SyMColor.BarBackground
        Me.pbMemoryPhysical.ForeColor = My.App.SyMColor.BarForeground
        Me.pbNetworkDownload.ForeColor = My.App.SyMColor.BarForeground
        Me.pbNetworkUpload.ForeColor = My.App.SyMColor.BarForeground
        Me.pbProcessMemoryPhysical.ForeColor = My.App.SyMColor.BarForeground
        Me.pbProcessor.ForeColor = My.App.SyMColor.BarForeground
        Me.pbProcessProcessor.ForeColor = My.App.SyMColor.BarForeground
        Me.pbProcessorSystem.ForeColor = My.App.SyMColor.BarProcessorSystemForeground
        Me.pbProcessorUser.ForeColor = My.App.SyMColor.BarProcessorUserForeground

    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartTopMostLoop()
    End Sub
    Private Sub Frm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ctsTopMost.Cancel()
    End Sub
    Private Sub FrmVisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        My.App.SyMSetLoop()
    End Sub
    Private Sub FrmLocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        My.App.SyMLocation = Me.Location
    End Sub
    Private Sub FrmMouseEnter(sender As Object, e As EventArgs) Handles picboxProcessor.MouseEnter, picboxProcessInstance.MouseEnter, picboxNetwork.MouseEnter, picboxMemory.MouseEnter, picboxDisk.MouseEnter, pbProcessProcessor.MouseEnter, pbProcessorUser.MouseEnter, pbProcessorSystem.MouseEnter, pbProcessor.MouseEnter, pbProcessMemoryPhysical.MouseEnter, pbNetworkUpload.MouseEnter, pbNetworkDownload.MouseEnter, pbMemoryPhysical.MouseEnter, pbDisk0.MouseEnter, MyBase.MouseEnter, lblProcessThreads.MouseEnter, lblProcessProcessor.MouseEnter, lblProcessor.MouseEnter, lblProcessMemoryPhysicalPercent.MouseEnter, lblProcessMemoryPhysical.MouseEnter, lblProcessInstance.MouseEnter, lblProcesses.MouseEnter, lblNetworkUpload.MouseEnter, lblNetworkDownload.MouseEnter, lblMemoryPhysicalPercent.MouseEnter, lblMemoryPhysical.MouseEnter, lblDisk0.MouseEnter, pbDisk0.MouseEnter, lblDisk0.MouseEnter, pbDisk1.MouseEnter, lblDisk1.MouseEnter
        ResetOpacity()
        SetBackColor()
    End Sub
    Private Sub FrmMouseLeave(sender As Object, e As EventArgs) Handles picboxProcessor.MouseLeave, picboxProcessInstance.MouseLeave, picboxNetwork.MouseLeave, picboxMemory.MouseLeave, picboxDisk.MouseLeave, MyBase.MouseLeave, lblProcessThreads.MouseLeave, lblProcessProcessor.MouseLeave, lblProcessor.MouseLeave, lblProcessMemoryPhysicalPercent.MouseLeave, lblProcessMemoryPhysical.MouseLeave, lblProcessInstance.MouseLeave, lblProcesses.MouseLeave, lblNetworkUpload.MouseLeave, lblNetworkDownload.MouseLeave, lblMemoryPhysicalPercent.MouseLeave, lblMemoryPhysical.MouseLeave, lblDisk0.MouseLeave, lblDisk0.MouseLeave, lblDisk1.MouseLeave
        ResetBackColor()
        SetOpacity()
    End Sub
    Private Sub FrmMouseDown(sender As Object, e As MouseEventArgs) Handles picboxProcessor.MouseDown, picboxProcessInstance.MouseDown, picboxNetwork.MouseDown, picboxMemory.MouseDown, picboxDisk.MouseDown, pbProcessProcessor.MouseDown, pbProcessorUser.MouseDown, pbProcessorSystem.MouseDown, pbProcessor.MouseDown, pbProcessMemoryPhysical.MouseDown, pbNetworkUpload.MouseDown, pbNetworkDownload.MouseDown, pbMemoryPhysical.MouseDown, pbDisk0.MouseDown, MyBase.MouseDown, lblProcessThreads.MouseDown, lblProcessProcessor.MouseDown, lblProcessor.MouseDown, lblProcessMemoryPhysicalPercent.MouseDown, lblProcessMemoryPhysical.MouseDown, lblProcessInstance.MouseDown, lblProcesses.MouseDown, lblNetworkUpload.MouseDown, lblNetworkDownload.MouseDown, lblMemoryPhysicalPercent.MouseDown, lblMemoryPhysical.MouseDown, lblDisk0.MouseDown, pbDisk0.MouseDown, lblDisk0.MouseDown, pbDisk1.MouseDown, lblDisk1.MouseDown
        Static senderCtrl As Control
        If e.Button = MouseButtons.Left Then
            mMove = True
            If sender Is Me Then : mOffset = New System.Drawing.Point(-e.X, -e.Y)
            Else
                senderCtrl = CType(sender, Control)
                mOffset = New System.Drawing.Point(-e.X - senderCtrl.Left, -e.Y - senderCtrl.Top)
                senderCtrl = Nothing
            End If
        End If
    End Sub
    Private Sub FrmMouseMove(sender As Object, e As MouseEventArgs) Handles picboxProcessor.MouseMove, picboxProcessInstance.MouseMove, picboxNetwork.MouseMove, picboxMemory.MouseMove, picboxDisk.MouseMove, pbProcessProcessor.MouseMove, pbProcessorUser.MouseMove, pbProcessorSystem.MouseMove, pbProcessor.MouseMove, pbProcessMemoryPhysical.MouseMove, pbNetworkUpload.MouseMove, pbNetworkDownload.MouseMove, pbMemoryPhysical.MouseMove, pbDisk0.MouseMove, MyBase.MouseMove, lblProcessThreads.MouseMove, lblProcessProcessor.MouseMove, lblProcessor.MouseMove, lblProcessMemoryPhysicalPercent.MouseMove, lblProcessMemoryPhysical.MouseMove, lblProcessInstance.MouseMove, lblProcesses.MouseMove, lblNetworkUpload.MouseMove, lblNetworkDownload.MouseMove, lblMemoryPhysicalPercent.MouseMove, lblMemoryPhysical.MouseMove, lblDisk0.MouseMove, pbDisk0.MouseMove, lblDisk0.MouseMove, pbDisk1.MouseMove, lblDisk1.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub FrmMouseUp(sender As Object, e As MouseEventArgs) Handles picboxProcessor.MouseUp, picboxProcessInstance.MouseUp, picboxNetwork.MouseUp, picboxMemory.MouseUp, picboxDisk.MouseUp, pbProcessProcessor.MouseUp, pbProcessorUser.MouseUp, pbProcessorSystem.MouseUp, pbProcessor.MouseUp, pbProcessMemoryPhysical.MouseUp, pbNetworkUpload.MouseUp, pbNetworkDownload.MouseUp, pbMemoryPhysical.MouseUp, pbDisk0.MouseUp, MyBase.MouseUp, lblProcessThreads.MouseUp, lblProcessProcessor.MouseUp, lblProcessor.MouseUp, lblProcessMemoryPhysicalPercent.MouseUp, lblProcessMemoryPhysical.MouseUp, lblProcessInstance.MouseUp, lblProcesses.MouseUp, lblNetworkUpload.MouseUp, lblNetworkDownload.MouseUp, lblMemoryPhysicalPercent.MouseUp, lblMemoryPhysical.MouseUp, lblDisk0.MouseUp, pbDisk0.MouseUp, lblDisk0.MouseUp, pbDisk1.MouseUp, lblDisk1.MouseUp
        mMove = False
    End Sub
    Private Sub FrmMove(sender As Object, e As EventArgs) Handles MyBase.Move
        If Not mMove Then CheckMove(Me.Location)
    End Sub

    ' Control Events
    Private Sub CMSMOpening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmSM.Opening
        Select Case My.App.SyMAutoMinimal
            Case True
                Me.cmiAutoMinimal.Checked = True
                Me.cmiAutoMinimal.ForeColor = Color.Teal
            Case False
                Me.cmiAutoMinimal.Checked = False
                Me.cmiAutoMinimal.ForeColor = Color.Maroon
        End Select
        Me.cmiProcessInstance.Text = My.App.SyMProcessInstance.ToUpper
    End Sub
    Private Sub CMIAutoMinimalMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAutoMinimal.MouseUp
        My.App.SyMAutoMinimal = Not My.App.SyMAutoMinimal
        If Not My.App.SyMAutoMinimal Then My.App.FrmSyM.SetBackColor()
        App.FrmSettings?.ShowSettings()
    End Sub
    Private Sub CMIQuickHideMouseUp(sender As Object, e As MouseEventArgs) Handles cmiQuickHide.MouseUp
        If e.Button = MouseButtons.Left Then
            QuickHideAsync()
        End If
    End Sub
    Private Sub CMIOpacityMouseUp(sender As Object, e As MouseEventArgs) Handles cmiOpacity.MouseUp
        If e.Button = MouseButtons.Left Then
            My.App.SyMOpacity = 100
            If Me.cmSM.Visible Then Me.cmSM.Close()
            Me.SetOpacity(True)
            App.FrmSettings?.ShowSettings()
        End If
    End Sub
    Private Sub CMIOpacityPercentMouseUp(sender As Object, e As MouseEventArgs) Handles cmiOpacity90.MouseUp, cmiOpacity80.MouseUp, cmiOpacity70.MouseUp, cmiOpacity60.MouseUp, cmiOpacity50.MouseUp, cmiOpacity40.MouseUp, cmiOpacity30.MouseUp, cmiOpacity20.MouseUp, cmiOpacity100.MouseUp, cmiOpacity10.MouseUp
        If e.Button = MouseButtons.Left Then
            My.App.SyMOpacity = CByte(CType(sender, ToolStripMenuItem).Tag)
            Me.ResetBackColor()
            Me.SetOpacity(True)
            App.FrmSettings?.ShowSettings()
        End If
    End Sub
    Private Sub CMIWindowsMonitorMouseUp(sender As Object, e As MouseEventArgs) Handles cmiWindowsMonitor.MouseUp
        Select Case e.Button
            Case MouseButtons.Left : My.App.StartFile(My.App.WinTaskManagerPath)
            Case MouseButtons.Right
                If My.Computer.Keyboard.CtrlKeyDown Then : My.App.StartFile(My.App.WinPerformanceMonitorPath)
                Else : My.App.StartFile(My.App.WinResourceMonitorPath)
                End If
        End Select
    End Sub
    Private Sub CMICloseMouseUp(sender As Object, e As MouseEventArgs) Handles cmiClose.MouseUp
        If e.Button = MouseButtons.Left Then My.App.FrmMain.ShowSyM()
    End Sub
    Private Sub CMPI_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMPI.Opening
        UpdatePinMenuText()
    End Sub
    Private Sub CMIPIPinToggle_Click(sender As Object, e As EventArgs) Handles CMIPIPinToggle.Click
        Dim name = App.SyMProcessInstance
        If String.IsNullOrEmpty(name) Then Exit Sub

        If Not App.SyMPinnedProcesses.Remove(name) Then
            App.SyMPinnedProcesses.Add(name)
        End If
        App.SyMPinnedProcesses.Sort()
        App.SaveSettings()

        RefreshPinnedMenu()
        UpdatePinMenuText()
    End Sub
    Private Sub CMIPIMore_Click(sender As Object, e As EventArgs) Handles CMIPIMore.Click
        OpenProcessPicker()
    End Sub
    Private Sub CMIPIAttach_Click(sender As Object, e As EventArgs) Handles CMIPIAttach.Click
        Dim h = GetRealWindowBehindSelf()
        If h = IntPtr.Zero Then Exit Sub

        Dim proc = GetProcessNameFromWindow(h)
        If String.IsNullOrEmpty(proc) Then Exit Sub

        My.App.SyMProcessInstance = proc
        My.App.FrmMain.ResetSyM()
        UpdatePinMenuText()
    End Sub

    ' Handlers
    Private Async Sub StartTopMostLoop()
        Dim timer As New PeriodicTimer(TimeSpan.FromMilliseconds(App.SyMQuickHideInterval * 1000)) '3000
        Try
            While Await timer.WaitForNextTickAsync(ctsTopMost.Token)

                If IsDisposed OrElse Not IsHandleCreated Then Exit While

                If Not (cmSM.Visible Or CMPI.Visible) Then
                    If Not QuickHideActive Then
                        ResetBackColor()
                        SetOpacity()
                    End If
                    If Visible AndAlso
                       Not QuickHideActive AndAlso
                       (Picker Is Nothing OrElse Not Picker.Visible) Then
                        Me.BeginInvoke(Sub()
                                           Skye.WinAPI.SetWindowPos(Me.Handle, Skye.WinAPI.HWND_TOPMOST, 0, 0, 0, 0, Skye.WinAPI.SWP_NOMOVE Or Skye.WinAPI.SWP_NOSIZE Or Skye.WinAPI.SWP_NOACTIVATE Or Skye.WinAPI.SWP_SHOWWINDOW)
                                       End Sub)
                    End If
                End If

            End While
        Catch ex As OperationCanceledException
            ' Normal shutdown — ignore
        End Try
    End Sub
    Private Async Sub QuickHideAsync()
        If QuickHideActive Then Exit Sub
        QuickHideActive = True

        Dim interval As Integer = My.App.SyMQuickHideInterval * 1000

        ' Hide immediately
        Me.Opacity = 0

        ' Wait without blocking UI
        Await Task.Delay(interval)

        ' Restore only if form still exists
        If Not Me.IsDisposed Then
            SetOpacity(True)
        End If

        QuickHideActive = False
    End Sub
    Private Sub OnProcessSelected(item As ProcessItem)
        If item Is Nothing Then Exit Sub

        My.App.SyMProcessInstance = item.ProcessName
        My.App.FrmMain.ResetSyM()

    End Sub
    Private Sub PickerClosed(sender As Object, e As FormClosedEventArgs)
        Dim frm = DirectCast(sender, SyMPI)

        RemoveHandler frm.ProcessSelected, AddressOf Me.OnProcessSelected
        RemoveHandler frm.FormClosed, AddressOf PickerClosed

        If Picker Is frm Then
            Picker = Nothing
        End If
    End Sub

    ' Methods
    Private Sub OpenProcessPicker()

        ' Close previous picker if still open
        If Picker IsNot Nothing AndAlso Not Picker.IsDisposed Then
            Picker.Close()
        End If

        ' Create and store strong reference
        Picker = New SyMPI()
        AddHandler Picker.FormClosed, AddressOf PickerClosed
        AddHandler Picker.ProcessSelected, AddressOf Me.OnProcessSelected

        ' Positioning logic (unchanged)
        Dim wa = Screen.PrimaryScreen.WorkingArea
        Dim desired = Cursor.Position
        Dim x = desired.X
        Dim y = desired.Y
        If x + Picker.Width > wa.Right Then x = wa.Right - Picker.Width
        If x < wa.Left Then x = wa.Left
        If y + Picker.Height > wa.Bottom Then y = wa.Bottom - Picker.Height
        If y < wa.Top Then y = wa.Top
        Picker.Location = New Point(x, y)

        Picker.Show()

    End Sub
    Private Sub UpdatePinMenuText()
        Dim name = App.SyMProcessInstance
        If App.SyMPinnedProcesses.Contains(name) Then
            CMIPIPinToggle.Text = "Unpin Current Process"
            CMIPIPinToggle.Image = My.Resources.Resources.ImageUnpin16
        Else
            CMIPIPinToggle.Text = "Pin Current Process"
            CMIPIPinToggle.Image = My.Resources.Resources.ImagePin16
        End If
    End Sub
    Private Sub RefreshPinnedMenu()

        ' 1. Remove existing pinned items (everything ABOVE TSSPI)
        While CMPI.Items.Count > 0 AndAlso CMPI.Items(0) IsNot TSSPIPins
            CMPI.Items.RemoveAt(0)
        End While

        ' 2. Insert pinned items above TSSPI
        For i As Integer = App.SyMPinnedProcesses.Count - 1 To 0 Step -1
            Dim procName = App.SyMPinnedProcesses(i)
            Dim mi As New ToolStripMenuItem(procName)
            Dim ico = GetOrLoadIcon(procName)
            If ico IsNot Nothing Then
                mi.Image = ico.ToBitmap()
            End If

            AddHandler mi.Click, Sub()
                                     My.App.SyMProcessInstance = procName
                                     My.App.FrmMain.ResetSyM()
                                     UpdatePinMenuText()
                                 End Sub

            CMPI.Items.Insert(0, mi)
        Next

        TSSPIPins.Visible = (App.SyMPinnedProcesses.Count > 0)

    End Sub
    Public Overrides Sub ResetBackColor()
        If Me.picboxProcessor.Visible AndAlso My.App.SyMAutoMinimal AndAlso Not MouseInFormBounds() Then
            Me.SuspendLayout()
            Me.BackColor = My.App.SyMColorTransparencyKey
            Me.SetForeColor(False)
            Me.picboxProcessor.Visible = False
            Me.picboxMemory.Visible = False
            Me.picboxDisk.Visible = False
            Me.picboxNetwork.Visible = False
            Me.picboxProcessInstance.Visible = False
            Me.Refresh()
            Me.ResumeLayout()
        End If
    End Sub
    Friend Sub SetOpacity(Optional forceset As Boolean = False)
        If forceset OrElse (Not Me.Opacity = My.App.SyMOpacity / 100 AndAlso Not MouseInFormBounds()) Then
            Me.Opacity = My.App.SyMOpacity / 100
            SetOpacityText()
        End If
    End Sub
    Friend Sub ResetOpacity()
        If Not Me.Opacity = 1 Then
            Me.Opacity = 1
        End If
    End Sub
    Friend Sub SetBackColor()
        If Not Me.picboxProcessor.Visible Then
            Me.SuspendLayout()
            Me.BackColor = My.App.SyMColor.Background
            Me.SetForeColor(True)
            Me.picboxProcessor.Visible = True
            Me.picboxMemory.Visible = True
            Me.picboxDisk.Visible = True
            Me.picboxNetwork.Visible = True
            Me.picboxProcessInstance.Visible = True
            Me.Refresh()
            Me.ResumeLayout()
            If Not My.App.FrmMain.Visible Then Me.TopMost = True
            'Debug.Print("SetBackColor")
        End If
    End Sub
    Friend Sub ShowForm()
        ResetOpacity()
        SetBackColor()
        Me.Show()
    End Sub
    Friend Sub HideForm()
        Me.Hide()
        ResetMonitor()
    End Sub
    Private Sub SetForeColor(Optional IsOnBackground As Boolean = True)
        If IsOnBackground Then
            Me.lblDisk0.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblDisk1.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblMemoryPhysical.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblMemoryPhysicalPercent.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblNetworkDownload.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblNetworkUpload.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblProcesses.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblProcessInstance.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblProcessMemoryPhysical.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblProcessMemoryPhysicalPercent.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblProcessor.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblProcessProcessor.ForeColor = My.App.SyMColor.ForegroundOnBackground
            Me.lblProcessThreads.ForeColor = My.App.SyMColor.ForegroundOnBackground
        Else
            Me.lblDisk0.ForeColor = My.App.SyMColor.Foreground
            Me.lblDisk1.ForeColor = My.App.SyMColor.Foreground
            Me.lblMemoryPhysical.ForeColor = My.App.SyMColor.Foreground
            Me.lblMemoryPhysicalPercent.ForeColor = My.App.SyMColor.Foreground
            Me.lblNetworkDownload.ForeColor = My.App.SyMColor.Foreground
            Me.lblNetworkUpload.ForeColor = My.App.SyMColor.Foreground
            Me.lblProcesses.ForeColor = My.App.SyMColor.Foreground
            Me.lblProcessInstance.ForeColor = My.App.SyMColor.Foreground
            Me.lblProcessMemoryPhysical.ForeColor = My.App.SyMColor.Foreground
            Me.lblProcessMemoryPhysicalPercent.ForeColor = My.App.SyMColor.Foreground
            Me.lblProcessor.ForeColor = My.App.SyMColor.Foreground
            Me.lblProcessProcessor.ForeColor = My.App.SyMColor.Foreground
            Me.lblProcessThreads.ForeColor = My.App.SyMColor.Foreground
        End If
    End Sub
    Private Sub SetOpacityText()
        Me.cmiOpacity.Text = "Opacity = " + My.App.SyMOpacity.ToString + " %"
    End Sub
    Private Sub SetProcessInstanceImage()
        Dim instancepath As String = GetProcessInstancePath(My.App.SyMProcessInstance)
        If String.IsNullOrEmpty(instancepath) Then
            Me.picboxProcessInstance.Image = SystemIcons.Question.ToBitmap
            Me.picboxProcessInstance.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Me.picboxProcessInstance.Image = Skye.WinAPI.GetApplicationIcon(instancepath).ToBitmap
            Me.picboxProcessInstance.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
    Private Sub ResetMonitor()
        Me.lblProcesses.ResetText()
        Me.lblProcessor.ResetText()
        Me.lblMemoryPhysical.ResetText()
        Me.lblMemoryPhysicalPercent.ResetText()
        Me.lblDisk0.ResetText()
        Me.lblDisk1.ResetText()
        Me.lblNetworkDownload.ResetText()
        Me.lblNetworkUpload.ResetText()
        Me.lblProcessInstance.ResetText()
        Me.lblProcessProcessor.ResetText()
        Me.lblProcessThreads.ResetText()
        Me.lblProcessMemoryPhysical.ResetText()
        Me.lblProcessMemoryPhysicalPercent.ResetText()
        Me.pbProcessor.Value = 0 'Me.pbProcessor.Minimum
        Me.pbProcessorUser.Value = 0 'Me.pbProcessorUser.Minimum
        Me.pbProcessorSystem.Value = 0 'Me.pbProcessorSystem.Minimum
        Me.pbMemoryPhysical.Value = 0 'Me.pbMemoryPhysical.Minimum
        Me.pbDisk0.Value = 0 'Me.pbDisk0.Minimum
        Me.pbDisk1.Value = 0 'Me.pbDisk1.Minimum
        Me.pbNetworkDownload.Value = 0 'Me.pbNetworkDownload.Minimum
        Me.pbNetworkUpload.Value = 0 'Me.pbNetworkUpload.Minimum
        Me.pbProcessProcessor.Value = 0 'Me.pbProcessProcessor.Minimum
        Me.pbProcessMemoryPhysical.Value = 0 'Me.pbProcessMemoryPhysical.Minimum
    End Sub
    Private Sub CheckMove(ByRef location As System.Drawing.Point)
        If location.X + Me.Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Me.Width
        If location.Y + Me.Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Me.Height
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left
        If location.Y < My.Computer.Screen.WorkingArea.Top Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub
    Private Function AdjustDisplayMaximum(maxvalue As Integer) As Integer
        AdjustDisplayMaximum = 0
        'AdjustDisplayMaximum = CInt((maxvalue / 64) * 2)
    End Function
    Private Function MouseInFormBounds() As Boolean
        If Control.MousePosition.X > Me.Location.X AndAlso Control.MousePosition.X < Me.Location.X + Me.Width - 1 AndAlso Control.MousePosition.Y > Me.Location.Y AndAlso Control.MousePosition.Y < Me.Location.Y + Me.Height - 1 Then : Return True
        Else : Return False
        End If
    End Function
    Private Function GetProcessInstancePath(instance As String) As String
        Dim pc As Diagnostics.PerformanceCounter
        Dim p As Diagnostics.Process
        pc = New Diagnostics.PerformanceCounter("Process", "ID Process", instance, True)
        p = New Diagnostics.Process
        Try
            p = Diagnostics.Process.GetProcessById(CInt(pc.RawValue))
            If String.IsNullOrEmpty(instance) Then : GetProcessInstancePath = Nothing
            ElseIf p.Id < 5 Then : GetProcessInstancePath = String.Empty
            Else
                Try : GetProcessInstancePath = p.MainModule.FileName.TrimStart(New Char() {CChar("\"), CChar("?"), CChar("?"), CChar("\")}) 'This string,"\??\", gets inserted sometimes for some unknown reason.
                Catch : GetProcessInstancePath = My.Application.GetEnvironmentVariable("WINDIR") 'Nothing
                End Try
            End If
        Catch : GetProcessInstancePath = Nothing
        End Try
        p.Close()
        p.Dispose()
        pc.Close()
        pc.Dispose()
        instance = String.Empty
        instance = Nothing
    End Function
    Private Function GetRealWindowBehindSelf() As IntPtr
        Dim h = Me.Handle

        While True
            h = Skye.WinAPI.GetWindow(h, Skye.WinAPI.GW_HWNDNEXT)
            If h = IntPtr.Zero Then Return IntPtr.Zero

            ' Skip invisible windows
            If Not Skye.WinAPI.IsWindowVisible(h) Then Continue While

            ' Skip owned windows (tool windows, popup managers, GPU windows, etc.)
            Dim owner = Skye.WinAPI.GetWindowLongPtr(h, Skye.WinAPI.GWL_HWNDPARENT)
            If owner <> IntPtr.Zero Then Continue While

            ' Skip our own process
            Dim pid As UInteger
            Dim result = Skye.WinAPI.GetWindowThreadProcessId(h, pid)
            If pid = Environment.ProcessId Then Continue While

            ' Skip tool windows (WS_EX_TOOLWINDOW)
            Dim ex = Skye.WinAPI.GetWindowLong(h, Skye.WinAPI.GWL_EXSTYLE)
            If (ex And Skye.WinAPI.WS_EX_TOOLWINDOW) <> 0 Then Continue While

            ' Skip child windows (WS_CHILD)
            Dim style = Skye.WinAPI.GetWindowLong(h, Skye.WinAPI.GWL_STYLE)
            If (style And Skye.WinAPI.WS_CHILD) <> 0 Then Continue While

            ' Skip tiny windows (GPU, IME, popup managers)
            Dim r As Skye.WinAPI.RECT
            If Skye.WinAPI.GetWindowRect(h, r) Then
                Dim w = r.Right - r.Left
                Dim hgt = r.Bottom - r.Top
                If w < 200 OrElse hgt < 150 Then Continue While
            End If

            ' Skip known junk classes
            Dim cls = GetWindowClass(h).ToLowerInvariant()
            If cls.Contains("workerw") Then Continue While
            If cls.Contains("shell") Then Continue While
            If cls.Contains("ime") Then Continue While
            If cls.Contains("tool") Then Continue While
            If cls.Contains("notify") Then Continue While
            If cls.Contains("popup") Then Continue While
            If cls.Contains("dwm") Then Continue While

            ' This is a real top-level window
            Return h
        End While

        Return IntPtr.Zero
    End Function
    Private Function GetWindowClass(hWnd As IntPtr) As String
        Dim sb As New StringBuilder(256)
        Dim result = Skye.WinAPI.GetClassName(hWnd, sb, sb.Capacity)
        Return sb.ToString()
    End Function
    Private Function GetProcessNameFromWindow(hWnd As IntPtr) As String
        If hWnd = IntPtr.Zero Then Return Nothing

        Dim pid As UInteger = 0
        Dim result = Skye.WinAPI.GetWindowThreadProcessId(hWnd, pid)

        If pid = 0 Then Return Nothing

        Try
            Dim p = Process.GetProcessById(CInt(pid))
            Return p.ProcessName.ToLowerInvariant()
        Catch
            Return Nothing
        End Try
    End Function
    Private Function GetOrLoadIcon(procName As String) As Icon
        Dim key = procName.ToLowerInvariant()

        ' Already cached?
        Dim cachedIcon As Icon = Nothing
        If App.SyMProcessIconCache.TryGetValue(key, cachedIcon) Then
            Return cachedIcon
        End If

        ' Need to load it
        Try
            Dim p = Process.GetProcessesByName(procName).FirstOrDefault()
            If p IsNot Nothing Then
                Dim file = ""
                Try
                    file = p.MainModule.FileName
                Catch
                    Return Nothing
                End Try

                Dim ico = Icon.ExtractAssociatedIcon(file)
                If ico IsNot Nothing Then
                    App.SyMProcessIconCache(key) = ico
                    Return ico
                End If
            End If
        Catch
        End Try

        Return Nothing
    End Function

    ' Show Data
    Friend Sub ShowDataProcessor(data As Integer, dataraw As Single, datauser As Integer, datauserraw As Single, datasystem As Integer, datasystemraw As Single)
        Me.pbProcessor.Value = data
        Me.pbProcessorUser.Value = datauser
        Me.pbProcessorSystem.Value = datasystem
        Me.lblProcessor.Text = data.ToString + "%"
        Me.tipInfo.SetToolTip(Me.pbProcessor, My.App.SyMGetCounterDescription(My.App.SyMCounters.Processor) + VisualBasic.vbCr + data.ToString + "% (" + dataraw.ToString + ")")
        Me.tipInfo.SetToolTip(Me.pbProcessorUser, My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessorUser) + VisualBasic.vbCr + datauser.ToString + "% (" + datauserraw.ToString + ")")
        Me.tipInfo.SetToolTip(Me.pbProcessorSystem, My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessorSystem) + VisualBasic.vbCr + datasystem.ToString + "% (" + datasystemraw.ToString + ")")
    End Sub
    Friend Sub ShowDataProcesses(data As Integer)
        Me.lblProcesses.Text = data.ToString + "P"
    End Sub
    Friend Sub ShowDataMemoryPhysical(datafreememory As Integer, datafreememoryraw As Single, datausedmemoryraw As Single)
        Me.pbMemoryPhysical.Value = My.App.SyMMemoryPhysicalMaximum - datafreememory
        Me.lblMemoryPhysical.Text = (datausedmemoryraw / My.App.GBConversion).ToString("N2") + "GB"
        Me.lblMemoryPhysicalPercent.Text = CInt((My.App.SyMMemoryPhysicalMaximum - datafreememory) / My.App.SyMMemoryPhysicalMaximum * 100).ToString + "%"
        Me.tipInfo.SetToolTip(Me.pbMemoryPhysical, My.App.SyMGetCounterDescription(My.App.SyMCounters.MemoryPhysical) + VisualBasic.vbCr + (My.App.SyMMemoryPhysicalMaximum - datafreememory).ToString + " MB (" + (My.App.SyMMemoryPhysicalMaximumRaw - CULng(datafreememoryraw)).ToString("N0") + ")" + VisualBasic.vbCr + Me.lblMemoryPhysicalPercent.Text + VisualBasic.vbCr + "Calculated From Physical Memory Available" + VisualBasic.vbCr + datafreememory.ToString + " MB (" + CULng(datafreememoryraw).ToString("N0") + ")" + VisualBasic.vbCr + CInt(datafreememory / My.App.SyMMemoryPhysicalMaximum * 100).ToString + "%")
    End Sub
    Friend Sub ShowDataDisk0(data As Integer, dataraw As Single)
        Me.pbDisk0.Value = data
        Me.lblDisk0.Text = data.ToString + "%"
        Me.tipInfo.SetToolTip(Me.pbDisk0, My.App.SyMGetCounterDescription(My.App.SyMCounters.Disk0) + VisualBasic.vbCr + data.ToString + "% (" + dataraw.ToString + ")")
    End Sub
    Friend Sub ShowDataDisk1(data As Integer, dataraw As Single)
        Me.pbDisk1.Value = data
        Me.lblDisk1.Text = data.ToString + "%"
        Me.tipInfo.SetToolTip(Me.pbDisk1, My.App.SyMGetCounterDescription(My.App.SyMCounters.Disk1) + VisualBasic.vbCr + data.ToString + "% (" + dataraw.ToString + ")")
    End Sub
    Friend Sub ShowDataNetworkDownload(data As Integer, dataraw As Single)
        Me.pbNetworkDownload.Value = data
        Me.lblNetworkDownload.Text = data.ToString + " KB/sec"
        Me.tipInfo.SetToolTip(Me.pbNetworkDownload, My.App.SyMGetCounterDescription(My.App.SyMCounters.NetworkDownload) + VisualBasic.vbCr + CInt(dataraw / My.App.KBConversion).ToString + " KB/sec (" + dataraw.ToString("N3") + ")")
    End Sub
    Friend Sub ShowDataNetworkUpload(data As Integer, dataraw As Single)
        Me.pbNetworkUpload.Value = data
        Me.lblNetworkUpload.Text = data.ToString + " KB/sec"
        Me.tipInfo.SetToolTip(Me.pbNetworkUpload, My.App.SyMGetCounterDescription(My.App.SyMCounters.NetworkUpload) + VisualBasic.vbCr + CInt(dataraw / My.App.KBConversion).ToString + " KB/sec (" + dataraw.ToString("N3") + ")")
    End Sub
    Friend Sub ShowDataPagingFileUsage(data As Integer)
        Dim tiptext = tipInfo.GetToolTip(pbMemoryPhysical)
        tiptext &= vbCr & "Paging File Utilization" & vbCr & data.ToString & "%"
        tipInfo.SetToolTip(pbMemoryPhysical, tiptext)
    End Sub
    Friend Sub ShowDataProcessProcessor(data As Integer, dataraw As Single)
        Me.lblProcessInstance.Text = My.App.SyMProcessInstance.ToUpper
        Me.tipInfo.SetToolTip(Me.lblProcessInstance, My.App.SyMProcessInstance)
        Me.tipInfo.SetToolTip(Me.picboxProcessInstance, My.App.SyMProcessInstance)
        Me.pbProcessProcessor.Value = data
        Me.lblProcessProcessor.Text = data.ToString + "%"
        Me.tipInfo.SetToolTip(Me.pbProcessProcessor, My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessProcessor) + VisualBasic.vbCr + data.ToString + "% (" + dataraw.ToString + ")")
    End Sub
    Friend Sub ShowDataProcessID(data As Integer)
        If Not Environment.Is64BitOperatingSystem Then
            Exit Sub
        End If
        Dim bText As String = String.Empty
        Dim p As Diagnostics.Process
        Dim bState As Boolean = False
        ' SAFETY: Process may have exited before we query it
        Try
            p = Diagnostics.Process.GetProcessById(data)
        Catch
            Exit Sub
        End Try

        Try
            If p.HasExited Then
                bText = String.Empty
            Else
                Try
                    Skye.WinAPI.IsWow64Process(p.Handle, bState)
                    bText = If(bState, " 32b", " 64b")
                Catch
                    bText = String.Empty
                End Try
            End If
        Catch
            bText = String.Empty
        Finally
            p.Dispose()
        End Try

        Me.tipInfo.SetToolTip(Me.lblProcessInstance, Me.tipInfo.GetToolTip(Me.lblProcessInstance) & " (" & data.ToString & ")" & bText)
        Me.tipInfo.SetToolTip(Me.picboxProcessInstance, Me.tipInfo.GetToolTip(Me.picboxProcessInstance) & " (" & data.ToString & ")" & bText)

    End Sub
    Friend Sub ShowDataProcessPriority(data As Integer)
        Me.tipInfo.SetToolTip(Me.lblProcessInstance, Me.tipInfo.GetToolTip(Me.lblProcessInstance) + VisualBasic.vbCr + My.App.SyMGetProcessPriority(data) + " (" + data.ToString + ")")
        Me.tipInfo.SetToolTip(Me.picboxProcessInstance, Me.tipInfo.GetToolTip(Me.picboxProcessInstance) + VisualBasic.vbCr + My.App.SyMGetProcessPriority(data) + " (" + data.ToString + ")")
    End Sub
    Friend Sub ShowDataProcessTime(data As Integer)
        Me.tipInfo.SetToolTip(Me.lblProcessInstance, Me.tipInfo.GetToolTip(Me.lblProcessInstance) + VisualBasic.vbCr + My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessTime) + " = " + TimeSpan.FromSeconds(data).ToString + " (" + data.ToString + ")")
        Me.tipInfo.SetToolTip(Me.picboxProcessInstance, Me.tipInfo.GetToolTip(Me.picboxProcessInstance) + VisualBasic.vbCr + My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessTime) + " = " + TimeSpan.FromSeconds(data).ToString + " (" + data.ToString + ")")
    End Sub
    Friend Sub ShowDataProcessThreads(data As Integer)
        Me.lblProcessThreads.Text = data.ToString + "T"
        Me.tipInfo.SetToolTip(Me.lblProcessThreads, data.ToString + " " + My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessThreads))
    End Sub
    Friend Sub ShowDataProcessHandles(data As Integer)
        Me.tipInfo.SetToolTip(Me.lblProcessThreads, Me.tipInfo.GetToolTip(Me.lblProcessThreads) + VisualBasic.vbCr + data.ToString + " " + My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessHandles))
    End Sub
    Friend Sub ShowDataProcessMemoryPhysical(data As Integer, dataraw As Single)
        Me.pbProcessMemoryPhysical.Value = data
        Me.pbProcessMemoryPhysical.Maximum = Me.pbMemoryPhysical.Value + AdjustDisplayMaximum(My.App.SyMMemoryPhysicalMaximum)
        Me.lblProcessMemoryPhysical.Text = data.ToString + "MB"
        Me.lblProcessMemoryPhysicalPercent.Text = CInt(data / Me.pbMemoryPhysical.Value * 100).ToString + "%"
        Me.tipInfo.SetToolTip(Me.pbProcessMemoryPhysical, My.App.SyMGetCounterDescription(My.App.SyMCounters.ProcessMemoryPhysical) + VisualBasic.vbCr + CInt(dataraw / My.App.MBConversion).ToString + " MB (" + dataraw.ToString("N0") + ")" + VisualBasic.vbCr + Me.lblProcessMemoryPhysicalPercent.Text + " of " + Me.lblMemoryPhysicalPercent.Text + " Overall Usage")
    End Sub

End Class
