Partial Friend Class Settings
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        chbxSMAutoMinimal = New CheckBox()
        panelSMColors = New Panel()
        btnSMColorForegroundOnBackground = New Button()
        lblSMColorForegroundOnBackground = New Label()
        btnSMColorForeground = New Button()
        btnSMColorBarSystemForeground = New Button()
        btnSMColorBarForeground = New Button()
        btnSMColorBarBackground = New Button()
        btnSMColorBarUserForeground = New Button()
        btnSMColorBackground = New Button()
        btnSMColorsDefaults = New Button()
        btnSMColorsUndo = New Button()
        lblSMColorBarBackground = New Label()
        lblSMColorBarUserForeground = New Label()
        lblSMColorForeground = New Label()
        lblSMColorBarSystemForeground = New Label()
        lblSMColorBarForeground = New Label()
        lblSMColorBackground = New Label()
        textboxSMQuickHideInterval = New TextBox()
        lblSMQuickHideInterval = New Label()
        comboboxSMOpacity = New ComboBox()
        lblSMOpacity = New Label()
        comboboxSMNetworkInstance = New ComboBox()
        textboxSMNetworkDownloadMaximum = New TextBox()
        textboxSMNetworkUploadMaximum = New TextBox()
        textboxSMUpdateInterval = New TextBox()
        lblSMNetworkInstance = New Label()
        lblSMNetworkDownloadMaximum = New Label()
        lblSMNetworkUploadMaximum = New Label()
        lblSMUpdateInterval = New Label()
        txbxHKSM = New TextBox()
        btnHKSet = New Button()
        btnHKUndo = New Button()
        btnHKEnabled = New Button()
        lblHKSM = New Label()
        btnHKSMDisable = New Button()
        btnClose = New Button()
        chbxSMAutoClose = New CheckBox()
        tableLayoutPanel2 = New TableLayoutPanel()
        panel1 = New Panel()
        TipMain = New Skye.UI.ToolTipEX(components)
        panelSMColors.SuspendLayout()
        panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' chbxSMAutoMinimal
        ' 
        TipMain.SetImage(chbxSMAutoMinimal, Nothing)
        chbxSMAutoMinimal.Location = New Point(216, 12)
        chbxSMAutoMinimal.Name = "chbxSMAutoMinimal"
        chbxSMAutoMinimal.Size = New Size(104, 21)
        chbxSMAutoMinimal.TabIndex = 4
        TipMain.SetText(chbxSMAutoMinimal, "Auto Hide The Window Background")
        chbxSMAutoMinimal.Text = "Auto Minimal"
        chbxSMAutoMinimal.UseVisualStyleBackColor = True
        ' 
        ' panelSMColors
        ' 
        panelSMColors.BorderStyle = BorderStyle.FixedSingle
        panelSMColors.Controls.Add(btnSMColorForegroundOnBackground)
        panelSMColors.Controls.Add(lblSMColorForegroundOnBackground)
        panelSMColors.Controls.Add(btnSMColorForeground)
        panelSMColors.Controls.Add(btnSMColorBarSystemForeground)
        panelSMColors.Controls.Add(btnSMColorBarForeground)
        panelSMColors.Controls.Add(btnSMColorBarBackground)
        panelSMColors.Controls.Add(btnSMColorBarUserForeground)
        panelSMColors.Controls.Add(btnSMColorBackground)
        panelSMColors.Controls.Add(btnSMColorsDefaults)
        panelSMColors.Controls.Add(btnSMColorsUndo)
        panelSMColors.Controls.Add(lblSMColorBarBackground)
        panelSMColors.Controls.Add(lblSMColorBarUserForeground)
        panelSMColors.Controls.Add(lblSMColorForeground)
        panelSMColors.Controls.Add(lblSMColorBarSystemForeground)
        panelSMColors.Controls.Add(lblSMColorBarForeground)
        panelSMColors.Controls.Add(lblSMColorBackground)
        TipMain.SetImage(panelSMColors, Nothing)
        panelSMColors.Location = New Point(130, 223)
        panelSMColors.Name = "panelSMColors"
        panelSMColors.Size = New Size(379, 143)
        panelSMColors.TabIndex = 50
        TipMain.SetText(panelSMColors, Nothing)
        ' 
        ' btnSMColorForegroundOnBackground
        ' 
        btnSMColorForegroundOnBackground.FlatAppearance.BorderSize = 0
        btnSMColorForegroundOnBackground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorForegroundOnBackground, Nothing)
        btnSMColorForegroundOnBackground.Location = New Point(13, 67)
        btnSMColorForegroundOnBackground.Name = "btnSMColorForegroundOnBackground"
        btnSMColorForegroundOnBackground.Size = New Size(110, 20)
        btnSMColorForegroundOnBackground.TabIndex = 0
        btnSMColorForegroundOnBackground.TabStop = False
        TipMain.SetText(btnSMColorForegroundOnBackground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorForegroundOnBackground.UseVisualStyleBackColor = False
        ' 
        ' lblSMColorForegroundOnBackground
        ' 
        TipMain.SetImage(lblSMColorForegroundOnBackground, Nothing)
        lblSMColorForegroundOnBackground.Location = New Point(9, 46)
        lblSMColorForegroundOnBackground.Name = "lblSMColorForegroundOnBackground"
        lblSMColorForegroundOnBackground.Size = New Size(118, 21)
        lblSMColorForegroundOnBackground.TabIndex = 0
        lblSMColorForegroundOnBackground.Text = "Foreground On Bg"
        TipMain.SetText(lblSMColorForegroundOnBackground, Nothing)
        lblSMColorForegroundOnBackground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' btnSMColorForeground
        ' 
        btnSMColorForeground.FlatAppearance.BorderSize = 0
        btnSMColorForeground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorForeground, Nothing)
        btnSMColorForeground.Location = New Point(13, 107)
        btnSMColorForeground.Name = "btnSMColorForeground"
        btnSMColorForeground.Size = New Size(110, 20)
        btnSMColorForeground.TabIndex = 0
        btnSMColorForeground.TabStop = False
        TipMain.SetText(btnSMColorForeground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorForeground.UseVisualStyleBackColor = False
        ' 
        ' btnSMColorBarSystemForeground
        ' 
        btnSMColorBarSystemForeground.FlatAppearance.BorderSize = 0
        btnSMColorBarSystemForeground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorBarSystemForeground, Nothing)
        btnSMColorBarSystemForeground.Location = New Point(253, 67)
        btnSMColorBarSystemForeground.Name = "btnSMColorBarSystemForeground"
        btnSMColorBarSystemForeground.Size = New Size(110, 20)
        btnSMColorBarSystemForeground.TabIndex = 0
        btnSMColorBarSystemForeground.TabStop = False
        TipMain.SetText(btnSMColorBarSystemForeground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorBarSystemForeground.UseVisualStyleBackColor = False
        ' 
        ' btnSMColorBarForeground
        ' 
        btnSMColorBarForeground.FlatAppearance.BorderSize = 0
        btnSMColorBarForeground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorBarForeground, Nothing)
        btnSMColorBarForeground.Location = New Point(133, 67)
        btnSMColorBarForeground.Name = "btnSMColorBarForeground"
        btnSMColorBarForeground.Size = New Size(110, 20)
        btnSMColorBarForeground.TabIndex = 0
        btnSMColorBarForeground.TabStop = False
        TipMain.SetText(btnSMColorBarForeground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorBarForeground.UseVisualStyleBackColor = False
        ' 
        ' btnSMColorBarBackground
        ' 
        btnSMColorBarBackground.FlatAppearance.BorderSize = 0
        btnSMColorBarBackground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorBarBackground, Nothing)
        btnSMColorBarBackground.Location = New Point(133, 27)
        btnSMColorBarBackground.Name = "btnSMColorBarBackground"
        btnSMColorBarBackground.Size = New Size(110, 20)
        btnSMColorBarBackground.TabIndex = 0
        btnSMColorBarBackground.TabStop = False
        TipMain.SetText(btnSMColorBarBackground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorBarBackground.UseVisualStyleBackColor = False
        ' 
        ' btnSMColorBarUserForeground
        ' 
        btnSMColorBarUserForeground.FlatAppearance.BorderSize = 0
        btnSMColorBarUserForeground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorBarUserForeground, Nothing)
        btnSMColorBarUserForeground.Location = New Point(253, 27)
        btnSMColorBarUserForeground.Name = "btnSMColorBarUserForeground"
        btnSMColorBarUserForeground.Size = New Size(110, 20)
        btnSMColorBarUserForeground.TabIndex = 0
        btnSMColorBarUserForeground.TabStop = False
        TipMain.SetText(btnSMColorBarUserForeground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorBarUserForeground.UseVisualStyleBackColor = False
        ' 
        ' btnSMColorBackground
        ' 
        btnSMColorBackground.FlatAppearance.BorderSize = 0
        btnSMColorBackground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorBackground, Nothing)
        btnSMColorBackground.Location = New Point(13, 27)
        btnSMColorBackground.Name = "btnSMColorBackground"
        btnSMColorBackground.Size = New Size(110, 20)
        btnSMColorBackground.TabIndex = 0
        btnSMColorBackground.TabStop = False
        TipMain.SetText(btnSMColorBackground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorBackground.UseVisualStyleBackColor = False
        ' 
        ' btnSMColorsDefaults
        ' 
        btnSMColorsDefaults.ForeColor = Color.Navy
        btnSMColorsDefaults.Image = My.Resources.Resources.imageRestore
        TipMain.SetImage(btnSMColorsDefaults, Nothing)
        btnSMColorsDefaults.ImageAlign = ContentAlignment.MiddleLeft
        btnSMColorsDefaults.Location = New Point(280, 105)
        btnSMColorsDefaults.Name = "btnSMColorsDefaults"
        btnSMColorsDefaults.Size = New Size(87, 26)
        btnSMColorsDefaults.TabIndex = 6
        TipMain.SetText(btnSMColorsDefaults, Nothing)
        btnSMColorsDefaults.Text = "Defaults"
        btnSMColorsDefaults.TextAlign = ContentAlignment.MiddleRight
        btnSMColorsDefaults.UseVisualStyleBackColor = True
        ' 
        ' btnSMColorsUndo
        ' 
        btnSMColorsUndo.Enabled = False
        btnSMColorsUndo.ForeColor = Color.Navy
        btnSMColorsUndo.Image = My.Resources.Resources.imageRemove
        TipMain.SetImage(btnSMColorsUndo, Nothing)
        btnSMColorsUndo.ImageAlign = ContentAlignment.MiddleLeft
        btnSMColorsUndo.Location = New Point(209, 105)
        btnSMColorsUndo.Name = "btnSMColorsUndo"
        btnSMColorsUndo.Size = New Size(65, 26)
        btnSMColorsUndo.TabIndex = 5
        TipMain.SetText(btnSMColorsUndo, "LeftClick = Undo" & vbCrLf & "RightClick = Reset Undo" & vbCrLf)
        btnSMColorsUndo.Text = "Undo"
        btnSMColorsUndo.TextAlign = ContentAlignment.MiddleRight
        btnSMColorsUndo.UseVisualStyleBackColor = True
        ' 
        ' lblSMColorBarBackground
        ' 
        TipMain.SetImage(lblSMColorBarBackground, Nothing)
        lblSMColorBarBackground.Location = New Point(133, 6)
        lblSMColorBarBackground.Name = "lblSMColorBarBackground"
        lblSMColorBarBackground.Size = New Size(110, 21)
        lblSMColorBarBackground.TabIndex = 0
        lblSMColorBarBackground.Text = "Bar Background"
        TipMain.SetText(lblSMColorBarBackground, Nothing)
        lblSMColorBarBackground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBarUserForeground
        ' 
        TipMain.SetImage(lblSMColorBarUserForeground, Nothing)
        lblSMColorBarUserForeground.Location = New Point(243, 6)
        lblSMColorBarUserForeground.Name = "lblSMColorBarUserForeground"
        lblSMColorBarUserForeground.Size = New Size(131, 21)
        lblSMColorBarUserForeground.TabIndex = 0
        lblSMColorBarUserForeground.Text = "User Bar Foreground"
        TipMain.SetText(lblSMColorBarUserForeground, Nothing)
        lblSMColorBarUserForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorForeground
        ' 
        TipMain.SetImage(lblSMColorForeground, Nothing)
        lblSMColorForeground.Location = New Point(13, 86)
        lblSMColorForeground.Name = "lblSMColorForeground"
        lblSMColorForeground.Size = New Size(110, 21)
        lblSMColorForeground.TabIndex = 0
        lblSMColorForeground.Text = "Foreground"
        TipMain.SetText(lblSMColorForeground, Nothing)
        lblSMColorForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBarSystemForeground
        ' 
        TipMain.SetImage(lblSMColorBarSystemForeground, Nothing)
        lblSMColorBarSystemForeground.Location = New Point(246, 46)
        lblSMColorBarSystemForeground.Name = "lblSMColorBarSystemForeground"
        lblSMColorBarSystemForeground.Size = New Size(125, 21)
        lblSMColorBarSystemForeground.TabIndex = 0
        lblSMColorBarSystemForeground.Text = "Sys Bar Foreground"
        TipMain.SetText(lblSMColorBarSystemForeground, Nothing)
        lblSMColorBarSystemForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBarForeground
        ' 
        TipMain.SetImage(lblSMColorBarForeground, Nothing)
        lblSMColorBarForeground.Location = New Point(133, 46)
        lblSMColorBarForeground.Name = "lblSMColorBarForeground"
        lblSMColorBarForeground.Size = New Size(110, 21)
        lblSMColorBarForeground.TabIndex = 0
        lblSMColorBarForeground.Text = "Bar Foreground"
        TipMain.SetText(lblSMColorBarForeground, Nothing)
        lblSMColorBarForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBackground
        ' 
        TipMain.SetImage(lblSMColorBackground, Nothing)
        lblSMColorBackground.Location = New Point(13, 6)
        lblSMColorBackground.Name = "lblSMColorBackground"
        lblSMColorBackground.Size = New Size(110, 21)
        lblSMColorBackground.TabIndex = 0
        lblSMColorBackground.Text = "Background"
        TipMain.SetText(lblSMColorBackground, Nothing)
        lblSMColorBackground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' textboxSMQuickHideInterval
        ' 
        TipMain.SetImage(textboxSMQuickHideInterval, Nothing)
        textboxSMQuickHideInterval.Location = New Point(289, 85)
        textboxSMQuickHideInterval.MaxLength = 2
        textboxSMQuickHideInterval.Name = "textboxSMQuickHideInterval"
        textboxSMQuickHideInterval.Size = New Size(90, 25)
        textboxSMQuickHideInterval.TabIndex = 12
        TipMain.SetText(textboxSMQuickHideInterval, "How long the System Monitor should remain hidden after initiating Quick Hide, in seconds")
        textboxSMQuickHideInterval.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblSMQuickHideInterval
        ' 
        TipMain.SetImage(lblSMQuickHideInterval, Nothing)
        lblSMQuickHideInterval.Location = New Point(289, 44)
        lblSMQuickHideInterval.Name = "lblSMQuickHideInterval"
        lblSMQuickHideInterval.Size = New Size(90, 42)
        lblSMQuickHideInterval.TabIndex = 155
        lblSMQuickHideInterval.Text = "QuickHide Interval"
        TipMain.SetText(lblSMQuickHideInterval, Nothing)
        lblSMQuickHideInterval.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' comboboxSMOpacity
        ' 
        comboboxSMOpacity.DropDownStyle = ComboBoxStyle.DropDownList
        TipMain.SetImage(comboboxSMOpacity, Nothing)
        comboboxSMOpacity.Items.AddRange(New Object() {"100", "90", "80", "70", "60", "50", "40", "30", "20", "10"})
        comboboxSMOpacity.Location = New Point(385, 85)
        comboboxSMOpacity.Name = "comboboxSMOpacity"
        comboboxSMOpacity.Size = New Size(60, 25)
        comboboxSMOpacity.TabIndex = 14
        TipMain.SetText(comboboxSMOpacity, "Opacity (Window Visibility Strength)")
        ' 
        ' lblSMOpacity
        ' 
        TipMain.SetImage(lblSMOpacity, Nothing)
        lblSMOpacity.Location = New Point(385, 65)
        lblSMOpacity.Name = "lblSMOpacity"
        lblSMOpacity.Size = New Size(60, 21)
        lblSMOpacity.TabIndex = 153
        lblSMOpacity.Text = "Opacity"
        TipMain.SetText(lblSMOpacity, Nothing)
        lblSMOpacity.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' comboboxSMNetworkInstance
        ' 
        comboboxSMNetworkInstance.DropDownStyle = ComboBoxStyle.DropDownList
        comboboxSMNetworkInstance.DropDownWidth = 350
        TipMain.SetImage(comboboxSMNetworkInstance, Nothing)
        comboboxSMNetworkInstance.Location = New Point(264, 167)
        comboboxSMNetworkInstance.Name = "comboboxSMNetworkInstance"
        comboboxSMNetworkInstance.Size = New Size(361, 25)
        comboboxSMNetworkInstance.TabIndex = 20
        TipMain.SetText(comboboxSMNetworkInstance, "Select a Network Interface")
        ' 
        ' textboxSMNetworkDownloadMaximum
        ' 
        TipMain.SetImage(textboxSMNetworkDownloadMaximum, Nothing)
        textboxSMNetworkDownloadMaximum.Location = New Point(13, 167)
        textboxSMNetworkDownloadMaximum.MaxLength = 5
        textboxSMNetworkDownloadMaximum.Name = "textboxSMNetworkDownloadMaximum"
        textboxSMNetworkDownloadMaximum.Size = New Size(119, 25)
        textboxSMNetworkDownloadMaximum.TabIndex = 16
        TipMain.SetText(textboxSMNetworkDownloadMaximum, "Network Download Maximum in KBs")
        textboxSMNetworkDownloadMaximum.TextAlign = HorizontalAlignment.Center
        ' 
        ' textboxSMNetworkUploadMaximum
        ' 
        TipMain.SetImage(textboxSMNetworkUploadMaximum, Nothing)
        textboxSMNetworkUploadMaximum.Location = New Point(138, 167)
        textboxSMNetworkUploadMaximum.MaxLength = 5
        textboxSMNetworkUploadMaximum.Name = "textboxSMNetworkUploadMaximum"
        textboxSMNetworkUploadMaximum.Size = New Size(119, 25)
        textboxSMNetworkUploadMaximum.TabIndex = 18
        TipMain.SetText(textboxSMNetworkUploadMaximum, "Network Upload Maximum in KBs")
        textboxSMNetworkUploadMaximum.TextAlign = HorizontalAlignment.Center
        ' 
        ' textboxSMUpdateInterval
        ' 
        TipMain.SetImage(textboxSMUpdateInterval, Nothing)
        textboxSMUpdateInterval.Location = New Point(193, 85)
        textboxSMUpdateInterval.MaxLength = 5
        textboxSMUpdateInterval.Name = "textboxSMUpdateInterval"
        textboxSMUpdateInterval.Size = New Size(90, 25)
        textboxSMUpdateInterval.TabIndex = 10
        TipMain.SetText(textboxSMUpdateInterval, "How Often does the System Monitor Refresh, in milliseconds")
        textboxSMUpdateInterval.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblSMNetworkInstance
        ' 
        TipMain.SetImage(lblSMNetworkInstance, Nothing)
        lblSMNetworkInstance.Location = New Point(263, 147)
        lblSMNetworkInstance.Name = "lblSMNetworkInstance"
        lblSMNetworkInstance.Size = New Size(113, 21)
        lblSMNetworkInstance.TabIndex = 108
        lblSMNetworkInstance.Text = "Network Instance"
        TipMain.SetText(lblSMNetworkInstance, Nothing)
        lblSMNetworkInstance.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblSMNetworkDownloadMaximum
        ' 
        TipMain.SetImage(lblSMNetworkDownloadMaximum, Nothing)
        lblSMNetworkDownloadMaximum.Location = New Point(13, 126)
        lblSMNetworkDownloadMaximum.Name = "lblSMNetworkDownloadMaximum"
        lblSMNetworkDownloadMaximum.Size = New Size(120, 42)
        lblSMNetworkDownloadMaximum.TabIndex = 106
        lblSMNetworkDownloadMaximum.Text = "Network Download Activity Maximum"
        TipMain.SetText(lblSMNetworkDownloadMaximum, Nothing)
        lblSMNetworkDownloadMaximum.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMNetworkUploadMaximum
        ' 
        TipMain.SetImage(lblSMNetworkUploadMaximum, Nothing)
        lblSMNetworkUploadMaximum.Location = New Point(138, 126)
        lblSMNetworkUploadMaximum.Name = "lblSMNetworkUploadMaximum"
        lblSMNetworkUploadMaximum.Size = New Size(120, 42)
        lblSMNetworkUploadMaximum.TabIndex = 104
        lblSMNetworkUploadMaximum.Text = "Network Upload Activity Maximum"
        TipMain.SetText(lblSMNetworkUploadMaximum, Nothing)
        lblSMNetworkUploadMaximum.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMUpdateInterval
        ' 
        TipMain.SetImage(lblSMUpdateInterval, Nothing)
        lblSMUpdateInterval.Location = New Point(193, 44)
        lblSMUpdateInterval.Name = "lblSMUpdateInterval"
        lblSMUpdateInterval.Size = New Size(90, 42)
        lblSMUpdateInterval.TabIndex = 102
        lblSMUpdateInterval.Text = "Update Interval"
        TipMain.SetText(lblSMUpdateInterval, Nothing)
        lblSMUpdateInterval.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' txbxHKSM
        ' 
        txbxHKSM.Anchor = AnchorStyles.Top
        TipMain.SetImage(txbxHKSM, Nothing)
        txbxHKSM.Location = New Point(13, 25)
        txbxHKSM.Name = "txbxHKSM"
        txbxHKSM.ShortcutsEnabled = False
        txbxHKSM.Size = New Size(156, 25)
        txbxHKSM.TabIndex = 121
        txbxHKSM.TabStop = False
        TipMain.SetText(txbxHKSM, Nothing)
        txbxHKSM.TextAlign = HorizontalAlignment.Center
        txbxHKSM.WordWrap = False
        ' 
        ' btnHKSet
        ' 
        btnHKSet.Anchor = AnchorStyles.Top
        btnHKSet.Enabled = False
        btnHKSet.ForeColor = Color.Navy
        TipMain.SetImage(btnHKSet, Nothing)
        btnHKSet.ImageAlign = ContentAlignment.MiddleLeft
        btnHKSet.Location = New Point(110, 50)
        btnHKSet.Name = "btnHKSet"
        btnHKSet.Size = New Size(60, 32)
        btnHKSet.TabIndex = 1010
        TipMain.SetText(btnHKSet, Nothing)
        btnHKSet.Text = "Set"
        btnHKSet.TextAlign = ContentAlignment.MiddleRight
        btnHKSet.UseVisualStyleBackColor = True
        ' 
        ' btnHKUndo
        ' 
        btnHKUndo.Enabled = False
        btnHKUndo.ForeColor = Color.Navy
        TipMain.SetImage(btnHKUndo, Nothing)
        btnHKUndo.ImageAlign = ContentAlignment.MiddleLeft
        btnHKUndo.Location = New Point(12, 50)
        btnHKUndo.Name = "btnHKUndo"
        btnHKUndo.Size = New Size(90, 32)
        btnHKUndo.TabIndex = 1000
        TipMain.SetText(btnHKUndo, Nothing)
        btnHKUndo.Text = "Undo"
        btnHKUndo.TextAlign = ContentAlignment.MiddleRight
        btnHKUndo.UseVisualStyleBackColor = True
        ' 
        ' btnHKEnabled
        ' 
        btnHKEnabled.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnHKEnabled.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnHKEnabled.ForeColor = Color.Navy
        TipMain.SetImage(btnHKEnabled, Nothing)
        btnHKEnabled.ImageAlign = ContentAlignment.MiddleLeft
        btnHKEnabled.Location = New Point(12, 97)
        btnHKEnabled.Name = "btnHKEnabled"
        btnHKEnabled.Size = New Size(171, 32)
        btnHKEnabled.TabIndex = 1020
        TipMain.SetText(btnHKEnabled, Nothing)
        btnHKEnabled.TextAlign = ContentAlignment.MiddleRight
        btnHKEnabled.UseVisualStyleBackColor = True
        ' 
        ' lblHKSM
        ' 
        lblHKSM.Anchor = AnchorStyles.Top
        lblHKSM.ForeColor = SystemColors.ControlText
        TipMain.SetImage(lblHKSM, Nothing)
        lblHKSM.Location = New Point(13, 4)
        lblHKSM.Name = "lblHKSM"
        lblHKSM.Size = New Size(157, 21)
        lblHKSM.TabIndex = 120
        lblHKSM.Text = "Toggle System Monitor"
        TipMain.SetText(lblHKSM, Nothing)
        lblHKSM.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' btnHKSMDisable
        ' 
        btnHKSMDisable.Anchor = AnchorStyles.Top
        btnHKSMDisable.FlatStyle = FlatStyle.Flat
        btnHKSMDisable.ForeColor = Color.Transparent
        btnHKSMDisable.Image = My.Resources.Resources.imageRemove
        TipMain.SetImage(btnHKSMDisable, Nothing)
        btnHKSMDisable.Location = New Point(166, 27)
        btnHKSMDisable.Name = "btnHKSMDisable"
        btnHKSMDisable.Size = New Size(20, 20)
        btnHKSMDisable.TabIndex = 122
        btnHKSMDisable.TabStop = False
        TipMain.SetText(btnHKSMDisable, Nothing)
        btnHKSMDisable.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.Image = My.Resources.Resources.ImageOK
        TipMain.SetImage(btnClose, Nothing)
        btnClose.Location = New Point(287, 558)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(64, 64)
        btnClose.TabIndex = 100
        TipMain.SetText(btnClose, "Hide Window")
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' chbxSMAutoClose
        ' 
        TipMain.SetImage(chbxSMAutoClose, Nothing)
        chbxSMAutoClose.Location = New Point(328, 12)
        chbxSMAutoClose.Name = "chbxSMAutoClose"
        chbxSMAutoClose.Size = New Size(94, 21)
        chbxSMAutoClose.TabIndex = 6
        TipMain.SetText(chbxSMAutoClose, "Auto Close On ScreenSaver")
        chbxSMAutoClose.Text = "Auto Close"
        chbxSMAutoClose.UseVisualStyleBackColor = True
        ' 
        ' tableLayoutPanel2
        ' 
        tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        tableLayoutPanel2.ColumnCount = 2
        tableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TipMain.SetImage(tableLayoutPanel2, Nothing)
        tableLayoutPanel2.Location = New Point(0, 0)
        tableLayoutPanel2.Name = "tableLayoutPanel2"
        tableLayoutPanel2.RowCount = 4
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tableLayoutPanel2.Size = New Size(200, 100)
        tableLayoutPanel2.TabIndex = 0
        TipMain.SetText(tableLayoutPanel2, Nothing)
        ' 
        ' panel1
        ' 
        panel1.BorderStyle = BorderStyle.FixedSingle
        panel1.Controls.Add(btnHKEnabled)
        panel1.Controls.Add(txbxHKSM)
        panel1.Controls.Add(lblHKSM)
        panel1.Controls.Add(btnHKUndo)
        panel1.Controls.Add(btnHKSet)
        panel1.Controls.Add(btnHKSMDisable)
        TipMain.SetImage(panel1, Nothing)
        panel1.Location = New Point(221, 399)
        panel1.Name = "panel1"
        panel1.Size = New Size(197, 143)
        panel1.TabIndex = 60
        TipMain.SetText(panel1, Nothing)
        ' 
        ' TipMain
        ' 
        TipMain.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ' 
        ' Settings
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        AutoValidate = AutoValidate.EnablePreventFocusChange
        ClientSize = New Size(638, 634)
        Controls.Add(chbxSMAutoClose)
        Controls.Add(panel1)
        Controls.Add(chbxSMAutoMinimal)
        Controls.Add(panelSMColors)
        Controls.Add(textboxSMQuickHideInterval)
        Controls.Add(lblSMQuickHideInterval)
        Controls.Add(comboboxSMOpacity)
        Controls.Add(lblSMOpacity)
        Controls.Add(comboboxSMNetworkInstance)
        Controls.Add(textboxSMNetworkDownloadMaximum)
        Controls.Add(textboxSMNetworkUploadMaximum)
        Controls.Add(textboxSMUpdateInterval)
        Controls.Add(btnClose)
        Controls.Add(lblSMNetworkInstance)
        Controls.Add(lblSMNetworkDownloadMaximum)
        Controls.Add(lblSMNetworkUploadMaximum)
        Controls.Add(lblSMUpdateInterval)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = My.Resources.Resources.iconApp
        TipMain.SetImage(Me, Nothing)
        MaximizeBox = False
        Name = "Settings"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        TipMain.SetText(Me, Nothing)
        panelSMColors.ResumeLayout(False)
        panel1.ResumeLayout(False)
        panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private WithEvents chbxSMAutoClose As System.Windows.Forms.CheckBox
    Private WithEvents chbxSMAutoMinimal As System.Windows.Forms.CheckBox
    Private WithEvents txbxHKSM As System.Windows.Forms.TextBox
    Private panel1 As System.Windows.Forms.Panel
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnHKUndo As System.Windows.Forms.Button
    Private lblSMColorForegroundOnBackground As System.Windows.Forms.Label
    Private WithEvents btnSMColorForegroundOnBackground As System.Windows.Forms.Button
    Private WithEvents btnSMColorsDefaults As System.Windows.Forms.Button
    Private WithEvents btnSMColorsUndo As System.Windows.Forms.Button
    Private WithEvents btnSMColorBackground As System.Windows.Forms.Button
    Private WithEvents btnSMColorBarUserForeground As System.Windows.Forms.Button
    Private WithEvents btnSMColorBarBackground As System.Windows.Forms.Button
    Private WithEvents btnSMColorBarForeground As System.Windows.Forms.Button
    Private WithEvents btnSMColorBarSystemForeground As System.Windows.Forms.Button
    Private WithEvents btnSMColorForeground As System.Windows.Forms.Button
    Private lblSMColorBarSystemForeground As System.Windows.Forms.Label
    Private lblSMColorBarUserForeground As System.Windows.Forms.Label
    Private lblSMColorBackground As System.Windows.Forms.Label
    Private lblSMColorBarForeground As System.Windows.Forms.Label
    Private lblSMColorForeground As System.Windows.Forms.Label
    Private lblSMColorBarBackground As System.Windows.Forms.Label
    Private panelSMColors As System.Windows.Forms.Panel
    Private lblSMQuickHideInterval As System.Windows.Forms.Label
    Private WithEvents lblSMOpacity As System.Windows.Forms.Label
    Private WithEvents comboboxSMOpacity As System.Windows.Forms.ComboBox
    Private WithEvents textboxSMQuickHideInterval As System.Windows.Forms.TextBox
    Private lblSMUpdateInterval As System.Windows.Forms.Label
    Private lblSMNetworkDownloadMaximum As System.Windows.Forms.Label
    Private lblSMNetworkUploadMaximum As System.Windows.Forms.Label
    Private lblSMNetworkInstance As System.Windows.Forms.Label
    Private WithEvents comboboxSMNetworkInstance As System.Windows.Forms.ComboBox
    Private WithEvents textboxSMNetworkUploadMaximum As System.Windows.Forms.TextBox
    Private WithEvents textboxSMNetworkDownloadMaximum As System.Windows.Forms.TextBox
    Private WithEvents textboxSMUpdateInterval As System.Windows.Forms.TextBox
    Private WithEvents btnHKSMDisable As System.Windows.Forms.Button
    Private lblHKSM As System.Windows.Forms.Label
    Private tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents btnHKEnabled As System.Windows.Forms.Button
    Private WithEvents btnHKSet As System.Windows.Forms.Button
    Friend WithEvents TipMain As Skye.UI.ToolTipEX
End Class