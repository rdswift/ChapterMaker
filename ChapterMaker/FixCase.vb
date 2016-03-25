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

Public Class FixCase
	
	Public Const WORDCASEDSNAME = "WordDataSet"
	Public Const ProperCaseSeparators = """' ,.<>/;:!@#$%^&*()-=+_|\`~"
	Private WordCaseDS As New DataSet(WORDCASEDSNAME)
	
	Private FCFileName As String = "tWordCase.xml"
	Private FCFilePath As String
	Private StartValues() As String = { "a", "an", "and", "as", "at", "for", "I", "in", "is", "of", "on", "or", "the", "to", _
		"A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I", "J.", "K.", "L.", "M.", "N.", "O.", "P.", "Q.", "R.", "S.", "T.", "U.", "V.", "W.", "X.", "Y.", "Z.", _
		"CIA", "FBI", "KGB", "NASA", "NSA", "HQ" }
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Public Sub New()
		FCFilePath = Me.GetFileName()
		If FCFilePath.Trim.Length < 1 Then
			MsgBox("Error accessing the application word case data file.", MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
		End If
		Read()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
'	Public Property DS() As DataSet
'		Get
'			Return WordCaseDS
'		End Get
'		Set(ByVal value As DataSet)
'			WordCaseDS = value
'		End Set
'	End Property
	
	Public ReadOnly Property XMLFilePath() As String
		Get
			Return FCFilePath
		End Get
	End Property
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Checks standard locations for words list file and creates file if none exists
	
	Private Function GetFileName() As String
		Dim s1, s2, s3, sFilePath As String
		
		s1 = Application.StartupPath
		If Not s1.EndsWith("\") Then s1 &= "\"
		s1 &= FCFileName
		
		s2 = Application.CommonAppDataPath
		If Not s2.EndsWith("\") Then s2 &= "\"
		s2 &= "ChapterMaker\" & FCFileName
		
		sFilePath = ""
		Try
			If System.IO.File.Exists(s1) Then sFilePath = s1
		Catch
			sFilePath = ""
		End Try
		
		If sFilePath.Trim.Length < 1 Then
			Try
				If System.IO.File.Exists(s2) Then sFilePath = s2
			Catch
				sFilePath = ""
			End Try
		End If
		
		s3 = "<?xml version=""1.0"" standalone=""yes""?>" & Environment.NewLine & "<" & WORDCASEDSNAME & ">" & Environment.NewLine
		For I As Integer = LBound(StartValues) To UBound(StartValues) Step 1
        	s3 &= "  <tWordCase>" & Environment.NewLine _
        		& "    <tWord>" & StartValues(I) & "</tWord>" & Environment.NewLine _
        		& "    <tAlways>0</tAlways>" & Environment.NewLine _
        		& "  </tWordCase>" & Environment.NewLine
		Next
		s3 &= "</" & WORDCASEDSNAME & ">" & Environment.NewLine
		
		If sFilePath.Trim.Length < 1 Then
			Try
				System.IO.File.WriteAllText(s1, s3)
				sFilePath = s1
			Catch
				sFilePath = ""
			End Try
		End If

		If sFilePath.Trim.Length < 1 Then
			Try
				System.IO.File.WriteAllText(s2, s3)
				sFilePath = s2
			Catch
				sFilePath = ""
			End Try
		End If

		Return sFilePath
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Reads the contents of the words list file
	
	Public Sub Read()
		If FCFilePath.Trim.Length > 0 Then
			Try
				WordCaseDS.Clear
				WordCaseDS.ReadXml(FCFilePath)
			Catch
				WordCaseDS = New DataSet(WORDCASEDSNAME)
				For I = LBound(StartValues) To UBound(StartValues) Step 1
					Dim myRow As DataRow = WordCaseDS.Tables(0).NewRow
					myRow("tWord") = StartValues(I)
					myRow("tAlways") = 0
					WordCaseDS.Tables(0).Rows.Add(myRow)
				Next
			End Try
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Writes the updated words list file
	
	Public Sub Write()
		If FCFilePath.Trim.Length > 0 Then
			Try
				WordCaseDS.WriteXml(FCFilePath)
			Catch
				MsgBox("Error writing XML file.", MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
			End Try
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Converts the supplied string to proper title case
	
	Public Function MakeProper(ByVal TitleToFix As String) As String
		Dim LB, UB, AC, iStart, iEnd, iTest As Integer
		Dim TestWord, sOld, sNew, sBefore, sAfter As String
		Dim SpaceTest As Boolean
		
		If (TitleToFix.Trim.Length > 0) Then
			
			sNew = StrConv(TitleToFix.Trim, VbStrConv.ProperCase)
			
			''''''''''''''''''''''''''''''''''''''
			' Process characters after separators
			''''''''''''''''''''''''''''''''''''''
			LB = 1
			UB = Len(ProperCaseSeparators)
			For AC = LB To UB Step 1
				sOld = sNew
				TestWord = Mid(ProperCaseSeparators, AC, 1)
				iStart = 1
				iEnd = sOld.Trim.Length
				Do While iStart < iEnd
					sOld = sNew
					iStart = InStr(iStart, sOld, TestWord, CompareMethod.Text)
					If (iStart < 1) Then
						iStart = iEnd
					Else
						sNew = Left(sOld, iStart)
						iStart = iStart + 1
						If (iStart <= iEnd) Then sNew = sNew & UCase(Mid(sOld, iStart, 1))
						If (iStart < iEnd) Then sNew = sNew & Mid(sOld, iStart + 1)
					End If
				Loop
			Next
			
			''''''''''''''''''''''''''''''''''''''
			' Process characters after numbers
			''''''''''''''''''''''''''''''''''''''
			LB = 0
			UB = 9
			For AC = LB To UB Step 1
				sOld = sNew
				TestWord = AC.ToString.Trim
				iStart = 1
				iEnd = sOld.Trim.Length
				Do While iStart < iEnd
					sOld = sNew
					iStart = InStr(iStart, sOld, TestWord, CompareMethod.Text)
					If (iStart < 1) Then
						iStart = iEnd
					Else
						sNew = Left(sOld, iStart)
						iStart = iStart + 1
						If (iStart <= iEnd) Then sNew = sNew & LCase(Mid(sOld, iStart, 1))
						If (iStart < iEnd) Then sNew = sNew & Mid(sOld, iStart + 1)
					End If
				Loop
			Next
			
			''''''''''''''''''''''''''''''''''''''
			' Process spaced words
			''''''''''''''''''''''''''''''''''''''
			For Each myRow As DataRow In WordCaseDS.Tables(0).Select("tAlways < 1", "tWord")
				sOld = sNew
				TestWord = myRow("tWord").ToString
				'Debug.Print "Spaced Word: " & TestWord
				iStart = 1
				iEnd = sOld.Length
				Do While iStart <= iEnd
					sOld = sNew
					SpaceTest = False
					iStart = InStr(iStart, sOld, TestWord, CompareMethod.Text)
					If (iStart < 1) Then
						iStart = iEnd
					Else
						If (iStart < 2) Then
							SpaceTest = True
						Else
							sBefore = Mid(sOld, iStart - 1, 1)
							SpaceTest = (InStr(1, ProperCaseSeparators, sBefore) > 0)
						End If
						iTest = iStart + TestWord.Length
						If (iEnd > iTest) Then
							sAfter = Mid(sOld, iTest, 1)
							SpaceTest = SpaceTest And (InStr(1, ProperCaseSeparators, sAfter) > 0)
						End If
					End If
					If SpaceTest Then
						sNew = ""
						If (iStart > 1) Then sNew = Left(sOld, iStart - 1)
						sNew = sNew & TestWord
						If (iEnd >= iStart + TestWord.Length) Then sNew = sNew & Mid(sOld, iStart + TestWord.Length)
					End If
					iStart = iStart + TestWord.Length
				Loop
			Next
			
			''''''''''''''''''''''''''''''''''''''
			' Process characters after apostrophes
			''''''''''''''''''''''''''''''''''''''
			sOld = sNew
			TestWord = "'"
			iStart = 1
			iEnd = sOld.Length
			Do While iStart < iEnd
				sOld = sNew
				SpaceTest = False
				iStart = InStr(iStart, sOld, TestWord, CompareMethod.Text)
				If (iStart < 1) Then
					iStart = iEnd
				Else
					sNew = ""
					sNew = Left(sOld, iStart)
					If (iStart > 1) Then
						sBefore = Mid(sOld, iStart - 1, 1)
					Else
						sBefore = " "
					End If
					If (iStart < iEnd) Then
						If TestChar(sBefore) Then
							iTest = iStart
							Do While (iTest < iEnd)
								iTest = iTest + 1
								sAfter = Mid(sOld, iTest, 1)
								If TestChar(sAfter) Then
									sNew = sNew & sAfter.ToLower
									iStart = iStart + 1
								Else
									iTest = iEnd
								End If
							Loop
						Else
							sNew = sNew & Mid(sOld, iStart + 1, 1).ToUpper
							iStart = iStart + 1
						End If
						If (iStart < iEnd - 1) Then sNew = sNew & Mid(sOld, iStart + 1)
					End If
					iStart = iStart + 1
				End If
			Loop
			
			''''''''''''''''''''''''''''''''''''''
			' Process non-spaced words
			''''''''''''''''''''''''''''''''''''''
			For Each myRow As DataRow In WordCaseDS.Tables(0).Select("tAlways > 0", "tWord")
				sOld = sNew
				TestWord = myRow("tWord").ToString
				iStart = 1
				iEnd = sOld.Length
				Do While iStart <= iEnd
					sOld = sNew
					SpaceTest = False
					iStart = InStr(iStart, sOld, TestWord, CompareMethod.Text)
					If (iStart < 1) Then
						iStart = iEnd
					Else
						sNew = ""
						If (iStart > 1) Then sNew = Left(sOld, iStart - 1)
						sNew = sNew & TestWord
						If (iEnd >= iStart + TestWord.Length) Then sNew = sNew & Mid(sOld, iStart + TestWord.Length)
					End If
					iStart = iStart + TestWord.Length
				Loop
			Next
			Return Replace(sNew, Left(sNew, 1), Left(sNew, 1).ToUpper, 1, 1, CompareMethod.Text)
		Else
			Return ""
		End If
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Tests if supplied character is a letter
	
	Private Function TestChar(ByVal CharToTest As String) As Boolean
		Dim myChar As string
		If CharToTest.length < 1 Then
			myChar = " "
		Else
			myChar = Left(CharToTest & "", 1)
		End If
		TestChar = False
		myChar = LCase(myChar)
		If (myChar >= "a") And (myChar <= "z") Then TestChar = True
		
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
End Class
