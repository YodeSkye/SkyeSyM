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
        lblSMOpacity = New Label()
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
        LblBehavior = New Label()
        LblNetwork = New Label()
        LblColors = New Label()
        LblHotKey = New Label()
        LblTheme = New Label()
        CoBoxTheme = New Skye.UI.ComboBox()
        ChkBoxThemeAuto = New CheckBox()
        comboboxSMOpacity = New Skye.UI.ComboBox()
        comboboxSMNetworkInstance = New Skye.UI.ComboBox()
        panelSMColors.SuspendLayout()
        panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' chbxSMAutoMinimal
        ' 
        TipMain.SetImage(chbxSMAutoMinimal, Nothing)
        chbxSMAutoMinimal.Location = New Point(286, 35)
        chbxSMAutoMinimal.Margin = New Padding(4)
        chbxSMAutoMinimal.Name = "chbxSMAutoMinimal"
        chbxSMAutoMinimal.Size = New Size(134, 26)
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
        panelSMColors.Location = New Point(18, 283)
        panelSMColors.Margin = New Padding(4)
        panelSMColors.Name = "panelSMColors"
        panelSMColors.Size = New Size(487, 193)
        panelSMColors.TabIndex = 50
        TipMain.SetText(panelSMColors, Nothing)
        ' 
        ' btnSMColorForegroundOnBackground
        ' 
        btnSMColorForegroundOnBackground.FlatAppearance.BorderSize = 0
        btnSMColorForegroundOnBackground.FlatStyle = FlatStyle.Flat
        TipMain.SetImage(btnSMColorForegroundOnBackground, Nothing)
        btnSMColorForegroundOnBackground.Location = New Point(17, 83)
        btnSMColorForegroundOnBackground.Margin = New Padding(4)
        btnSMColorForegroundOnBackground.Name = "btnSMColorForegroundOnBackground"
        btnSMColorForegroundOnBackground.Size = New Size(141, 25)
        btnSMColorForegroundOnBackground.TabIndex = 0
        btnSMColorForegroundOnBackground.TabStop = False
        TipMain.SetText(btnSMColorForegroundOnBackground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorForegroundOnBackground.UseVisualStyleBackColor = False
        ' 
        ' lblSMColorForegroundOnBackground
        ' 
        TipMain.SetImage(lblSMColorForegroundOnBackground, Nothing)
        lblSMColorForegroundOnBackground.Location = New Point(12, 57)
        lblSMColorForegroundOnBackground.Margin = New Padding(4, 0, 4, 0)
        lblSMColorForegroundOnBackground.Name = "lblSMColorForegroundOnBackground"
        lblSMColorForegroundOnBackground.Size = New Size(152, 26)
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
        btnSMColorForeground.Location = New Point(17, 132)
        btnSMColorForeground.Margin = New Padding(4)
        btnSMColorForeground.Name = "btnSMColorForeground"
        btnSMColorForeground.Size = New Size(141, 25)
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
        btnSMColorBarSystemForeground.Location = New Point(325, 83)
        btnSMColorBarSystemForeground.Margin = New Padding(4)
        btnSMColorBarSystemForeground.Name = "btnSMColorBarSystemForeground"
        btnSMColorBarSystemForeground.Size = New Size(141, 25)
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
        btnSMColorBarForeground.Location = New Point(171, 83)
        btnSMColorBarForeground.Margin = New Padding(4)
        btnSMColorBarForeground.Name = "btnSMColorBarForeground"
        btnSMColorBarForeground.Size = New Size(141, 25)
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
        btnSMColorBarBackground.Location = New Point(171, 33)
        btnSMColorBarBackground.Margin = New Padding(4)
        btnSMColorBarBackground.Name = "btnSMColorBarBackground"
        btnSMColorBarBackground.Size = New Size(141, 25)
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
        btnSMColorBarUserForeground.Location = New Point(325, 33)
        btnSMColorBarUserForeground.Margin = New Padding(4)
        btnSMColorBarUserForeground.Name = "btnSMColorBarUserForeground"
        btnSMColorBarUserForeground.Size = New Size(141, 25)
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
        btnSMColorBackground.Location = New Point(17, 33)
        btnSMColorBackground.Margin = New Padding(4)
        btnSMColorBackground.Name = "btnSMColorBackground"
        btnSMColorBackground.Size = New Size(141, 25)
        btnSMColorBackground.TabIndex = 0
        btnSMColorBackground.TabStop = False
        TipMain.SetText(btnSMColorBackground, "LeftClick = Select Color" & vbCrLf & "RightClick = Select Color By Name")
        btnSMColorBackground.UseVisualStyleBackColor = False
        ' 
        ' btnSMColorsDefaults
        ' 
        btnSMColorsDefaults.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSMColorsDefaults.Image = My.Resources.Resources.ImageDefaults32
        TipMain.SetImage(btnSMColorsDefaults, My.Resources.Resources.ImageDefaults32)
        btnSMColorsDefaults.Location = New Point(418, 126)
        btnSMColorsDefaults.Margin = New Padding(4)
        btnSMColorsDefaults.Name = "btnSMColorsDefaults"
        btnSMColorsDefaults.Size = New Size(48, 48)
        btnSMColorsDefaults.TabIndex = 6
        TipMain.SetText(btnSMColorsDefaults, "Restore Defaults")
        btnSMColorsDefaults.TextAlign = ContentAlignment.MiddleRight
        btnSMColorsDefaults.UseVisualStyleBackColor = True
        ' 
        ' btnSMColorsUndo
        ' 
        btnSMColorsUndo.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSMColorsUndo.Enabled = False
        btnSMColorsUndo.Image = My.Resources.Resources.ImageRestore32
        TipMain.SetImage(btnSMColorsUndo, My.Resources.Resources.ImageRestore32)
        btnSMColorsUndo.Location = New Point(362, 126)
        btnSMColorsUndo.Margin = New Padding(4)
        btnSMColorsUndo.Name = "btnSMColorsUndo"
        btnSMColorsUndo.Size = New Size(48, 48)
        btnSMColorsUndo.TabIndex = 5
        TipMain.SetText(btnSMColorsUndo, "LeftClick = Undo" & vbCrLf & "RightClick = Reset Undo")
        btnSMColorsUndo.TextAlign = ContentAlignment.MiddleRight
        btnSMColorsUndo.UseVisualStyleBackColor = True
        ' 
        ' lblSMColorBarBackground
        ' 
        TipMain.SetImage(lblSMColorBarBackground, Nothing)
        lblSMColorBarBackground.Location = New Point(171, 7)
        lblSMColorBarBackground.Margin = New Padding(4, 0, 4, 0)
        lblSMColorBarBackground.Name = "lblSMColorBarBackground"
        lblSMColorBarBackground.Size = New Size(141, 26)
        lblSMColorBarBackground.TabIndex = 0
        lblSMColorBarBackground.Text = "Bar Background"
        TipMain.SetText(lblSMColorBarBackground, Nothing)
        lblSMColorBarBackground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBarUserForeground
        ' 
        TipMain.SetImage(lblSMColorBarUserForeground, Nothing)
        lblSMColorBarUserForeground.Location = New Point(312, 7)
        lblSMColorBarUserForeground.Margin = New Padding(4, 0, 4, 0)
        lblSMColorBarUserForeground.Name = "lblSMColorBarUserForeground"
        lblSMColorBarUserForeground.Size = New Size(168, 26)
        lblSMColorBarUserForeground.TabIndex = 0
        lblSMColorBarUserForeground.Text = "User Bar Foreground"
        TipMain.SetText(lblSMColorBarUserForeground, Nothing)
        lblSMColorBarUserForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorForeground
        ' 
        TipMain.SetImage(lblSMColorForeground, Nothing)
        lblSMColorForeground.Location = New Point(17, 106)
        lblSMColorForeground.Margin = New Padding(4, 0, 4, 0)
        lblSMColorForeground.Name = "lblSMColorForeground"
        lblSMColorForeground.Size = New Size(141, 26)
        lblSMColorForeground.TabIndex = 0
        lblSMColorForeground.Text = "Foreground"
        TipMain.SetText(lblSMColorForeground, Nothing)
        lblSMColorForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBarSystemForeground
        ' 
        TipMain.SetImage(lblSMColorBarSystemForeground, Nothing)
        lblSMColorBarSystemForeground.Location = New Point(316, 57)
        lblSMColorBarSystemForeground.Margin = New Padding(4, 0, 4, 0)
        lblSMColorBarSystemForeground.Name = "lblSMColorBarSystemForeground"
        lblSMColorBarSystemForeground.Size = New Size(161, 26)
        lblSMColorBarSystemForeground.TabIndex = 0
        lblSMColorBarSystemForeground.Text = "Sys Bar Foreground"
        TipMain.SetText(lblSMColorBarSystemForeground, Nothing)
        lblSMColorBarSystemForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBarForeground
        ' 
        TipMain.SetImage(lblSMColorBarForeground, Nothing)
        lblSMColorBarForeground.Location = New Point(171, 57)
        lblSMColorBarForeground.Margin = New Padding(4, 0, 4, 0)
        lblSMColorBarForeground.Name = "lblSMColorBarForeground"
        lblSMColorBarForeground.Size = New Size(141, 26)
        lblSMColorBarForeground.TabIndex = 0
        lblSMColorBarForeground.Text = "Bar Foreground"
        TipMain.SetText(lblSMColorBarForeground, Nothing)
        lblSMColorBarForeground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMColorBackground
        ' 
        TipMain.SetImage(lblSMColorBackground, Nothing)
        lblSMColorBackground.Location = New Point(17, 7)
        lblSMColorBackground.Margin = New Padding(4, 0, 4, 0)
        lblSMColorBackground.Name = "lblSMColorBackground"
        lblSMColorBackground.Size = New Size(141, 26)
        lblSMColorBackground.TabIndex = 0
        lblSMColorBackground.Text = "Background"
        TipMain.SetText(lblSMColorBackground, Nothing)
        lblSMColorBackground.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' textboxSMQuickHideInterval
        ' 
        textboxSMQuickHideInterval.BorderStyle = BorderStyle.FixedSingle
        TipMain.SetImage(textboxSMQuickHideInterval, Nothing)
        textboxSMQuickHideInterval.Location = New Point(372, 102)
        textboxSMQuickHideInterval.Margin = New Padding(4)
        textboxSMQuickHideInterval.MaxLength = 2
        textboxSMQuickHideInterval.Name = "textboxSMQuickHideInterval"
        textboxSMQuickHideInterval.Size = New Size(115, 29)
        textboxSMQuickHideInterval.TabIndex = 12
        TipMain.SetText(textboxSMQuickHideInterval, "How long the System Monitor should remain hidden after initiating Quick Hide, in seconds")
        textboxSMQuickHideInterval.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblSMQuickHideInterval
        ' 
        TipMain.SetImage(lblSMQuickHideInterval, Nothing)
        lblSMQuickHideInterval.Location = New Point(372, 51)
        lblSMQuickHideInterval.Margin = New Padding(4, 0, 4, 0)
        lblSMQuickHideInterval.Name = "lblSMQuickHideInterval"
        lblSMQuickHideInterval.Size = New Size(116, 52)
        lblSMQuickHideInterval.TabIndex = 155
        lblSMQuickHideInterval.Text = "QuickHide Interval"
        TipMain.SetText(lblSMQuickHideInterval, Nothing)
        lblSMQuickHideInterval.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMOpacity
        ' 
        TipMain.SetImage(lblSMOpacity, Nothing)
        lblSMOpacity.Location = New Point(495, 76)
        lblSMOpacity.Margin = New Padding(4, 0, 4, 0)
        lblSMOpacity.Name = "lblSMOpacity"
        lblSMOpacity.Size = New Size(77, 26)
        lblSMOpacity.TabIndex = 153
        lblSMOpacity.Text = "Opacity"
        TipMain.SetText(lblSMOpacity, Nothing)
        lblSMOpacity.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' textboxSMNetworkDownloadMaximum
        ' 
        textboxSMNetworkDownloadMaximum.BorderStyle = BorderStyle.FixedSingle
        TipMain.SetImage(textboxSMNetworkDownloadMaximum, Nothing)
        textboxSMNetworkDownloadMaximum.Location = New Point(18, 215)
        textboxSMNetworkDownloadMaximum.Margin = New Padding(4)
        textboxSMNetworkDownloadMaximum.MaxLength = 5
        textboxSMNetworkDownloadMaximum.Name = "textboxSMNetworkDownloadMaximum"
        textboxSMNetworkDownloadMaximum.Size = New Size(152, 29)
        textboxSMNetworkDownloadMaximum.TabIndex = 16
        TipMain.SetText(textboxSMNetworkDownloadMaximum, "Network Download Maximum in KBs")
        textboxSMNetworkDownloadMaximum.TextAlign = HorizontalAlignment.Center
        ' 
        ' textboxSMNetworkUploadMaximum
        ' 
        textboxSMNetworkUploadMaximum.BorderStyle = BorderStyle.FixedSingle
        TipMain.SetImage(textboxSMNetworkUploadMaximum, Nothing)
        textboxSMNetworkUploadMaximum.Location = New Point(178, 215)
        textboxSMNetworkUploadMaximum.Margin = New Padding(4)
        textboxSMNetworkUploadMaximum.MaxLength = 5
        textboxSMNetworkUploadMaximum.Name = "textboxSMNetworkUploadMaximum"
        textboxSMNetworkUploadMaximum.Size = New Size(152, 29)
        textboxSMNetworkUploadMaximum.TabIndex = 18
        TipMain.SetText(textboxSMNetworkUploadMaximum, "Network Upload Maximum in KBs")
        textboxSMNetworkUploadMaximum.TextAlign = HorizontalAlignment.Center
        ' 
        ' textboxSMUpdateInterval
        ' 
        textboxSMUpdateInterval.BorderStyle = BorderStyle.FixedSingle
        TipMain.SetImage(textboxSMUpdateInterval, Nothing)
        textboxSMUpdateInterval.Location = New Point(248, 102)
        textboxSMUpdateInterval.Margin = New Padding(4)
        textboxSMUpdateInterval.MaxLength = 5
        textboxSMUpdateInterval.Name = "textboxSMUpdateInterval"
        textboxSMUpdateInterval.Size = New Size(115, 29)
        textboxSMUpdateInterval.TabIndex = 10
        TipMain.SetText(textboxSMUpdateInterval, "How Often does the System Monitor Refresh, in milliseconds")
        textboxSMUpdateInterval.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblSMNetworkInstance
        ' 
        TipMain.SetImage(lblSMNetworkInstance, Nothing)
        lblSMNetworkInstance.Location = New Point(339, 189)
        lblSMNetworkInstance.Margin = New Padding(4, 0, 4, 0)
        lblSMNetworkInstance.Name = "lblSMNetworkInstance"
        lblSMNetworkInstance.Size = New Size(145, 26)
        lblSMNetworkInstance.TabIndex = 108
        lblSMNetworkInstance.Text = "Network Instance"
        TipMain.SetText(lblSMNetworkInstance, Nothing)
        lblSMNetworkInstance.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblSMNetworkDownloadMaximum
        ' 
        TipMain.SetImage(lblSMNetworkDownloadMaximum, Nothing)
        lblSMNetworkDownloadMaximum.Location = New Point(18, 163)
        lblSMNetworkDownloadMaximum.Margin = New Padding(4, 0, 4, 0)
        lblSMNetworkDownloadMaximum.Name = "lblSMNetworkDownloadMaximum"
        lblSMNetworkDownloadMaximum.Size = New Size(154, 52)
        lblSMNetworkDownloadMaximum.TabIndex = 106
        lblSMNetworkDownloadMaximum.Text = "Network Download Activity Maximum"
        TipMain.SetText(lblSMNetworkDownloadMaximum, Nothing)
        lblSMNetworkDownloadMaximum.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMNetworkUploadMaximum
        ' 
        TipMain.SetImage(lblSMNetworkUploadMaximum, Nothing)
        lblSMNetworkUploadMaximum.Location = New Point(178, 163)
        lblSMNetworkUploadMaximum.Margin = New Padding(4, 0, 4, 0)
        lblSMNetworkUploadMaximum.Name = "lblSMNetworkUploadMaximum"
        lblSMNetworkUploadMaximum.Size = New Size(154, 52)
        lblSMNetworkUploadMaximum.TabIndex = 104
        lblSMNetworkUploadMaximum.Text = "Network Upload Activity Maximum"
        TipMain.SetText(lblSMNetworkUploadMaximum, Nothing)
        lblSMNetworkUploadMaximum.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblSMUpdateInterval
        ' 
        TipMain.SetImage(lblSMUpdateInterval, Nothing)
        lblSMUpdateInterval.Location = New Point(248, 51)
        lblSMUpdateInterval.Margin = New Padding(4, 0, 4, 0)
        lblSMUpdateInterval.Name = "lblSMUpdateInterval"
        lblSMUpdateInterval.Size = New Size(116, 52)
        lblSMUpdateInterval.TabIndex = 102
        lblSMUpdateInterval.Text = "Update Interval"
        TipMain.SetText(lblSMUpdateInterval, Nothing)
        lblSMUpdateInterval.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' txbxHKSM
        ' 
        txbxHKSM.Anchor = AnchorStyles.Top
        txbxHKSM.BorderStyle = BorderStyle.FixedSingle
        TipMain.SetImage(txbxHKSM, Nothing)
        txbxHKSM.Location = New Point(4, 28)
        txbxHKSM.Margin = New Padding(4)
        txbxHKSM.Name = "txbxHKSM"
        txbxHKSM.ShortcutsEnabled = False
        txbxHKSM.Size = New Size(212, 29)
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
        btnHKSet.Image = My.Resources.Resources.ImageSet32
        TipMain.SetImage(btnHKSet, My.Resources.Resources.ImageSet32)
        btnHKSet.Location = New Point(168, 58)
        btnHKSet.Margin = New Padding(4)
        btnHKSet.Name = "btnHKSet"
        btnHKSet.Size = New Size(48, 48)
        btnHKSet.TabIndex = 1010
        TipMain.SetText(btnHKSet, "Activate New HotKey")
        btnHKSet.TextAlign = ContentAlignment.MiddleRight
        btnHKSet.UseVisualStyleBackColor = True
        ' 
        ' btnHKUndo
        ' 
        btnHKUndo.Enabled = False
        btnHKUndo.ForeColor = Color.Navy
        btnHKUndo.Image = My.Resources.Resources.ImageRestore32
        TipMain.SetImage(btnHKUndo, My.Resources.Resources.ImageRestore32)
        btnHKUndo.Location = New Point(4, 58)
        btnHKUndo.Margin = New Padding(4)
        btnHKUndo.Name = "btnHKUndo"
        btnHKUndo.Size = New Size(48, 48)
        btnHKUndo.TabIndex = 1000
        TipMain.SetText(btnHKUndo, "Restore Original HotKey")
        btnHKUndo.TextAlign = ContentAlignment.MiddleRight
        btnHKUndo.UseVisualStyleBackColor = True
        ' 
        ' btnHKEnabled
        ' 
        btnHKEnabled.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnHKEnabled.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipMain.SetImage(btnHKEnabled, Nothing)
        btnHKEnabled.ImageAlign = ContentAlignment.MiddleLeft
        btnHKEnabled.Location = New Point(4, 139)
        btnHKEnabled.Margin = New Padding(4)
        btnHKEnabled.Name = "btnHKEnabled"
        btnHKEnabled.Size = New Size(243, 48)
        btnHKEnabled.TabIndex = 1020
        TipMain.SetText(btnHKEnabled, "Enable / Disable HotKeys")
        btnHKEnabled.TextAlign = ContentAlignment.MiddleRight
        btnHKEnabled.UseVisualStyleBackColor = True
        ' 
        ' lblHKSM
        ' 
        lblHKSM.Anchor = AnchorStyles.Top
        lblHKSM.ForeColor = SystemColors.ControlText
        TipMain.SetImage(lblHKSM, Nothing)
        lblHKSM.Location = New Point(4, 1)
        lblHKSM.Margin = New Padding(4, 0, 4, 0)
        lblHKSM.Name = "lblHKSM"
        lblHKSM.Size = New Size(212, 26)
        lblHKSM.TabIndex = 120
        lblHKSM.Text = "Toggle System Monitor"
        TipMain.SetText(lblHKSM, Nothing)
        lblHKSM.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' btnHKSMDisable
        ' 
        btnHKSMDisable.Anchor = AnchorStyles.Top
        btnHKSMDisable.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnHKSMDisable.ForeColor = Color.Transparent
        btnHKSMDisable.Image = My.Resources.Resources.imageRemove
        TipMain.SetImage(btnHKSMDisable, My.Resources.Resources.imageRemove)
        btnHKSMDisable.Location = New Point(216, 26)
        btnHKSMDisable.Margin = New Padding(4)
        btnHKSMDisable.Name = "btnHKSMDisable"
        btnHKSMDisable.Size = New Size(32, 32)
        btnHKSMDisable.TabIndex = 122
        btnHKSMDisable.TabStop = False
        TipMain.SetText(btnHKSMDisable, "Disable This HotKey")
        btnHKSMDisable.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.Image = My.Resources.Resources.ImageOK
        TipMain.SetImage(btnClose, Nothing)
        btnClose.Location = New Point(378, 584)
        btnClose.Margin = New Padding(4)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(64, 64)
        btnClose.TabIndex = 100
        TipMain.SetText(btnClose, "Hide Window")
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' chbxSMAutoClose
        ' 
        TipMain.SetImage(chbxSMAutoClose, Nothing)
        chbxSMAutoClose.Location = New Point(430, 35)
        chbxSMAutoClose.Margin = New Padding(4)
        chbxSMAutoClose.Name = "chbxSMAutoClose"
        chbxSMAutoClose.Size = New Size(121, 26)
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
        panel1.Controls.Add(btnHKSMDisable)
        panel1.Controls.Add(btnHKEnabled)
        panel1.Controls.Add(txbxHKSM)
        panel1.Controls.Add(lblHKSM)
        panel1.Controls.Add(btnHKUndo)
        panel1.Controls.Add(btnHKSet)
        TipMain.SetImage(panel1, Nothing)
        panel1.Location = New Point(550, 283)
        panel1.Margin = New Padding(4)
        panel1.Name = "panel1"
        panel1.Size = New Size(253, 193)
        panel1.TabIndex = 60
        TipMain.SetText(panel1, Nothing)
        ' 
        ' TipMain
        ' 
        TipMain.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ' 
        ' LblBehavior
        ' 
        LblBehavior.AutoSize = True
        LblBehavior.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipMain.SetImage(LblBehavior, Nothing)
        LblBehavior.Location = New Point(375, 11)
        LblBehavior.Margin = New Padding(4, 0, 4, 0)
        LblBehavior.Name = "LblBehavior"
        LblBehavior.Size = New Size(78, 21)
        LblBehavior.TabIndex = 156
        LblBehavior.Text = "Behavior"
        TipMain.SetText(LblBehavior, Nothing)
        LblBehavior.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' LblNetwork
        ' 
        LblNetwork.AutoSize = True
        LblNetwork.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipMain.SetImage(LblNetwork, Nothing)
        LblNetwork.Location = New Point(375, 146)
        LblNetwork.Margin = New Padding(4, 0, 4, 0)
        LblNetwork.Name = "LblNetwork"
        LblNetwork.Size = New Size(76, 21)
        LblNetwork.TabIndex = 157
        LblNetwork.Text = "Network"
        TipMain.SetText(LblNetwork, Nothing)
        LblNetwork.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' LblColors
        ' 
        LblColors.AutoSize = True
        LblColors.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipMain.SetImage(LblColors, Nothing)
        LblColors.Location = New Point(234, 257)
        LblColors.Margin = New Padding(4, 0, 4, 0)
        LblColors.Name = "LblColors"
        LblColors.Size = New Size(58, 21)
        LblColors.TabIndex = 158
        LblColors.Text = "Colors"
        TipMain.SetText(LblColors, Nothing)
        LblColors.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' LblHotKey
        ' 
        LblHotKey.AutoSize = True
        LblHotKey.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipMain.SetImage(LblHotKey, Nothing)
        LblHotKey.Location = New Point(646, 257)
        LblHotKey.Margin = New Padding(4, 0, 4, 0)
        LblHotKey.Name = "LblHotKey"
        LblHotKey.Size = New Size(66, 21)
        LblHotKey.TabIndex = 159
        LblHotKey.Text = "HotKey"
        TipMain.SetText(LblHotKey, Nothing)
        LblHotKey.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' LblTheme
        ' 
        LblTheme.AutoSize = True
        LblTheme.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipMain.SetImage(LblTheme, Nothing)
        LblTheme.Location = New Point(379, 491)
        LblTheme.Margin = New Padding(4, 0, 4, 0)
        LblTheme.Name = "LblTheme"
        LblTheme.Size = New Size(62, 21)
        LblTheme.TabIndex = 160
        LblTheme.Text = "Theme"
        TipMain.SetText(LblTheme, Nothing)
        LblTheme.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' CoBoxTheme
        ' 
        CoBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList
        CoBoxTheme.FormattingEnabled = True
        TipMain.SetImage(CoBoxTheme, Nothing)
        CoBoxTheme.Location = New Point(333, 515)
        CoBoxTheme.Name = "CoBoxTheme"
        CoBoxTheme.Size = New Size(155, 30)
        CoBoxTheme.TabIndex = 161
        TipMain.SetText(CoBoxTheme, Nothing)
        ' 
        ' ChkBoxThemeAuto
        ' 
        ChkBoxThemeAuto.AutoSize = True
        TipMain.SetImage(ChkBoxThemeAuto, Nothing)
        ChkBoxThemeAuto.Location = New Point(497, 518)
        ChkBoxThemeAuto.Name = "ChkBoxThemeAuto"
        ChkBoxThemeAuto.Size = New Size(194, 25)
        ChkBoxThemeAuto.TabIndex = 162
        TipMain.SetText(ChkBoxThemeAuto, Nothing)
        ChkBoxThemeAuto.Text = "Auto Set With Windows"
        ChkBoxThemeAuto.UseVisualStyleBackColor = True
        ' 
        ' comboboxSMOpacity
        ' 
        comboboxSMOpacity.DropDownStyle = ComboBoxStyle.DropDownList
        comboboxSMOpacity.FormattingEnabled = True
        TipMain.SetImage(comboboxSMOpacity, Nothing)
        comboboxSMOpacity.Items.AddRange(New Object() {"100", "90", "80", "70", "60", "50", "40", "30", "20", "10"})
        comboboxSMOpacity.Location = New Point(495, 101)
        comboboxSMOpacity.Name = "comboboxSMOpacity"
        comboboxSMOpacity.Size = New Size(76, 30)
        comboboxSMOpacity.TabIndex = 163
        TipMain.SetText(comboboxSMOpacity, Nothing)
        ' 
        ' comboboxSMNetworkInstance
        ' 
        comboboxSMNetworkInstance.DropDownStyle = ComboBoxStyle.DropDownList
        comboboxSMNetworkInstance.FormattingEnabled = True
        TipMain.SetImage(comboboxSMNetworkInstance, Nothing)
        comboboxSMNetworkInstance.Location = New Point(340, 214)
        comboboxSMNetworkInstance.Name = "comboboxSMNetworkInstance"
        comboboxSMNetworkInstance.Size = New Size(463, 30)
        comboboxSMNetworkInstance.TabIndex = 164
        TipMain.SetText(comboboxSMNetworkInstance, Nothing)
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        AutoValidate = AutoValidate.EnablePreventFocusChange
        ClientSize = New Size(820, 661)
        Controls.Add(comboboxSMNetworkInstance)
        Controls.Add(comboboxSMOpacity)
        Controls.Add(ChkBoxThemeAuto)
        Controls.Add(CoBoxTheme)
        Controls.Add(LblTheme)
        Controls.Add(LblHotKey)
        Controls.Add(LblColors)
        Controls.Add(LblNetwork)
        Controls.Add(LblBehavior)
        Controls.Add(chbxSMAutoClose)
        Controls.Add(panel1)
        Controls.Add(chbxSMAutoMinimal)
        Controls.Add(panelSMColors)
        Controls.Add(textboxSMQuickHideInterval)
        Controls.Add(lblSMQuickHideInterval)
        Controls.Add(lblSMOpacity)
        Controls.Add(textboxSMNetworkDownloadMaximum)
        Controls.Add(textboxSMNetworkUploadMaximum)
        Controls.Add(textboxSMUpdateInterval)
        Controls.Add(btnClose)
        Controls.Add(lblSMNetworkInstance)
        Controls.Add(lblSMNetworkDownloadMaximum)
        Controls.Add(lblSMNetworkUploadMaximum)
        Controls.Add(lblSMUpdateInterval)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = My.Resources.Resources.iconApp
        TipMain.SetImage(Me, Nothing)
        Margin = New Padding(4)
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
    Private WithEvents textboxSMQuickHideInterval As System.Windows.Forms.TextBox
    Private lblSMUpdateInterval As System.Windows.Forms.Label
    Private lblSMNetworkDownloadMaximum As System.Windows.Forms.Label
    Private lblSMNetworkUploadMaximum As System.Windows.Forms.Label
    Private lblSMNetworkInstance As System.Windows.Forms.Label
    Private WithEvents textboxSMNetworkUploadMaximum As System.Windows.Forms.TextBox
    Private WithEvents textboxSMNetworkDownloadMaximum As System.Windows.Forms.TextBox
    Private WithEvents textboxSMUpdateInterval As System.Windows.Forms.TextBox
    Private WithEvents btnHKSMDisable As System.Windows.Forms.Button
    Private lblHKSM As System.Windows.Forms.Label
    Private tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents btnHKEnabled As System.Windows.Forms.Button
    Private WithEvents btnHKSet As System.Windows.Forms.Button
    Friend WithEvents TipMain As Skye.UI.ToolTipEX
    Friend WithEvents LblBehavior As Label
    Friend WithEvents LblNetwork As Label
    Friend WithEvents LblColors As Label
    Friend WithEvents LblHotKey As Label
    Friend WithEvents LblTheme As Label
    Friend WithEvents CoBoxTheme As Skye.UI.ComboBox
    Friend WithEvents ChkBoxThemeAuto As CheckBox
    Friend WithEvents comboboxSMOpacity As Skye.UI.ComboBox
    Friend WithEvents comboboxSMNetworkInstance As Skye.UI.ComboBox
End Class