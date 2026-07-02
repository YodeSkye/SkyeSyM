
Imports System.Diagnostics
Imports Skye.UI
Imports SkyeSyM.My

Partial Friend Class MainForm

    ' Declarations
    Private ni As NotifyIcon
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private DCInterval As Integer = 0
    Private DCFirstClick As Boolean = True
    Private DCDoubleClick As Boolean = False
    Private WithEvents DCTimer As New Timer

    ' Form Events
    Friend Sub New()

        ' Initialize Locals
        ni = New NotifyIcon With {
            .Text = My.Application.Info.ProductName,
            .Icon = My.Resources.Resources.iconApp}
        AddHandler ni.MouseUp, AddressOf NIMouseUp

        ' Initialize Form
        InitializeComponent()
        cmSM.Renderer = New Skye.UI.SkyeMenuRenderer
        components.Add(ni)
        ni.ContextMenuStrip = cmSM
        cmiExitApp.Text = "Exit " + My.Application.Info.ProductName
        cmiExitApp.ToolTipText = "RightClick = ReStart " + My.Application.Info.ProductName

    End Sub
    Private Sub FrmShown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        ' Hide From Task Switcher
        Dim style = Skye.WinAPI.GetWindowLong(Handle, Skye.WinAPI.GWL_EXSTYLE)
        style = (style Or Skye.WinAPI.WS_EX_TOOLWINDOW) And Not Skye.WinAPI.WS_EX_APPWINDOW
        Dim result = Skye.WinAPI.SetWindowLong(Handle, Skye.WinAPI.GWL_EXSTYLE, style)
        ni.Visible = True
    End Sub
    Private Sub FrmClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        ni.Visible = False
        My.App.Finalize()
    End Sub
    Private Sub FrmMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left And Me.WindowState = FormWindowState.Normal Then
            mMove = True
            mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight)
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
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then CheckMove(Me.Location)
    End Sub

    ' Control Events
    Private Sub NIMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Select Case e.Button
            Case MouseButtons.Left
                If DCFirstClick Then
                    DCFirstClick = False
                    DCTimer.Start()
                ElseIf DCInterval < SystemInformation.DoubleClickTime Then
                    DCDoubleClick = True
                End If
        End Select
    End Sub
    Private Sub CMISMMouseUp(sender As Object, e As MouseEventArgs) Handles cmiSM.MouseUp
        ShowSyM()
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
    Private Sub CMIHelp_MouseUp(sender As Object, e As MouseEventArgs) Handles cmiHelp.MouseUp
        App.ShowHelp()
    End Sub
    Private Sub CMILog_MouseUp(sender As Object, e As MouseEventArgs) Handles cmiLog.MouseUp
        App.ShowLog()
    End Sub
    Private Sub CMISettingsMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmiSettings.MouseUp
        App.ShowSettings()
    End Sub
    Private Sub CMICloseAllMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmiExitApp.MouseUp
        Close()
        If e.Button = MouseButtons.Right Then System.Windows.Forms.Application.Restart()
    End Sub

    ' Handlers
    Private Sub DCTimerTick(ByVal sender As Object, ByVal e As EventArgs) Handles DCTimer.Tick
        DCInterval += 100
        If DCInterval >= SystemInformation.DoubleClickTime Then
            DCTimer.Stop()
            DCInterval = 0
            DCFirstClick = True
            If DCDoubleClick Then
                'Debug.Print("niMouseUp: DOUBLEClick")
                DCDoubleClick = False
                App.ShowSettings()
            Else
                'Debug.Print("niMouseUp: LEFTClick")
                ShowSyM()
            End If
        End If
    End Sub

    ' Methods
    Friend Sub ShowSyM(Optional forcehide As Boolean = False)
        If My.App.FrmSyM.Visible Then
            App.FrmSyM.HideForm()
            ResetSystemUpTime()
            cmiSM.Checked = False
        ElseIf Not forcehide Then
            App.FrmSyM.ShowForm()
            cmiSM.Checked = True
        End If
    End Sub
    Friend Sub ResetSyM()
        If App.FrmSyM.Visible Then
            App.SyMSet()
            ShowSyM()
        Else : App.SyMSet()
        End If
    End Sub
    Friend Sub ShowDataSystemUpTime(data As Integer)
        Dim nitext = My.Application.Info.ProductName & vbCr
        Dim ts As TimeSpan = TimeSpan.FromSeconds(data)
        nitext &= $"System Up Time: {ts.Days}d {ts.Hours}h {ts.Minutes}m {ts.Seconds}s"
        ni.Text = nitext
    End Sub
    Friend Sub ResetSystemUpTime()
        ni.Text = My.Application.Info.ProductName
    End Sub

    Private Sub CheckMove(ByRef location As Point)
        If location.X + Me.Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Me.Width
        If location.Y + Me.Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Me.Height
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left
        If location.Y < My.Computer.Screen.WorkingArea.Top Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub

End Class
