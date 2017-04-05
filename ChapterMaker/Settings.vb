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

Public Partial Class Settings
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
		AddHandler Application.Idle, AddressOf UpdateEditButtons
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Sets initial values on the form
	
	Sub SettingsLoad(sender As Object, e As EventArgs)
		'Me.AllowDrop=True
		Me.Text = AppName & " - Settings"
		DisplayPanel(0)
		Me.cbLanguage.Items.Clear
		Me.cbLanguage.Items.AddRange(Languages)
		Me.cbLanguage.SelectedIndex = cbLanguage.FindString(AppConfig.Language)
		If Me.cbLanguage.SelectedIndex < 0 Then Me.cbLanguage.SelectedIndex = 0
		Me.cbNumbers.Checked = AppConfig.AddNumbers
		Me.cbTimes.Checked = AppConfig.AddTimes
		Me.rbXML.Checked = True 
		If AppConfig.OutputType = Defaults.cmOutputType.OGM Then Me.rbOGM.Checked = True
		If AppConfig.OutputType = Defaults.cmOutputType.XML Then Me.rbXML.Checked = True
		If AppConfig.OutputType = Defaults.cmOutputType.TXT Then Me.rbTXT.Checked = True
		Me.tbOutputDir.Text = AppConfig.OutFilePath.Trim
		Me.tbTXTExt.Text = AppConfig.TXTExt.Trim
		Me.tbXMLExt.Text = AppConfig.XMLExt.Trim
		Me.tbOGMExt.Text = AppConfig.OGMExt.Trim
		If AppConfig.NoTitle = Defaults.cmNoTitle.NA Then Me.rbNA.Checked = True
		If AppConfig.NoTitle = Defaults.cmNoTitle.ChapterNum Then Me.rbChapterNum.Checked = True
		If AppConfig.NoTitle = Defaults.cmNoTitle.ChapterTime Then Me.rbChapterTime.Checked = True
		Me.cbInsert.Checked = AppConfig.ConfirmInsert
		Me.cbModify.Checked = AppConfig.ConfirmModify
		Me.cbDelete.Checked = AppConfig.ConfirmDelete
		Me.cbUpdates.Checked = AppConfig.UpdateCheck
		Me.cbUpload.Checked = AppConfig.ConfirmUpload
		Me.cbLoadAppend.Checked = AppConfig.LoadAppend
		Me.tbFrameRate.Text = AppConfig.FrameRate.ToString.Trim
		Me.tbApiKey.Text = AppConfig.ChapterDBKey.Trim
		Me.cbChapterDB.Checked = AppConfig.ChapterDBEnabled
		Me.tbUploader.Text = AppConfig.ChapterDBName.Trim
		Me.tbMkvToolNix.Text = AppConfig.MkvToolNixPath.Trim
		Me.treeView1.SelectedNode = Me.treeView1.Nodes(0)
		Me.treeView1.SelectedNode.Expand()
		Me.treeView1.Focus
		Me.toolStripStatusLabel1.Text = "Settings loaded from configuration file."
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Dialog box to get the default output directory
	
	Private Sub GetDefaultDirectory()
		Dim s1 As String
		Try
			s1 = System.IO.Path.GetDirectoryName(Me.tbOutputDir.Text.Trim)
		Catch
			s1 = ""
		End Try
		If s1.Trim.Length() < 1 Then s1 = "C:\"
		Me.folderBrowserDialog1.Description = "Output Folder"
		Me.folderBrowserDialog1.SelectedPath = s1
		Me.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
		Dim fdResult As DialogResult = Me.folderBrowserDialog1.ShowDialog()
		If (fdResult = DialogResult.OK) Or (fdResult = DialogResult.Yes) Then Me.tbOutputDir.Text = Me.folderBrowserDialog1.SelectedPath.Trim
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Dialog box to get the path to the MkvToolNix utilities
	
	Private Sub GetMkvToolNixDirectory()
		Dim s1 As String
		Try
			s1 = System.IO.Path.GetDirectoryName(Me.tbOutputDir.Text.Trim)
		Catch
			s1 = ""
		End Try
		If s1.Trim.Length() < 1 Then s1 = "C:\"
		Me.folderBrowserDialog1.Description = "Path to MkvToolNix Utilities"
		Me.folderBrowserDialog1.SelectedPath = s1
		Me.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
		Dim fdResult As DialogResult = Me.folderBrowserDialog1.ShowDialog()
		If (fdResult = DialogResult.OK) Or (fdResult = DialogResult.Yes) Then Me.tbMkvToolNix.Text = Me.folderBrowserDialog1.SelectedPath.Trim
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launches the default output directory dialog
	
	Sub TbOutputDirDoubleClick(sender As Object, e As EventArgs)
		GetDefaultDirectory()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launches the default output directory dialog
	
	Sub BDirectoryLookupClick(sender As Object, e As EventArgs)
		GetDefaultDirectory()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launches the MkvToolNix directory dialog
	
	Sub BMkvToolNixClick(sender As Object, e As EventArgs)
		GetMkvToolNixDirectory()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launches the MkvToolNix directory dialog
	Sub TbMkvToolNixDoubleClick(sender As Object, e As EventArgs)
		GetMkvToolNixDirectory()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Close the window without saving changes
	
	Sub BCancelClick(sender As Object, e As EventArgs)
		Me.Close
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Save the settings and close the window
	
	Sub BSaveClick(sender As Object, e As EventArgs)
		SaveSettings()
		Me.Close
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Save the settings
	
	Sub SaveSettings()
		AppConfig.OutputType = Defaults.cmOutputType.XML
		If Me.rbOGM.Checked Then AppConfig.OutputType = Defaults.cmOutputType.OGM
		If Me.rbTXT.Checked Then AppConfig.OutputType = Defaults.cmOutputType.TXT
		AppConfig.OutFilePath = Me.tbOutputDir.Text.Trim
		AppConfig.TXTExt = Me.tbTXTExt.Text.Trim
		AppConfig.XMLExt = Me.tbXMLExt.Text.Trim
		AppConfig.OGMExt = Me.tbOGMExt.Text.Trim
		AppConfig.AddNumbers = Me.cbNumbers.Checked
		AppConfig.AddTimes = Me.cbTimes.Checked
		AppConfig.NoTitle = Defaults.cmNoTitle.ChapterNum
		If Me.rbNA.Checked Then AppConfig.NoTitle = Defaults.cmNoTitle.NA
		If Me.rbChapterTime.Checked Then AppConfig.NoTitle = Defaults.cmNoTitle.ChapterTime
		AppConfig.ConfirmInsert = Me.cbInsert.Checked
		AppConfig.ConfirmModify = Me.cbModify.Checked
		AppConfig.ConfirmDelete = Me.cbDelete.Checked
		AppConfig.ConfirmUpload = Me.cbUpload.Checked
		AppConfig.UpdateCheck = Me.cbUpdates.Checked
		AppConfig.LoadAppend = Me.cbLoadAppend.Checked
		Try
			AppConfig.Language = Strings.Left(Me.cbLanguage.SelectedItem.ToString.Trim, 3).ToLower
		Catch
			AppConfig.Language = "und"
		End Try
		Dim FR As Double
		Try
			FR = Convert.ToDouble("0" & Me.tbFrameRate.Text.Trim)
		Catch
			FR = 0
		End Try
		If (FR < 10) Or (FR > 100) Then FR = 23.976
		AppConfig.FrameRate = FR
		AppConfig.ChapterDBEnabled = Me.cbChapterDB.Checked
		AppConfig.ChapterDBKey = Me.tbApiKey.Text.Trim
		AppConfig.ChapterDBName = Me.tbUploader.Text.Trim
		AppConfig.MkvToolNixPath = Me.tbMkvToolNix.Text.Trim
		If AppConfig.Write() Then
			Me.toolStripStatusLabel1.Text = "Settings saved to configuration file."
		Else
			Me.toolStripStatusLabel1.Text = "Error saving settings to configuration file."
			ErrorBox("Error saving settings to configuration file.")
		End If
