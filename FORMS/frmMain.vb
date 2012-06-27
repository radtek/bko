Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Xml
Imports System.Xml.XPath
Imports System.Threading
Imports Ionic.Zip



Public Class frmMain
    Inherits System.Windows.Forms.Form
    Private Btn(500) As ToolStripButton

    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.Show()
        My.Application.DoEvents()

        If unamDB <> "MS Access" Then ArhToolZipbutton.Enabled = False


        Call SECUR_LEVEL()


    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        UnLoadDatabase()


        If DB_N <> "MS Access" Then Exit Sub

        Dim objIniFile As New IniFile(PrPath & "base.ini")

        Dim uname As String
        uname = objIniFile.GetString("general", "ARHIVATOR", 0)

        If uname = "1" Then

            Dim dirs As String
            Dim sFIleName As String
            dirs = BasePath
            sFIleName = PrPath & "arhiv\" & GENID() & "_" & Date.Today & "_" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision & ".zip"

            Try
                Using zip1 As ZipFile = New ZipFile
                    zip1.AddDirectory(dirs)
                    zip1.Save(sFIleName)
                End Using
            Catch exc1 As Exception
                MessageBox.Show(String.Format("Исключение при сжатии: {0}", exc1.Message))
            End Try


        End If

    End Sub

    Private Sub SendFonts_1()
        SendFonts(Me)
    End Sub

    Public Sub LANG_frmMain_1()

        Me.Invoke(New MethodInvoker(AddressOf LANG_frmMain))

    End Sub

    Public Sub SHED_CHECK_1()

        Me.Invoke(New MethodInvoker(AddressOf SHED_CHECK))

    End Sub

    Public Sub REM_CHECK_1()

        Me.Invoke(New MethodInvoker(AddressOf REM_CHECK))

    End Sub

    Private Sub load_ICONS()

        On Error Resume Next

        ToolStripDropDownButton1.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\new.png")
        NewToolStripButton.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\find.png")
        SaveInfTehButton.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\save.png")
        ArhToolZipbutton.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\zip.png")
        ToolStripButton1.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\report.png")


        NewToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\setup.png")
        ПроверитьОбновлениеToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\update.png")
        MailToAuthors.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\Mail.png")
        ФорумToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\forum.png")
        BugTrackerToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\bug.png")
        ExitToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\exit.png")

        СправочникиОборудованияToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\direct.png")
        ОрганизацияToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\org.png")
        БланкиToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\blank.png")
        ЖурналыПрограммыToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\log.png")
        АктытребованияToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\akt.png")
        ИнвентаризацияToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\invent.png")
        OptionsToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\notes.png")
        ОбслуживаниеБДToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\database.png")
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''Меняем шрифт
        Call SendFonts(Me)

        Call load_ICONS()

        Dim newThread3 As New Thread(AddressOf LANG_frmMain_1)
        newThread3.Start()


        Call Tree_Icons_Feel(frmComputers.ilsCommands, "sCMP", "pic\tree\")
        ' Call Tree_Icons_Feel(frmComputers.ImageList11, "sCMP", "pic\tree\")


        Dim sText As String

        'Определяем путь до файла настроек
        Dim objIniFile As New IniFile(PrPath & "base.ini")


        'На полный экран или нет
        sText = objIniFile.GetString("General", "FullScreen", "0")

        Select Case sText

            Case "1"

                Me.WindowState = 2

            Case "0"

                Me.WindowState = 0

        End Select



        'Показывать меню системные или нет
        sText = objIniFile.GetString("general", "SYS", 0)

        Select Case sText

            Case 0

                Me.CleerDBToolStripMenuItem.Visible = False
                Me.ЗапросыToolStripMenuItem.Visible = False

            Case 1

                Me.CleerDBToolStripMenuItem.Visible = True
                Me.ЗапросыToolStripMenuItem.Visible = True

        End Select



        'Наименование программы 
        Dim rsG As ADODB.Recordset
        rsG = New ADODB.Recordset

        rsG.Open("SELECT * FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rsG
            If Not IsDBNull(.Fields("Name_Prog").Value) Then ProGramName = .Fields("Name_Prog").Value
        End With
        rsG.Close()
        rsG = Nothing

        If Len(ProGramName) = 0 Or ProGramName = Nothing Then ProGramName = "BKO.NET"

        Me.Text = ProGramName & " " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision


        'Напоминания есть или нет
        Dim newThread4 As New Thread(AddressOf SHED_CHECK_1)
        newThread4.Start()

        'Ремонты есть или нет
        Dim newThread5 As New Thread(AddressOf REM_CHECK_1)
        newThread5.Start()


        '###########################################################

        'Добавляем в меню добавления техники другое оборудование

        Dim sCountOTH As Integer
        rsG = New ADODB.Recordset
        rsG.Open("SELECT count(*) as T_N FROM spr_other", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rsG
            sCountOTH = .Fields("T_N").Value
        End With
        rsG.Close()
        rsG = Nothing



        If sCountOTH > 0 Then
            Dim rs As ADODB.Recordset 'Объявляем рекордсет
            Dim sSQL As String 'Переменная, где будет размещён SQL запрос
            sSQL = "SELECT * FROM spr_other"

            Dim sNameZ(sCountOTH) As String

            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            Dim iz As Integer = 0

            With rs
                .MoveFirst()
                Do While Not .EOF
                    sNameZ(iz) = .Fields("name").Value
                    iz = iz + 1
                    .MoveNext()
                Loop
            End With
            rs.Close()
            rs = Nothing


            For i As Integer = 0 To sCountOTH
                Dim B As New ToolStripButton

                B.ForeColor = Color.Blue
                B.Text = sNameZ(i)
                Btn(i) = B

                AddHandler Btn(i).Click, AddressOf colorButtonsClick
                ДругоеОборудованиеToolStripMenuItem.DropDown.Items.AddRange(New ToolStripItem() {Btn(i)})
            Next

        End If



        'Какой модуль запускать
        sText = objIniFile.GetString("general", "MOD", 0)

        If Len(sText) > 2 Then sText = 0

        Select Case sText

            Case 0

                'frmComputers.Visible = False
                frmComputers.MdiParent = Me
                ' My.Application.DoEvents()
                frmComputers.Show()
                ' My.Application.DoEvents()

            Case 1
                frmserviceDesc.MdiParent = Me
                ' My.Application.DoEvents()
                frmserviceDesc.Show()
                ' My.Application.DoEvents()
            Case 2

                frmSoftware.MdiParent = Me
                '  My.Application.DoEvents()
                frmSoftware.Show()
                '  My.Application.DoEvents()
            Case 3

                frmCRT3.MdiParent = Me
                '  My.Application.DoEvents()
                frmCRT3.Show()
                '   My.Application.DoEvents()
        End Select


        'Запускаем таймер

        Dim t As New System.Windows.Forms.Timer
        t.Interval = 1000
        t.Enabled = True
        AddHandler t.Tick, AddressOf TimerEventHandler


        LBL_SUBD.Text = unamDB & " - " & Base_Name
        LBL_USER.Text = UserNames
    End Sub

    Public Sub colorButtonsClick(ByVal sender As [Object], ByVal e As EventArgs)
        Dim senderButton As ToolStripButton = CType(sender, ToolStripButton)
        'Me.ForeColor = senderButton.ForeColor

        Call Clear_Form_For_Computer()

        frmComputers.cmbOTH.Items.Clear()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_OTH_DEV", "", False, True)
        FillComboNET(frmComputers.cmbOTHConnect, "name", "spr_other", "", False, True)
        frmComputers.lblTipOther.Visible = True
        frmComputers.cmbOTHConnect.Visible = True

        frmComputers.cmbOTHConnect.Text = senderButton.Text

        frmComputers.lblOTMac.Visible = True
        frmComputers.lblOtIp.Visible = True
        frmComputers.txtOTHIP.Visible = True
        frmComputers.txtOTHMAC.Visible = True

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "OT"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub

    Private Sub frmMain_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize

        On Error GoTo error_Renamed


        'If frmMain.Height < 8500 + 300 Then frmMain.Height = 8500 + 300
        'If frmMain.Width < 12620 Then frmMain.Width = 12620

        If (Me.Height) < 750 Then Me.Height = 750
        If (Me.Width) < 1024 Then Me.Width = 1024



        Exit Sub
error_Renamed:
        Me.Height = 750
        Me.Width = 1024
    End Sub

    Private Sub ExitToolsStripMenuItem_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub FrmComputersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrmComputersMenuItem.Click
        frmComputers.MdiParent = Me
        frmComputers.Show()
        frmComputers.Focus()


    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub СправочникиОборудованияToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СправочникиОборудованияToolStripMenuItem.Click
        frmDirectory.MdiParent = Me
        frmDirectory.Show()
        frmDirectory.Focus()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Call UnLoadDatabase()
        End

    End Sub

    Private Sub УчётЗаявокремонтовToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles УчётЗаявокремонтовToolStripMenuItem.Click

        frmserviceDesc.MdiParent = Me
        frmserviceDesc.Show()
        frmserviceDesc.Focus()
    End Sub

    Private Sub HelpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpMenu.Click
        frmAbout.ShowDialog(Me)
    End Sub

    Private Sub УчётПрограммногоОбеспеченияToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles УчётПрограммногоОбеспеченияToolStripMenuItem.Click
        frmSoftware.MdiParent = Me
        frmSoftware.Show()
        frmSoftware.Focus()
    End Sub

    Private Sub HelpToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmARHIV.ShowDialog(Me)
    End Sub

    Private Sub CleerDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CleerDBToolStripMenuItem.Click

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset



        'On Error GoTo error
        On Error Resume Next


        rs.Open("DELETE FROM T_Log", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM Garantia_sis", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM garant_comp", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_Master", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing


        rs = New ADODB.Recordset
        rs.Open("DELETE FROM remonty_plus", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM Remont", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SOFT_INSTALL", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM Zametki", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM Update_Log", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM USER_COMP", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM tbl_bios", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing


        rs = New ADODB.Recordset
        rs.Open("DELETE FROM CARTRIDG_Z", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM CARTRIDG_D", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM CARTRIDG", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("DELETE FROM AKT_SP_OS3", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM ActOS", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM TrebOvanie", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM dvig", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SES_Pass", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM ZAM_OTD", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM OTD_O", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_OTV", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing


        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_KAB", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_OTD_FILIAL", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_MESTO", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_FILIAL", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing


        rs = New ADODB.Recordset
        rs.Open("DELETE FROM Sclad", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        rs = New ADODB.Recordset
        rs.Open("DELETE FROM Sheduler", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("DELETE FROM net_port", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("DELETE FROM kompy", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing


        Call frmComputers.STAT_INF()
        Call SHED_CHECK()
        Call REM_CHECK()
        Call COMPARE_DB()
        Call LoadSPR()

        RefFilTree(frmComputers.lstGroups)


        Dim LNGIniFile As New IniFile(sLANGPATH)


        MsgBox(LNGIniFile.GetString("frmMain", "MSG4", ""), MsgBoxStyle.Information)
        'Exit Sub





        Exit Sub
Error_:
        Debug.Print(Err.Description)

    End Sub

    Private Sub CompareDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompareDBToolStripMenuItem.Click
        Call COMPARE_DB()
    End Sub

    Private Sub COMPARE_DB()
        On Error GoTo err_
        Dim LNGIniFile As New IniFile(sLANGPATH)

        If DB_N = "MS Access" Then
            UnLoadDatabase()
            Dim sBname As String
            sBname = "temp_" & Base_Name

            Dim JRO As JRO.JetEngine
            JRO = New JRO.JetEngine
            JRO.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & BasePath & Base_Name, "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & BasePath & sBname & ";Jet OLEDB:Engine Type=5")
            Kill(BasePath & Base_Name)
            Rename(BasePath & sBname, BasePath & Base_Name)
            LoadDatabase()
            MsgBox(LNGIniFile.GetString("frmMain", "MSG5", ""), MsgBoxStyle.Information, ProGramName)

        End If

        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
        LoadDatabase()

    End Sub

    Private Sub УчётКартриджейToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles УчётКартриджейToolStripMenuItem.Click

        Dim Counter As Decimal
        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy where tiptehn = 'Printer'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            Counter = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy where tiptehn = 'KOpir'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            Counter = Counter + .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy where tiptehn = 'MFU'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            Counter = Counter + .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing


        rs = New ADODB.Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy where tiptehn = 'FAX'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            Counter = Counter + .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing

        If Counter = 0 Then
            MsgBox("Печатающих устройств не обнаружено!", MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If



        frmCRT3.MdiParent = Me
        frmCRT3.Show()
        frmCRT3.Focus()
    End Sub

    Private Sub СкладToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СкладToolStripMenuItem.Click

        frmSclad.MdiParent = Me
        frmSclad.Show()
        frmSclad.Focus()
    End Sub

    Private Sub ЖурналыПрограммыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ЖурналыПрограммыToolStripMenuItem.Click
        frmLOG.MdiParent = Me
        frmLOG.Show()
        frmLOG.Focus()
    End Sub

    Private Sub ФорумToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ФорумToolStripMenuItem.Click

        System.Diagnostics.Process.Start("http://bko.shatki.info/forum/")


    End Sub

    Private Sub BugTrackerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BugTrackerToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://bko.shatki.info:3000/projects/bko")
    End Sub

    Private Sub MailToAuthors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MailToAuthors.Click

        Dim Subject As String
        Dim Body As String

        Dim bAns As Boolean = True
        Dim sParams As String

        Subject = "БКО " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        sParams = "ldragon24@gmail.com"
        Body = "Здравствуйте Алексей, " & vbCrLf
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams & _
              "?subject=" & Subject

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & Body
        End If


        Try

            System.Diagnostics.Process.Start(sParams)

        Catch
            bAns = False
        End Try

        'Return bAns

    End Sub

    Private Sub ПаспортКомпьютераToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаспортКомпьютераToolStripMenuItem.Click


        If TipTehn <> "PC" Then Exit Sub

        Select Case frmComputers.sPREF

            Case "C"

                Select Case sOfficePACK

                    Case "OpenOffice.org"

                        Call OOO_SEND_PK(frmComputers.sCOUNT)

                    Case Else

                        Call WRD_SEND_PK(frmComputers.sCOUNT)
                End Select




            Case Else

                Exit Sub

        End Select


    End Sub

    Private Sub АктытребованияToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles АктытребованияToolStripMenuItem.Click

        Select Case frmComputers.sPREF

            Case "C"


                frmAct_Treb.MdiParent = Me
                frmAct_Treb.Show()
                frmAct_Treb.Focus()

            Case Else

                Exit Sub

        End Select



    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        frmSheduler.MdiParent = Me
        frmSheduler.Show()
        frmSheduler.Focus()
    End Sub

    Private Sub lblShed_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShed.DoubleClick
        frmSheduler.MdiParent = Me
        frmSheduler.Show()
        frmSheduler.Focus()
    End Sub

    Private Sub lblRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRem.Click
        frmserviceDesc.MdiParent = Me
        frmserviceDesc.Show()
        frmserviceDesc.Focus()
    End Sub

    Private Sub ЗапросыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ЗапросыToolStripMenuItem.Click
        frmSQL.MdiParent = Me
        frmSQL.Show()
        frmSQL.Focus()
    End Sub

    Private Sub ОрганизацияToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОрганизацияToolStripMenuItem.Click

        frmSetup.SStab1.SelectedTab = frmSetup.SStab1.TabPages("TabPage3")
        frmSetup.MdiParent = Me
        frmSetup.Show()
        frmSetup.Focus()
    End Sub

    Private Sub ПроверитьОбновлениеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПроверитьОбновлениеToolStripMenuItem.Click

        Dim reader As XmlNodeReader = Nothing

        Dim iA, iB, iC As String


        Try
            Dim s As String = ""
            ' The xml document to read from.
            Dim doc As New XmlDocument()

            ' Load the xml document.
            doc.Load("http://bko.shatki.info/bko.xml")

            ' Set the reader to open the xml document.
            reader = New XmlNodeReader(doc)

            ' Read all the data in the XML document and display it.
            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        ' Keep track of the element that the user is on.
                        s = reader.Name
                    Case XmlNodeType.Text
                        If s.Equals("version") Then
                            ' With the first name add a line to the listview control.
                            iA = (reader.Value)
                            ' For all other data itmes in the list just add
                            ' as sub itmes since they are in the correct order.
                        Else

                            iB = (reader.Value)

                        End If
                End Select
            End While
        Finally
            ' Do the necessary clean up.
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try

        iC = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision

        If iA > iC Then

            Dim LNGIniFile As New IniFile(sLANGPATH)
            If MsgBox(LNGIniFile.GetString("frmMain", "MSG7", "") & " " & iA & vbCrLf & iB & vbCrLf & LNGIniFile.GetString("frmMain", "MSG8", ""), ProGramName, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start("http://suse.shatki.info/opensuse/alex_plotnikov/BKO/UPDATE/")

            Else

            End If


            '"На сервере появилась новая версия программы - " & " " & xmlNode.childNodes(0).Text & ". Открыть страницу загрузки?" & vbNewLine & "Изменения:" & vbNewLine & xmlNode.childNodes(2).Text
        End If


    End Sub

    Private Sub МойБланкToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles МойБланкToolStripMenuItem.Click
        
        Dim sTMP As String
        Dim ePatch As String


        ePatch = Directory.GetParent(Application.ExecutablePath).ToString & "\blanks"

        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        fdlg.Title = LNGIniFile.GetString("frmMain", "MSG9", "")
        fdlg.InitialDirectory = ePatch
        fdlg.Filter = "Шаблоны документов MS Word(*.dot)|*.dot|Документы MS Word(*.doc)|*.doc"

        'fdlg.Filter = "All files (*.*)|*.*|Access Database(*.mdb) files (*.mdb)|*.mdb" ;
        '"Шаблоны Microsoft Word (*.doc)|*.doc"
        fdlg.FilterIndex = 2

        fdlg.RestoreDirectory = True

        If fdlg.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            sTMP = fdlg.FileName

            
        End If

         Select sOfficePACK

            Case "OpenOffice.org"

                If Len(sTMP) > 3 Then Call blanks_my_o(fdlg.FileName)


            Case Else

                If Len(sTMP) > 3 Then Call blanks_my_wrd(fdlg.FileName)

        End Select


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ПаспортМФУToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаспортМФУToolStripMenuItem.Click

        If TipTehn <> "MFU" Then Exit Sub

        Call PASSWORD_MFU(frmComputers.sCOUNT, "MFU")

    End Sub

    Private Sub ПаспортПринтераToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаспортПринтераToolStripMenuItem.Click

        If TipTehn <> "Printer" Then Exit Sub

        Call PASSWORD_MFU(frmComputers.sCOUNT, "Printer")
    End Sub

    Private Sub ПаспортКопираToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаспортКопираToolStripMenuItem.Click

        If TipTehn <> "KOpir" Then Exit Sub

        Call PASSWORD_MFU(frmComputers.sCOUNT, "KOpir")
    End Sub

    Private Sub ПаспортСетевогоОборудованияToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаспортСетевогоОборудованияToolStripMenuItem.Click

        If TipTehn <> "NET" Then Exit Sub

        Call PASSWORD_NET(frmComputers.sCOUNT)
    End Sub

    Private Sub ПаспортСканераToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаспортСканераToolStripMenuItem.Click

        If TipTehn <> "SCANER" Then Exit Sub

        Call PASSWORD_OTH(frmComputers.sCOUNT, "SCANER")
    End Sub

    Private Sub LabelPanelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelPanelToolStripMenuItem.Click

        Select Case Me.LabelPanelToolStripMenuItem.Checked

            Case True

                ToolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                NewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                SaveInfTehButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                ArhToolZipbutton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText


            Case False

                ToolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
                NewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image
                SaveInfTehButton.DisplayStyle = ToolStripItemDisplayStyle.Image
                ArhToolZipbutton.DisplayStyle = ToolStripItemDisplayStyle.Image
                ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image


        End Select



    End Sub

    Private Sub QRCodeTestingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QRCodeTestingToolStripMenuItem.Click
        'QrCode.MdiParent = Me
        'QrCode.Show()
    End Sub

    '#################################################################################################
    Private Sub ФотоаппаратToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ФотоаппаратToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        FillComboNET(frmComputers.cmbOTH, "name", "spr_photo", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False
        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False


        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "PHOTO"
        Call Clear_Form_For_Computer()

        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = False
        frmComputers.cmbOTHPCL.Visible = False

    End Sub

    Private Sub ФаксToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ФаксToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        FillComboNET(frmComputers.cmbOTH, "name", "spr_fax", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False
        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False


        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "FAX"
        Call Clear_Form_For_Computer()

        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = False
        frmComputers.cmbOTHPCL.Visible = False

    End Sub

    Private Sub ТелефонToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ТелефонToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "spr_phone", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = True
        frmComputers.lblOtIp.Visible = True
        frmComputers.txtOTHIP.Visible = True
        frmComputers.txtOTHMAC.Visible = True


        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "PHONE"
        frmComputers.EDT = False


        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True
        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)
    End Sub

    Private Sub ДисководZIPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ДисководZIPToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "spr_zip", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "ZIP"
        frmComputers.EDT = False
        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice
        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)
    End Sub

    Private Sub СканерToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СканерToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_SCANER", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "SCANER"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)
    End Sub

    Private Sub ДругоеОборудованиеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ДругоеОборудованиеToolStripMenuItem.Click



        Call Clear_Form_For_Computer()

        frmComputers.cmbOTH.Items.Clear()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_OTH_DEV", "", False, True)
        FillComboNET(frmComputers.cmbOTHConnect, "name", "spr_other", "", False, True)
        frmComputers.lblTipOther.Visible = True
        frmComputers.cmbOTHConnect.Visible = True

        frmComputers.lblOTMac.Visible = True
        frmComputers.lblOtIp.Visible = True
        frmComputers.txtOTHIP.Visible = True
        frmComputers.txtOTHMAC.Visible = True

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "OT"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub

    Private Sub МониторToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles МониторToolStripMenuItem.Click
        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_MONITOR", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False

        TipTehn = "MONITOR"

        frmComputers.EDT = False
        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.txtMonDum.Visible = True
        frmComputers.txtOTHSN.Left = "355"
        frmComputers.txtOTHSN.Width = "108"

        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False
        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub

    Private Sub ЗагрузитьИзCSVEverestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ЗагрузитьИзCSVEverestToolStripMenuItem.Click

        Call VisibleForm(frmComputers)
        Dim ePatch As String
        Dim objIniFile As New IniFile(PrPath & "base.ini")
        ePatch = objIniFile.GetString("General", "aida", "c:\")

        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        fdlg.Title = LNGIniFile.GetString("frmMain", "MSG3", "")

        fdlg.InitialDirectory = ePatch
        fdlg.Filter = "csv files (*.csv)|*.csv"
        fdlg.FilterIndex = 2

        fdlg.RestoreDirectory = True

        If fdlg.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            EverestFilePatch = fdlg.FileName


        End If
        frmComputers.selectTECMesto()
        Call Clear_Form_For_Computer()
        frmComputers.EDT = False
        TipTehn = "PC"

        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB1.Visible = True
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False

        'If Len(EverestFilePatch) > 3 Then Call ReadFromFile(EverestFilePatch)


        frmComputers.cmbBranch.Text = sBranch
        frmComputers.cmbDepartment.Text = sDepartment
        frmComputers.cmbOffice.Text = sOffice

        Me.Cursor = Cursors.Default

        'ReadFromFile
    End Sub

    Private Sub ЗагрузитьЧерезWMIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ЗагрузитьЧерезWMIToolStripMenuItem.Click

        Call VisibleForm(frmComputers)
        Me.Cursor = Cursors.WaitCursor

        frmComputers.selectTECMesto()
        Call Clear_Form_For_Computer()
        frmComputers.EDT = False
        TipTehn = "PC"

        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB1.Visible = True
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False

        Call LOAD_WMI()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ЗагрузитьИзASTRA32ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ЗагрузитьИзASTRA32ToolStripMenuItem.Click
        Call VisibleForm(frmComputers)
        Dim ePatch As String
        Dim objIniFile As New IniFile(PrPath & "base.ini")
        ePatch = objIniFile.GetString("General", "aida", "c:\")

        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        Dim LNGIniFile As New IniFile(sLANGPATH)
        fdlg.Title = LNGIniFile.GetString("frmMain", "MSG6", "")
        fdlg.InitialDirectory = ePatch
        fdlg.Filter = "ini files (*.ini)|*.ini"
        fdlg.FilterIndex = 2

        fdlg.RestoreDirectory = True

        If fdlg.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            EverestFilePatch = fdlg.FileName


        End If
        frmComputers.selectTECMesto()
        Call Clear_Form_For_Computer()
        frmComputers.EDT = False
        TipTehn = "PC"

        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB1.Visible = True
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False

        If Len(EverestFilePatch) > 3 Then Call ASTRA_Load()


        frmComputers.cmbBranch.Text = sBranch
        frmComputers.cmbDepartment.Text = sDepartment
        frmComputers.cmbOffice.Text = sOffice

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub СетевоеОборудованиеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СетевоеОборудованиеToolStripMenuItem.Click

        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = True
        frmComputers.sSTAB5.Visible = False
        TipTehn = "NET"
        Call Clear_Form_For_Computer()

        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbNETBranch.Text = sBranch
        frmComputers.cmbNetDepart.Text = sDepartment
        frmComputers.cmbNETOffice.Text = sOffice


    End Sub

    Private Sub КопирToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles КопирToolStripMenuItem.Click
        Call Clear_Form_For_Computer()

        frmComputers.EDT = False
        FillComboNET(frmComputers.cmbPRN, "name", "SPR_KOPIR", "", False, True)

        frmComputers.sSTAB2.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False

        frmComputers.selectTECMesto()
        frmComputers.cmbPRNFil.Text = sBranch
        frmComputers.cmbPRNDepart.Text = sDepartment
        frmComputers.cmbPRNOffice.Text = sOffice

        'Call LOAD_PCL(frmComputers.cmbPRNFil.Text, frmComputers.cmbPRNDepart.Text, frmComputers.cmbPRNOffice.Text, frmComputers.cmbPCL)
        TipTehn = "KOpir"

    End Sub

    Private Sub ПринтерToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПринтерToolStripMenuItem.Click
        Call Clear_Form_For_Computer()

        frmComputers.EDT = False
        FillComboNET(frmComputers.cmbPRN, "name", "SPR_PRINTER", "", False, True)

        frmComputers.sSTAB2.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False

        frmComputers.selectTECMesto()
        frmComputers.cmbPRNFil.Text = sBranch
        frmComputers.cmbPRNDepart.Text = sDepartment
        frmComputers.cmbPRNOffice.Text = sOffice

        TipTehn = "Printer"
        Call LOAD_PCL(frmComputers.cmbPRNFil.Text, frmComputers.cmbPRNDepart.Text, frmComputers.cmbPRNOffice.Text, frmComputers.cmbPCL)

    End Sub

    Private Sub МФУToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles МФУToolStripMenuItem.Click
        Call Clear_Form_For_Computer()


        frmComputers.EDT = False
        FillComboNET(frmComputers.cmbPRN, "name", "SPR_MFU", "", False, True)

        frmComputers.sSTAB2.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False

        frmComputers.selectTECMesto()
        frmComputers.cmbPRNFil.Text = sBranch
        frmComputers.cmbPRNDepart.Text = sDepartment
        frmComputers.cmbPRNOffice.Text = sOffice

        TipTehn = "MFU"

        Call LOAD_PCL(frmComputers.cmbPRNFil.Text, frmComputers.cmbPRNDepart.Text, frmComputers.cmbPRNOffice.Text, frmComputers.cmbPCL)

    End Sub

    Private Sub ЗагрузитьИзEverestiniToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ЗагрузитьИзEverestiniToolStripMenuItem.Click
        Call VisibleForm(frmComputers)

        Dim ePatch As String
        Dim objIniFile As New IniFile(PrPath & "base.ini")
        ePatch = objIniFile.GetString("General", "aida", "c:\")

        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        Dim LNGIniFile As New IniFile(sLANGPATH)
        fdlg.Title = LNGIniFile.GetString("frmMain", "MSG3", "")
        fdlg.InitialDirectory = ePatch
        fdlg.Filter = "ini files (*.ini)|*.ini"
        fdlg.FilterIndex = 2

        fdlg.RestoreDirectory = True

        If fdlg.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            EverestFilePatch = fdlg.FileName


        End If
        frmComputers.selectTECMesto()
        Call Clear_Form_For_Computer()
        frmComputers.EDT = False
        TipTehn = "PC"

        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB1.Visible = True
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False

        If Len(EverestFilePatch) > 3 Then Call Everest_Load()


        frmComputers.cmbBranch.Text = sBranch
        frmComputers.cmbDepartment.Text = sDepartment
        frmComputers.cmbOffice.Text = sOffice

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SaveInfTehButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInfTehButton.Click

        Call SaveInfTeh()

    End Sub

    Public Sub SaveInfTeh()
        Me.Cursor = Cursors.WaitCursor
        On Error Resume Next


        Dim LNGIniFile As New IniFile(sLANGPATH)


        If frmComputers.EDT = True Then
            Call SaveActivityToLogDB(LNGIniFile.GetString("frmMain", "MSG1", "") & " " & frmComputers.lstGroups.SelectedNode.Text)

        Else
            Call SaveActivityToLogDB(LNGIniFile.GetString("frmMain", "MSG2", ""))
        End If


        If Len(TipTehn) <> 0 Then

            GoTo ADD

        Else

            Select Case frmComputers.sPREF

                Case "G"

                    Call SAVE_INF_BRANCHE()

                Case "O"

                    Call SAVE_INF_BRANCHE()

                Case "K"

                    Call SAVE_INF_BRANCHE()



                Case "C"



            End Select

        End If

        Me.Cursor = Cursors.Default

        Exit Sub

ADD:
        Dim langfile As New IniFile(sLANGPATH)
        Select Case TipTehn

            Case "PC"

                If frmComputers.EDT = True Then

                    Call Save_T(frmComputers.sCOUNT)

                Else

                    'Call Save_T()
                    Me.Invoke(New MethodInvoker(AddressOf Save_T))

                End If

            Case "Printer"
                'Save_P
                If frmComputers.EDT = True Then

                    Call Save_P(frmComputers.sCOUNT)

                Else

                    Call Save_P()

                End If
            Case "MFU"
                If frmComputers.EDT = True Then

                    Call Save_P(frmComputers.sCOUNT)

                Else

                    Call Save_P()

                End If

            Case "KOpir"
                If frmComputers.EDT = True Then

                    Call Save_P(frmComputers.sCOUNT)

                Else

                    Call Save_P()

                End If

            Case "OT"

                If frmComputers.EDT = True Then

                    Call Save_OT(frmComputers.sCOUNT)

                Else

                    Call Save_OT()

                End If

            Case "CNT"

                If frmComputers.EDT = True Then

                    Call Save_OT(frmComputers.sCOUNT)

                Else

                    Call Save_OT()

                End If


            Case "PHOTO"

                If frmComputers.EDT = True Then

                    Call Save_OT(frmComputers.sCOUNT)

                Else

                    Call Save_OT()

                End If

            Case "FAX"

                If frmComputers.EDT = True Then

                    Call Save_OT(frmComputers.sCOUNT)

                Else

                    Call Save_OT()

                End If

            Case "PHONE"

                If frmComputers.EDT = True Then

                    Call Save_OT(frmComputers.sCOUNT)

                Else

                    Call Save_OT()

                End If

            Case "ZIP"

                If frmComputers.EDT = True Then

                    Call Save_OT(frmComputers.sCOUNT)

                Else

                    Call Save_OT()

                End If

            Case "SCANER"
                If frmComputers.EDT = True Then

                    Call Save_OT(frmComputers.sCOUNT)

                Else

                    Call Save_OT()

                End If

            Case "NET"

                'Save_NET

                If frmComputers.EDT = True Then

                    Call Save_NET(frmComputers.sCOUNT)

                Else

                    Call Save_NET()

                End If


            Case "MONITOR"

                'Save_NET

                If frmComputers.EDT = True Then

                    Call SAVE_MON(frmComputers.sCOUNT)

                Else

                    Call SAVE_MON()

                End If

                '--------------VIP_Graff Добавление новой перефирии Начало-----------------
            Case "USB"
                If frmComputers.EDT = True Then
                    Call Save_OT(frmComputers.sCOUNT)
                Else
                    Call Save_OT()
                End If

            Case "SOUND"
                If frmComputers.EDT = True Then
                    Call Save_OT(frmComputers.sCOUNT)
                Else
                    Call Save_OT()
                End If

            Case "IBP"
                If frmComputers.EDT = True Then
                    Call Save_OT(frmComputers.sCOUNT)
                Else
                    Call Save_OT()
                End If

            Case "FS"
                If frmComputers.EDT = True Then
                    Call Save_OT(frmComputers.sCOUNT)
                Else
                    Call Save_OT()
                End If

            Case "KEYB"
                If frmComputers.EDT = True Then
                    Call Save_OT(frmComputers.sCOUNT)
                Else
                    Call Save_OT()
                End If

            Case "MOUSE"
                If frmComputers.EDT = True Then
                    Call Save_OT(frmComputers.sCOUNT)
                Else
                    Call Save_OT()
                End If
                '--------------VIP_Graff Добавление новой перефирии Конец------------------


            Case Else

        End Select

        On Error Resume Next

        If frmComputers.EDT = True Then

            Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG51", "") & " " & frmComputers.lstGroups.SelectedNode.Text)

        Else

            Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG50", "") & " /" & sBranch & "/" & sDepartment & "/" & sOffice)

        End If




        'Call COLOR_Form_For_Computer()
        Call frmComputers.STAT_INF()





        Me.Cursor = Cursors.Default

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        frmSetup.MdiParent = Me
        frmSetup.Show()
        frmSetup.Focus()
    End Sub



    Private Sub HANDINSERTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HANDINSERTToolStripMenuItem.Click

        Call VisibleForm(frmComputers)

        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB1.Visible = True
        frmComputers.sSTAB3.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        Call Clear_Form_For_Computer()

        Call frmComputers.selectTECMesto()

        frmComputers.cmbBranch.Text = sBranch
        frmComputers.cmbDepartment.Text = sDepartment
        frmComputers.cmbOffice.Text = sOffice


        frmComputers.EDT = False
        TipTehn = "PC"


    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        'frmSearch
        frmSearch.MdiParent = Me
        frmSearch.Show()
        frmSearch.Focus()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmReports.MdiParent = Me
        frmReports.Show()
        frmReports.Focus()
    End Sub

    Private Sub ArhToolZipbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArhToolZipbutton.Click
        frmARHIV.ShowDialog(Me)
    End Sub

    Private Sub СетевыеФильтрыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СетевыеФильтрыToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()
        FillComboNET(frmComputers.cmbOTH, "name", "SPR_FS", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "FS"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)
    End Sub

    Private Sub БесперебойникиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles БесперебойникиToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()


        FillComboNET(frmComputers.cmbOTH, "name", "SPR_IBP", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = True
        frmComputers.lblOtIp.Visible = True
        frmComputers.txtOTHIP.Visible = True
        frmComputers.txtOTHMAC.Visible = True

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "IBP"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)
    End Sub

    Private Sub АккустическиеСистемыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles АккустическиеСистемыToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_ASISTEM", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "SOUND"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub

    Private Sub USBУстройстваToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USBУстройстваToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_USB", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "USB"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub

    Private Sub КлавиатураToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles КлавиатураToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_KEYBOARD", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "KEYB"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub

    Private Sub МышьToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles МышьToolStripMenuItem.Click
        frmComputers.txtMonDum.Visible = False
        frmComputers.txtOTHSN.Left = "249"
        frmComputers.txtOTHSN.Width = "214"

        Call Clear_Form_For_Computer()

        FillComboNET(frmComputers.cmbOTH, "name", "SPR_MOUSE", "", False, True)
        frmComputers.lblTipOther.Visible = False
        frmComputers.cmbOTHConnect.Visible = False

        frmComputers.lblOTMac.Visible = False
        frmComputers.lblOtIp.Visible = False
        frmComputers.txtOTHIP.Visible = False
        frmComputers.txtOTHMAC.Visible = False

        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "MOUSE"
        frmComputers.EDT = False

        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = True
        frmComputers.cmbOTHPCL.Visible = True

        Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub


    Private Sub ИнвентаризацияToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ИнвентаризацияToolStripMenuItem.Click
        Call INVENT()

    End Sub

    
    Private Sub СтатистическиеОтчетыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СтатистическиеОтчетыToolStripMenuItem.Click


    End Sub

    Private Sub РемонтыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РемонтыToolStripMenuItem.Click
        frmReports.MdiParent = Me
        frmReports.Show()
        frmReports.sSTAB1.SelectedTab = frmReports.sSTAB1.TabPages("TabPage3")
        frmReports.Focus()


    End Sub


    Private Sub CNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNTToolStripMenuItem.Click
        Call Clear_Form_For_Computer()

        frmComputers.cmbOTH.Items.Clear()

        'FillComboNET(frmComputers.cmbOTH, "name", "SPR_OTH_DEV", "", False, True)
        'FillComboNET(frmComputers.cmbOTHConnect, "name", "spr_other", "", False, True)

        'On Error Resume Next
        On Error GoTo err_
        frmComputers.cmbOTH.Items.Clear()


        Dim rs As ADODB.Recordset

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM spr_other WHERE name <> '' and C='1'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
        Dim COUnT As String
        With rs

            COUnT = .Fields("t_n").Value

        End With
        rs.Close()
        rs = Nothing


        If COUnT > 0 Then

            rs = New ADODB.Recordset
            rs.Open("SELECT name FROM spr_other WHERE name <> '' and C='1' ORDER BY name", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

            With rs
                .MoveFirst()
                Do While Not .EOF

                    frmComputers.cmbOTH.Items.Add(.Fields("name").Value)

                    .MoveNext()
                Loop
            End With

            rs.Close()
            rs = Nothing

        End If


        frmComputers.lblTipOther.Visible = True
        frmComputers.cmbOTHConnect.Visible = True
        frmComputers.lblOTMac.Visible = True
        frmComputers.lblOtIp.Visible = True
        frmComputers.txtOTHIP.Visible = True
        frmComputers.txtOTHMAC.Visible = True
        frmComputers.sSTAB3.Visible = True
        frmComputers.sSTAB1.Visible = False
        frmComputers.sSTAB2.Visible = False
        frmComputers.sSTAB4.Visible = False
        frmComputers.sSTAB5.Visible = False
        TipTehn = "CNT"
        frmComputers.EDT = False
        frmComputers.selectTECMesto()
        frmComputers.cmbOTHFil.Text = sBranch
        frmComputers.cmbOTHDepart.Text = sDepartment
        frmComputers.cmbOTHOffice.Text = sOffice

        frmComputers.lblOTPCL.Visible = False
        frmComputers.cmbOTHPCL.Visible = False



        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)

       

        'Call LOAD_PCL(frmComputers.cmbOTHFil.Text, frmComputers.cmbOTHDepart.Text, frmComputers.cmbOTHOffice.Text, frmComputers.cmbOTHPCL)

    End Sub

    Private Sub КабельныеЖурналыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles netMagmnu.Click
        frmNetMagazin.MdiParent = Me
        frmNetMagazin.Show()
        frmNetMagazin.Focus()
    End Sub

    Private Sub TimerEventHandler(ByVal obj As Object, ByVal ergs As EventArgs)
        On Error Resume Next



        If TimeOfDay.Minute = 0 And TimeOfDay.Second = 0 Then


            Dim LNGIniFile As New IniFile(sLANGPATH)

            Dim rs As ADODB.Recordset

            Dim sSQL, SERT, SERT2, uname, SERT3 As String

            sSQL = "SELECT COUNT(*) AS total_number FROM Remont"

            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs
                SERT = .Fields("total_number").Value
            End With

            rs.Close()
            rs = Nothing


            If SERT > 0 Then


                rs = New ADODB.Recordset
                rs.Open("SELECT * FROM SPR_Master WHERE A='" & UserNames & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs
                    uname = .Fields("name").Value
                End With

                rs.Close()
                rs = Nothing

                If uname = Nothing Then uname = "ADMINISTRATOR"

                sSQL = "SELECT COUNT(*) AS total_number FROM Remont WHERE otvetstv='" & uname & "'"

                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs
                    SERT2 = .Fields("total_number").Value
                End With
                rs.Close()
                rs = Nothing

                If SERT2 > 0 Then

                    sSQL = "SELECT COUNT(*) AS total_number FROM Remont Where otvetstv='" & uname & "' and zakryt = 0"

                    rs = New ADODB.Recordset
                    rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs
                        SERT3 = .Fields("total_number").Value
                    End With
                    rs.Close()
                    rs = Nothing

                    If SERT3 > 0 Then

                        MsgBox(LNGIniFile.GetString("frmMain", "MSG10", "") & " " & SERT3 & " " & LNGIniFile.GetString("frmMain", "MSG11", ""), MsgBoxStyle.Information, ProGramName)

                    End If

                End If


            End If

        End If


    End Sub

    Private Sub ПерегрузкаСрправочниковToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПерегрузкаСрправочниковToolStripMenuItem.Click
        Dim newThread2 As New Thread(AddressOf LoadSPR_1)
        newThread2.Start()
    End Sub

    Private Sub LoadSPR_1()

        Me.BeginInvoke(New MethodInvoker(AddressOf LoadSPR))

    End Sub

    Private Sub ПроверитьФилиалыОтделыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПроверитьФилиалыОтделыToolStripMenuItem.Click

        Dim newThread1 As New Thread(AddressOf add_kabn_if_nothing)
        newThread1.Start()
        'newThread1.Priority = 4


    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If SaveInfTehButton.Enabled = False Then Exit Sub

        Call SaveInfTeh()
    End Sub
End Class
