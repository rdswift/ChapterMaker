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

Public Class Defaults
	Public Const DefXML = "xml"
	Public Const DefOGM = "chapters.txt"
	Public Const DefTXT = "txt"
	
	Private FNAME As String = AppFileRoot & ".cfg"
	
	Public Enum cmOutputType
		XML = 1
		OGM = 2
		TXT = 3
	End Enum
	
	Public Enum cmNoTitle
		ChapterNum = 1
		NA = 2
		ChapterTime = 3
	End Enum
	
	Private myCfgFileName As String
	Private myOutputType As Integer
	Private myFrameRate As Double
	Private myOutFilePath As String
	Private myAddNumbers As Boolean
	Private myAddTimes As Boolean
	Private myLanguage As String
	Private myConfirmDelete As Boolean
	Private myConfirmInsert As Boolean
	Private myConfirmModify As Boolean
	Private myNoTitle As Integer
	Private myXMLExt As String
	Private myOGMExt As String
	Private myTXTExt As String
	Private myUpdateCheck As Boolean
	Private myLoadAppend As Boolean
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Public Sub New()
		myOutputType = cmOutputType.XML
		myFrameRate = 23.976
		myOutFilePath = ""
		myLanguage = "und"
		myAddNumbers = False
		myAddTimes = False
		myConfirmDelete = True
		myConfirmInsert = True
		myConfirmModify = True
		myUpdateCheck = True
		myLoadAppend = True
		myNoTitle = cmNoTitle.ChapterNum
		myXMLExt = DefXML
		myOGMExt = DefOGM
		myTXTExt = DefTXT
		myCfgFileName = GetFileName()
		If myCfgFileName.Trim.Length < 1 Then
			MsgBox("Error accessing the application configuration file.", MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
		End If
		Read()
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
	Public Property OutputType() As Integer
		Get
			Return myOutputType
		End Get
		Set(ByVal value As Integer)
			myOutputType = value
		End Set
	End Property
	
	Public Property FrameRate() As Double
		Get
			Return myFrameRate
		End Get
		Set(ByVal value As Double)
			myFrameRate = value
		End Set
	End Property
	
	Public Property OutFilePath() As String
		Get
			Return myOutFilePath
		End Get
		Set(ByVal value As String)
			myOutFilePath = value.Trim
			If (myOutFilePath.Length > 0) And (Not myOutFilePath.EndsWith("\")) Then myOutFilePath &= "\"
		End Set
	End Property
	
	Public Property AddNumbers() As Boolean
		Get
			Return myAddNumbers
		End Get
		Set(ByVal value As Boolean)
			myAddNumbers = value
		End Set
	End Property
	
	Public Property AddTimes() As Boolean
		Get
			Return myAddTimes
		End Get
		Set(ByVal value As Boolean)
			myAddTimes = value
		End Set
	End Property
	
	Public Property ConfirmInsert() As Boolean
		Get
			Return myConfirmInsert
		End Get
		Set(ByVal value As Boolean)
			myConfirmInsert = value
		End Set
	End Property
	
	Public Property ConfirmModify() As Boolean
		Get
			Return myConfirmModify
		End Get
		Set(ByVal value As Boolean)
			myConfirmModify = value
		End Set
	End Property
	
	Public Property ConfirmDelete() As Boolean
		Get
			Return myConfirmDelete
		End Get
		Set(ByVal value As Boolean)
			myConfirmDelete = value
		End Set
	End Property
	
	Public Property UpdateCheck() As Boolean
		Get
			Return myUpdateCheck
		End Get
		Set(ByVal value As Boolean)
			myUpdateCheck = value
		End Set
	End Property
	
	Public Property LoadAppend() As Boolean
		Get
			Return myLoadAppend
		End Get
		Set(ByVal value As Boolean)
			myLoadAppend = value
		End Set
	End Property
	
	Public Property Language() As String
		Get
			Return myLanguage.Trim.ToLower
		End Get
		Set(ByVal value As String)
			If value.Trim.Length <> 3 Then value = "und"
			myLanguage = value.Trim.ToLower
		End Set
	End Property
	
	Public Property NoTitle() As Integer
		Get
			Return myNoTitle
		End Get
		Set(ByVal value As Integer)
			myNoTitle = value
		End Set
	End Property
	
	Public Property OGMExt() As String
		Get
			Return myOGMExt.Trim
		End Get
		Set(ByVal value As String)
			myOGMExt = FixExt(value, DefOGM)
		End Set
	End Property
		
	Public Property XMLExt() As String
		Get
			Return myXMLExt.Trim
		End Get
		Set(ByVal value As String)
			myXMLExt = FixExt(value,"")
		End Set
	End Property
		
	Public Property TXTExt() As String
		Get
			Return myTXTExt.Trim
		End Get
		Set(ByVal value As String)
			myTXTExt = FixExt(value,"")
		End Set
	End Property
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Validate and repair TXT, OGM and XML File Extensions
	
	Public Function FixExt(ByVal value As String, ByVal DefVal as String) As String
		value = value.Trim
		Do While (value.Trim.Length > 0 ) And (value.Trim.EndsWith("."))
			value = value.Trim.Substring(0,value.Trim.Length - 1)
		Loop
		Do While (value.Trim.Length > 0 ) And (value.Trim.StartsWith("."))
			value = value.Trim.Substring(1,value.Trim.Length - 1)
		Loop
		If value.Trim.Length < 1 Then value = defval
'		If Not value.Trim.StartsWith(".") Then value = "." & value.Trim
		Return value.Trim
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Read the settings from the configuration file
	
	Public Sub Read()
		Dim s1, s2, s3, s4 As String
		Dim d1 As Double
		
		If myCfgFileName.Trim.Length > 0 Then
			
			'Configuration File Name
			s1 = myCfgFileName
			
			'Append Input Files
            s2 = "Input"
            s3 = "AppendLoad"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            If s4 <> "" Then myLoadAppend = s4.Trim.ToUpper.StartsWith("Y")
			
            'Output File Type
            s2 = "Output"
            s3 = "FileType"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            myOutputType = cmOutputType.XML
            If s4 <> "" Then
            	If s4.Equals("XML", StringComparison.OrdinalIgnoreCase) Then myOutputType = cmOutputType.XML
            	If s4.Equals("OGM", StringComparison.OrdinalIgnoreCase) Then myOutputType = cmOutputType.OGM
            	If s4.Equals("TXT", StringComparison.OrdinalIgnoreCase) Then myOutputType = cmOutputType.TXT
            End If
            
            'Output File directory
            s3 = "Directory"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            myOutFilePath = s4
            
            'TXT Output File extension
            s3 = "TXTExtension"
            s4 = ReadIni(s1, s2, s3, "").Trim
            myTXTExt = FixExt(s4, DefTXT)
            
            'XML Output File extension
            s3 = "XMLExtension"
            s4 = ReadIni(s1, s2, s3, "").Trim
            myXMLExt = FixExt(s4, DefXML)
            
            'OGM Output File extension
            s3 = "OGMExtension"
            s4 = ReadIni(s1, s2, s3, "").Trim
            myOGMExt = FixExt(s4, DefOGM)
            
            'Add Chapter Numbers
            s3 = "ChapterNumbers"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            If s4 <> "" Then myAddNumbers = s4.Trim.ToUpper.StartsWith("Y")
            
            'Add Chapter Times
            s3 = "ChapterTimes"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            If s4 <> "" Then myAddTimes = s4.Trim.ToUpper.StartsWith("Y")
            
            'Missing Chapter Titles
            s3 = "MissingTitle"
            s4 = ReadIni(s1, s2, s3, "").Trim
            myNoTitle = cmNoTitle.ChapterNum
            If s4 <> "" Then
            	If s4.Equals("ChapterNum", StringComparison.OrdinalIgnoreCase) Then myNoTitle = cmNoTitle.ChapterNum
            	If s4.Equals("NA", StringComparison.OrdinalIgnoreCase) Then myNoTitle = cmNoTitle.NA
            	If s4.Equals("ChapterTime", StringComparison.OrdinalIgnoreCase) Then myNoTitle = cmNoTitle.ChapterTime
            End If
            
            'Confirm Delete
            s2 = "Confirmation"
            s3 = "ConfirmDelete"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            If s4 <> "" Then myConfirmDelete = s4.Trim.ToUpper.StartsWith("Y")
            
            'Confirm Insert
            s3 = "ConfirmInsert"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            If s4 <> "" Then myConfirmInsert = s4.Trim.ToUpper.StartsWith("Y")
            
            'Confirm Modify
            s3 = "ConfirmModify"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            If s4 <> "" Then myConfirmModify = s4.Trim.ToUpper.StartsWith("Y")
            
            'Check for Updates
            s3 = "UpdateCheck"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            If s4 <> "" Then myUpdateCheck = s4.Trim.ToUpper.StartsWith("Y")
            
            'Language Code
            s2 = "Defaults"
            s3 = "Language"
            s4 = ReadIni(s1, s2, s3, "").Trim
            If s4 <> "" Then
            	myLanguage = s4
            Else
            	myLanguage = "eng"
            End If
            
            'Frame Rate
            s3 = "FrameRate"
            s4 = ReadIni(s1, s2, s3, "").Trim.ToUpper
            d1 = Convert.ToDouble(s4)
            If d1 > 0 Then myFrameRate = d1
            
		End If
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Save the settings to the configuration file
	
	Public Function Write() As Boolean
		Try
			System.IO.File.WriteAllText(myCfgFileName.Trim, MakeFileContents())
			Return True
		Catch
			Return False
		End Try
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Searches standard locations for configuration file and creats one if none exists
	
	Private Function GetFileName() As String
		Dim s1, s2, s3, sFilePath As String
		
		s1 = Application.StartupPath
		If Not s1.EndsWith("\") Then s1 &= "\"
		s1 &= FNAME
		
		s2 = Application.CommonAppDataPath
		s2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
		If Not s2.EndsWith("\") Then s2 &= "\"
		s2 &= "ChapterMaker\" & FNAME
		
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
		
		s3 = MakeFileContents()
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
	'	Make string contents of settings output file to save
	
	Private Function MakeFileContents() As String
		Dim oFT As String = "XML"
		If (myOutputType = cmOutputType.OGM) Then oFT = "OGM"  
		If (myOutputType = cmOutputType.XML) Then oFT = "XML"
		If (myOutputType = cmOutputType.TXT) Then oFT = "TXT"
		Dim oFP As String = myOutFilePath.Trim
		Dim sMT As String = ""
		If (myNoTitle = cmNoTitle.ChapterNum) Then sMT = "ChapterNum"
		If (myNoTitle = cmNoTitle.ChapterTime) Then sMT = "ChapterTime"
		If (myNoTitle = cmNoTitle.NA) Then sMT = "NA"
		Dim sCD As String = "Yes"
		If Not myConfirmDelete Then sCD = "No"
		Dim sCI As String = "Yes"
		If Not myConfirmInsert Then sCI = "No"
		Dim sCM As String = "Yes"
		If Not myConfirmModify Then sCM = "No"
		Dim sUC As String = "Yes"
		If Not myUpdateCheck Then sUC = "No"
		Dim sAL As String = "Yes"
		If Not myLoadAppend Then sAL = "No"
		Dim dLan As String = myLanguage.Trim.ToLower
		If dLan.Trim.Length <> 3 Then dLan = "und"
		Dim dFR As String = myFrameRate.ToString.Trim
		Dim dCN As String = "No"
		If myAddNumbers Then dCN = "Yes"
		Dim dCT As String = "No"
		If myAddTimes Then dCT = "Yes"
		
		Dim filecontents As String = ";=================================================================" & Environment.NewLine _
			& ";" & Environment.NewLine _
			& "; Local Configuration Information for ChapterMaker Application" & Environment.NewLine _
			& ";" & Environment.NewLine _
			& ";=================================================================" & Environment.NewLine _
			& Environment.NewLine & Environment.NewLine & "[Input]" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "; AppendLoad:  Loading times or titles will append to existing list (Yes|No)" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "AppendLoad=" & sAL & Environment.NewLine _
			& Environment.NewLine & Environment.NewLine & "[Output]" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "; FileType:  Type of output file to generate (TXT|XML|OGM)" & Environment.NewLine _
			& "; TXTExtension:  Default extension for TXT output files" & Environment.NewLine _
			& "; XMLExtension:  Default extension for XML output files" & Environment.NewLine _
			& "; OGMExtension:  Default extension for OGM output files" & Environment.NewLine _
			& "; Directory: Default directory to write output file" & Environment.NewLine _
			& "; ChapterNumbers: Include chapter numbers in titles (Yes|No)" & Environment.NewLine _
			& "; ChapterTimes: Include chapter times in titles (Yes|No)" & Environment.NewLine _
			& "; MissingTitle:  How to deal with missing titles (ChapterNum|ChapterTime|NA)" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "FileType=" & oFT & Environment.NewLine _
			& "TXTExtension=" & myTXTExt & Environment.NewLine _
			& "XMLExtension=" & myXMLExt & Environment.NewLine _
			& "OGMExtension=" & myOGMExt & Environment.NewLine _
			& "Directory=" & oFP & Environment.NewLine _
			& "ChapterNumbers=" & dCN & Environment.NewLine _
			& "ChapterTimes=" & dCT & Environment.NewLine _
			& "MissingTitle=" & sMT & Environment.NewLine _
			& Environment.NewLine & Environment.NewLine & "[Confirmation]" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "; ConfirmInsert: Confirm before inserting times or titles (Yes|No)" & Environment.NewLine _
			& "; ConfirmModify: Confirm before modifying times or titles (Yes|No)" & Environment.NewLine _
			& "; ConfirmDelete: Confirm before deleting times or titles (Yes|No)" & Environment.NewLine _
			& "; UpdateCheck: Check for program updates at start-up (Yes|No)" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "ConfirmInsert=" & sCI & Environment.NewLine _
			& "ConfirmModify=" & sCM & Environment.NewLine _
			& "ConfirmDelete=" & sCD & Environment.NewLine _
			& "UpdateCheck=" & sUC & Environment.NewLine _
			& Environment.NewLine & Environment.NewLine & "[Defaults]" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "; Language: Three character language code (Default is 'und')" & Environment.NewLine _
			& "; FrameRate: Used for time adjustments. Typically 23.976 or 29.970" & Environment.NewLine _
			& ";-----------------------------------------------------------------" & Environment.NewLine _
			& "Language=" & dLan & Environment.NewLine _
			& "FrameRate=" & dFR & Environment.NewLine
		Return filecontents
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
End Class
