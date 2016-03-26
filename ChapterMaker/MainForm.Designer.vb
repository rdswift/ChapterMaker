﻿' -----------------------------------------------------------------------
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

Partial Class MainForm
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
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.tbFileTitles = New System.Windows.Forms.TextBox()
		Me.tbFileTimes = New System.Windows.Forms.TextBox()
		Me.tbFileOutput = New System.Windows.Forms.TextBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.cbAddChapterNumbers = New System.Windows.Forms.CheckBox()
		Me.tbScaleFrom = New System.Windows.Forms.TextBox()
		Me.bReset = New System.Windows.Forms.Button()
		Me.bOutput = New System.Windows.Forms.Button()
		Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.tbOffset = New System.Windows.Forms.TextBox()
		Me.bTitlesFileDialog = New System.Windows.Forms.Button()
		Me.bTimesFileDialog = New System.Windows.Forms.Button()
		Me.bOutputFileDialog = New System.Windows.Forms.Button()
		Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.fileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.timesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.titlesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
		Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.printPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.exitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.editToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.wordsListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.settingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.contentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.indexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.tbFrameRate = New System.Windows.Forms.TextBox()
		Me.bLoadTitles = New System.Windows.Forms.Button()
		Me.bLoadTimes = New System.Windows.Forms.Button()
		Me.bOutputType = New System.Windows.Forms.Button()
		Me.tbTimeType = New System.Windows.Forms.TextBox()
		Me.tbTitleType = New System.Windows.Forms.TextBox()
		Me.tbOutputType = New System.Windows.Forms.TextBox()
		Me.maskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
		Me.dataGridView1 = New System.Windows.Forms.DataGridView()
		Me.dgNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.bTimeAdd = New System.Windows.Forms.Button()
		Me.label7 = New System.Windows.Forms.Label()
		Me.bTimeUpdate = New System.Windows.Forms.Button()
		Me.tbChapterTitle = New System.Windows.Forms.TextBox()
		Me.bTimeRemove = New System.Windows.Forms.Button()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.bTitleRemove = New System.Windows.Forms.Button()
		Me.bTitleUpdate = New System.Windows.Forms.Button()
		Me.bTitleInsert = New System.Windows.Forms.Button()
		Me.groupBox3 = New System.Windows.Forms.GroupBox()
		Me.cbLanguage = New System.Windows.Forms.ComboBox()
		Me.groupBox4 = New System.Windows.Forms.GroupBox()
		Me.bExit = New System.Windows.Forms.Button()
		Me.maskedTextBox4 = New System.Windows.Forms.MaskedTextBox()
		Me.label4 = New System.Windows.Forms.Label()
		Me.maskedTextBox3 = New System.Windows.Forms.MaskedTextBox()
		Me.label5 = New System.Windows.Forms.Label()
		Me.bAddIntervals = New System.Windows.Forms.Button()
		Me.label16 = New System.Windows.Forms.Label()
		Me.maskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
		Me.label15 = New System.Windows.Forms.Label()
		Me.label14 = New System.Windows.Forms.Label()
		Me.label13 = New System.Windows.Forms.Label()
		Me.bScaleTimes = New System.Windows.Forms.Button()
		Me.bShiftTimes = New System.Windows.Forms.Button()
		Me.label12 = New System.Windows.Forms.Label()
		Me.label11 = New System.Windows.Forms.Label()
		Me.bFrameRateTimes = New System.Windows.Forms.Button()
		Me.bFixTitleCase = New System.Windows.Forms.Button()
		Me.label10 = New System.Windows.Forms.Label()
		Me.bDeleteLine = New System.Windows.Forms.Button()
		Me.label9 = New System.Windows.Forms.Label()
		Me.helpProvider1 = New System.Windows.Forms.HelpProvider()
		Me.menuStrip1.SuspendLayout
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.groupBox1.SuspendLayout
		Me.groupBox2.SuspendLayout
		Me.groupBox3.SuspendLayout
		Me.groupBox4.SuspendLayout
		Me.SuspendLayout
		'
		'tbFileTitles
		'
		Me.tbFileTitles.AccessibleName = ""
		Me.tbFileTitles.AllowDrop = true
		Me.tbFileTitles.Location = New System.Drawing.Point(96, 56)
		Me.tbFileTitles.Margin = New System.Windows.Forms.Padding(4)
		Me.tbFileTitles.Name = "tbFileTitles"
		Me.tbFileTitles.Size = New System.Drawing.Size(320, 23)
		Me.tbFileTitles.TabIndex = 0
		Me.tbFileTitles.TabStop = false
		AddHandler Me.tbFileTitles.TextChanged, AddressOf Me.TbFileTitlesTextChanged
		AddHandler Me.tbFileTitles.DragDrop, AddressOf Me.TextBox1DragDrop
		AddHandler Me.tbFileTitles.DragEnter, AddressOf Me.TextBox1DragEnter
		AddHandler Me.tbFileTitles.DoubleClick, AddressOf Me.TextBox1DoubleClick
		'
		'tbFileTimes
		'
		Me.tbFileTimes.AccessibleName = ""
		Me.tbFileTimes.AllowDrop = true
		Me.tbFileTimes.Location = New System.Drawing.Point(96, 32)
		Me.tbFileTimes.Margin = New System.Windows.Forms.Padding(4)
		Me.tbFileTimes.Name = "tbFileTimes"
		Me.tbFileTimes.Size = New System.Drawing.Size(320, 23)
		Me.tbFileTimes.TabIndex = 1
		Me.tbFileTimes.TabStop = false
		AddHandler Me.tbFileTimes.TextChanged, AddressOf Me.TbFileTimesTextChanged
		AddHandler Me.tbFileTimes.DragDrop, AddressOf Me.TextBox2DragDrop
		AddHandler Me.tbFileTimes.DragEnter, AddressOf Me.TextBox2DragEnter
		AddHandler Me.tbFileTimes.DoubleClick, AddressOf Me.TextBox2DoubleClick
		'
		'tbFileOutput
		'
		Me.tbFileOutput.AccessibleName = ""
		Me.tbFileOutput.AllowDrop = true
		Me.tbFileOutput.Location = New System.Drawing.Point(96, 80)
		Me.tbFileOutput.Margin = New System.Windows.Forms.Padding(4)
		Me.tbFileOutput.Name = "tbFileOutput"
		Me.tbFileOutput.Size = New System.Drawing.Size(320, 23)
		Me.tbFileOutput.TabIndex = 2
		Me.tbFileOutput.TabStop = false
		AddHandler Me.tbFileOutput.DragDrop, AddressOf Me.TextBox3DragDrop
		AddHandler Me.tbFileOutput.DragEnter, AddressOf Me.TextBox3DragEnter
		AddHandler Me.tbFileOutput.DoubleClick, AddressOf Me.TextBox3DoubleClick
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(8, 60)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(88, 18)
		Me.label1.TabIndex = 3
		Me.label1.Text = "Titles File:"
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(8, 35)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(88, 18)
		Me.label2.TabIndex = 4
		Me.label2.Text = "Times File:"
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(8, 84)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(88, 18)
		Me.label3.TabIndex = 5
		Me.label3.Text = "Output File:"
		'
		'cbAddChapterNumbers
		'
		Me.cbAddChapterNumbers.Location = New System.Drawing.Point(8, 24)
		Me.cbAddChapterNumbers.Name = "cbAddChapterNumbers"
		Me.cbAddChapterNumbers.Size = New System.Drawing.Size(168, 24)
		Me.cbAddChapterNumbers.TabIndex = 9
		Me.cbAddChapterNumbers.TabStop = false
		Me.cbAddChapterNumbers.Text = "Add Chapter Numbers"
		Me.cbAddChapterNumbers.UseVisualStyleBackColor = true
		'
		'tbScaleFrom
		'
		Me.tbScaleFrom.BackColor = System.Drawing.SystemColors.Window
		Me.tbScaleFrom.Location = New System.Drawing.Point(176, 120)
		Me.tbScaleFrom.MaxLength = 20
		Me.tbScaleFrom.Name = "tbScaleFrom"
		Me.tbScaleFrom.ReadOnly = true
		Me.tbScaleFrom.Size = New System.Drawing.Size(104, 23)
		Me.tbScaleFrom.TabIndex = 11
		Me.tbScaleFrom.TabStop = false
		Me.tbScaleFrom.Text = "00:00:00.00000"
		Me.tbScaleFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'bReset
		'
		Me.bReset.Location = New System.Drawing.Point(8, 224)
		Me.bReset.Name = "bReset"
		Me.bReset.Size = New System.Drawing.Size(80, 31)
		Me.bReset.TabIndex = 18
		Me.bReset.TabStop = false
		Me.bReset.Text = "Reset"
		Me.bReset.UseVisualStyleBackColor = true
		AddHandler Me.bReset.Click, AddressOf Me.BResetClick
		'
		'bOutput
		'
		Me.bOutput.Location = New System.Drawing.Point(104, 224)
		Me.bOutput.Name = "bOutput"
		Me.bOutput.Size = New System.Drawing.Size(80, 31)
		Me.bOutput.TabIndex = 19
		Me.bOutput.TabStop = false
		Me.bOutput.Text = "Output"
		Me.bOutput.UseVisualStyleBackColor = true
		AddHandler Me.bOutput.Click, AddressOf Me.BOutputClick
		'
		'openFileDialog1
		'
		Me.openFileDialog1.FileName = "openFileDialog1"
		'
		'tbOffset
		'
		Me.tbOffset.Location = New System.Drawing.Point(152, 96)
		Me.tbOffset.MaxLength = 20
		Me.tbOffset.Name = "tbOffset"
		Me.tbOffset.Size = New System.Drawing.Size(48, 23)
		Me.tbOffset.TabIndex = 23
		Me.tbOffset.TabStop = false
		Me.tbOffset.Text = "0.0"
		Me.tbOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'bTitlesFileDialog
		'
		Me.bTitlesFileDialog.Location = New System.Drawing.Point(424, 56)
		Me.bTitlesFileDialog.Name = "bTitlesFileDialog"
		Me.bTitlesFileDialog.Size = New System.Drawing.Size(24, 23)
		Me.bTitlesFileDialog.TabIndex = 25
		Me.bTitlesFileDialog.TabStop = false
		Me.bTitlesFileDialog.Text = "..."
		Me.bTitlesFileDialog.UseVisualStyleBackColor = true
		AddHandler Me.bTitlesFileDialog.Click, AddressOf Me.Button3Click
		'
		'bTimesFileDialog
		'
		Me.bTimesFileDialog.Location = New System.Drawing.Point(424, 32)
		Me.bTimesFileDialog.Name = "bTimesFileDialog"
		Me.bTimesFileDialog.Size = New System.Drawing.Size(24, 23)
		Me.bTimesFileDialog.TabIndex = 26
		Me.bTimesFileDialog.TabStop = false
		Me.bTimesFileDialog.Text = "..."
		Me.bTimesFileDialog.UseVisualStyleBackColor = true
		AddHandler Me.bTimesFileDialog.Click, AddressOf Me.Button4Click
		'
		'bOutputFileDialog
		'
		Me.bOutputFileDialog.Location = New System.Drawing.Point(424, 80)
		Me.bOutputFileDialog.Name = "bOutputFileDialog"
		Me.bOutputFileDialog.Size = New System.Drawing.Size(24, 23)
		Me.bOutputFileDialog.TabIndex = 27
		Me.bOutputFileDialog.TabStop = false
		Me.bOutputFileDialog.Text = "..."
		Me.bOutputFileDialog.UseVisualStyleBackColor = true
		AddHandler Me.bOutputFileDialog.Click, AddressOf Me.Button5Click
		'
		'menuStrip1
		'
		Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem1, Me.editToolStripMenuItem1, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
		Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.menuStrip1.Name = "menuStrip1"
		Me.menuStrip1.Size = New System.Drawing.Size(865, 24)
		Me.menuStrip1.TabIndex = 28
		Me.menuStrip1.Text = "menuStrip1"
		'
		'fileToolStripMenuItem1
		'
		Me.fileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator1, Me.printToolStripMenuItem, Me.printPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem1})
		Me.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1"
		Me.fileToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
		Me.fileToolStripMenuItem1.Text = "&File"
		'
		'newToolStripMenuItem
		'
		Me.newToolStripMenuItem.Image = CType(resources.GetObject("newToolStripMenuItem.Image"),System.Drawing.Image)
		Me.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
		Me.newToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N),System.Windows.Forms.Keys)
		Me.newToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.newToolStripMenuItem.Text = "&New"
		AddHandler Me.newToolStripMenuItem.Click, AddressOf Me.NewToolStripMenuItemClick
		'
		'openToolStripMenuItem
		'
		Me.openToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.timesToolStripMenuItem, Me.titlesToolStripMenuItem})
		Me.openToolStripMenuItem.Image = CType(resources.GetObject("openToolStripMenuItem.Image"),System.Drawing.Image)
		Me.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
		Me.openToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O),System.Windows.Forms.Keys)
		Me.openToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.openToolStripMenuItem.Text = "&Open"
		'
		'timesToolStripMenuItem
		'
		Me.timesToolStripMenuItem.Name = "timesToolStripMenuItem"
		Me.timesToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
		Me.timesToolStripMenuItem.Text = "Times"
		AddHandler Me.timesToolStripMenuItem.Click, AddressOf Me.TimesToolStripMenuItemClick
		'
		'titlesToolStripMenuItem
		'
		Me.titlesToolStripMenuItem.Name = "titlesToolStripMenuItem"
		Me.titlesToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
		Me.titlesToolStripMenuItem.Text = "Titles"
		AddHandler Me.titlesToolStripMenuItem.Click, AddressOf Me.TitlesToolStripMenuItemClick
		'
		'toolStripSeparator
		'
		Me.toolStripSeparator.Name = "toolStripSeparator"
		Me.toolStripSeparator.Size = New System.Drawing.Size(143, 6)
		'
		'saveToolStripMenuItem
		'
		Me.saveToolStripMenuItem.Image = CType(resources.GetObject("saveToolStripMenuItem.Image"),System.Drawing.Image)
		Me.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
		Me.saveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S),System.Windows.Forms.Keys)
		Me.saveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.saveToolStripMenuItem.Text = "&Save"
		AddHandler Me.saveToolStripMenuItem.Click, AddressOf Me.SaveToolStripMenuItemClick
		'
		'saveAsToolStripMenuItem
		'
		Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
		Me.saveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.saveAsToolStripMenuItem.Text = "Save &As"
		AddHandler Me.saveAsToolStripMenuItem.Click, AddressOf Me.SaveAsToolStripMenuItemClick
		'
		'toolStripSeparator1
		'
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		Me.toolStripSeparator1.Size = New System.Drawing.Size(143, 6)
		'
		'printToolStripMenuItem
		'
		Me.printToolStripMenuItem.Enabled = false
		Me.printToolStripMenuItem.Image = CType(resources.GetObject("printToolStripMenuItem.Image"),System.Drawing.Image)
		Me.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
		Me.printToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P),System.Windows.Forms.Keys)
		Me.printToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.printToolStripMenuItem.Text = "&Print"
		Me.printToolStripMenuItem.Visible = false
		'
		'printPreviewToolStripMenuItem
		'
		Me.printPreviewToolStripMenuItem.Enabled = false
		Me.printPreviewToolStripMenuItem.Image = CType(resources.GetObject("printPreviewToolStripMenuItem.Image"),System.Drawing.Image)
		Me.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem"
		Me.printPreviewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.printPreviewToolStripMenuItem.Text = "Print Pre&view"
		Me.printPreviewToolStripMenuItem.Visible = false
		'
		'toolStripSeparator2
		'
		Me.toolStripSeparator2.Name = "toolStripSeparator2"
		Me.toolStripSeparator2.Size = New System.Drawing.Size(143, 6)
		Me.toolStripSeparator2.Visible = false
		'
		'exitToolStripMenuItem1
		'
		Me.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1"
		Me.exitToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
		Me.exitToolStripMenuItem1.Text = "E&xit"
		AddHandler Me.exitToolStripMenuItem1.Click, AddressOf Me.ExitToolStripMenuItem1Click
		'
		'editToolStripMenuItem1
		'
		Me.editToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripSeparator3, Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.toolStripSeparator4, Me.selectAllToolStripMenuItem})
		Me.editToolStripMenuItem1.Name = "editToolStripMenuItem1"
		Me.editToolStripMenuItem1.Size = New System.Drawing.Size(39, 20)
		Me.editToolStripMenuItem1.Text = "&Edit"
		Me.editToolStripMenuItem1.Visible = false
		'
		'undoToolStripMenuItem
		'
		Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
		Me.undoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z),System.Windows.Forms.Keys)
		Me.undoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
		Me.undoToolStripMenuItem.Text = "&Undo"
		'
		'redoToolStripMenuItem
		'
		Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
		Me.redoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y),System.Windows.Forms.Keys)
		Me.redoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
		Me.redoToolStripMenuItem.Text = "&Redo"
		'
		'toolStripSeparator3
		'
		Me.toolStripSeparator3.Name = "toolStripSeparator3"
		Me.toolStripSeparator3.Size = New System.Drawing.Size(141, 6)
		'
		'cutToolStripMenuItem
		'
		Me.cutToolStripMenuItem.Image = CType(resources.GetObject("cutToolStripMenuItem.Image"),System.Drawing.Image)
		Me.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
		Me.cutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X),System.Windows.Forms.Keys)
		Me.cutToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
		Me.cutToolStripMenuItem.Text = "Cu&t"
		'
		'copyToolStripMenuItem
		'
		Me.copyToolStripMenuItem.Image = CType(resources.GetObject("copyToolStripMenuItem.Image"),System.Drawing.Image)
		Me.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
		Me.copyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C),System.Windows.Forms.Keys)
		Me.copyToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
		Me.copyToolStripMenuItem.Text = "&Copy"
		'
		'pasteToolStripMenuItem
		'
		Me.pasteToolStripMenuItem.Image = CType(resources.GetObject("pasteToolStripMenuItem.Image"),System.Drawing.Image)
		Me.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
		Me.pasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V),System.Windows.Forms.Keys)
		Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
		Me.pasteToolStripMenuItem.Text = "&Paste"
		'
		'toolStripSeparator4
		'
		Me.toolStripSeparator4.Name = "toolStripSeparator4"
		Me.toolStripSeparator4.Size = New System.Drawing.Size(141, 6)
		'
		'selectAllToolStripMenuItem
		'
		Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
		Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
		Me.selectAllToolStripMenuItem.Text = "Select &All"
		'
		'toolsToolStripMenuItem
		'
		Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.wordsListToolStripMenuItem, Me.settingsToolStripMenuItem})
		Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
		Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
		Me.toolsToolStripMenuItem.Text = "&Tools"
		'
		'wordsListToolStripMenuItem
		'
		Me.wordsListToolStripMenuItem.Name = "wordsListToolStripMenuItem"
		Me.wordsListToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.wordsListToolStripMenuItem.Text = "&Words List"
		AddHandler Me.wordsListToolStripMenuItem.Click, AddressOf Me.WordsListToolStripMenuItemClick
		'
		'settingsToolStripMenuItem
		'
		Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
		Me.settingsToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
		Me.settingsToolStripMenuItem.Text = "&Settings"
		AddHandler Me.settingsToolStripMenuItem.Click, AddressOf Me.SettingsToolStripMenuItemClick
		'
		'helpToolStripMenuItem
		'
		Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.contentsToolStripMenuItem, Me.indexToolStripMenuItem, Me.searchToolStripMenuItem, Me.toolStripSeparator5, Me.aboutToolStripMenuItem})
		Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
		Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
		Me.helpToolStripMenuItem.Text = "&Help"
		'
		'contentsToolStripMenuItem
		'
		Me.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem"
		Me.contentsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
		Me.contentsToolStripMenuItem.Text = "&Contents"
		AddHandler Me.contentsToolStripMenuItem.Click, AddressOf Me.ContentsToolStripMenuItemClick
		'
		'indexToolStripMenuItem
		'
		Me.indexToolStripMenuItem.Name = "indexToolStripMenuItem"
		Me.indexToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
		Me.indexToolStripMenuItem.Text = "&Index"
		AddHandler Me.indexToolStripMenuItem.Click, AddressOf Me.IndexToolStripMenuItemClick
		'
		'searchToolStripMenuItem
		'
		Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
		Me.searchToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
		Me.searchToolStripMenuItem.Text = "&Search"
		AddHandler Me.searchToolStripMenuItem.Click, AddressOf Me.SearchToolStripMenuItemClick
		'
		'toolStripSeparator5
		'
		Me.toolStripSeparator5.Name = "toolStripSeparator5"
		Me.toolStripSeparator5.Size = New System.Drawing.Size(119, 6)
		'
		'aboutToolStripMenuItem
		'
		Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
		Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
		Me.aboutToolStripMenuItem.Text = "&About..."
		AddHandler Me.aboutToolStripMenuItem.Click, AddressOf Me.AboutToolStripMenuItemClick
		'
		'tbFrameRate
		'
		Me.tbFrameRate.Location = New System.Drawing.Point(104, 72)
		Me.tbFrameRate.MaxLength = 20
		Me.tbFrameRate.Name = "tbFrameRate"
		Me.tbFrameRate.Size = New System.Drawing.Size(72, 23)
		Me.tbFrameRate.TabIndex = 29
		Me.tbFrameRate.TabStop = false
		Me.tbFrameRate.Text = "23.976"
		Me.tbFrameRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'bLoadTitles
		'
		Me.bLoadTitles.Location = New System.Drawing.Point(504, 56)
		Me.bLoadTitles.Name = "bLoadTitles"
		Me.bLoadTitles.Size = New System.Drawing.Size(56, 23)
		Me.bLoadTitles.TabIndex = 31
		Me.bLoadTitles.TabStop = false
		Me.bLoadTitles.Text = "Load"
		Me.bLoadTitles.UseVisualStyleBackColor = true
		AddHandler Me.bLoadTitles.Click, AddressOf Me.Button6Click
		'
		'bLoadTimes
		'
		Me.bLoadTimes.Location = New System.Drawing.Point(504, 32)
		Me.bLoadTimes.Name = "bLoadTimes"
		Me.bLoadTimes.Size = New System.Drawing.Size(56, 23)
		Me.bLoadTimes.TabIndex = 32
		Me.bLoadTimes.TabStop = false
		Me.bLoadTimes.Text = "Load"
		Me.bLoadTimes.UseVisualStyleBackColor = true
		AddHandler Me.bLoadTimes.Click, AddressOf Me.Button7Click
		'
		'bOutputType
		'
		Me.bOutputType.Location = New System.Drawing.Point(504, 80)
		Me.bOutputType.Name = "bOutputType"
		Me.bOutputType.Size = New System.Drawing.Size(56, 23)
		Me.bOutputType.TabIndex = 33
		Me.bOutputType.TabStop = false
		Me.bOutputType.Text = "Type"
		Me.bOutputType.UseVisualStyleBackColor = true
		AddHandler Me.bOutputType.Click, AddressOf Me.Button8Click
		'
		'tbTimeType
		'
		Me.tbTimeType.Location = New System.Drawing.Point(456, 32)
		Me.tbTimeType.MaxLength = 20
		Me.tbTimeType.Name = "tbTimeType"
		Me.tbTimeType.ReadOnly = true
		Me.tbTimeType.Size = New System.Drawing.Size(40, 23)
		Me.tbTimeType.TabIndex = 34
		Me.tbTimeType.TabStop = false
		Me.tbTimeType.Text = "---"
		Me.tbTimeType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'tbTitleType
		'
		Me.tbTitleType.Location = New System.Drawing.Point(456, 56)
		Me.tbTitleType.MaxLength = 20
		Me.tbTitleType.Name = "tbTitleType"
		Me.tbTitleType.ReadOnly = true
		Me.tbTitleType.Size = New System.Drawing.Size(40, 23)
		Me.tbTitleType.TabIndex = 35
		Me.tbTitleType.TabStop = false
		Me.tbTitleType.Text = "---"
		Me.tbTitleType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'tbOutputType
		'
		Me.tbOutputType.Location = New System.Drawing.Point(456, 80)
		Me.tbOutputType.MaxLength = 20
		Me.tbOutputType.Name = "tbOutputType"
		Me.tbOutputType.ReadOnly = true
		Me.tbOutputType.Size = New System.Drawing.Size(40, 23)
		Me.tbOutputType.TabIndex = 36
		Me.tbOutputType.TabStop = false
		Me.tbOutputType.Text = "---"
		Me.tbOutputType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'maskedTextBox1
		'
		Me.maskedTextBox1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.maskedTextBox1.Location = New System.Drawing.Point(8, 24)
		Me.maskedTextBox1.Mask = "00:00:00.00000"
		Me.maskedTextBox1.Name = "maskedTextBox1"
		Me.maskedTextBox1.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.maskedTextBox1.RejectInputOnFirstFailure = true
		Me.maskedTextBox1.ResetOnPrompt = false
		Me.maskedTextBox1.ResetOnSpace = false
		Me.maskedTextBox1.Size = New System.Drawing.Size(120, 23)
		Me.maskedTextBox1.TabIndex = 39
		Me.maskedTextBox1.TabStop = false
		Me.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.maskedTextBox1.Leave, AddressOf Me.MaskedTextBox1Leave
		'
		'dataGridView1
		'
		Me.dataGridView1.AllowDrop = true
		Me.dataGridView1.AllowUserToAddRows = false
		Me.dataGridView1.AllowUserToDeleteRows = false
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
		Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgNumber, Me.dgTime, Me.dgTitle})
		Me.dataGridView1.Location = New System.Drawing.Point(8, 112)
		Me.dataGridView1.MultiSelect = false
		Me.dataGridView1.Name = "dataGridView1"
		Me.dataGridView1.Size = New System.Drawing.Size(552, 440)
		Me.dataGridView1.TabIndex = 41
		Me.dataGridView1.TabStop = false
		AddHandler Me.dataGridView1.CellValueChanged, AddressOf Me.DataGridView1CellValueChanged
		AddHandler Me.dataGridView1.SelectionChanged, AddressOf Me.DataGridView1SelectionChanged
		AddHandler Me.dataGridView1.DragDrop, AddressOf Me.DataGridView1DragDrop
		AddHandler Me.dataGridView1.DragOver, AddressOf Me.DataGridView1DragOver
		AddHandler Me.dataGridView1.MouseDown, AddressOf Me.DataGridView1MouseDown
		AddHandler Me.dataGridView1.MouseMove, AddressOf Me.DataGridView1MouseMove
		'
		'dgNumber
		'
		Me.dgNumber.DataPropertyName = "dgNumber"
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		Me.dgNumber.DefaultCellStyle = dataGridViewCellStyle2
		Me.dgNumber.HeaderText = "No."
		Me.dgNumber.Name = "dgNumber"
		Me.dgNumber.ReadOnly = true
		Me.dgNumber.Width = 50
		'
		'dgTime
		'
		Me.dgTime.DataPropertyName = "dgTime"
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		Me.dgTime.DefaultCellStyle = dataGridViewCellStyle3
		Me.dgTime.HeaderText = "Time"
		Me.dgTime.Name = "dgTime"
		Me.dgTime.ReadOnly = true
		Me.dgTime.Width = 150
		'
		'dgTitle
		'
		Me.dgTitle.DataPropertyName = "dgTitle"
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		Me.dgTitle.DefaultCellStyle = dataGridViewCellStyle4
		Me.dgTitle.HeaderText = "Title"
		Me.dgTitle.Name = "dgTitle"
		Me.dgTitle.Width = 290
		'
		'bTimeAdd
		'
		Me.bTimeAdd.Location = New System.Drawing.Point(8, 48)
		Me.bTimeAdd.Name = "bTimeAdd"
		Me.bTimeAdd.Size = New System.Drawing.Size(80, 23)
		Me.bTimeAdd.TabIndex = 42
		Me.bTimeAdd.TabStop = false
		Me.bTimeAdd.Text = "Add"
		Me.bTimeAdd.UseVisualStyleBackColor = true
		AddHandler Me.bTimeAdd.Click, AddressOf Me.BTimeAddClick
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(8, 48)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(80, 24)
		Me.label7.TabIndex = 43
		Me.label7.Text = "Language:"
		Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bTimeUpdate
		'
		Me.bTimeUpdate.Location = New System.Drawing.Point(104, 48)
		Me.bTimeUpdate.Name = "bTimeUpdate"
		Me.bTimeUpdate.Size = New System.Drawing.Size(80, 23)
		Me.bTimeUpdate.TabIndex = 44
		Me.bTimeUpdate.TabStop = false
		Me.bTimeUpdate.Text = "Update"
		Me.bTimeUpdate.UseVisualStyleBackColor = true
		AddHandler Me.bTimeUpdate.Click, AddressOf Me.BTimeUpdateClick
		'
		'tbChapterTitle
		'
		Me.tbChapterTitle.AccessibleName = ""
		Me.tbChapterTitle.AllowDrop = true
		Me.tbChapterTitle.Location = New System.Drawing.Point(8, 24)
		Me.tbChapterTitle.Margin = New System.Windows.Forms.Padding(4)
		Me.tbChapterTitle.Name = "tbChapterTitle"
		Me.tbChapterTitle.Size = New System.Drawing.Size(256, 23)
		Me.tbChapterTitle.TabIndex = 46
		Me.tbChapterTitle.TabStop = false
		'
		'bTimeRemove
		'
		Me.bTimeRemove.Location = New System.Drawing.Point(200, 48)
		Me.bTimeRemove.Name = "bTimeRemove"
		Me.bTimeRemove.Size = New System.Drawing.Size(80, 23)
		Me.bTimeRemove.TabIndex = 48
		Me.bTimeRemove.TabStop = false
		Me.bTimeRemove.Text = "Remove"
		Me.bTimeRemove.UseVisualStyleBackColor = true
		AddHandler Me.bTimeRemove.Click, AddressOf Me.BTimeRemoveClick
		'
		'groupBox1
		'
		Me.groupBox1.Controls.Add(Me.maskedTextBox1)
		Me.groupBox1.Controls.Add(Me.bTimeRemove)
		Me.groupBox1.Controls.Add(Me.bTimeAdd)
		Me.groupBox1.Controls.Add(Me.bTimeUpdate)
		Me.groupBox1.Location = New System.Drawing.Point(568, 120)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(288, 80)
		Me.groupBox1.TabIndex = 49
		Me.groupBox1.TabStop = false
		Me.groupBox1.Text = "Chapter Time"
		'
		'groupBox2
		'
		Me.groupBox2.Controls.Add(Me.bTitleRemove)
		Me.groupBox2.Controls.Add(Me.bTitleUpdate)
		Me.groupBox2.Controls.Add(Me.bTitleInsert)
		Me.groupBox2.Controls.Add(Me.tbChapterTitle)
		Me.groupBox2.Location = New System.Drawing.Point(568, 208)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(288, 80)
		Me.groupBox2.TabIndex = 50
		Me.groupBox2.TabStop = false
		Me.groupBox2.Text = "Chapter Title"
		'
		'bTitleRemove
		'
		Me.bTitleRemove.Location = New System.Drawing.Point(200, 48)
		Me.bTitleRemove.Name = "bTitleRemove"
		Me.bTitleRemove.Size = New System.Drawing.Size(80, 23)
		Me.bTitleRemove.TabIndex = 51
		Me.bTitleRemove.TabStop = false
		Me.bTitleRemove.Text = "Remove"
		Me.bTitleRemove.UseVisualStyleBackColor = true
		AddHandler Me.bTitleRemove.Click, AddressOf Me.BTitleRemoveClick
		'
		'bTitleUpdate
		'
		Me.bTitleUpdate.Location = New System.Drawing.Point(104, 48)
		Me.bTitleUpdate.Name = "bTitleUpdate"
		Me.bTitleUpdate.Size = New System.Drawing.Size(80, 23)
		Me.bTitleUpdate.TabIndex = 50
		Me.bTitleUpdate.TabStop = false
		Me.bTitleUpdate.Text = "Update"
		Me.bTitleUpdate.UseVisualStyleBackColor = true
		AddHandler Me.bTitleUpdate.Click, AddressOf Me.BTitleUpdateClick
		'
		'bTitleInsert
		'
		Me.bTitleInsert.Location = New System.Drawing.Point(8, 48)
		Me.bTitleInsert.Name = "bTitleInsert"
		Me.bTitleInsert.Size = New System.Drawing.Size(80, 23)
		Me.bTitleInsert.TabIndex = 47
		Me.bTitleInsert.TabStop = false
		Me.bTitleInsert.Text = "Insert"
		Me.bTitleInsert.UseVisualStyleBackColor = true
		AddHandler Me.bTitleInsert.Click, AddressOf Me.BTitleInsertClick
		'
		'groupBox3
		'
		Me.groupBox3.Controls.Add(Me.cbLanguage)
		Me.groupBox3.Controls.Add(Me.cbAddChapterNumbers)
		Me.groupBox3.Controls.Add(Me.label7)
		Me.groupBox3.Location = New System.Drawing.Point(568, 32)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(288, 80)
		Me.groupBox3.TabIndex = 51
		Me.groupBox3.TabStop = false
		Me.groupBox3.Text = "Output Options"
		'
		'cbLanguage
		'
		Me.cbLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cbLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbLanguage.FormattingEnabled = true
		Me.cbLanguage.Location = New System.Drawing.Point(88, 48)
		Me.cbLanguage.Name = "cbLanguage"
		Me.cbLanguage.Size = New System.Drawing.Size(192, 24)
		Me.cbLanguage.TabIndex = 52
		Me.cbLanguage.TabStop = false
		'
		'groupBox4
		'
		Me.groupBox4.Controls.Add(Me.bExit)
		Me.groupBox4.Controls.Add(Me.maskedTextBox4)
		Me.groupBox4.Controls.Add(Me.label4)
		Me.groupBox4.Controls.Add(Me.maskedTextBox3)
		Me.groupBox4.Controls.Add(Me.label5)
		Me.groupBox4.Controls.Add(Me.bAddIntervals)
		Me.groupBox4.Controls.Add(Me.tbScaleFrom)
		Me.groupBox4.Controls.Add(Me.label16)
		Me.groupBox4.Controls.Add(Me.maskedTextBox2)
		Me.groupBox4.Controls.Add(Me.label15)
		Me.groupBox4.Controls.Add(Me.label14)
		Me.groupBox4.Controls.Add(Me.label13)
		Me.groupBox4.Controls.Add(Me.bScaleTimes)
		Me.groupBox4.Controls.Add(Me.bShiftTimes)
		Me.groupBox4.Controls.Add(Me.label12)
		Me.groupBox4.Controls.Add(Me.label11)
		Me.groupBox4.Controls.Add(Me.bFrameRateTimes)
		Me.groupBox4.Controls.Add(Me.bFixTitleCase)
		Me.groupBox4.Controls.Add(Me.label10)
		Me.groupBox4.Controls.Add(Me.bDeleteLine)
		Me.groupBox4.Controls.Add(Me.label9)
		Me.groupBox4.Controls.Add(Me.bReset)
		Me.groupBox4.Controls.Add(Me.bOutput)
		Me.groupBox4.Controls.Add(Me.tbFrameRate)
		Me.groupBox4.Controls.Add(Me.tbOffset)
		Me.groupBox4.Location = New System.Drawing.Point(568, 296)
		Me.groupBox4.Name = "groupBox4"
		Me.groupBox4.Size = New System.Drawing.Size(288, 264)
		Me.groupBox4.TabIndex = 52
		Me.groupBox4.TabStop = false
		Me.groupBox4.Text = "Chapter List"
		'
		'bExit
		'
		Me.bExit.Location = New System.Drawing.Point(200, 224)
		Me.bExit.Name = "bExit"
		Me.bExit.Size = New System.Drawing.Size(80, 31)
		Me.bExit.TabIndex = 53
		Me.bExit.Text = "Exit"
		Me.bExit.UseVisualStyleBackColor = true
		AddHandler Me.bExit.Click, AddressOf Me.BExitClick
		'
		'maskedTextBox4
		'
		Me.maskedTextBox4.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.maskedTextBox4.Location = New System.Drawing.Point(176, 192)
		Me.maskedTextBox4.Mask = "00:00:00.00000"
		Me.maskedTextBox4.Name = "maskedTextBox4"
		Me.maskedTextBox4.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.maskedTextBox4.RejectInputOnFirstFailure = true
		Me.maskedTextBox4.ResetOnPrompt = false
		Me.maskedTextBox4.ResetOnSpace = false
		Me.maskedTextBox4.Size = New System.Drawing.Size(104, 23)
		Me.maskedTextBox4.TabIndex = 71
		Me.maskedTextBox4.TabStop = false
		Me.maskedTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.maskedTextBox4.Leave, AddressOf Me.MaskedTextBox4Leave
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(88, 192)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(88, 24)
		Me.label4.TabIndex = 71
		Me.label4.Text = "Up to"
		Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'maskedTextBox3
		'
		Me.maskedTextBox3.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.maskedTextBox3.Location = New System.Drawing.Point(176, 168)
		Me.maskedTextBox3.Mask = "00:00:00.00000"
		Me.maskedTextBox3.Name = "maskedTextBox3"
		Me.maskedTextBox3.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.maskedTextBox3.RejectInputOnFirstFailure = true
		Me.maskedTextBox3.ResetOnPrompt = false
		Me.maskedTextBox3.ResetOnSpace = false
		Me.maskedTextBox3.Size = New System.Drawing.Size(104, 23)
		Me.maskedTextBox3.TabIndex = 70
		Me.maskedTextBox3.TabStop = false
		Me.maskedTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.maskedTextBox3.Leave, AddressOf Me.MaskedTextBox3Leave
		'
		'label5
		'
		Me.label5.Location = New System.Drawing.Point(56, 168)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(120, 24)
		Me.label5.TabIndex = 69
		Me.label5.Text = "Add Times Every"
		Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bAddIntervals
		'
		Me.bAddIntervals.Location = New System.Drawing.Point(8, 168)
		Me.bAddIntervals.Name = "bAddIntervals"
		Me.bAddIntervals.Size = New System.Drawing.Size(40, 23)
		Me.bAddIntervals.TabIndex = 68
		Me.bAddIntervals.TabStop = false
		Me.bAddIntervals.Text = "Go"
		Me.bAddIntervals.UseVisualStyleBackColor = true
		AddHandler Me.bAddIntervals.Click, AddressOf Me.BAddIntervalsClick
		'
		'label16
		'
		Me.label16.Location = New System.Drawing.Point(88, 144)
		Me.label16.Name = "label16"
		Me.label16.Size = New System.Drawing.Size(88, 24)
		Me.label16.TabIndex = 66
		Me.label16.Text = "Becomes"
		Me.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'maskedTextBox2
		'
		Me.maskedTextBox2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.maskedTextBox2.Location = New System.Drawing.Point(176, 144)
		Me.maskedTextBox2.Mask = "00:00:00.00000"
		Me.maskedTextBox2.Name = "maskedTextBox2"
		Me.maskedTextBox2.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.maskedTextBox2.RejectInputOnFirstFailure = true
		Me.maskedTextBox2.ResetOnPrompt = false
		Me.maskedTextBox2.ResetOnSpace = false
		Me.maskedTextBox2.Size = New System.Drawing.Size(104, 23)
		Me.maskedTextBox2.TabIndex = 65
		Me.maskedTextBox2.TabStop = false
		Me.maskedTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.maskedTextBox2.Leave, AddressOf Me.MaskedTextBox2Leave
		'
		'label15
		'
		Me.label15.Location = New System.Drawing.Point(56, 120)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(120, 24)
		Me.label15.TabIndex = 64
		Me.label15.Text = "Scale Times so"
		Me.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label14
		'
		Me.label14.Location = New System.Drawing.Point(200, 96)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(64, 24)
		Me.label14.TabIndex = 63
		Me.label14.Text = "seconds"
		Me.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label13
		'
		Me.label13.Location = New System.Drawing.Point(56, 96)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(96, 24)
		Me.label13.TabIndex = 62
		Me.label13.Text = "Shift Times by"
		Me.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bScaleTimes
		'
		Me.bScaleTimes.Location = New System.Drawing.Point(8, 120)
		Me.bScaleTimes.Name = "bScaleTimes"
		Me.bScaleTimes.Size = New System.Drawing.Size(40, 23)
		Me.bScaleTimes.TabIndex = 61
		Me.bScaleTimes.TabStop = false
		Me.bScaleTimes.Text = "Go"
		Me.bScaleTimes.UseVisualStyleBackColor = true
		AddHandler Me.bScaleTimes.Click, AddressOf Me.BScaleTimesClick
		'
		'bShiftTimes
		'
		Me.bShiftTimes.Location = New System.Drawing.Point(8, 96)
		Me.bShiftTimes.Name = "bShiftTimes"
		Me.bShiftTimes.Size = New System.Drawing.Size(40, 23)
		Me.bShiftTimes.TabIndex = 60
		Me.bShiftTimes.TabStop = false
		Me.bShiftTimes.Text = "Go"
		Me.bShiftTimes.UseVisualStyleBackColor = true
		AddHandler Me.bShiftTimes.Click, AddressOf Me.BShiftTimesClick
		'
		'label12
		'
		Me.label12.Location = New System.Drawing.Point(176, 72)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(56, 24)
		Me.label12.TabIndex = 59
		Me.label12.Text = "fps FR"
		Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(56, 72)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(48, 24)
		Me.label11.TabIndex = 58
		Me.label11.Text = "Match"
		Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bFrameRateTimes
		'
		Me.bFrameRateTimes.Location = New System.Drawing.Point(8, 72)
		Me.bFrameRateTimes.Name = "bFrameRateTimes"
		Me.bFrameRateTimes.Size = New System.Drawing.Size(40, 23)
		Me.bFrameRateTimes.TabIndex = 57
		Me.bFrameRateTimes.TabStop = false
		Me.bFrameRateTimes.Text = "Go"
		Me.bFrameRateTimes.UseVisualStyleBackColor = true
		AddHandler Me.bFrameRateTimes.Click, AddressOf Me.BFrameRateTimesClick
		'
		'bFixTitleCase
		'
		Me.bFixTitleCase.Location = New System.Drawing.Point(8, 48)
		Me.bFixTitleCase.Name = "bFixTitleCase"
		Me.bFixTitleCase.Size = New System.Drawing.Size(40, 23)
		Me.bFixTitleCase.TabIndex = 56
		Me.bFixTitleCase.TabStop = false
		Me.bFixTitleCase.Text = "Go"
		Me.bFixTitleCase.UseVisualStyleBackColor = true
		AddHandler Me.bFixTitleCase.Click, AddressOf Me.BFixTitleCaseClick
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(56, 48)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(160, 24)
		Me.label10.TabIndex = 55
		Me.label10.Text = "Fix Case on All Titles"
		Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bDeleteLine
		'
		Me.bDeleteLine.Location = New System.Drawing.Point(8, 24)
		Me.bDeleteLine.Name = "bDeleteLine"
		Me.bDeleteLine.Size = New System.Drawing.Size(40, 23)
		Me.bDeleteLine.TabIndex = 54
		Me.bDeleteLine.TabStop = false
		Me.bDeleteLine.Text = "Go"
		Me.bDeleteLine.UseVisualStyleBackColor = true
		AddHandler Me.bDeleteLine.Click, AddressOf Me.BDeleteLineClick
		'
		'label9
		'
		Me.label9.Location = New System.Drawing.Point(56, 24)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(160, 24)
		Me.label9.TabIndex = 46
		Me.label9.Text = "Remove Selected Line"
		Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'helpProvider1
		'
		Me.helpProvider1.HelpNamespace = "ChapterMakerHelp.chm"
		'
		'MainForm
		'
		Me.AllowDrop = true
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 16!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(865, 565)
		Me.Controls.Add(Me.groupBox4)
		Me.Controls.Add(Me.groupBox3)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.dataGridView1)
		Me.Controls.Add(Me.tbOutputType)
		Me.Controls.Add(Me.tbTitleType)
		Me.Controls.Add(Me.tbTimeType)
		Me.Controls.Add(Me.bOutputType)
		Me.Controls.Add(Me.bLoadTimes)
		Me.Controls.Add(Me.bLoadTitles)
		Me.Controls.Add(Me.tbFileTitles)
		Me.Controls.Add(Me.tbFileTimes)
		Me.Controls.Add(Me.menuStrip1)
		Me.Controls.Add(Me.tbFileOutput)
		Me.Controls.Add(Me.bOutputFileDialog)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.bTimesFileDialog)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.bTitlesFileDialog)
		Me.Controls.Add(Me.label3)
		Me.Font = New System.Drawing.Font("Arial", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MainMenuStrip = Me.menuStrip1
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.MaximizeBox = false
		Me.Name = "MainForm"
		Me.Text = "ChapterMaker"
		AddHandler Load, AddressOf Me.MainFormLoad
		Me.menuStrip1.ResumeLayout(false)
		Me.menuStrip1.PerformLayout
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
		Me.groupBox1.ResumeLayout(false)
		Me.groupBox1.PerformLayout
		Me.groupBox2.ResumeLayout(false)
		Me.groupBox2.PerformLayout
		Me.groupBox3.ResumeLayout(false)
		Me.groupBox4.ResumeLayout(false)
		Me.groupBox4.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private helpProvider1 As System.Windows.Forms.HelpProvider
	Private bExit As System.Windows.Forms.Button
	Private settingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private titlesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private timesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private bReset As System.Windows.Forms.Button
	Private bOutput As System.Windows.Forms.Button
	Private bAddIntervals As System.Windows.Forms.Button
	Private label5 As System.Windows.Forms.Label
	Private maskedTextBox3 As System.Windows.Forms.MaskedTextBox
	Private label4 As System.Windows.Forms.Label
	Private maskedTextBox4 As System.Windows.Forms.MaskedTextBox
	Private bTitlesFileDialog As System.Windows.Forms.Button
	Private bTimesFileDialog As System.Windows.Forms.Button
	Private bOutputFileDialog As System.Windows.Forms.Button
	Private bLoadTimes As System.Windows.Forms.Button
	Private bLoadTitles As System.Windows.Forms.Button
	Private bOutputType As System.Windows.Forms.Button
	Private bFrameRateTimes As System.Windows.Forms.Button
	Private bScaleTimes As System.Windows.Forms.Button
	Private bShiftTimes As System.Windows.Forms.Button
	Private label11 As System.Windows.Forms.Label
	Private label12 As System.Windows.Forms.Label
	Private label13 As System.Windows.Forms.Label
	Private label14 As System.Windows.Forms.Label
	Private label15 As System.Windows.Forms.Label
	Private maskedTextBox2 As System.Windows.Forms.MaskedTextBox
	Private label16 As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private bFixTitleCase As System.Windows.Forms.Button
	Private label9 As System.Windows.Forms.Label
	Private bDeleteLine As System.Windows.Forms.Button
	Private bTitleInsert As System.Windows.Forms.Button
	Private bTitleUpdate As System.Windows.Forms.Button
	Private bTitleRemove As System.Windows.Forms.Button
	Private groupBox4 As System.Windows.Forms.GroupBox
	Private cbLanguage As System.Windows.Forms.ComboBox
	Private groupBox3 As System.Windows.Forms.GroupBox
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private bTimeAdd As System.Windows.Forms.Button
	Private bTimeRemove As System.Windows.Forms.Button
	Private tbChapterTitle As System.Windows.Forms.TextBox
	Private bTimeUpdate As System.Windows.Forms.Button
	Private label7 As System.Windows.Forms.Label
	Private dgTitle As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgTime As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgNumber As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dataGridView1 As System.Windows.Forms.DataGridView
	Private maskedTextBox1 As System.Windows.Forms.MaskedTextBox
	Private tbOutputType As System.Windows.Forms.TextBox
	Private tbTitleType As System.Windows.Forms.TextBox
	Private tbTimeType As System.Windows.Forms.TextBox
	Private wordsListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private tbFrameRate As System.Windows.Forms.TextBox
	Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
	Private searchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private indexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private contentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
	Private pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private cutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	Private redoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private undoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private editToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
	Private exitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
	Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Private printPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Private saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripSeparator As System.Windows.Forms.ToolStripSeparator
	Private openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private fileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
	Private menuStrip1 As System.Windows.Forms.MenuStrip
	Private tbOffset As System.Windows.Forms.TextBox
	Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
	Private tbScaleFrom As System.Windows.Forms.TextBox
	Private cbAddChapterNumbers As System.Windows.Forms.CheckBox
	Private label3 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private tbFileOutput As System.Windows.Forms.TextBox
	Private tbFileTimes As System.Windows.Forms.TextBox
	Private tbFileTitles As System.Windows.Forms.TextBox
End Class