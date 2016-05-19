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
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
		Me.bSave = New System.Windows.Forms.Button()
		Me.bCancel = New System.Windows.Forms.Button()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
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
		Me.groupBox3 = New System.Windows.Forms.GroupBox()
		Me.cbUpdates = New System.Windows.Forms.CheckBox()
		Me.cbModify = New System.Windows.Forms.CheckBox()
		Me.cbInsert = New System.Windows.Forms.CheckBox()
		Me.cbDelete = New System.Windows.Forms.CheckBox()
		Me.groupBox4 = New System.Windows.Forms.GroupBox()
		Me.label6 = New System.Windows.Forms.Label()
		Me.tbFrameRate = New System.Windows.Forms.TextBox()
		Me.cbLanguage = New System.Windows.Forms.ComboBox()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.rbChapterTime = New System.Windows.Forms.RadioButton()
		Me.groupBox5 = New System.Windows.Forms.GroupBox()
		Me.groupBox6 = New System.Windows.Forms.GroupBox()
		Me.cbLoadAppend = New System.Windows.Forms.CheckBox()
		Me.groupBox1.SuspendLayout
		Me.groupBox3.SuspendLayout
		Me.groupBox4.SuspendLayout
		Me.groupBox2.SuspendLayout
		Me.groupBox5.SuspendLayout
		Me.groupBox6.SuspendLayout
		Me.SuspendLayout
		'
		'bSave
		'
		Me.bSave.Location = New System.Drawing.Point(272, 648)
		Me.bSave.Margin = New System.Windows.Forms.Padding(4)
		Me.bSave.Name = "bSave"
		Me.bSave.Size = New System.Drawing.Size(100, 28)
		Me.bSave.TabIndex = 0
		Me.bSave.Text = "Save"
		Me.bSave.UseVisualStyleBackColor = true
		AddHandler Me.bSave.Click, AddressOf Me.BSaveClick
		'
		'bCancel
		'
		Me.bCancel.Location = New System.Drawing.Point(376, 648)
		Me.bCancel.Margin = New System.Windows.Forms.Padding(4)
		Me.bCancel.Name = "bCancel"
		Me.bCancel.Size = New System.Drawing.Size(100, 28)
		Me.bCancel.TabIndex = 1
		Me.bCancel.Text = "Cancel"
		Me.bCancel.UseVisualStyleBackColor = true
		AddHandler Me.bCancel.Click, AddressOf Me.BCancelClick
		'
		'groupBox1
		'
		Me.groupBox1.Controls.Add(Me.label7)
		Me.groupBox1.Controls.Add(Me.tbOGMExt)
		Me.groupBox1.Controls.Add(Me.bDirectoryLookup)
		Me.groupBox1.Controls.Add(Me.tbOutputDir)
		Me.groupBox1.Controls.Add(Me.label2)
		Me.groupBox1.Controls.Add(Me.rbXML)
		Me.groupBox1.Controls.Add(Me.label1)
		Me.groupBox1.Controls.Add(Me.rbOGM)
		Me.groupBox1.Location = New System.Drawing.Point(8, 152)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(464, 112)
		Me.groupBox1.TabIndex = 4
		Me.groupBox1.TabStop = false
		Me.groupBox1.Text = "Output File"
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(8, 72)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(72, 24)
		Me.label7.TabIndex = 6
		Me.label7.Text = "OGM Ext.:"
		Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tbOGMExt
		'
		Me.tbOGMExt.Location = New System.Drawing.Point(80, 72)
		Me.tbOGMExt.Name = "tbOGMExt"
		Me.tbOGMExt.Size = New System.Drawing.Size(344, 22)
		Me.tbOGMExt.TabIndex = 7
		Me.tbOGMExt.TabStop = false
		AddHandler Me.tbOGMExt.TextChanged, AddressOf Me.TbOGMExtTextChanged
		'
		'bDirectoryLookup
		'
		Me.bDirectoryLookup.Location = New System.Drawing.Point(432, 48)
		Me.bDirectoryLookup.Name = "bDirectoryLookup"
		Me.bDirectoryLookup.Size = New System.Drawing.Size(24, 24)
		Me.bDirectoryLookup.TabIndex = 5
		Me.bDirectoryLookup.TabStop = false
		Me.bDirectoryLookup.Text = "..."
		Me.bDirectoryLookup.UseVisualStyleBackColor = true
		AddHandler Me.bDirectoryLookup.Click, AddressOf Me.BDirectoryLookupClick
		'
		'tbOutputDir
		'
		Me.tbOutputDir.Location = New System.Drawing.Point(80, 48)
		Me.tbOutputDir.Name = "tbOutputDir"
		Me.tbOutputDir.Size = New System.Drawing.Size(344, 22)
		Me.tbOutputDir.TabIndex = 4
		Me.tbOutputDir.TabStop = false
		AddHandler Me.tbOutputDir.DoubleClick, AddressOf Me.TbOutputDirDoubleClick
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(8, 48)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(72, 24)
		Me.label2.TabIndex = 3
		Me.label2.Text = "Directory:"
		Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'rbXML
		'
		Me.rbXML.Checked = true
		Me.rbXML.Location = New System.Drawing.Point(80, 24)
		Me.rbXML.Name = "rbXML"
		Me.rbXML.Size = New System.Drawing.Size(240, 24)
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
		Me.rbOGM.Location = New System.Drawing.Point(320, 24)
		Me.rbOGM.Name = "rbOGM"
		Me.rbOGM.Size = New System.Drawing.Size(136, 24)
		Me.rbOGM.TabIndex = 2
		Me.rbOGM.Text = "OGM (Ogg Media)"
		Me.rbOGM.UseVisualStyleBackColor = true
		'
		'rbChapterNum
		'
		Me.rbChapterNum.Checked = true
		Me.rbChapterNum.Location = New System.Drawing.Point(224, 48)
		Me.rbChapterNum.Name = "rbChapterNum"
		Me.rbChapterNum.Size = New System.Drawing.Size(128, 24)
		Me.rbChapterNum.TabIndex = 2
		Me.rbChapterNum.TabStop = true
		Me.rbChapterNum.Text = "Chapter Number"
		Me.rbChapterNum.UseVisualStyleBackColor = true
		'
		'rbNA
		'
		Me.rbNA.Location = New System.Drawing.Point(224, 96)
		Me.rbNA.Name = "rbNA"
		Me.rbNA.Size = New System.Drawing.Size(56, 24)
		Me.rbNA.TabIndex = 4
		Me.rbNA.Text = """n/a"""
		Me.rbNA.UseVisualStyleBackColor = true
		'
		'cbNumbers
		'
		Me.cbNumbers.Location = New System.Drawing.Point(8, 24)
		Me.cbNumbers.Name = "cbNumbers"
		Me.cbNumbers.Size = New System.Drawing.Size(448, 24)
		Me.cbNumbers.TabIndex = 0
		Me.cbNumbers.TabStop = false
		Me.cbNumbers.Text = "Include chapter numbers in output chapter titles"
		Me.cbNumbers.UseVisualStyleBackColor = true
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(8, 48)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(216, 24)
		Me.label3.TabIndex = 1
		Me.label3.Text = "Replace missing chapter titles with:"
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'groupBox3
		'
		Me.groupBox3.Controls.Add(Me.cbModify)
		Me.groupBox3.Controls.Add(Me.cbInsert)
		Me.groupBox3.Controls.Add(Me.cbDelete)
		Me.groupBox3.Location = New System.Drawing.Point(8, 432)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(464, 104)
		Me.groupBox3.TabIndex = 6
		Me.groupBox3.TabStop = false
		Me.groupBox3.Text = "Confirmations"
		'
		'cbUpdates
		'
		Me.cbUpdates.Location = New System.Drawing.Point(8, 24)
		Me.cbUpdates.Name = "cbUpdates"
		Me.cbUpdates.Size = New System.Drawing.Size(448, 24)
		Me.cbUpdates.TabIndex = 0
		Me.cbUpdates.TabStop = false
		Me.cbUpdates.Text = "Check for program updates at start-up"
		Me.cbUpdates.UseVisualStyleBackColor = true
		'
		'cbModify
		'
		Me.cbModify.Location = New System.Drawing.Point(8, 48)
		Me.cbModify.Name = "cbModify"
		Me.cbModify.Size = New System.Drawing.Size(448, 24)
		Me.cbModify.TabIndex = 1
		Me.cbModify.TabStop = false
		Me.cbModify.Text = "Scaling, shifting or adjusting chapter times"
		Me.cbModify.UseVisualStyleBackColor = true
		'
		'cbInsert
		'
		Me.cbInsert.Location = New System.Drawing.Point(8, 24)
		Me.cbInsert.Name = "cbInsert"
		Me.cbInsert.Size = New System.Drawing.Size(448, 24)
		Me.cbInsert.TabIndex = 0
		Me.cbInsert.TabStop = false
		Me.cbInsert.Text = "Inserting chapter times or titles"
		Me.cbInsert.UseVisualStyleBackColor = true
		'
		'cbDelete
		'
		Me.cbDelete.Location = New System.Drawing.Point(8, 72)
		Me.cbDelete.Name = "cbDelete"
		Me.cbDelete.Size = New System.Drawing.Size(448, 24)
		Me.cbDelete.TabIndex = 2
		Me.cbDelete.TabStop = false
		Me.cbDelete.Text = "Deleting chapter times, titles or chapter list lines"
		Me.cbDelete.UseVisualStyleBackColor = true
		'
		'groupBox4
		'
		Me.groupBox4.Controls.Add(Me.label6)
		Me.groupBox4.Controls.Add(Me.tbFrameRate)
		Me.groupBox4.Controls.Add(Me.cbLanguage)
		Me.groupBox4.Controls.Add(Me.label5)
		Me.groupBox4.Controls.Add(Me.label4)
		Me.groupBox4.Location = New System.Drawing.Point(8, 552)
		Me.groupBox4.Name = "groupBox4"
		Me.groupBox4.Size = New System.Drawing.Size(464, 80)
		Me.groupBox4.TabIndex = 7
		Me.groupBox4.TabStop = false
		Me.groupBox4.Text = "Default Preferences"
		'
		'label6
		'
		Me.label6.Location = New System.Drawing.Point(264, 48)
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
		Me.tbFrameRate.Size = New System.Drawing.Size(136, 22)
		Me.tbFrameRate.TabIndex = 3
		Me.tbFrameRate.TabStop = false
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
		Me.cbLanguage.TabStop = false
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
		'groupBox2
		'
		Me.groupBox2.Controls.Add(Me.rbChapterTime)
		Me.groupBox2.Controls.Add(Me.rbChapterNum)
		Me.groupBox2.Controls.Add(Me.cbNumbers)
		Me.groupBox2.Controls.Add(Me.label3)
		Me.groupBox2.Controls.Add(Me.rbNA)
		Me.groupBox2.Location = New System.Drawing.Point(8, 280)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(464, 136)
		Me.groupBox2.TabIndex = 5
		Me.groupBox2.TabStop = false
		Me.groupBox2.Text = "Chapters"
		'
		'rbChapterTime
		'
		Me.rbChapterTime.Location = New System.Drawing.Point(224, 72)
		Me.rbChapterTime.Name = "rbChapterTime"
		Me.rbChapterTime.Size = New System.Drawing.Size(128, 24)
		Me.rbChapterTime.TabIndex = 3
		Me.rbChapterTime.Text = "Chapter Time"
		Me.rbChapterTime.UseVisualStyleBackColor = true
		'
		'groupBox5
		'
		Me.groupBox5.Controls.Add(Me.cbUpdates)
		Me.groupBox5.Location = New System.Drawing.Point(8, 8)
		Me.groupBox5.Name = "groupBox5"
		Me.groupBox5.Size = New System.Drawing.Size(464, 56)
		Me.groupBox5.TabIndex = 2
		Me.groupBox5.TabStop = false
		Me.groupBox5.Text = "Updates"
		'
		'groupBox6
		'
		Me.groupBox6.Controls.Add(Me.cbLoadAppend)
		Me.groupBox6.Location = New System.Drawing.Point(8, 80)
		Me.groupBox6.Name = "groupBox6"
		Me.groupBox6.Size = New System.Drawing.Size(464, 56)
		Me.groupBox6.TabIndex = 3
		Me.groupBox6.TabStop = false
		Me.groupBox6.Text = "Input Files"
		'
		'cbLoadAppend
		'
		Me.cbLoadAppend.Location = New System.Drawing.Point(8, 24)
		Me.cbLoadAppend.Name = "cbLoadAppend"
		Me.cbLoadAppend.Size = New System.Drawing.Size(448, 24)
		Me.cbLoadAppend.TabIndex = 0
		Me.cbLoadAppend.TabStop = false
		Me.cbLoadAppend.Text = "Append times and titles to existing list when loading"
		Me.cbLoadAppend.UseVisualStyleBackColor = true
		'
		'Settings
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(490, 690)
		Me.Controls.Add(Me.groupBox6)
		Me.Controls.Add(Me.groupBox5)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox4)
		Me.Controls.Add(Me.groupBox3)
		Me.Controls.Add(Me.groupBox1)
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
		Me.groupBox1.ResumeLayout(false)
		Me.groupBox1.PerformLayout
		Me.groupBox3.ResumeLayout(false)
		Me.groupBox4.ResumeLayout(false)
		Me.groupBox4.PerformLayout
		Me.groupBox2.ResumeLayout(false)
		Me.groupBox5.ResumeLayout(false)
		Me.groupBox6.ResumeLayout(false)
		Me.ResumeLayout(false)
	End Sub
	Private cbLoadAppend As System.Windows.Forms.CheckBox
	Private groupBox6 As System.Windows.Forms.GroupBox
	Private groupBox5 As System.Windows.Forms.GroupBox
	Private cbUpdates As System.Windows.Forms.CheckBox
	Private rbChapterTime As System.Windows.Forms.RadioButton
	Private tbOGMExt As System.Windows.Forms.TextBox
	Private label7 As System.Windows.Forms.Label
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private cbLanguage As System.Windows.Forms.ComboBox
	Private tbFrameRate As System.Windows.Forms.TextBox
	Private label6 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private groupBox4 As System.Windows.Forms.GroupBox
	Private cbDelete As System.Windows.Forms.CheckBox
	Private cbInsert As System.Windows.Forms.CheckBox
	Private cbModify As System.Windows.Forms.CheckBox
	Private groupBox3 As System.Windows.Forms.GroupBox
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
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private bCancel As System.Windows.Forms.Button
	Private bSave As System.Windows.Forms.Button
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
End Class
