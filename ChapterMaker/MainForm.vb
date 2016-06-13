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
Imports System.Data

Public Partial Class MainForm
	Enum FileType
		Undefined = -1
		TXT = 3
		OGM = 2
		XML = 1
	End Enum
	
	Const BLANKTIME = "00:00:00.00000"
	
	Private fromIndex As Integer = 0
	Private dragIndex As Integer = 0
	Private dragRect As Rectangle
	
	Dim cTimes(), cTitles() As String
	Dim cTimesType, cTitlesType As Integer
	Dim ChaptersDS As DataSet
	Dim cOutputType As FileType
	
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
	'	Initialize the form
	
	Sub MainFormLoad(sender As Object, e As EventArgs)
		Me.Text = appName & " v" & String.Format("{0}.{1:00}", vMajor, vMinor)
		Me.AllowDrop=True
		Me.cbLanguage.Items.Clear
		Me.cbLanguage.Items.AddRange(Languages)
		Me.cbOutputType.Items.Clear
		Me.cbOutputType.Items.Add("XML (Extensible Markup)")
		Me.cbOutputType.Items.Add("OGM (OGG Media)")
		Me.cbOutputType.Items.Add("TXT (Plain Text)")
		AppConfig = New Defaults
		AppConfig.Read()
		ChaptersDS = New DataSet()
		Dim DT As New DataTable()
		Dim DC1 As New DataColumn("dgNumber", Type.GetType("System.Int32"))
		Dim DC2 As New DataColumn("dgTime", Type.GetType("System.String"))
		Dim DC3 As New DataColumn("dgTitle", Type.GetType("System.String"))
		DT.Columns.Add(DC1)
		DT.Columns.Add(DC2)
		DT.Columns.Add(DC3)
		ChaptersDS.Tables.Add(DT)
		Me.dataGridView1.DataSource = ChaptersDS.Tables(0)
		Me.cOutputType = CType(AppConfig.OutputType, FileType)
		ResetAll
		AppFixCase = New FixCase
		AppFixCase.Read()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Once form is displayed, initiate check for updates
	
	Sub MainFormShown(sender As Object, e As EventArgs)
        Application.DoEvents()
        If AppConfig.UpdateCheck Then CheckForUpdates()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle drag 'n' drop events for chapter titles input file
	
	Sub TextBox1DragDrop(sender As Object, e As DragEventArgs)
		Dim myJunk As String
		Dim theFiles() As String = CType(e.Data.GetData("FileDrop", True), String())
		myjunk=theFiles(0).ToString.Trim
		Try
			If System.IO.Directory.Exists(myJunk) Then
				myJunk=""
			End If
		Catch
			myJunk=""
		End Try
		If Len(myJunk.Trim) > 0 Then
			Me.tbFileTitles.Text = myJunk
		Else
			ErrorBox("Not a valid file.")
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Sub TextBox1DragEnter(sender As Object, e As DragEventArgs)
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle drag 'n' drop events for chapter times input file
	
	Sub TextBox2DragDrop(sender As Object, e As DragEventArgs)
		Dim myJunk As String
		Dim theFiles() As String = CType(e.Data.GetData("FileDrop", True), String())
		myjunk=theFiles(0).ToString.Trim
		Try
			If System.IO.Directory.Exists(myJunk) Then
				myJunk=""
			End If
		Catch
			myJunk=""
		End Try
		If Len(myJunk.Trim) > 0 Then
			Me.tbFileTimes.Text = myJunk
		Else
			ErrorBox("Not a valid file.")
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Sub TextBox2DragEnter(sender As Object, e As DragEventArgs)
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle drag 'n' drop events for the output file
	
	Sub TextBox3DragDrop(sender As Object, e As DragEventArgs)
		Dim myJunk As String
		Dim theFiles() As String = CType(e.Data.GetData("FileDrop", True), String())
		myjunk=theFiles(0).ToString.Trim
		Try
			If System.IO.Directory.Exists(myJunk) Then
				myJunk=""
			End If
		Catch
