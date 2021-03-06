﻿' -----------------------------------------------------------------------
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

Imports System.Reflection

Public Module Globals
	
	'Public Const AppBeta = "β1"
	Public Const AppBeta = ""
	
	Public Const VersionURL = "http://rdswift.github.io/ChapterMaker/version.txt"
	
	Public vMajor As Integer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major
	Public vMinor As Integer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor
	Public vBuild As Integer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build
	Public vRevision As Integer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision
	
	' -----------------------------------------------------------
	' Most constants are now read from the AssemblyInfo.vb file
	' to ensure consistency with information displayed under the
	' file properties.
	'
	' Version information is provided by a public function called
	' AppVersion(ShowBuild as Boolean) which appears at the end
	' of this module.
	' -----------------------------------------------------------
	'Public const AppName = "ChapterMaker"
	'Public appDescription As String = "Create and edit video chapter files"
	'Read information from AssemblyInfo.vb
	Public appName As String = Application.ProductName.Trim
	Public appCompany As String = Application.CompanyName.Trim
	Public AppDescription As String = CType(Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(System.Reflection.AssemblyDescriptionAttribute)), System.Reflection.AssemblyDescriptionAttribute).Description
	Public AppCopyright As String = CType(Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(System.Reflection.AssemblyCopyrightAttribute)), System.Reflection.AssemblyCopyrightAttribute).Copyright
	Public AppProduct As String = CType(Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(System.Reflection.AssemblyProductAttribute)), System.Reflection.AssemblyProductAttribute).Product
	Public AppTitle As String = CType(Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly, GetType(System.Reflection.AssemblyTitleAttribute)), System.Reflection.AssemblyTitleAttribute).Title
	Public AppFileRoot As String = AppTitle
	Public AppEmail As String = "bswift@rsds.ca"
	Public AppHelp As String = AppFileRoot & "Help.chm"
	
	
	Public AppConfig As Defaults
	Public AppFixCase As FixCase
	Public Languages() As String = { _
		"ara - Arabic", _
		"bul - Bulgarian", _
		"chi - Chinese", _
		"cze - Czech", _
		"dan - Danish", _
		"dut - Dutch", _
		"egy - Egyptian", _
		"eng - English", _
		"fin - Finnish", _
		"fre - French", _
		"ger - German", _
		"gre - Greek", _
		"heb - Hebrew", _
		"hun - Hungarian", _
		"ind - Indonesian", _
		"ita - Italian", _
		"jpn - Japanese", _
		"kor - Korean", _
		"nor - Norwegian", _
		"pol - Polish", _
		"por - Portuguese", _
		"rum - Romanian", _
		"rus - Russian", _
		"spa - Spanish", _
		"tha - Thai", _
		"tur - Turkish", _
		"ukr - Ukrainian", _
		"und - Undefined", _
		"vie - Vietnamese" _
	}
	
	
