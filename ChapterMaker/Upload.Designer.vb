'
' Created by SharpDevelop.
' User: bob
' Date: 2016-09-05
' Time: 11:26
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class Upload
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Upload))
		Me.textBox1 = New System.Windows.Forms.TextBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.tbTitle = New System.Windows.Forms.TextBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.mtbDuration = New System.Windows.Forms.MaskedTextBox()
		Me.tbFrameRate = New System.Windows.Forms.TextBox()
		Me.comboMedia = New System.Windows.Forms.ComboBox()
		Me.bUpload = New System.Windows.Forms.Button()
		Me.bQuit = New System.Windows.Forms.Button()
		Me.lbFRList = New System.Windows.Forms.ListBox()
		Me.bFRDropDown = New System.Windows.Forms.Button()
		Me.label7 = New System.Windows.Forms.Label()
		Me.lTbTitle = New System.Windows.Forms.Label()
		Me.lUploading = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'textBox1
		'
		Me.textBox1.Location = New System.Drawing.Point(8, 80)
		Me.textBox1.Multiline = true
		Me.textBox1.Name = "textBox1"
		Me.textBox1.ReadOnly = true
		Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.textBox1.Size = New System.Drawing.Size(704, 464)
		Me.textBox1.TabIndex = 0
		Me.textBox1.TabStop = false
		Me.textBox1.WordWrap = false
		'
		'label1
		'
		Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label1.Location = New System.Drawing.Point(8, 8)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(72, 23)
		Me.label1.TabIndex = 1
		Me.label1.Text = "Title:"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tbTitle
		'
		Me.tbTitle.BackColor = System.Drawing.SystemColors.Window
		Me.tbTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.tbTitle.Location = New System.Drawing.Point(80, 8)
		Me.tbTitle.MaxLength = 160
		Me.tbTitle.Name = "tbTitle"
		Me.tbTitle.Size = New System.Drawing.Size(632, 23)
		Me.tbTitle.TabIndex = 1
		Me.tbTitle.Visible = false
		Me.tbTitle.WordWrap = false
		AddHandler Me.tbTitle.TextChanged, AddressOf Me.TbTitleTextChanged
		AddHandler Me.tbTitle.Leave, AddressOf Me.TbTitleLeave
		'
		'label2
		'
		Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label2.Location = New System.Drawing.Point(8, 32)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(72, 23)
		Me.label2.TabIndex = 3
		Me.label2.Text = "Duration:"
		Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label3
		'
		Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label3.Location = New System.Drawing.Point(216, 32)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(72, 23)
		Me.label3.TabIndex = 4
		Me.label3.Text = "Media:"
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'label4
		'
		Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label4.Location = New System.Drawing.Point(424, 32)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(142, 23)
		Me.label4.TabIndex = 5
		Me.label4.Text = "Frames Per Second:"
		Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'mtbDuration
		'
		Me.mtbDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.mtbDuration.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
		Me.mtbDuration.Location = New System.Drawing.Point(80, 32)
		Me.mtbDuration.Mask = "00:00:00.000000000"
		Me.mtbDuration.Name = "mtbDuration"
		Me.mtbDuration.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
		Me.mtbDuration.RejectInputOnFirstFailure = true
		Me.mtbDuration.ResetOnPrompt = false
		Me.mtbDuration.ResetOnSpace = false
		Me.mtbDuration.Size = New System.Drawing.Size(128, 23)
		Me.mtbDuration.TabIndex = 3
		Me.mtbDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.mtbDuration.TextChanged, AddressOf Me.MtbDurationTextChanged
		'
		'tbFrameRate
		'
		Me.tbFrameRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.tbFrameRate.Location = New System.Drawing.Point(560, 32)
		Me.tbFrameRate.Name = "tbFrameRate"
		Me.tbFrameRate.Size = New System.Drawing.Size(128, 23)
		Me.tbFrameRate.TabIndex = 5
		AddHandler Me.tbFrameRate.TextChanged, AddressOf Me.TbFrameRateTextChanged
		'
		'comboMedia
		'
		Me.comboMedia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.comboMedia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboMedia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.comboMedia.FormattingEnabled = true
		Me.comboMedia.Items.AddRange(New Object() {"Other", "Blu-Ray", "DVD"})
		Me.comboMedia.Location = New System.Drawing.Point(288, 32)
		Me.comboMedia.Name = "comboMedia"
		Me.comboMedia.Size = New System.Drawing.Size(120, 24)
		Me.comboMedia.TabIndex = 4
		AddHandler Me.comboMedia.SelectedIndexChanged, AddressOf Me.ComboMediaSelectedIndexChanged
		'
		'bUpload
		'
		Me.bUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.bUpload.Location = New System.Drawing.Point(592, 552)
		Me.bUpload.Name = "bUpload"
		Me.bUpload.Size = New System.Drawing.Size(120, 32)
		Me.bUpload.TabIndex = 6
		Me.bUpload.Text = "Upload"
		Me.bUpload.UseVisualStyleBackColor = true
		AddHandler Me.bUpload.Click, AddressOf Me.BUploadClick
		'
		'bQuit
		'
		Me.bQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.bQuit.Location = New System.Drawing.Point(464, 552)
		Me.bQuit.Name = "bQuit"
		Me.bQuit.Size = New System.Drawing.Size(120, 32)
		Me.bQuit.TabIndex = 0
		Me.bQuit.Text = "Quit"
		Me.bQuit.UseVisualStyleBackColor = true
		AddHandler Me.bQuit.Click, AddressOf Me.BQuitClick
		'
		'lbFRList
		'
		Me.lbFRList.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lbFRList.FormattingEnabled = true
		Me.lbFRList.ItemHeight = 16
		Me.lbFRList.Items.AddRange(New Object() {"23.976", "24.0", "25.0", "29.97", "30.0", "50.0", "59.94", "60", "Custom"})
		Me.lbFRList.Location = New System.Drawing.Point(560, 32)
		Me.lbFRList.Name = "lbFRList"
		Me.lbFRList.Size = New System.Drawing.Size(128, 148)
		Me.lbFRList.TabIndex = 28
		Me.lbFRList.TabStop = false
		Me.lbFRList.Visible = false
		AddHandler Me.lbFRList.SelectedIndexChanged, AddressOf Me.LbFRListSelectedIndexChanged
		'
		'bFRDropDown
		'
		Me.bFRDropDown.Location = New System.Drawing.Point(688, 32)
		Me.bFRDropDown.Name = "bFRDropDown"
		Me.bFRDropDown.Size = New System.Drawing.Size(24, 23)
		Me.bFRDropDown.TabIndex = 29
		Me.bFRDropDown.TabStop = false
		Me.bFRDropDown.Text = "▼"
		Me.bFRDropDown.UseVisualStyleBackColor = true
		AddHandler Me.bFRDropDown.Click, AddressOf Me.BFRDropDownClick
		'
		'label7
		'
		Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label7.Location = New System.Drawing.Point(8, 56)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(184, 23)
		Me.label7.TabIndex = 30
		Me.label7.Text = "XML Content Preview:"
		Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lTbTitle
		'
		Me.lTbTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
		Me.lTbTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lTbTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lTbTitle.Location = New System.Drawing.Point(80, 8)
		Me.lTbTitle.Name = "lTbTitle"
		Me.lTbTitle.Size = New System.Drawing.Size(632, 23)
		Me.lTbTitle.TabIndex = 31
		Me.lTbTitle.Text = "Enter the title as it will appear on the ChapterDB website"
		Me.lTbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		AddHandler Me.lTbTitle.Click, AddressOf Me.LTbTitleClick
		'
		'lUploading
		'
		Me.lUploading.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
		Me.lUploading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lUploading.Font = New System.Drawing.Font("Microsoft Sans Serif", 36!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lUploading.Location = New System.Drawing.Point(208, 232)
		Me.lUploading.Name = "lUploading"
		Me.lUploading.Size = New System.Drawing.Size(312, 64)
		Me.lUploading.TabIndex = 32
		Me.lUploading.Text = "Uploading..."
		Me.lUploading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lUploading.Visible = false
		'
		'Upload
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(718, 590)
		Me.Controls.Add(Me.lUploading)
		Me.Controls.Add(Me.label7)
		Me.Controls.Add(Me.lbFRList)
		Me.Controls.Add(Me.bFRDropDown)
		Me.Controls.Add(Me.bQuit)
		Me.Controls.Add(Me.bUpload)
		Me.Controls.Add(Me.comboMedia)
		Me.Controls.Add(Me.tbFrameRate)
		Me.Controls.Add(Me.mtbDuration)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.tbTitle)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.textBox1)
		Me.Controls.Add(Me.lTbTitle)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "Upload"
		Me.Text = "Upload to ChapterDB"
		AddHandler Load, AddressOf Me.UploadLoad
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private lUploading As System.Windows.Forms.Label
	Private lTbTitle As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private tbFrameRate As System.Windows.Forms.TextBox
	Private bFRDropDown As System.Windows.Forms.Button
	Private lbFRList As System.Windows.Forms.ListBox
	Private bQuit As System.Windows.Forms.Button
	Private bUpload As System.Windows.Forms.Button
	Private comboMedia As System.Windows.Forms.ComboBox
	Private mtbDuration As System.Windows.Forms.MaskedTextBox
	Private tbTitle As System.Windows.Forms.TextBox
	Private label4 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private textBox1 As System.Windows.Forms.TextBox
End Class
