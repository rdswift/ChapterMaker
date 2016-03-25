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

Partial Class AboutBox
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox))
		Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
		Me.button1 = New System.Windows.Forms.Button()
		Me.pictureBox1 = New System.Windows.Forms.PictureBox()
		Me.pictureBox2 = New System.Windows.Forms.PictureBox()
		Me.lBuild = New System.Windows.Forms.Label()
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.pictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'richTextBox1
		'
		Me.richTextBox1.BackColor = System.Drawing.SystemColors.Control
		Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.richTextBox1.Location = New System.Drawing.Point(144, 16)
		Me.richTextBox1.Name = "richTextBox1"
		Me.richTextBox1.ReadOnly = true
		Me.richTextBox1.Size = New System.Drawing.Size(416, 272)
		Me.richTextBox1.TabIndex = 0
		Me.richTextBox1.TabStop = false
		Me.richTextBox1.Text = ""
		AddHandler Me.richTextBox1.LinkClicked, AddressOf Me.RichTextBox1LinkClicked
		'
		'button1
		'
		Me.button1.Location = New System.Drawing.Point(488, 296)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(75, 23)
		Me.button1.TabIndex = 1
		Me.button1.Text = "&Okay"
		Me.button1.UseVisualStyleBackColor = true
		AddHandler Me.button1.Click, AddressOf Me.Button1Click
		'
		'pictureBox1
		'
		Me.pictureBox1.Enabled = false
		Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"),System.Drawing.Image)
		Me.pictureBox1.Location = New System.Drawing.Point(16, 136)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(112, 56)
		Me.pictureBox1.TabIndex = 2
		Me.pictureBox1.TabStop = false
		'
		'pictureBox2
		'
		Me.pictureBox2.Image = CType(resources.GetObject("pictureBox2.Image"),System.Drawing.Image)
		Me.pictureBox2.Location = New System.Drawing.Point(16, 16)
		Me.pictureBox2.Name = "pictureBox2"
		Me.pictureBox2.Size = New System.Drawing.Size(112, 112)
		Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.pictureBox2.TabIndex = 3
		Me.pictureBox2.TabStop = false
		'
		'lBuild
		'
		Me.lBuild.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lBuild.Location = New System.Drawing.Point(8, 296)
		Me.lBuild.Name = "lBuild"
		Me.lBuild.Size = New System.Drawing.Size(224, 23)
		Me.lBuild.TabIndex = 4
		Me.lBuild.Text = "label1"
		Me.lBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'AboutBox
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(574, 330)
		Me.Controls.Add(Me.lBuild)
		Me.Controls.Add(Me.pictureBox2)
		Me.Controls.Add(Me.pictureBox1)
		Me.Controls.Add(Me.button1)
		Me.Controls.Add(Me.richTextBox1)
		Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "AboutBox"
		Me.Text = "AboutBox"
		AddHandler Load, AddressOf Me.AboutBoxLoad
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.pictureBox2,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------

	Private lBuild As System.Windows.Forms.Label
	Private pictureBox2 As System.Windows.Forms.PictureBox
	Private pictureBox1 As System.Windows.Forms.PictureBox
	Private button1 As System.Windows.Forms.Button
	Private richTextBox1 As System.Windows.Forms.RichTextBox
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
End Class
