' -----------------------------------------------------------------------
'
' ChapterMaker - Create and edit video chapter files.
' Copyright © 2016 Bob Swift
'
' This file is part of ChapterMaker.
'
' ChapterMaker is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' ChapterMaker is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with ChapterMaker.  If not, see <http://www.gnu.org/licenses/>.
'
' -----------------------------------------------------------------------
'
' Prepared using SharpDevelop <https://sourceforge.net/projects/sharpdevelop/>
'
' -----------------------------------------------------------------------

Partial Class Settings
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
		RemoveHandler Application.Idle, AddressOf UpdateEditButtons
		MyBase.OnFormClosing(e)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Dim treeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Updates")
		Dim treeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Input Files")
		Dim treeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Output Files")
		Dim treeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Chapter Titles")
		Dim treeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Confirmations")
		Dim treeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Preferred Defaults")
		Dim treeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ChapterDB")
		Dim treeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("External Tools")
		Dim treeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Program Settings", New System.Windows.Forms.TreeNode() {treeNode1, treeNode2, treeNode3, treeNode4, treeNode5, treeNode6, treeNode7, treeNode8})
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
		Me.bSave = New System.Windows.Forms.Button()
		Me.bCancel = New System.Windows.Forms.Button()
		Me.group3 = New System.Windows.Forms.GroupBox()
		Me.rbTXT = New System.Windows.Forms.RadioButton()
		Me.label8 = New System.Windows.Forms.Label()
		Me.tbTXTExt = New System.Windows.Forms.TextBox()
		Me.label10 = New System.Windows.Forms.Label()
		Me.tbXMLExt = New System.Windows.Forms.TextBox()
		Me.label7 = New System.Windows.Forms.Label()
		Me.tbOGMExt = New System.Windows.Forms.TextBox()
		Me.bDirectoryLookup = New System.Windows.Forms.Button()
		Me.tbOutputDir = New System.Windows.Forms.TextBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.rbXML = New System.Windows.Forms.RadioButton()
		Me.label1 = New System.Windows.Forms.Label()
		Me.rbOGM = New System.Windows.Forms.RadioButton()
		Me.rbChapterNum = New System.Windows.Forms.RadioButton()
		Me.rbNA = New System.Windows.Forms.RadioButton()
		Me.cbNumbers = New System.Windows.Forms.CheckBox()
		Me.label3 = New System.Windows.Forms.Label()
		Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.group5 = New System.Windows.Forms.GroupBox()
		Me.cbUpload = New System.Windows.Forms.CheckBox()
		Me.cbModify = New System.Windows.Forms.CheckBox()
		Me.cbInsert = New System.Windows.Forms.CheckBox()
		Me.cbDelete = New System.Windows.Forms.CheckBox()
		Me.group1 = New System.Windows.Forms.GroupBox()
		Me.bUpdateCheck = New System.Windows.Forms.Button()
		Me.cbUpdates = New System.Windows.Forms.CheckBox()
		Me.group7 = New System.Windows.Forms.GroupBox()
		Me.label13 = New System.Windows.Forms.Label()
		Me.tbUploader = New System.Windows.Forms.TextBox()
		Me.label12 = New System.Windows.Forms.Label()
		Me.tbApiKey = New System.Windows.Forms.TextBox()
		Me.label11 = New System.Windows.Forms.Label()
		Me.cbChapterDB = New System.Windows.Forms.CheckBox()
		Me.group6 = New System.Windows.Forms.GroupBox()
		Me.lbFRList = New System.Windows.Forms.ListBox()
		Me.bFRDropDown = New System.Windows.Forms.Button()
		Me.label6 = New System.Windows.Forms.Label()
		Me.tbFrameRate = New System.Windows.Forms.TextBox()
		Me.cbLanguage = New System.Windows.Forms.ComboBox()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.group4 = New System.Windows.Forms.GroupBox()
		Me.cbTimes = New System.Windows.Forms.CheckBox()
		Me.rbChapterTime = New System.Windows.Forms.RadioButton()
		Me.group2 = New System.Windows.Forms.GroupBox()
		Me.cbLoadAppend = New System.Windows.Forms.CheckBox()
		Me.treeView1 = New System.Windows.Forms.TreeView()
		Me.label9 = New System.Windows.Forms.Label()
		Me.group0 = New System.Windows.Forms.GroupBox()
		Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.newToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.openToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.printToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
		Me.cutToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.copyToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.pasteToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.helpToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.group8 = New System.Windows.Forms.GroupBox()
		Me.bMkvToolNix = New System.Windows.Forms.Button()
		Me.tbMkvToolNix = New System.Windows.Forms.TextBox()
		Me.label14 = New System.Windows.Forms.Label()
		Me.label15 = New System.Windows.Forms.Label()
		Me.group3.SuspendLayout
		Me.group5.SuspendLayout
		Me.group1.SuspendLayout
		Me.group7.SuspendLayout
		Me.group6.SuspendLayout
		Me.group4.SuspendLayout
		Me.group2.SuspendLayout
		Me.group0.SuspendLayout
		Me.toolStrip1.SuspendLayout
		Me.statusStrip1.SuspendLayout
		Me.group8.SuspendLayout
		Me.SuspendLayout
		'
		'bSave
		'
		Me.bSave.Location = New System.Drawing.Point(496, 272)
		Me.bSave.Margin = New System.Windows.Forms.Padding(4)
		Me.bSave.Name = "bSave"
		Me.bSave.Size = New System.Drawing.Size(100, 28)
		Me.bSave.TabIndex = 0
		Me.bSave.Text = "Save / Exit"
		Me.bSave.UseVisualStyleBackColor = true
		AddHandler Me.bSave.Click, AddressOf Me.BSaveClick
		'
		'bCancel
		'
		Me.bCancel.Location = New System.Drawing.Point(600, 272)
		Me.bCancel.Margin = New System.Windows.Forms.Padding(4)
		Me.bCancel.Name = "bCancel"
		Me.bCancel.Size = New System.Drawing.Size(100, 28)
		Me.bCancel.TabIndex = 1
		Me.bCancel.Text = "Cancel"
		Me.bCancel.UseVisualStyleBackColor = true
		AddHandler Me.bCancel.Click, AddressOf Me.BCancelClick
		'
		'group3
		'
		Me.group3.Controls.Add(Me.rbTXT)
		Me.group3.Controls.Add(Me.label8)
		Me.group3.Controls.Add(Me.tbTXTExt)
		Me.group3.Controls.Add(Me.label10)
		Me.group3.Controls.Add(Me.tbXMLExt)
		Me.group3.Controls.Add(Me.label7)
		Me.group3.Controls.Add(Me.tbOGMExt)
		Me.group3.Controls.Add(Me.bDirectoryLookup)
		Me.group3.Controls.Add(Me.tbOutputDir)
		Me.group3.Controls.Add(Me.label2)
		Me.group3.Controls.Add(Me.rbXML)
		Me.group3.Controls.Add(Me.label1)
		Me.group3.Controls.Add(Me.rbOGM)
		Me.group3.Location = New System.Drawing.Point(232, 32)
		Me.group3.Name = "group3"
		Me.group3.Size = New System.Drawing.Size(464, 232)
		Me.group3.TabIndex = 4
		Me.group3.TabStop = false
		Me.group3.Text = "Output Files"
		'
		'rbTXT
		'
		Me.rbTXT.Location = New System.Drawing.Point(80, 72)
		Me.rbTXT.Name = "rbTXT"
		Me.rbTXT.Size = New System.Drawing.Size(344, 24)
		Me.rbTXT.TabIndex = 3
		Me.rbTXT.TabStop = true
		Me.rbTXT.Text = "TXT (Simple Text File)"
		Me.rbTXT.UseVisualStyleBackColor = true
		'
		'label8
		'
		Me.label8.Location = New System.Drawing.Point(8, 120)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(72, 24)
		Me.label8.TabIndex = 7
		Me.label8.Text = "Text Ext.:"
		Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tbTXTExt
		'
		Me.tbTXTExt.Location = New System.Drawing.Point(80, 120)
		Me.tbTXTExt.Name = "tbTXTExt"
		Me.tbTXTExt.Size = New System.Drawing.Size(344, 22)
		Me.tbTXTExt.TabIndex = 8
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(8, 144)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(72, 24)
		Me.label10.TabIndex = 9
		Me.label10.Text = "XML Ext.:"
		Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tbXMLExt
		'
		Me.tbXMLExt.Location = New System.Drawing.Point(80, 144)
		Me.tbXMLExt.Name = "tbXMLExt"
		Me.tbXMLExt.Size = New System.Drawing.Size(344, 22)
		Me.tbXMLExt.TabIndex = 10
		AddHandler Me.tbXMLExt.Leave, AddressOf Me.TbXMLExtLeave
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(8, 168)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(72, 24)
		Me.label7.TabIndex = 11
		Me.label7.Text = "OGM Ext.:"
		Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tbOGMExt
		'
		Me.tbOGMExt.Location = New System.Drawing.Point(80, 168)
		Me.tbOGMExt.Name = "tbOGMExt"
		Me.tbOGMExt.Size = New System.Drawing.Size(344, 22)
		Me.tbOGMExt.TabIndex = 12
		AddHandler Me.tbOGMExt.Leave, AddressOf Me.TbOGMExtLeave
		'
		'bDirectoryLookup
		'
		Me.bDirectoryLookup.Location = New System.Drawing.Point(432, 96)
		Me.bDirectoryLookup.Name = "bDirectoryLookup"
		Me.bDirectoryLookup.Size = New System.Drawing.Size(24, 24)
		Me.bDirectoryLookup.TabIndex = 6
		Me.bDirectoryLookup.TabStop = false
		Me.bDirectoryLookup.Text = "..."
		Me.bDirectoryLookup.UseVisualStyleBackColor = true
		AddHandler Me.bDirectoryLookup.Click, AddressOf Me.BDirectoryLookupClick
		'
		'tbOutputDir
		'
		Me.tbOutputDir.Location = New System.Drawing.Point(80, 96)
		Me.tbOutputDir.Name = "tbOutputDir"
		Me.tbOutputDir.Size = New System.Drawing.Size(344, 22)
		Me.tbOutputDir.TabIndex = 5
		AddHandler Me.tbOutputDir.DoubleClick, AddressOf Me.TbOutputDirDoubleClick
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(8, 96)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(72, 24)
		Me.label2.TabIndex = 4
		Me.label2.Text = "Directory:"
		Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'rbXML
		'
		Me.rbXML.Checked = true
		Me.rbXML.Location = New System.Drawing.Point(80, 24)
		Me.rbXML.Name = "rbXML"
		Me.rbXML.Size = New System.Drawing.Size(344, 24)
		Me.rbXML.TabIndex = 1
		Me.rbXML.TabStop = true
		Me.rbXML.Text = "XML (Extensible Markup Language)"
		Me.rbXML.UseVisualStyleBackColor = true
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(8, 24)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(72, 24)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Type:"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'rbOGM
		'
		Me.rbOGM.Location = New System.Drawing.Point(80, 48)
		Me.rbOGM.Name = "rbOGM"
		Me.rbOGM.Size = New System.Drawing.Size(344, 24)
		Me.rbOGM.TabIndex = 2
		Me.rbOGM.TabStop = true
		Me.rbOGM.Text = "OGM (Ogg Media)"
		Me.rbOGM.UseVisualStyleBackColor = true
		'
		'rbChapterNum
		'
		Me.rbChapterNum.Checked = true
		Me.rbChapterNum.Location = New System.Drawing.Point(224, 72)
		Me.rbChapterNum.Name = "rbChapterNum"
		Me.rbChapterNum.Size = New System.Drawing.Size(128, 24)
		Me.rbChapterNum.TabIndex = 3
		Me.rbChapterNum.TabStop = true
		Me.rbChapterNum.Text = "Chapter Number"
		Me.rbChapterNum.UseVisualStyleBackColor = true
		'
		'rbNA
		'
		Me.rbNA.Location = New System.Drawing.Point(224, 120)
		Me.rbNA.Name = "rbNA"
		Me.rbNA.Size = New System.Drawing.Size(56, 24)
		Me.rbNA.TabIndex = 5
		Me.rbNA.TabStop = true
		Me.rbNA.Text = """n/a"""
		Me.rbNA.UseVisualStyleBackColor = true
		'
		'cbNumbers
		'
		Me.cbNumbers.Location = New System.Drawing.Point(8, 24)
		Me.cbNumbers.Name = "cbNumbers"
		Me.cbNumbers.Size = New System.Drawing.Size(448, 24)
		Me.cbNumbers.TabIndex = 0
		Me.cbNumbers.Text = "Include chapter numbers in output chapter titles"
		Me.cbNumbers.UseVisualStyleBackColor = true
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(8, 72)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(216, 24)
		Me.label3.TabIndex = 2
		Me.label3.Text = "Replace missing chapter titles with:"
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'group5
		'
		Me.group5.Controls.Add(Me.cbUpload)
		Me.group5.Controls.Add(Me.cbModify)
		Me.group5.Controls.Add(Me.cbInsert)
		Me.group5.Controls.Add(Me.cbDelete)
		Me.group5.Location = New System.Drawing.Point(232, 32)
		Me.group5.Name = "group5"
		Me.group5.Size = New System.Drawing.Size(464, 232)
		Me.group5.TabIndex = 6
		Me.group5.TabStop = false
		Me.group5.Text = "Confirmations"
		'
		'cbUpload
		'
		Me.cbUpload.Location = New System.Drawing.Point(8, 96)
		Me.cbUpload.Name = "cbUpload"
		Me.cbUpload.Size = New System.Drawing.Size(448, 24)
		Me.cbUpload.TabIndex = 3
		Me.cbUpload.Text = "Uploading chapter information to the ChapterDB website"
		Me.cbUpload.UseVisualStyleBackColor = true
		'
		'cbModify
		'
		Me.cbModify.Location = New System.Drawing.Point(8, 48)
		Me.cbModify.Name = "cbModify"
		Me.cbModify.Size = New System.Drawing.Size(448, 24)
		Me.cbModify.TabIndex = 1
		Me.cbModify.Text = "Scaling, shifting or adjusting chapter times"
		Me.cbModify.UseVisualStyleBackColor = true
		'
		'cbInsert
		'
		Me.cbInsert.Location = New System.Drawing.Point(8, 24)
		Me.cbInsert.Name = "cbInsert"
		Me.cbInsert.Size = New System.Drawing.Size(448, 24)
		Me.cbInsert.TabIndex = 0
		Me.cbInsert.Text = "Inserting chapter times or titles"
		Me.cbInsert.UseVisualStyleBackColor = true
		'
		'cbDelete
		'
		Me.cbDelete.Location = New System.Drawing.Point(8, 72)
		Me.cbDelete.Name = "cbDelete"
		Me.cbDelete.Size = New System.Drawing.Size(448, 24)
		Me.cbDelete.TabIndex = 2
		Me.cbDelete.Text = "Deleting chapter times, titles or chapter list lines"
		Me.cbDelete.UseVisualStyleBackColor = true
		'
		'group1
		'
		Me.group1.Controls.Add(Me.bUpdateCheck)
		Me.group1.Controls.Add(Me.cbUpdates)
		Me.group1.Location = New System.Drawing.Point(232, 32)
		Me.group1.Name = "group1"
		Me.group1.Size = New System.Drawing.Size(464, 232)
		Me.group1.TabIndex = 16
		Me.group1.TabStop = false
		Me.group1.Text = "Updates"
		'
		'bUpdateCheck
		'
		Me.bUpdateCheck.Location = New System.Drawing.Point(360, 48)
		Me.bUpdateCheck.Margin = New System.Windows.Forms.Padding(4)
		Me.bUpdateCheck.Name = "bUpdateCheck"
		Me.bUpdateCheck.Size = New System.Drawing.Size(100, 28)
		Me.bUpdateCheck.TabIndex = 1
		Me.bUpdateCheck.Text = "Check Now"
		Me.bUpdateCheck.UseVisualStyleBackColor = true
		AddHandler Me.bUpdateCheck.Click, AddressOf Me.BUpdateCheckClick
		'
		'cbUpdates
		'
		Me.cbUpdates.Location = New System.Drawing.Point(8, 24)
		Me.cbUpdates.Name = "cbUpdates"
		Me.cbUpdates.Size = New System.Drawing.Size(448, 24)
		Me.cbUpdates.TabIndex = 0
		Me.cbUpdates.Text = "Check for updates during program start-up"
		Me.cbUpdates.UseVisualStyleBackColor = true
		'
		'group7
		'
		Me.group7.Controls.Add(Me.label13)
		Me.group7.Controls.Add(Me.tbUploader)
		Me.group7.Controls.Add(Me.label12)
		Me.group7.Controls.Add(Me.tbApiKey)
		Me.group7.Controls.Add(Me.label11)
		Me.group7.Controls.Add(Me.cbChapterDB)
		Me.group7.Location = New System.Drawing.Point(232, 32)
		Me.group7.Name = "group7"
		Me.group7.Size = New System.Drawing.Size(464, 232)
		Me.group7.TabIndex = 19
		Me.group7.TabStop = false
		Me.group7.Text = "ChapterDB"
		'
		'label13
		'
		Me.label13.Location = New System.Drawing.Point(280, 72)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(176, 23)
		Me.label13.TabIndex = 5
		Me.label13.Text = "(Name or email address)"
		Me.label13.Visible = false
		'
		'tbUploader
		'
		Me.tbUploader.Location = New System.Drawing.Point(88, 72)
		Me.tbUploader.Name = "tbUploader"
		Me.tbUploader.Size = New System.Drawing.Size(184, 22)
		Me.tbUploader.TabIndex = 4
		Me.tbUploader.Visible = false
		'
		'label12
		'
		Me.label12.Location = New System.Drawing.Point(8, 72)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(80, 23)
		Me.label12.TabIndex = 3
		Me.label12.Text = "Uploader:"
		Me.label12.Visible = false
		'
		'tbApiKey
		'
		Me.tbApiKey.Location = New System.Drawing.Point(88, 48)
		Me.tbApiKey.Name = "tbApiKey"
		Me.tbApiKey.Size = New System.Drawing.Size(184, 22)
		Me.tbApiKey.TabIndex = 2
		AddHandler Me.tbApiKey.TextChanged, AddressOf Me.TbApiKeyTextChanged
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(8, 48)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(80, 23)
		Me.label11.TabIndex = 1
		Me.label11.Text = "API Key:"
		'
		'cbChapterDB
		'
		Me.cbChapterDB.Location = New System.Drawing.Point(8, 24)
		Me.cbChapterDB.Name = "cbChapterDB"
		Me.cbChapterDB.Size = New System.Drawing.Size(448, 24)
		Me.cbChapterDB.TabIndex = 0
		Me.cbChapterDB.Text = "Allow file uploads to ChapterDB web site"
		Me.cbChapterDB.UseVisualStyleBackColor = true
		Me.cbChapterDB.Visible = false
		'
		'group6
		'
		Me.group6.Controls.Add(Me.lbFRList)
		Me.group6.Controls.Add(Me.bFRDropDown)
		Me.group6.Controls.Add(Me.label6)
		Me.group6.Controls.Add(Me.tbFrameRate)
		Me.group6.Controls.Add(Me.cbLanguage)
		Me.group6.Controls.Add(Me.label5)
		Me.group6.Controls.Add(Me.label4)
		Me.group6.Location = New System.Drawing.Point(232, 32)
		Me.group6.Name = "group6"
		Me.group6.Size = New System.Drawing.Size(464, 232)
		Me.group6.TabIndex = 7
		Me.group6.TabStop = false
		Me.group6.Text = "Preferred Defaults"
		'
		'lbFRList
		'
		Me.lbFRList.FormattingEnabled = true
		Me.lbFRList.ItemHeight = 16
		Me.lbFRList.Items.AddRange(New Object() {"23.976", "24.0", "25.0", "29.97", "30.0", "50.0", "59.94", "60", "Custom"})
		Me.lbFRList.Location = New System.Drawing.Point(120, 48)
		Me.lbFRList.Name = "lbFRList"
		Me.lbFRList.Size = New System.Drawing.Size(72, 148)
		Me.lbFRList.TabIndex = 28
		Me.lbFRList.Visible = false
		AddHandler Me.lbFRList.SelectedIndexChanged, AddressOf Me.LbFRListSelectedIndexChanged
		AddHandler Me.lbFRList.Leave, AddressOf Me.LbFRListLeave
		'
		'bFRDropDown
		'
		Me.bFRDropDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.bFRDropDown.Location = New System.Drawing.Point(192, 48)
		Me.bFRDropDown.Name = "bFRDropDown"
		Me.bFRDropDown.Size = New System.Drawing.Size(24, 23)
		Me.bFRDropDown.TabIndex = 29
		Me.bFRDropDown.TabStop = false
		Me.bFRDropDown.Text = "▼"
		Me.bFRDropDown.UseVisualStyleBackColor = true
		AddHandler Me.bFRDropDown.Click, AddressOf Me.BFRDropDownClick
		'
		'label6
		'
		Me.label6.Location = New System.Drawing.Point(224, 48)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(32, 24)
		Me.label6.TabIndex = 4
		Me.label6.Text = "fps"
		Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tbFrameRate
		'
		Me.tbFrameRate.Location = New System.Drawing.Point(120, 48)
		Me.tbFrameRate.Name = "tbFrameRate"
		Me.tbFrameRate.Size = New System.Drawing.Size(72, 22)
		Me.tbFrameRate.TabIndex = 3
		Me.tbFrameRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'cbLanguage
		'
		Me.cbLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cbLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbLanguage.FormattingEnabled = true
		Me.cbLanguage.Location = New System.Drawing.Point(120, 24)
		Me.cbLanguage.Name = "cbLanguage"
		Me.cbLanguage.Size = New System.Drawing.Size(304, 24)
		Me.cbLanguage.TabIndex = 1
		'
		'label5
		'
		Me.label5.Location = New System.Drawing.Point(8, 24)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(112, 24)
		Me.label5.TabIndex = 0
		Me.label5.Text = "Language Code:"
		Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(8, 48)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(88, 24)
		Me.label4.TabIndex = 2
		Me.label4.Text = "Frame Rate:"
		Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'group4
		'
		Me.group4.Controls.Add(Me.cbTimes)
		Me.group4.Controls.Add(Me.rbChapterTime)
		Me.group4.Controls.Add(Me.rbChapterNum)
		Me.group4.Controls.Add(Me.cbNumbers)
		Me.group4.Controls.Add(Me.label3)
		Me.group4.Controls.Add(Me.rbNA)
		Me.group4.Location = New System.Drawing.Point(232, 32)
		Me.group4.Name = "group4"
		Me.group4.Size = New System.Drawing.Size(464, 232)
		Me.group4.TabIndex = 5
		Me.group4.TabStop = false
		Me.group4.Text = "Chapter Titles"
		'
		'cbTimes
		'
		Me.cbTimes.Location = New System.Drawing.Point(8, 48)
		Me.cbTimes.Name = "cbTimes"
		Me.cbTimes.Size = New System.Drawing.Size(448, 24)
		Me.cbTimes.TabIndex = 1
		Me.cbTimes.Text = "Include chapter times in output chapter titles"
		Me.cbTimes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
		Me.cbTimes.UseVisualStyleBackColor = true
		'
		'rbChapterTime
		'
		Me.rbChapterTime.Location = New System.Drawing.Point(224, 96)
		Me.rbChapterTime.Name = "rbChapterTime"
		Me.rbChapterTime.Size = New System.Drawing.Size(128, 24)
		Me.rbChapterTime.TabIndex = 4
		Me.rbChapterTime.TabStop = true
		Me.rbChapterTime.Text = "Chapter Time"
		Me.rbChapterTime.UseVisualStyleBackColor = true
		'
		'group2
		'
		Me.group2.Controls.Add(Me.cbLoadAppend)
		Me.group2.Location = New System.Drawing.Point(232, 32)
		Me.group2.Name = "group2"
		Me.group2.Size = New System.Drawing.Size(464, 232)
		Me.group2.TabIndex = 3
		Me.group2.TabStop = false
		Me.group2.Text = "Input Files"
		'
		'cbLoadAppend
		'
		Me.cbLoadAppend.Location = New System.Drawing.Point(8, 24)
		Me.cbLoadAppend.Name = "cbLoadAppend"
		Me.cbLoadAppend.Size = New System.Drawing.Size(448, 24)
		Me.cbLoadAppend.TabIndex = 0
		Me.cbLoadAppend.Text = "Append times and titles to existing list when loading"
		Me.cbLoadAppend.UseVisualStyleBackColor = true
		'
		'treeView1
		'
		Me.treeView1.Location = New System.Drawing.Point(8, 32)
		Me.treeView1.Name = "treeView1"
		treeNode1.Name = "Node1"
		treeNode1.Text = "Updates"
		treeNode2.Name = "Node2"
		treeNode2.Text = "Input Files"
		treeNode3.Name = "Node3"
		treeNode3.Text = "Output Files"
		treeNode4.Name = "Node4"
		treeNode4.Text = "Chapter Titles"
		treeNode5.Name = "Node5"
		treeNode5.Text = "Confirmations"
		treeNode6.Name = "Node6"
		treeNode6.Text = "Preferred Defaults"
		treeNode7.Name = "Node7"
		treeNode7.Text = "ChapterDB"
		treeNode8.Name = "Node8"
		treeNode8.Text = "External Tools"
		treeNode9.Name = "Node0"
		treeNode9.Text = "Program Settings"
		Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {treeNode9})
		Me.treeView1.Size = New System.Drawing.Size(216, 232)
		Me.treeView1.TabIndex = 14
		Me.treeView1.TabStop = false
		AddHandler Me.treeView1.AfterSelect, AddressOf Me.TreeView1AfterSelect
		'
		'label9
		'
		Me.label9.Location = New System.Drawing.Point(8, 24)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(448, 72)
		Me.label9.TabIndex = 0
		Me.label9.Text = "Please select the settings that you would like to edit from the tree on the left "& _ 
		"side of the window.  Your settings for that selection will be displayed for revi"& _ 
		"ew and editing."
		'
		'group0
		'
		Me.group0.Controls.Add(Me.label9)
		Me.group0.Location = New System.Drawing.Point(232, 32)
		Me.group0.Name = "group0"
		Me.group0.Size = New System.Drawing.Size(464, 232)
		Me.group0.TabIndex = 15
		Me.group0.TabStop = false
		Me.group0.Text = "Program Settings"
		'
		'toolStrip1
		'
		Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripButton, Me.openToolStripButton, Me.saveToolStripButton, Me.printToolStripButton, Me.toolStripSeparator, Me.cutToolStripButton, Me.copyToolStripButton, Me.pasteToolStripButton, Me.toolStripSeparator1, Me.helpToolStripButton})
		Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.toolStrip1.Name = "toolStrip1"
		Me.toolStrip1.Size = New System.Drawing.Size(706, 25)
		Me.toolStrip1.TabIndex = 17
		Me.toolStrip1.Text = "toolStrip1"
		'
		'newToolStripButton
		'
		Me.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.newToolStripButton.Image = CType(resources.GetObject("newToolStripButton.Image"),System.Drawing.Image)
		Me.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.newToolStripButton.Name = "newToolStripButton"
		Me.newToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.newToolStripButton.Text = "&New"
		Me.newToolStripButton.Visible = false
		'
		'openToolStripButton
		'
		Me.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.openToolStripButton.Image = CType(resources.GetObject("openToolStripButton.Image"),System.Drawing.Image)
		Me.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.openToolStripButton.Name = "openToolStripButton"
		Me.openToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.openToolStripButton.Text = "&Open"
		Me.openToolStripButton.Visible = false
		'
		'saveToolStripButton
		'
		Me.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.saveToolStripButton.Image = CType(resources.GetObject("saveToolStripButton.Image"),System.Drawing.Image)
		Me.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.saveToolStripButton.Name = "saveToolStripButton"
		Me.saveToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.saveToolStripButton.Text = "&Save"
		AddHandler Me.saveToolStripButton.Click, AddressOf Me.SaveToolStripButtonClick
		'
		'printToolStripButton
		'
		Me.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.printToolStripButton.Image = CType(resources.GetObject("printToolStripButton.Image"),System.Drawing.Image)
		Me.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.printToolStripButton.Name = "printToolStripButton"
		Me.printToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.printToolStripButton.Text = "&Print"
		Me.printToolStripButton.Visible = false
		'
		'toolStripSeparator
		'
		Me.toolStripSeparator.Name = "toolStripSeparator"
		Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
		'
		'cutToolStripButton
		'
		Me.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.cutToolStripButton.Image = CType(resources.GetObject("cutToolStripButton.Image"),System.Drawing.Image)
		Me.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.cutToolStripButton.Name = "cutToolStripButton"
		Me.cutToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.cutToolStripButton.Text = "C&ut"
		AddHandler Me.cutToolStripButton.Click, AddressOf Me.CutToolStripButtonClick
		'
		'copyToolStripButton
		'
		Me.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.copyToolStripButton.Image = CType(resources.GetObject("copyToolStripButton.Image"),System.Drawing.Image)
		Me.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.copyToolStripButton.Name = "copyToolStripButton"
		Me.copyToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.copyToolStripButton.Text = "&Copy"
		AddHandler Me.copyToolStripButton.Click, AddressOf Me.CopyToolStripButtonClick
		'
		'pasteToolStripButton
		'
		Me.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.pasteToolStripButton.Image = CType(resources.GetObject("pasteToolStripButton.Image"),System.Drawing.Image)
		Me.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.pasteToolStripButton.Name = "pasteToolStripButton"
		Me.pasteToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.pasteToolStripButton.Text = "&Paste"
		AddHandler Me.pasteToolStripButton.Click, AddressOf Me.PasteToolStripButtonClick
		'
		'toolStripSeparator1
		'
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'helpToolStripButton
		'
		Me.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.helpToolStripButton.Image = CType(resources.GetObject("helpToolStripButton.Image"),System.Drawing.Image)
		Me.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.helpToolStripButton.Name = "helpToolStripButton"
		Me.helpToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.helpToolStripButton.Text = "He&lp"
		AddHandler Me.helpToolStripButton.Click, AddressOf Me.HelpToolStripButtonClick
		'
		'statusStrip1
		'
		Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1})
		Me.statusStrip1.Location = New System.Drawing.Point(0, 307)
		Me.statusStrip1.Name = "statusStrip1"
		Me.statusStrip1.Size = New System.Drawing.Size(706, 22)
		Me.statusStrip1.TabIndex = 18
		Me.statusStrip1.Text = "statusStrip1"
		'
		'toolStripStatusLabel1
		'
		Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
		Me.toolStripStatusLabel1.Size = New System.Drawing.Size(118, 17)
		Me.toolStripStatusLabel1.Text = "toolStripStatusLabel1"
		'
		'group8
		'
		Me.group8.Controls.Add(Me.bMkvToolNix)
		Me.group8.Controls.Add(Me.tbMkvToolNix)
		Me.group8.Controls.Add(Me.label14)
		Me.group8.Controls.Add(Me.label15)
		Me.group8.Location = New System.Drawing.Point(232, 32)
		Me.group8.Name = "group8"
		Me.group8.Size = New System.Drawing.Size(464, 232)
		Me.group8.TabIndex = 19
		Me.group8.TabStop = false
		Me.group8.Text = "External Tools"
		'
		'bMkvToolNix
		'
		Me.bMkvToolNix.Location = New System.Drawing.Point(432, 48)
		Me.bMkvToolNix.Name = "bMkvToolNix"
		Me.bMkvToolNix.Size = New System.Drawing.Size(24, 24)
		Me.bMkvToolNix.TabIndex = 6
		Me.bMkvToolNix.TabStop = false
		Me.bMkvToolNix.Text = "..."
		Me.bMkvToolNix.UseVisualStyleBackColor = true
		AddHandler Me.bMkvToolNix.Click, AddressOf Me.BMkvToolNixClick
		'
		'tbMkvToolNix
		'
		Me.tbMkvToolNix.Location = New System.Drawing.Point(104, 48)
		Me.tbMkvToolNix.Name = "tbMkvToolNix"
		Me.tbMkvToolNix.Size = New System.Drawing.Size(328, 22)
		Me.tbMkvToolNix.TabIndex = 5
		AddHandler Me.tbMkvToolNix.DoubleClick, AddressOf Me.TbMkvToolNixDoubleClick
		'
		'label14
		'
		Me.label14.Location = New System.Drawing.Point(8, 48)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(88, 24)
		Me.label14.TabIndex = 4
		Me.label14.Text = "MkVToolNix:"
		Me.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label15
		'
		Me.label15.Location = New System.Drawing.Point(8, 24)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(280, 24)
		Me.label15.TabIndex = 0
		Me.label15.Text = "Path to External Tools:"
		Me.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Settings
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(706, 329)
		Me.Controls.Add(Me.group7)
		Me.Controls.Add(Me.group8)
		Me.Controls.Add(Me.group1)
		Me.Controls.Add(Me.statusStrip1)
		Me.Controls.Add(Me.toolStrip1)
		Me.Controls.Add(Me.group5)
		Me.Controls.Add(Me.group0)
		Me.Controls.Add(Me.group6)
		Me.Controls.Add(Me.group2)
		Me.Controls.Add(Me.group3)
		Me.Controls.Add(Me.group4)
		Me.Controls.Add(Me.treeView1)
		Me.Controls.Add(Me.bCancel)
		Me.Controls.Add(Me.bSave)
		Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "Settings"
		Me.Text = "Settings"
		AddHandler Load, AddressOf Me.SettingsLoad
		Me.group3.ResumeLayout(false)
		Me.group3.PerformLayout
		Me.group5.ResumeLayout(false)
		Me.group1.ResumeLayout(false)
		Me.group7.ResumeLayout(false)
		Me.group7.PerformLayout
		Me.group6.ResumeLayout(false)
		Me.group6.PerformLayout
		Me.group4.ResumeLayout(false)
		Me.group2.ResumeLayout(false)
		Me.group0.ResumeLayout(false)
		Me.toolStrip1.ResumeLayout(false)
		Me.toolStrip1.PerformLayout
		Me.statusStrip1.ResumeLayout(false)
		Me.statusStrip1.PerformLayout
		Me.group8.ResumeLayout(false)
		Me.group8.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private cbUpload As System.Windows.Forms.CheckBox
	Private label12 As System.Windows.Forms.Label
	Private tbUploader As System.Windows.Forms.TextBox
	Private label13 As System.Windows.Forms.Label
	Private label11 As System.Windows.Forms.Label
	Private tbApiKey As System.Windows.Forms.TextBox
	Private cbChapterDB As System.Windows.Forms.CheckBox
	Private label15 As System.Windows.Forms.Label
	Private label14 As System.Windows.Forms.Label
	Private tbMkvToolNix As System.Windows.Forms.TextBox
	Private bMkvToolNix As System.Windows.Forms.Button
	Private group7 As System.Windows.Forms.GroupBox
	Private group8 As System.Windows.Forms.GroupBox
	Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
	Private statusStrip1 As System.Windows.Forms.StatusStrip
	Private helpToolStripButton As System.Windows.Forms.ToolStripButton
	Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Private pasteToolStripButton As System.Windows.Forms.ToolStripButton
	Private copyToolStripButton As System.Windows.Forms.ToolStripButton
	Private cutToolStripButton As System.Windows.Forms.ToolStripButton
	Private toolStripSeparator As System.Windows.Forms.ToolStripSeparator
	Private printToolStripButton As System.Windows.Forms.ToolStripButton
	Private saveToolStripButton As System.Windows.Forms.ToolStripButton
	Private openToolStripButton As System.Windows.Forms.ToolStripButton
	Private newToolStripButton As System.Windows.Forms.ToolStripButton
	Private toolStrip1 As System.Windows.Forms.ToolStrip
	Private tbTXTExt As System.Windows.Forms.TextBox
	Private label8 As System.Windows.Forms.Label
	Private rbTXT As System.Windows.Forms.RadioButton
	Private bFRDropDown As System.Windows.Forms.Button
	Private lbFRList As System.Windows.Forms.ListBox
	Private bUpdateCheck As System.Windows.Forms.Button
	Private cbUpdates As System.Windows.Forms.CheckBox
	Private group1 As System.Windows.Forms.GroupBox
	Private group0 As System.Windows.Forms.GroupBox
	Private tbXMLExt As System.Windows.Forms.TextBox
	Private label10 As System.Windows.Forms.Label
	Private label9 As System.Windows.Forms.Label
	Private treeView1 As System.Windows.Forms.TreeView
	Private cbTimes As System.Windows.Forms.CheckBox
	Private cbLoadAppend As System.Windows.Forms.CheckBox
	Private group2 As System.Windows.Forms.GroupBox
	Private rbChapterTime As System.Windows.Forms.RadioButton
	Private tbOGMExt As System.Windows.Forms.TextBox
	Private label7 As System.Windows.Forms.Label
	Private group4 As System.Windows.Forms.GroupBox
	Private cbLanguage As System.Windows.Forms.ComboBox
	Private tbFrameRate As System.Windows.Forms.TextBox
	Private label6 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private group6 As System.Windows.Forms.GroupBox
	Private cbDelete As System.Windows.Forms.CheckBox
	Private cbInsert As System.Windows.Forms.CheckBox
	Private cbModify As System.Windows.Forms.CheckBox
	Private group5 As System.Windows.Forms.GroupBox
	Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Private rbOGM As System.Windows.Forms.RadioButton
	Private label1 As System.Windows.Forms.Label
	Private rbXML As System.Windows.Forms.RadioButton
	Private label3 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private cbNumbers As System.Windows.Forms.CheckBox
	Private rbNA As System.Windows.Forms.RadioButton
	Private tbOutputDir As System.Windows.Forms.TextBox
	Private bDirectoryLookup As System.Windows.Forms.Button
	Private rbChapterNum As System.Windows.Forms.RadioButton
	Private label5 As System.Windows.Forms.Label
	Private group3 As System.Windows.Forms.GroupBox
	Private bCancel As System.Windows.Forms.Button
	Private bSave As System.Windows.Forms.Button
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
End Class
