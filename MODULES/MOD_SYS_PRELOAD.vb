Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Principal.WindowsIdentity 

Module MOD_SYS_PRELOAD
    Public new_prov As Boolean
    'Public lngCounter As Integer
    Public iCOUNTFIELLDS As String
    Public ProGramName As String
    Public FontN As String
    Public fontS As String
    Public FontC As String
    Public FontB As String
    Public RAZDEL As String

    Public KCKey As Integer
    Public DCKey As String
    Public TipTehn As String
    Public PrPath As String
    Public EverestFilePatch As String
    Public IdentifierMAC As String
    Public CS As String
    Public SUBD As String
    Public BaseName As String

    'Структура для перемещения
    Public sBranch As String
    Public sDepartment As String
    Public sOffice As String
    Public sName As String
    Public sOfficePACK As String
    'Пользователи программы
    Public uSERID As String
    Public UserNames As String
    Public uLevel As String
    Public uLevelSetup As Boolean
    Public uLevelTehAdd As Boolean
    Public uLevelTehDel As Boolean
    Public uLevelNotesAdd As Boolean
    Public uLevelNotesDel As Boolean
    Public uLevelRepAdd As Boolean
    Public uLevelRepDel As Boolean
    Public uLevelRepEd As Boolean
    Public uLevelPOAdd As Boolean
    Public uLevelPODel As Boolean
    Public uLevelCart As Boolean
    Public uLevelPO As Boolean
    Public uLevelWarehause As Boolean
    Public uPCNAME As String
    Public uUSERNAME As String
    Public uCASHE As String
    Public sLANGPATH As String

    Public Sub PreLoad()

        'Dim langFile As String
        PrPath = Directory.GetParent(Application.ExecutablePath).ToString & "\"

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        BasePath = objIniFile.GetString("general", "BasePath", "")
        IdentifierMAC = objIniFile.GetString("IdentifierMAC", "Check", "0")

        BasePath = BasePath & "\"
        'If Len(langFile) = 0 Or langFile = "" Or langFile = Nothing Then langFile = "ru.ini"
        'LangPath = Directory.GetParent(Application.ExecutablePath).ToString & "\lang\" & langFile


        If BasePath = Nothing Or Len(BasePath) < 3 Then

            BasePath = Directory.GetParent(Application.ExecutablePath).ToString & "\database\"
            objIniFile.WriteString("general", "BasePath", BasePath)
        End If

        Base_Name = objIniFile.GetString("general", "file", "basekomp.mdb")




        sOfficePACK = objIniFile.GetString("general", "Office", "OpenOffice.org")

        'sLANGPATH = PrPath & "lang\ru.ini"

        sLANGPATH = PrPath & "lang\" & objIniFile.GetString("general", "LANG", "ru.ini")



        Call UNAME_GET()
        Call iface_preload()

    End Sub

    Public Sub iface_preload()

        Dim objIniFile As New IniFile(PrPath & "base.ini")

        FontN = objIniFile.GetString("general", "Font", "")
        fontS = objIniFile.GetString("general", "FontSize", "")
        FontB = objIniFile.GetString("general", "FontBold", "")

    End Sub

    Public Sub UNAME_GET()
        Dim rName As String = My.Computer.Name
        Dim lSlash As Integer = rName.LastIndexOf("\")
        Dim fName As String = rName.Substring(lSlash + 1)

        uPCNAME = fName
        uUSERNAME = GetCurrent.Name

        's = GetCurrent.User.Value


    End Sub

    Public Sub ALTER_DB()
        'Dim sSQL As String
        'sSQL = "ALTER TABLE SPR_Uroven ALTER COLUMN Uroven Name TEXT(255)"
        'ALTER TABLE TableName ALTER COLUMN FieldName TEXT(255);

        'Dim rs As ADODB.Recordset
        'rs = New ADODB.Recordset

        'rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        'rs = Nothing

    End Sub

End Module

