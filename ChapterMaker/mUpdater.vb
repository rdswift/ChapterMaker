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

Public Module mUpdater
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Checks specified url for current version number.  Returns version (ByRef), download URL (ByRef) and whether check completed successfully (Boolean)
	
	Private Function CheckUpdate(ByVal URL2Check As String, ByRef cVersion As String, ByRef cFilename As String) As Boolean
        Dim S As String = ""
        Dim RetVal As Boolean = True
        cVersion = ""
        cFilename = ""
        Try
        	Dim Request As System.Net.WebRequest = System.Net.WebRequest.Create(URL2Check)
            Dim Response As System.Net.WebResponse = Request.GetResponse()
            Using Reader As System.IO.StreamReader = New System.IO.StreamReader(Response.GetResponseStream())
                Do While Reader.Peek <> -1
                    S = Reader.ReadLine.Trim
                    If S.StartsWith("Version:", StringComparison.CurrentCultureIgnoreCase) Then
                        cVersion = Mid(S, 9).Trim
                    End If
                    If S.StartsWith("FileName:", StringComparison.CurrentCultureIgnoreCase) Then
                        cFilename = Mid(S, 10).Trim
                    End If
                Loop
            End Using
        Catch ex As Exception
            RetVal = False
            cVersion = ""
            cFilename = ""
        End Try
        'MessageBox.Show("Return: " & RetVal.ToString & vbCrLf & "Version: " & cVersion & vbCrLf & "FileName: " & cFilename, "Return")
        Return RetVal
    End Function
    
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Checks standard locations for words list file and creates file if none exists
	
    Public Sub CheckForUpdates(Optional ByVal AlwaysShowUpdate As Boolean = False)
        Dim cVersion, cFileName, S1, myCheckURL As String
        Dim mbButton As MessageBoxButtons = MessageBoxButtons.OK
        Dim ShowUpdate As Boolean = AlwaysShowUpdate
        Dim curVersion As String = String.Format("v{0}.{1:00}", vMajor, vMinor)
        cVersion = ""
        cFileName = ""
        myCheckURL = VersionURL

        S1 = "No update available."
        If CheckUpdate(myCheckURL, cVersion, cFileName) Then
            If cVersion > curVersion Then S1 = "There is an update available."
            S1 &= vbCrLf & vbCrLf & "Your Version: " & curVersion & vbCrLf & "Current Version: " & cVersion
            If cVersion > curVersion Then
                S1 &= vbCrLf & vbCrLf & "Would you like to download the new version?"
                mbButton = MessageBoxButtons.YesNo
                ShowUpdate = True
            End If
        Else
            S1 = "Problem connecting with download site over the Internet.  Please try again later."
        End If
        If ShowUpdate Then
'            cVersion = constDownloadURL
'            cVersion = constDownloadDir & cFileName
            cVersion = cFileName
            If MessageBox.Show(S1, "Update Check", mbButton) = Windows.Forms.DialogResult.Yes Then Process.Start(cVersion)
        End If
    End Sub
    
    '-----------------------------------------------------------------------------------------------------------------------------------------------------

End Module
