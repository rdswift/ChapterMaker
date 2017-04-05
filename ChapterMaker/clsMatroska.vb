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

Imports System.IO
Imports System.Text.RegularExpressions

Public Class Matroska
	
	''' <summary>
	''' The full path and file name of the Matroska file
	''' </summary>
	Public FileName As String				'Full path and file name of Matroska file
	
	''' <summary>
	''' The full path and file name of the chapters information XML file.
	''' </summary>
	Public ChaptersXML As String			'Chapters XML file name
	
	''' <summary>
	''' The duration of the video in the form hh:mm:ss.nnnnnnnnn.
	''' </summary>
	Public Duration As String				'Duration of Track 1 in the form hh:mm:ss.nnnnnnnnn
	
	''' <summary>
	''' The title setting from the Matroska file
	''' </summary>
	Public Title As String					'Title setting from Matroska file
	
	''' <summary>
	''' The full path to the MkvToolNix utility files.
	''' </summary>
	Public MkvToolNixDir As String			'Path to MkvToolNix utilities
	
	''' <summary>
	''' The video's frames per second.
	''' </summary>
	Public FPS As Double					'Video frames per second
	
	''' <summary>
	''' The name of the MkvToolNix extraction utility.
	''' </summary>
	Private Const MKVEXTRACT = "mkvextract.exe"
	
	''' <summary>
	''' The name of the MkvToolNix property editor utility.
	''' </summary>
	Private Const MKVPROPEDIT = "mkvpropedit.exe"
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Creates a new Matroska file information collection.
	''' </summary>
	''' 
	Public Sub New()
		ResetAll()
	End Sub
	
	
	''' <summary>
	''' Creates a new Matroska file information collection.
	''' </summary>
	''' <param name="MkvFile">The full path and filename of the Matroska file.</param>
	''' 
	Public Sub New(MkvFile As String)
		ResetAll()
		Me.FileName = MkvFile.Trim
	End Sub
	
	
	''' <summary>
	''' Creates a new Matroska file information collection.
	''' </summary>
	''' <param name="MkvFile">The full path and filename of the Matroska file.</param>
	''' <param name="ToolNixDir">The full path to the MkvToolNix utility files.</param>
	''' 
	Public Sub New(MkvFile As String, ToolNixDir As String)
		ResetAll()
		Me.FileName = MkvFile.Trim
		Me.MkvToolNixDir = ToolNixDir.Trim
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Resets all properties of the Matroska object.
	''' </summary>
	''' 
	Public Sub ResetAll()
		CleanUp()
		Me.Title = ""
		Me.FileName = ""
		Me.ChaptersXML = ""
		Me.Duration = "00:00:00.000000000"
		Me.MkvToolNixDir = ""
		Me.FPS = 0
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Updates the chapters information in the specified Matroska file.
	''' </summary>
	''' <param name="MkvFileName">The full path and filename of the Matroska file.</param>
	''' 
	Public Sub WriteChapters(MkvFileName As String)
		Dim s1, sFN As String
		Dim em As String = ""
		Me.MkvToolNixDir = Me.MkvToolNixDir.Trim
		sFN = MkvFileName.Trim
		Me.ChaptersXML = Me.ChaptersXML.Trim
		