End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Fix Default OGM File Extension
	
	Sub TbOGMExtLeave(sender As Object, e As EventArgs)
		Me.tbOGMExt.Text = AppConfig.FixExt(Me.tbOGMExt.Text.Trim, Defaults.DefOGM).Trim
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Fix Default XML File Extension
	
	Sub TbXMLExtLeave(sender As Object, e As EventArgs)
		Me.tbXMLExt.Text = AppConfig.FixExt(Me.tbXMLExt.Text.Trim, Defaults.DefXML).Trim
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Process Treeview Selection
	
	Sub TreeView1AfterSelect(sender As Object, e As TreeViewEventArgs)
		Dim nNode As Integer = 0
		If Me.treeView1.SelectedNode.Level < 1 Then
			nNode = 0
		Else
			nNode = Me.treeView1.SelectedNode.Index + 1
		End If
		DisplayPanel(nNode)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Display specified panel
	
	Sub DisplayPanel(ByVal pNum As Integer)
		Dim s1 As String
		Dim b1 As Boolean
		For I As Integer = 0 To 8 Step 1
			s1 = "group" & I.ToString.Trim
			b1 = False
			If I = pNum Then b1 = True
'			FindControl(Me, s1).Visible = b1
			Me.Controls.Find("group" & I.ToString.Trim,True)(0).Visible = b1
		Next
		Select Case pNum
		    Case 1
				Me.toolStripStatusLabel1.Text = "Settings related to automated update checking."
		    Case 2
				Me.toolStripStatusLabel1.Text = "Settings related to input files."
		    Case 3
				Me.toolStripStatusLabel1.Text = "Settings related to output files."
		    Case 4
				Me.toolStripStatusLabel1.Text = "Settings related to chapter title formatting."
		    Case 5
				Me.toolStripStatusLabel1.Text = "Settings related to pre-action user confirmations."
		    Case 6
				Me.toolStripStatusLabel1.Text = "Settings related to preferred program setting defaults."
		    Case 7
				Me.toolStripStatusLabel1.Text = "Settings related to ChapterDB integration."
		    Case 8
				Me.toolStripStatusLabel1.Text = "Settings related to external tools."
		    Case Else
				Me.toolStripStatusLabel1.Text = "Select the group of settings to edit."
		End Select
		Me.treeView1.Focus
	End Sub
	
