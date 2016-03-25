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

Partial Class WordsList
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
		Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WordsList))
		Me.dataGridView1 = New System.Windows.Forms.DataGridView()
		Me.tWord = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.tAlways = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.button1 = New System.Windows.Forms.Button()
		Me.button2 = New System.Windows.Forms.Button()
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'dataGridView1
		'
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
		Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tWord, Me.tAlways})
		Me.dataGridView1.Location = New System.Drawing.Point(248, 8)
		Me.dataGridView1.Name = "dataGridView1"
		Me.dataGridView1.Size = New System.Drawing.Size(264, 360)
		Me.dataGridView1.TabIndex = 0
		Me.dataGridView1.TabStop = false
		AddHandler Me.dataGridView1.DefaultValuesNeeded, AddressOf Me.DataGridView1DefaultValuesNeeded
		'
		'tWord
		'
		Me.tWord.DataPropertyName = "tWord"
		Me.tWord.HeaderText = "Word"
		Me.tWord.MaxInputLength = 20
		Me.tWord.Name = "tWord"
		Me.tWord.Width = 120
		'
		'tAlways
		'
		Me.tAlways.DataPropertyName = "tAlways"
		Me.tAlways.FalseValue = "0"
		Me.tAlways.HeaderText = "Always"
		Me.tAlways.Name = "tAlways"
		Me.tAlways.TrueValue = "1"
		Me.tAlways.Width = 80
		'
		'label1
		'
		Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label1.Location = New System.Drawing.Point(8, 8)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(240, 23)
		Me.label1.TabIndex = 1
		Me.label1.Text = "Words List Editor"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'label2
		'
		Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label2.Location = New System.Drawing.Point(8, 32)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(240, 368)
		Me.label2.TabIndex = 2
		Me.label2.Text = resources.GetString("label2.Text")
		'
		'button1
		'
		Me.button1.Location = New System.Drawing.Point(360, 376)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(75, 23)
		Me.button1.TabIndex = 3
		Me.button1.Text = "Save"
		Me.button1.UseVisualStyleBackColor = true
		AddHandler Me.button1.Click, AddressOf Me.Button1Click
		'
		'button2
		'
		Me.button2.Location = New System.Drawing.Point(440, 376)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(75, 23)
		Me.button2.TabIndex = 4
		Me.button2.Text = "Cancel"
		Me.button2.UseVisualStyleBackColor = true
		AddHandler Me.button2.Click, AddressOf Me.Button2Click
		'
		'WordsList
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(522, 406)
		Me.Controls.Add(Me.button2)
		Me.Controls.Add(Me.button1)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.dataGridView1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "WordsList"
		Me.Text = "Edit Words List"
		AddHandler Load, AddressOf Me.WordsListLoad
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private button2 As System.Windows.Forms.Button
	Private button1 As System.Windows.Forms.Button
	Private label2 As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private tAlways As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private tWord As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dataGridView1 As System.Windows.Forms.DataGridView
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
End Class
