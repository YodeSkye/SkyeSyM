Friend Partial Class MainForm
Inherits System.Windows.Forms.Form
	Private components As System.ComponentModel.IContainer
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then components.Dispose
		End If
		MyBase.Dispose(disposing)
	End Sub
    Private Sub InitializeComponent
        components = New ComponentModel.Container()
        cmSM = New ContextMenuStrip(components)
        cmiSM = New ToolStripMenuItem()
        cmiWindowsMonitor = New ToolStripMenuItem()
        toolStripSeparator1 = New ToolStripSeparator()
        cmiHelp = New ToolStripMenuItem()
        cmiLog = New ToolStripMenuItem()
        cmiSettings = New ToolStripMenuItem()
        toolStripSeparator2 = New ToolStripSeparator()
        cmiExitApp = New ToolStripMenuItem()
        tableLayoutPanel2 = New TableLayoutPanel()
        cmSM.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmSM
        ' 
        cmSM.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmSM.Items.AddRange(New ToolStripItem() {cmiSM, cmiWindowsMonitor, toolStripSeparator1, cmiHelp, cmiLog, cmiSettings, toolStripSeparator2, cmiExitApp})
        cmSM.Name = "contextmenuWorkSpaceTools"
        cmSM.Size = New Size(181, 170)
        ' 
        ' cmiSM
        ' 
        cmiSM.Image = My.Resources.Resources.imageSM
        cmiSM.Name = "cmiSM"
        cmiSM.Size = New Size(180, 22)
        cmiSM.Text = "System Monitor"
        ' 
        ' cmiWindowsMonitor
        ' 
        cmiWindowsMonitor.Image = My.Resources.Resources.imageTaskManager
        cmiWindowsMonitor.Name = "cmiWindowsMonitor"
        cmiWindowsMonitor.Size = New Size(180, 22)
        cmiWindowsMonitor.Text = "Windows Monitor"
        cmiWindowsMonitor.ToolTipText = "LeftClick = Task Manager" & vbCrLf & "RightClick = Resource Monitor" & vbCrLf & "CtrlRightClick = Performance Monitor"
        ' 
        ' toolStripSeparator1
        ' 
        toolStripSeparator1.Name = "toolStripSeparator1"
        toolStripSeparator1.Size = New Size(177, 6)
        ' 
        ' cmiHelp
        ' 
        cmiHelp.Image = My.Resources.Resources.imageInfo
        cmiHelp.Name = "cmiHelp"
        cmiHelp.Size = New Size(180, 22)
        cmiHelp.Text = "Help && About"
        cmiHelp.ToolTipText = "RightClick = Show Maximized"
        ' 
        ' cmiLog
        ' 
        cmiLog.Image = My.Resources.Resources.imageLog
        cmiLog.Name = "cmiLog"
        cmiLog.Size = New Size(180, 22)
        cmiLog.Text = "Log"
        ' 
        ' cmiSettings
        ' 
        cmiSettings.Image = My.Resources.Resources.imageSettings
        cmiSettings.Name = "cmiSettings"
        cmiSettings.Size = New Size(180, 22)
        cmiSettings.Text = "Settings"
        ' 
        ' toolStripSeparator2
        ' 
        toolStripSeparator2.Name = "toolStripSeparator2"
        toolStripSeparator2.Size = New Size(177, 6)
        ' 
        ' cmiExitApp
        ' 
        cmiExitApp.Image = My.Resources.Resources.imageClose
        cmiExitApp.Name = "cmiExitApp"
        cmiExitApp.Size = New Size(180, 22)
        ' 
        ' tableLayoutPanel2
        ' 
        tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        tableLayoutPanel2.ColumnCount = 2
        tableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.Location = New Point(0, 0)
        tableLayoutPanel2.Name = "tableLayoutPanel2"
        tableLayoutPanel2.RowCount = 4
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.Size = New Size(200, 100)
        tableLayoutPanel2.TabIndex = 0
        ' 
        ' MainForm
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(238, 72)
        ControlBox = False
        MaximizeBox = False
        MinimizeBox = False
        Name = "MainForm"
        Opacity = 0R
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        WindowState = FormWindowState.Minimized
        cmSM.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmiWindowsMonitor As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmSM As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiHelp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiLog As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiExitApp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiSettings As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiSM As System.Windows.Forms.ToolStripMenuItem
    Private tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
End Class