'		If Me.MkvToolNixDir.Equals("") Then em &= "Missing path to MKVToolNix utilities." & Environment.NewLine  
		If sFN.Equals("") Then em &= "Missing MKV output file name." & Environment.NewLine
		If Me.ChaptersXML.Equals("") Then em &= "Missing MKV chapters file name." & Environment.NewLine
		If (Not System.IO.File.Exists(sFN)) Then em &= "MKV file not found." & Environment.NewLine
		If (Not System.IO.File.Exists(Me.ChaptersXML)) Then em &= "MKV chapters file not found." & Environment.NewLine
		If (Not Me.MkvToolNixDir.Equals("")) And (Not Me.MkvToolNixDir.EndsWith("\")) Then Me.MkvToolNixDir &= "\"
		s1 = Me.MkvToolNixDir & MKVPROPEDIT
		If (Not System.IO.File.Exists(s1)) Then em &= "Unable to find MKVToolNix " & MKVPROPEDIT & " utility." & Environment.NewLine
		Dim proc As System.Diagnostics.Process = Nothing
		Try
			If em.Equals("") Then
				proc = New System.Diagnostics.Process()
				proc.StartInfo.Arguments = """" & Me.FileName & """ --chapters """ & Me.ChaptersXML & """"
				proc.StartInfo.FileName = Me.MkvToolNixDir & MKVPROPEDIT
				proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
				'				proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
				proc.StartInfo.RedirectStandardOutput = False
				proc.Start()
				Do
					If Not proc.HasExited Then
						proc.Refresh()
					End If
				Loop While Not proc.WaitForExit(500)
				If (proc.ExitCode <> 0) Then
					em &= "Chapter update exit code:" & proc.ExitCode.ToString.Trim & Environment.NewLine _
						& Environment.NewLine & "Program Call: " & proc.StartInfo.FileName & " " & proc.StartInfo.Arguments & Environment.NewLine
				Else
					If System.IO.File.Exists(Me.ChaptersXML) Then System.IO.File.Delete(Me.ChaptersXML)
				End If
				proc.Close()
			End If
		Catch
		Finally
			If Not proc Is Nothing Then proc.Close()
		End Try
		If (Not em.Equals("")) Then
			MessageBox.Show("Error updating Matroska file." & Environment.NewLine & Environment.NewLine & em, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Reads the information from the Matroska file into the Matroska object.
	''' </summary>
	''' 
	Public Sub Read()
		Dim s1 As String
		Dim em As String = ""
		Me.MkvToolNixDir = Me.MkvToolNixDir.Trim
		Me.FileName = Me.FileName.Trim
'		If Me.MkvToolNixDir.Equals("") Then em &= "Missing path to MKVToolNix utilities." & Environment.NewLine  
		If Me.FileName.Equals("") Then em &= "Missing MKV file name." & Environment.NewLine
		If (Not System.IO.File.Exists(Me.FileName)) Then Exit Sub
		If (Not Me.MkvToolNixDir.Equals("")) And (Not Me.MkvToolNixDir.EndsWith("\")) Then Me.MkvToolNixDir &= "\"
		s1 = Me.MkvToolNixDir & MKVEXTRACT
		If (Not System.IO.File.Exists(s1)) Then em &= "Unable to find MKVToolNix " & MKVEXTRACT & " utility." & Environment.NewLine
		Dim proc As System.Diagnostics.Process = Nothing
		Try
			If em.Equals("") Then
				Dim s2 As String = Me.FileName & ".tags.xml"
				proc = New System.Diagnostics.Process()
				proc.StartInfo.Arguments = " tags """ & Me.FileName & """ -r """ & s2 & """"
				proc.StartInfo.FileName = Me.MkvToolNixDir & MKVEXTRACT
				proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
'				proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
				proc.StartInfo.RedirectStandardOutput = False
				proc.Start()
				Do
					If Not proc.HasExited Then
						proc.Refresh()
					End If
				Loop While Not proc.WaitForExit(500)
				If (proc.ExitCode <> 0) Then em &= "Tag extraction exit code:" & proc.ExitCode.ToString.Trim & Environment.NewLine
				proc.Close()
				Dim frames As Int32 = 0
				Dim tagType As String = ""
				Dim tagVal As String = ""
				Me.Duration = ""
				If System.IO.File.Exists(s2) Then
					Me.Title = Path.GetFileNameWithoutExtension(Me.FileName)
					'Read the tag information
					Dim regex1 As String = "<Name>([^<]+)</"
					Dim regex2 As String = "<String>([^<]+)</"
					Dim regex3 As String = ">([0-9]+:[0-9]+:[0-9\.]+)<"
					Dim readlines() As String = File.ReadAllLines(s2)
					Dim s4 As String = ""
					Dim matches As MatchCollection
					For Each s3 As String In readlines
						If (Me.Duration.Trim.Equals("")) Or (Me.FPS = 0) Then
							matches = Regex.Matches(s3, regex1, RegexOptions.IgnoreCase)
							For Each match As Match In matches
								tagType = match.Groups(1).Value.Trim
								tagVal = ""
							Next
							matches = Regex.Matches(s3, regex2, RegexOptions.IgnoreCase)
							For Each match As Match In matches
								tagVal = match.Groups(1).Value.Trim
							Next
							If (Not tagVal.Trim.Equals("")) Then
								If (tagType.Trim.Equals("NUMBER_OF_FRAMES")) And (Not tagVal.Trim.Equals("")) And (frames = 0) Then
									frames = Convert.ToInt32(tagVal)
								End If
								If (tagType.Trim.Equals("DURATION")) And (Not tagVal.Trim.Equals("")) And (Duration.Trim.Equals("")) Then
									Duration = tagVal.Trim
								End If
								tagType = ""
								tagVal = ""
							End If
							If (frames <> 0) And (Not Duration.Trim.Equals("")) And (FPS = 0) Then
								Dim dur As Double = 0
								Dim digits() As String = Split(Duration, ":")
								Dim multiplier As Double = 1
								Dim J As Integer = 0
								For I As Integer = UBound(digits) To LBound(digits) Step - 1
									J += 1
									If (J < 4) Then
										If (digits(I).Trim.Length() < 1) Then digits(I) = "0" 
										dur += (Convert.ToDouble(digits(I)) * multiplier)
										multiplier *= 60
									End If
								Next
								If (dur > 0) And (frames > 0) Then
									FPS = Convert.ToDouble(frames) / dur
								End If
								'									Exit For
							End If
						End If
					Next
					System.IO.File.Delete(s2)
				End If
		
		
				Me.ChaptersXML = ""	
				s2 = Me.FileName & ".chapters.xml"
				proc = New System.Diagnostics.Process()
				proc.StartInfo.Arguments = " chapters """ & Me.FileName & """ -r """ & s2 & """"
				proc.StartInfo.FileName = Me.MkvToolNixDir & MKVEXTRACT
				proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
'				proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
				proc.StartInfo.RedirectStandardOutput = False
				proc.Start()
				Do
					If Not proc.HasExited Then
						proc.Refresh()
					End If
				Loop While Not proc.WaitForExit(500)
				If (proc.ExitCode <> 0) Then em &= "Chapter extraction exit code:" & proc.ExitCode.ToString.Trim & Environment.NewLine
				proc.Close()
				Me.ChaptersXML = s2
			End If
		Catch
		Finally
			If Not proc Is Nothing Then proc.Close()
		End Try
		If Me.Duration.Trim.Equals("") Then Me.Duration = "00:00:00.000000000"
		If (Not em.Equals("")) Then
			MessageBox.Show("Error reading Matroska file." & Environment.NewLine & Environment.NewLine & em, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Cleans up temporary files.  Removes the chapters temporary XML file.
	''' </summary>
	''' 
	Public Sub CleanUp()
		Try
			System.IO.File.Delete(Me.ChaptersXML)
		Catch ex As Exception
			'Do nothing with exception
		End Try
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
End Class
