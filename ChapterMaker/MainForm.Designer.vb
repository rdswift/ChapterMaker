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
	
	Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
		RemoveHandler Application.Idle, AddressOf UpdateEditButtons
		MyBase.OnFormClosing(e)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
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
		Me.outputTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.xMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.oGGMediaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.plainTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
		Me.checkForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.contentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.indexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.tbFrameRate = New System.Windows.Forms.TextBox()
		Me.bLoadTitles = New System.Windows.Forms.Button()
		Me.bLoadTimes = New System.Windows.Forms.Button()
		Me.tbTimeType = New System.Windows.Forms.TextBox()
		Me.tbTitleType = New System.Windows.Forms.TextBox()
		Me.maskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
		Me.dataGridView1 = New System.Windows.Forms.DataGridView()
		Me.dgNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.moveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.moveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.deleteLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.deleteTimeOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.deleteTitleOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
		Me.cbAddChapterTimes = New System.Windows.Forms.CheckBox()
		Me.cbLanguage = New System.Windows.Forms.ComboBox()
		Me.groupBox4 = New System.Windows.Forms.GroupBox()
		Me.bShiftTimesHelp = New System.Windows.Forms.Button()
		Me.bAddTimesHelp = New System.Windows.Forms.Button()
		Me.bScaleHelp = New System.Windows.Forms.Button()
		Me.lbFRList = New System.Windows.Forms.ListBox()
		Me.bFRDropDown = New System.Windows.Forms.Button()
		Me.label19 = New System.Windows.Forms.Label()
		Me.label18 = New System.Windows.Forms.Label()
		Me.label17 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
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
		Me.bExit = New System.Windows.Forms.Button()
		Me.helpProvider1 = New System.Windows.Forms.HelpProvider()
		Me.bClearTimes = New System.Windows.Forms.Button()
		Me.bClearTitles = New System.Windows.Forms.Button()
		Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.newToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.openToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.printToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
		Me.cutToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.copyToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.pasteToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
		Me.helpToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.cbOutputType = New System.Windows.Forms.ComboBox()
		Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.menuStrip1.SuspendLayout
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.contextMenuStrip1.SuspendLayout
		Me.groupBox1.SuspendLayout
		Me.groupBox2.SuspendLayout
		Me.groupBox3.SuspendLayout
		Me.groupBox4.SuspendLayout
		Me.toolStrip1.SuspendLayout
		Me.statusStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'tbFileTitles
		'
		Me.tbFileTitles.AccessibleName = ""
		Me.tbFileTitles.AllowDrop = true
		Me.tbFileTitles.Location = New System.Drawing.Point(96, 80)
		Me.tbFileTitles.Margin = New System.Windows.Forms.Padding(4)
		Me.tbFileTitles.Name = "tbFileTitles"
		Me.tbFileTitles.Size = New System.Drawing.Size(320, 23)
		Me.tbFileTitles.TabIndex = 8
		Me.tbFileTitles.TabStop = false
		Me.toolTip1.SetToolTip(Me.tbFileTitles, "The file to read the chapter titles.  This can be either an XLM file,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"an OGM-for"& _ 
				"mat Chapters file, or a plain text file.  The program"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"will try to automatically"& _ 
				" detect the file type."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
		AddHandler Me.tbFileTitles.TextChanged, AddressOf Me.TbFileTitlesTextChanged
		AddHandler Me.tbFileTitles.DragDrop, AddressOf Me.TextBox1DragDrop
		AddHandler Me.tbFileTitles.DragEnter, AddressOf Me.TextBox1DragEnter
		AddHandler Me.tbFileTitles.DoubleClick, AddressOf Me.TextBox1DoubleClick
		'
		'tbFileTimes
		'
		Me.tbFileTimes.AccessibleName = ""
		Me.tbFileTimes.AllowDrop = true
		Me.tbFileTimes.Location = New System.Drawing.Point(96, 56)
		Me.tbFileTimes.Margin = New System.Windows.Forms.Padding(4)
		Me.tbFileTimes.Name = "tbFileTimes"
		Me.tbFileTimes.Size = New System.Drawing.Size(320, 23)
		Me.tbFileTimes.TabIndex = 2
		Me.tbFileTimes.TabStop = false
		Me.toolTip1.SetToolTip(Me.tbFileTimes, "The file to read the chapter times.  This can be either an XLM file,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"an OGM-form"& _ 
				"at Chapters file, or a plain text file.  The program"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"will try to automatically "& _ 
				"detect the file type."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
		AddHandler Me.tbFileTimes.TextChanged, AddressOf Me.TbFileTimesTextChanged
		AddHandler Me.tbFileTimes.DragDrop, AddressOf Me.TextBox2DragDrop
		AddHandler Me.tbFileTimes.DragEnter, AddressOf Me.TextBox2DragEnter
		AddHandler Me.tbFileTimes.DoubleClick, AddressOf Me.TextBox2DoubleClick
		'
		'tbFileOutput
		'
		Me.tbFileOutput.AccessibleName = ""
		Me.tbFileOutput.AllowDrop = true
		Me.tbFileOutput.Location = New System.Drawing.Point(96, 104)
		Me.tbFileOutput.Margin = New System.Windows.Forms.Padding(4)
		Me.tbFileOutput.Name = "tbFileOutput"
		Me.tbFileOutput.Size = New System.Drawing.Size(320, 23)
		Me.tbFileOutput.TabIndex = 14
		Me.tbFileOutput.TabStop = false
		Me.toolTip1.SetToolTip(Me.tbFileOutput, "The path and name of the output file that you wish to write."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
		AddHandler Me.tbFileOutput.DragDrop, AddressOf Me.TextBox3DragDrop
		AddHandler Me.tbFileOutput.DragEnter, AddressOf Me.TextBox3DragEnter
		AddHandler Me.tbFileOutput.DoubleClick, AddressOf Me.TextBox3DoubleClick
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(8, 84)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(88, 18)
		Me.label1.TabIndex = 7
		Me.label1.Text = "Titles File:"
		Me.toolTip1.SetToolTip(Me.label1, "The file to read the chapter titles.  This can be either an XLM file,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"an OGM-for"& _ 
				"mat Chapters file, or a plain text file.  The program"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"will try to automatically"& _ 
				" detect the file type."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(8, 59)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(88, 18)
		Me.label2.TabIndex = 1
		Me.label2.Text = "Times File:"
		Me.toolTip1.SetToolTip(Me.label2, "The file to read the chapter times.  This can be either an XLM file,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"an OGM-form"& _ 
				"at Chapters file, or a plain text file.  The program"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"will try to automatically "& _ 
				"detect the file type."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(8, 108)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(88, 18)
		Me.label3.TabIndex = 13
		Me.label3.Text = "Output File:"
		Me.toolTip1.SetToolTip(Me.label3, "The path and name of the output file that you wish to write.")
		'
		'cbAddChapterNumbers
		'
		Me.cbAddChapterNumbers.Location = New System.Drawing.Point(8, 24)
		Me.cbAddChapterNumbers.Name = "cbAddChapterNumbers"
		Me.cbAddChapterNumbers.Size = New System.Drawing.Size(168, 24)
		Me.cbAddChapterNumbers.TabIndex = 0
		Me.cbAddChapterNumbers.TabStop = false
		Me.cbAddChapterNumbers.Text = "Add Chapter Numbers"
		Me.toolTip1.SetToolTip(Me.cbAddChapterNumbers, "This will include the chapter numbers in the"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"chapter names written to the output"& _ 
				" file.")
		Me.cbAddChapterNumbers.UseVisualStyleBackColor = true
		'
		'tbScaleFrom
		'
		Me.tbScaleFrom.BackColor = System.Drawing.SystemColors.Window
		Me.tbScaleFrom.Location = New System.Drawing.Point(176, 208)
		Me.tbScaleFrom.MaxLength = 20
		Me.tbScaleFrom.Name = "tbScaleFrom"
		Me.tbScaleFrom.ReadOnly = true
		Me.tbScaleFrom.Size = New System.Drawing.Size(104, 23)
		Me.tbScaleFrom.TabIndex = 18
		Me.tbScaleFrom.TabStop = false
		Me.tbScaleFrom.Text = "00:00:00.00000"
		Me.tbScaleFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.tbScaleFrom, "Current chapter time for scaling.")
		'
		'bReset
		'
		Me.bReset.Location = New System.Drawing.Point(640, 680)
		Me.bReset.Name = "bReset"
		Me.bReset.Size = New System.Drawing.Size(80, 31)
		Me.bReset.TabIndex = 23
		Me.bReset.TabStop = false
		Me.bReset.Text = "Reset"
		Me.toolTip1.SetToolTip(Me.bReset, "Clear the chapter list and reset all"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"settings to their specified defaults.")
		Me.bReset.UseVisualStyleBackColor = true
		AddHandler Me.bReset.Click, AddressOf Me.BResetClick
		'
		'bOutput
		'
		Me.bOutput.Location = New System.Drawing.Point(736, 680)
		Me.bOutput.Name = "bOutput"
		Me.bOutput.Size = New System.Drawing.Size(80, 31)
		Me.bOutput.TabIndex = 24
		Me.bOutput.TabStop = false
		Me.bOutput.Text = "Output"
		Me.toolTip1.SetToolTip(Me.bOutput, "White the chapters list to the specified output file.")
		Me.bOutput.UseVisualStyleBackColor = true
		AddHandler Me.bOutput.Click, AddressOf Me.BOutputClick
		'
		'openFileDialog1
		'
		Me.openFileDialog1.FileName = "openFileDialog1"
		'
		'tbOffset
		'
		Me.tbOffset.Location = New System.Drawing.Point(152, 144)
		Me.tbOffset.MaxLength = 20
		Me.tbOffset.Name = "tbOffset"
		Me.tbOffset.Size = New System.Drawing.Size(48, 23)
		Me.tbOffset.TabIndex = 13
		Me.tbOffset.TabStop = false
		Me.tbOffset.Text = "0.0"
		Me.tbOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.tbOffset, "Number of seconds to shift chapter times.")
		'
		'bTitlesFileDialog
		'
		Me.bTitlesFileDialog.Location = New System.Drawing.Point(424, 80)
		Me.bTitlesFileDialog.Name = "bTitlesFileDialog"
		Me.bTitlesFileDialog.Size = New System.Drawing.Size(24, 23)
		Me.bTitlesFileDialog.TabIndex = 9
		Me.bTitlesFileDialog.TabStop = false
		Me.bTitlesFileDialog.Text = "..."
		Me.toolTip1.SetToolTip(Me.bTitlesFileDialog, resources.GetString("bTitlesFileDialog.ToolTip"))
		Me.bTitlesFileDialog.UseVisualStyleBackColor = true
		AddHandler Me.bTitlesFileDialog.Click, AddressOf Me.Button3Click
		'
		'bTimesFileDialog
		'
		Me.bTimesFileDialog.Location = New System.Drawing.Point(424, 56)
		Me.bTimesFileDialog.Name = "bTimesFileDialog"
		Me.bTimesFileDialog.Size = New System.Drawing.Size(24, 23)
		Me.bTimesFileDialog.TabIndex = 3
		Me.bTimesFileDialog.TabStop = false
		Me.bTimesFileDialog.Text = "..."
		Me.toolTip1.SetToolTip(Me.bTimesFileDialog, resources.GetString("bTimesFileDialog.ToolTip"))
		Me.bTimesFileDialog.UseVisualStyleBackColor = true
		AddHandler Me.bTimesFileDialog.Click, AddressOf Me.Button4Click
		'
		'bOutputFileDialog
		'
		Me.bOutputFileDialog.Location = New System.Drawing.Point(424, 104)
		Me.bOutputFileDialog.Name = "bOutputFileDialog"
		Me.bOutputFileDialog.Size = New System.Drawing.Size(24, 23)
		Me.bOutputFileDialog.TabIndex = 15
		Me.bOutputFileDialog.TabStop = false
		Me.bOutputFileDialog.Text = "..."
		Me.toolTip1.SetToolTip(Me.bOutputFileDialog, "Select the output file name and path using the system file browser."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"This can be "& _ 
				"either an XLM file, an OGM-format Chapters file, or a plain"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"text file, as deter"& _ 
				"mined by the selected file type."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
		Me.bOutputFileDialog.UseVisualStyleBackColor = true
		AddHandler Me.bOutputFileDialog.Click, AddressOf Me.Button5Click
		'
		'menuStrip1
		'
		Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem1, Me.editToolStripMenuItem1, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
		Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.menuStrip1.Name = "menuStrip1"
		Me.menuStrip1.Size = New System.Drawing.Size(926, 24)
		Me.menuStrip1.TabIndex = 25
		Me.menuStrip1.Text = "menuStrip1"
		'
		'fileToolStripMenuItem1
		'
		Me.fileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.outputTypeToolStripMenuItem, Me.toolStripSeparator1, Me.printToolStripMenuItem, Me.printPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem1})
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
		'outputTypeToolStripMenuItem
		'
		Me.outputTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xMLToolStripMenuItem, Me.oGGMediaToolStripMenuItem, Me.plainTextToolStripMenuItem})
		Me.outputTypeToolStripMenuItem.Name = "outputTypeToolStripMenuItem"
		Me.outputTypeToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.outputTypeToolStripMenuItem.Text = "Output &Type"
		'
		'xMLToolStripMenuItem
		'
		Me.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem"
		Me.xMLToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
		Me.xMLToolStripMenuItem.Text = "Extensible Markup (XML)"
		AddHandler Me.xMLToolStripMenuItem.Click, AddressOf Me.XMLToolStripMenuItemClick
		'
		'oGGMediaToolStripMenuItem
		'
		Me.oGGMediaToolStripMenuItem.Name = "oGGMediaToolStripMenuItem"
		Me.oGGMediaToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
		Me.oGGMediaToolStripMenuItem.Text = "OGG Media (OGM)"
		AddHandler Me.oGGMediaToolStripMenuItem.Click, AddressOf Me.OGGMediaToolStripMenuItemClick
		'
		'plainTextToolStripMenuItem
		'
		Me.plainTextToolStripMenuItem.Name = "plainTextToolStripMenuItem"
		Me.plainTextToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
		Me.plainTextToolStripMenuItem.Text = "Plain Text (TXT)"
		AddHandler Me.plainTextToolStripMenuItem.Click, AddressOf Me.PlainTextToolStripMenuItemClick
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
		'
		'undoToolStripMenuItem
		'
		Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
		Me.undoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z),System.Windows.Forms.Keys)
		Me.undoToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
		Me.undoToolStripMenuItem.Text = "&Undo"
		Me.undoToolStripMenuItem.Visible = false
		'
		'redoToolStripMenuItem
		'
		Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
		Me.redoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y),System.Windows.Forms.Keys)
		Me.redoToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
		Me.redoToolStripMenuItem.Text = "&Redo"
		Me.redoToolStripMenuItem.Visible = false
		'
		'toolStripSeparator3
		'
		Me.toolStripSeparator3.Name = "toolStripSeparator3"
		Me.toolStripSeparator3.Size = New System.Drawing.Size(161, 6)
		'
		'cutToolStripMenuItem
		'
		Me.cutToolStripMenuItem.Image = CType(resources.GetObject("cutToolStripMenuItem.Image"),System.Drawing.Image)
		Me.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
		Me.cutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X),System.Windows.Forms.Keys)
		Me.cutToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
		Me.cutToolStripMenuItem.Text = "Cu&t"
		AddHandler Me.cutToolStripMenuItem.Click, AddressOf Me.CutToolStripMenuItemClick
		'
		'copyToolStripMenuItem
		'
		Me.copyToolStripMenuItem.Image = CType(resources.GetObject("copyToolStripMenuItem.Image"),System.Drawing.Image)
		Me.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
		Me.copyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C),System.Windows.Forms.Keys)
		Me.copyToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
		Me.copyToolStripMenuItem.Text = "&Copy"
		AddHandler Me.copyToolStripMenuItem.Click, AddressOf Me.CopyToolStripMenuItemClick
		'
		'pasteToolStripMenuItem
		'
		Me.pasteToolStripMenuItem.Image = CType(resources.GetObject("pasteToolStripMenuItem.Image"),System.Drawing.Image)
		Me.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
		Me.pasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V),System.Windows.Forms.Keys)
		Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
		Me.pasteToolStripMenuItem.Text = "&Paste"
		AddHandler Me.pasteToolStripMenuItem.Click, AddressOf Me.PasteToolStripMenuItemClick
		'
		'toolStripSeparator4
		'
		Me.toolStripSeparator4.Name = "toolStripSeparator4"
		Me.toolStripSeparator4.Size = New System.Drawing.Size(161, 6)
		'
		'selectAllToolStripMenuItem
		'
		Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
		Me.selectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A),System.Windows.Forms.Keys)
		Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
		Me.selectAllToolStripMenuItem.Text = "Select &All"
		AddHandler Me.selectAllToolStripMenuItem.Click, AddressOf Me.SelectAllToolStripMenuItemClick
		'
		'toolsToolStripMenuItem
		'
		Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.wordsListToolStripMenuItem, Me.settingsToolStripMenuItem, Me.checkForUpdatesToolStripMenuItem})
		Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
		Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
		Me.toolsToolStripMenuItem.Text = "&Tools"
		'
		'wordsListToolStripMenuItem
		'
		Me.wordsListToolStripMenuItem.Name = "wordsListToolStripMenuItem"
		Me.wordsListToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
		Me.wordsListToolStripMenuItem.Text = "&Words List"
		AddHandler Me.wordsListToolStripMenuItem.Click, AddressOf Me.WordsListToolStripMenuItemClick
		'
		'settingsToolStripMenuItem
		'
		Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
		Me.settingsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
		Me.settingsToolStripMenuItem.Text = "&Settings"
		AddHandler Me.settingsToolStripMenuItem.Click, AddressOf Me.SettingsToolStripMenuItemClick
		'
		'checkForUpdatesToolStripMenuItem
		'
		Me.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem"
		Me.checkForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
		Me.checkForUpdatesToolStripMenuItem.Text = "&Check for Updates"
		AddHandler Me.checkForUpdatesToolStripMenuItem.Click, AddressOf Me.CheckForUpdatesToolStripMenuItemClick
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
		Me.tbFrameRate.Location = New System.Drawing.Point(104, 104)
		Me.tbFrameRate.MaxLength = 20
		Me.tbFrameRate.Name = "tbFrameRate"
		Me.tbFrameRate.Size = New System.Drawing.Size(72, 23)
		Me.tbFrameRate.TabIndex = 8
		Me.tbFrameRate.TabStop = false
		Me.tbFrameRate.Text = "23.976"
		Me.tbFrameRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.tbFrameRate, "Frame rate to use for chapter time adjustments.")
		'
		'bLoadTitles
		'
		Me.bLoadTitles.Location = New System.Drawing.Point(504, 80)
		Me.bLoadTitles.Name = "bLoadTitles"
		Me.bLoadTitles.Size = New System.Drawing.Size(56, 23)
		Me.bLoadTitles.TabIndex = 11
		Me.bLoadTitles.TabStop = false
		Me.bLoadTitles.Text = "Load"
		Me.toolTip1.SetToolTip(Me.bLoadTitles, resources.GetString("bLoadTitles.ToolTip"))
		Me.bLoadTitles.UseVisualStyleBackColor = true
		AddHandler Me.bLoadTitles.Click, AddressOf Me.Button6Click
		'
		'bLoadTimes
		'
		Me.bLoadTimes.Location = New System.Drawing.Point(504, 56)
		Me.bLoadTimes.Name = "bLoadTimes"
		Me.bLoadTimes.Size = New System.Drawing.Size(56, 23)
		Me.bLoadTimes.TabIndex = 5
		Me.bLoadTimes.TabStop = false
		Me.bLoadTimes.Text = "Load"
		Me.toolTip1.SetToolTip(Me.bLoadTimes, resources.GetString("bLoadTimes.ToolTip"))
		Me.bLoadTimes.UseVisualStyleBackColor = true
		AddHandler Me.bLoadTimes.Click, AddressOf Me.Button7Click
		'
		'tbTimeType
		'
		Me.tbTimeType.Location = New System.Drawing.Point(456, 56)
		Me.tbTimeType.MaxLength = 20
		Me.tbTimeType.Name = "tbTimeType"
		Me.tbTimeType.ReadOnly = true
		Me.tbTimeType.Size = New System.Drawing.Size(40, 23)
		Me.tbTimeType.TabIndex = 4
		Me.tbTimeType.TabStop = false
		Me.tbTimeType.Text = "---"
		Me.tbTimeType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.tbTimeType, "The type of input file used for the chapter times,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"as determined automatically b"& _ 
				"y the program.")
		'
		'tbTitleType
		'
		Me.tbTitleType.Location = New System.Drawing.Point(456, 80)
		Me.tbTitleType.MaxLength = 20
		Me.tbTitleType.Name = "tbTitleType"
		Me.tbTitleType.ReadOnly = true
		Me.tbTitleType.Size = New System.Drawing.Size(40, 23)
		Me.tbTitleType.TabIndex = 10
		Me.tbTitleType.TabStop = false
		Me.tbTitleType.Text = "---"
		Me.tbTitleType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.tbTitleType, "The type of input file used for the chapter titles,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"as determined automatically "& _ 
				"by the program."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
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
		Me.maskedTextBox1.TabIndex = 0
		Me.maskedTextBox1.TabStop = false
		Me.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.maskedTextBox1, "The currently selected chapter time.  This can be"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"deleted, edited and saved, or "& _ 
				"edited and the new"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"time inserted into the list."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
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
		Me.dataGridView1.ContextMenuStrip = Me.contextMenuStrip1
		Me.dataGridView1.Location = New System.Drawing.Point(8, 136)
		Me.dataGridView1.MultiSelect = false
		Me.dataGridView1.Name = "dataGridView1"
		Me.dataGridView1.Size = New System.Drawing.Size(616, 576)
		Me.dataGridView1.TabIndex = 18
		Me.dataGridView1.TabStop = false
		AddHandler Me.dataGridView1.CellMouseDown, AddressOf Me.DataGridView1CellMouseDown
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
		Me.dgTitle.Width = 340
		'
		'contextMenuStrip1
		'
		Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.moveUpToolStripMenuItem, Me.moveDownToolStripMenuItem, Me.deleteLineToolStripMenuItem, Me.deleteTimeOnlyToolStripMenuItem, Me.deleteTitleOnlyToolStripMenuItem})
		Me.contextMenuStrip1.Name = "contextMenuStrip1"
		Me.contextMenuStrip1.Size = New System.Drawing.Size(166, 114)
		'
		'moveUpToolStripMenuItem
		'
		Me.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem"
		Me.moveUpToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.moveUpToolStripMenuItem.Text = "Move Title Up"
		AddHandler Me.moveUpToolStripMenuItem.Click, AddressOf Me.MoveUpToolStripMenuItemClick
		'
		'moveDownToolStripMenuItem
		'
		Me.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem"
		Me.moveDownToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.moveDownToolStripMenuItem.Text = "Move Title Down"
		AddHandler Me.moveDownToolStripMenuItem.Click, AddressOf Me.MoveDownToolStripMenuItemClick
		'
		'deleteLineToolStripMenuItem
		'
		Me.deleteLineToolStripMenuItem.Name = "deleteLineToolStripMenuItem"
		Me.deleteLineToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.deleteLineToolStripMenuItem.Text = "Delete Line"
		AddHandler Me.deleteLineToolStripMenuItem.Click, AddressOf Me.DeleteLineToolStripMenuItemClick
		'
		'deleteTimeOnlyToolStripMenuItem
		'
		Me.deleteTimeOnlyToolStripMenuItem.Name = "deleteTimeOnlyToolStripMenuItem"
		Me.deleteTimeOnlyToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.deleteTimeOnlyToolStripMenuItem.Text = "Delete Time Only"
		AddHandler Me.deleteTimeOnlyToolStripMenuItem.Click, AddressOf Me.DeleteTimeOnlyToolStripMenuItemClick
		'
		'deleteTitleOnlyToolStripMenuItem
		'
		Me.deleteTitleOnlyToolStripMenuItem.Name = "deleteTitleOnlyToolStripMenuItem"
		Me.deleteTitleOnlyToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
		Me.deleteTitleOnlyToolStripMenuItem.Text = "Delete Title Only"
		AddHandler Me.deleteTitleOnlyToolStripMenuItem.Click, AddressOf Me.DeleteTitleOnlyToolStripMenuItemClick
		'
		'bTimeAdd
		'
		Me.bTimeAdd.Location = New System.Drawing.Point(8, 48)
		Me.bTimeAdd.Name = "bTimeAdd"
		Me.bTimeAdd.Size = New System.Drawing.Size(80, 23)
		Me.bTimeAdd.TabIndex = 1
		Me.bTimeAdd.TabStop = false
		Me.bTimeAdd.Text = "Add"
		Me.toolTip1.SetToolTip(Me.bTimeAdd, "Add a new chapter time to the list.")
		Me.bTimeAdd.UseVisualStyleBackColor = true
		AddHandler Me.bTimeAdd.Click, AddressOf Me.BTimeAddClick
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(8, 72)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(80, 24)
		Me.label7.TabIndex = 2
		Me.label7.Text = "Language:"
		Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bTimeUpdate
		'
		Me.bTimeUpdate.Location = New System.Drawing.Point(104, 48)
		Me.bTimeUpdate.Name = "bTimeUpdate"
		Me.bTimeUpdate.Size = New System.Drawing.Size(80, 23)
		Me.bTimeUpdate.TabIndex = 2
		Me.bTimeUpdate.TabStop = false
		Me.bTimeUpdate.Text = "Update"
		Me.toolTip1.SetToolTip(Me.bTimeUpdate, "Update the currently selected chapter time.")
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
		Me.tbChapterTitle.Size = New System.Drawing.Size(272, 23)
		Me.tbChapterTitle.TabIndex = 0
		Me.tbChapterTitle.TabStop = false
		Me.toolTip1.SetToolTip(Me.tbChapterTitle, "The currently selected chapter title.  This can be"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"deleted, edited and saved, or"& _ 
				" edited and the new"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"title inserted into the list."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Titles can also be edited "& _ 
				"directly in the list.")
		'
		'bTimeRemove
		'
		Me.bTimeRemove.Location = New System.Drawing.Point(200, 48)
		Me.bTimeRemove.Name = "bTimeRemove"
		Me.bTimeRemove.Size = New System.Drawing.Size(80, 23)
		Me.bTimeRemove.TabIndex = 3
		Me.bTimeRemove.TabStop = false
		Me.bTimeRemove.Text = "Remove"
		Me.toolTip1.SetToolTip(Me.bTimeRemove, "Delete the currently selected chapter time.")
		Me.bTimeRemove.UseVisualStyleBackColor = true
		AddHandler Me.bTimeRemove.Click, AddressOf Me.BTimeRemoveClick
		'
		'groupBox1
		'
		Me.groupBox1.Controls.Add(Me.maskedTextBox1)
		Me.groupBox1.Controls.Add(Me.bTimeRemove)
		Me.groupBox1.Controls.Add(Me.bTimeAdd)
		Me.groupBox1.Controls.Add(Me.bTimeUpdate)
		Me.groupBox1.Location = New System.Drawing.Point(632, 168)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(288, 80)
		Me.groupBox1.TabIndex = 20
		Me.groupBox1.TabStop = false
		Me.groupBox1.Text = "Chapter Time"
		'
		'groupBox2
		'
		Me.groupBox2.Controls.Add(Me.bTitleRemove)
		Me.groupBox2.Controls.Add(Me.bTitleUpdate)
		Me.groupBox2.Controls.Add(Me.bTitleInsert)
		Me.groupBox2.Controls.Add(Me.tbChapterTitle)
		Me.groupBox2.Location = New System.Drawing.Point(632, 256)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(288, 80)
		Me.groupBox2.TabIndex = 21
		Me.groupBox2.TabStop = false
		Me.groupBox2.Text = "Chapter Title"
		'
		'bTitleRemove
		'
		Me.bTitleRemove.Location = New System.Drawing.Point(200, 48)
		Me.bTitleRemove.Name = "bTitleRemove"
		Me.bTitleRemove.Size = New System.Drawing.Size(80, 23)
		Me.bTitleRemove.TabIndex = 3
		Me.bTitleRemove.TabStop = false
		Me.bTitleRemove.Text = "Remove"
		Me.toolTip1.SetToolTip(Me.bTitleRemove, "Delete the currently selected chapter title."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"All following titles will be shifte"& _ 
				"d up.")
		Me.bTitleRemove.UseVisualStyleBackColor = true
		AddHandler Me.bTitleRemove.Click, AddressOf Me.BTitleRemoveClick
		'
		'bTitleUpdate
		'
		Me.bTitleUpdate.Location = New System.Drawing.Point(104, 48)
		Me.bTitleUpdate.Name = "bTitleUpdate"
		Me.bTitleUpdate.Size = New System.Drawing.Size(80, 23)
		Me.bTitleUpdate.TabIndex = 2
		Me.bTitleUpdate.TabStop = false
		Me.bTitleUpdate.Text = "Update"
		Me.toolTip1.SetToolTip(Me.bTitleUpdate, "Update the currently selected chapter title.")
		Me.bTitleUpdate.UseVisualStyleBackColor = true
		AddHandler Me.bTitleUpdate.Click, AddressOf Me.BTitleUpdateClick
		'
		'bTitleInsert
		'
		Me.bTitleInsert.Location = New System.Drawing.Point(8, 48)
		Me.bTitleInsert.Name = "bTitleInsert"
		Me.bTitleInsert.Size = New System.Drawing.Size(80, 23)
		Me.bTitleInsert.TabIndex = 1
		Me.bTitleInsert.TabStop = false
		Me.bTitleInsert.Text = "Insert"
		Me.toolTip1.SetToolTip(Me.bTitleInsert, "Insert a new chapter title ahead of the selected title.")
		Me.bTitleInsert.UseVisualStyleBackColor = true
		AddHandler Me.bTitleInsert.Click, AddressOf Me.BTitleInsertClick
		'
		'groupBox3
		'
		Me.groupBox3.Controls.Add(Me.cbAddChapterTimes)
		Me.groupBox3.Controls.Add(Me.cbLanguage)
		Me.groupBox3.Controls.Add(Me.cbAddChapterNumbers)
		Me.groupBox3.Controls.Add(Me.label7)
		Me.groupBox3.Location = New System.Drawing.Point(632, 56)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(288, 104)
		Me.groupBox3.TabIndex = 19
		Me.groupBox3.TabStop = false
		Me.groupBox3.Text = "Output Options"
		'
		'cbAddChapterTimes
		'
		Me.cbAddChapterTimes.Location = New System.Drawing.Point(8, 48)
		Me.cbAddChapterTimes.Name = "cbAddChapterTimes"
		Me.cbAddChapterTimes.Size = New System.Drawing.Size(168, 24)
		Me.cbAddChapterTimes.TabIndex = 1
		Me.cbAddChapterTimes.TabStop = false
		Me.cbAddChapterTimes.Text = "Add Chapter Times"
		Me.toolTip1.SetToolTip(Me.cbAddChapterTimes, "This will include the chapter start times in"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"the chapter names written to the ou"& _ 
				"tput file.")
		Me.cbAddChapterTimes.UseVisualStyleBackColor = true
		'
		'cbLanguage
		'
		Me.cbLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cbLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbLanguage.FormattingEnabled = true
		Me.cbLanguage.Location = New System.Drawing.Point(88, 72)
		Me.cbLanguage.Name = "cbLanguage"
		Me.cbLanguage.Size = New System.Drawing.Size(192, 24)
		Me.cbLanguage.TabIndex = 3
		Me.cbLanguage.TabStop = false
		Me.toolTip1.SetToolTip(Me.cbLanguage, "This is the language code to be written to the"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"output file when XML output is se"& _ 
				"lected.")
		'
		'groupBox4
		'
		Me.groupBox4.Controls.Add(Me.bShiftTimesHelp)
		Me.groupBox4.Controls.Add(Me.bAddTimesHelp)
		Me.groupBox4.Controls.Add(Me.bScaleHelp)
		Me.groupBox4.Controls.Add(Me.lbFRList)
		Me.groupBox4.Controls.Add(Me.bFRDropDown)
		Me.groupBox4.Controls.Add(Me.label19)
		Me.groupBox4.Controls.Add(Me.label18)
		Me.groupBox4.Controls.Add(Me.label17)
		Me.groupBox4.Controls.Add(Me.label8)
		Me.groupBox4.Controls.Add(Me.label6)
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
		Me.groupBox4.Controls.Add(Me.tbFrameRate)
		Me.groupBox4.Controls.Add(Me.tbOffset)
		Me.groupBox4.Location = New System.Drawing.Point(632, 344)
		Me.groupBox4.Name = "groupBox4"
		Me.groupBox4.Size = New System.Drawing.Size(288, 328)
		Me.groupBox4.TabIndex = 22
		Me.groupBox4.TabStop = false
		Me.groupBox4.Text = "Chapter List"
		'
		'bShiftTimesHelp
		'
		Me.bShiftTimesHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.bShiftTimesHelp.Location = New System.Drawing.Point(8, 168)
		Me.bShiftTimesHelp.Name = "bShiftTimesHelp"
		Me.bShiftTimesHelp.Size = New System.Drawing.Size(40, 23)
		Me.bShiftTimesHelp.TabIndex = 29
		Me.bShiftTimesHelp.TabStop = false
		Me.bShiftTimesHelp.Text = "Help"
		Me.bShiftTimesHelp.UseVisualStyleBackColor = true
		AddHandler Me.bShiftTimesHelp.Click, AddressOf Me.BShiftTimesHelpClick
		'
		'bAddTimesHelp
		'
		Me.bAddTimesHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.bAddTimesHelp.Location = New System.Drawing.Point(8, 296)
		Me.bAddTimesHelp.Name = "bAddTimesHelp"
		Me.bAddTimesHelp.Size = New System.Drawing.Size(40, 23)
		Me.bAddTimesHelp.TabIndex = 29
		Me.bAddTimesHelp.TabStop = false
		Me.bAddTimesHelp.Text = "Help"
		Me.bAddTimesHelp.UseVisualStyleBackColor = true
		AddHandler Me.bAddTimesHelp.Click, AddressOf Me.BAddTimesHelpClick
		'
		'bScaleHelp
		'
		Me.bScaleHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.bScaleHelp.Location = New System.Drawing.Point(8, 232)
		Me.bScaleHelp.Name = "bScaleHelp"
		Me.bScaleHelp.Size = New System.Drawing.Size(40, 23)
		Me.bScaleHelp.TabIndex = 28
		Me.bScaleHelp.TabStop = false
		Me.bScaleHelp.Text = "Help"
		Me.bScaleHelp.UseVisualStyleBackColor = true
		AddHandler Me.bScaleHelp.Click, AddressOf Me.BScaleHelpClick
		'
		'lbFRList
		'
		Me.lbFRList.FormattingEnabled = true
		Me.lbFRList.ItemHeight = 16
		Me.lbFRList.Items.AddRange(New Object() {"23.976", "24.0", "25.0", "29.97", "30.0", "50.0", "59.94", "60", "Custom"})
		Me.lbFRList.Location = New System.Drawing.Point(104, 104)
		Me.lbFRList.Name = "lbFRList"
		Me.lbFRList.Size = New System.Drawing.Size(72, 148)
		Me.lbFRList.TabIndex = 26
		Me.toolTip1.SetToolTip(Me.lbFRList, "Frame rate to use for chapter time adjustments.")
		Me.lbFRList.Visible = false
		AddHandler Me.lbFRList.SelectedIndexChanged, AddressOf Me.LbFRListSelectedIndexChanged
		AddHandler Me.lbFRList.Leave, AddressOf Me.LbFRListLeave
		'
		'bFRDropDown
		'
		Me.bFRDropDown.Location = New System.Drawing.Point(176, 104)
		Me.bFRDropDown.Name = "bFRDropDown"
		Me.bFRDropDown.Size = New System.Drawing.Size(24, 23)
		Me.bFRDropDown.TabIndex = 27
		Me.bFRDropDown.TabStop = false
		Me.bFRDropDown.Text = "▼"
		Me.toolTip1.SetToolTip(Me.bFRDropDown, "Frame rate to use for chapter time adjustments.")
		Me.bFRDropDown.UseVisualStyleBackColor = true
		AddHandler Me.bFRDropDown.Click, AddressOf Me.BFRDropDownClick
		'
		'label19
		'
		Me.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label19.Location = New System.Drawing.Point(8, 264)
		Me.label19.Name = "label19"
		Me.label19.Size = New System.Drawing.Size(272, 2)
		Me.label19.TabIndex = 21
		'
		'label18
		'
		Me.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label18.Location = New System.Drawing.Point(8, 200)
		Me.label18.Name = "label18"
		Me.label18.Size = New System.Drawing.Size(272, 2)
		Me.label18.TabIndex = 15
		'
		'label17
		'
		Me.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label17.Location = New System.Drawing.Point(8, 136)
		Me.label17.Name = "label17"
		Me.label17.Size = New System.Drawing.Size(272, 2)
		Me.label17.TabIndex = 10
		'
		'label8
		'
		Me.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label8.Location = New System.Drawing.Point(8, 96)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(272, 2)
		Me.label8.TabIndex = 5
		'
		'label6
		'
		Me.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label6.Location = New System.Drawing.Point(8, 56)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(272, 2)
		Me.label6.TabIndex = 2
		'
		'maskedTextBox4
		'
		Me.maskedTextBox4.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.maskedTextBox4.Location = New System.Drawing.Point(176, 296)
		Me.maskedTextBox4.Mask = "00:00:00.00000"
		Me.maskedTextBox4.Name = "maskedTextBox4"
		Me.maskedTextBox4.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.maskedTextBox4.RejectInputOnFirstFailure = true
		Me.maskedTextBox4.ResetOnPrompt = false
		Me.maskedTextBox4.ResetOnSpace = false
		Me.maskedTextBox4.Size = New System.Drawing.Size(104, 23)
		Me.maskedTextBox4.TabIndex = 26
		Me.maskedTextBox4.TabStop = false
		Me.maskedTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.maskedTextBox4, "End time to use when adding a block of times.")
		AddHandler Me.maskedTextBox4.Leave, AddressOf Me.MaskedTextBox4Leave
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(88, 296)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(88, 24)
		Me.label4.TabIndex = 25
		Me.label4.Text = "Up to"
		Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'maskedTextBox3
		'
		Me.maskedTextBox3.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.maskedTextBox3.Location = New System.Drawing.Point(176, 272)
		Me.maskedTextBox3.Mask = "00:00:00.00000"
		Me.maskedTextBox3.Name = "maskedTextBox3"
		Me.maskedTextBox3.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.maskedTextBox3.RejectInputOnFirstFailure = true
		Me.maskedTextBox3.ResetOnPrompt = false
		Me.maskedTextBox3.ResetOnSpace = false
		Me.maskedTextBox3.Size = New System.Drawing.Size(104, 23)
		Me.maskedTextBox3.TabIndex = 24
		Me.maskedTextBox3.TabStop = false
		Me.maskedTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.maskedTextBox3, "Interval to use for new block of times.")
		AddHandler Me.maskedTextBox3.Leave, AddressOf Me.MaskedTextBox3Leave
		'
		'label5
		'
		Me.label5.Location = New System.Drawing.Point(56, 272)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(120, 24)
		Me.label5.TabIndex = 23
		Me.label5.Text = "Add Times Every"
		Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bAddIntervals
		'
		Me.bAddIntervals.Location = New System.Drawing.Point(8, 272)
		Me.bAddIntervals.Name = "bAddIntervals"
		Me.bAddIntervals.Size = New System.Drawing.Size(40, 23)
		Me.bAddIntervals.TabIndex = 22
		Me.bAddIntervals.TabStop = false
		Me.bAddIntervals.Text = "Go"
		Me.toolTip1.SetToolTip(Me.bAddIntervals, "Add a block of times at the specified interval"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"from 00:00:00.00000 to the specif"& _ 
				"ied end time.")
		Me.bAddIntervals.UseVisualStyleBackColor = true
		AddHandler Me.bAddIntervals.Click, AddressOf Me.BAddIntervalsClick
		'
		'label16
		'
		Me.label16.Location = New System.Drawing.Point(88, 232)
		Me.label16.Name = "label16"
		Me.label16.Size = New System.Drawing.Size(88, 24)
		Me.label16.TabIndex = 19
		Me.label16.Text = "Becomes"
		Me.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'maskedTextBox2
		'
		Me.maskedTextBox2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.maskedTextBox2.Location = New System.Drawing.Point(176, 232)
		Me.maskedTextBox2.Mask = "00:00:00.00000"
		Me.maskedTextBox2.Name = "maskedTextBox2"
		Me.maskedTextBox2.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.maskedTextBox2.RejectInputOnFirstFailure = true
		Me.maskedTextBox2.ResetOnPrompt = false
		Me.maskedTextBox2.ResetOnSpace = false
		Me.maskedTextBox2.Size = New System.Drawing.Size(104, 23)
		Me.maskedTextBox2.TabIndex = 20
		Me.maskedTextBox2.TabStop = false
		Me.maskedTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.toolTip1.SetToolTip(Me.maskedTextBox2, "New chapter time for scaling.")
		AddHandler Me.maskedTextBox2.Leave, AddressOf Me.MaskedTextBox2Leave
		'
		'label15
		'
		Me.label15.Location = New System.Drawing.Point(56, 208)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(120, 24)
		Me.label15.TabIndex = 17
		Me.label15.Text = "Scale Times so"
		Me.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label14
		'
		Me.label14.Location = New System.Drawing.Point(200, 144)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(64, 24)
		Me.label14.TabIndex = 14
		Me.label14.Text = "seconds"
		Me.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label13
		'
		Me.label13.Location = New System.Drawing.Point(56, 144)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(96, 24)
		Me.label13.TabIndex = 12
		Me.label13.Text = "Shift Times by"
		Me.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bScaleTimes
		'
		Me.bScaleTimes.Location = New System.Drawing.Point(8, 208)
		Me.bScaleTimes.Name = "bScaleTimes"
		Me.bScaleTimes.Size = New System.Drawing.Size(40, 23)
		Me.bScaleTimes.TabIndex = 16
		Me.bScaleTimes.TabStop = false
		Me.bScaleTimes.Text = "Go"
		Me.toolTip1.SetToolTip(Me.bScaleTimes, "Change the currently selected time to the new"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"time specified, and scale all prec"& _ 
				"eeding times"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"accordingly.")
		Me.bScaleTimes.UseVisualStyleBackColor = true
		AddHandler Me.bScaleTimes.Click, AddressOf Me.BScaleTimesClick
		'
		'bShiftTimes
		'
		Me.bShiftTimes.Location = New System.Drawing.Point(8, 144)
		Me.bShiftTimes.Name = "bShiftTimes"
		Me.bShiftTimes.Size = New System.Drawing.Size(40, 23)
		Me.bShiftTimes.TabIndex = 11
		Me.bShiftTimes.TabStop = false
		Me.bShiftTimes.Text = "Go"
		Me.toolTip1.SetToolTip(Me.bShiftTimes, "Shift the currently selected time and all subsequent"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"times by the specified numb"& _ 
				"er of seconds.")
		Me.bShiftTimes.UseVisualStyleBackColor = true
		AddHandler Me.bShiftTimes.Click, AddressOf Me.BShiftTimesClick
		'
		'label12
		'
		Me.label12.Location = New System.Drawing.Point(200, 104)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(56, 24)
		Me.label12.TabIndex = 9
		Me.label12.Text = "fps FR"
		Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(56, 104)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(48, 24)
		Me.label11.TabIndex = 7
		Me.label11.Text = "Match"
		Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bFrameRateTimes
		'
		Me.bFrameRateTimes.Location = New System.Drawing.Point(8, 104)
		Me.bFrameRateTimes.Name = "bFrameRateTimes"
		Me.bFrameRateTimes.Size = New System.Drawing.Size(40, 23)
		Me.bFrameRateTimes.TabIndex = 6
		Me.bFrameRateTimes.TabStop = false
		Me.bFrameRateTimes.Text = "Go"
		Me.toolTip1.SetToolTip(Me.bFrameRateTimes, "Adjust all chapter times to align to frame"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"boundaries at the specified frame rat"& _ 
				"e.")
		Me.bFrameRateTimes.UseVisualStyleBackColor = true
		AddHandler Me.bFrameRateTimes.Click, AddressOf Me.BFrameRateTimesClick
		'
		'bFixTitleCase
		'
		Me.bFixTitleCase.Location = New System.Drawing.Point(8, 64)
		Me.bFixTitleCase.Name = "bFixTitleCase"
		Me.bFixTitleCase.Size = New System.Drawing.Size(40, 23)
		Me.bFixTitleCase.TabIndex = 3
		Me.bFixTitleCase.TabStop = false
		Me.bFixTitleCase.Text = "Go"
		Me.toolTip1.SetToolTip(Me.bFixTitleCase, "Convert all chapter titles to proper title case while applying"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"the rules from th"& _ 
				"e user-specified words list.")
		Me.bFixTitleCase.UseVisualStyleBackColor = true
		AddHandler Me.bFixTitleCase.Click, AddressOf Me.BFixTitleCaseClick
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(56, 64)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(160, 24)
		Me.label10.TabIndex = 4
		Me.label10.Text = "Fix Case on All Titles"
		Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bDeleteLine
		'
		Me.bDeleteLine.Location = New System.Drawing.Point(8, 24)
		Me.bDeleteLine.Name = "bDeleteLine"
		Me.bDeleteLine.Size = New System.Drawing.Size(40, 23)
		Me.bDeleteLine.TabIndex = 0
		Me.bDeleteLine.TabStop = false
		Me.bDeleteLine.Text = "Go"
		Me.toolTip1.SetToolTip(Me.bDeleteLine, "Delete the currently selected line (time and title).")
		Me.bDeleteLine.UseVisualStyleBackColor = true
		AddHandler Me.bDeleteLine.Click, AddressOf Me.BDeleteLineClick
		'
		'label9
		'
		Me.label9.Location = New System.Drawing.Point(56, 24)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(160, 24)
		Me.label9.TabIndex = 1
		Me.label9.Text = "Remove Selected Line"
		Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'bExit
		'
		Me.bExit.Location = New System.Drawing.Point(832, 680)
		Me.bExit.Name = "bExit"
		Me.bExit.Size = New System.Drawing.Size(80, 31)
		Me.bExit.TabIndex = 0
		Me.bExit.Text = "Exit"
		Me.toolTip1.SetToolTip(Me.bExit, "Close all windows and exit the program.")
		Me.bExit.UseVisualStyleBackColor = true
		AddHandler Me.bExit.Click, AddressOf Me.BExitClick
		'
		'helpProvider1
		'
		Me.helpProvider1.HelpNamespace = "ChapterMakerHelp.chm"
		'
		'bClearTimes
		'
		Me.bClearTimes.Location = New System.Drawing.Point(568, 56)
		Me.bClearTimes.Name = "bClearTimes"
		Me.bClearTimes.Size = New System.Drawing.Size(56, 23)
		Me.bClearTimes.TabIndex = 6
		Me.bClearTimes.TabStop = false
		Me.bClearTimes.Text = "Clear"
		Me.toolTip1.SetToolTip(Me.bClearTimes, "Clear all chapter time entries from the list.  Chapter"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"titles will remain as orp"& _ 
				"han records in the list.")
		Me.bClearTimes.UseVisualStyleBackColor = true
		AddHandler Me.bClearTimes.Click, AddressOf Me.BClearTimesClick
		'
		'bClearTitles
		'
		Me.bClearTitles.Location = New System.Drawing.Point(568, 80)
		Me.bClearTitles.Name = "bClearTitles"
		Me.bClearTitles.Size = New System.Drawing.Size(56, 23)
		Me.bClearTitles.TabIndex = 12
		Me.bClearTitles.TabStop = false
		Me.bClearTitles.Text = "Clear"
		Me.toolTip1.SetToolTip(Me.bClearTitles, "Clear all chapter title entries from the list.  Chapter"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"times will remain in the"& _ 
				" list, but will have no associated"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"titles."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))
		Me.bClearTitles.UseVisualStyleBackColor = true
		AddHandler Me.bClearTitles.Click, AddressOf Me.BClearTitlesClick
		'
		'toolStrip1
		'
		Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripButton, Me.openToolStripButton, Me.saveToolStripButton, Me.printToolStripButton, Me.toolStripSeparator6, Me.cutToolStripButton, Me.copyToolStripButton, Me.pasteToolStripButton, Me.toolStripSeparator7, Me.helpToolStripButton})
		Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
		Me.toolStrip1.Name = "toolStrip1"
		Me.toolStrip1.Size = New System.Drawing.Size(926, 25)
		Me.toolStrip1.TabIndex = 26
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
		AddHandler Me.newToolStripButton.Click, AddressOf Me.NewToolStripButtonClick
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
		'toolStripSeparator6
		'
		Me.toolStripSeparator6.Name = "toolStripSeparator6"
		Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
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
		'toolStripSeparator7
		'
		Me.toolStripSeparator7.Name = "toolStripSeparator7"
		Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 25)
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
		Me.statusStrip1.Location = New System.Drawing.Point(0, 722)
		Me.statusStrip1.Name = "statusStrip1"
		Me.statusStrip1.Size = New System.Drawing.Size(926, 22)
		Me.statusStrip1.TabIndex = 27
		Me.statusStrip1.Text = "statusStrip1"
		'
		'toolStripStatusLabel1
		'
		Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
		Me.toolStripStatusLabel1.Size = New System.Drawing.Size(118, 17)
		Me.toolStripStatusLabel1.Text = "toolStripStatusLabel1"
		'
		'cbOutputType
		'
		Me.cbOutputType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cbOutputType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cbOutputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbOutputType.FormattingEnabled = true
		Me.cbOutputType.Location = New System.Drawing.Point(456, 104)
		Me.cbOutputType.Name = "cbOutputType"
		Me.cbOutputType.Size = New System.Drawing.Size(168, 24)
		Me.cbOutputType.TabIndex = 28
		Me.toolTip1.SetToolTip(Me.cbOutputType, "The type of output file that you wish to write.")
		AddHandler Me.cbOutputType.SelectedIndexChanged, AddressOf Me.CbOutputTypeSelectedIndexChanged
		'
		'MainForm
		'
		Me.AllowDrop = true
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 16!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(926, 744)
		Me.Controls.Add(Me.cbOutputType)
		Me.Controls.Add(Me.statusStrip1)
		Me.Controls.Add(Me.toolStrip1)
		Me.Controls.Add(Me.bClearTitles)
		Me.Controls.Add(Me.bClearTimes)
		Me.Controls.Add(Me.bExit)
		Me.Controls.Add(Me.groupBox4)
		Me.Controls.Add(Me.groupBox3)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.dataGridView1)
		Me.Controls.Add(Me.tbTitleType)
		Me.Controls.Add(Me.tbTimeType)
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
		Me.Controls.Add(Me.bReset)
		Me.Controls.Add(Me.bTitlesFileDialog)
		Me.Controls.Add(Me.bOutput)
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
		AddHandler Shown, AddressOf Me.MainFormShown
		Me.menuStrip1.ResumeLayout(false)
		Me.menuStrip1.PerformLayout
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
		Me.contextMenuStrip1.ResumeLayout(false)
		Me.groupBox1.ResumeLayout(false)
		Me.groupBox1.PerformLayout
		Me.groupBox2.ResumeLayout(false)
		Me.groupBox2.PerformLayout
		Me.groupBox3.ResumeLayout(false)
		Me.groupBox4.ResumeLayout(false)
		Me.groupBox4.PerformLayout
		Me.toolStrip1.ResumeLayout(false)
		Me.toolStrip1.PerformLayout
		Me.statusStrip1.ResumeLayout(false)
		Me.statusStrip1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private bShiftTimesHelp As System.Windows.Forms.Button
	Private bScaleHelp As System.Windows.Forms.Button
	Private bAddTimesHelp As System.Windows.Forms.Button
	Private deleteTitleOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private deleteTimeOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private deleteLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private moveDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private moveUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
	Private toolTip1 As System.Windows.Forms.ToolTip
	Private cbOutputType As System.Windows.Forms.ComboBox
	Private plainTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private oGGMediaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private xMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private outputTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
	Private statusStrip1 As System.Windows.Forms.StatusStrip
	Private helpToolStripButton As System.Windows.Forms.ToolStripButton
	Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
	Private pasteToolStripButton As System.Windows.Forms.ToolStripButton
	Private copyToolStripButton As System.Windows.Forms.ToolStripButton
	Private cutToolStripButton As System.Windows.Forms.ToolStripButton
	Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
	Private printToolStripButton As System.Windows.Forms.ToolStripButton
	Private saveToolStripButton As System.Windows.Forms.ToolStripButton
	Private openToolStripButton As System.Windows.Forms.ToolStripButton
	Private newToolStripButton As System.Windows.Forms.ToolStripButton
	Private toolStrip1 As System.Windows.Forms.ToolStrip
	Private bFRDropDown As System.Windows.Forms.Button
	Private lbFRList As System.Windows.Forms.ListBox
	Private cbAddChapterTimes As System.Windows.Forms.CheckBox
	Private bClearTitles As System.Windows.Forms.Button
	Private bClearTimes As System.Windows.Forms.Button
	Private label8 As System.Windows.Forms.Label
	Private label17 As System.Windows.Forms.Label
	Private label18 As System.Windows.Forms.Label
	Private label19 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private checkForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
