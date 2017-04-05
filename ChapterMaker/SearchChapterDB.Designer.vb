'
' Created by SharpDevelop.
' User: bob
' Date: 2016-09-27
' Time: 15:58
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class SearchChapterDB
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
		Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchChapterDB))
		Me.bSearch = New System.Windows.Forms.Button()
		Me.tbTitleSearch = New System.Windows.Forms.TextBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.dgvTitles = New System.Windows.Forms.DataGridView()
		Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvChapters = New System.Windows.Forms.DataGridView()
		Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.title = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.lSearching = New System.Windows.Forms.Label()
		Me.cbTimes = New System.Windows.Forms.CheckBox()
		Me.cbTitles = New System.Windows.Forms.CheckBox()
		Me.bImport = New System.Windows.Forms.Button()
		Me.bExit = New System.Windows.Forms.Button()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.helpProvider1 = New System.Windows.Forms.HelpProvider()
		CType(Me.dgvTitles,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.dgvChapters,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'bSearch
		'
		Me.bSearch.Location = New System.Drawing.Point(528, 8)
		Me.bSearch.Name = "bSearch"
		Me.bSearch.Size = New System.Drawing.Size(75, 23)
		Me.bSearch.TabIndex = 2
		Me.bSearch.Text = "Search"
		Me.bSearch.UseVisualStyleBackColor = true
		AddHandler Me.bSearch.Click, AddressOf Me.BSearchClick
		'
		'tbTitleSearch
		'
		Me.tbTitleSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.tbTitleSearch.Location = New System.Drawing.Point(112, 8)
		Me.tbTitleSearch.Name = "tbTitleSearch"
		Me.tbTitleSearch.Size = New System.Drawing.Size(408, 22)
		Me.tbTitleSearch.TabIndex = 1
		AddHandler Me.tbTitleSearch.KeyUp, AddressOf Me.TbTitleSearchKeyUp
		'
		'label1
		'
		Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label1.Location = New System.Drawing.Point(8, 8)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(100, 23)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Title to Search:"
		'
		'dgvTitles
		'
		Me.dgvTitles.AllowUserToAddRows = false
		Me.dgvTitles.AllowUserToDeleteRows = false
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvTitles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
		Me.dgvTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvTitles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10})
		Me.dgvTitles.Location = New System.Drawing.Point(8, 56)
		Me.dgvTitles.MultiSelect = false
		Me.dgvTitles.Name = "dgvTitles"
		Me.dgvTitles.ReadOnly = true
		Me.dgvTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvTitles.Size = New System.Drawing.Size(600, 504)
		Me.dgvTitles.TabIndex = 1
		AddHandler Me.dgvTitles.RowPostPaint, AddressOf Me.DgvAddLineNUmbers
		'
		'Column1
		'
		Me.Column1.DataPropertyName = "title"
		Me.Column1.HeaderText = "Title"
		Me.Column1.Name = "Column1"
		Me.Column1.ReadOnly = true
		Me.Column1.Width = 250
		'
		'Column2
		'
		Me.Column2.DataPropertyName = "createdBy"
		Me.Column2.HeaderText = "createdBy"
		Me.Column2.Name = "Column2"
		Me.Column2.ReadOnly = true
		Me.Column2.Visible = false
		'
		'Column3
		'
		Me.Column3.DataPropertyName = "createdDate"
		Me.Column3.HeaderText = "createdDate"
		Me.Column3.Name = "Column3"
		Me.Column3.ReadOnly = true
		Me.Column3.Visible = false
		'
		'Column4
		'
		Me.Column4.DataPropertyName = "updatedBy"
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
		Me.Column4.DefaultCellStyle = dataGridViewCellStyle2
		Me.Column4.HeaderText = "Media"
		Me.Column4.Name = "Column4"
		Me.Column4.ReadOnly = true
		Me.Column4.Width = 70
		'
		'Column5
		'
		Me.Column5.DataPropertyName = "updatedDate"
		Me.Column5.HeaderText = "updatedDate"
		Me.Column5.Name = "Column5"
		Me.Column5.ReadOnly = true
		Me.Column5.Visible = false
		'
		'Column6
		'
		Me.Column6.DataPropertyName = "lang"
		Me.Column6.HeaderText = "lang"
		Me.Column6.Name = "Column6"
		Me.Column6.ReadOnly = true
		Me.Column6.Visible = false
		'
		'Column7
		'
		Me.Column7.DataPropertyName = "version"
		Me.Column7.HeaderText = "version"
		Me.Column7.Name = "Column7"
		Me.Column7.ReadOnly = true
		Me.Column7.Visible = false
		'
		'Column8
		'
		Me.Column8.DataPropertyName = "extractor"
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
		Me.Column8.DefaultCellStyle = dataGridViewCellStyle3
		Me.Column8.HeaderText = "FPS"
		Me.Column8.Name = "Column8"
		Me.Column8.ReadOnly = true
		Me.Column8.Width = 65
		'
		'Column9
		'
		Me.Column9.DataPropertyName = "client"
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
		Me.Column9.DefaultCellStyle = dataGridViewCellStyle4
		Me.Column9.HeaderText = "Duration"
		Me.Column9.Name = "Column9"
		Me.Column9.ReadOnly = true
		Me.Column9.Width = 80
		'
		'Column10
		'
		Me.Column10.DataPropertyName = "confirmations"
		dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
		Me.Column10.DefaultCellStyle = dataGridViewCellStyle5
		Me.Column10.HeaderText = "Chapters"
		Me.Column10.Name = "Column10"
		Me.Column10.ReadOnly = true
		Me.Column10.Width = 60
		'
		'dgvChapters
		'
		Me.dgvChapters.AllowUserToAddRows = false
		Me.dgvChapters.AllowUserToDeleteRows = false
		Me.dgvChapters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvChapters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.time, Me.title})
		Me.dgvChapters.Location = New System.Drawing.Point(616, 104)
		Me.dgvChapters.MultiSelect = false
		Me.dgvChapters.Name = "dgvChapters"
		Me.dgvChapters.ReadOnly = true
		Me.dgvChapters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvChapters.Size = New System.Drawing.Size(458, 456)
		Me.dgvChapters.TabIndex = 2
		AddHandler Me.dgvChapters.RowPostPaint, AddressOf Me.DgvAddLineNUmbers
		'
		'time
		'
		Me.time.DataPropertyName = "time"
		Me.time.HeaderText = "Time"
		Me.time.Name = "time"
		Me.time.ReadOnly = true
		'
		'title
		'
		Me.title.DataPropertyName = "name"
		Me.title.HeaderText = "Title"
		Me.title.Name = "title"
		Me.title.ReadOnly = true
		Me.title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.title.Width = 300
		'
		'lSearching
		'
		Me.lSearching.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
		Me.lSearching.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lSearching.Font = New System.Drawing.Font("Microsoft Sans Serif", 36!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lSearching.Location = New System.Drawing.Point(408, 184)
		Me.lSearching.Name = "lSearching"
		Me.lSearching.Size = New System.Drawing.Size(304, 96)
		Me.lSearching.TabIndex = 0
		Me.lSearching.Text = "Searching..."
		Me.lSearching.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lSearching.Visible = false
		'
		'cbTimes
		'
		Me.cbTimes.Location = New System.Drawing.Point(912, 16)
		Me.cbTimes.Name = "cbTimes"
		Me.cbTimes.Size = New System.Drawing.Size(144, 24)
		Me.cbTimes.TabIndex = 3
		Me.cbTimes.Text = "Import Chapter Times"
		Me.cbTimes.UseVisualStyleBackColor = true
		'
		'cbTitles
		'
		Me.cbTitles.Checked = true
		Me.cbTitles.CheckState = System.Windows.Forms.CheckState.Checked
		Me.cbTitles.Location = New System.Drawing.Point(912, 40)
		Me.cbTitles.Name = "cbTitles"
		Me.cbTitles.Size = New System.Drawing.Size(144, 24)
		Me.cbTitles.TabIndex = 4
		Me.cbTitles.Text = "Import Chapter Titles"
		Me.cbTitles.UseVisualStyleBackColor = true
		'
		'bImport
		'
		Me.bImport.Location = New System.Drawing.Point(912, 72)
		Me.bImport.Name = "bImport"
		Me.bImport.Size = New System.Drawing.Size(75, 23)
		Me.bImport.TabIndex = 5
		Me.bImport.Text = "Import"
		Me.bImport.UseVisualStyleBackColor = true
		AddHandler Me.bImport.Click, AddressOf Me.BImportClick
		'
		'bExit
		'
		Me.bExit.Location = New System.Drawing.Point(1000, 72)
		Me.bExit.Name = "bExit"
		Me.bExit.Size = New System.Drawing.Size(75, 23)
		Me.bExit.TabIndex = 6
		Me.bExit.Text = "Cancel"
		Me.bExit.UseVisualStyleBackColor = true
		AddHandler Me.bExit.Click, AddressOf Me.BExitClick
		'
		'label2
		'
		Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label2.Location = New System.Drawing.Point(8, 32)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(120, 23)
		Me.label2.TabIndex = 7
		Me.label2.Text = "Search Results:"
		'
		'label3
		'
		Me.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.label3.Location = New System.Drawing.Point(624, 8)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(272, 88)
		Me.label3.TabIndex = 8
		Me.label3.Text = resources.GetString("label3.Text")
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'helpProvider1
		'
		Me.helpProvider1.HelpNamespace = "ChapterMakerHelp.chm"
		'
		'SearchChapterDB
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1080, 571)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.bExit)
		Me.Controls.Add(Me.bImport)
		Me.Controls.Add(Me.cbTitles)
		Me.Controls.Add(Me.cbTimes)
		Me.Controls.Add(Me.lSearching)
		Me.Controls.Add(Me.dgvChapters)
		Me.Controls.Add(Me.dgvTitles)
		Me.Controls.Add(Me.bSearch)
		Me.Controls.Add(Me.tbTitleSearch)
		Me.Controls.Add(Me.label1)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "SearchChapterDB"
		Me.Text = "Search ChapterDB Site"
		AddHandler Shown, AddressOf Me.SearchChapterDBShown
		CType(Me.dgvTitles,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.dgvChapters,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private helpProvider1 As System.Windows.Forms.HelpProvider
	Private label3 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private bExit As System.Windows.Forms.Button
	Private bImport As System.Windows.Forms.Button
	Private cbTitles As System.Windows.Forms.CheckBox
	Private cbTimes As System.Windows.Forms.CheckBox
	Private Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvTitles As System.Windows.Forms.DataGridView
	Private title As System.Windows.Forms.DataGridViewTextBoxColumn
	Private time As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgvChapters As System.Windows.Forms.DataGridView
	Private lSearching As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private tbTitleSearch As System.Windows.Forms.TextBox
	Private bSearch As System.Windows.Forms.Button
End Class