'	Public Languages() As String = { _
'		"aar - Afar", _
'		"abk - Abkhazian", _
'		"afr - Afrikaans", _
'		"aka - Akan", _
'		"alb - Albanian", _
'		"amh - Amharic", _
'		"ara - Arabic", _
'		"arg - Aragonese", _
'		"arm - Armenian", _
'		"asm - Assamese", _
'		"ava - Avaric", _
'		"ave - Avestan", _
'		"aym - Aymara", _
'		"aze - Azerbaijani", _
'		"bak - Bashkir", _
'		"bam - Bambara", _
'		"baq - Basque", _
'		"bel - Belarusian", _
'		"ben - Bengali", _
'		"bih - Bihari languages", _
'		"bis - Bislama", _
'		"bos - Bosnian", _
'		"bre - Breton", _
'		"bul - Bulgarian", _
'		"bur - Burmese", _
'		"cat - Catalan; Valencian", _
'		"cha - Chamorro", _
'		"che - Chechen", _
'		"chi - Chinese", _
'		"chu - Church Slavic", _
'		"chv - Chuvash", _
'		"cor - Cornish", _
'		"cos - Corsican", _
'		"cre - Cree", _
'		"cze - Czech", _
'		"dan - Danish", _
'		"div - Divehi; Dhivehi; Maldivian", _
'		"dut - Dutch; Flemish", _
'		"dzo - Dzongkha", _
'		"eng - English", _
'		"epo - Esperanto", _
'		"est - Estonian", _
'		"ewe - Ewe", _
'		"fao - Faroese", _
'		"fij - Fijian", _
'		"fin - Finnish", _
'		"fre - French", _
'		"fry - Western Frisian", _
'		"ful - Fulah", _
'		"geo - Georgian", _
'		"ger - German", _
'		"gla - Gaelic; Scottish Gaelic", _
'		"gle - Irish", _
'		"glg - Galician", _
'		"glv - Manx", _
'		"gre - Greek", _
'		"grn - Guarani", _
'		"guj - Gujarati", _
'		"hat - Haitian; Haitian Creole", _
'		"hau - Hausa", _
'		"heb - Hebrew", _
'		"her - Herero", _
'		"hin - Hindi", _
'		"hmo - Hiri Motu", _
'		"hrv - Croatian", _
'		"hun - Hungarian", _
'		"ibo - Igbo", _
'		"ice - Icelandic", _
'		"ido - Ido", _
'		"iii - Sichuan Yi; Nuosu", _
'		"iku - Inuktitut", _
'		"ile - Interlingue", _
'		"ina - Interlingua", _
'		"ind - Indonesian", _
'		"ipk - Inupiaq", _
'		"ita - Italian", _
'		"jav - Javanese", _
'		"jpn - Japanese", _
'		"kal - Kalaallisut; Greenlandic", _
'		"kan - Kannada", _
'		"kas - Kashmiri", _
'		"kau - Kanuri", _
'		"kaz - Kazakh", _
'		"khm - Central Khmer", _
'		"kik - Kikuyu; Gikuyu", _
'		"kin - Kinyarwanda", _
'		"kir - Kirghiz; Kyrgyz", _
'		"kom - Komi", _
'		"kon - Kongo", _
'		"kor - Korean", _
'		"kua - Kuanyama; Kwanyama", _
'		"kur - Kurdish", _
'		"lao - Lao", _
'		"lat - Latin", _
'		"lav - Latvian", _
'		"lim - Limburgan; Limburger; Limburgish", _
'		"lin - Lingala", _
'		"lit - Lithuanian", _
'		"ltz - Luxembourgish; Letzeburgesch", _
'		"lub - Luba-Katanga", _
'		"lug - Ganda", _
'		"mac - Macedonian", _
'		"mah - Marshallese", _
'		"mal - Malayalam", _
'		"mao - Maori", _
'		"mar - Marathi", _
'		"may - Malay", _
'		"mlg - Malagasy", _
'		"mlt - Maltese", _
'		"mon - Mongolian", _
'		"nau - Nauru", _
'		"nav - Navajo; Navaho", _
'		"nbl - South Ndebele", _
'		"nde - North Ndebele", _
'		"ndo - Ndonga", _
'		"nep - Nepali", _
'		"nno - Norwegian Nynorsk", _
'		"nob - Norwegian Bokmål", _
'		"nor - Norwegian", _
'		"nya - Chichewa; Chewa; Nyanja", _
'		"oci - Occitan (post 1500); Provençal", _
'		"oji - Ojibwa", _
'		"ori - Oriya", _
'		"orm - Oromo", _
'		"oss - Ossetian; Ossetic", _
'		"pan - Panjabi; Punjabi", _
'		"per - Persian", _
'		"pli - Pali", _
'		"pol - Polish", _
'		"por - Portuguese", _
'		"pus - Pushto; Pashto", _
'		"que - Quechua", _
'		"roh - Romansh", _
'		"rum - Romanian; Moldavian; Moldovan", _
'		"run - Rundi", _
'		"rus - Russian", _
'		"sag - Sango", _
'		"san - Sanskrit", _
'		"sin - Sinhala", _
'		"slo - Slovak", _
'		"slv - Slovenian", _
'		"sme - Northern Sami", _
'		"smo - Samoan", _
'		"sna - Shona", _
'		"snd - Sindhi", _
'		"som - Somali", _
'		"sot - Southern Sotho", _
'		"spa - Spanish; Castilian", _
'		"srd - Sardinian", _
'		"srp - Serbian", _
'		"ssw - Swati", _
'		"sun - Sundanese", _
'		"swa - Swahili", _
'		"swe - Swedish", _
'		"tah - Tahitian", _
'		"tam - Tamil", _
'		"tat - Tatar", _
'		"tel - Telugu", _
'		"tgk - Tajik", _
'		"tgl - Tagalog", _
'		"tha - Thai", _
'		"tib - Tibetan", _
'		"tir - Tigrinya", _
'		"ton - Tonga (Tonga Islands)", _
'		"tsn - Tswana", _
'		"tso - Tsonga", _
'		"tuk - Turkmen", _
'		"tur - Turkish", _
'		"twi - Twi", _
'		"uig - Uighur; Uyghur", _
'		"ukr - Ukrainian", _
'		"und - Undefined", _
'		"urd - Urdu", _
'		"uzb - Uzbek", _
'		"ven - Venda", _
'		"vie - Vietnamese", _
'		"vol - Volapük", _
'		"wel - Welsh", _
'		"wln - Walloon", _
'		"wol - Wolof", _
'		"xho - Xhosa", _
'		"yid - Yiddish", _
'		"yor - Yoruba", _
'		"zha - Zhuang; Chuang", _
'		"zul - Zulu" _
'	}

	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Return the version number based on the value in the AssemblyInfo.vb file, appending the AppBeta string defined above

	Public Function AppVersion(Optional ByVal ShowBuild As Boolean = False) As String
		Dim s1 As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString.Trim
		If Not ShowBuild Then s1 = String.Format("{0}.{1}", vMajor, vMinor)
		Return s1 & AppBeta
	End Function

	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Verify that the help file exists
	
	Public Function HelpFileExists() As Boolean
		If System.IO.File.Exists(AppHelp) Then Return True
		ErrorBox("Unable to locate the help file """ & AppHelp & """ in the program directory.")
		Return False
	End Function
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	'
	'	Standard error messagebox
	
	Public Sub ErrorBox(ByVal ErrorMessage As String, optional byval ErrorTitle As String = "Error")
		MsgBox(ErrorMessage, MsgBoxStyle.ApplicationModal Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, ErrorTitle)
	End Sub
	
	'-----------------------------------------------------------------------------------------------------------------------------------------------------
	
End Module
