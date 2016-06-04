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

Imports System.Xml
Imports System.Data

Public Partial Class WordsList
	
	Dim DS As New DataSet(FixCase.WORDCASEDSNAME)
	'
	'	TODO : Set up to use common dataset with FixCase.vb
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
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
	'	Read the words list file and load the form
	'
	'	TODO : Set up to use common dataset with FixCase.vb
	
	Sub WordsListLoad(sender As Object, e As EventArgs)
		Me.Text = AppName & " - Edit Words List"
		Dim FCFilePath As String = AppFixCase.XMLFilePath
		If FCFilePath.Trim.Length > 0 Then
			Try
				DS.Clear
				DS.ReadXml(AppFixCase.XMLFilePath)
				Me.dataGridView1.DataSource = DS.Tables(0)
				Me.toolStripStatusLabel1.Text = "Words list loaded from XML file."
			Catch
				Me.toolStripStatusLabel1.Text = "Error loading words list from XML file."
				ErrorBox("Unable to read the words list XML file.")
'				MsgBox("Unable to read the words list XML file.", MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
			End Try
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	(Cancel) Force a reload of the existing words list and exit
	
	Sub Button2Click(sender As Object, e As EventArgs)
		AppFixCase.Read
		Me.Close
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Write the words list and force a reload of the new list
	
	Sub Button1Click(sender As Object, e As EventArgs)
		SaveWords()
		Me.Close
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Write the words list and force a reload of the new list
	
	Sub SaveWords()
		Dim FCFilePath As String = AppFixCase.XMLFilePath
		If FCFilePath.Trim.Length > 0 Then
			Try
				DS.WriteXml(FCFilePath)
				Me.toolStripStatusLabel1.Text = "Words list saved to XML file."
'				MsgBox("Words list saved.", MsgBoxStyle.ApplicationModal and MsgBoxStyle.Information And MsgBoxStyle.OkOnly, "Save Words List")
			Catch
				Me.toolStripStatusLabel1.Text = "Error writing the words list XML file."
				ErrorBox("Error writing the words list XML file.")
'				MsgBox("Error writing the words list XML file.", MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
			End Try
		End If
		AppFixCase.Read
		AppFixCase.Write
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Force default values to avoid the word being saved with no "Always" setting
	
	Sub DataGridView1DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs)
		With e.Row
			.Cells("tWord").Value = ""
			.Cells("tAlways").Value = 0
		End With
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handles toolstrip save
	
	Sub SaveToolStripButtonClick(sender As Object, e As EventArgs)
		SaveWords()
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
End Class
