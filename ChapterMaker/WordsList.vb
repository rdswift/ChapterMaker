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
' Foobar is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
'
' -----------------------------------------------------------------------

Imports System.Xml
Imports System.Data

Public Partial Class WordsList
	
	Dim DS As New DataSet(FixCase.WORDCASEDSNAME)
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Sub WordsListLoad(sender As Object, e As EventArgs)
		Me.Text = AppName & " - Edit Words List"
		Dim FCFilePath As String = AppFixCase.XMLFilePath
		If FCFilePath.Trim.Length > 0 Then
			Try
				DS.Clear
				DS.ReadXml(AppFixCase.XMLFilePath)
				Me.dataGridView1.DataSource = DS.Tables(0)
			Catch
				MsgBox("Unable to read the Words XML file.", MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
			End Try
		End If
	End Sub
	
	Sub Button2Click(sender As Object, e As EventArgs)
		AppFixCase.Read
		Me.Close
	End Sub
	
	Sub Button1Click(sender As Object, e As EventArgs)
		Dim FCFilePath As String = AppFixCase.XMLFilePath
		If FCFilePath.Trim.Length > 0 Then
			Try
				DS.WriteXml(FCFilePath)
			Catch
				MsgBox("Error writing XML file.", MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
			End Try
		End If
		AppFixCase.Read
		AppFixCase.Write
		Me.Close
	End Sub
	
	Sub DataGridView1DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs)
		With e.Row
			.Cells("tWord").Value = ""
			.Cells("tAlways").Value = 0
		End With
	End Sub
End Class
