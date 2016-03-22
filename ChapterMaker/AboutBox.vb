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

Public Partial Class AboutBox
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Sub AboutBoxLoad(sender As Object, e As EventArgs)
		Me.Text = String.Format("About {0}", AppName)
		Dim s1 As String = AppName & " - " & appDescription & "." & Environment.NewLine _
			& AppCopyright & " " & appCompany & " <"
		Dim a1 As Integer = s1.Length
		s1 &= AppEmail & ">" & Environment.NewLine & Environment.NewLine _
        	& "This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published " _
        	& "by the Free Software Foundation, either version 3 of the License, or (at your option) any later version." _
        	& Environment.NewLine & Environment.NewLine _
        	& "This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of " _
        	& "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details." _
        	& Environment.NewLine & Environment.NewLine _
        	& "You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>." _
        	& Environment.NewLine
		Me.richTextBox1.Text = s1
		Me.richTextBox1.Select(0, Strings.Len(AppName))
		Me.richTextBox1.SelectionColor = Color.Black
		Me.richTextBox1.SelectionFont = New Font(Me.richTextBox1.Font.Name, 12, FontStyle.Bold)
		Me.richTextBox1.Select(Me.richTextBox1.Text.Length, 0)
		Me.lBuild.Text = "Build: " & AppVersion(True)
	End Sub
	
	Sub Button1Click(sender As Object, e As EventArgs)
		Me.Close
	End Sub
	
	Sub RichTextBox1LinkClicked(sender As Object, e As LinkClickedEventArgs)
		Process.Start(e.LinkText.Trim)
		Me.button1.Focus
	End Sub
	
End Class
