Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Principal.WindowsIdentity 

Module MOD_SYS_PRELOAD
    Public new_prov As Boolean
    'Public lngCounter As Integer
    Public iCOUNTFIELLDS As String
    Public ITEM_DB_COUNT As String
    Public ProGramName As String
    Public FontN As String
    Public fontS As Double
    Public FontC As String
    Public FontB As Boolean
    Public FontSt As System.Drawing.FontStyle
    Public FontD As System.Drawing.GraphicsUnit
    Public FontI As Integer
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
    Public sICONS As String
    Public sRelogin As Boolean = False
    Public sTechINF As String

    Public _DBALTER As Boolean = False
    Public sVERSIA As String



    Public Sub Tree_Icons_Feel(ByVal ills As ImageList, ByVal sFRM As String, ByVal sPATH As String)

        On Error Resume Next

        ills.Images.Clear()



        Select Case sICONS


            Case "32*32"

                frmComputers.ilsCommands.ImageSize = New System.Drawing.Size(32, 32)

            Case Else

                frmComputers.ilsCommands.ImageSize = New System.Drawing.Size(24, 24)

        End Select


        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A1.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A2.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A3.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A4.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A5.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A6.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A7.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A8.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "A9.png"))

        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B1.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B2.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B3.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B4.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B5.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B6.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B7.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B8.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "B9.png"))

        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C1.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C2.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C3.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C4.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C5.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C6.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C7.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C8.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "C9.png"))

        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D1.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D2.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D3.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D4.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D5.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D6.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D7.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D8.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "D9.png"))

        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E1.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E2.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E3.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E4.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E5.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E6.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E7.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E8.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "E9.png"))

        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F1.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F2.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F3.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F4.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F5.png"))

        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F6.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F7.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F8.png"))
        ills.Images.Add(Image.FromFile(PrPath & sPATH & "F9.png"))

        If sFRM <> "DIR" Then

            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G1.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G2.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G3.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G4.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G5.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G6.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G7.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G8.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "G9.png"))

            ills.Images.Add(Image.FromFile(PrPath & sPATH & "H1.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "H2.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "H3.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "H4.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "H5.png"))

            ills.Images.Add(Image.FromFile(PrPath & sPATH & "I1.png"))
            ills.Images.Add(Image.FromFile(PrPath & sPATH & "A0.png"))
        Else

        End If



        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-branche.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-department.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-office.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-server.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-pc.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-notebook.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-pda.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-printer.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-mfu.png"))

        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-copir.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-network.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-photo.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-phone.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-fax.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-scanner.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-zip.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-other.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-monitor.png"))

        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-flash.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-calc.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-garnitura.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-microphone.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-webcamera.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-gamepad.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-planshet.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-flash-2.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-flash-3.png"))

        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-flash-4.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-video.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-ipad.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-antenna.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-mobile-1.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-mobile-2.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-monitor-2.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-projector.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-monitor-3.png"))

        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-workkey.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-usb.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-dvd.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-hdd.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-photo-2.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-ups.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-rupor.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-people.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-audio.png"))

        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-usb-2.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-keyboard.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-mouse.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-acdc.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-cartridg.png"))

        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-cable.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-portfel.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-battery.png"))
        'ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-papper.png"))

        'If sFRM <> "DIR" Then

        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-battery-2.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-bp.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-cable-2.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-other-2.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-other-3.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-pcmci.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-other-4.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-fs.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-flash-5.png"))

        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-soft.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-scanner-2.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-other-5.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-other-6.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-bluetouch.png"))

        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-server-2.png"))
        '    ills.Images.Add(Image.FromFile(PrPath & sPATH & "bko-root.png"))
        'Else

        'End If



        Dim allowedExtensions() As String = {".png"}
        Dim dirFiles() As String = IO.Directory.GetFiles(PrPath & "pic\")


        For Each dirFile As String In dirFiles
            For Each extension As String In allowedExtensions
                If extension = IO.Path.GetExtension(dirFile) Then
                    ills.Images.Add(Image.FromFile(dirFile))
                End If
            Next
        Next




    End Sub

    Public Sub frmservills_load()

        If frmserviceDesc.ilsCMD.Images.Count = 0 Then

            frmserviceDesc.ilsCMD.Images.Add(Image.FromFile(PrPath & "pic\iface\ok.png"))
            frmserviceDesc.ilsCMD.Images.Add(Image.FromFile(PrPath & "pic\iface\servnz.png"))
            frmserviceDesc.ilsCMD.Images.Add(Image.FromFile(PrPath & "pic\iface\pcupdate.png"))

        End If

    End Sub

    Public Sub PreLoad()

        'Dim langFile As String
        PrPath = Directory.GetParent(Application.ExecutablePath).ToString & "\"

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        BasePath = objIniFile.GetString("general", "BasePath", "")
        IdentifierMAC = objIniFile.GetString("IdentifierMAC", "Check", "0")

        BasePath = BasePath & "\"

        If BasePath = Nothing Or Len(BasePath) < 3 Then

            BasePath = Directory.GetParent(Application.ExecutablePath).ToString & "\database\"
            objIniFile.WriteString("general", "BasePath", BasePath)
        End If

        Base_Name = objIniFile.GetString("general", "file", "basekomp.mdb")

        sOfficePACK = objIniFile.GetString("general", "Office", "OpenOffice.org")

        sLANGPATH = PrPath & "lang\" & objIniFile.GetString("general", "LANG", "ru.ini")

        sICONS = objIniFile.GetString("General", "ICONs", "24*24")

        sTechINF = objIniFile.GetString("General", "TechINF", "AIDA64(Everest)")

        FontI = objIniFile.GetString("General", "chkFonts", "0")

        Select Case sICONS

            Case "32*32"

                sICONS = "32*32"

            Case Else

                sICONS = "24*24"

        End Select



        Call UNAME_GET()
        Call iface_preload()





    End Sub

    Public Sub iface_preload()

        Dim objIniFile As New IniFile(PrPath & "base.ini")

        FontN = objIniFile.GetString("general", "Font", "Microsoft Sans Serif")
        fontS = objIniFile.GetString("general", "FontSize", "9")
        FontC = objIniFile.GetString("general", "FontColor", "Black")
        FontB = objIniFile.GetString("general", "FontBold", "False")
        FontSt = objIniFile.GetString("general", "FontStyle", "0")
        FontD = objIniFile.GetString("general", "FontUnit", "3")

        If fontS > 10 Then fontS = 10


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


        Call ALTER_DB17351()


    End Sub


    '    Public Sub ALTER_DB1735()
    '        On Error GoTo err_

    '        If _DBALTER = False Then Exit Sub

    '        Dim rs As ADODB.Recordset
    '        Dim sSQL, sSQLver As String

    '        sSQL = "ALTER TABLE kompy ADD SNMP_COMMUNITY TEXT, SNMP YESNO"


    '        Select Case DB_N

    '            Case "MS SQL 2008"

    '                sSQL = "ALTER TABLE " & DBtabl & ".dbo.kompy ADD SNMP_COMMUNITY TEXT, SNMP tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MS SQL"

    '                sSQL = "ALTER TABLE " & DBtabl & ".dbo.kompy ADD SNMP_COMMUNITY TEXT, SNMP tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MS Access"

    '                sSQL = "ALTER TABLE kompy ADD SNMP_COMMUNITY TEXT, SNMP LOGICAL"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MySQL"

    '                sSQL = "ALTER TABLE 'kompy' ADD COLUMN 'SNMP_COMMUNITY' TEXT, ADD COLUMN 'SNMP' tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MySQL (MyODBC 5.1)"

    '                sSQL = "ALTER TABLE 'kompy' ADD COLUMN 'SNMP_COMMUNITY' TEXT, ADD COLUMN 'SNMP' tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "PostgreSQL"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "SQLLite"


    '            Case "DSN"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '        End Select

    '        Call ALTER_DB17351()


    '        Exit Sub
    'err_:
    '        MsgBox(Err.Description)
    '        rs = Nothing
    '        _DBALTER = True

    '    End Sub

    Public Sub ALTER_DB17351()

        On Error GoTo err_

        If _DBALTER = False Then Exit Sub

        Dim rs As ADODB.Recordset
        Dim sSQL17351, sSQL1734, sSQLver As String

        sSQL17351 = "ALTER TABLE Remont ADD GARANT Date"

        sSQLver = "Update CONFIGURE SET access='1.7.3.5.1' WHERE access<>'1.7.3.5.1'"

        Select Case DB_N

            Case "MS SQL 2008"

                sSQL17351 = "ALTER TABLE " & DBtabl & ".dbo.Remont ADD GARANT datetime"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "MS SQL"

                sSQL17351 = "ALTER TABLE " & DBtabl & ".dbo.Remont ADD GARANT datetime"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "MS Access"

                'bit
                'ALTER TABLE 'kompy' ADD COLUMN 'SNMP_COMMUNITY' TEXT AFTER 'PATH', ADD COLUMN 'SNMP' tinyint(4) DEFAULT '0' AFTER 'SNMP_COMMUNITY';
                sSQL1734 = "ALTER TABLE 'kompy' ADD COLUMN 'SNMP_COMMUNITY' TEXT AFTER 'PATH', ADD COLUMN 'SNMP' tinyint(4) DEFAULT '0' AFTER 'SNMP_COMMUNITY';"

                'Версия 1.7.3.5.1

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "MySQL"
                ' ALTER TABLE 'kompy' ADD COLUMN 'SVGA2_NAME' TEXT AFTER 'SVGA_PROIZV',

                sSQL17351 = "ALTER TABLE Remont ADD COLUMN GARANT Date"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case "MySQL (MyODBC 5.1)"

                sSQL17351 = "ALTER TABLE Remont ADD COLUMN GARANT Date"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case "PostgreSQL"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "SQLLite"

            Case "DSN"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

        End Select

        rs = New ADODB.Recordset
        rs.Open(sSQLver, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        _DBALTER = False

        Exit Sub
err_:
        ' MsgBox(Err.Description)
        rs = Nothing
        _DBALTER = True
    End Sub

    Public Sub VisibleForm(ByVal ControlContainer As Object)

        frmComputers.sCPU = 4
        frmComputers.sRAM = 4
        frmComputers.sHDD = 4
        frmComputers.sVGA = 2
        frmComputers.sOPTICAL = 3
        frmComputers.sNET = 2

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then
                    VisibleForm(Ctl)

                    If TypeOf Ctl Is TextBox Then Ctl.visible = True
                    If TypeOf Ctl Is ComboBox Then Ctl.visible = True

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        frmComputers.bCPUPlus.Visible = False
        frmComputers.bRamPlus.Visible = False
        frmComputers.bHddPlus.Visible = False
        frmComputers.bSVGAPlus.Visible = False
        frmComputers.bOpticalPlus.Visible = False
        frmComputers.bNETPlus.Visible = False
        frmComputers.bMonitorPlus.Visible = False
        frmComputers.bPrinterPlus.Visible = False

    End Sub

    Public Sub ClearForm(ByVal ControlContainer As Object)


        Dim A1 As String
        A1 = frmComputers.treebranche.Text

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then

                    ClearForm(Ctl)

                    If TypeOf Ctl Is TextBox Then Ctl.ResetText()
                    If TypeOf Ctl Is ComboBox Then Ctl.ResetText()
                    If TypeOf Ctl Is ListView Then Ctl.items.clear()
                    'If TypeOf Ctl Is CheckBox Then Ctl.checked = False
                    If TypeOf Ctl Is RadioButton Then Ctl.checked = False


                    ' If TypeOf Ctl Is ToolStrip Then Ctl.rendermode = ToolStripRenderMode.System

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        frmComputers.chkPCspis.Checked = False
        frmComputers.chkPCNNb.Checked = False
        frmComputers.chkPRNspis.Checked = False
        frmComputers.chkPRNNNb.Checked = False
        frmComputers.chkNETspis.Checked = False
        frmComputers.chkNETNNb.Checked = False
        frmComputers.chkOTHNNb.Checked = False
        frmComputers.chkOTHspis.Checked = False

        'frmComputers.chkSNMP.Checked = False

        'If TipTehn = "IBP" Then

        '    frmComputers.chkSNMP.Visible = True

        'Else

        '   frmComputers.chkSNMP.Visible = False

        'End If



        'frmComputers.Label94.Text = "---"
        'frmComputers.Label95.Text = "---"
        'frmComputers.Label96.Text = "---"
        'frmComputers.Label97.Text = "---"
        'frmComputers.Label110.Text = "---"
        'frmComputers.Label111.Text = "---"
        'frmComputers.Label112.Text = "---"
        'frmComputers.Label113.Text = "---"
        'frmComputers.Label102.Text = "---"
        'frmComputers.Label103.Text = "---"
        'frmComputers.Label104.Text = "---"
        'frmComputers.Label105.Text = "---"
        'frmComputers.txtOTHSN.Text = "---"
        'frmComputers.txtOTHMAC.Text = "---"

        frmComputers.treebranche.Text = A1


    End Sub

    Public Sub COLOR_Form_For_Computer(ByVal ControlContainer As Object)

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then
                    COLOR_Form_For_Computer(Ctl)

                    If TypeOf Ctl Is TextBox Then Ctl.BackColor = Color.White
                    If TypeOf Ctl Is ComboBox Then Ctl.BackColor = Color.White

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next


    End Sub

    Public Sub SendFonts(ByVal ControlContainer As Object)

        If FontI = 0 Then Exit Sub

        If FontN = "Microsoft Sans Serif" And fontS = "8,25" And FontC = "Black" And FontB = False And FontSt = 0 And FontD = 3 Then Exit Sub

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then
                    SendFonts(Ctl)

                    If TypeOf Ctl Is TextBox Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is ComboBox Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is Label Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is ListView Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is TreeView Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is TabPage Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is GroupBox Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is DateTimePicker Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is NumericUpDown Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is Button Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is CheckBox Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is RadioButton Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is MenuStrip Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is ToolStrip Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is StatusStrip Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is ListBox Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is Form Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)
                    If TypeOf Ctl Is TabControl Then Ctl.Font = New Font(FontN, fontS, FontSt, FontD, FontB)


                    If TypeOf Ctl Is Button Then Ctl.autosize = True
                    If TypeOf Ctl Is Label Then Ctl.autosize = True
                    If TypeOf Ctl Is TableLayoutPanel Then Ctl.autosize = True
                    If TypeOf Ctl Is GroupBox Then Ctl.autosize = True
                    If TypeOf Ctl Is CheckBox Then Ctl.autosize = True
                    If TypeOf Ctl Is RadioButton Then Ctl.autosize = True
                    If TypeOf Ctl Is Form Then Ctl.autosize = True

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        COLOR_LOAD(ControlContainer)

    End Sub

    Private Sub COLOR_LOAD(ByVal ControlContainer As Object)

        For Each C As Object In ControlContainer.Controls
            Try
                If Not C.Controls Is Nothing Then
                    COLOR_LOAD(C)
                    If TypeOf C Is Form Then C.ForeColor = Drawing.Color.FromName(FontC)
                    'If TypeOf C Is TabControl Then C.TabPage.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is TableLayoutPanel Then C.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is GroupBox Then C.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is Label Then C.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is CheckBox Then C.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is RadioButton Then C.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is TextBox Then C.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is ComboBox Then C.ForeColor = Drawing.Color.FromName(FontC)
                    If TypeOf C Is ListView Then C.ForeColor = Drawing.Color.FromName(FontC)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

    End Sub

    Public Sub ClearCMB(ByVal ControlContainer As Object)

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then
                    ClearCMB(Ctl)

                    If TypeOf Ctl Is ComboBox Then Ctl.Items.Clear()

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub

    'Public Sub fLATCMB(ByVal ControlContainer As Object)

    '    For Each Ctl As Object In ControlContainer.Controls
    '        Try
    '            If Not Ctl.Controls Is Nothing Then
    '                fLATCMB(Ctl)

    '                If TypeOf Ctl Is ComboBox Then Ctl.FlatStyle = FlatStyle.Flat
    '                If TypeOf Ctl Is Button Then Ctl.FlatStyle = FlatStyle.Flat
    '            End If

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    Next
    'End Sub

    Public Sub LOAD_COMBO_SPR()
        Dim oRS As ADODB.Recordset

        oRS = DB7.OpenSchema(ADODB.SchemaEnum.adSchemaTables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

        If Not (oRS.EOF) Then
            Do Until oRS.EOF
                If UCase(oRS.Fields.Item("TABLE_TYPE").Value) = "TABLE" Then


                    If Left(oRS.Fields.Item("TABLE_NAME").Value, 3) = "SPR" Then

                        frmDirectory.cmb1.Items.Add(oRS.Fields.Item("TABLE_NAME").Value)

                    End If


                End If
                oRS.MoveNext()
            Loop
        End If

        oRS.Close()
        oRS = Nothing
    End Sub

End Module

