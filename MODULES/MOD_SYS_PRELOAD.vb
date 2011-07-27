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
    Public fontS As Double
    Public FontC As String
    Public FontB As Boolean
    Public FontSt As System.Drawing.FontStyle
    Public FontD As System.Drawing.GraphicsUnit

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

    Public Sub Tree_Icons_Feel()
        Try
            Dim dirs As String() = Directory.GetFiles(PrPath & "pic\tree\", "*.png")

            Dim dir As String

            For Each dir In dirs


                frmComputers.ImageList1.Images.Add(Image.FromFile(dir))
                frmComputers.ilsCommands.Images.Add(Image.FromFile(dir))

            Next
        Catch e1 As Exception

        End Try


        Try
            Dim dirs As String() = Directory.GetFiles(PrPath & "pic\", "*.png")

            Dim dir As String

            For Each dir In dirs

                frmComputers.ImageList1.Images.Add(Image.FromFile(dir))
                frmComputers.ilsCommands.Images.Add(Image.FromFile(dir))

            Next
        Catch e1 As Exception

        End Try
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

        Select Case sICONS

            Case "32*32"

                sICONS = sICONS
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
        'Dim sSQL As String
        'sSQL = "ALTER TABLE SPR_Uroven ALTER COLUMN Uroven Name TEXT(255)"
        'ALTER TABLE TableName ALTER COLUMN FieldName TEXT(255);

        'Dim rs As ADODB.Recordset
        'rs = New ADODB.Recordset

        'rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        'rs = Nothing

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

                    If TypeOf Ctl Is TextBox Then Ctl.text = ""
                    If TypeOf Ctl Is ComboBox Then Ctl.text = ""
                    If TypeOf Ctl Is ListView Then Ctl.items.clear()
                    'If TypeOf Ctl Is CheckBox Then Ctl.checked = False
                    If TypeOf Ctl Is RadioButton Then Ctl.checked = False

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
End Module