'	'-----------------------------------------------------------------------------------------------------------------------------------------------------
'	'
'	'	Locate and return specified control
'	
'	Private Function FindControl(ByVal parent As Control, ByVal ident As String) As Control
'		Dim n As Integer
'		Dim tmpctrl As Control
'		Dim tmpctrl2 As Control
'		For n = 0 To parent.Controls.Count - 1
'			tmpctrl = parent.Controls(n)
'			If tmpctrl.Name = ident Then
'				Return parent.Controls(n)
'			ElseIf tmpctrl.Controls.Count > 0 Then
'				tmpctrl2 = FindControl(tmpctrl, ident)
'				If Not IsNothing(tmpctrl2) Then
'					Return tmpctrl2
'				End If
'			End If
'		Next
'		' Not found
'		Return Nothing
'	end function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Check for updates
	
	Sub BUpdateCheckClick(sender As Object, e As EventArgs)
		CheckForUpdates(True)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Select from list of standard frame rates
	
	Sub LbFRListLeave(sender As Object, e As EventArgs)
		CopyFR()
	End Sub

	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Select from list of standard frame rates
	
	Sub LbFRListSelectedIndexChanged(sender As Object, e As EventArgs)
		CopyFR()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Select from list of standard frame rates
	
	Sub CopyFR()
		If (Me.lbFRList.SelectedIndex >= 0) Then
			If Me.lbFRList.SelectedIndex < 8 Then
				Me.tbFrameRate.Text = Me.lbFRList.SelectedItem.ToString.Trim
			Else
				Me.tbFrameRate.Text = ""
			End If
		End If
		Me.tbFrameRate.Focus
		Me.lbFRList.Visible = False
	End Sub

	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Display drop down list of standard frame rates
	
	Sub BFRDropDownClick(sender As Object, e As EventArgs)
		If Me.lbFRList.Visible Then
			Me.tbFrameRate.Focus
			Me.lbFRList.Visible = False
		Else
			Me.lbFRList.ClearSelected
			Me.lbFRList.Visible = True
			'Me.lbFRList.Focus
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handles toolstrip save
	
	Sub SaveToolStripButtonClick(sender As Object, e As EventArgs)
		SaveSettings()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handles toolstrip cut
	
	Sub CutToolStripButtonClick(sender As Object, e As EventArgs)
		If TypeOf Me.ActiveControl Is TextBox Then
			Dim box As TextBox = TryCast(Me.ActiveControl, TextBox)
			If box.SelectedText <> "" Then
				Clipboard.SetText(box.SelectedText)
				box.SelectedText = ""
			End If
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handles toolstrip copy
	
	Sub CopyToolStripButtonClick(sender As Object, e As EventArgs)
		If TypeOf Me.ActiveControl Is TextBox Then
			Dim box As TextBox = TryCast(Me.ActiveControl, TextBox)
'			MsgBox("This is a text box.")
			If box.SelectedText <> "" Then
				Clipboard.SetText(box.SelectedText)
			End If
		ElseIf TypeOf Me.ActiveControl Is MaskedTextBox Then
			Dim box As MaskedTextBox = TryCast(Me.ActiveControl, MaskedTextBox)
			Clipboard.SetText(box.Text)
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handles toolstrip paste
	
	Sub PasteToolStripButtonClick(sender As Object, e As EventArgs)
		If TypeOf Me.ActiveControl Is TextBox Then
			Dim box As TextBox = TryCast(Me.ActiveControl, TextBox)
			Dim iData As IDataObject = Clipboard.GetDataObject()
        	'Check to see if the data is in a text format
        	If iData.GetDataPresent(DataFormats.Text) Then box.SelectedText = Clipboard.GetText()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handles toolstrip help
	
	Sub HelpToolStripButtonClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.TableOfContents, Nothing)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update the enabled status of the edit buttons
	
    Private Sub UpdateEditButtons(ByVal sender As Object, ByVal e As EventArgs)
    	If TypeOf Me.ActiveControl Is TextBox Then
    		Me.copyToolStripButton.Enabled = (TryCast(Me.ActiveControl, TextBox).SelectionLength > 0)
    		Me.cutToolStripButton.Enabled = (TryCast(Me.ActiveControl, TextBox).SelectionLength > 0)
    		Me.pasteToolStripButton.Enabled = Clipboard.ContainsText
    	Else
    		Me.copyToolStripButton.Enabled = False
    		Me.cutToolStripButton.Enabled = False
    		Me.pasteToolStripButton.Enabled = False
		End If
    End Sub
    
    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    '
    '	Check for invalid ChapterDB API Key
    
	Sub TbApiKeyTextChanged(sender As Object, e As EventArgs)
		Dim tStr As String = Me.tbApiKey.Text.Trim
		If (tStr.Length > 0) AndAlso (tStr.Contains(" ")) Then
			ErrorBox("API key cannot contain spaces.")
			Me.tbApiKey.Focus
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	
End Class
