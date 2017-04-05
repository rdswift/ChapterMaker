'
' Created by SharpDevelop.
' User: bob
' Date: 2016-09-27
' Time: 15:58
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports System.Net
Imports System.Xml
Imports System.Data

Public Partial Class SearchChapterDB
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
		
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Initiate the search of the ChapterDB website.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
	Sub BSearchClick(sender As Object, e As EventArgs)
		DoTheSearch()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Do the actual search
	
	Sub DoTheSearch()
		Dim bSkip As Boolean = False
		If Me.tbTitleSearch.Text.Trim.Equals("") Then
			ErrorBox("No search title provided.  Please enter a title and try again.")
			Exit Sub
		End If
		Dim returnStatus As Boolean = False
		Dim returnString As String = ""
		
		Me.lSearching.Visible = True
		Me.lSearching.Refresh
		Me.Refresh
		
		Dim myURI As String = "http://chapterdb.org/chapters/search?title=" & System.Net.WebUtility.HtmlEncode(Me.tbTitleSearch.Text.Trim)
		'myURI = "http://private-anon-47fa45625f-jarrettvance.apiary-mock.com/chapters"	'API Test Site 
		
		Dim myKey As String = AppConfig.ChapterDBKey
		If myKey.Trim.Equals("") Then myKey = "ETET7TXFJH45YNYW0I4A"	'Live testing key
		'myKey = "XXXXXXXXXX"											'API Test Site
		
		Dim request As HttpWebRequest = DirectCast(WebRequest.Create(myURI), HttpWebRequest)
		request.Headers.Add("ApiKey", myKey)
		request.UserAgent = "ChapterGrabber"
		' Set the Method property of the request to POST.
		request.Method = "GET"
		request.contentlength = 0
		Dim responseContent As String = ""
		Try
			Using response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)
				Using reader = New System.IO.StreamReader(response.GetResponseStream())
					responseContent = reader.ReadToEnd()
				End Using
			End Using
		Catch ex As Exception
'			ErrorBox(ex.Message & Environment.NewLine & Environment.NewLine & "Source: " & ex.Source & Environment.NewLine _
'				&Environment.NewLine & ex.StackTrace)
			ErrorBox("Problem connecting to the ChapterDB website.  Please wait a moment and try your search again.")
			responseContent = ""
			bSkip = True
		End Try
		
		Me.dgvChapters.DataSource = Nothing
		Me.dgvTitles.DataSource = Nothing
		
		Dim DS As New DataSet("ReturnList")
		Dim sr As New System.IO.StringReader(responseContent)
		DS.Clear()
		Try
			DS.ReadXml(sr)
		Catch
			DS.Clear()
		End Try
		
		If (DS.Tables.Count > 0) Then
			For Each tDR As DataRow In DS.Tables("chapterInfo").Rows
				tDR.Item("confirmations") = tDR.GetChildRows("chapterInfo_chapters")(0).GetChildRows("chapters_chapter").Length.ToString.Trim.PadLeft(2)
				tDR.Item("extractor") = Strings.Left(tDR.GetChildRows("chapterInfo_source")(0).Item("fps").ToString, 6)
				tDR.Item("client") = Strings.Left(tDR.GetChildRows("chapterInfo_source")(0).Item("duration").ToString, 8)
				tDR.Item("updatedBy") = tDR.GetChildRows("chapterInfo_source")(0).Item("type").ToString
			Next
			
			Me.dgvTitles.DataSource = DS
			Me.dgvTitles.DataMember = "chapterInfo"
			
			Me.dgvChapters.DataSource = DS
			Me.dgvChapters.DataMember = "chapterInfo.chapterInfo_chapters.chapters_chapter"
			
			Me.dgvTitles.Focus()
			
		Else
			If Not bSkip Then ErrorBox("No chapter sets found.")
		End If
		
		Me.lSearching.Visible = False
		Me.Refresh
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Add line numbers to DataGridView rows.  Call from the RowPostPaint event. 
	''' </summary>
	''' <param name="sender">The DataGridView control firing the event.</param>
	''' <param name="e">The control's event arguments.</param>
	''' 
	Sub DgvAddLineNumbers(sender As Object, e As DataGridViewRowPostPaintEventArgs)
		Using b As SolidBrush = New SolidBrush(CType(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
				CType(sender, DataGridView).DefaultCellStyle.Font, _
				b, _
				e.RowBounds.Location.X + 20, _
				e.RowBounds.Location.Y + 4)
		End Using
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Handle the close button click event.  Close the form.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	Sub BExitClick(sender As Object, e As EventArgs)
		Me.Close()
	End Sub
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Sends the selected chapter information to the main working form and closes the search form.
	''' </summary>
	''' <param name="sender">The control that fired the event.</param>
	''' <param name="e">The control's event arguments.</param>
	Sub BImportClick(sender As Object, e As EventArgs)
		Dim cTimes() As String = {}
		Dim cTitles() As String = {}
		Dim es As String = ""
		If (Not Me.cbTimes.Checked) And (Not Me.cbTitles.Checked) Then es = "Please select information (times, titles, or both) to be imported."
		If (Me.dgvChapters.Rows.Count < 1) Then es = "Please select a chapter set to import."
		If Not es.Trim.Equals("") Then
			ErrorBox(es)
			Exit Sub
		End If
		es = ""
		For Each dgr As DataGridViewRow In Me.dgvChapters.Rows
			es &= dgr.Cells(0).Value.ToString.Trim & " ==> " & dgr.Cells(1).Value.ToString.Trim & Environment.NewLine
			AppendArray(cTimes, dgr.Cells(0).Value.ToString.Trim.Replace(",", ".")) 
			AppendArray(cTitles, dgr.Cells(1).Value.ToString.Trim) 
		Next
		
		For Each f As Form In My.Application.OpenForms
			If f.Name.Equals("MainForm") Then
				If cbTimes.Checked Then CType(f, MainForm).cTimes = cTimes 
				If cbTitles.Checked Then CType(f, MainForm).cTitles = cTitles 
			End If
		Next
		Me.Close()
	End Sub
	
		
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	''' <summary>
	''' Append a string value to specified array.
	''' </summary>
	''' <param name="arrayname">Name of the array to append the string.</param>
	''' <param name="linetoadd">String to append to the specified array.</param>
	''' <returns>True when the string has been appended.</returns>
	Private Function AppendArray(ByRef arrayname() as string, linetoadd As String) As Boolean
		Array.Resize(arrayname, arrayname.Length + 1)
		arrayname(arrayname.Length - 1) = linetoadd
		return true
	End Function
	
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Sub TbTitleSearchKeyUp(sender As Object, e As KeyEventArgs)
		If ((e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Return)) Then
			DoTheSearch()
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Sub SearchChapterDBShown(sender As Object, e As EventArgs)
		Me.tbTitleSearch.Text = "Enter Search Text"
		Me.tbTitleSearch.SelectAll()
		Me.tbTitleSearch.Focus()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
End Class

