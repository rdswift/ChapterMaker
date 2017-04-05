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

Imports System.Security.Cryptography
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Data

Public Partial Class Upload
	
	Dim ChapterTitle As String
	Dim ChapterString As String
	Dim ChapterHash As String
	Dim sLanguage As String
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
		
		ChapterString = ""
		ChapterHash = ""
		ChapterTitle = ""
	End Sub
	
	Public Sub New(ChapterInfo As String, ChapterTimesHash As String)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
		ChapterString = ChapterInfo
		ChapterHash = ChapterTimesHash
		ChapterTitle = ""
	End Sub
	
	Public Sub New(ChapterInfo As String, ChapterTimesHash As String, ChapterUploadTitle As String)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
		ChapterString = ChapterInfo
		ChapterHash = ChapterTimesHash.Trim
		ChapterTitle = ChapterUploadTitle.Trim
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Handles the load event.  Initializes the screen information.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
	Sub UploadLoad(sender As Object, e As EventArgs)
		Me.mtbDuration.Text = "00:00:00:00000"
		Me.comboMedia.SelectedIndex = 0
		Me.textBox1.ReadOnly = True
		For Each f As Form In My.Application.OpenForms
			If f.Name.Equals("MainForm") Then
				Me.tbFrameRate.Text = CType(f, MainForm).tbFrameRate.Text.Trim
				sLanguage = Strings.Left(CType(f, MainForm).cbLanguage.SelectedItem.ToString.ToLower & "und", 3)
				Me.mtbDuration.Text = CType(f, MainForm).mtbDuration.Text
			End If
		Next
		
		Me.tbTitle.Text = ChapterTitle.Trim
		If (Me.tbTitle.Text.Trim.Length > 0) Then 
			Me.tbTitle.Visible = True
			Me.tbTitle.Focus
		End If
		
		MakeXML()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Update the XML string after a title update.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
	Sub TbTitleTextChanged(sender As Object, e As EventArgs)
		MakeXML()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Handles the Quit button click.  Closes the form and returns to main form.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
	Sub BQuitClick(sender As Object, e As EventArgs)
		Me.Close
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Handles the Upload button click.  Validates the information, builds the XML file and uploads to the ChaptersDB.org website.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
	Sub BUploadClick(sender As Object, e As EventArgs)
		Dim es As String = ""
		If Me.tbTitle.Text.Trim.Equals("") Then es = "Title cannot be blank.  Please enter the title to save to ChapterDB."
		'
		'Add any other upload quality checks here.
		'
		If Not es.Trim.Equals("") Then
			ErrorBox(es)
			Exit Sub
		End If
		If AppConfig.ConfirmUpload And Not MsgBoxResult.Yes = MsgBox("Are you sure that you want to upload the current chapter information to the ChapterDB website?", _
			MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") Then Exit Sub
		Dim sXML As String = Me.textBox1.Text.Trim
		If postChapter(sXml) Then
			Me.Close
		End If
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Creates the XML string for display and uploading.
	''' </summary>
	''' <returns>The assembled XML string.</returns>
	''' 
	Private Function MakeXML() As String
		Dim sXml, sHash, sType, sFPS As String
		Dim mcsp As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
		Dim sExtractor As String = appName & " " & AppVersion(False)
		
		sExtractor = "ChapterGrabber 4.5"
		
		sXml = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf & "<chapterInfo xml:lang=""" & sLanguage _
			& """ version=""3"" extractor=""" & sExtractor & """ xmlns=""http://jvance.com/2008/ChapterGrabber"">" & vbCrLf
		If Not Me.tbTitle.Text.Trim.Equals("") Then
			sXml &= "  <title>" & Me.tbTitle.Text.Trim & "</title>" & vbCrLf
		End If
		sXml &= "  <source>" & vbCrLf
		sHash = ""
		Dim sName As String = "C:\" & Me.tbTitle.Text.Trim & ".txt"
		If sName.Equals("") Then sName = "Unknown"
		sXml &= "    <name>" & sName & "</name>" & vbCrLf
		sHash = ChapterHash.Trim
'		Try
'			sHash = BitConverter.ToString(mcsp.ComputeHash(System.IO.File.ReadAllBytes(Me.tbFileName.Text.Trim))).Replace("-", "").ToLower
'		Catch
'			sHash = ""
'		End Try
		If sHash.Trim.Equals("") Then
			sHash = BitConverter.ToString(mcsp.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sXml & ChapterString))).Replace("-", "").ToLower
		End If
		sXml &= "    <hash>" & sHash & "</hash>" & vbCrLf
		sType = Me.comboMedia.SelectedItem.ToString.Trim
		If sType.Equals("Other") Then
			sType = "Unknown"
		Else
			sXml &= "    <type>" & sType & "</type>" & vbCrLf 
		End If
		sFPS = Me.tbFrameRate.Text.Trim
		If sFPS.Equals("") Then sFPS = "29.970029970029973"
		sXml &= "    <fps>" & sFPS & "</fps>" & vbCrLf & "    <duration>" & FixMaskedText(Me.mtbDuration.Text.Trim) & "</duration>" _
			& vbCrLf & "  </source>" & vbCrLf & "  <chapters>" & vbCrLf & ChapterString & "  </chapters>" & vbCrLf
		'Dim sName As String = AppConfig.ChapterDBName.Trim
		'sName = AppConfig.ChapterDBName.Trim
		sName = ""
		If sName.Equals("") Then sName = "Anon@chapterdb.org"
		sXml &= "  <createdBy>" & sName & "</createdBy>" & vbCrLf
		sXml &= "  <createdDate>" & Format(Now, "yyyy-MM-ddTHH:mm:ss.ffzzz") & "</createdDate>" & vbCrLf
		sXml &= "</chapterInfo>" & vbCrLf
		Me.textBox1.Text = sXml
		Me.textBox1.Refresh
		Return sXml
	End Function
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Fixes a masked textbox value to replace spaces with zeros.
	''' </summary>
	''' <param name="TextToFix">The string from a masked text box to repair.</param>
	''' <returns>The repaired formatted string.</returns>
	''' 
	Private Function FixMaskedText(ByVal TextToFix As String) As String
		Dim s1 As String = TextToFix.Replace(" ", "0").Replace(":", "").Trim
		Dim d1 As Double = CDbl(s1)
		Dim s2 As String = Strings.Format(d1, "00:00:00.00000000")
		Return s2
	End Function
	

	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Displays a drop down list of standard frame rates.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
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
	''' <summary>
	''' Copies the selected frame rate to the text box.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
	Sub LbFRListSelectedIndexChanged(sender As Object, e As EventArgs)
		CopyFR()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Copies the selected frame rate to the text box.
	''' </summary>
	''' 
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
	'	Send XML to ChapterDB server
	''' <summary>
	''' Upload the chapter set information to the ChapterDB website.
	''' </summary>
	''' <param name="xmlContent">The XML content string to upload.</param>
	''' <returns>True on successful upload.  False if an error occurred.</returns>
	''' 
	Public Function postChapter(xmlContent As String) As Boolean
		Dim returnStatus As Boolean = False
		Dim returnString As String = ""
		
		Me.lUploading.Visible = True
		
		Dim myURI As String = "http://chapterdb.org/chapters"
'		myURI = "http://private-anon-47fa45625f-jarrettvance.apiary-mock.com/chapters"	'API Test Site 

		Dim myKey As String = AppConfig.ChapterDBKey
'		myKey = "XXXXXXXXXX"				'API Test Site key

		Dim request As HttpWebRequest = DirectCast(WebRequest.Create(myURI), HttpWebRequest)
		request.Headers.Add("ApiKey", myKey)
		request.UserAgent = "ChapterGrabber"
		' Set the Method property of the request to POST.
		request.Method = "POST"
		' Create POST data and convert it to a byte array.
		Dim postData As String = xmlContent
		Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
		' Set the ContentType property of the WebRequest.
		request.ContentType = "text/xml"
		' Set the ContentLength property of the WebRequest.
		request.ContentLength = byteArray.Length
		' Get the request stream.
		Dim dataStream As Stream = request.GetRequestStream()
		' Write the data to the request stream.
		dataStream.Write(byteArray, 0, byteArray.Length)
		' Close the Stream object.
		dataStream.Close()
		Try
			' Get the response.
			Dim response As WebResponse = request.GetResponse()
			' Display the status.
			returnString = (DirectCast(response, HttpWebResponse).StatusDescription) & Environment.NewLine
			' Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream()
			' Open the stream using a StreamReader for easy access.
			Dim reader As New StreamReader(dataStream)
			' Read the content.
			Dim responseFromServer As String = reader.ReadToEnd()
			' Display the content.
			returnString = returnString & responseFromServer
			reader.Close()
			dataStream.Close()
			response.Close()
			returnStatus = True
		Catch e As Exception
'          	throw;
			returnString = (e.Source & ": ") & e.Message & Environment.NewLine & e.StackTrace
		End Try
		
		Me.lUploading.Visible = False
		
		If returnString.Trim.StartsWith("No Content") Then
			MessageBox.Show("File uploaded successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.None)
			returnstatus = True
		Else
			ErrorBox(returnstring)
		End If
		Return returnStatus
	End Function
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Display Title Text Box
	
	Sub LTbTitleClick(sender As Object, e As EventArgs)
		Me.tbTitle.Visible = True
		Me.tbTitle.Focus()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Hide Title Text Box if empty
	
	Sub TbTitleLeave(sender As Object, e As EventArgs)
		Me.tbTitle.Text = Me.tbTitle.Text.Trim
		If Me.tbTitle.Text.Trim.Equals("") Then Me.tbTitle.Visible = False
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update the XML string after the duration information has changed
	'
	
	Sub MtbDurationTextChanged(sender As Object, e As EventArgs)
		MakeXML()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update the XML string after the media type information has changed
	'
	
	Sub ComboMediaSelectedIndexChanged(sender As Object, e As EventArgs)
		MakeXML()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Update the XML string after the frames per second information has changed
	'
	
	Sub TbFrameRateTextChanged(sender As Object, e As EventArgs)
		MakeXML()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
End Class