'			myJunk=""
		End Try
		If Len(myJunk.Trim) > 0 Then
			Me.tbFileOutput.Text = myJunk
		Else
			ErrorBox("Not a valid file.")
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Sub TextBox3DragEnter(sender As Object, e As DragEventArgs)
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle double click to launch file dialog for chapter titles input file
	
	Sub TextBox1DoubleClick(sender As Object, e As EventArgs)
		SelectTitlesFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch file dialog for input files
	
	Private Function InputFileDialog(myStart As String) As String
		Dim myFile As String
		Dim s1 As String
		myFile=""
        Me.OpenFileDialog1.DefaultExt = ".*"
        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.Multiselect = False
        Me.OpenFileDialog1.Title = "Select Input File"
        If InStr(myStart, "\") > 0 Then s1 = System.IO.Path.GetDirectoryName(myStart) Else s1 = ""
        If s1 = "" Then s1 = "C:\"
        Me.OpenFileDialog1.InitialDirectory = s1
        Me.OpenFileDialog1.FileName = ""
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then myFile = Me.OpenFileDialog1.FileName
		Return myFile
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch file dialog for outnput file
	
	Private Function OutputFileDialog() As Boolean
		Dim s1, s2, s3, s4, myJunk As String
		s1 = ""
		s2 = ""
		
		' Set file type and associated filter
		s3 = AppConfig.XMLExt.Trim
		s4 = "XML Files|*." & s3 & "|All Files|*.*"
		If Me.cOutputType = FileType.OGM Then
			s3 = AppConfig.OGMExt.Trim
			s4 = "OGM Files|*." & s3 & "|All Files|*.*"
		End If
		If Me.cOutputType = FileType.TXT Then
			s3 = AppConfig.TXTExt.Trim
			s4 = "Text Files|*." & s3 & "|All Files|*.*"
		End If
		
		' Get output file name from existing entry if possible or set to default
		Try
			s1 = System.IO.Path.GetFileName(Me.tbFileOutput.Text.Trim)
		Catch
			s1 = ""
		End Try
		If s1.Trim.Length < 1 Then s1 = GetOutputFileName()
		
		' Check validity of output file directory from existing entry
		Try
			s2 = System.IO.Path.GetDirectoryName(Me.tbFileOutput.Text.Trim)
		Catch
			s2 = ""
		End Try
		
		' If existing entry directory entry is invalid, set to default
		If s2.Trim.Length < 1 Then s2 = AppConfig.OutFilePath
		
		' Check validity of selected starting directory
		Try
			If Not System.IO.Directory.Exists(s2) Then s2 = ""
		Catch
			s2 = ""
		End Try
		
		' If default directory is invalid, set to known valid directory (C:\)
		If s2.Trim.Length < 1 Then s2 = "C:\"
		
		' Fire up the dialog box
        Me.SaveFileDialog1.AddExtension = True
        Me.SaveFileDialog1.CheckPathExists = True
        Me.SaveFileDialog1.Filter = s4
        Me.SaveFileDialog1.FileName = s1
        Me.SaveFileDialog1.InitialDirectory = s2
        Me.SaveFileDialog1.OverwritePrompt = True
        Me.SaveFileDialog1.Title = "Output File"
        myJunk = ""
        If Me.SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            	Me.tbFileOutput.Text = Me.saveFileDialog1.FileName
        End If
        Return True
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle double click to launch file dialog for chapter times input file
	
	Sub TextBox2DoubleClick(sender As Object, e As EventArgs)
		SelectTimesFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle double click to launch file dialog for output file
	
	Sub TextBox3DoubleClick(sender As Object, e As EventArgs)
		OutputFileDialog()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Set desired end time and scale all previous times
	
	Private Sub ScaleTimes()
		Dim fromTime As Double = HMStoSEC(FormatTimes(Me.tbScaleFrom.Text.Trim))
		If (fromTime <= 0) Or (HMStoSEC(FormatTimes(Me.maskedTextBox2.Text.Trim)) <= 0) Then
			ErrorBox("Missing or invalid chapter times correction information.")
			Exit Sub
		End If
		Dim s1 As String = "Chapter times scaled so " & FormatTimes(Me.tbScaleFrom.Text.Trim) & " is now " & FormatTimes(Me.maskedTextBox2.Text.Trim) & "." 
		If AppConfig.ConfirmModify And Not MsgBoxResult.Yes = MsgBox("This will scale all chapter times up to and including " & _
			FormatTimes(Me.tbScaleFrom.Text.Trim) & " so that the time " & FormatTimes(Me.tbScaleFrom.Text.Trim) & " will be " & _
			FormatTimes(Me.maskedTextBox2.Text.Trim) & ".  Chapter times after "  & FormatTimes(Me.tbScaleFrom.Text.Trim) & _
			" will not be adjusted.  Do you want to proceed?", _
			MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm Changes") Then Exit Sub
		Dim ratio As Double = 1
		ratio = HMStoSEC(FormatTimes(Me.maskedTextBox2.Text.Trim)) / fromTime
		Dim tempTime As Double = 0
		For I As Integer = LBound(Me.cTimes) To UBound(Me.cTimes) Step 1
			tempTime = HMStoSEC(Me.cTimes(I).Trim)
			If tempTime <= fromTime Then Me.cTimes(I) = SECtoHMS(tempTime * ratio)
		Next
		Me.tbScaleFrom.Text = BLANKTIME
		Me.maskedTextBox2.Text = BLANKTIME
		ShowList()
		Me.toolStripStatusLabel1.Text = s1
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Shift selected time and all following chapter times by specified amount
	
	Private Sub ShiftTimes()
		If Me.cTimes.Length < 1 Then Exit Sub
		Dim fromtime As String = ""
		Dim ShiftSeconds As Double = 0
		Dim eMsg As String = "No valid chapter time selected to shift."
		Try
			fromtime = dataGridView1.CurrentRow.Cells("dgTime").Value.ToString
			If Not fromtime.StartsWith("n") Then eMsg = "" 
		Catch
			'no operation
		End Try
		If eMsg.Trim.Length < 1 Then ShiftSeconds = Convert.ToDouble("0" & Me.tbOffset.Text.Trim)
		If ShiftSeconds = 0 Then eMsg = "Missing or invalid chapter times shift information."
		If eMsg.Trim.Length > 0 Then
			ErrorBox(eMsg)
			Exit Sub
		End If
		Dim fromseconds As Double = HMStoSEC(fromtime)
		Dim s1 As String = "All chapter times from " & FormatTimes(Me.tbScaleFrom.Text.Trim) & " onward have been shifted by " & ShiftSeconds & " seconds."
		If AppConfig.ConfirmModify And Not MsgBoxResult.Yes = MsgBox("This will shift all chapter times including and following " & _
			FormatTimes(Me.tbScaleFrom.Text.Trim) & " by " & ShiftSeconds & " seconds.  Chapter times before "  & _
			FormatTimes(Me.tbScaleFrom.Text.Trim) & " will not be adjusted.  Do you want to proceed?", _
			MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm Changes") Then Exit Sub
		Dim tempTime As Double = 0
		For I As Integer = LBound(Me.cTimes) To UBound(Me.cTimes) Step 1
			tempTime = HMStoSEC(Me.cTimes(I).Trim)
			If tempTime >= fromseconds Then
				tempTime += ShiftSeconds
				If tempTime < 0 Then tempTime = 0
				Me.cTimes(I) = SECtoHMS(tempTime)
			End If
		Next
		Me.tbOffset.Text = "0.0"
		ShowList()
		Me.toolStripStatusLabel1.Text = s1
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Adjust all chapter times to try to match frame boundary for specified frame rate
	
	Private Sub MatchFrameRate()
		If Me.cTimes.Length < 1 Then Exit Sub
		Dim fps As Double = 0
		Dim eMsg As String = "Missing or invalid frame rate information."
		Try
			fps = Convert.ToDouble("0" & Me.tbFrameRate.Text.Trim)
		Catch
			fps = 0
		End Try
		If ((fps > 20) And (fps < 40)) Then eMsg = ""
		If eMsg.Trim.Length > 0 Then
			ErrorBox(eMsg)
			Exit Sub
		End If
		Dim s1 As String = "All chapter times adjusted to match a frame rate of " & Me.tbFrameRate.Text.Trim & " fps."
		If AppConfig.ConfirmModify And Not MsgBoxResult.Yes = MsgBox("This will adjust all chapter times to try to match up to a " & _
			"frame boundary at the specified frame rate of " & Me.tbFrameRate.Text.Trim & " fps.  Do you want to proceed?", _
			MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm Changes") Then Exit Sub
		Dim seconds As Double = 0
		Dim myJunk As Long = 0
		For I As Integer = LBound(Me.cTimes) To UBound(Me.cTimes) Step 1
			seconds = HMStoSEC(Me.cTimes(I).Trim)
			myJunk = Convert.ToInt32((seconds * fps) + 0.5)
			seconds = Convert.ToDouble(myJunk) / fps
			If seconds < 0 Then seconds = 0
			Me.cTimes(I) = SECtoHMS(seconds)
		Next
		ShowList()
		Me.toolStripStatusLabel1.Text = s1
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Add block of chapter times at specified interval
	
	Private Sub AddIntervalTimes()
		Dim IntervalSec As Double = HMStoSEC(Me.maskedTextBox3.Text.Trim)
		Dim IntervalEnd As Double = HMStoSEC(Me.maskedTextBox4.Text.Trim)
		If (IntervalEnd < IntervalSec) Then
			ErrorBox("Missing or invalid chapter interval time information.")
			Exit Sub
		End If
		Dim s1 As String = "Times added every " & Me.maskedTextBox3.Text.Trim & " from 00:00:00.00000 to " & Me.maskedTextBox4.Text.Trim & "."
		If AppConfig.ConfirmInsert And Not MsgBoxResult.Yes = MsgBox("This will create chapter times every " & _
			Me.maskedTextBox3.Text.Trim & " (specified interval) from 00:00:00.00000 to " & Me.maskedTextBox4.Text.Trim & _
			" (specified end time).  Do you want to proceed?", _
			MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm Changes") Then Exit Sub
		Dim seconds As Double = 0
		Do Until (seconds > IntervalEnd)
			AppendArray(Me.cTimes, SECtoHMS(seconds))
			seconds += IntervalSec
		Loop
		Me.maskedTextBox3.Text = BLANKTIME
		Me.maskedTextBox4.Text = BLANKTIME
		ShowList()
		Me.toolStripStatusLabel1.Text = s1
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Write the output chapter file in the specified format
	'
	
	Sub WriteChapterFile()
		Dim s1, s2, s3 As String
		Dim i1, i2, i3 As Integer
		Dim d1, d2 As Double
		Dim b1 As Boolean = False
		Dim eStr As String = ""
		If (eStr.Trim.Length < 1) And (Me.cTimes.Length < 1) Then _
			eStr = "No chapter times identified."
'		If (eStr.Trim.Length < 1) And (Me.cTitles.Length < 1) Then _
'			eStr = "No chapter titles identified."
		If (eStr.Trim.Length < 1) And (Me.tbFileOutput.Text.Trim.Length < 1) Then _
			eStr = "No chapters output file identified."
		
		'Write the output file
		Dim outlines() As String = { }
		If Me.cOutputType = FileType.XML Then
			AppendArray(outlines, "<?xml version=""1.0"" encoding=""utf-8""?>")
			AppendArray(outlines, "<!-- <!DOCTYPE Chapters SYSTEM ""matroskachapters.dtd""> -->")
			AppendArray(outlines, "<Chapters>")
			AppendArray(outlines, "  <EditionEntry>")
			AppendArray(outlines, "    <EditionFlagHidden>0</EditionFlagHidden>")
			AppendArray(outlines, "    <EditionFlagDefault>0</EditionFlagDefault>")
		End If
		
		' Write one entry for each valid chapter time.  Any additional titles will be ignored.
		d1 = 0
		If (Me.cOutputType = FileType.TXT) Then b1 = (MsgBox("Do you want to include the chapter duration information with the chapter titles?" _
			& vbCrLf & vbCrLf & "Note that the the duration of the final chapter will be set to [00:00].", MsgBoxStyle.ApplicationModal Or _
			MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Include Durations") = MsgBoxResult.Yes)
		Dim chaptercount As Integer = 0
		For Each s1 In Me.cTimes
			chaptercount += 1
			s2 = ""
			If Me.cbAddChapterTimes.Checked Then s2 = s2 & "{" & s1 & "} "
			If Me.cbAddChapterNumbers.Checked Then s2 = s2 & chaptercount.ToString.Trim & ". "
			If chaptercount > (UBound(Me.cTitles) + 1) Then
				Dim s2s As String = "Unknown Chapter Title"
				If AppConfig.NoTitle = Defaults.cmNoTitle.ChapterNum Then s2s = "Chapter " & chaptercount.ToString.Trim
				If AppConfig.NoTitle = Defaults.cmNoTitle.ChapterTime Then s2s = s1
				If AppConfig.NoTitle = Defaults.cmNoTitle.NA Then s2s = "n/a"
				s2 &= s2s
			Else
				s2 &= Me.cTitles(chaptercount - 1)
			End If
			If Me.cOutputType = FileType.XML Then
				s2 = System.Net.WebUtility.HtmlEncode(s2)
				AppendArray(outlines, "")
				AppendArray(outlines, "    <ChapterAtom>")
				AppendArray(outlines, "      <ChapterDisplay>")
				AppendArray(outlines, "        <ChapterString>" & s2 & "</ChapterString>")
				AppendArray(outlines, "        <ChapterLanguage>" & Strings.Left(Me.cbLanguage.SelectedItem.ToString.ToLower & "und", 3) & "</ChapterLanguage>")
				AppendArray(outlines, "      </ChapterDisplay>")
				AppendArray(outlines, "      <ChapterTimeStart>" & s1 & "</ChapterTimeStart>")
				AppendArray(outlines, "      <ChapterFlagHidden>0</ChapterFlagHidden>")
				AppendArray(outlines, "      <ChapterFlagEnabled>1</ChapterFlagEnabled>")
				AppendArray(outlines, "    </ChapterAtom>")
			ElseIf Me.cOutputType = FileType.OGM Then
				AppendArray(outlines, "CHAPTER" & chaptercount.ToString.PadLeft(2, CChar("0")) & "=" & s1)
				AppendArray(outlines, "CHAPTER" & chaptercount.ToString.PadLeft(2, CChar("0")) & "NAME=" & s2)
			Else
				Try
					d2 = HMStoSEC(Me.cTimes(chaptercount))
				Catch
					d2 = d1
				End Try
				i1 = CInt(d2 - d1)
				d1 = d2
				i2 = i1 \ 60
				i3 = i1 Mod 60
				s3 = ""
				If b1 Then s3 = " [" & Format(i2, "00") & ":" & Format(i3, "00") & "] "
				AppendArray(outlines, s2 & s3)
			End If
		Next
		If Me.cOutputType = FileType.XML Then
			AppendArray(outlines, "")
			AppendArray(outlines, "  </EditionEntry>")
			AppendArray(outlines, "</Chapters>")
		End If
		
		
		Try
			File.WriteAllLines(Me.tbFileOutput.Text.Trim, outlines)
		Catch
			eStr = "Problem writing to the output file."
		End Try
		
		
		If (eStr.Trim.Length > 0) Then
			Me.toolStripStatusLabel1.Text = eStr
			ErrorBox(eStr)
		Else
			Me.toolStripStatusLabel1.Text = "Chapters file successfully created."
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Convert time entry (e.g. "01:23:45.67890") to total seconds
	
	Private Function HMStoSEC(tm As String) As Double
		Dim RetVal As Double = 0
		Dim digits() As String = Split(tm, ":")
		Dim multiplier As Double = 1
		Dim J As Integer = 0
		For I As Integer = UBound(digits) To LBound(digits) Step - 1
			J += 1
			If (J < 4) Then
				RetVal += (Convert.ToDouble(digits(I)) * multiplier)
				multiplier *= 60
			End If
		Next
		Return RetVal
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Convert hour, minute and second strings to total seconds
	
	Private Function GetSeconds(byval hh As String, byval mm As String, byval ss As String) As Double
		Dim RetVal As Double = 0
		hh = "0" & hh.Trim
		mm = "0" & mm.Trim
		ss = "0" & ss.Trim
		Try
			RetVal = (Convert.ToDouble(hh) * 3600) + (Convert.ToDouble(mm) * 60) + Convert.ToDouble(ss)
		Catch
			RetVal = 0
		End Try
		Return RetVal
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Format partial or invalid time strings to standard format of "hh:mm:ss.sssss"
	
	Private Function FormatTimes(tm As String) As String
		tm = Strings.Replace(tm, " ", "0")
		Dim digits() As String = Split(tm, ":")
		If UBound(digits) <> 2 Then Return tm
		Dim seconds As Double = GetSeconds(digits(0), digits(1), digits(2))
		Return SECtoHMS(seconds)
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Convert total seconds to time string in standard format of "hh:mm:ss.sssss"
	
	Private Function SECtoHMS(ByVal seconds As Double) As String
		Dim hh As Integer = 0
		Dim mm As Integer = 0
		While seconds >= 3600
			seconds -= 3600
			hh += 1
		End While
		While seconds >= 60
			seconds -= 60
			mm += 1
		End While
		Return Format(hh, "00") & ":" & Format(mm, "00") & ":" & Format(seconds, "00.00000")
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Append string value to specified array
	
	Private Function AppendArray(ByRef arrayname() as string, linetoadd As String) As Boolean
		Array.Resize(arrayname, arrayname.Length + 1)
		arrayname(arrayname.Length - 1) = linetoadd
		return true
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Reinitialize, clearing all fields and resetting to default values
	
	Private Sub ResetAll
		Dim s1 As String
		Me.cbAddChapterNumbers.Checked = AppConfig.AddNumbers
		Me.cbAddChapterTimes.Checked = AppConfig.AddTimes
		Me.cbLanguage.SelectedIndex = cbLanguage.FindString(AppConfig.Language)
		If Me.cbLanguage.SelectedIndex < 0 Then Me.cbLanguage.SelectedIndex = 0
		Me.tbOffset.Text = "0.0"
		Me.tbScaleFrom.Text = BLANKTIME
		Me.maskedTextBox2.Text = BLANKTIME
		Me.tbFrameRate.Text = AppConfig.FrameRate.ToString.Trim
		Me.tbFileTitles.Text=""
		Me.tbFileTimes.Text=""
		Me.cTimes = {}
		Me.cTitles = {}
		Me.cTimesType = FileType.Undefined
		Me.cTitlesType = FileType.Undefined
		Me.tbTimeType.Text = "---"
		Me.tbTitleType.Text = "---"
		s1 = "XML"
		If AppConfig.OutputType = Defaults.cmOutputType.OGM Then s1 = "OGM"
		If AppConfig.OutputType = Defaults.cmOutputType.TXT Then s1 = "TXT"
		SetOutputType(CType(AppConfig.OutputType, FileType))
		s1 = AppConfig.OutFilePath.Trim
		If s1.Trim.Length > 0 Then
			If Not s1.EndsWith("\") Then s1 &= "\"
			s1 &= GetOutputFileName()
		End If
		Me.tbFileOutput.Text = s1.Trim
		ShowList()
		Me.toolStripStatusLabel1.Text = "Form reset.  Default configuration loaded."
	End Sub
		
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Develop output file name based on selected file type
	
	Function GetOutputFileName() As String
		Dim s1 As String = AppFileRoot & "Chapters."
		If Me.cOutputType = FileType.OGM Then s1 &= AppConfig.OGMExt
		If Me.cOutputType = FileType.XML Then s1 &= AppConfig.XMLExt
		If Me.cOutputType = FileType.TXT Then s1 &= AppConfig.TXTExt
		Return s1
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle button to launch file dialog for chapter titles input file
	
	Sub Button3Click(sender As Object, e As EventArgs)
		SelectTitlesFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle button to launch file dialog for chapter times input file
	
	Sub Button4Click(sender As Object, e As EventArgs)
		SelectTimesFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle button to launch file dialog for chapters output file
	
	Sub Button5Click(sender As Object, e As EventArgs)
		OutputFileDialog()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Read an input file and determine the file type (i.e. XML, OGM, TXT, other)
	
	Private Function GetFileType(ByVal FilePath As String) As Integer
		Dim s1, a1() As String
		Try
			a1 = System.IO.File.ReadAllLines(FilePath)
			s1 = a1(0)
			If s1.Trim.Length < 1 Then Return FileType.Undefined
			If s1.Trim.StartsWith("CHAPTER01=", StringComparison.OrdinalIgnoreCase) Then Return FileType.OGM
			If s1.Trim.StartsWith("<?xml", StringComparison.OrdinalIgnoreCase) Then Return FileType.XML
			Return FileType.TXT
		Catch
			Return FileType.Undefined
		End Try
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Return the file type string
	
	Private Function GetFileTypeString(ByVal myFileType As Integer) As String
		If myFileType = FileType.XML Then Return "XML"
		If myFileType = FileType.OGM Then Return "OGM"
		If myFileType = FileType.TXT Then Return "TXT"
		Return "---"
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Exit the application via the toolstrip
	
	Sub ExitToolStripMenuItem1Click(sender As Object, e As EventArgs)
		Application.Exit
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the words list editor
	
	Sub WordsListToolStripMenuItemClick(sender As Object, e As EventArgs)
		Dim A As New WordsList()
		A.ShowDialog()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Load chapter times from the specified input file (clears all exising times)
	
	Sub LoadTimes()
		Dim s1 As String = ""
		If Not AppConfig.LoadAppend Then Me.cTimes = {}
		If Me.tbFileTimes.Text.Trim.Length < 1 Then
			If (Me.cTitlesType = FileType.OGM) Or (Me.cTitlesType = FileType.XML) Or (Me.cTitlesType = FileType.TXT) Then
				If MsgBoxResult.Yes = MsgBox("No source file specified.  Use the chapter titles source file?", MsgBoxStyle.ApplicationModal _
					Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Missing Input") Then
					Me.tbFileTimes.Text = Me.tbFileTitles.Text.Trim
				End If
			Else
				ErrorBox("No source file specified.  Please select a source file.", "Missing Input")
			End If
			Exit Sub
		End If
		
		'Read the times
		Dim RegEx3 As String = ""
		If Me.cTimesType = FileType.OGM Then RegEx3 = "CHAPTER[0-9]+=(.*)$"
		If Me.cTimesType = FileType.XML Then RegEx3 = "<ChapterTimeStart>([^<]*)<"
		If Me.cTimesType = FileType.TXT Then RegEx3 = "\[([0-9:]*)\]\s*$"
		Dim s2 As String = Me.tbFileTimes.Text.Trim
		Dim cumTime As Double = 0
		Try
			Dim readTimes() As String = File.ReadAllLines(s2)
			For Each s1 In readTimes
				Dim matches As MatchCollection = Regex.Matches(s1, RegEx3, RegexOptions.IgnoreCase)
				For Each match As Match In matches
					If Me.cTimesType = FileType.TXT Then
						cumTime += HMStoSEC(match.Groups(1).Value)
						AppendArray(Me.cTimes, FormatTimes(SECtoHMS(cumTime)))
					Else
						AppendArray(Me.cTimes, FormatTimes(match.Groups(1).Value))
					End If
				Next
			Next
		Catch
			Me.toolStripStatusLabel1.Text = "Error loading the specified chapter times file."
			ErrorBox("There was a problem loading the chapter times file.")
			Me.cTimes = {}
		End Try
		If (Me.cTimes.Length > 0) And (Me.cTimesType = FileType.TXT) Then AppendArray(Me.cTimes, FormatTimes(SECtoHMS(0)))
		ShowList()
		Me.toolStripStatusLabel1.Text = "Chapter times loaded from specified file."
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Load chapter titles from the specified input file (clears all exising titles)
	
	Sub LoadTitles()
		Dim s1 As String = ""
		Dim s2 As String = ""
		If Not AppConfig.LoadAppend Then Me.cTitles = {}
		If Me.tbFileTitles.Text.Trim.Length < 1 Then
			If (Me.cTimesType = FileType.OGM) Or (Me.cTimesType = FileType.XML) Or (Me.cTimesType = FileType.TXT) Then
				If MsgBoxResult.Yes = MsgBox("No source file specified.  Use the chapter times source file?", MsgBoxStyle.ApplicationModal _
					Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Missing Input") Then
					Me.tbFileTitles.Text = Me.tbFileTimes.Text.Trim
				End If
			Else
				ErrorBox("No source file specified.  Please select a source file.", "Missing Input")
			End If
			Exit Sub
		End If
			
		'Read the titles
		Dim RegEx1 As String = ""
		If Me.cTitlesType = FileType.OGM Then RegEx1 = "CHAPTER[0-9]+NAME=(.*)$"
		If Me.cTitlesType = FileType.XML Then RegEx1 = "ChapterString>([^<]*)</ChapterString"
		Dim RegEx2 As String = "^[0-9]+\.\s+"
		Dim RegEx3 As String = "\s+\[[0-9\:]+\]\s*$"
		Try
			Dim readText() As String = File.ReadAllLines(Me.tbFileTitles.Text.Trim)
			For Each s1 In readText
				s1 = s1.Trim
				s2 = ""
				If Me.cTitlesType = FileType.TXT Then
					s1 = Regex.Replace(s1, RegEx3, String.Empty)
					If s1.Trim.Length > 0 Then AppendArray(Me.cTitles, Regex.Replace(s1, RegEx2, String.Empty))
				Else
					For Each match As Match In Regex.Matches(s1, RegEx1, RegexOptions.IgnoreCase)
						s2 = match.Groups(1).Value
						s2 = System.Net.WebUtility.HtmlDecode(s2)
						AppendArray(Me.cTitles, Regex.Replace(s2, RegEx2, String.Empty))
					Next
				End If
			Next	
		Catch
			Me.toolStripStatusLabel1.Text = "Error loading the specified chapter titles file."
			ErrorBox("There was a problem loading the chapter titles file.")
			Me.cTitles = {}
		End Try
		ShowList()
		Me.toolStripStatusLabel1.Text = "Chapter titles loaded from specified file."
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update the DataGridView with any changes from the time and title arrays
	
	Sub ShowList(optional sRow As Integer = 0, optional sCol As Integer = 0)
		Dim cntTimes As Integer = Me.cTimes.Length
		Dim cntTitles As Integer = Me.cTitles.Length
		Dim cntList As Integer = cntTimes
		If cntTitles > cntTimes Then cntList = cntTitles
		Array.Sort(Me.cTimes)	'Ensure times are properly sorted
		ChaptersDS.Tables(0).Rows.Clear
		Dim DR As DataRow
		For I As Integer = 1 To cntList Step 1
			DR = ChaptersDS.Tables(0).NewRow()
			DR("dgNumber") = I
			If I > cntTimes Then
				DR("dgTime") = "n/a"
			Else
				DR("dgTime") = Me.cTimes(I - 1).Trim
			End If
			If I > cntTitles Then 
				DR("dgTitle") = "n/a"
			Else
				DR("dgTitle") = Me.cTitles(I - 1).Trim
			End If
			ChaptersDS.Tables(0).Rows.Add(DR)
		Next
		UpdateContextMenuItemEnabled()
		Me.dataGridView1.Refresh
		If Me.dataGridView1.Rows.Count > sRow Then Me.dataGridView1.CurrentCell = Me.dataGridView1(sCol, sRow)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update the buttons on the list item context menu
	
	Sub UpdateContextMenuItemEnabled()
		If ChaptersDS.Tables(0).Rows.Count > 0 Then
			Me.contextMenuStrip1.Enabled = True
			Dim i As Integer = Me.dataGridView1.CurrentRow.Index	'zero-based
			Dim j As Integer = Me.cTimes.Length
			Dim k As Integer = Me.cTitles.Length
			Me.moveUpToolStripMenuItem.Enabled =  ((i > 0) And (i < k))
			Me.moveDownToolStripMenuItem.Enabled = ((i > -1) And (i < k - 1))
			Me.deleteLineToolStripMenuItem.Enabled = (i > -1)
			Me.deleteTimeOnlyToolStripMenuItem.Enabled = ((i > -1) And (i < j))
			Me.deleteTitleOnlyToolStripMenuItem.Enabled = ((i > -1) And (i < k))
		Else
			Me.contextMenuStrip1.Enabled = False
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Validate new times input file and load the times
	
	Sub TbFileTimesTextChanged(sender As Object, e As EventArgs)
		Dim myJunk As String = ""
		Me.cTimesType = GetFileType(Me.tbFileTimes.Text.Trim)
		Me.tbTimeType.Text = GetFileTypeString(Me.cTimesType)
		If Me.tbFileTimes.Text.Trim.Length > 0 Then
			If Me.tbFileOutput.Text.Trim.Length < 1 Then
				Try
					If (System.IO.File.Exists(Me.tbFileTimes.Text.Trim) And Not System.IO.Directory.Exists(Me.tbFileTimes.Text.Trim)) Then
						myJunk = System.IO.Path.GetDirectoryName(Me.tbFileTimes.Text.Trim)
						If Not myJunk.EndsWith("\") Then myJunk &= "\"
						myJunk &= GetOutputFileName()
						Me.tbFileOutput.Text = myJunk
					End If
				Catch
					myJunk=""
				End Try
			End If
			LoadTimes()
		Else
			Me.cTimes = {}
'			ShowList()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Validate new titles input file and load the titles
	
	Sub TbFileTitlesTextChanged(sender As Object, e As EventArgs)
		Dim myJunk As String = ""
		Me.cTitlesType = GetFileType(Me.tbFileTitles.Text.Trim)
		Me.tbTitleType.Text = GetFileTypeString(Me.cTitlesType)
		If Me.tbFileTitles.Text.Trim.Length > 0 Then
			If Me.tbFileOutput.Text.Trim.Length < 1 Then
				Try
					If (System.IO.File.Exists(Me.tbFileTitles.Text.Trim) And Not System.IO.Directory.Exists(Me.tbFileTitles.Text.Trim)) Then
						myJunk = System.IO.Path.GetDirectoryName(Me.tbFileTitles.Text.Trim)
						If Not myJunk.EndsWith("\") Then myJunk &= "\"
						myJunk &= GetOutputFileName()
						Me.tbFileOutput.Text = myJunk
					End If
				Catch
					myJunk=""
				End Try
			End If
			LoadTitles()
		Else
'			Me.cTitles = {}
			ShowList()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle button to (re)load chapter times input file
	
	Sub Button7Click(sender As Object, e As EventArgs)
		LoadTimes()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle button to (re)load chapter titles input file
	
	Sub Button6Click(sender As Object, e As EventArgs)
		LoadTitles()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update editing textboxes to capture changes made directly in the DataGridView
	
	Sub DataGridView1SelectionChanged(sender As Object, e As EventArgs)
		dgvLineInfo()
		UpdateContextMenuItemEnabled()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update editing textboxes from current DataGridView row
	
	Private Sub dgvLineInfo()
		Try
			Dim myTemp As String = dataGridView1.CurrentRow.Cells("dgTime").Value.ToString
			If myTemp.StartsWith("n") Then
				myTemp = BLANKTIME
			End If
			Me.maskedTextBox1.Text = myTemp
			Me.tbScaleFrom.Text = myTemp
			Me.maskedTextBox2.Text = myTemp
			Me.tbChapterTitle.Text = dataGridView1.CurrentRow.Cells("dgTitle").Value.ToString.Trim
		Catch
			Me.maskedTextBox1.Text = BLANKTIME
			Me.tbScaleFrom.Text = BLANKTIME
			Me.maskedTextBox2.Text = BLANKTIME
			Me.tbChapterTitle.Text = ""
		End Try
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update time and title arrays from the DataGridView
	
	Private Sub UpdateFromDatagrid()
		Me.cTimes = {}
		Me.cTitles = {}
		Dim tTime, tTitle As String
		For Each dgRow As DataGridViewRow In Me.dataGridView1.Rows
			tTime = dgRow.Cells("dgTime").Value.ToString.Trim
			tTitle = dgRow.Cells("dgTitle").Value.ToString.Trim
			If Not tTime.Equals("n/a") Then AppendArray(Me.cTimes, tTime)
			If Not tTitle.Equals("n/a") Then AppendArray(Me.cTitles, tTitle)
		Next
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Force array and editing textboxes update after changes made in the DataGridView
	
	Sub DataGridView1CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
		UpdateFromDatagrid()
		dgvLineInfo()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Add new chapter time and force updates
	
	Sub BTimeAddClick(sender As Object, e As EventArgs)
		AppendArray(Me.cTimes, FormatTimes(Me.maskedTextBox1.Text.Trim))
		Me.maskedTextBox1.Text = BLANKTIME
		ShowList()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Toggle output file type selection (TXT -> XML -> OGM) 
	
	Sub Button8Click(sender As Object, e As EventArgs)
		If Me.cOutputType = FileType.XML Then
			SetOutputType(FileType.OGM)
		ElseIf Me.cOutputType = FileType.OGM Then
			SetOutputType(FileType.TXT)
		Else
			SetOutputType(FileType.XML)
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Force fixing of masked textbox value
	
	Sub MaskedTextBox1Leave(sender As Object, e As EventArgs)
		Me.maskedTextBox1.Text = FixMaskedText(Me.maskedTextBox1.Text)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Force fixing of masked textbox value
	
	Sub MaskedTextBox2Leave(sender As Object, e As EventArgs)
		Me.maskedTextBox2.Text = FixMaskedText(Me.maskedTextBox2.Text)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Force fixing of masked textbox value
	
	Sub MaskedTextBox3Leave(sender As Object, e As EventArgs)
		Me.maskedTextBox3.Text = FixMaskedText(Me.maskedTextBox3.Text)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Force fixing of masked textbox value
	
	Sub MaskedTextBox4Leave(sender As Object, e As EventArgs)
		Me.maskedTextBox4.Text = FixMaskedText(Me.maskedTextBox4.Text)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Fix masked textbox value to replace spaces with zeros (bug in VB Net?)
	
	Private Function FixMaskedText(ByVal TextToFix As String) As String
		Dim s1 As String = TextToFix.PadRight(14, CChar("0"))
		Dim s2 As String = Strings.Replace(s1, " ", "0")
		Return s2
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update selected chapter time
	
	Sub BTimeUpdateClick(sender As Object, e As EventArgs)
		Dim idx As Integer
		Try
			idx = Me.dataGridView1.CurrentRow.Index
		Catch
			idx = -1
		End Try
		If idx < 0 Then
			ErrorBox("No row selected.")
			Exit Sub
		End If
		Me.dataGridView1.CurrentRow.Cells("dgTime").Value = FormatTimes(Me.maskedTextBox1.Text.Trim)
		UpdateFromDatagrid()
		Me.maskedTextBox1.Text = BLANKTIME
		ShowList()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Delete selected chapter time from the list
	
	Sub BTimeRemoveClick(sender As Object, e As EventArgs)
		DeleteSelectedTime()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Delete selected chapter time from the list
	
	Sub DeleteSelectedTime()
		Dim idx As Integer
		Dim confirm As Boolean = True
		Try
			idx = Me.dataGridView1.CurrentRow.Index
		Catch
			idx = -1
		End Try
		If idx < 0 Then
			ErrorBox("No row selected.")
			Exit Sub
		End If
		If AppConfig.ConfirmDelete Then
			confirm = (MsgBoxResult.Yes = MsgBox("Are you sure that you want to remove the selected row's chapter time (" & _
				Me.dataGridView1.CurrentRow.Cells("dgTime").Value.ToString.Trim & ")?  All following times will be moved up.", _
				MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm Delection"))
		End If
		If confirm Then
			Me.dataGridView1.CurrentRow.Cells("dgTime").Value = "n/a"
			UpdateFromDatagrid()
			Me.maskedTextBox1.Text = BLANKTIME
			ShowList()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Insert new chapter title
	
	Sub BTitleInsertClick(sender As Object, e As EventArgs)
		Dim idx As Integer
		Dim s1 As String
		If Me.tbChapterTitle.Text.Trim.Length < 1 Then
			ErrorBox("Cannot insert blank title.  Please enter the title and try again.")
			Exit Sub
		End If
		If Me.dataGridView1.Rows.Count < 1 Then
			AppendArray(Me.cTitles, Me.tbChapterTitle.Text.Trim)
		Else
			Try
				idx = Me.dataGridView1.CurrentRow.Index
			Catch
				idx = -1
			End Try
			If idx < 0 Then
				ErrorBox("No row selected.")
				Exit Sub
			End If
			Me.cTitles = {}
			For I As Integer = 0 To (Me.dataGridView1.Rows.Count - 1) Step 1
				If I = idx Then AppendArray(Me.cTitles, Me.tbChapterTitle.Text.Trim)
				s1 = Me.dataGridView1.Rows(I).Cells("dgTitle").Value.ToString.Trim
				If Not s1.Equals("n/a") Then AppendArray(Me.cTitles, s1)
			Next
		End If
		ShowList()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update selected chapter title
	
	Sub BTitleUpdateClick(sender As Object, e As EventArgs)
		Dim idx As Integer
		If Me.tbChapterTitle.Text.Trim.Length < 1 Then
			ErrorBox("Cannot update to a blank title.  Please enter the title and try again.")
			Exit Sub
		End If
		Try
			idx = Me.dataGridView1.CurrentRow.Index
		Catch
			idx = -1
		End Try
		If idx < 0 Then
			ErrorBox("No row selected.")
			Exit Sub
		End If
		Me.dataGridView1.CurrentRow.Cells("dgTitle").Value = Me.tbChapterTitle.Text.Trim
		UpdateFromDatagrid()
		Me.tbChapterTitle.Text = ""
		ShowList()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Delete selected chapter title from the list
	
	Sub BTitleRemoveClick(sender As Object, e As EventArgs)
		DeleteSelectedTitle()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Delete selected chapter title from the list
	
	Sub DeleteSelectedTitle()
		Dim idx As Integer
		Dim confirm As Boolean = True
		Try
			idx = Me.dataGridView1.CurrentRow.Index
		Catch
			idx = -1
		End Try
		If idx < 0 Then
			ErrorBox("No row selected.")
			Exit Sub
		End If
		If AppConfig.ConfirmDelete Then
			confirm = (MsgBoxResult.Yes = MsgBox("Are you sure that you want to remove the selected row's chapter title (" & _
				Me.dataGridView1.CurrentRow.Cells("dgTitle").Value.ToString.Trim & ")?  All following titles will be moved up.", _
				MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm Delection"))
		End If
		If confirm Then
			Me.dataGridView1.CurrentRow.Cells("dgTitle").Value = "n/a"
			UpdateFromDatagrid()
			Me.tbChapterTitle.Text = ""
			ShowList()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Delete selected line (chapter time and title) from the list
	
	Sub BDeleteLineClick(sender As Object, e As EventArgs)
		DeleteSelectedLine()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Delete selected line (chapter time and title) from the list
	
	Sub DeleteSelectedLine()
		Dim idx As Integer
		Dim confirm As Boolean = True
		Try
			idx = Me.dataGridView1.CurrentRow.Index
		Catch
			idx = -1
		End Try
		If idx < 0 Then
			ErrorBox("No row selected.")
			Exit Sub
		End If
		If AppConfig.ConfirmDelete Then
			confirm = (MsgBoxResult.Yes = MsgBox("Are you sure that you want to remove the selected row (chapter time and title)?", _
				MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm Delection"))
		End If
		If confirm Then
			Me.dataGridView1.CurrentRow.Cells("dgTime").Value = "n/a"
			Me.dataGridView1.CurrentRow.Cells("dgTitle").Value = "n/a"
			UpdateFromDatagrid()
			Me.maskedTextBox1.Text = BLANKTIME
			Me.tbChapterTitle.Text = ""
			ShowList()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Adjust the case of all titles based on user-defined words list
	
	Sub BFixTitleCaseClick(sender As Object, e As EventArgs)
		If Me.dataGridView1.Rows.Count < 1 Then Exit Sub
		If AppConfig.ConfirmModify And Not MsgBoxResult.Yes = MsgBox("Are you sure that you want to adjust the case of all chapter titles?", _
			MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") Then Exit Sub
		For I As Integer = LBound(Me.cTitles) To UBound(Me.cTitles) Step 1
			Me.cTitles(I) = AppFixCase.MakeProper(Me.cTitles(I))
		Next
		ShowList()
		Me.toolStripStatusLabel1.Text = "All chapter titles have been adjusted to title case."
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the time scaling routine
	
	Sub BScaleTimesClick(sender As Object, e As EventArgs)
		ScaleTimes()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the time shifting routine
	
	Sub BShiftTimesClick(sender As Object, e As EventArgs)
		ShiftTimes()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the time framerate matching routine
	
	Sub BFrameRateTimesClick(sender As Object, e As EventArgs)
		MatchFrameRate()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the interval time block adding routine
	
	Sub BAddIntervalsClick(sender As Object, e As EventArgs)
		AddIntervalTimes()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the write output file routine
	
	Sub BOutputClick(sender As Object, e As EventArgs)
		WriteChapterFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the reset routine
	
	Sub BResetClick(sender As Object, e As EventArgs)
		ResetAll()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch file dialog for chapter times input file
	
	Sub TimesToolStripMenuItemClick(sender As Object, e As EventArgs)
		SelectTimesFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch file dialog for chapter titles input file
	
	Sub TitlesToolStripMenuItemClick(sender As Object, e As EventArgs)
		SelectTitlesFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch file dialog for chapter times input file
	
	Private Sub SelectTimesFile()
		Dim myJunk As String
		myJunk = InputFileDialog(Me.tbFileTimes.Text.Trim)
		If myJunk.Trim.Length > 0 Then
			Me.tbFileTimes.Text = myJunk.Trim
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch file dialog for chapter titles input file
	
	Private Sub SelectTitlesFile()
		Dim myJunk As String
		myJunk = InputFileDialog(Me.tbFileTitles.Text.Trim)
		If myJunk.Trim.Length > 0 Then
			Me.tbFileTitles.Text = myJunk.Trim
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the settings window
	
	Sub SettingsToolStripMenuItemClick(sender As Object, e As EventArgs)
		Dim A As New Settings()
		A.ShowDialog()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the reset routine
	
	Sub NewToolStripMenuItemClick(sender As Object, e As EventArgs)
		ResetAll()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the write chapters output file routine
	
	Sub SaveToolStripMenuItemClick(sender As Object, e As EventArgs)
		WriteChapterFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the output file selection dialog routine
	
	Sub SaveAsToolStripMenuItemClick(sender As Object, e As EventArgs)
		OutputFileDialog()
		If Me.tbFileOutput.Text.Trim.Length > 0 Then WriteChapterFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Launch the "About ChapterMaker" window
	
	Sub AboutToolStripMenuItemClick(sender As Object, e As EventArgs)
		Dim A As New AboutBox()
		A.ShowDialog()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Exit the program
	
	Sub BExitClick(sender As Object, e As EventArgs)
		Me.Close
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	'Examples of help calls:
	
	'Help.ShowHelp(ParentForm, "HelpFile.chm", HelpNavigator.TableofContents, Nothing)
	'Help.ShowHelp(ParentForm, "HelpFile.chm", HelpNavigator.Index, Nothing)
	'Help.ShowHelp(ParentForm, "HelpFile.chm", HelpNavigator.Topic, "Page.html")
	'Help.ShowHelp(ParentForm, "HelpFile.chm", HelpNavigator.TopicId, 123)
	'Help.ShowHelp(ParentForm, "HelpFile.chm", HelpNavigator.Keyword, "Keyword")	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Open the help file Scaling Chapter Times screen
	
	Sub BScaleHelpClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.TopicId, "9010")
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Open the help file Shifting Chapter Times screen
	
	Sub BShiftTimesHelpClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.TopicId, "9020")
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Open the help file Adding Chapter Times screen
	
	Sub BAddTimesHelpClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.TopicId, "9030")
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Open the help file Table of Contents tab
	
	Sub ContentsToolStripMenuItemClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.TableOfContents, Nothing)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Open the help file index tab
	
	Sub IndexToolStripMenuItemClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.Index, Nothing)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Open the help file Search tab
	
	Sub SearchToolStripMenuItemClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.Find, "")
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle drag 'n' drop rearranging of chapter titles
	
	Sub DataGridView1DragDrop(sender As Object, e As DragEventArgs)
		Dim p As Point = DataGridView1.PointToClient(New Point(e.X, e.Y))
		Dim z As Integer
		dragIndex = DataGridView1.HitTest(p.X, p.Y).RowIndex
		If (e.Effect = DragDropEffects.Move) Then
			Dim dragRow As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
			If dragIndex < 0 Then dragIndex = DataGridView1.RowCount - 1
			Dim tempStr As String = dataGridView1.Rows(fromIndex).Cells("dgTitle").Value.ToString.Trim
			Dim tempTitles() As String = {}
			For I As Integer = LBound(cTitles) To UBound(cTitles) Step 1
				If (I = dragIndex) Then AppendArray(tempTitles, tempStr)
				If Not (I = fromIndex) Then AppendArray(tempTitles, cTitles(I))
			Next
			cTitles = tempTitles
			z = dragIndex
			If dragIndex > fromIndex Then z = dragIndex - 1
			ShowList(z, 2)
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle drag 'n' drop rearranging of chapter titles
	
	Sub DataGridView1DragOver(sender As Object, e As DragEventArgs)
		Dim p As Point = DataGridView1.PointToClient(New Point(e.X, e.Y))
		If dataGridView1.HitTest(p.X, p.Y).ColumnIndex = 2 then
			e.Effect = DragDropEffects.Move
		Else
			e.Effect = DragDropEffects.None
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle drag 'n' drop rearranging of chapter titles
	
	Sub DataGridView1MouseDown(sender As Object, e As MouseEventArgs)
		fromIndex = DataGridView1.HitTest(e.X, e.Y).RowIndex
		Dim ColTest As Integer = dataGridView1.HitTest(e.X, e.Y).ColumnIndex
		If (fromIndex > -1) And (ColTest = 2) Then
			Dim dragSize As Size = SystemInformation.DragSize
			dragRect = New Rectangle(New Point(CInt((e.X - (dragSize.Width / 2))), CInt(e.Y - (dragSize.Height / 2))), dragSize)
		Else
			dragRect = Rectangle.Empty
		End If	
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle drag 'n' drop rearranging of chapter titles
	
	Sub DataGridView1MouseMove(sender As Object, e As MouseEventArgs)
		If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
			If (dragRect <> Rectangle.Empty _
				AndAlso Not dragRect.Contains(e.X, e.Y)) Then
				DataGridView1.DoDragDrop(DataGridView1.Rows(fromIndex), DragDropEffects.Move)
			End If
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Check for program updates
	
	Sub CheckForUpdatesToolStripMenuItemClick(sender As Object, e As EventArgs)
		CheckForUpdates(True)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Clear list of chapter times
	
	Sub BClearTimesClick(sender As Object, e As EventArgs)
		Me.cTimes = {}
		ShowList()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Clear list of chapter titles
	
	Sub BClearTitlesClick(sender As Object, e As EventArgs)
		Me.cTitles = {}
		ShowList()
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
	'	Text edit cut function
	
	Sub TextEditCut()
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
	'	Text edit copy function
	
	Sub TextEditCopy()
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
	'	Text edit paste function
	
	Sub TextEditPaste()
		If TypeOf Me.ActiveControl Is TextBox Then
			Dim box As TextBox = TryCast(Me.ActiveControl, TextBox)
			Dim iData As IDataObject = Clipboard.GetDataObject()
        	'Check to see if the data is in a text format
        	If iData.GetDataPresent(DataFormats.Text) Then box.SelectedText = Clipboard.GetText()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the cut function
	
	Sub CutToolStripMenuItemClick(sender As Object, e As EventArgs)
		TextEditCut()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the copy function
	
	Sub CopyToolStripMenuItemClick(sender As Object, e As EventArgs)
		TextEditCopy()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the paste function
	
	Sub PasteToolStripMenuItemClick(sender As Object, e As EventArgs)
		TextEditPaste()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the select all function
	
	Sub SelectAllToolStripMenuItemClick(sender As Object, e As EventArgs)
		If TypeOf Me.ActiveControl Is TextBox Then
			Dim box As TextBox = TryCast(Me.ActiveControl, TextBox)
			box.SelectAll()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update the enabled status of the edit buttons
	
    Private Sub UpdateEditButtons(ByVal sender As Object, ByVal e As EventArgs)
    	If TypeOf Me.ActiveControl Is TextBox Then
    		Me.selectAllToolStripMenuItem.Enabled = (Me.ActiveControl.Text.Trim.Length > 0)
    		Me.copyToolStripMenuItem.Enabled = (TryCast(Me.ActiveControl, TextBox).SelectionLength > 0)
    		Me.cutToolStripMenuItem.Enabled = (TryCast(Me.ActiveControl, TextBox).SelectionLength > 0)
    		Me.pasteToolStripMenuItem.Enabled = Clipboard.ContainsText
    		Me.cutToolStripButton.Enabled = (TryCast(Me.ActiveControl, TextBox).SelectionLength > 0)
    		Me.copyToolStripButton.Enabled = (TryCast(Me.ActiveControl, TextBox).SelectionLength > 0)
    		Me.pasteToolStripButton.Enabled = Clipboard.ContainsText
    	Else
    		Me.selectAllToolStripMenuItem.Enabled = False
    		Me.pasteToolStripMenuItem.Enabled = False
    		Me.copyToolStripMenuItem.Enabled = False
    		Me.cutToolStripMenuItem.Enabled = False
    		Me.cutToolStripButton.Enabled = False
    		Me.copyToolStripButton.Enabled = False
    		Me.pasteToolStripButton.Enabled = False
		End If
    End Sub
    
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the new document tool strip button 
	
	Sub NewToolStripButtonClick(sender As Object, e As EventArgs)
		ResetAll()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the save tool strip button 
	
	Sub SaveToolStripButtonClick(sender As Object, e As EventArgs)
		WriteChapterFile()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the cut tool strip button
	
	Sub CutToolStripButtonClick(sender As Object, e As EventArgs)
		TextEditCut()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the copy tool strip button
	
	Sub CopyToolStripButtonClick(sender As Object, e As EventArgs)
		TextEditCopy()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the paste tool strip button
	
	Sub PasteToolStripButtonClick(sender As Object, e As EventArgs)
		TextEditPaste()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the help tool strip button
	
	Sub HelpToolStripButtonClick(sender As Object, e As EventArgs)
		If HelpFileExists() Then System.Windows.Forms.Help.ShowHelp(ParentForm, AppHelp, HelpNavigator.TableOfContents, Nothing)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Set output file type
	
	Sub SetOutputType(ByVal newType As FileType)
		Dim s1, s2, s3, s4, s5 As String
		Dim n1 As Integer
		If Me.cOutputType = FileType.XML Then
			n1 = AppConfig.XMLExt.Trim.Length
			s2 = AppConfig.XMLExt.Trim
		ElseIf Me.cOutputType = FileType.OGM Then
			n1 = AppConfig.OGMExt.Trim.Length
			s2 = AppConfig.OGMExt.Trim
		Else
			n1 = AppConfig.TXTExt.Trim.Length
			s2 = AppConfig.TXTExt.Trim
		End If
		Me.cOutputType = newType
		If newType = FileType.XML Then
			s4 = "XML"
			s5 = "Extensible Markup Language"
			s1 = AppConfig.XMLExt.Trim
			Me.xMLToolStripMenuItem.Checked = True
			Me.oGGMediaToolStripMenuItem.Checked = False
			Me.plainTextToolStripMenuItem.Checked = False
		ElseIf newType = FileType.OGM Then
			s4 = "OGM"
			s5 = "OGG Media / Chapters"
			s1 = AppConfig.OGMExt.Trim
			Me.xMLToolStripMenuItem.Checked =  False
			Me.oGGMediaToolStripMenuItem.Checked = True
			Me.plainTextToolStripMenuItem.Checked = False
		Else
			s4 = "TXT"
			s5 = "Plain Text"
			s1 = AppConfig.TXTExt.Trim
			Me.xMLToolStripMenuItem.Checked = False
			Me.oGGMediaToolStripMenuItem.Checked = False
			Me.plainTextToolStripMenuItem.Checked = True
		End If
		s3 = Me.tbFileOutput.Text.Trim
		If s3.Length > 0 Then
			If s3.EndsWith(s2) Then
				s3 = Strings.Left(s3, s3.Length - n1) & s1
				Me.tbFileOutput.Text = s3
			End If
		End If
		'Dim otItem As Object
		For Each otItem As Object In Me.cbOutputType.Items
			If Strings.Left(otItem.ToString.Trim, 3) = s4 Then Me.cbOutputType.SelectedItem = otItem
		Next
		Me.toolStripStatusLabel1.Text = "Output file set to " & s5 & " (" & s4 & ") format."
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the XML Output tool strip button
	
	Sub XMLToolStripMenuItemClick(sender As Object, e As EventArgs)
		SetOutputType(FileType.XML)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the OGM Output tool strip button
	
	Sub OGGMediaToolStripMenuItemClick(sender As Object, e As EventArgs)
		SetOutputType(FileType.OGM)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle the TXT Output tool strip button
	
	Sub PlainTextToolStripMenuItemClick(sender As Object, e As EventArgs)
		SetOutputType(FileType.TXT)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle output file type selection update
	
	Sub CbOutputTypeSelectedIndexChanged(sender As Object, e As EventArgs)
		Dim s1 As String = Strings.Left(Me.cbOutputType.SelectedItem.ToString.Trim, 3)
		If s1 = "XML" Then
			SetOutputType(FileType.XML)
		ElseIf s1 = "OGM" Then
			SetOutputType(FileType.OGM)
		Else
			SetOutputType(FileType.TXT)
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle delete line toolstrip item
	
	Sub DeleteLineToolStripMenuItemClick(sender As Object, e As EventArgs)
		DeleteSelectedLine()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle delete title only toolstrip item
	
	Sub DeleteTitleOnlyToolStripMenuItemClick(sender As Object, e As EventArgs)
		DeleteSelectedTitle()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle delete time only toolstrip item
	
	Sub DeleteTimeOnlyToolStripMenuItemClick(sender As Object, e As EventArgs)
		DeleteSelectedTime()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle move title up toolstrip item
	
	Sub MoveUpToolStripMenuItemClick(sender As Object, e As EventArgs)
		Dim i As Integer = Me.dataGridView1.CurrentRow.Index
		Dim s1 As String = Me.cTitles(i - 1)
		Me.cTitles(i - 1) = Me.cTitles(i)
		Me.cTitles(i) = s1
		ShowList(i - 1, 2)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Handle move title down toolstrip item
	
	Sub MoveDownToolStripMenuItemClick(sender As Object, e As EventArgs)
		Dim i As Integer = Me.dataGridView1.CurrentRow.Index
		Dim s1 As String = Me.cTitles(i + 1)
		Me.cTitles(i + 1) = Me.cTitles(i)
		Me.cTitles(i) = s1
		ShowList(i + 1, 2)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Select line on right mouse click
	
	Sub DataGridView1CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
		If (e.Button = MouseButtons.Right) And (e.ColumnIndex >= 0) And (e.RowIndex >= 0) Then
			Me.dataGridView1.CurrentCell = Me.dataGridView1(e.ColumnIndex, e.RowIndex)
			UpdateContextMenuItemEnabled()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	
End Class
