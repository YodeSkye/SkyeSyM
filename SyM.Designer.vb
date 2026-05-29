Friend Partial Class SyM
Inherits System.Windows.Forms.Form
	Private components As System.ComponentModel.IContainer
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
    Private Sub InitializeComponent
        components = New ComponentModel.Container()
        lblProcessor = New Label()
        lblMemoryPhysical = New Label()
        lblDisk0 = New Label()
        lblNetworkDownload = New Label()
        cmiOpacity = New ToolStripMenuItem()
        cmOpacity = New ContextMenuStrip(components)
        cmiOpacity100 = New ToolStripMenuItem()
        cmiOpacity90 = New ToolStripMenuItem()
        cmiOpacity80 = New ToolStripMenuItem()
        cmiOpacity70 = New ToolStripMenuItem()
        cmiOpacity60 = New ToolStripMenuItem()
        cmiOpacity50 = New ToolStripMenuItem()
        cmiOpacity40 = New ToolStripMenuItem()
        cmiOpacity30 = New ToolStripMenuItem()
        cmiOpacity20 = New ToolStripMenuItem()
        cmiOpacity10 = New ToolStripMenuItem()
        cmSM = New ContextMenuStrip(components)
        cmiQuickHide = New ToolStripMenuItem()
        cmiClose = New ToolStripMenuItem()
        toolStripSeparator1 = New ToolStripSeparator()
        cmiWindowsMonitor = New ToolStripMenuItem()
        cmiProcessInstance = New ToolStripMenuItem()
        CMPI = New ContextMenuStrip(components)
        TSSPIPins = New ToolStripSeparator()
        CMIPIMore = New ToolStripMenuItem()
        CMIPIAttach = New ToolStripMenuItem()
        CMIPIPinToggle = New ToolStripMenuItem()
        toolStripSeparator3 = New ToolStripSeparator()
        cmiAutoMinimal = New ToolStripMenuItem()
        lblNetworkUpload = New Label()
        picboxProcessor = New PictureBox()
        picboxMemory = New PictureBox()
        picboxDisk = New PictureBox()
        picboxNetwork = New PictureBox()
        lblProcesses = New Label()
        lblMemoryPhysicalPercent = New Label()
        lblProcessProcessor = New Label()
        lblProcessThreads = New Label()
        lblProcessMemoryPhysical = New Label()
        lblProcessMemoryPhysicalPercent = New Label()
        lblProcessInstance = New Label()
        picboxProcessInstance = New PictureBox()
        lblDisk1 = New Label()
        pbProcessMemoryPhysical = New Skye.UI.DataBar()
        pbMemoryPhysical = New Skye.UI.DataBar()
        pbProcessProcessor = New Skye.UI.DataBar()
        pbProcessor = New Skye.UI.DataBar()
        pbProcessorSystem = New Skye.UI.DataBar()
        pbProcessorUser = New Skye.UI.DataBar()
        pbDisk0 = New Skye.UI.DataBar()
        pbNetworkDownload = New Skye.UI.DataBar()
        pbNetworkUpload = New Skye.UI.DataBar()
        pbDisk1 = New Skye.UI.DataBar()
        cmOpacity.SuspendLayout()
        cmSM.SuspendLayout()
        CMPI.SuspendLayout()
        CType(picboxProcessor, ComponentModel.ISupportInitialize).BeginInit()
        CType(picboxMemory, ComponentModel.ISupportInitialize).BeginInit()
        CType(picboxDisk, ComponentModel.ISupportInitialize).BeginInit()
        CType(picboxNetwork, ComponentModel.ISupportInitialize).BeginInit()
        CType(picboxProcessInstance, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblProcessor
        ' 
        lblProcessor.ForeColor = Color.Crimson
        lblProcessor.Location = New Point(24, 7)
        lblProcessor.Name = "lblProcessor"
        lblProcessor.Size = New Size(58, 17)
        lblProcessor.TabIndex = 0
        lblProcessor.Text = "VALUE"
        lblProcessor.TextAlign = ContentAlignment.BottomLeft
        lblProcessor.UseMnemonic = False
        ' 
        ' lblMemoryPhysical
        ' 
        lblMemoryPhysical.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMemoryPhysical.ForeColor = Color.Crimson
        lblMemoryPhysical.Location = New Point(34, 62)
        lblMemoryPhysical.Name = "lblMemoryPhysical"
        lblMemoryPhysical.Size = New Size(76, 17)
        lblMemoryPhysical.TabIndex = 5
        lblMemoryPhysical.Text = "VALUE"
        lblMemoryPhysical.TextAlign = ContentAlignment.BottomRight
        lblMemoryPhysical.UseMnemonic = False
        ' 
        ' lblDisk0
        ' 
        lblDisk0.ForeColor = Color.Crimson
        lblDisk0.Location = New Point(24, 92)
        lblDisk0.Name = "lblDisk0"
        lblDisk0.Size = New Size(80, 17)
        lblDisk0.TabIndex = 15
        lblDisk0.Text = "VALUE"
        lblDisk0.TextAlign = ContentAlignment.BottomLeft
        lblDisk0.UseMnemonic = False
        ' 
        ' lblNetworkDownload
        ' 
        lblNetworkDownload.ForeColor = Color.Crimson
        lblNetworkDownload.Location = New Point(24, 123)
        lblNetworkDownload.Name = "lblNetworkDownload"
        lblNetworkDownload.Size = New Size(168, 17)
        lblNetworkDownload.TabIndex = 20
        lblNetworkDownload.Text = "VALUE"
        lblNetworkDownload.TextAlign = ContentAlignment.BottomLeft
        lblNetworkDownload.UseMnemonic = False
        ' 
        ' cmiOpacity
        ' 
        cmiOpacity.DropDown = cmOpacity
        cmiOpacity.Image = My.Resources.Resources.imageOpacity
        cmiOpacity.Name = "cmiOpacity"
        cmiOpacity.Size = New Size(180, 22)
        cmiOpacity.ToolTipText = "LeftClick = Make Opaque"
        ' 
        ' cmOpacity
        ' 
        cmOpacity.AllowMerge = False
        cmOpacity.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmOpacity.Items.AddRange(New ToolStripItem() {cmiOpacity100, cmiOpacity90, cmiOpacity80, cmiOpacity70, cmiOpacity60, cmiOpacity50, cmiOpacity40, cmiOpacity30, cmiOpacity20, cmiOpacity10})
        cmOpacity.Name = "cmOpacity"
        cmOpacity.OwnerItem = cmiOpacity
        cmOpacity.ShowItemToolTips = False
        cmOpacity.Size = New Size(113, 224)
        ' 
        ' cmiOpacity100
        ' 
        cmiOpacity100.Name = "cmiOpacity100"
        cmiOpacity100.Size = New Size(112, 22)
        cmiOpacity100.Tag = "100"
        cmiOpacity100.Text = "100 %"
        ' 
        ' cmiOpacity90
        ' 
        cmiOpacity90.Name = "cmiOpacity90"
        cmiOpacity90.Size = New Size(112, 22)
        cmiOpacity90.Tag = "90"
        cmiOpacity90.Text = " 90 %"
        ' 
        ' cmiOpacity80
        ' 
        cmiOpacity80.Name = "cmiOpacity80"
        cmiOpacity80.Size = New Size(112, 22)
        cmiOpacity80.Tag = "80"
        cmiOpacity80.Text = " 80 %"
        ' 
        ' cmiOpacity70
        ' 
        cmiOpacity70.Name = "cmiOpacity70"
        cmiOpacity70.Size = New Size(112, 22)
        cmiOpacity70.Tag = "70"
        cmiOpacity70.Text = " 70 %"
        ' 
        ' cmiOpacity60
        ' 
        cmiOpacity60.Name = "cmiOpacity60"
        cmiOpacity60.Size = New Size(112, 22)
        cmiOpacity60.Tag = "60"
        cmiOpacity60.Text = " 60 %"
        ' 
        ' cmiOpacity50
        ' 
        cmiOpacity50.Name = "cmiOpacity50"
        cmiOpacity50.Size = New Size(112, 22)
        cmiOpacity50.Tag = "50"
        cmiOpacity50.Text = " 50 %"
        ' 
        ' cmiOpacity40
        ' 
        cmiOpacity40.Name = "cmiOpacity40"
        cmiOpacity40.Size = New Size(112, 22)
        cmiOpacity40.Tag = "40"
        cmiOpacity40.Text = " 40 %"
        ' 
        ' cmiOpacity30
        ' 
        cmiOpacity30.Name = "cmiOpacity30"
        cmiOpacity30.Size = New Size(112, 22)
        cmiOpacity30.Tag = "30"
        cmiOpacity30.Text = " 30 %"
        ' 
        ' cmiOpacity20
        ' 
        cmiOpacity20.Name = "cmiOpacity20"
        cmiOpacity20.Size = New Size(112, 22)
        cmiOpacity20.Tag = "20"
        cmiOpacity20.Text = " 20 %"
        ' 
        ' cmiOpacity10
        ' 
        cmiOpacity10.Name = "cmiOpacity10"
        cmiOpacity10.Size = New Size(112, 22)
        cmiOpacity10.Tag = "10"
        cmiOpacity10.Text = " 10 %"
        ' 
        ' cmSM
        ' 
        cmSM.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmSM.Items.AddRange(New ToolStripItem() {cmiQuickHide, cmiClose, toolStripSeparator1, cmiWindowsMonitor, cmiProcessInstance, toolStripSeparator3, cmiAutoMinimal, cmiOpacity})
        cmSM.Name = "cmSM"
        cmSM.Size = New Size(181, 148)
        ' 
        ' cmiQuickHide
        ' 
        cmiQuickHide.Image = My.Resources.Resources.imageWindowHide
        cmiQuickHide.Name = "cmiQuickHide"
        cmiQuickHide.Size = New Size(180, 22)
        cmiQuickHide.Text = "Quick Hide"
        ' 
        ' cmiClose
        ' 
        cmiClose.Image = My.Resources.Resources.imageClose
        cmiClose.Name = "cmiClose"
        cmiClose.Size = New Size(180, 22)
        cmiClose.Text = "Close"
        ' 
        ' toolStripSeparator1
        ' 
        toolStripSeparator1.Name = "toolStripSeparator1"
        toolStripSeparator1.Size = New Size(177, 6)
        ' 
        ' cmiWindowsMonitor
        ' 
        cmiWindowsMonitor.Image = My.Resources.Resources.imageTaskManager
        cmiWindowsMonitor.Name = "cmiWindowsMonitor"
        cmiWindowsMonitor.ShortcutKeyDisplayString = ""
        cmiWindowsMonitor.Size = New Size(180, 22)
        cmiWindowsMonitor.Text = "Windows Monitor"
        cmiWindowsMonitor.ToolTipText = "LeftClick = Task Manager" & vbCrLf & "RightClick = Resource Monitor" & vbCrLf & "CtrlRightClick = Performance Monitor"
        ' 
        ' cmiProcessInstance
        ' 
        cmiProcessInstance.DropDown = CMPI
        cmiProcessInstance.Image = My.Resources.Resources.imageSMProcessor
        cmiProcessInstance.Name = "cmiProcessInstance"
        cmiProcessInstance.Size = New Size(180, 22)
        ' 
        ' CMPI
        ' 
        CMPI.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CMPI.Items.AddRange(New ToolStripItem() {TSSPIPins, CMIPIMore, CMIPIAttach, CMIPIPinToggle})
        CMPI.Name = "CMPI"
        CMPI.OwnerItem = cmiProcessInstance
        CMPI.Size = New Size(230, 76)
        ' 
        ' TSSPIPins
        ' 
        TSSPIPins.Name = "TSSPIPins"
        TSSPIPins.Size = New Size(226, 6)
        ' 
        ' CMIPIMore
        ' 
        CMIPIMore.Image = My.Resources.Resources.imageSMProcessor
        CMIPIMore.Name = "CMIPIMore"
        CMIPIMore.Size = New Size(229, 22)
        CMIPIMore.Text = "More..."
        ' 
        ' CMIPIAttach
        ' 
        CMIPIAttach.Image = My.Resources.Resources.ImageAttach16
        CMIPIAttach.Name = "CMIPIAttach"
        CMIPIAttach.Size = New Size(229, 22)
        CMIPIAttach.Text = "Attach to Foreground App"
        ' 
        ' CMIPIPinToggle
        ' 
        CMIPIPinToggle.Name = "CMIPIPinToggle"
        CMIPIPinToggle.Size = New Size(229, 22)
        CMIPIPinToggle.Text = "Pin/Unpin"
        ' 
        ' toolStripSeparator3
        ' 
        toolStripSeparator3.Name = "toolStripSeparator3"
        toolStripSeparator3.Size = New Size(177, 6)
        ' 
        ' cmiAutoMinimal
        ' 
        cmiAutoMinimal.Image = My.Resources.Resources.imageSMAutoMinimal
        cmiAutoMinimal.Name = "cmiAutoMinimal"
        cmiAutoMinimal.Size = New Size(180, 22)
        cmiAutoMinimal.Text = "Auto Minimal?"
        ' 
        ' lblNetworkUpload
        ' 
        lblNetworkUpload.ForeColor = Color.Crimson
        lblNetworkUpload.Location = New Point(24, 157)
        lblNetworkUpload.Name = "lblNetworkUpload"
        lblNetworkUpload.Size = New Size(168, 17)
        lblNetworkUpload.TabIndex = 25
        lblNetworkUpload.Text = "VALUE"
        lblNetworkUpload.UseMnemonic = False
        ' 
        ' picboxProcessor
        ' 
        picboxProcessor.BackgroundImageLayout = ImageLayout.None
        picboxProcessor.Image = My.Resources.Resources.imageSMProcessor
        picboxProcessor.Location = New Point(7, 20)
        picboxProcessor.Margin = New Padding(0)
        picboxProcessor.Name = "picboxProcessor"
        picboxProcessor.Size = New Size(19, 21)
        picboxProcessor.SizeMode = PictureBoxSizeMode.CenterImage
        picboxProcessor.TabIndex = 27
        picboxProcessor.TabStop = False
        ' 
        ' picboxMemory
        ' 
        picboxMemory.BackgroundImageLayout = ImageLayout.None
        picboxMemory.Image = My.Resources.Resources.imageSMMemory
        picboxMemory.Location = New Point(8, 73)
        picboxMemory.Margin = New Padding(0)
        picboxMemory.Name = "picboxMemory"
        picboxMemory.Size = New Size(19, 21)
        picboxMemory.SizeMode = PictureBoxSizeMode.CenterImage
        picboxMemory.TabIndex = 28
        picboxMemory.TabStop = False
        ' 
        ' picboxDisk
        ' 
        picboxDisk.BackgroundImageLayout = ImageLayout.None
        picboxDisk.Image = My.Resources.Resources.imageSMDisk
        picboxDisk.Location = New Point(8, 103)
        picboxDisk.Margin = New Padding(0)
        picboxDisk.Name = "picboxDisk"
        picboxDisk.Size = New Size(19, 21)
        picboxDisk.SizeMode = PictureBoxSizeMode.CenterImage
        picboxDisk.TabIndex = 29
        picboxDisk.TabStop = False
        ' 
        ' picboxNetwork
        ' 
        picboxNetwork.BackgroundImageLayout = ImageLayout.None
        picboxNetwork.Image = My.Resources.Resources.imageSMNetwork
        picboxNetwork.Location = New Point(8, 139)
        picboxNetwork.Margin = New Padding(0)
        picboxNetwork.Name = "picboxNetwork"
        picboxNetwork.Size = New Size(19, 21)
        picboxNetwork.SizeMode = PictureBoxSizeMode.CenterImage
        picboxNetwork.TabIndex = 30
        picboxNetwork.TabStop = False
        ' 
        ' lblProcesses
        ' 
        lblProcesses.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblProcesses.ForeColor = Color.Crimson
        lblProcesses.Location = New Point(79, 7)
        lblProcesses.Name = "lblProcesses"
        lblProcesses.Size = New Size(30, 17)
        lblProcesses.TabIndex = 38
        lblProcesses.Text = "VAL"
        lblProcesses.TextAlign = ContentAlignment.BottomRight
        lblProcesses.UseMnemonic = False
        ' 
        ' lblMemoryPhysicalPercent
        ' 
        lblMemoryPhysicalPercent.ForeColor = Color.Crimson
        lblMemoryPhysicalPercent.Location = New Point(24, 62)
        lblMemoryPhysicalPercent.Name = "lblMemoryPhysicalPercent"
        lblMemoryPhysicalPercent.Size = New Size(40, 17)
        lblMemoryPhysicalPercent.TabIndex = 41
        lblMemoryPhysicalPercent.Text = "VAL"
        lblMemoryPhysicalPercent.TextAlign = ContentAlignment.BottomLeft
        lblMemoryPhysicalPercent.UseMnemonic = False
        ' 
        ' lblProcessProcessor
        ' 
        lblProcessProcessor.ForeColor = Color.Crimson
        lblProcessProcessor.Location = New Point(110, 7)
        lblProcessProcessor.Name = "lblProcessProcessor"
        lblProcessProcessor.Size = New Size(57, 17)
        lblProcessProcessor.TabIndex = 43
        lblProcessProcessor.Text = "VALUE"
        lblProcessProcessor.TextAlign = ContentAlignment.BottomLeft
        lblProcessProcessor.UseMnemonic = False
        ' 
        ' lblProcessThreads
        ' 
        lblProcessThreads.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblProcessThreads.ForeColor = Color.Crimson
        lblProcessThreads.Location = New Point(165, 7)
        lblProcessThreads.Name = "lblProcessThreads"
        lblProcessThreads.Size = New Size(30, 17)
        lblProcessThreads.TabIndex = 46
        lblProcessThreads.Text = "VAL"
        lblProcessThreads.TextAlign = ContentAlignment.BottomRight
        lblProcessThreads.UseMnemonic = False
        ' 
        ' lblProcessMemoryPhysical
        ' 
        lblProcessMemoryPhysical.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblProcessMemoryPhysical.ForeColor = Color.Crimson
        lblProcessMemoryPhysical.Location = New Point(129, 62)
        lblProcessMemoryPhysical.Name = "lblProcessMemoryPhysical"
        lblProcessMemoryPhysical.Size = New Size(67, 17)
        lblProcessMemoryPhysical.TabIndex = 47
        lblProcessMemoryPhysical.Text = "VALUE"
        lblProcessMemoryPhysical.TextAlign = ContentAlignment.BottomRight
        lblProcessMemoryPhysical.UseMnemonic = False
        ' 
        ' lblProcessMemoryPhysicalPercent
        ' 
        lblProcessMemoryPhysicalPercent.ForeColor = Color.Crimson
        lblProcessMemoryPhysicalPercent.Location = New Point(110, 62)
        lblProcessMemoryPhysicalPercent.Name = "lblProcessMemoryPhysicalPercent"
        lblProcessMemoryPhysicalPercent.Size = New Size(40, 17)
        lblProcessMemoryPhysicalPercent.TabIndex = 52
        lblProcessMemoryPhysicalPercent.Text = "VAL"
        lblProcessMemoryPhysicalPercent.TextAlign = ContentAlignment.BottomLeft
        lblProcessMemoryPhysicalPercent.UseMnemonic = False
        ' 
        ' lblProcessInstance
        ' 
        lblProcessInstance.ForeColor = Color.Crimson
        lblProcessInstance.Location = New Point(128, 37)
        lblProcessInstance.Name = "lblProcessInstance"
        lblProcessInstance.Size = New Size(70, 17)
        lblProcessInstance.TabIndex = 54
        lblProcessInstance.Text = "VALUE"
        lblProcessInstance.TextAlign = ContentAlignment.MiddleLeft
        lblProcessInstance.UseMnemonic = False
        ' 
        ' picboxProcessInstance
        ' 
        picboxProcessInstance.BackgroundImageLayout = ImageLayout.None
        picboxProcessInstance.Image = My.Resources.Resources.imageSMProcessor
        picboxProcessInstance.Location = New Point(111, 36)
        picboxProcessInstance.Margin = New Padding(0)
        picboxProcessInstance.Name = "picboxProcessInstance"
        picboxProcessInstance.Size = New Size(19, 21)
        picboxProcessInstance.SizeMode = PictureBoxSizeMode.CenterImage
        picboxProcessInstance.TabIndex = 56
        picboxProcessInstance.TabStop = False
        ' 
        ' lblDisk1
        ' 
        lblDisk1.ForeColor = Color.Crimson
        lblDisk1.Location = New Point(110, 92)
        lblDisk1.Name = "lblDisk1"
        lblDisk1.Size = New Size(80, 17)
        lblDisk1.TabIndex = 57
        lblDisk1.Text = "VALUE"
        lblDisk1.TextAlign = ContentAlignment.BottomLeft
        lblDisk1.UseMnemonic = False
        ' 
        ' pbProcessMemoryPhysical
        ' 
        pbProcessMemoryPhysical.ForeColor = Color.Teal
        pbProcessMemoryPhysical.Location = New Point(112, 76)
        pbProcessMemoryPhysical.Margin = New Padding(0)
        pbProcessMemoryPhysical.Name = "pbProcessMemoryPhysical"
        pbProcessMemoryPhysical.Size = New Size(80, 13)
        pbProcessMemoryPhysical.TabIndex = 51
        pbProcessMemoryPhysical.Value = 100
        ' 
        ' pbMemoryPhysical
        ' 
        pbMemoryPhysical.ForeColor = Color.Teal
        pbMemoryPhysical.Location = New Point(26, 76)
        pbMemoryPhysical.Margin = New Padding(0)
        pbMemoryPhysical.Name = "pbMemoryPhysical"
        pbMemoryPhysical.Size = New Size(80, 13)
        pbMemoryPhysical.TabIndex = 36
        pbMemoryPhysical.Value = 100
        ' 
        ' pbProcessProcessor
        ' 
        pbProcessProcessor.ForeColor = Color.Teal
        pbProcessProcessor.Location = New Point(112, 21)
        pbProcessProcessor.Margin = New Padding(0)
        pbProcessProcessor.Name = "pbProcessProcessor"
        pbProcessProcessor.Size = New Size(80, 13)
        pbProcessProcessor.TabIndex = 45
        pbProcessProcessor.Value = 100
        ' 
        ' pbProcessor
        ' 
        pbProcessor.ForeColor = Color.Teal
        pbProcessor.Location = New Point(26, 21)
        pbProcessor.Margin = New Padding(0)
        pbProcessor.Name = "pbProcessor"
        pbProcessor.Size = New Size(80, 13)
        pbProcessor.TabIndex = 37
        pbProcessor.Value = 100
        ' 
        ' pbProcessorSystem
        ' 
        pbProcessorSystem.ForeColor = Color.Crimson
        pbProcessorSystem.Location = New Point(26, 45)
        pbProcessorSystem.Margin = New Padding(0)
        pbProcessorSystem.Name = "pbProcessorSystem"
        pbProcessorSystem.Size = New Size(80, 13)
        pbProcessorSystem.TabIndex = 40
        pbProcessorSystem.Value = 100
        ' 
        ' pbProcessorUser
        ' 
        pbProcessorUser.ForeColor = Color.MediumBlue
        pbProcessorUser.Location = New Point(26, 33)
        pbProcessorUser.Margin = New Padding(0)
        pbProcessorUser.Name = "pbProcessorUser"
        pbProcessorUser.Size = New Size(80, 13)
        pbProcessorUser.TabIndex = 39
        pbProcessorUser.Value = 100
        ' 
        ' pbDisk0
        ' 
        pbDisk0.ForeColor = Color.Teal
        pbDisk0.Location = New Point(26, 106)
        pbDisk0.Margin = New Padding(0)
        pbDisk0.Name = "pbDisk0"
        pbDisk0.Size = New Size(80, 13)
        pbDisk0.TabIndex = 34
        pbDisk0.Value = 100
        ' 
        ' pbNetworkDownload
        ' 
        pbNetworkDownload.ForeColor = Color.Teal
        pbNetworkDownload.Location = New Point(26, 137)
        pbNetworkDownload.Margin = New Padding(0)
        pbNetworkDownload.Name = "pbNetworkDownload"
        pbNetworkDownload.Size = New Size(166, 13)
        pbNetworkDownload.TabIndex = 33
        pbNetworkDownload.Value = 100
        ' 
        ' pbNetworkUpload
        ' 
        pbNetworkUpload.ForeColor = Color.Teal
        pbNetworkUpload.Location = New Point(26, 149)
        pbNetworkUpload.Margin = New Padding(0)
        pbNetworkUpload.Name = "pbNetworkUpload"
        pbNetworkUpload.Size = New Size(166, 13)
        pbNetworkUpload.TabIndex = 32
        pbNetworkUpload.Value = 100
        ' 
        ' pbDisk1
        ' 
        pbDisk1.ForeColor = Color.Teal
        pbDisk1.Location = New Point(112, 106)
        pbDisk1.Margin = New Padding(0)
        pbDisk1.Name = "pbDisk1"
        pbDisk1.Size = New Size(80, 13)
        pbDisk1.TabIndex = 58
        pbDisk1.Value = 100
        ' 
        ' SyM
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoValidate = AutoValidate.Disable
        BackColor = Color.WhiteSmoke
        CausesValidation = False
        ClientSize = New Size(204, 181)
        ContextMenuStrip = cmSM
        ControlBox = False
        Controls.Add(pbProcessMemoryPhysical)
        Controls.Add(lblProcessMemoryPhysicalPercent)
        Controls.Add(pbMemoryPhysical)
        Controls.Add(lblMemoryPhysicalPercent)
        Controls.Add(pbProcessProcessor)
        Controls.Add(lblProcessThreads)
        Controls.Add(lblProcessProcessor)
        Controls.Add(pbProcessor)
        Controls.Add(pbProcessorSystem)
        Controls.Add(lblProcesses)
        Controls.Add(pbProcessorUser)
        Controls.Add(lblProcessor)
        Controls.Add(pbDisk0)
        Controls.Add(pbNetworkDownload)
        Controls.Add(pbNetworkUpload)
        Controls.Add(lblNetworkDownload)
        Controls.Add(lblDisk0)
        Controls.Add(lblNetworkUpload)
        Controls.Add(picboxProcessInstance)
        Controls.Add(picboxProcessor)
        Controls.Add(picboxNetwork)
        Controls.Add(picboxDisk)
        Controls.Add(lblProcessInstance)
        Controls.Add(lblMemoryPhysical)
        Controls.Add(lblProcessMemoryPhysical)
        Controls.Add(picboxMemory)
        Controls.Add(pbDisk1)
        Controls.Add(lblDisk1)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = Color.Crimson
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "SyM"
        Opacity = 0R
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.Manual
        TopMost = True
        cmOpacity.ResumeLayout(False)
        cmSM.ResumeLayout(False)
        CMPI.ResumeLayout(False)
        CType(picboxProcessor, ComponentModel.ISupportInitialize).EndInit()
        CType(picboxMemory, ComponentModel.ISupportInitialize).EndInit()
        CType(picboxDisk, ComponentModel.ISupportInitialize).EndInit()
        CType(picboxNetwork, ComponentModel.ISupportInitialize).EndInit()
        CType(picboxProcessInstance, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmiWindowsMonitor As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents picboxProcessInstance As System.Windows.Forms.PictureBox
    Private WithEvents cmiAutoMinimal As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity10 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity20 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity30 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity40 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity50 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity60 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity70 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity80 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity90 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiOpacity100 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmOpacity As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiProcessInstance As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents pbProcessor As Skye.UI.DataBar
    Private WithEvents pbProcessorUser As Skye.UI.DataBar
    Private WithEvents pbProcessorSystem As Skye.UI.DataBar
    Private WithEvents lblProcessInstance As System.Windows.Forms.Label
    Private WithEvents lblProcessMemoryPhysicalPercent As System.Windows.Forms.Label
    Private WithEvents lblProcessMemoryPhysical As System.Windows.Forms.Label
    Private WithEvents pbProcessMemoryPhysical As Skye.UI.DataBar
    Private WithEvents lblProcessThreads As System.Windows.Forms.Label
    Private WithEvents lblProcessProcessor As System.Windows.Forms.Label
    Private WithEvents pbProcessProcessor As Skye.UI.DataBar
    Private WithEvents pbDisk0 As Skye.UI.DataBar
    Private WithEvents pbMemoryPhysical As Skye.UI.DataBar
    Private WithEvents pbNetworkUpload As Skye.UI.DataBar
    Private WithEvents pbNetworkDownload As Skye.UI.DataBar
    Private WithEvents picboxNetwork As System.Windows.Forms.PictureBox
    Private WithEvents lblMemoryPhysicalPercent As System.Windows.Forms.Label
    Private WithEvents lblProcesses As System.Windows.Forms.Label
    Private WithEvents picboxDisk As System.Windows.Forms.PictureBox
    Private WithEvents picboxMemory As System.Windows.Forms.PictureBox
    Private WithEvents picboxProcessor As System.Windows.Forms.PictureBox
    Private WithEvents lblNetworkDownload As System.Windows.Forms.Label
    Private WithEvents lblNetworkUpload As System.Windows.Forms.Label
    Private WithEvents cmiQuickHide As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lblMemoryPhysical As System.Windows.Forms.Label
    Private WithEvents cmiOpacity As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiClose As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmSM As System.Windows.Forms.ContextMenuStrip
    Private WithEvents lblDisk0 As System.Windows.Forms.Label
    Private WithEvents lblProcessor As System.Windows.Forms.Label
    Private WithEvents pbDisk1 As Skye.UI.DataBar
    Private WithEvents lblDisk1 As Label
    Friend WithEvents CMPI As ContextMenuStrip
    Friend WithEvents TSSPIPins As ToolStripSeparator
    Friend WithEvents CMIPIMore As ToolStripMenuItem
    Friend WithEvents CMIPIAttach As ToolStripMenuItem
    Friend WithEvents CMIPIPinToggle As ToolStripMenuItem
End Class