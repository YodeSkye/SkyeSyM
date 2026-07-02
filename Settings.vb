
Imports Skye.UI
Imports SkyeSyM.My

Partial Friend Class Settings

    ' Declarations
    Private SMColorsUndo As My.App.SyMColors
    Private uiSMColors As New ColorDialog
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private nonNumberEntered As Boolean

    ' Form Events
    Friend Sub New()

        ' Initialize Locals
        uiSMColors.FullOpen = True

        ' Initialize Form
        InitializeComponent()
        Skye.UI.ThemeManager.RegisterComponent(TipMain)
        Skye.UI.ThemeManager.ApplyTheme(Me)
        For Each thm In SkyeThemes.AllThemes
            CoBoxTheme.Items.Add(thm.Name)
        Next
        ShowSettings()

    End Sub
    Private Sub FrmMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left And Me.WindowState = FormWindowState.Normal Then
            mMove = True
            mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width * 2, -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height * 2)
        End If
    End Sub
    Private Sub FrmMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub FrmMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        mMove = False
    End Sub
    Private Sub FrmMove(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso WindowState = FormWindowState.Normal Then CheckMove(Location)
    End Sub

    ' Control Events
    Private Sub LblSMOpacityMouseUp(sender As Object, e As MouseEventArgs) Handles lblSMOpacity.MouseUp
        If e.Button = MouseButtons.Left AndAlso Not My.App.SyMOpacity = 100 Then
            My.App.SyMOpacity = 100
            Me.comboboxSMOpacity.SelectedItem = "100"
            Me.comboboxSMOpacity.Select()
            My.App.FrmSyM.SetOpacity()
        End If
    End Sub
    Private Sub TxbxNumbersOnlyKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles textboxSMUpdateInterval.KeyDown, textboxSMQuickHideInterval.KeyDown, textboxSMNetworkUploadMaximum.KeyDown, textboxSMNetworkDownloadMaximum.KeyDown
        nonNumberEntered = False
        If (e.KeyCode < Keys.D0 Or e.KeyCode > Keys.D9) And (e.KeyCode < Keys.NumPad0 Or e.KeyCode > Keys.NumPad9) Then
            If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Enter Then : nonNumberEntered = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                e.Handled = True
                Validate()
            End If
        End If
    End Sub
    Private Sub TxbxNumbersOnlyKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textboxSMUpdateInterval.KeyPress, textboxSMQuickHideInterval.KeyPress, textboxSMNetworkUploadMaximum.KeyPress, textboxSMNetworkDownloadMaximum.KeyPress
        If nonNumberEntered Then e.Handled = True
    End Sub
    Private Sub TxbxHKPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles txbxHKSM.PreviewKeyDown
        Dim senderTextBox As TextBox = CType(sender, TextBox)
        Dim senderTag As My.App.HKType = CType(senderTextBox.Tag, My.App.HKType)
        If e.KeyData <> senderTag.Key Then
            'Setup New HotKey
            Dim newhotkey As New My.App.HKType
            Dim modifiers As Integer = 0
            If e.Shift Then modifiers += Skye.WinAPI.MOD_SHIFT
            If e.Control Then modifiers += Skye.WinAPI.MOD_CONTROL
            If e.Alt Then modifiers += Skye.WinAPI.MOD_ALT
            newhotkey.WinID = senderTag.WinID
            newhotkey.Key = e.KeyData
            newhotkey.KeyCode = CByte(e.KeyValue)
            newhotkey.KeyMod = CByte(modifiers)
            'Display New HotKey
            senderTextBox.Font = New Font(Me.Font, FontStyle.Regular)
            senderTextBox.ForeColor = Color.Maroon
            senderTextBox.Text = e.KeyData.ToString
            senderTextBox.Tag = newhotkey
            Me.btnHKUndo.Enabled = True
            Me.btnHKSet.Enabled = True
        End If
    End Sub
    Private Sub TxbxHKKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txbxHKSM.KeyPress
        e.Handled = True
    End Sub
    Private Sub TxbxSMUpdateIntervalValidating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles textboxSMUpdateInterval.Validating
        If Int(Val(Me.textboxSMUpdateInterval.Text)) < 250 Then Me.textboxSMUpdateInterval.Text = "250"
        If Int(Val(Me.textboxSMUpdateInterval.Text)) > 60000 Then Me.textboxSMUpdateInterval.Text = "60000"
    End Sub
    Private Sub TxbxSMUpdateIntervalValidated(sender As Object, e As EventArgs) Handles textboxSMUpdateInterval.Validated
        If Not App.SyMUpdateInterval = Int(Val(textboxSMUpdateInterval.Text)) Then
            App.SyMUpdateInterval = CUShort(Val(textboxSMUpdateInterval.Text))
            App.SaveSettings()
            textboxSMUpdateInterval.SelectAll()
            App.FrmMain.ResetSyM()
        End If
    End Sub
    Private Sub TxbxSMQuickHideIntervalValidating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles textboxSMQuickHideInterval.Validating
        If Int(Val(Me.textboxSMQuickHideInterval.Text)) < 5 Then Me.textboxSMQuickHideInterval.Text = "5"
        If Int(Val(Me.textboxSMQuickHideInterval.Text)) > 60 Then Me.textboxSMQuickHideInterval.Text = "60"
    End Sub
    Private Sub TxbxSMQuickHideIntervalValidated(sender As Object, e As EventArgs) Handles textboxSMQuickHideInterval.Validated
        If Not App.SyMQuickHideInterval = CByte(Val(textboxSMQuickHideInterval.Text)) Then
            App.SyMQuickHideInterval = CByte(Val(textboxSMQuickHideInterval.Text))
            App.SaveSettings()
            textboxSMQuickHideInterval.SelectAll()
            App.FrmMain.ResetSyM()
        End If
    End Sub
    Private Sub TxbxSMNetworkDownloadMaximumValidating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles textboxSMNetworkDownloadMaximum.Validating
        If CInt(Val(Me.textboxSMNetworkDownloadMaximum.Text)) > UInt16.MaxValue Then Me.textboxSMNetworkDownloadMaximum.Text = UInt16.MaxValue.ToString
    End Sub
    Private Sub TxbxSMNetworkDownloadMaximumValidated(sender As Object, e As EventArgs) Handles textboxSMNetworkDownloadMaximum.Validated
        If Not App.SyMNetworkDownloadMaximum = Int(Val(textboxSMNetworkDownloadMaximum.Text)) Then
            App.SyMNetworkDownloadMaximum = CUShort(Val(textboxSMNetworkDownloadMaximum.Text))
            App.SaveSettings()
            textboxSMNetworkDownloadMaximum.SelectAll()
            App.FrmMain.ResetSyM()
        End If
    End Sub
    Private Sub TxbxSMNetworkUploadMaximumValidating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles textboxSMNetworkUploadMaximum.Validating
        If CInt(Val(Me.textboxSMNetworkUploadMaximum.Text)) > UInt16.MaxValue Then Me.textboxSMNetworkUploadMaximum.Text = UInt16.MaxValue.ToString
    End Sub
    Private Sub TxbxSMNetworkUploadMaximumValidated(sender As Object, e As EventArgs) Handles textboxSMNetworkUploadMaximum.Validated
        If Not App.SyMNetworkUploadMaximum = Int(Val(textboxSMNetworkUploadMaximum.Text)) Then
            App.SyMNetworkUploadMaximum = CUShort(Val(textboxSMNetworkUploadMaximum.Text))
            App.SaveSettings()
            textboxSMNetworkUploadMaximum.SelectAll()
            App.FrmMain.ResetSyM()
        End If
    End Sub
    Private Sub CoBxSMNetworkInstanceSelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxSMNetworkInstance.SelectedIndexChanged
        If Not SyMNetworkInstance = comboboxSMNetworkInstance.Text Then
            SyMNetworkInstance = comboboxSMNetworkInstance.Text
            SaveSettings()
            FrmMain.ResetSyM()
        End If
    End Sub
    Private Sub CoBxSMOpacitySelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxSMOpacity.SelectedIndexChanged
        If Not SyMOpacity.ToString = comboboxSMOpacity.Text Then
            SyMOpacity = CByte(Val(comboboxSMOpacity.Text))
            FrmSyM.SetOpacity()
            SaveSettings()
        End If
    End Sub
    Private Sub CoBxTheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CoBoxTheme.SelectedIndexChanged
        Dim selectedName As String = CoBoxTheme.SelectedItem.ToString()
        Dim selected As Skye.UI.SkyeTheme = Skye.UI.SkyeThemes.GetTheme(selectedName)
        App.Theme = selected
        If Not App.ThemeAuto Then
            Skye.UI.ThemeManager.SetTheme(selected)
            ShowSettings()
        End If
        App.SaveSettings()
    End Sub
    Private Sub ChbxSMAutoMinimalClick(sender As Object, e As EventArgs) Handles chbxSMAutoMinimal.Click
        App.SyMAutoMinimal = Not App.SyMAutoMinimal
        App.SaveSettings()
        If Not App.SyMAutoMinimal Then App.FrmSyM.SetBackColor()
    End Sub
    Private Sub ChbxSMAutoCloseClick(sender As Object, e As EventArgs) Handles chbxSMAutoClose.Click
        App.SyMAutoClose = Not App.SyMAutoClose
        App.SaveSettings()
    End Sub
    Private Sub ChkBoxThemeAuto_Click(sender As Object, e As EventArgs) Handles ChkBoxThemeAuto.Click
        App.ThemeAuto = ChkBoxThemeAuto.Checked
        SetThemesList()
        If App.ThemeAuto Then
            Skye.UI.ThemeManager.SetTheme(Skye.UI.ThemeManager.DetectWindowsTheme())
        Else
            Skye.UI.ThemeManager.SetTheme(App.Theme)
        End If
        App.SaveSettings()
    End Sub
    Private Sub BtnCloseClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub BtnHKDisableClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnHKSMDisable.Click
        Dim senderTextBox As New TextBox
        Dim senderTag As New My.App.HKType
        Select Case CType(sender, Button).Name
            Case Me.btnHKSMDisable.Name
                senderTextBox = Me.txbxHKSM
                senderTag = CType(Me.txbxHKSM.Tag, My.App.HKType)
        End Select

        Dim newhotkey As New My.App.HKType With {
            .WinID = senderTag.WinID,
            .Key = Keys.None,
            .KeyCode = 0,
            .KeyMod = 0}
        senderTextBox.Font = New Font(Me.Font, FontStyle.Regular)
        senderTextBox.ForeColor = Color.Maroon
        senderTextBox.Text = newhotkey.Key.ToString
        senderTextBox.Tag = newhotkey
        Me.btnHKUndo.Enabled = True
        Me.btnHKSet.Enabled = True
        Me.btnHKSet.Focus()
    End Sub
    Private Sub BtnHKDisableEnter(ByVal sender As Object, ByVal e As EventArgs) Handles btnHKSMDisable.Enter
        If Me.btnHKSet.Enabled Then : Me.btnHKSet.Focus()
        Else : Me.btnClose.Focus()
        End If
    End Sub
    Private Sub BtnHKSetClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnHKSet.Click
        If Not CType(Me.txbxHKSM.Tag, My.App.HKType).Key = My.App.HKSyM.Key Then
            My.App.HKRegister(False)
            My.App.HKSyM = CType(Me.txbxHKSM.Tag, My.App.HKType)
            My.App.HKRegister(True)
            App.SaveSettings()
            ShowSettings()
        End If
    End Sub
    Private Sub BtnHKUndoClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnHKUndo.Click
        ShowSettings()
    End Sub
    Private Sub BtnHKEnabledClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnHKEnabled.Click
        If My.App.HKEnabled Then
            My.App.HKRegister(False)
            My.App.HKEnabled = False
        Else
            My.App.HKEnabled = True
            My.App.HKRegister(True)
        End If
        ShowSettings()
    End Sub
    Private Sub BtnSMColorMouseUp(sender As Object, e As MouseEventArgs) Handles btnSMColorForegroundOnBackground.MouseUp, btnSMColorForeground.MouseUp, btnSMColorBarUserForeground.MouseUp, btnSMColorBarSystemForeground.MouseUp, btnSMColorBarForeground.MouseUp, btnSMColorBarBackground.MouseUp, btnSMColorBackground.MouseUp
        Select Case e.Button
            Case MouseButtons.Left
                If sender Is Me.btnSMColorBackground Then : uiSMColors.Color = My.App.SyMColor.Background
                ElseIf sender Is Me.btnSMColorForegroundOnBackground Then : uiSMColors.Color = My.App.SyMColor.ForegroundOnBackground
                ElseIf sender Is Me.btnSMColorForeground Then : uiSMColors.Color = My.App.SyMColor.Foreground
                ElseIf sender Is Me.btnSMColorBarBackground Then : uiSMColors.Color = My.App.SyMColor.BarBackground
                ElseIf sender Is Me.btnSMColorBarForeground Then : uiSMColors.Color = My.App.SyMColor.BarForeground
                ElseIf sender Is Me.btnSMColorBarUserForeground Then : uiSMColors.Color = My.App.SyMColor.BarProcessorUserForeground
                ElseIf sender Is Me.btnSMColorBarSystemForeground Then : uiSMColors.Color = My.App.SyMColor.BarProcessorSystemForeground
                End If
                uiSMColors.ShowDialog(Me)
                If Not DirectCast(sender, Button).BackColor = uiSMColors.Color Then
                    If My.App.SyMColors.IsNullOrEmpty(SMColorsUndo) Then SyMColorsSetUndo()
                    If sender Is Me.btnSMColorBackground Then : My.App.SyMColor.Background = uiSMColors.Color
                    ElseIf sender Is Me.btnSMColorForegroundOnBackground Then : My.App.SyMColor.ForegroundOnBackground = uiSMColors.Color
                    ElseIf sender Is Me.btnSMColorForeground Then : My.App.SyMColor.Foreground = uiSMColors.Color
                    ElseIf sender Is Me.btnSMColorBarBackground Then : My.App.SyMColor.BarBackground = uiSMColors.Color
                    ElseIf sender Is Me.btnSMColorBarForeground Then : My.App.SyMColor.BarForeground = uiSMColors.Color
                    ElseIf sender Is Me.btnSMColorBarUserForeground Then : My.App.SyMColor.BarProcessorUserForeground = uiSMColors.Color
                    ElseIf sender Is Me.btnSMColorBarSystemForeground Then : My.App.SyMColor.BarProcessorSystemForeground = uiSMColors.Color
                    End If
                    App.SaveSettings()
                    ShowSettings()
                    Me.Refresh()
                    App.FrmMain.ResetSyM()
                End If
            Case MouseButtons.Right
                Dim frmColor As New SkyeSyM.ColorSelector
                If sender Is Me.btnSMColorBackground Then : frmColor.combobxColor.Color = SyMGetColor(My.App.SyMColor.Background.ToArgb)
                ElseIf sender Is Me.btnSMColorForegroundOnBackground Then : frmColor.combobxColor.Color = SyMGetColor(My.App.SyMColor.ForegroundOnBackground.ToArgb)
                ElseIf sender Is Me.btnSMColorForeground Then : frmColor.combobxColor.Color = SyMGetColor(My.App.SyMColor.Foreground.ToArgb)
                ElseIf sender Is Me.btnSMColorBarBackground Then : frmColor.combobxColor.Color = SyMGetColor(My.App.SyMColor.BarBackground.ToArgb)
                ElseIf sender Is Me.btnSMColorBarForeground Then : frmColor.combobxColor.Color = SyMGetColor(My.App.SyMColor.BarForeground.ToArgb)
                ElseIf sender Is Me.btnSMColorBarUserForeground Then : frmColor.combobxColor.Color = SyMGetColor(My.App.SyMColor.BarProcessorUserForeground.ToArgb)
                ElseIf sender Is Me.btnSMColorBarSystemForeground Then : frmColor.combobxColor.Color = SyMGetColor(My.App.SyMColor.BarProcessorSystemForeground.ToArgb)
                End If
                frmColor.Location = MousePosition
                frmColor.Tag = DirectCast(sender, Button).Name
                frmColor.ShowDialog(Me)
                If frmColor.DialogResult = System.Windows.Forms.DialogResult.OK Then
                    'Debug.Print("btnSMColorMouseUp: " + frmColor.combobxColor.Color.ToString)
                    If My.App.SyMColors.IsNullOrEmpty(SMColorsUndo) Then SyMColorsSetUndo()
                    Select Case frmColor.Tag.ToString
                        Case Me.btnSMColorBackground.Name : My.App.SyMColor.Background = frmColor.combobxColor.Color
                        Case Me.btnSMColorForegroundOnBackground.Name : My.App.SyMColor.ForegroundOnBackground = frmColor.combobxColor.Color
                        Case Me.btnSMColorForeground.Name : My.App.SyMColor.Foreground = frmColor.combobxColor.Color
                        Case Me.btnSMColorBarBackground.Name : My.App.SyMColor.BarBackground = frmColor.combobxColor.Color
                        Case Me.btnSMColorBarForeground.Name : My.App.SyMColor.BarForeground = frmColor.combobxColor.Color
                        Case Me.btnSMColorBarUserForeground.Name : My.App.SyMColor.BarProcessorUserForeground = frmColor.combobxColor.Color
                        Case Me.btnSMColorBarSystemForeground.Name : My.App.SyMColor.BarProcessorSystemForeground = frmColor.combobxColor.Color
                    End Select
                    App.SaveSettings()
                    ShowSettings()
                    Me.Refresh()
                    App.FrmMain.ResetSyM()
                End If
                frmColor.Dispose()
        End Select
    End Sub
    Private Sub BtnSMColorsUndoMouseUp(sender As Object, e As MouseEventArgs) Handles btnSMColorsUndo.MouseUp
        Select Case e.Button
            Case MouseButtons.Left
                My.App.SyMColor = Me.SMColorsUndo
                App.SaveSettings()
                SyMColorsResetUndo()
                ShowSettings()
                Me.Refresh()
                App.FrmMain.ResetSyM()
            Case MouseButtons.Right : SyMColorsResetUndo()
        End Select
    End Sub
    Private Sub BtnSMColorsDefaultsClick(sender As Object, e As EventArgs) Handles btnSMColorsDefaults.Click
        If My.App.SyMColors.IsNullOrEmpty(SMColorsUndo) Then SyMColorsSetUndo()
        My.App.SyMColor = My.App.SyMColors.Defaults
        App.SaveSettings()
        ShowSettings()
        Me.Refresh()
        App.FrmMain.ResetSyM()
    End Sub

    ' Methods
    Friend Sub ShowSettings()
        SuspendLayout()

        'HotKeys
        txbxHKSM.Text = App.HKSyM.Key.ToString
        txbxHKSM.Tag = App.HKSyM
        txbxHKSM.Font = New Font(Font, FontStyle.Bold)
        txbxHKSM.ForeColor = Color.Teal
        btnHKUndo.Enabled = False
        btnHKSet.Enabled = False
        If My.App.HKEnabled Then
            lblHKSM.Enabled = True
            txbxHKSM.Enabled = True
            btnHKSMDisable.Enabled = True
            btnHKEnabled.Text = "Disable"
            TipMain.SetText(btnHKEnabled, "Disable HotKeys")
            TipMain.SetImage(btnHKEnabled, My.Resources.Resources.ImageHKDisable32)
            btnHKEnabled.Image = My.Resources.Resources.ImageHKDisable32
        Else
            lblHKSM.Enabled = False
            txbxHKSM.Enabled = False
            btnHKSMDisable.Enabled = False
            btnHKEnabled.Text = "Enable"
            TipMain.SetText(btnHKEnabled, "Enable HotKeys")
            TipMain.SetImage(btnHKEnabled, My.Resources.Resources.ImageHKEnable32)
            btnHKEnabled.Image = My.Resources.Resources.ImageHKEnable32
        End If

        'SyM
        chbxSMAutoMinimal.Checked = App.SyMAutoMinimal
        chbxSMAutoClose.Checked = App.SyMAutoClose
        textboxSMUpdateInterval.Text = App.SyMUpdateInterval.ToString
        textboxSMQuickHideInterval.Text = App.SyMQuickHideInterval.ToString
        comboboxSMOpacity.SelectedItem = App.SyMOpacity.ToString
        textboxSMNetworkDownloadMaximum.Text = App.SyMNetworkDownloadMaximum.ToString
        textboxSMNetworkUploadMaximum.Text = App.SyMNetworkUploadMaximum.ToString
        comboboxSMNetworkInstance.Items.Clear()
        comboboxSMNetworkInstance.Items.AddRange(App.SyMGetNetworkInstanceNames)
        comboboxSMNetworkInstance.SelectedItem = App.SyMNetworkInstance
        btnSMColorBackground.BackColor = App.SyMColor.Background
        btnSMColorForegroundOnBackground.BackColor = App.SyMColor.ForegroundOnBackground
        btnSMColorForeground.BackColor = App.SyMColor.Foreground
        btnSMColorBarBackground.BackColor = App.SyMColor.BarBackground
        btnSMColorBarForeground.BackColor = App.SyMColor.BarForeground
        btnSMColorBarUserForeground.BackColor = App.SyMColor.BarProcessorUserForeground
        btnSMColorBarSystemForeground.BackColor = App.SyMColor.BarProcessorSystemForeground

        'Theme
        CoBoxTheme.SelectedItem = App.Theme.Name
        ChkBoxThemeAuto.Checked = App.ThemeAuto
        SetThemesList()

        ResumeLayout()
        btnClose.Select()
    End Sub
    Private Sub SetThemesList()
        If App.ThemeAuto Then
            CoBoxTheme.Enabled = False
        Else
            CoBoxTheme.Enabled = True
        End If
    End Sub
    Private Sub SyMColorsSetUndo()
        Me.SMColorsUndo = My.App.SyMColor
        Me.btnSMColorsUndo.Enabled = True
    End Sub
    Private Sub SyMColorsResetUndo()
        Me.btnSMColorsUndo.Enabled = False
        Me.SMColorsUndo = Nothing
    End Sub
    Private Sub CheckMove(ByRef location As Point)
        Dim screen = System.Windows.Forms.Screen.FromControl(Me).WorkingArea
        If location.X + Width > screen.Right Then location.X = screen.Right - Width + App.AdjustScreenBoundsNormalWindow
        If location.Y + Height > screen.Bottom Then location.Y = screen.Bottom - Height + App.AdjustScreenBoundsNormalWindow
        If location.X < screen.Left Then location.X = screen.Left - App.AdjustScreenBoundsNormalWindow
        If location.Y < screen.Top Then location.Y = screen.Top
    End Sub
    Private Function SyMGetColor(rgb As Integer) As Color
        For Each kc As KnownColor In [Enum].GetValues(Of KnownColor)()
            If Color.FromKnownColor(kc).ToArgb() = rgb Then Return Color.FromName(kc.ToString())
        Next
        Return Nothing
    End Function

End Class
