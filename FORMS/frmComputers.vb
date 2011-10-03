Imports System.Threading
Imports System
Imports System.IO
Imports System.ComponentModel


Public Class frmComputers
    Private m_SortingColumn As ColumnHeader

    Private BTN As Decimal
    Public sPREF As String
    Public sCOUNT As Decimal
    Public zCOUNT As Decimal
    Public uCOUNT As Decimal
    Private dvCOUNT As Decimal
    Private npCOUNT As Decimal
    Public EDT As Boolean
    Public portEDT As Boolean
    Public MASSLOAD As Boolean
    Public pDRAG As Boolean
    Private lvServices As ListView
    Public sCPU As Integer = 1
    Public sRAM As Integer = 1
    Public sHDD As Integer = 1
    Public sVGA As Integer = 1
    Public sOPTICAL As Integer = 1
    Public sNET As Integer = 1
    Public sMonitor As Integer = 1
    Public sPrinter As Integer = 1

    Public OneStart As Decimal = 0

    Public Sub New()
        InitializeComponent()
    End Sub 'New

    Private Sub frmComputers_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated


        If uLevelTehAdd = False And uLevel <> "Admin" Then

        Else
            frmMain.SaveInfTehButton.Enabled = True
            frmMain.ToolStripDropDownButton1.Enabled = True
        End If

        If uLevelTehAdd = False And uLevel <> "Admin" Then
            frmMain.ToolStripDropDownButton1.Enabled = False
            Me.CopyToolStripMenuItem.Enabled = False
            Me.addFoldertoBranch.Enabled = False
            Me.UpdateToolStripMenuItem.Enabled = False
        End If

    End Sub

    Private Sub frmComputers_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        frmMain.SaveInfTehButton.Enabled = False
        frmMain.ToolStripDropDownButton1.Enabled = False
    End Sub

    Private Sub chkVisibleSTR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisibleSTR.CheckedChanged

        Me.Cursor = Cursors.WaitCursor

        Dim objIniFile As New IniFile(PrPath & "base.ini")

        Select Case chkVisibleSTR.Checked

            Case False

                objIniFile.WriteString("General", "VisibleALL", "0")

            Case True

                objIniFile.WriteString("General", "VisibleALL", "1")

        End Select

        If OneStart = 0 Then Exit Sub

        Dim newThread5 As New Thread(AddressOf R_T_LOAD)
        newThread5.Start()



        Me.Cursor = Cursors.Default

    End Sub

    Private Sub treebranche_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles treebranche.SelectedIndexChanged

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("General", "branche", treebranche.Text)

        If OneStart = 0 Then Exit Sub

        Dim newThread5 As New Thread(AddressOf R_T_LOAD)
        newThread5.Start()


    End Sub

    Private Sub PRELOAD_FORM()

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        Dim uname As String

        uname = objIniFile.GetString("General", "branche", "")
        Dim LNGIniFile As New IniFile(sLANGPATH)


        'Загружаем иконки
        Me.BeginInvoke(New MethodInvoker(AddressOf Load_ICONS))

        ' Меняем шрифт на форме
        Me.BeginInvoke(New MethodInvoker(AddressOf Font_Form_For_Computer_1))

        'Подгружаем язык
        Me.BeginInvoke(New MethodInvoker(AddressOf frmComputers_Lang_1))

        'Справочники
        'Call LoadSPR()

        Dim newThread2 As New Thread(AddressOf LoadSPR_1)
        newThread2.Start()

        'Выбираем филиал если он выбран, если нет то "Все"
        If Len(uname) = 0 Then
            treebranche.Text = LNGIniFile.GetString("frmComputers", "MSG53", "")

        Else
            treebranche.Text = uname
        End If


        uname = objIniFile.GetString("General", "VisibleALL", "0")

        Select Case uname

            Case "1"

                chkVisibleSTR.Checked = True

            Case "0"

                chkVisibleSTR.Checked = False

        End Select


        uname = objIniFile.GetString("General", "RAZDEL", "0")

        Dim langfile As New IniFile(sLANGPATH)
        Select Case uname

            Case "0"

                ОтделитьПринтерыИМониторыToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG1", "")
                ВернутьПерефериюToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG1.1", "")

            Case "1"

                ОтделитьПринтерыИМониторыToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG2", "")
                ВернутьПерефериюToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG2.1", "")
            Case "2"

                ОтделитьПринтерыИМониторыToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG3", "")
                ВернутьПерефериюToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG3.1", "")
            Case "3"

                ОтделитьПринтерыИМониторыToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG4", "")
                ВернутьПерефериюToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG4.1", "")

            Case "4"

                ОтделитьПринтерыИМониторыToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG5", "")
                ВернутьПерефериюToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG5.1", "")
            Case "5"

                ОтделитьПринтерыИМониторыToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG6", "")
                ВернутьПерефериюToolStripMenuItem.Text = langfile.GetString("frmComputers", "MSG6.1", "")
        End Select

        MassRazdelPerf.Text = ОтделитьПринтерыИМониторыToolStripMenuItem.Text
        MassObedPerf.Text = ВернутьПерефериюToolStripMenuItem.Text


        cmbTIPCartridg.Items.Add(langfile.GetString("frmComputers", "MSG7", ""))
        cmbTIPCartridg.Items.Add(langfile.GetString("frmComputers", "MSG8", ""))
        cmbTIPCartridg.Items.Add(langfile.GetString("frmComputers", "MSG9", ""))
        cmbTIPCartridg.Items.Add(langfile.GetString("frmComputers", "MSG10", ""))
        cmbTIPCartridg.Items.Add(langfile.GetString("frmComputers", "MSG11", ""))
        cmbTIPCartridg.Items.Add(langfile.GetString("frmComputers", "MSG12", ""))


        'Dim objIniFile As New IniFile(PrPath & "base.ini")

        KCKey = objIniFile.GetString("general", "DK", 0)
        DCKey = objIniFile.GetString("general", "Default", 0)


        If Len(DCKey) <> 0 And DCKey <> "0" Then sSTAB5.Visible = True

        If KCKey <> 0 Then

            Dim rs As ADODB.Recordset
            rs = New ADODB.Recordset

            Dim VisibleSSTAB As String

            rs.Open("SELECT tiptehn from kompy where id=" & KCKey, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                VisibleSSTAB = .Fields("tiptehn").Value

            End With

            rs.Close()
            rs = Nothing

            Select Case VisibleSSTAB

                Case "PC"
                    sSTAB1.Visible = True

                Case "Printer"
                    sSTAB2.Visible = True

                Case "KOpir"
                    sSTAB2.Visible = True

                Case "MFU"
                    sSTAB2.Visible = True

                Case "NET"
                    sSTAB4.Visible = True
                Case Else
                    sSTAB3.Visible = True

            End Select


        End If





    End Sub

    Private Sub Load_ICONS()

        On Error Resume Next

        mnuDeltoBranch.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\delete.png")
        DeleteBranche.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\delete.png")

        addFoldertoBranch.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\fadd.png")
        RepAddBrToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\service.png")
        SoftInstallToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\soft.png")
        ПаспортКомпьютераToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\pasport.png")
        MassRazdelPerf.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\remove.png")
        MassObedPerf.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        MassUpdatetoINI.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\updatefolder.png")

        DELTEdVIGToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\delete.png")
        DeleteService.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\delete.png")

        EditService.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\editservice.png")
        MnuSendEmail.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\sendmail.png")
        mnu_Z_to_Office.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\serviceprint.png")
        mnu_z_rasp.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\servicerasp.png")

        addRemToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\service.png")
        'CartrAddToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\servicerasp.png")

        CopyToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\copy.png")
        UpdateToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\pcupdate.png")

        DeleteToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\delete.png")

        ОтделитьПринтерыИМониторыToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\remove.png")
        ВернутьПерефериюToolStripMenuItem.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")

        btnSearch.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\search.png")


        addServiseWork.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")



        'bCPUPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        'bRamPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        'bHddPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        'bSVGAPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        'bOpticalPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        'bNETPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        'bMonitorPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")
        'bPrinterPlus.Image = New System.Drawing.Bitmap(PrPath & "pic\iface\add.png")



        If ilsCommands.Images.Count = 0 Then

            Call Tree_Icons_Feel(ilsCommands, "sCMP", "pic\tree\")
            'Call Tree_Icons_Feel(ImageList11, "sCMP", "pic\tree\")

        End If


    End Sub

    Private Sub frmComputers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.BeginInvoke(New MethodInvoker(AddressOf PRELOAD_FORM))

        'Call PRELOAD_FORM()

        Application.DoEvents()



        'Меняем форму
        'Me.BeginInvoke(New MethodInvoker(AddressOf RESIZER))

        'Статистика
        Dim newThread4 As New Thread(AddressOf STAT_INF_1)
        newThread4.Start()
        'newThread4.Priority = 4


        Me.WindowState = FormWindowState.Maximized

        Me.Cursor = Cursors.WaitCursor


        Application.DoEvents()



        If lstGroups.Nodes.Count = 0 Then

            If Me.lstGroups.Nodes.Count = 0 Then
                Dim newThread5 As New Thread(AddressOf R_T_LOAD)
                newThread5.Start()
                'newThread5.Priority = 4
            End If

        End If

        Me.Cursor = Cursors.Default
        OneStart = 1

    End Sub

    Private Sub frmComputers_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize

        Call RESIZER()

    End Sub

    Private Sub spCont_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles spCont.Resize
        Call RESIZER()
    End Sub

    Private Sub RESIZER()
        'Cursor.Current = System.Windows.Forms.Cursors.Default

        'If spCont.SplitterDistance > 200 Then Exit Sub

        If spCont.SplitterDistance > 450 Then spCont.SplitterDistance = 450
        If spCont.SplitterDistance < 250 Then spCont.SplitterDistance = 250
        PROiZV39.Width = gbOTh.Width - 475




    End Sub

    Private Sub spCont_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles spCont.SplitterMoved
        Call RESIZER()
    End Sub

    Public Sub selectTECMesto()
        On Error GoTo Error_

        'If EDT = False Then Exit Sub

        If MASSLOAD = True Then Exit Sub

        'MASSLOAD = False

        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")

        Dim rs2 As ADODB.Recordset
        rs2 = New ADODB.Recordset


        sOffice = ""
        sBranch = ""
        sDepartment = ""

        Dim langfile As New IniFile(sLANGPATH)

        Select Case d(0)

            Case "C"

                rs2.Open("SELECT * FROM kompy where Id = " & d(1), DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)

                With rs2
                    sOffice = .Fields("kabn").Value
                    sBranch = .Fields("filial").Value
                    sDepartment = .Fields("mesto").Value

                End With
                rs2.Close()
                rs2 = Nothing


                '#########################################################################################################################

                If Len(sBranch) <> 0 Then lblT_O_T.Text = langfile.GetString("frmComputers", "MSG15", "")
                If Len(sDepartment) <> 0 Then lblT_O_T.Text = langfile.GetString("frmComputers", "MSG16", "")
                If Len(sOffice) <> 0 Then lblT_O_T.Text = langfile.GetString("frmComputers", "MSG17", "")



                Dim rs As ADODB.Recordset 'Объявляем рекордсет
                Dim sSQL As String 'Переменная, где будет размещён SQL запрос


                sSQL = "SELECT COUNT(*) as t_n FROM kompy WHERE filial ='" & sBranch & "' and mesto='" & sDepartment & "' and kabn='" & sOffice & "'"
                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


                With rs
                    lblT_O.Text = .Fields("t_n").Value & " " & langfile.GetString("frmComputers", "MSG13", "") '& langIni.GetString("messages", "l4", "")
                End With

                rs.Close()
                rs = Nothing



            Case "G"

                rs2.Open("SELECT * FROM SPR_FILIAL where Id = " & d(1), DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)

                With rs2
                    sBranch = .Fields("FILIAL").Value
                    sDepartment = ""
                    sOffice = ""
                End With
                rs2.Close()
                rs2 = Nothing


            Case "O"

                rs2.Open("SELECT * FROM SPR_OTD_FILIAL where Id = " & d(1), DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)

                With rs2
                    sBranch = .Fields("FILIAL").Value
                    sDepartment = .Fields("N_Otd").Value
                    sOffice = ""
                End With
                rs2.Close()
                rs2 = Nothing


            Case "OT"



                rs2.Open("SELECT * FROM SPR_MESTO where mestoId = " & d(1), DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)

                With rs2
                    sBranch = ""
                    sDepartment = .Fields("MESTO").Value
                    sOffice = ""
                End With
                rs2.Close()
                rs2 = Nothing

            Case "K"

                rs2.Open("SELECT * FROM SPR_KAB where Id = " & d(1), DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)

                With rs2
                    sOffice = .Fields("Name").Value
                    sBranch = .Fields("N_F").Value
                    sDepartment = .Fields("N_M").Value

                End With
                rs2.Close()
                rs2 = Nothing


                Exit Sub
Error_:
                'MsgBox Err.Description


        End Select
    End Sub

    Private Sub lstGroups_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles lstGroups.AfterSelect
        'ClearBackColor()
        Me.Cursor = Cursors.WaitCursor
        Me.txtSNAME.BackColor = Me.txtSBSN.BackColor
        Me.txtPSEUDONIM.BackColor = Me.txtSBSN.BackColor
        Me.cmbBranch.BackColor = Me.txtSBSN.BackColor

        pDRAG = False

        COLOR_Form_For_Computer(Me)

        'Call LOAD_LIST()
        Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_LIST))
        Me.BeginInvoke(New MethodInvoker(AddressOf selectTECMesto))

        Application.DoEvents()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LOAD_LIST()
        Dim langfile As New IniFile(sLANGPATH)

        Call selectTECMesto()

        Me.Cursor = Cursors.WaitCursor

        'If pDRAG = True Then

        'Else
        '    TipTehn = ""
        'End If


        frmMain.SaveInfTehButton.Enabled = True

        Me.ChkPDC.Checked = False

        Me.BeginInvoke(New MethodInvoker(AddressOf SECUR_LEVEL))

        'Call SECUR_LEVEL()

        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")


        Call Clear_Form_For_Computer()

        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG14", "") & " " & Me.lstGroups.SelectedNode.Text)



        Select Case d(0)

            Case "C"

                '###################
                'Нужно сохранить последний открытый объект
                '###################

                'Call SAVE_INF_CONF(d(1))

                Dim objIniFile As New IniFile(PrPath & "base.ini")
                objIniFile.WriteString("general", "DK", d(1))
                objIniFile.WriteString("general", "Default", 0)

            Case Else

                Dim objIniFile As New IniFile(PrPath & "base.ini")
                objIniFile.WriteString("general", "DK", 0)
                objIniFile.WriteString("general", "Default", lstGroups.SelectedNode.Tag)

        End Select


        Me.txtMonDum.Visible = False
        Me.txtOTHSN.Left = "249"
        Me.txtOTHSN.Width = "214"

        Me.cmbOTH.Items.Clear()

        Select Case d(0)

            Case "C"
                CopyToolStripMenuItem.Enabled = True
                UpdateToolStripMenuItem.Enabled = True
                Me.EDT = True

                sPREF = d(0)
                sCOUNT = d(1)

                Dim rs As ADODB.Recordset 'Объявляем рекордсет
                Dim sSQL As String 'Переменная, где будет размещён SQL запрос
                sSQL = "SELECT tiptehn FROM kompy WHERE id =" & d(1)
                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                ОтделитьПринтерыИМониторыToolStripMenuItem.Visible = False
                ВернутьПерефериюToolStripMenuItem.Visible = False
                With rs

                    TipTehn = .Fields("tiptehn").Value

                    Select Case .Fields("tiptehn").Value

                        Case "PC"
                            ОтделитьПринтерыИМониторыToolStripMenuItem.Visible = True

                            Dim rs1 As ADODB.Recordset
                            Dim sSQL1 As String 'Переменная, где будет размещён SQL запрос
                            sSQL1 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & d(1)
                            rs1 = New ADODB.Recordset
                            rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            Dim sCNTr As Integer

                            With rs1

                                sCNTr = .Fields("t_n").Value

                            End With
                            rs1.Close()
                            rs1 = Nothing

                            If sCNTr > 0 Then ВернутьПерефериюToolStripMenuItem.Visible = True


                            CartrAddToolStripMenuItem.Visible = False
                            sSTAB2.Visible = False
                            sSTAB1.Visible = True
                            sSTAB3.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False

                            'Call LOADt(d(1))


                            Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                            newThread1.Start()
                            'newThread1.Priority = 4

                            Dim newThread2 As New Thread(AddressOf S_P_LOAD_t)
                            newThread2.Start()


                            Dim newThread3 As New Thread(AddressOf U_P_LOAD_t)
                            newThread3.Start()


                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()



                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbPCLK)

                        Case "Printer"

                            CartrAddToolStripMenuItem.Visible = True
                            FillComboNET(Me.cmbPRN, "name", "SPR_PRINTER", "", False, True)
                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB2.Visible = True
                            sSTAB1.Visible = False
                            sSTAB3.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            Label83.Visible = True
                            cmbPCL.Visible = True


                            'Call LOADp(d(1))


                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()



                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbPCL)
                            'me.cmbPCL

                        Case "MFU"
                            CartrAddToolStripMenuItem.Visible = True
                            FillComboNET(Me.cmbPRN, "name", "SPR_MFU", "", False, True)
                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB2.Visible = True
                            sSTAB1.Visible = False
                            sSTAB3.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            Label83.Visible = True
                            cmbPCL.Visible = True



                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbPCL)

                        Case "KOpir"
                            CartrAddToolStripMenuItem.Visible = True
                            FillComboNET(Me.cmbPRN, "name", "SPR_KOPIR", "", False, True)
                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB2.Visible = True
                            sSTAB1.Visible = False
                            sSTAB3.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False

                            Label83.Visible = False
                            cmbPCL.Visible = False


                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            'Call LOAD_PCL()
                        Case "OT"


                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_OTH_DEV", "", False, True)
                            lblTipOther.Visible = True
                            cmbOTHConnect.Visible = True
                            lblOTMac.Visible = True
                            lblOtIp.Visible = True
                            txtOTHIP.Visible = True
                            txtOTHMAC.Visible = True

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True
                            FillComboNET(Me.cmbOTHConnect, "name", "spr_other", "", False, True)

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()


                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)




                        Case "PHOTO"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "spr_photo", "", False, True)

                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False

                            lblOTPCL.Visible = False
                            cmbOTHPCL.Visible = False

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                        Case "FAX"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "spr_fax", "", False, True)

                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False

                            lblOTPCL.Visible = False
                            cmbOTHPCL.Visible = False

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                        Case "PHONE"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "spr_phone", "", False, True)

                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = True
                            lblOtIp.Visible = True
                            txtOTHIP.Visible = True
                            txtOTHMAC.Visible = True
                            cmbOTHPCL.Visible = True

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False

                            lblOTPCL.Visible = True


                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                        Case "ZIP"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "spr_zip", "", False, True)

                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)

                        Case "SCANER"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_SCANER", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False


                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()


                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)
                        Case "MONITOR"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "Name", "SPR_MONITOR", "", False, True)

                            Me.txtMonDum.Visible = True
                            Me.txtOTHSN.Left = "355"
                            Me.txtOTHSN.Width = "108"

                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            ' CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False

                            ' Call LOADmon(d(1))


                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)


                        Case "NET"
                            CartrAddToolStripMenuItem.Visible = False
                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = False
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB5.Visible = False
                            sSTAB4.Visible = True

                            Call LOADnet(d(1))


                            '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                        Case "USB"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_USB", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)

                        Case "SOUND"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_ASISTEM", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)

                        Case "IBP"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_IBP", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)

                        Case "FS"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_FS", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)

                        Case "KEYB"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_KEYBOARD", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)

                        Case "MOUSE"
                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_MOUSE", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = True
                            cmbOTHPCL.Visible = True

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)
                            '--------------VIP_Graff Добавление новой перефирии Конец------------------

                        Case "CNT"


                            CartrAddToolStripMenuItem.Visible = False
                            FillComboNET(Me.cmbOTH, "name", "SPR_other", "", False, True)
                            lblTipOther.Visible = False
                            cmbOTHConnect.Visible = False
                            lblOTMac.Visible = False
                            lblOtIp.Visible = False
                            txtOTHIP.Visible = False
                            txtOTHMAC.Visible = False

                            'CopyToolStripMenuItem.Enabled = False
                            UpdateToolStripMenuItem.Enabled = False
                            sSTAB3.Visible = True
                            sSTAB1.Visible = False
                            sSTAB2.Visible = False
                            sSTAB4.Visible = False
                            sSTAB5.Visible = False
                            lblOTPCL.Visible = False
                            cmbOTHPCL.Visible = False

                            'Me.BeginInvoke(New MethodInvoker(AddressOf T_LOAD_T))

                            Dim newThread3 As New Thread(AddressOf T_LOAD_T)
                            newThread3.Start()
                            'newThread3.Priority = 4

                            Dim newThread4 As New Thread(AddressOf N_P_LOAD_t)
                            newThread4.Start()

                            Dim newThread5 As New Thread(AddressOf R_P_LOAD_t)
                            newThread5.Start()

                            Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                            newThread6.Start()

                            ' Call LOAD_PCL(sBranch, sDepartment, sOffice, Me.cmbOTHPCL)

                    End Select

                End With

                rs.Close()
                rs = Nothing


            Case "G"
                Me.EDT = False

                'frmMain.SaveInfTehButton.Enabled = False

                sSTAB3.Visible = False
                sSTAB1.Visible = False
                sSTAB2.Visible = False
                sSTAB4.Visible = False
                sSTAB5.Visible = True

                sPREF = d(0)
                sCOUNT = d(1)

                lblT_O_T.Text = langfile.GetString("frmComputers", "MSG15", "") 'langini.GetString("messages", "l1", "")
                'langini.GetString("language", "l1001", "")

                Dim rs As ADODB.Recordset 'Объявляем рекордсет
                Dim sSQL As String 'Переменная, где будет размещён SQL запрос
                sSQL = "SELECT COUNT(*) as t_n FROM kompy WHERE filial ='" & lstGroups.SelectedNode.Text & "' "
                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


                With rs
                    lblT_O.Text = .Fields("t_n").Value & " " & langfile.GetString("frmComputers", "MSG13", "") '& langIni.GetString("messages", "l4", "")
                End With

                rs.Close()
                rs = Nothing

                LOAD_INF_BRANCHE(d(1))
                Call LOAD_REPAIR(d(1), Me.lvRepairBR)

            Case "O"


                'frmMain.SaveInfTehButton.Enabled = False

                Me.EDT = False


                sPREF = d(0)
                sCOUNT = d(1)

                lblT_O_T.Text = langfile.GetString("frmComputers", "MSG16", "") 'langini.GetString("messages", "l2", "")

                Dim rs As ADODB.Recordset 'Объявляем рекордсет
                Dim sSQL As String 'Переменная, где будет размещён SQL запрос
                Dim sFIL As String

                sSQL = "SELECT filial FROM SPR_OTD_FILIAL WHERE id =" & d(1)
                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs
                    sFIL = .Fields("filial").Value
                End With

                rs.Close()
                rs = Nothing


                sSQL = "SELECT COUNT(*) as t_n FROM kompy WHERE filial ='" & sFIL & "' and mesto='" & lstGroups.SelectedNode.Text & "'"
                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


                With rs
                    lblT_O.Text = .Fields("t_n").Value & " " & langfile.GetString("frmComputers", "MSG13", "") '& langIni.GetString("messages", "l4", "")
                End With

                rs.Close()
                rs = Nothing

                sSTAB3.Visible = False
                sSTAB1.Visible = False
                sSTAB2.Visible = False
                sSTAB4.Visible = False
                sSTAB5.Visible = True
                LOAD_INF_BRANCHE(d(1))
                Call LOAD_REPAIR(d(1), Me.lvRepairBR)

            Case "K"
                'TipTehn = ""

                'frmMain.SaveInfTehButton.Enabled = False

                Me.EDT = False

                sPREF = d(0)
                sCOUNT = d(1)

                lblT_O_T.Text = langfile.GetString("frmComputers", "MSG17", "") 'langini.GetString("messages", "l3", "")


                '###################################################################################
                Dim rs As ADODB.Recordset 'Объявляем рекордсет
                Dim sSQL As String 'Переменная, где будет размещён SQL запрос
                Dim sFIL As String
                Dim sOT As String

                sSQL = "SELECT N_F, N_M FROM SPR_KAB WHERE id =" & d(1)
                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs
                    sFIL = .Fields("N_F").Value
                    sOT = .Fields("N_M").Value

                End With

                rs.Close()
                rs = Nothing


                sSQL = "SELECT COUNT(*) as t_n FROM kompy WHERE filial ='" & sFIL & "' and mesto='" & sOT & "' and kabn='" & lstGroups.SelectedNode.Text & "'"
                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


                With rs
                    lblT_O.Text = .Fields("t_n").Value & " " & langfile.GetString("frmComputers", "MSG13", "") '& langIni.GetString("messages", "l4", "")
                End With

                rs.Close()
                rs = Nothing

                sSTAB3.Visible = False
                sSTAB1.Visible = False
                sSTAB2.Visible = False
                sSTAB4.Visible = False
                sSTAB5.Visible = True
                LOAD_INF_BRANCHE(d(1))
                Call LOAD_REPAIR(d(1), Me.lvRepairBR)


        End Select


        Me.Cursor = Cursors.Default


        If OneStart = 0 Then OneStart = 1

    End Sub

    '######################

    Private Sub S_P_LOAD_t()

        Me.BeginInvoke(New MethodInvoker(AddressOf S_P_LOAD_t_1))

    End Sub

    Private Sub S_P_LOAD_t_1()
        Call LOAD_SOFT(sCOUNT, Me.lstSoftware)
    End Sub

    Private Sub U_P_LOAD_t()

        Me.BeginInvoke(New MethodInvoker(AddressOf U_P_LOAD_t_1))
    End Sub

    Private Sub U_P_LOAD_t_1()
        Call LOAD_USER(sCOUNT)
    End Sub

    Private Sub T_LOAD_T()


        Me.BeginInvoke(New MethodInvoker(AddressOf T_LOAD_T_1))


    End Sub

    Private Sub T_LOAD_T_1()

        Select Case TipTehn

            Case "PC"
                Call LOADt(sCOUNT)

            Case "Printer"

                Call LOADp(sCOUNT)
            Case "KOpir"
                Call LOADp(sCOUNT)

            Case "MFU"
                Call LOADp(sCOUNT)


            Case "MONITOR"

                LOADmon(sCOUNT)

            Case "NET"

            Case Else

                Call LOADot(sCOUNT)

        End Select

    End Sub

    Private Sub N_P_LOAD_t()

        Me.BeginInvoke(New MethodInvoker(AddressOf N_P_LOAD_t_1))

    End Sub

    Private Sub N_P_LOAD_t_1()
        Select Case TipTehn

            Case "PC"

                Call LOAD_NOTES(sCOUNT, Me.lvNotes)

            Case "Printer"

                Call LOAD_NOTES(sCOUNT, Me.lvNotesPRN)
            Case "KOpir"
                Call LOAD_NOTES(sCOUNT, Me.lvNotesPRN)
            Case "MFU"
                Call LOAD_NOTES(sCOUNT, Me.lvNotesPRN)
            Case "NET"

                Call LOAD_NOTES(sCOUNT, Me.lvNotesNET)
            Case Else
                Call LOAD_NOTES(sCOUNT, Me.lvNotesOTH)


        End Select
    End Sub

    Private Sub R_P_LOAD_t()

        Me.BeginInvoke(New MethodInvoker(AddressOf R_P_LOAD_t_1))

    End Sub

    Private Sub R_P_LOAD_t_1()
        Select Case TipTehn

            Case "PC"

                Call LOAD_REPAIR(sCOUNT, Me.lvRepair)

            Case "Printer"

                Call LOAD_REPAIR(sCOUNT, Me.lvRepairPRN)
            Case "KOpir"
                Call LOAD_REPAIR(sCOUNT, Me.lvRepairPRN)
            Case "MFU"
                Call LOAD_REPAIR(sCOUNT, Me.lvRepairPRN)
            Case "NET"

                Call LOAD_REPAIR(sCOUNT, Me.lvRepairNET)
            Case Else
                Call LOAD_REPAIR(sCOUNT, Me.lvRepairOTH)


        End Select
    End Sub

    Private Sub D_P_LOAD_t()

        Me.BeginInvoke(New MethodInvoker(AddressOf D_PLOAD_T_1))

    End Sub

    Private Sub D_PLOAD_T_1()

        Select Case TipTehn

            Case "PC"

                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovement)

            Case "Printer"
                'lvMovementPRN
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementPRN)
            Case "KOpir"
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementPRN)
            Case "MFU"
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementPRN)
            Case "NET"
                'lvMovementNET
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementNET)
            Case Else
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementOTH)
                'lvMovementOTH

        End Select
    End Sub

    Public Sub Font_Form_For_Computer_1()

        Me.lstGroups.Invoke(New MethodInvoker(AddressOf Font_Form_For_Computer))

    End Sub

    Public Sub frmComputers_Lang_1()

        Me.lstGroups.Invoke(New MethodInvoker(AddressOf frmComputers_Lang))

    End Sub

    Public Sub R_T_LOAD_1()
        Call RefFilTree(Me.lstGroups)
    End Sub

    Public Sub STAT_INF_1()

        Me.lstGroups.Invoke(New MethodInvoker(AddressOf STAT_INF))

    End Sub

    Private Sub S_Tl_LOAD()

        Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_LIST))

    End Sub

    Public Sub R_T_LOAD()

        Me.BeginInvoke(New MethodInvoker(AddressOf R_T_LOAD_1), Nothing)

    End Sub

    Public Sub STAT_INF()
        On Error GoTo err_
        Dim langfile As New IniFile(sLANGPATH)

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос
        sSQL = "select COUNT(*) as T_N from kompy"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            lblT_All.Text = (.Fields("T_N").Value) & " " & langfile.GetString("frmComputers", "MSG13", "")
        End With
        rs.Close()
        rs = Nothing

        Exit Sub
err_:
    End Sub

    Private Sub LoadSPR_1()

        Me.BeginInvoke(New MethodInvoker(AddressOf LoadSPR))

    End Sub
    '######################

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        OneStart = 0

        txtSearch.Text = ""

        Me.Cursor = Cursors.WaitCursor


        'Dim newThread2 As New Thread(AddressOf LoadSPR_1)
        'newThread2.Start()

        Dim newThread1 As New Thread(AddressOf R_T_LOAD)
        newThread1.Start()
        'newThread1.Priority = 4

        'Call LoadSPR()
        'Call RefFilTree(lstGroups)


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                'Search2(txtSearch.Text)
                lstGroups.Nodes.Clear()
                Dim newThread1 As New Thread(AddressOf S2_LOAD_)
                newThread1.Start()
                'newThread1.Priority = 3

        End Select


    End Sub

    Private Sub S2_LOAD_()

        Me.BeginInvoke(New MethodInvoker(AddressOf S2_LOAD_t))

    End Sub

    Private Sub S2_LOAD_t()
        'Call Search2(txtSearch.Text)

        Call Search(txtSearch.Text, lstGroups, gbTree, "COMP")

    End Sub

    Private Sub BrainchLoad(ByVal fCombo As ComboBox, ByVal dCombo As ComboBox)

        On Error GoTo err_

        dCombo.Items.Clear()

        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset

        rs1.Open("select * from SPR_OTD_FILIAL WHERE Filial='" & fCombo.Text & "' ORDER BY N_Otd", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        cmbDepartment.Items.Clear()

        With rs1
            .MoveFirst()
            Do While Not .EOF

                If Not IsDBNull(.Fields("N_Otd").Value) Then dCombo.Items.Add(.Fields("N_Otd").Value)

                .MoveNext()
            Loop
        End With

        rs1.Close()
        rs1 = Nothing

        Exit Sub
err_:
        ' MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)

    End Sub

    Private Sub DepartmentLoad(ByVal fCombo As ComboBox, ByVal dCombo As ComboBox, ByVal oCombo As ComboBox)

        On Error GoTo err_

        oCombo.Items.Clear()

        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset

        rs1.Open("select * from SPR_KAB WHERE N_F='" & fCombo.Text & "' AND N_M='" & dCombo.Text & "' ORDER BY Name", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        cmbOffice.Items.Clear()

        With rs1
            .MoveFirst()
            Do While Not .EOF
                If Not IsDBNull(.Fields("Name").Value) Then oCombo.Items.Add(.Fields("Name").Value)
                .MoveNext()
            Loop
        End With

        rs1.Close()
        rs1 = Nothing

        Exit Sub
err_:

    End Sub

    Private Sub lstSoftware_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSoftware.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
         lstSoftware.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lstSoftware.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lstSoftware.Sort()
    End Sub

    Private Sub lstSoftware_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSoftware.DoubleClick
        Dim rCOUNT As Integer

        If lstSoftware.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstSoftware.SelectedItems.Count - 1
            rCOUNT = (lstSoftware.SelectedItems(z).Text)
        Next

        frmSoftware.lstSoftware.Select()

        frmSoftware.MdiParent = frmMain
        frmSoftware.Show()

        Call frmSoftware.Soft_Click(rCOUNT)

    End Sub

    Private Sub zCOUNT_LOAD(ByVal lvNote As ListView)
        If lvNote.Items.Count = 0 Then Exit Sub
        Dim z As Integer
        For z = 0 To lvNote.SelectedItems.Count - 1
            zCOUNT = (lvNote.SelectedItems(z).Text)
        Next
    End Sub

    Private Sub NotesLoaded(ByVal lvNotes As ListView, ByVal dtdatenotes As DateTimePicker, ByVal cmbNotesMaster As ComboBox, ByVal txtNotes As TextBox, ByVal btnNotes As Button)

        If lvNotes.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvNotes.SelectedItems.Count - 1
            zCOUNT = (lvNotes.SelectedItems(z).Text)
        Next

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        rs.Open("SELECT * FROM Zametki WHERE id=" & zCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("Date").Value) Then dtdatenotes.Value = .Fields("Date").Value
            If Not IsDBNull(.Fields("Master").Value) Then cmbNotesMaster.Text = .Fields("Master").Value
            If Not IsDBNull(.Fields("Zametki").Value) Then txtNotes.Text = .Fields("Zametki").Value

        End With

        Dim langfile As New IniFile(sLANGPATH)


        btnNotes.Text = langfile.GetString("frmComputers", "MSG19", "")

        rs.Close()
        rs = Nothing
    End Sub

    Private Sub RemoVe_Notes(ByVal lvNote As ListView)

        If lvNote.Items.Count = 0 Then Exit Sub
        If zCOUNT = 0 Then Exit Sub

        Dim langfile As New IniFile(sLANGPATH)


        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG20", "") & " " & Me.lstGroups.SelectedNode.Text)

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        rs.Open("DELETE FROM Zametki WHERE id=" & zCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        rs = Nothing

        Call LOAD_NOTES(sCOUNT, lvNote)


    End Sub

    Private Sub addRemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addRemToolStripMenuItem.Click
        Dim langfile As New IniFile(sLANGPATH)

        frmService_add.Text = langfile.GetString("frmComputers", "MSG21", "") & " " & lstGroups.SelectedNode.Text

        'serviceDesc.MdiParent = frmMain
        'serviceDesc.Show()
        frmService_add.REMFU = True
        frmService_add.REMED = False
        frmService_add.cmbIst.Text = ""
        frmService_add.cmbMast.Text = ""
        frmService_add.txtPhone.Text = ""
        frmService_add.dtReg.Value = Date.Today
        frmService_add.dtIsp.Value = Date.Today
        frmService_add.txtHead.Text = ""
        frmService_add.txtRem.Text = ""
        frmService_add.cmbStatus.Text = ""
        frmService_add.cmbOtv.Text = ""
        frmService_add.cmbKrit.Text = ""
        frmService_add.cmbTip.Text = ""
        frmService_add.txtComent.Text = ""
        frmService_add.RemCashe.Text = 0
        frmService_add.chkClose.Checked = False


        frmService_add.ShowDialog(frmserviceDesc)

        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG22", "") & " " & lstGroups.SelectedNode.Text)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim langfile As New IniFile(sLANGPATH)


        If MsgBox(langfile.GetString("frmComputers", "MSG23", "") & " " & lstGroups.SelectedNode.Text, MsgBoxStyle.YesNo, ProGramName) = MsgBoxResult.Yes Then


            Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG24", "") & " " & lstGroups.SelectedNode.Text)

            Dim d() As String
            d = Split(lstGroups.SelectedNode.Tag, "|")

            REMOVE_TEHN(d(1))
            Me.lstGroups.Nodes.Remove(Me.lstGroups.SelectedNode)

            Dim newThread1 As New Thread(AddressOf STAT_INF_1)
            newThread1.Start()

        Else

        End If

    End Sub

    Private Sub LoadRepairEdit(ByVal lvList As ListView)

        If lvList.Items.Count = 0 Then Exit Sub

        If uLevelRepEd = False And uLevel <> "Admin" Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvList.SelectedItems.Count - 1
            rCOUNT = (lvList.SelectedItems(z).Text)
        Next

        If rCOUNT = 0 Then Exit Sub

        frmService_add.REMED = True

        'frmserviceDesc.MdiParent = frmMain
        'frmserviceDesc.Show()
        'Call frmserviceDesc.Load_Z_Form(rCOUNT)

        '#################################################################

        frmserviceDesc.rCOUNT = rCOUNT
        Dim sSQL As String
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset

        sSQL = "SELECT * FROM Remont WHERE id=" & rCOUNT

        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmService_add.Text = LNGIniFile.GetString("frmserviceDesc", "MSG1", "") & " " & lstGroups.SelectedNode.Text

        rs1.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sSw As Date
        Dim sSw2 As String

        With rs1
            .MoveFirst()
            Do While Not .EOF

                If Not IsDBNull(.Fields("istochnik").Value) Then frmService_add.cmbIst.Text = .Fields("istochnik").Value 'Источник
                If Not IsDBNull(.Fields("Master").Value) Then frmService_add.cmbMast.Text = .Fields("Master").Value 'Мастер


                If Not IsDBNull(.Fields("Date").Value) Then sSw = .Fields("Date").Value
                If Not IsDBNull(.Fields("srok").Value) Then sSw2 = .Fields("srok").Value

                If Len(sSw) = 0 Then
                    sSw = Date.Today
                End If

                If Len(sSw2) = 0 Then
                    sSw2 = Date.Today
                End If

                frmService_add.dtReg.Value = sSw 'Дата регистрации
                frmService_add.dtIsp.Value = sSw2 'Срок исполнения


                If Not IsDBNull(.Fields("phone").Value) Then frmService_add.txtPhone.Text = .Fields("phone").Value 'Телефон
                If Not IsDBNull(.Fields("name_of_remont").Value) Then frmService_add.txtHead.Text = .Fields("name_of_remont").Value 'Название
                If Not IsDBNull(.Fields("Remont").Value) Then frmService_add.txtRem.Text = .Fields("Remont").Value 'Сообщение
                If Not IsDBNull(.Fields("vip").Value) Then frmService_add.cmbStatus.Text = .Fields("vip").Value 'Статус
                If Not IsDBNull(.Fields("otvetstv").Value) Then frmService_add.cmbOtv.Text = .Fields("otvetstv").Value 'Ответственный

                If Not IsDBNull(.Fields("krit_rem").Value) Then frmService_add.cmbTip.Text = .Fields("krit_rem").Value 'Критичность
                If Not IsDBNull(.Fields("Uroven").Value) Then frmService_add.cmbKrit.Text = .Fields("Uroven").Value 'Тип


                If Not IsDBNull(.Fields("MeMo").Value) Then frmService_add.txtComent.Text = .Fields("MeMo").Value 'Комментарий

                If Not IsDBNull(.Fields("Summ").Value) Then frmService_add.RemCashe.Text = .Fields("Summ").Value 'Комментарий

                '.Fields("Summ").Value = RemCashe.Text 'Сумма

                If .Fields("zakryt").Value = -1 Then
                    frmService_add.chkClose.Checked = 1
                Else

                    frmService_add.chkClose.Checked = 0
                End If

                .MoveNext()
            Loop
        End With

        frmService_add.REMED = True

        frmService_add.cmbAdd.Text = LNGIniFile.GetString("frmserviceDesc", "MSG2", "")

        rs1.Close()
        rs1 = Nothing

        frmService_add.ShowDialog(Me)



    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click

        EDT = False
        sCOUNT = 0

        Select Case TipTehn


            Case "PC"

                Me.txtSNAME.Text = ""
                Me.txtPSEUDONIM.Text = ""
                Me.txtModSB.Text = ""
                Me.txtSNSB.Text = ""
                Me.txtSBSN.Text = ""
                Me.txtMSN.Text = ""
                Me.IN_IBP.Text = ""
                Me.IN_PRN.Text = ""

            Case "Printer"
                txtPRNSN.Text = ""
                txtPRNinnumber.Text = ""

            Case "NET"
                txtNetIP.Text = ""
                txtNetMac.Text = ""
                txtNetINN.Text = ""
                txtNetSN.Text = ""

            Case "KOpir"
                txtPRNSN.Text = ""
                txtPRNinnumber.Text = ""

            Case "PHONE"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "PHOTO"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "FAX"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "MFU"
                txtPRNSN.Text = ""
                txtPRNinnumber.Text = ""

            Case "MONITOR"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "ZIP"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "OT"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""
                '--------------VIP_Graff Добавление новой перефирии Конец------------------
            Case "USB"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "SOUND"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "IBP"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "FS"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "KEYB"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""

            Case "MOUSE"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""
                '--------------VIP_Graff Добавление новой перефирии Конец------------------

            Case "CNT"
                Me.txtOTHSN.Text = ""
                txtOTHinnumber.Text = ""
        End Select

        Dim langfile As New IniFile(sLANGPATH)

        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG25", "") & " " & lstGroups.SelectedNode.Text)

    End Sub

    Private Sub mnuDeltoBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeltoBranch.Click
        Dim langfile As New IniFile(sLANGPATH)

        Me.Cursor = Cursors.WaitCursor
        'On Error GoTo err_

        Dim d() As String
        'Dim uname As String
        'Dim N_NAME As String
        'Dim P_NAME As String
        'Dim L_NAME As String

        'Dim objIniFile As New IniFile(PrPath & "base.ini")
        'uname = objIniFile.GetString("general", "NETNAME", "1")

        d = Split(lstGroups.SelectedNode.Tag, "|")

        Dim sSQL As String

        Call selectTECMesto()


        Select Case d(0)

            Case "C"

            Case "G"

                sSQL = "SELECT id,net_name,psevdonim FROM kompy where filial ='" & sBranch & "' and mesto=''"

                Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG26", "") & " " & sBranch)

            Case "O"

                sSQL = "SELECT id,net_name,psevdonim FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' and kabn=''"

                Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG26", "") & " " & sBranch & "/" & sDepartment)

            Case "K"

                sSQL = "SELECT id,net_name,psevdonim FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' AND kabn ='" & sOffice & "'"

                Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG26", "") & " " & sBranch & "/" & sDepartment & "/" & sOffice)

        End Select

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF


                'Select Case uname

                '    Case 0
                '        N_NAME = .Fields("net_name").Value
                '        P_NAME = .Fields("psevdonim").Value

                '        If Len(N_NAME) = 0 Then
                '            N_NAME = "NoName"
                '        End If

                '        If Len(P_NAME) = 0 Then
                '            P_NAME = "NoName"
                '        End If
                '        L_NAME = N_NAME & " (" & P_NAME & ")"

                '    Case 2
                '        P_NAME = .Fields("psevdonim").Value

                '        If Len(P_NAME) = 0 Then
                '            P_NAME = "NoName"
                '        End If
                '        L_NAME = P_NAME

                '    Case 1

                '        N_NAME = .Fields("net_name").Value
                '        If Len(N_NAME) = 0 Then
                '            N_NAME = "NoName"
                '        End If

                '        L_NAME = N_NAME
                'End Select

                REMOVE_TEHN(.Fields("id").Value)

                'Dim TEHNodeCNT As New TreeNode(L_NAME)
                'Me.lstGroups.Nodes.Remove(TEHNodeCNT)


                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


        Dim newThread1 As New Thread(AddressOf R_T_LOAD)
        newThread1.Start()


        'RefFilTree(Me.lstGroups)

        Dim newThread2 As New Thread(AddressOf STAT_INF_1)
        newThread2.Start()

        Me.Cursor = Cursors.Default
        Exit Sub
err_:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub addFoldertoBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addFoldertoBranch.Click
        'On Error GoTo Err_


        Call selectTECMesto()

        EDT = False
        MASSLOAD = True
        TipTehn = "PC"

        Dim DirectoryBrowser As New FolderBrowserDialog
        Dim sTXTDIR As String


        Dim objIniFile As New IniFile(PrPath & "base.ini")
        sTXTDIR = objIniFile.GetString("General", "aida", "d:\")

        With DirectoryBrowser
            ' Desktop is the root folder in the dialog.

            .RootFolder = Environment.SpecialFolder.Desktop


            If Len(sTXTDIR) = 0 Then
                ' Select the C:\Windows directory on entry.
                .SelectedPath = "c:\windows"
            Else
                .SelectedPath = sTXTDIR
            End If

            ' Prompt the user with a custom message.
            .Description = "Select the source directory"

            If .ShowDialog = DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                ' Display the selected folder if the user clicked on the OK button.
                sTXTDIR = .SelectedPath

                sTXTDIR = sTXTDIR & "\"

                Try
                    ' Only get files that begin with the letter "c."
                    Dim dirs As String() = Directory.GetFiles(sTXTDIR, "*.ini")
                    ' Console.WriteLine("The number of files starting with c is {0}.", dirs.Length)
                    Dim dir As String

                    For Each dir In dirs
                        Dim d() As String
                        d = Split(dir, "\")

                        'cmbBD.Items.Add(d(d.Length - 1))

                        EverestFilePatch = sTXTDIR & d(d.Length - 1)

                        Call Clear_Form_For_Computer()

                        Me.BeginInvoke(New MethodInvoker(AddressOf Everest_Load))


                        cmbBranch.Text = sBranch
                        cmbDepartment.Text = sDepartment
                        cmbOffice.Text = sOffice

                        Call Save_T()
                    Next
                Catch e1 As Exception
                    MsgBox(Err.Description)
                    'Console.WriteLine("The process failed: {0}", e1.ToString())
                End Try

                MASSLOAD = False

                Dim newThread1 As New Thread(AddressOf STAT_INF_1)
                newThread1.Start()

                Dim langfile As New IniFile(sLANGPATH)


                Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG27", ""))

                RefFilTree(Me.lstGroups)
                'Dim newThread As New Thread(AddressOf R_T_LOAD)
                'newThread.Start()

                'Dim newThread1 As New Thread(AddressOf STAT_INF)
                'newThread1.Start()

            End If

        End With

        Me.Cursor = Cursors.Default
        Exit Sub
err_:
        MsgBox(Err.Description)

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If TipTehn <> "PC" Then Exit Sub

        Dim ePatch As String
        Dim objIniFile As New IniFile(PrPath & "base.ini")
        ePatch = objIniFile.GetString("General", "aida", "c:\")

        Dim fdlg As OpenFileDialog = New OpenFileDialog()

        fdlg.Title = "Everest Cirporate Edition ini file"
        fdlg.InitialDirectory = ePatch
        fdlg.Filter = "ini files (*.ini)|*.ini"
        fdlg.FilterIndex = 2

        fdlg.RestoreDirectory = True

        If fdlg.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            EverestFilePatch = fdlg.FileName


        End If

        If Len(EverestFilePatch) > 3 Then Call EVEREST_UPDATE()
        Dim langfile As New IniFile(sLANGPATH)


        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG28", "") & " " & lstGroups.SelectedNode.Text)
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub ДобавитьЗаявкуToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepAddBrToolStripMenuItem.Click

        Dim langfile As New IniFile(sLANGPATH)

        frmService_add.Text = langfile.GetString("frmComputers", "MSG21", "") & " " & lstGroups.SelectedNode.Text
        'serviceDesc.MdiParent = frmMain
        'serviceDesc.Show()
        frmService_add.REMFU = True
        frmService_add.cmbIst.Text = ""
        frmService_add.cmbMast.Text = ""
        frmService_add.txtPhone.Text = ""
        frmService_add.dtReg.Value = Date.Today
        frmService_add.dtIsp.Value = Date.Today
        frmService_add.txtHead.Text = ""
        frmService_add.txtRem.Text = ""
        frmService_add.cmbStatus.Text = ""
        frmService_add.cmbOtv.Text = ""
        frmService_add.cmbKrit.Text = ""
        frmService_add.cmbTip.Text = ""
        frmService_add.txtComent.Text = ""
        frmService_add.RemCashe.Text = 0
        frmService_add.cmbAdd.Text = langfile.GetString("frmComputers", "MSG30", "")
        frmService_add.chkClose.Checked = 0

        frmService_add.ShowDialog(frmserviceDesc)
    End Sub

    Private Sub DeleteBranche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBranche.Click

        Dim langfile As New IniFile(sLANGPATH)


        If MsgBox(langfile.GetString("frmComputers", "MSG23", "") & " " & lstGroups.SelectedNode.Text, MsgBoxStyle.YesNo, ProGramName) = MsgBoxResult.Yes Then

            Me.Cursor = Cursors.WaitCursor
            On Error GoTo err_

            Me.selectTECMesto()

            Dim d() As String

            d = Split(lstGroups.SelectedNode.Tag, "|")




            Select Case d(0)

                Case "C"

                Case "G"

                    RemoveBrainch(lstGroups.SelectedNode.Text)
                    Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG31", "") & " " & sBranch)

                Case "O"

                    RemoveDepartment(d(1))
                    Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG32", "") & " " & sBranch & "/" & sDepartment)

                Case "K"

                    RemoveOffice(d(1))
                    Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG33", "") & " " & sBranch & "/" & sDepartment & "/" & sOffice)

            End Select


            Me.Cursor = Cursors.Default

        Else

        End If

        Exit Sub
err_:
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub lstGroups_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstGroups.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                BTN = 1
            Case MouseButtons.Right
                BTN = 2
            Case MouseButtons.Middle
            Case Else
        End Select
    End Sub

    Private Sub lstGroups_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstGroups.MouseUp


        'BTN = Button
        On Error GoTo err_

        If uLevelTehAdd = False And uLevel <> "Admin" Then Exit Sub

        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")

        Dim langfile As New IniFile(sLANGPATH)


        Select Case d(0)

            Case "C" 'Техника

                If e.Button = Windows.Forms.MouseButtons.Right Then

                    cmMENU.Show(CType(sender, Control), e.Location)

                End If

            Case "G"

                If e.Button = Windows.Forms.MouseButtons.Right Then
                    mnuDeltoBranch.Text = langfile.GetString("frmComputers", "MSG34", "")

                    cmBmenu.Show(CType(sender, Control), e.Location)

                End If

            Case "K"

                If e.Button = Windows.Forms.MouseButtons.Right Then
                    mnuDeltoBranch.Text = langfile.GetString("frmComputers", "MSG35", "")

                    cmBmenu.Show(CType(sender, Control), e.Location)

                End If

            Case "O"

                If e.Button = Windows.Forms.MouseButtons.Right Then
                    mnuDeltoBranch.Text = langfile.GetString("frmComputers", "MSG36", "")

                    cmBmenu.Show(CType(sender, Control), e.Location)

                End If

            Case "OT"

                If e.Button = Windows.Forms.MouseButtons.Right Then
                    mnuDeltoBranch.Text = langfile.GetString("frmComputers", "MSG36", "")

                    cmBmenu.Show(CType(sender, Control), e.Location)

                End If

            Case "CNT"

                If e.Button = Windows.Forms.MouseButtons.Right Then
                    mnuDeltoBranch.Text = langfile.GetString("frmComputers", "MSG36", "")

                    cmBmenu.Show(CType(sender, Control), e.Location)

                End If

        End Select


        Exit Sub
err_:

    End Sub

    Private Sub btnOfficeSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOfficeSend.Click

        Me.selectTECMesto()


        Dim tipot As String
        tipot = Directory.GetParent(Application.ExecutablePath).ToString & "/blanks/ses.dot"

        Dim rsG As ADODB.Recordset
        rsG = New ADODB.Recordset
        rsG.Open("SELECT * FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim aaaa As String

        With rsG

            If Not IsDBNull(.Fields("ORG").Value) Then aaaa = .Fields("ORG").Value

        End With
        rsG.Close()
        rsG = Nothing


        Dim oSM As Object                 'Root object for accessing OpenOffice FROM VB
        Dim oDesk, oDoc As Object 'First objects FROM the API
        Dim arg(-1) As Object                 'Ignore it for the moment !
        'Dim mmerge As Object
        Dim objCoreReflection As Object ' objects from OOo API 

        'Instanciate OOo : this line is mandatory with VB for OOo API
        oSM = CreateObject("com.sun.star.ServiceManager")
        'Create the first and most important service
        objCoreReflection = oSM.createInstance("com.sun.star.reflection.CoreReflection")

        oDesk = oSM.createInstance("com.sun.star.frame.Desktop")
        'Create a new doc

        oDoc = oDesk.loadComponentFromURL("file:///" & tipot, "_blank", 0, arg)

        ' jon code
        Dim objText As Object, objCursor As Object
        objText = oDoc.GetText
        objCursor = objText.createTextCursor

        ' replace all
        Dim oSrch As Object
        'Set oSrch = oDoc.createSearchDescriptor
        oSrch = oDoc.createReplaceDescriptor
        oSrch.setSearchString("KONT")
        oSrch.setReplaceString(sBranch & "/" & sOffice & vbLf)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("ORG")
        oSrch.setReplaceString(aaaa)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("ADR")
        oSrch.setReplaceString(txtBRAddress.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("P1lo")
        oSrch.setReplaceString(Me.txtspplo.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("Vis")
        oSrch.setReplaceString(Me.txtspvis.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("Pl1Pk")
        oSrch.setReplaceString(Me.txtspPloOneEVM.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("ob1Pk")
        oSrch.setReplaceString(Me.txtspObOneEVM.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("nalpom")
        oSrch.setReplaceString(cmbSpRemEVM.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("vent")
        oSrch.setReplaceString(Me.cmbSpVent.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("teplo")
        oSrch.setReplaceString(Me.cmbSpTeplo.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("voda")
        oSrch.setReplaceString(Me.cmbSpWater.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("kanal")
        oSrch.setReplaceString(Me.cmbSpKanal.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("otdelka")
        oSrch.setReplaceString(Me.txtSpWall.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("mebel")
        oSrch.setReplaceString(Me.txtSpMebel.Text)
        Debug.Print(oDoc.replaceAll(oSrch))

        oSrch.setSearchString("KOLKOM")
        oSrch.setReplaceString(Me.lblT_O.Text)
        Debug.Print(oDoc.replaceAll(oSrch))



    End Sub

    Private Sub lvRepairBR_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadRepairEdit(lvRepairBR)
    End Sub

    Private Sub SoftInstallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoftInstallToolStripMenuItem.Click

        Dim sSQL, sSQL1, A, scN As String
        Dim langfile As New IniFile(sLANGPATH)

        Me.selectTECMesto()

        Select Case sPREF

            Case "G"
                'sBranch 
                sSQL = "SELECT count(*) as t_n FROM kompy WHERE FILIAL='" & sBranch & "' And TipTehn='PC'"
            Case "O"
                'sDepartment
                sSQL = "SELECT count(*) as t_n FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' And TipTehn='PC'"

            Case "K"
                'sOffice 

                sSQL = "SELECT count(*) as t_n FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' AND kabn ='" & sOffice & "' And TipTehn='PC'"
        End Select

        Dim rs As ADODB.Recordset
        Dim rs1 As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            scN = .Fields("t_n").Value

        End With
        rs.Close()
        rs = Nothing

        If scN = 0 Then Exit Sub


        Select Case sPREF

            Case "G"
                'sBranch 
                sSQL = "SELECT * FROM kompy WHERE FILIAL='" & sBranch & "' And TipTehn='PC'"
            Case "O"
                'sDepartment
                sSQL = "SELECT * FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' And TipTehn='PC'"

            Case "K"
                'sOffice 

                sSQL = "SELECT * FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' AND kabn ='" & sOffice & "' And TipTehn='PC'"
        End Select

        Select Case sOfficePACK

            Case "OpenOffice.org"


                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                Dim oSM As Object                 'Root object for accessing OpenOffice FROM VB
                Dim oDesk, oDoc As Object 'First objects FROM the API
                Dim arg(-1) As Object                 'Ignore it for the moment !
                'Dim mmerge As Object
                Dim objCoreReflection As Object ' objects from OOo API 

                'Instanciate OOo : this line is mandatory with VB for OOo API
                oSM = CreateObject("com.sun.star.ServiceManager")
                'Create the first and most important service
                objCoreReflection = oSM.createInstance("com.sun.star.reflection.CoreReflection")

                oDesk = oSM.createInstance("com.sun.star.frame.Desktop")
                'Create a new doc

                oDoc = oDesk.loadComponentFROMURL("private:factory/swriter", "_blank", 0, arg)

                ' jon code
                Dim objText As Object, objCursor As Object

                Dim objTable As Object ' objects from OOo API 
                Dim objRows, objRow As Object

                objText = oDoc.GetText
                objCursor = objText.createTextCursor

                ' replace all
                'Dim oSrch As Object




                Dim tiptehCP, uname, QWERT As String
                Dim GIST As Decimal = 0
                Dim intj As Decimal = 0
                With rs
                    .MoveFirst()
                    Do While Not .EOF
                        tiptehCP = .Fields("TipTehn").Value
                        GIST = 0
                        uname = .Fields("id").Value
                        If tiptehCP = "PC" Then
                            objText.insertString(objCursor, " " & vbLf, False)

                            objText.insertString(objCursor, langfile.GetString("frmComputers", "MSG37", "") & " " & .Fields("PSEVDONIM").Value & vbLf, False)
                            objText.insertString(objCursor, langfile.GetString("frmComputers", "MSG38", "") & " " & .Fields("FILIAL").Value & "/" & .Fields("MESTO").Value & "/" & .Fields("kabn").Value & vbLf, False)
                            'objText.insertString(objCursor, "Операционная система : " & .Fields("OS").Value & vbLf, False)

                            objText.insertString(objCursor, " " & vbLf, False)


                            'Установленное ПО
                            sSQL1 = "SELECT count(*) as t_n FROM SOFT_INSTALL WHERE id_comp=" & uname

                            rs1 = New ADODB.Recordset
                            rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
                            QWERT = rs1.RecordCount
                            rs1.Close()
                            rs1 = Nothing

                            rs1 = New ADODB.Recordset
                            rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rs1

                                GIST = .Fields("t_n").Value

                            End With

                            rs1.Close()
                            rs1 = Nothing

                            If GIST = 0 Then
                            Else

                                objTable = oDoc.createInstance("com.sun.star.text.TextTable")
                                objTable.Initialize(GIST + 1, 1)
                                objText.insertTextContent(objCursor, objTable, False)

                                objRows = objTable.GetRows
                                objRow = objRows.getByIndex(0)

                                objTable.setPropertyValue("BackTransparent", True)
                                objTable.setPropertyValue("BackColor", 16777215)


                                intj = 1
                                insertIntoCell("A1", langfile.GetString("frmComputers", "MSG39", ""), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                                sSQL1 = "SELECT * FROM SOFT_INSTALL WHERE id_comp=" & uname
                                rs1 = New ADODB.Recordset
                                rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                                With rs1
                                    If .RecordCount <> 0 Then
                                        .MoveFirst()
                                        Do While Not .EOF
                                            A = "A" & intj + 1

                                            insertIntoCell(A, .Fields("Soft"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                                            intj = intj + 1

                                            .MoveNext()
                                        Loop
                                    End If
                                End With
                                rs1.Close()
                                rs1 = Nothing

                                objText.insertString(objCursor, " " & vbLf, False)

                            End If
                        End If
                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

            Case Else

                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                Dim oWord As Word.Application
                Dim oDoc As Word.Document
                Dim oTable As Word.Table
                Dim oPara1 As Word.Paragraph, oPara2 As Word.Paragraph
                'Dim oPara3 As Word.Paragraph, oPara4 As Word.Paragraph
                'Dim oRng As Word.Range
                ' Dim oShape As Word.InlineShape
                ' Dim oChart As Object
                ' Dim Pos As Double
                '
                'Start Word and open the document template.
                oWord = CreateObject("Word.Application")
                oWord.Visible = True
                oDoc = oWord.Documents.Add

                Dim tiptehCP, uname, QWERT As String
                Dim GIST As Decimal = 0
                Dim intj As Decimal = 0

                With rs
                    .MoveFirst()
                    Do While Not .EOF
                        tiptehCP = .Fields("TipTehn").Value
                        GIST = 0
                        uname = .Fields("id").Value

                        If tiptehCP = "PC" Then

                            oPara1 = oDoc.Content.Paragraphs.Add
                            oPara1.Range.Text = langfile.GetString("frmComputers", "MSG37", "") & " " & .Fields("PSEVDONIM").Value
                            oPara1.Range.Font.Bold = True
                            oPara1.Format.SpaceAfter = 6
                            oPara1.Range.InsertParagraphAfter()

                            oPara1 = oDoc.Content.Paragraphs.Add
                            oPara1.Range.Text = langfile.GetString("frmComputers", "MSG38", "") & " " & .Fields("FILIAL").Value & "/" & .Fields("MESTO").Value & "/" & .Fields("kabn").Value
                            oPara1.Range.Font.Bold = True
                            oPara1.Format.SpaceAfter = 24
                            oPara1.Range.InsertParagraphAfter()


                            sSQL1 = "SELECT count(*) as t_n FROM SOFT_INSTALL WHERE id_comp=" & uname

                            rs1 = New ADODB.Recordset
                            rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
                            QWERT = rs1.RecordCount
                            rs1.Close()
                            rs1 = Nothing

                            rs1 = New ADODB.Recordset
                            rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rs1
                                GIST = .Fields("t_n").Value
                            End With

                            rs1.Close()
                            rs1 = Nothing

                            If GIST = 0 Then
                            Else

                                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, GIST + 1, 1)
                                oTable.Range.ParagraphFormat.SpaceAfter = 6
                                oTable.Cell(1, 1).Range.Text = langfile.GetString("frmComputers", "MSG39", "")

                                sSQL1 = "SELECT * FROM SOFT_INSTALL WHERE id_comp=" & uname
                                rs1 = New ADODB.Recordset
                                rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                                intj = 2
                                With rs1
                                    If .RecordCount <> 0 Then
                                        .MoveFirst()
                                        Do While Not .EOF

                                            oTable.Cell(intj, 1).Range.Text = .Fields("Soft").Value

                                            intj = intj + 1

                                            .MoveNext()
                                        Loop
                                    End If
                                End With
                                rs1.Close()
                                rs1 = Nothing

                                oPara1 = oDoc.Content.Paragraphs.Add
                                oPara1.Range.Text = ""
                                oPara1.Range.Font.Bold = True
                                oPara1.Format.SpaceAfter = 24    '24 pt spacing after paragraph.
                                oPara1.Range.InsertParagraphAfter()

                            End If
                        End If

                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing



        End Select



    End Sub

    Private Sub ПаспортКомпьютераToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПаспортКомпьютераToolStripMenuItem.Click
        Dim sSQL, scN As String

        Me.selectTECMesto()

        Select Case sPREF

            Case "G"
                'sBranch 
                sSQL = "SELECT count(*) as t_n FROM kompy WHERE FILIAL='" & sBranch & "' And TipTehn='PC'"
            Case "O"
                'sDepartment
                sSQL = "SELECT count(*) as t_n FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' And TipTehn='PC'"

            Case "K"
                'sOffice 

                sSQL = "SELECT count(*) as t_n FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' AND kabn ='" & sOffice & "' And TipTehn='PC'"
        End Select

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            scN = .Fields("t_n").Value

        End With
        rs.Close()
        rs = Nothing

        If scN = 0 Then Exit Sub


        Select Case sPREF

            Case "G"
                'sBranch 
                sSQL = "SELECT * FROM kompy WHERE FILIAL='" & sBranch & "' And TipTehn='PC'"
            Case "O"
                'sDepartment
                sSQL = "SELECT * FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' And TipTehn='PC'"

            Case "K"
                'sOffice 

                sSQL = "SELECT * FROM kompy WHERE FILIAL='" & sBranch & "' And MESTO='" & sDepartment & "' AND kabn ='" & sOffice & "' And TipTehn='PC'"
        End Select



        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case sOfficePACK

                    Case "OpenOffice.org"

                        OOO_SEND_PK(.Fields("id").Value)

                    Case Else

                        WRD_SEND_PK(.Fields("id").Value)

                End Select

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


    End Sub

    Private Sub gbcpu_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbcpu.DoubleClick

        If rbSist.Checked = True Then Exit Sub

        If Len(cmbCPU1.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call GCHTIO()
        frmGarCPL.sTEXT = "CPU"
        frmGarCPL.ShowDialog(Me)


    End Sub

    Private Sub gbRAM_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbRAM.DoubleClick

        If rbSist.Checked = True Then Exit Sub

        If Len(gbRAM.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call PAMIAT()
        frmGarCPL.sTEXT = "RAM"
        frmGarCPL.ShowDialog(Me)

    End Sub

    Private Sub gbHDD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbHDD.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(cmbHDD1.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call HARDY()
        frmGarCPL.sTEXT = "HDD"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbSVGA_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbSVGA.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(cmbSVGA1.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call VideoCard()
        frmGarCPL.sTEXT = "SVGA"
        frmGarCPL.ShowDialog(Me)

    End Sub

    Private Sub gbSOUND_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbSOUND.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(cmbSound.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call SoundCard()
        frmGarCPL.sTEXT = "SOUND"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbMB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbMB.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(cmbMB.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call GCHTIm()
        frmGarCPL.sTEXT = "MB"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbOptical_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbOptical.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbRAM.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call CdrF()
        frmGarCPL.sTEXT = "OPTICAL"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Public Sub lstGroups_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lstGroups.ItemDrag
        On Error Resume Next

        If uLevelTehAdd = False And uLevel <> "Admin" Then Exit Sub

        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")

        Select Case d(0)

            Case "C"

                pDRAG = True

                DoDragDrop(e.Item, DragDropEffects.Move)

            Case Else

                pDRAG = False

        End Select



    End Sub

    Public Sub lstGroups_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstGroups.DragEnter
        On Error Resume Next

        If uLevelTehAdd = False And uLevel <> "Admin" Then Exit Sub

        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow move effect

            Dim d() As String
            d = Split(lstGroups.SelectedNode.Tag, "|")

            Select Case d(0)

                Case "C"

                    Exit Sub
                Case Else

                    e.Effect = DragDropEffects.Move

            End Select

        Else
            'No TreeNode found, prevent move
            pDRAG = False
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Public Sub lstGroups_DragOver(ByVal sender As System.Object, ByVal e As DragEventArgs) Handles lstGroups.DragOver
        On Error Resume Next

        If uLevelTehAdd = False And uLevel <> "Admin" Then Exit Sub

        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'As the mouse moves over nodes, provide feedback to the user
        'by highlighting the node that is the current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)

        'See if the targetNode is currently selected, if so no need to validate again
        If Not (selectedTreeview Is targetNode) Then
            'Select the node currently under the cursor
            selectedTreeview.SelectedNode = targetNode

            'Check that the selected node is not the dropNode and also that it
            'is not a child of the dropNode and therefore an invalid target
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

            Do Until targetNode Is Nothing

                If targetNode Is dropNode Then

                    e.Effect = DragDropEffects.None
                    pDRAG = False
                    Exit Sub

                End If

                Dim d() As String
                d = Split(lstGroups.SelectedNode.Tag, "|")

                Select Case d(0)

                    Case "C"

                        e.Effect = DragDropEffects.None

                        Exit Sub
                    Case Else

                        targetNode = targetNode.Parent

                End Select



            Loop
        End If

        'Currently selected node is a suitable target, allow the move
        e.Effect = DragDropEffects.Move

    End Sub

    Public Sub lstGroups_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstGroups.DragDrop
        On Error Resume Next

        Dim sBranch_, sDepartment_, sOffice_ As String

        If uLevelTehAdd = False And uLevel <> "Admin" Then Exit Sub

        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = selectedTreeview.SelectedNode

        'Remove the drop node from its current location
        dropNode.Remove()

        'If there is no targetNode add dropNode to the bottom of the TreeView root
        'nodes, otherwise add it to the end of the dropNode child nodes
        If targetNode Is Nothing Then

            selectedTreeview.Nodes.Add(dropNode)

            pDRAG = False

        Else


            pDRAG = True

            targetNode.Nodes.Add(dropNode)

            Call selectTECMesto()



            sBranch_ = sBranch
            sDepartment_ = sDepartment
            sOffice_ = sOffice


        End If

        'Ensure the newley created node is visible to the user and select it

        If pDRAG = True Then

            dropNode.EnsureVisible()
            selectedTreeview.SelectedNode = dropNode

            Me.Cursor = Cursors.WaitCursor

            Select Case TipTehn

                Case "PC"

                    Me.cmbBranch.Text = sBranch_
                    Me.cmbDepartment.Text = sDepartment_
                    Me.cmbOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)

                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()

                Case "KOpir"

                    Me.cmbPRNFil.Text = sBranch_
                    Me.cmbPRNDepart.Text = sDepartment_
                    Me.cmbPRNOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "Printer"

                    Me.cmbPRNFil.Text = sBranch_
                    Me.cmbPRNDepart.Text = sDepartment_
                    Me.cmbPRNOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "MFU"

                    Me.cmbPRNFil.Text = sBranch_
                    Me.cmbPRNDepart.Text = sDepartment_
                    Me.cmbPRNOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "NET"

                    Me.cmbNETBranch.Text = sBranch_
                    Me.cmbNetDepart.Text = sDepartment_
                    Me.cmbNETOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    LOADnet(Me.sCOUNT)
                Case "MONITOR"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    LOADmon(Me.sCOUNT)
                Case "PHONE"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "PHOTO"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "FAX"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "ZIP"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "SCANER"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "OT"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    '--------------VIP_Graff Добавление новой перефирии Конец------------------

                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "USB"
                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_
                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "SOUND"
                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_
                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    LOADot(Me.sCOUNT)
                Case "IBP"
                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_
                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "FS"
                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_
                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "KEYB"
                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_
                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case "MOUSE"
                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_
                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    '--------------VIP_Graff Добавление новой перефирии Конец------------------
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()

                Case "CNT"

                    Me.cmbOTHFil.Text = sBranch_
                    Me.cmbOTHDepart.Text = sDepartment_
                    Me.cmbOTHOffice.Text = sOffice_

                    SAVE_DRAG_DROP(Me.sCOUNT, sBranch_, sDepartment_, sOffice_, Me.lstGroups.SelectedNode.Text)
                    Dim newThread1 As New Thread(AddressOf T_LOAD_T)
                    newThread1.Start()
                    Dim newThread6 As New Thread(AddressOf D_P_LOAD_t)
                    newThread6.Start()
                Case Else

            End Select

        End If

        pDRAG = False
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub gbNetwork_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbNetwork.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call NEtr()
        frmGarCPL.sTEXT = "NET"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbFDD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbFDD.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call FDDsS()
        frmGarCPL.sTEXT = "FDD"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbModem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbModem.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call MODEMs()
        frmGarCPL.sTEXT = "MODEM"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbMonitor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbMonitor.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call MonitorS()
        frmGarCPL.sTEXT = "MONITOR"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbKeyboard_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbKeyboard.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call KEYBOARDs()
        frmGarCPL.sTEXT = "KEYBOARD"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbMouse_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbMouse.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call MOUSEs()
        frmGarCPL.sTEXT = "MOUSE"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbFilter_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbFilter.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call FILTRsS()
        frmGarCPL.sTEXT = "FS"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub gbUSB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbUSB.DoubleClick
        If rbSist.Checked = True Then Exit Sub

        If Len(gbNetwork.Text) = 0 Then
            Exit Sub
        End If

        Call GAR_ED()

        frmGarCPL.cmbPostav.Text = ""
        Call USBs()
        frmGarCPL.sTEXT = "USB"
        frmGarCPL.ShowDialog(Me)
    End Sub

    Private Sub ОтделитьПринтерыИМониторыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОтделитьПринтерыИМониторыToolStripMenuItem.Click
        Dim langfile As New IniFile(sLANGPATH)



        If TipTehn <> "PC" Then Exit Sub

        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG40", "") & " " & Me.lstGroups.SelectedNode.Text)

        Call selectTECMesto()

        Call Re_PRN()

        Dim newThread1 As New Thread(AddressOf STAT_INF_1)
        newThread1.Start()

    End Sub

    Private Sub cmdUserAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserAdd.Click

        Call User_Comp_ADD()

    End Sub

    Private Sub cmdUserDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserDel.Click
        If lstUsers.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        For z = 0 To lstUsers.SelectedItems.Count - 1
            uCOUNT = (lstUsers.SelectedItems(z).Text)
        Next

        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("Delete FROM USER_COMP WHERE id=" & uCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs1 = Nothing
        LOAD_USER(sCOUNT)
    End Sub

    Private Sub cmdUserPassEncript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserPassEncript.Click
        Dim langfile As New IniFile(sLANGPATH)


        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG41", "") & " " & Me.lstGroups.SelectedNode.Text)

        txtUserPass.PasswordChar = ""
        txtUserEmailPwd.PasswordChar = ""


        strPassword = Trim(txtUserPass.Text)
        Call EncryptDecrypt(strPassword)
        txtUserPass.Text = Temp$


        strPassword = Trim(txtUserEmailPwd.Text)
        Call EncryptDecrypt(strPassword)
        txtUserEmailPwd.Text = Temp$
    End Sub

    Private Sub lstUsers_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstUsers.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lstUsers.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lstUsers.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lstUsers.Sort()
    End Sub

    Private Sub lstUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUsers.DoubleClick

        If lstUsers.Items.Count = 0 Then Exit Sub

        For Each C In Me.sSTAB1.TabPages(4).Controls
            If TypeOf C Is TextBox Then C.Text = ""
        Next C

        txtUserPass.PasswordChar = "*"
        txtUserEmailPwd.PasswordChar = "*"

        Dim z As Integer

        For z = 0 To lstUsers.SelectedItems.Count - 1
            uCOUNT = (lstUsers.SelectedItems(z).Text)
        Next

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        rs.Open("SELECT * FROM USER_COMP WHERE id=" & uCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("USERNAME").Value) Then txtUserName.Text = .Fields("USERNAME").Value
            If Not IsDBNull(.Fields("PASSWORD").Value) Then txtUserPass.Text = .Fields("PASSWORD").Value
            If Not IsDBNull(.Fields("EMAIL").Value) Then txtUserEmail.Text = .Fields("EMAIL").Value
            If Not IsDBNull(.Fields("EPASS").Value) Then txtUserEmailPwd.Text = .Fields("EPASS").Value
            If Not IsDBNull(.Fields("FIO").Value) Then txtUserFIO.Text = .Fields("FIO").Value
            If Not IsDBNull(.Fields("icq").Value) Then txtUserIcq.Text = .Fields("icq").Value
            If Not IsDBNull(.Fields("MEMO").Value) Then txtUMEMO.Text = .Fields("MEMO").Value


            If .Fields("PDC").Value = True Then

                Me.ChkPDC.Checked = True
            Else
                Me.ChkPDC.Checked = False
            End If



        End With
        Dim langfile As New IniFile(sLANGPATH)


        cmdUserAdd.Text = langfile.GetString("frmComputers", "MSG42", "")

        rs.Close()
        rs = Nothing
    End Sub

    Private Sub lvRepair_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRepair.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
lvRepair.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvRepair.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvRepair.Sort()
    End Sub

    Private Sub lvRepair_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRepair.DoubleClick
        LoadRepairEdit(lvRepair)
    End Sub

    Private Sub btnNotesAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotesAdd.Click
        Dim sStr As String = txtSNAME.Text

        NotesEditAdd(btnNotesAdd, lvNotes, cmbNotesMaster, txtNotes, dtDateNotes, sStr, cmbBranch, cmbDepartment, cmbOffice)

    End Sub

    Private Sub btnNotesDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotesDel.Click
        RemoVe_Notes(lvNotes)
        Notes_Clear(btnNotesAdd, dtDateNotes, cmbNotesMaster, txtNotes)
    End Sub

    Private Sub btnNotesCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotesCancel.Click
        Notes_Clear(btnNotesAdd, dtDateNotes, cmbNotesMaster, txtNotes)
    End Sub

    Private Sub lvNotes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotes.Click
        zCOUNT_LOAD(lvNotes)
    End Sub

    Private Sub lvNotes_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvNotes.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
lvNotes.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvNotes.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvNotes.Sort()
    End Sub

    Private Sub lvNotes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotes.DoubleClick
        NotesLoaded(lvNotes, dtDateNotes, cmbNotesMaster, txtNotes, btnNotesAdd)
    End Sub

    Private Sub btnBRNotesAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBRNotesAdd.Click

        Call BR_NOTES_ADD()

    End Sub

    Private Sub btnBRNotesCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBRNotesCancel.Click
        Notes_Clear(btnBRNotesAdd, Notesbrdate, cmbBRMaster, Notesbrtxt)
    End Sub

    Private Sub lvNotesBR_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotesBR.DoubleClick
        If lvNotesBR.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvNotesBR.SelectedItems.Count - 1
            zCOUNT = (lvNotesBR.SelectedItems(z).Text)
        Next

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        rs.Open("SELECT * FROM ZAM_OTD WHERE id=" & zCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("Date").Value) Then Notesbrdate.Value = .Fields("Date").Value
            If Not IsDBNull(.Fields("Master").Value) Then cmbBRMaster.Text = .Fields("Master").Value
            If Not IsDBNull(.Fields("ZAMETKA").Value) Then Notesbrtxt.Text = .Fields("ZAMETKA").Value


        End With




        Dim langfile As New IniFile(sLANGPATH)

        btnBRNotesAdd.Text = langfile.GetString("frmComputers", "MSG42", "")

        rs.Close()
        rs = Nothing
    End Sub

    Private Sub btnPRNNotesAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRNNotesAdd.Click
        Dim sStr As String = cmbPRN.Text
        NotesEditAdd(btnPRNNotesAdd, lvNotesPRN, cmbNotesPRNMaster, NotesPRNtxt, NotesPRNdate, sStr, cmbPRNFil, cmbPRNDepart, cmbPRNOffice)
    End Sub

    Private Sub btnPRNNotesDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRNNotesDel.Click
        RemoVe_Notes(lvNotesPRN)
        Notes_Clear(btnPRNNotesAdd, NotesPRNdate, cmbNotesPRNMaster, NotesPRNtxt)
    End Sub

    Private Sub btnPRNNotesCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRNNotesCancel.Click
        Notes_Clear(btnPRNNotesAdd, NotesPRNdate, cmbNotesPRNMaster, NotesPRNtxt)
    End Sub

    Private Sub lvNotesPRN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotesPRN.Click
        zCOUNT_LOAD(lvNotesPRN)
    End Sub

    Private Sub lvNotesPRN_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvNotesPRN.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lvNotesPRN.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvNotesPRN.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvNotesPRN.Sort()
    End Sub

    Private Sub lvNotesPRN_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotesPRN.DoubleClick
        NotesLoaded(lvNotesPRN, NotesPRNdate, cmbNotesPRNMaster, NotesPRNtxt, btnPRNNotesAdd)
    End Sub

    Private Sub lvRepairPRN_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRepairPRN.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lvRepairPRN.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvRepairPRN.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvRepairPRN.Sort()
    End Sub

    Private Sub lvRepairPRN_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRepairPRN.DoubleClick
        LoadRepairEdit(lvRepairPRN)
    End Sub

    Private Sub lvRepairBR_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRepairBR.DoubleClick
        LoadRepairEdit(lvRepairBR)
    End Sub

    Private Sub btnBRNotesDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBRNotesDel.Click
        RemoVe_Notes(lvNotesBR)
        Notes_Clear(btnBRNotesAdd, Notesbrdate, cmbBRMaster, Notesbrtxt)
    End Sub

    Private Sub btnNETAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNETAdd.Click
        Dim sStr As String = cmbDevNet.Text

        NotesEditAdd(btnNETAdd, lvNotesNET, cmbNotesNETMaster, NotesNETtxt, NotesNETdate, sStr, cmbNETBranch, cmbNetDepart, cmbNETOffice)
    End Sub

    Private Sub btnNETNotesDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNETNotesDel.Click
        RemoVe_Notes(lvNotesNET)
        Notes_Clear(btnNETAdd, NotesNETdate, cmbNotesNETMaster, NotesNETtxt)
    End Sub

    Private Sub btnNETNotesCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNETNotesCancel.Click
        Notes_Clear(btnNETAdd, NotesNETdate, cmbNotesNETMaster, NotesNETtxt)
    End Sub

    Private Sub lvNotesNET_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotesNET.Click
        zCOUNT_LOAD(lvNotesNET)
    End Sub

    Private Sub lvNotesNET_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvNotesNET.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lvNotesNET.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvNotesNET.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvNotesNET.Sort()
    End Sub

    Private Sub lvNotesNET_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotesNET.DoubleClick
        NotesLoaded(lvNotesNET, NotesNETdate, cmbNotesNETMaster, NotesNETtxt, btnNETAdd)
    End Sub

    Private Sub lvRepairNET_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRepairNET.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lvRepairNET.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvRepairNET.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvRepairNET.Sort()
    End Sub

    Private Sub lvRepairNET_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRepairNET.DoubleClick
        LoadRepairEdit(lvRepairNET)
    End Sub

    Private Sub btnOTHAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTHAdd.Click
        Dim sStr As String = cmbOTH.Text

        NotesEditAdd(btnOTHAdd, lvNotesOTH, cmbNotesOTHMaster, txtNotesOTH, NotesOTHdate, sStr, cmbOTHFil, cmbOTHDepart, cmbOTHOffice)

    End Sub

    Private Sub btnOTHNotesDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTHNotesDel.Click
        RemoVe_Notes(lvNotesOTH)
        Notes_Clear(btnOTHAdd, NotesOTHdate, cmbNotesOTHMaster, txtNotesOTH)
    End Sub

    Private Sub btnOTHNotesCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTHNotesCancel.Click
        Notes_Clear(btnOTHAdd, NotesOTHdate, cmbNotesOTHMaster, txtNotesOTH)
    End Sub

    Private Sub lvRepairOTH_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRepairOTH.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
lvRepairOTH.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvRepairOTH.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvRepairOTH.Sort()
    End Sub

    Private Sub lvRepairOTH_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRepairOTH.DoubleClick
        LoadRepairEdit(lvRepairOTH)
    End Sub

    Private Sub lvNotesOTH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotesOTH.Click
        zCOUNT_LOAD(lvNotesOTH)
    End Sub

    Private Sub lvNotesOTH_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvNotesOTH.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
lvNotesOTH.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvNotesOTH.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvNotesOTH.Sort()
    End Sub

    Private Sub lvNotesOTH_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNotesOTH.DoubleClick
        NotesLoaded(lvNotesOTH, NotesOTHdate, cmbNotesOTHMaster, txtNotesOTH, btnOTHAdd)
    End Sub

    Private Sub CartrAddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CartrAddToolStripMenuItem.Click

        'frmCartr_ADD()


        Dim langfile As New IniFile(sLANGPATH)

        frmCartr_ADD.Text = langfile.GetString("frmComputers", "MSG43", "") & " " & lstGroups.SelectedNode.Text

        'serviceDesc.MdiParent = frmMain
        'serviceDesc.Show()

        frmCartr_ADD.CRTFU = True

        frmCartr_ADD.EDTRCART = False
        frmCartr_ADD.chkNaSP.Checked = 0
        frmCartr_ADD.chkSPS.Checked = 0
        frmCartr_ADD.chkIznos.Checked = 0
        frmCartr_ADD.chkNZ.Checked = 0
        frmCartr_ADD.chkNezap.Checked = 0
        frmCartr_ADD.txtCashe.Text = ""
        frmCartr_ADD.txtSaleNumb.Text = ""
        frmCartr_ADD.cmbSaler.Text = ""
        frmCartr_ADD.cmbSostUstr.Text = ""
        frmCartr_ADD.cmbModC.Text = ""
        frmCartr_ADD.cmbTipC.Text = ""
        frmCartr_ADD.cmbProizv.Text = ""
        frmCartr_ADD.txtSerNumb.Text = ""
        frmCartr_ADD.lblRealNumber.Text = ""
        frmCartr_ADD.txtMemo.Text = ""
        frmCartr_ADD.dtSale.Value = Date.Today

        frmCRT3.cCOUNT = Me.sCOUNT
        frmCartr_ADD.ShowDialog(Me)

        Call SaveActivityToLogDB(langfile.GetString("frmComputers", "MSG44", "") & " " & lstGroups.SelectedNode.Text)
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        On Error GoTo err_

        BrainchLoad(cmbBranch, cmbDepartment)

        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartment.SelectedIndexChanged
        On Error GoTo err_

        DepartmentLoad(cmbBranch, cmbDepartment, cmbOffice)

        Exit Sub
err_:
    End Sub

    Private Sub cmbPRNFil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPRNFil.SelectedIndexChanged
        On Error GoTo err_

        BrainchLoad(cmbPRNFil, cmbPRNDepart)

        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub cmbPRNDepart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPRNDepart.SelectedIndexChanged
        On Error GoTo err_

        DepartmentLoad(cmbPRNFil, cmbPRNDepart, cmbPRNOffice)

        Exit Sub
err_:
    End Sub

    Private Sub lvPRNCartr_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPRNCartr.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lvPRNCartr.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvPRNCartr.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvPRNCartr.Sort()
    End Sub

    Private Sub lvPRNCartr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPRNCartr.DoubleClick
        Dim z As Integer
        'Dim rCOUNT As Integer

        For z = 0 To lvPRNCartr.SelectedItems.Count - 1
            frmCRT3.rCOUNT = (lvPRNCartr.SelectedItems(z).Text)
        Next

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("general", "DK", frmCRT3.rCOUNT)
        objIniFile.WriteString("general", "Default", 0)


        frmCRT3.MdiParent = frmMain
        frmCRT3.Show()
        'frmCartr_ADD.btnAdd.Text = "Сохранить"
        'frmCRT3.LOAD_CRR(frmCRT3.rCOUNT)
    End Sub

    Private Sub cmbOTH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOTH.SelectedIndexChanged
        Select Case TipTehn

            Case "MONITOR"
                ExLoadParTree(cmbOTH.Text, txtMonDum, PROiZV39, "SPR_MONITOR")

            Case "FAX"

                ExLoadParTwo(cmbOTH.Text, PROiZV39, "spr_fax")

            Case "PHONE"

                ExLoadParTwo(cmbOTH.Text, PROiZV39, "spr_phone")

            Case "PHOTO"

                ExLoadParTwo(cmbOTH.Text, PROiZV39, "spr_photo")

            Case "SCANER"

                ExLoadParTwo(cmbOTH.Text, PROiZV39, "SPR_SCANER")

            Case "ZIP"

                ExLoadParTwo(cmbOTH.Text, PROiZV39, "spr_zip")

            Case "OT"
                'ExLoadParTwo(cmbOTH.Text, PROiZV39, "SPR_OTH_DEV")

                Dim rs As ADODB.Recordset
                Dim sSQL As String
                Dim uNI As String
                rs = New ADODB.Recordset

                sSQL = "SELECT * FROM SPR_OTH_DEV WHERE Name = '" & cmbOTH.Text & "'"

                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs

                    If Not IsDBNull(.Fields("proizv").Value) Then uNI = .Fields("proizv").Value

                    Dim PROYZV As ADODB.Recordset
                    PROYZV = New ADODB.Recordset
                    PROYZV.Open("SELECT * FROM SPR_PROIZV WHERE iD=" & uNI, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With PROYZV
                        PROiZV39.Text = .Fields("proizv").Value
                    End With
                    PROYZV.Close()
                    PROYZV = Nothing

                    If Not IsDBNull(.Fields("A").Value) Then cmbOTHConnect.Text = .Fields("A").Value

                End With

                rs.Close()
                rs = Nothing

                '--------------VIP_Graff Добавление новой перефирии Начало-----------------
            Case "USB"
                ExLoadParTwo(cmbOTH.Text, PROiZV39, "spr_usb")

            Case "SOUND"
                ExLoadParTwo(cmbOTH.Text, PROiZV39, "SPR_ASISTEM")

            Case "IBP"
                ExLoadParTwo(cmbOTH.Text, PROiZV39, "SPR_IBP")

            Case "FS"
                ExLoadParTwo(cmbOTH.Text, PROiZV39, "SPR_FS")

            Case "KEYB"
                ExLoadParTwo(cmbOTH.Text, PROiZV39, "SPR_KEYBOARD")

            Case "MOUSE"
                ExLoadParTwo(cmbOTH.Text, PROiZV39, "SPR_MOUSE")
                '--------------VIP_Graff Добавление новой перефирии Конец------------------

            Case "CNT"
                ExLoadParTwo(cmbOTH.Text, PROiZV39, "spr_other")


        End Select
    End Sub

    Private Sub cmbOTHFil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOTHFil.SelectedIndexChanged
        BrainchLoad(cmbOTHFil, cmbOTHDepart)

        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub cmbOTHDepart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOTHDepart.SelectedIndexChanged


        DepartmentLoad(cmbOTHFil, cmbOTHDepart, cmbOTHOffice)


        Exit Sub
err_:
    End Sub

    Private Sub cmbCPU1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPU1.SelectedIndexChanged
        ExLoadParFow(cmbCPU1.Text, txtMHZ1, txtSoc1, PROizV1, "SPR_CPU")
    End Sub

    Private Sub cmbCPU2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPU2.SelectedIndexChanged
        ExLoadParFow(cmbCPU2.Text, txtMHZ2, txtSoc2, PROizV2, "SPR_CPU")
    End Sub

    Private Sub cmbCPU3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPU3.SelectedIndexChanged
        ExLoadParFow(cmbCPU3.Text, txtMHZ3, txtSoc3, PROizV3, "SPR_CPU")
    End Sub

    Private Sub cmbCPU4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPU4.SelectedIndexChanged
        ExLoadParFow(cmbCPU4.Text, txtMHZ4, txtSoc4, PROizV4, "SPR_CPU")
    End Sub

    Private Sub cmbRAM1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRAM1.SelectedIndexChanged
        ExLoadParTree(cmbRAM1.Text, txtRamS1, PROizV6, "SPR_RAM")
    End Sub

    Private Sub cmbRAM2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRAM2.SelectedIndexChanged
        ExLoadParTree(cmbRAM2.Text, txtRamS2, PROizV7, "SPR_RAM")
    End Sub

    Private Sub cmbRAM3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRAM3.SelectedIndexChanged
        ExLoadParTree(cmbRAM3.Text, txtRamS3, PROizV8, "SPR_RAM")
    End Sub

    Private Sub cmbRAM4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRAM4.SelectedIndexChanged
        ExLoadParTree(cmbRAM4.Text, txtRamS4, PROizV9, "SPR_RAM")
    End Sub

    Private Sub cmbHDD1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHDD1.SelectedIndexChanged
        ExLoadParTree(cmbHDD1.Text, txtHDDo1, PROizV10, "SPR_HDD")
    End Sub

    Private Sub cmbHDD2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHDD2.SelectedIndexChanged
        ExLoadParTree(cmbHDD2.Text, txtHDDo2, PROizV11, "SPR_HDD")
    End Sub

    Private Sub cmbHDD3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHDD3.SelectedIndexChanged
        ExLoadParTree(cmbHDD3.Text, txtHDDo3, PROizV12, "SPR_HDD")
    End Sub

    Private Sub cmbHDD4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHDD4.SelectedIndexChanged
        ExLoadParTree(cmbHDD4.Text, txtHDDo4, PROizV13, "SPR_HDD")
    End Sub

    Private Sub cmbSVGA1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSVGA1.SelectedIndexChanged
        ExLoadParTree(cmbSVGA1.Text, txtSVGAr1, PROizV14, "SPR_SVGA")
    End Sub

    Private Sub cmbSVGA2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSVGA2.SelectedIndexChanged
        ExLoadParTree(cmbSVGA2.Text, txtSVGAr2, PROizV15, "SPR_SVGA")
    End Sub

    Private Sub cmbSound_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSound.SelectedIndexChanged
        ExLoadParTree(cmbSound.Text, txtSoundB, PROizV16, "SPR_SOUND")
    End Sub

    Private Sub cmbMB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMB.SelectedIndexChanged
        ExLoadParTree(cmbMB.Text, txtChip, PROizV5, "SPR_MB")
    End Sub

    Private Sub cmbOPTIC1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOPTIC1.SelectedIndexChanged
        ExLoadParTree(cmbOPTIC1.Text, txtOPTICs1, PROizV17, "SPR_OPTICAL")
    End Sub

    Private Sub cmbOPTIC2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOPTIC2.SelectedIndexChanged
        ExLoadParTree(cmbOPTIC2.Text, txtOPTICs2, PROizV18, "SPR_OPTICAL")
    End Sub

    Private Sub cmbOPTIC3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOPTIC3.SelectedIndexChanged
        ExLoadParTree(cmbOPTIC3.Text, txtOPTICs3, PROizV19, "SPR_OPTICAL")
    End Sub

    Private Sub cmbNET1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNET1.SelectedIndexChanged
        ExLoadParTwo(cmbNET1.Text, PROizV20, "SPR_NET")
    End Sub

    Private Sub cmbNET2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNET2.SelectedIndexChanged
        ExLoadParTwo(cmbNET2.Text, PROizV21, "SPR_NET")
    End Sub

    Private Sub cmbFDD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFDD.SelectedIndexChanged
        ExLoadParTwo(cmbFDD.Text, PROizV22, "SPR_FDD")
    End Sub

    Private Sub cmbCreader_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCreader.SelectedIndexChanged
        ExLoadParTwo(cmbCreader.Text, PROizV23, "SPR_CREADER")
    End Sub

    Private Sub cmbModem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModem.SelectedIndexChanged
        ExLoadParTwo(cmbModem.Text, PROizV24, "SPR_MODEM")
    End Sub

    Private Sub cmbCase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCase.SelectedIndexChanged
        ExLoadParTwo(cmbCase.Text, PROizV25, "SPR_CASE")
    End Sub

    Private Sub cmbBP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBP.SelectedIndexChanged
        ExLoadParTwo(cmbBP.Text, PROizV26, "SPR_BP")
    End Sub

    Private Sub cmbUSB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUSB.SelectedIndexChanged
        ExLoadParTwo(cmbUSB.Text, PROizV41, "SPR_USB")
    End Sub

    Private Sub cmbPCI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPCI.SelectedIndexChanged
        ExLoadParTwo(cmbPCI.Text, PROizV42, "SPR_PCI")
    End Sub

    Private Sub cmbMon1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMon1.SelectedIndexChanged
        ExLoadParTree(cmbMon1.Text, txtMon1Dum, PROizV28, "SPR_MONITOR")
    End Sub

    Private Sub cmbMon2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMon2.SelectedIndexChanged
        ExLoadParTree(cmbMon2.Text, txtMon2Dum, PROizV29, "SPR_MONITOR")
    End Sub

    Private Sub cmbPrinters1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrinters1.SelectedIndexChanged
        ExLoadParTwo(cmbPrinters1.Text, PROizV34, "SPR_PRINTER")
    End Sub

    Private Sub cmbPrinters2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrinters2.SelectedIndexChanged
        ExLoadParTwo(cmbPrinters2.Text, PROizV35, "SPR_PRINTER")
    End Sub

    Private Sub cmbPrinters3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrinters3.SelectedIndexChanged
        ExLoadParTwo(cmbPrinters3.Text, PROizV36, "SPR_PRINTER")
    End Sub

    Private Sub cmbKeyb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKeyb.SelectedIndexChanged
        ExLoadParTwo(cmbKeyb.Text, PROizV30, "SPR_KEYBOARD")
    End Sub

    Private Sub cmbMouse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMouse.SelectedIndexChanged
        ExLoadParTwo(cmbMouse.Text, PROizV31, "SPR_MOUSE")
    End Sub

    Private Sub cmbAsist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAsist.SelectedIndexChanged
        ExLoadParTwo(cmbAsist.Text, PROizV32, "SPR_ASISTEM")
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged
        ExLoadParTwo(cmbFilter.Text, PROizV33, "SPR_FS")
    End Sub

    Private Sub cmbIBP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIBP.SelectedIndexChanged
        ExLoadParTwo(cmbIBP.Text, PROizV43, "SPR_IBP")
    End Sub

    Private Sub cmbNETBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo err_

        BrainchLoad(cmbNETBranch, cmbNetDepart)

        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub cmbNetDepart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo err_

        DepartmentLoad(cmbNETBranch, cmbNetDepart, cmbNETOffice)


        Exit Sub
err_:
    End Sub

    Private Sub cmbDevNet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDevNet.SelectedIndexChanged
        Dim unI As Long
        Dim uname As String
        unI = 0

        Dim PROYZV As ADODB.Recordset
        PROYZV = New ADODB.Recordset
        PROYZV.Open("SELECT * FROM SPR_PROIZV", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim SPR_DEV As ADODB.Recordset
        SPR_DEV = New ADODB.Recordset
        SPR_DEV.Open("SELECT * FROM SPR_DEV_NET where name ='" & cmbDevNet.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        On Error GoTo Error_

        With SPR_DEV
            .MoveFirst()
            Do While Not .EOF


                If Not IsDBNull(.Fields("proizv").Value) Then unI = .Fields("proizv").Value

                With PROYZV
                    .MoveFirst()
                    Do While Not .EOF
                        If unI = .Fields("ID").Value Then
                            uname = .Fields("proizv").Value
                        Else
                            'PROizV(0).Text = ""
                        End If
                        .MoveNext()
                        'DoEvents
                    Loop
                End With

                PROiZV40.Text = uname
                If Not IsDBNull(.Fields("A").Value) Then cmbNetDev.Text = .Fields("A").Value
                If Not IsDBNull(.Fields("B").Value) Then txtNetPort.Text = .Fields("B").Value

                .MoveNext()
                'DoEvents
            Loop

        End With
        PROYZV.Close()
        SPR_DEV.Close()
        PROYZV = Nothing
        SPR_DEV = Nothing

        Exit Sub
Error_:
    End Sub

    Private Sub cmbPRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPRN.SelectedIndexChanged
        Dim sSQL As String
        cmbTIPCartridg.Text = ""
        Select Case TipTehn

            Case "Printer"
                sSQL = "SELECT * FROM SPR_PRINTER WHERE Name = '" & cmbPRN.Text & "'"

            Case "MFU"
                sSQL = "SELECT * FROM SPR_MFU WHERE Name = '" & cmbPRN.Text & "'"

            Case "KOpir"
                sSQL = "SELECT * FROM SPR_KOPIR WHERE Name = '" & cmbPRN.Text & "'"

        End Select


        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim uNI As String
        rs = New ADODB.Recordset

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("proizv").Value) Then uNI = .Fields("proizv").Value

            Dim PROYZV As ADODB.Recordset
            PROYZV = New ADODB.Recordset
            PROYZV.Open("SELECT * FROM SPR_PROIZV WHERE iD=" & uNI, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With PROYZV
                PROiZV38.Text = .Fields("proizv").Value
            End With
            PROYZV.Close()
            PROYZV = Nothing

            If Not IsDBNull(.Fields("A").Value) Then cmbFormat.Text = .Fields("A").Value
            If Not IsDBNull(.Fields("B").Value) Then cmbModCartr.Text = .Fields("B").Value
        End With

        rs.Close()
        rs = Nothing
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSist.CheckedChanged

        'Call SaveActivityToLogDB("Изменение типа гарантии для " & Me.lstGroups.SelectedNode.Text)

        gbSeller.Visible = True

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbKompl.CheckedChanged
        gbSeller.Visible = False
        'Call SaveActivityToLogDB("Изменение типа гарантии для " & Me.lstGroups.SelectedNode.Text)
    End Sub

    Private Sub btnNetPortAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNetPortAdd.Click
        If portEDT = True Then
            NET_PORT_ED(npCOUNT)
        Else
            NET_PORT_ED()
        End If
    End Sub

    Private Sub lvNetPort_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvNetPort.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lvNetPort.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvNetPort.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvNetPort.Sort()
    End Sub

    Private Sub lvNetPort_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNetPort.DoubleClick
        If lvNetPort.Items.Count = 0 Then Exit Sub

        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("SELECT count(*) as t_n FROM TBL_NET_MAG WHERE COMMUTATOR=" & sCOUNT, DB7, ADODB.CursorTypeEnum.adOpenKeyset)

        Dim UCount As Integer

        With rs1
            UCount = .Fields("t_n").Value
        End With
        rs1.Close()
        rs1 = Nothing


        If UCount > 0 Then

            If uLevel <> "Admin" Then Exit Sub

            frmNetMagazin.sBDO_SVT_Pref = "PC"

            Dim z As Integer
            Dim z1 As Integer
            Dim LNGIniFile As New IniFile(sLANGPATH)



            For z = 0 To lvNetPort.SelectedItems.Count - 1
                frmNetMag_Add.sID = (lvNetPort.SelectedItems(z).Text)
            Next

            Dim sSQL As String

            frmNetMag_Add.sEDT = True

            frmNetMagazin.sBDO_Pref = ""
            frmNetMagazin.sBDO_count = 0
            frmNetMagazin.sBDO_SVT_count = 0
            frmNetMagazin.sBDO_NET_count = 0


            sSQL = "SELECT * FROM TBL_NET_MAG where id=" & frmNetMag_Add.sID

            Dim rs As ADODB.Recordset
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


            With rs

                frmNetMag_Add.txtLineRoz.Text = .Fields("id_line").Value
                frmNetMag_Add.cmbTipCab.Text = .Fields("tip_cab").Value
                frmNetMag_Add.txtDlina.Text = .Fields("dlin_cab").Value
                frmNetMag_Add.cmbTipKabLine.Text = .Fields("tip_cab_line").Value

                z1 = .Fields("SVT").Value
                frmNetMagazin.sBDO_SVT_count = z1


                If z1 = 0 Or Len(z1) = 0 Then

                    frmNetMag_Add.txtSVT.Text = ""
                    frmNetMag_Add.txtKom.Text = ""

                Else


                    Dim sTXT As String

                    rs1 = New ADODB.Recordset
                    rs1.Open("SELECT * FROM kompy where id=" & z1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


                    With rs1

                        Select Case .Fields("tiptehn").Value

                            Case "PC"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG11", "")
                            Case "Printer"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG6", "")
                            Case "KOpir"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG13", "")
                            Case "MONITOR"
                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG3", "")
                            Case "SCANER"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG8", "")
                            Case "NET"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG14", "")
                            Case "PHOTO"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG15", "")

                            Case "OT"

                                sTXT = .Fields("NET_NAME").Value & " " & .Fields("TIP_COMPA").Value
                            Case "ZIP"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG18", "")
                            Case "PHONE"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG16", "")
                            Case "MFU"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG7", "")
                            Case "FAX"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG17", "")

                            Case "USB"


                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG10", "")
                            Case "IBP"


                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG9", "")
                            Case "FS"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG5", "")

                            Case "SOUND"

                                sTXT = LNGIniFile.GetString("frmNetMagazin", "MSG4", "")


                        End Select


                        Select Case frmNetMagazin.sBDO_SVT_Pref

                            Case "PC"

                                frmNetMag_Add.txtSVT.Text = sTXT & ": " & .Fields("NET_NAME").Value & " , (" & LNGIniFile.GetString("frmNetMagazin", "MSG19", "") & " " & .Fields("OTvetstvennyj").Value & ")"
                                'Me.sBDO_SVT_count = .Fields("SVT").Value
                            Case Else

                                frmNetMag_Add.txtKom.Text = sTXT & ": " & .Fields("NET_NAME").Value & " , (" & LNGIniFile.GetString("frmNetMagazin", "MSG19", "") & " " & .Fields("OTvetstvennyj").Value & ")"

                        End Select

                    End With

                    rs1.Close()
                    rs1 = Nothing

                End If




                frmNetMag_Add.txtNetPortSVT.Text = .Fields("NET_PORT_SVT").Value
                frmNetMag_Add.cmbPhone.Text = .Fields("PHONE").Value
                frmNetMag_Add.txtSVT_MEMO.Text = .Fields("SVT_MEMO").Value

                z1 = .Fields("COMMUTATOR").Value

                frmNetMagazin.sBDO_NET_count = z1

                If z1 = 0 Or Len(z1) = 0 Then

                    frmNetMag_Add.txtKom.Text = ""

                Else


                    rs1 = New ADODB.Recordset
                    rs1.Open("SELECT * FROM kompy where id=" & z1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs1

                        frmNetMag_Add.txtKom.Text = LNGIniFile.GetString("frmNetMagazin", "MSG14", "") & ": " & .Fields("NET_NAME").Value & " , (" & LNGIniFile.GetString("frmNetMagazin", "MSG19", "") & " " & .Fields("OTvetstvennyj").Value & ")"

                    End With
                    rs1.Close()
                    rs1 = Nothing

                End If

                frmNetMag_Add.txtPortCom.Text = .Fields("NET_PORT_COMMUTATOR").Value
                frmNetMag_Add.txtComMemo.Text = .Fields("COMMUTATOR_MEMO").Value



                frmNetMagazin.sBDO_Pref = .Fields("PREF").Value
                frmNetMagazin.sBDO_count = .Fields("sID").Value

            End With
            rs.Close()
            rs = Nothing

            frmNetMag_Add.ShowDialog(Me)


        Else


            portEDT = True

            Dim z As Integer
            For z = 0 To lvNetPort.SelectedItems.Count - 1
                npCOUNT = (lvNetPort.SelectedItems(z).Text)
            Next
            Dim rs As ADODB.Recordset
            rs = New ADODB.Recordset
            Dim sSQL As String
            sSQL = "SELECT * FROM net_port WHERE id=" & npCOUNT
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                txtNetnumberPort.Text = .Fields("port").Value
                txtNetPortMapping.Text = .Fields("net_n").Value
                txtNetPortMac.Text = .Fields("mac").Value

            End With
            rs.Close()
            rs = Nothing


        End If





    End Sub

    Private Sub cmbModCartr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModCartr.SelectedIndexChanged
        Call Tip_Model_CARTR()
    End Sub


    Public Sub Tip_Model_CARTR()
        Dim sSQL As String
        cmbTIPCartridg.Text = ""

        sSQL = "SELECT * FROM spr_cart WHERE Name = '" & cmbModCartr.Text & "'"


        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim uNI As String
        rs = New ADODB.Recordset


        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            If Not IsDBNull(.Fields("A").Value) Then cmbTIPCartridg.Text = .Fields("A").Value
        End With

        rs.Close()
        rs = Nothing
    End Sub

    Private Sub btnUserCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserCancel.Click


        Dim langfile As New IniFile(sLANGPATH)


        Me.cmdUserAdd.Text = langfile.GetString("frmComputers", "MSG30", "")

        Me.txtUserName.Text = ""
        Me.txtUserPass.Text = ""
        Me.txtUserEmail.Text = ""
        Me.txtUserEmailPwd.Text = ""
        Me.txtUserFIO.Text = ""
        Me.txtUserIcq.Text = ""
        Me.txtUMEMO.Text = ""

    End Sub

    Private Sub lvMovement_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMovement.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
         lvMovement.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvMovement.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvMovement.Sort()
    End Sub

    Private Sub lvMovement_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvMovement.MouseUp

        If lvMovement.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmDvig.Show(CType(sender, Control), e.Location)


        Else

        End If


    End Sub

    Private Sub lvMovement_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMovement.SelectedIndexChanged

        If lvMovement.Items.Count = 0 Then Exit Sub
        Dim z As Integer

        For z = 0 To lvMovement.SelectedItems.Count - 1
            dvCOUNT = (lvMovement.SelectedItems(z).Text)
        Next


    End Sub

    Private Sub lvMovementPRN_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMovementPRN.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
 lvMovementPRN.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvMovementPRN.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvMovementPRN.Sort()
    End Sub


    Private Sub lvMovementPRN_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvMovementPRN.MouseUp

        If lvMovementPRN.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmDvig.Show(CType(sender, Control), e.Location)


        Else

        End If


    End Sub

    Private Sub lvMovementPRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMovementPRN.SelectedIndexChanged

        If lvMovementPRN.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvMovementPRN.SelectedItems.Count - 1
            dvCOUNT = (lvMovementPRN.SelectedItems(z).Text)
        Next


    End Sub


    Private Sub DELTEdVIGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELTEdVIGToolStripMenuItem.Click

        Dim dvig As ADODB.Recordset
        dvig = New ADODB.Recordset

        dvig.Open("DELETE FROM dvig WHERE Id=" & dvCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        dvig = Nothing


        Select Case TipTehn

            Case "PC"

                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovement)

            Case "NET"

                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementNET)


            Case "Printer"
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementPRN)
                'lvMovementPRN
            Case "MFU"
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementPRN)
            Case "KOpir"
                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementPRN)
            Case Else

                Call LOAD_DVIG_TEHN(sCOUNT, Me.lvMovementOTH)

        End Select







    End Sub

    Private Sub lvMovementNET_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMovementNET.ColumnClick

        Dim new_sorting_column As ColumnHeader = lvMovementNET.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvMovementNET.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvMovementNET.Sort()
    End Sub

    Private Sub lvMovementNET_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvMovementNET.MouseUp


        If lvMovementNET.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmDvig.Show(CType(sender, Control), e.Location)


        Else

        End If


    End Sub

    Private Sub lvMovementNET_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMovementNET.SelectedIndexChanged

        If lvMovementNET.Items.Count = 0 Then Exit Sub
        Dim z As Integer

        For z = 0 To lvMovementNET.SelectedItems.Count - 1
            dvCOUNT = (lvMovementNET.SelectedItems(z).Text)
        Next


    End Sub

    Private Sub lvMovementOTH_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMovementOTH.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
lvMovementOTH.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvMovementOTH.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvMovementOTH.Sort()
    End Sub

    Private Sub lvMovementOTH_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvMovementOTH.MouseUp


        If lvMovementOTH.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmDvig.Show(CType(sender, Control), e.Location)


        Else

        End If


    End Sub

    Private Sub lvMovementOTH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMovementOTH.SelectedIndexChanged

        If lvMovementOTH.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvMovementOTH.SelectedItems.Count - 1
            dvCOUNT = (lvMovementOTH.SelectedItems(z).Text)
        Next


    End Sub


    Private Sub lstGroups_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles lstGroups.NodeMouseClick

        '#############################################
        'Выделение по правому клику мышкой
        '#############################################

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.lstGroups.SelectedNode = e.Node
        End If

    End Sub

    Private Sub MassRazdelPerf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MassRazdelPerf.Click

        Dim sSQL As String
        Dim zCtn As String

        Call selectTECMesto()
        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")




        Select Case d(0)

            Case "G"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and TipTehn='PC'"


            Case "O"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' and TipTehn='PC'"


            Case "K"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' AND kabn ='" & sOffice & "' and TipTehn='PC'"


        End Select

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            zCtn = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If zCtn = 0 Then Exit Sub

        Select Case d(0)

            Case "G"

                sSQL = "SELECT * FROM kompy where filial ='" & sBranch & "' and tiptehn='PC'"


            Case "O"

                sSQL = "SELECT * FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' and tiptehn='PC'"


            Case "K"

                sSQL = "SELECT id FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' AND kabn ='" & sOffice & "' and tiptehn='PC'"


        End Select


        rs = New ADODB.Recordset

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intj As Integer = 1
        MRZD = True
        With rs
            .MoveFirst()
            Do While Not .EOF

                Re_PRN(.Fields("id").Value)

                If zCtn = intj Then
                    MRZD = False

                    Dim newThread1 As New Thread(AddressOf STAT_INF_1)
                    newThread1.Start()

                End If

                intj = intj + 1

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing



    End Sub

    Private Sub treebranche_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles treebranche.SelectedValueChanged
     
    End Sub

    Private Sub txtUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.SelectedIndexChanged

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        rs.Open("Select A from SPR_USER where name='" & txtUserName.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            txtUserFIO.Text = .Fields("A").Value
        End With
        rs.Close()
        rs = Nothing



    End Sub

    Private Sub txtUserFIO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserFIO.SelectedIndexChanged
        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        rs.Open("Select Name from SPR_USER where A='" & txtUserFIO.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            txtUserName.Text = .Fields("Name").Value
        End With
        rs.Close()
        rs = Nothing

    End Sub

    Private Sub MassUpdatetoINI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MassUpdatetoINI.Click

        Dim DirectoryBrowser As New FolderBrowserDialog
        Dim sTXTDIR As String


        Dim objIniFile As New IniFile(PrPath & "base.ini")
        sTXTDIR = objIniFile.GetString("General", "aida", "d:\")

        With DirectoryBrowser
            ' Desktop is the root folder in the dialog.

            .RootFolder = Environment.SpecialFolder.Desktop


            If Len(sTXTDIR) = 0 Then
                ' Select the C:\Windows directory on entry.
                .SelectedPath = "c:\windows"
            Else
                .SelectedPath = sTXTDIR
            End If

            ' Prompt the user with a custom message.
            .Description = "Select the source directory"

            If .ShowDialog = DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                ' Display the selected folder if the user clicked on the OK button.
                sTXTDIR = .SelectedPath

                sTXTDIR = sTXTDIR & "\"

                Try
                    ' Only get files that begin with the letter "c."
                    Dim dirs As String() = Directory.GetFiles(sTXTDIR, "*.ini")
                    ' Console.WriteLine("The number of files starting with c is {0}.", dirs.Length)
                    Dim dir As String

                    For Each dir In dirs
                        Dim d() As String
                        d = Split(dir, "\")

                        EverestFilePatch = sTXTDIR & d(d.Length - 1)

                        Call selectTECMesto()
                        Me.MASSLOAD = True

                        FINDtoUPDATEM(EverestFilePatch)



                    Next
                Catch e1 As Exception
                    MsgBox(Err.Description)
                End Try



            End If

        End With

        Me.MASSLOAD = False

        Me.Cursor = Cursors.Default


        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub FINDtoUPDATEM(ByVal sstring As String)
        Dim everIniFile As New IniFile(sstring)
        Dim A1 As String


        A1 = everIniFile.GetString("Имя компьютера", "Имя NetBIOS|Имя компьютера", "")
        If Len(A1) = 0 Then A1 = everIniFile.GetString("Суммарная информация", "Компьютер|Имя компьютера", "NoName")


        Call massUpdate(sstring, A1)



    End Sub

    Private Sub massUpdate(ByVal EverPath As String, ByVal KNAME As String)

        Dim sSQL As String
        Dim zCtn As String

        Me.sSTAB2.Visible = False
        Me.sSTAB1.Visible = True
        Me.sSTAB3.Visible = False
        Me.sSTAB4.Visible = False
        Me.sSTAB5.Visible = False
        Call Clear_Form_For_Computer()



        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")


        Select Case d(0)

            Case "G"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and TipTehn='PC' and net_name='" & KNAME & "'"


            Case "O"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' and TipTehn='PC' and net_name='" & KNAME & "'"


            Case "K"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' AND kabn ='" & sOffice & "' and TipTehn='PC' and net_name='" & KNAME & "'"


        End Select

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            zCtn = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If zCtn = 0 Then Exit Sub

        Select Case d(0)

            Case "G"

                sSQL = "SELECT id FROM kompy where filial ='" & sBranch & "' and tiptehn='PC' and net_name='" & KNAME & "'"


            Case "O"

                sSQL = "SELECT id FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' and tiptehn='PC' and net_name='" & KNAME & "'"


            Case "K"

                sSQL = "SELECT id FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' AND kabn ='" & sOffice & "' and tiptehn='PC' and net_name='" & KNAME & "'"


        End Select


        rs = New ADODB.Recordset

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intj As Integer = 1
        MRZD = True
        With rs

            sCOUNT = .Fields("id").Value
            TipTehn = "PC"
            Me.EDT = True
            LOADt(.Fields("id").Value)
            Application.DoEvents()
        End With

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("general", "DK", sCOUNT)
        objIniFile.WriteString("general", "Default", 0)

        EverestFilePatch = EverPath
        EVEREST_UPDATE()
        Application.DoEvents()

        Save_T(sCOUNT)

        rs.Close()
        rs = Nothing
    End Sub

    Private Sub DeleteService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteService.Click



        Dim langfile As New IniFile(sLANGPATH)


        If MsgBox(langfile.GetString("frmserviceDesc", "MSG9 ", ""), MsgBoxStyle.YesNo, ProGramName) = MsgBoxResult.Yes Then

            DELETE_SERVICE(lvServices)

        Else

        End If



    End Sub

    Private Sub DELETE_SERVICE(ByVal lvList As ListView)
        If lvList.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvList.SelectedItems.Count - 1
            rCOUNT = (lvList.SelectedItems(z).Text)
        Next

        If rCOUNT = 0 Then Exit Sub

        Dim unamZ As String

        If Me.sPREF = "C" Then

            Dim rs2 As ADODB.Recordset
            rs2 = New ADODB.Recordset
            rs2.Open("SELECT * FROM kompy WHERE id=" & Me.sCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs2
                unamZ = .Fields("filial").Value & "/" & .Fields("mesto").Value
            End With
            rs2.Close()
            rs2 = Nothing

        End If

        Dim LNGIniFile As New IniFile(sLANGPATH)
        Dim rs1 As ADODB.Recordset

        rs1 = New ADODB.Recordset

        rs1.Open("Delete FROM remonty_plus WHERE id_rem=" & rCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        rs1 = Nothing

        rs1 = New ADODB.Recordset

        rs1.Open("Delete FROM Remont WHERE id=" & rCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        rs1 = Nothing

        Call SaveActivityToLogDB(LNGIniFile.GetString("frmserviceDesc", "MSG7", "") & " " & lstGroups.SelectedNode.Text & " " & LNGIniFile.GetString("frmserviceDesc", "MSG8", "") & unamZ)

        Call LOAD_REPAIR(Me.sCOUNT, lvServices)
        Call REM_CHECK()

    End Sub

    Private Sub lvRepairNET_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRepairNET.MouseUp

        If lvRepairNET.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            CMServices.Show(CType(sender, Control), e.Location)
            lvServices = lvRepairNET
            Call MNU_SERVICES_BUTTON(lvServices)
        Else

        End If

    End Sub

    Private Sub lvRepairOTH_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRepairOTH.MouseUp
        If lvRepairOTH.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            CMServices.Show(CType(sender, Control), e.Location)
            lvServices = lvRepairOTH
            Call MNU_SERVICES_BUTTON(lvServices)
        Else

        End If
    End Sub

    Private Sub MNU_SERVICES_BUTTON(ByVal lvServices As ListView)
        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvServices.SelectedItems.Count - 1
            rCOUNT = (lvServices.SelectedItems(z).Text)
        Next

        If rCOUNT = 0 Then Exit Sub

        Dim unam As String
        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT zakryt FROM Remont WHERE id=" & rCOUNT
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            unam = .Fields("zakryt").Value
        End With
        rs.Close()
        rs = Nothing

        If unam = "1" Or unam = True Then

            mnu_z_rasp.Enabled = False
            MnuSendEmail.Enabled = False
            addServiseWork.Enabled = False
        Else
            mnu_z_rasp.Enabled = True
            MnuSendEmail.Enabled = True
            addServiseWork.Enabled = True
        End If
    End Sub

    Private Sub lvRepair_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRepair.MouseUp

        If lvRepair.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvRepair.SelectedItems.Count - 1
            rCOUNT = (lvRepair.SelectedItems(z).Text)
        Next
        If rCOUNT = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            CMServices.Show(CType(sender, Control), e.Location)
            lvServices = lvRepair
            Call MNU_SERVICES_BUTTON(lvServices)
        Else

        End If
    End Sub

    Private Sub lvRepairbr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRepairBR.MouseUp
        If lvRepairBR.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            CMServices.Show(CType(sender, Control), e.Location)
            lvServices = lvRepairBR
            Call MNU_SERVICES_BUTTON(lvServices)
        Else

        End If
    End Sub

    Private Sub lvRepairprn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRepairPRN.MouseUp
        If lvRepairPRN.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            CMServices.Show(CType(sender, Control), e.Location)
            lvServices = lvRepairPRN
            Call MNU_SERVICES_BUTTON(lvServices)
        Else

        End If
    End Sub



    Private Sub EditService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditService.Click

        LoadRepairEdit(lvServices)
    End Sub

    Private Sub Font_Form_For_Computer()

        SendFonts(Me)

    End Sub

    Private Sub bCPUPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCPUPlus.Click

        Select Case sCPU

            Case 1

                sCPU = sCPU + 1
                Me.cmbCPU2.Visible = True
                Me.txtMHZ2.Visible = True
                Me.txtSoc2.Visible = True
                Me.PROizV2.Visible = True

            Case 2

                sCPU = sCPU + 1
                Me.cmbCPU3.Visible = True
                Me.txtMHZ3.Visible = True
                Me.txtSoc3.Visible = True
                Me.PROizV3.Visible = True

            Case 3

                sCPU = sCPU + 1
                Me.cmbCPU4.Visible = True
                Me.txtMHZ4.Visible = True
                Me.txtSoc4.Visible = True
                Me.PROizV4.Visible = True
                Me.bCPUPlus.Visible = False
            Case Else

                sCPU = sCPU
        End Select





    End Sub


    Private Sub bRamPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bRamPlus.Click
        Select Case sRAM

            Case 1

                sRAM = sRAM + 1
                Me.cmbRAM2.Visible = True
                Me.txtRamSN2.Visible = True
                Me.txtRamS2.Visible = True
                Me.PROizV7.Visible = True
            Case 2

                sRAM = sRAM + 1
                Me.cmbRAM3.Visible = True
                Me.txtRamSN3.Visible = True
                Me.txtRamS3.Visible = True
                Me.PROizV8.Visible = True

            Case 3

                sRAM = sRAM + 1
                Me.cmbRAM4.Visible = True
                Me.txtRamSN4.Visible = True
                Me.txtRamS4.Visible = True
                Me.PROizV9.Visible = True
                Me.bRamPlus.Visible = False
            Case Else

                sRAM = sRAM
        End Select

    End Sub

    Private Sub bHddPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bHddPlus.Click
        Select Case sHDD

            Case 1

                sHDD = sHDD + 1
                Me.cmbHDD2.Visible = True
                Me.txtHDDo2.Visible = True
                Me.txtHDDsN2.Visible = True
                Me.PROizV11.Visible = True
            Case 2

                sHDD = sHDD + 1
                Me.cmbHDD3.Visible = True
                Me.txtHDDo3.Visible = True
                Me.txtHDDsN3.Visible = True
                Me.PROizV12.Visible = True

            Case 3

                sHDD = sHDD + 1
                Me.cmbHDD4.Visible = True
                Me.txtHDDo4.Visible = True
                Me.txtHDDsN4.Visible = True
                Me.PROizV13.Visible = True
                Me.bHddPlus.Visible = False
            Case Else

                sHDD = sHDD
        End Select



    End Sub

    Private Sub bSVGAPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSVGAPlus.Click

        Select Case sVGA

            Case 1

                sVGA = sVGA + 1
                Me.cmbSVGA2.Visible = True
                Me.txtSVGAr2.Visible = True
                Me.txtSVGAs2.Visible = True
                Me.PROizV15.Visible = True

                Me.bSVGAPlus.Visible = False
            Case Else

                sVGA = sVGA
        End Select
    End Sub

    Private Sub bOpticalPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bOpticalPlus.Click
        Select Case sOPTICAL

            Case 1

                sOPTICAL = sOPTICAL + 1
                Me.cmbOPTIC2.Visible = True
                Me.txtOPTICs2.Visible = True
                Me.txtOPTICsn2.Visible = True
                Me.PROizV18.Visible = True
            Case 2

                sOPTICAL = sOPTICAL + 1
                Me.cmbOPTIC3.Visible = True
                Me.txtOPTICs3.Visible = True
                Me.txtOPTICsn3.Visible = True
                Me.PROizV19.Visible = True
                Me.bOpticalPlus.Visible = False
            Case Else

                sOPTICAL = sOPTICAL
        End Select
    End Sub

    Private Sub bNETPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNETPlus.Click


        Select Case sNET

            Case 1

                sNET = sNET + 1
                Me.cmbNET2.Visible = True
                Me.txtNETip2.Visible = True
                Me.txtNETmac2.Visible = True
                Me.PROizV21.Visible = True
                Me.bNETPlus.Visible = False
            Case Else

                sNET = sNET
        End Select

    End Sub

    Private Sub bMonitorPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMonitorPlus.Click
        Select Case sMonitor

            Case 1

                sMonitor = sMonitor + 1
                Me.cmbMon2.Visible = True
                Me.txtMon2Dum.Visible = True
                Me.txtMon2SN.Visible = True
                Me.PROizV29.Visible = True
                Me.bMonitorPlus.Visible = False
            Case Else

                sMonitor = sMonitor
        End Select
    End Sub

    Private Sub bPrinterPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPrinterPlus.Click
        Select Case sPrinter

            Case 1

                sPrinter = sPrinter + 1
                Me.cmbPrinters2.Visible = True
                Me.txtPrint2SN.Visible = True
                Me.txtPrint2Port.Visible = True
                Me.PROizV35.Visible = True

            Case 2

                sPrinter = sPrinter + 1
                Me.cmbPrinters3.Visible = True
                Me.txtPrint3SN.Visible = True
                Me.txtPrint3Port.Visible = True
                Me.PROizV36.Visible = True
                Me.bPrinterPlus.Visible = False
            Case Else

                sPrinter = sPrinter
        End Select
    End Sub


    Private Sub ВернутьПерефериюToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ВернутьПерефериюToolStripMenuItem.Click

        Call under_prn()


    End Sub

    Private Sub ПрисоеденитьПерефериюToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MassObedPerf.Click
        Dim sSQL As String
        Dim zCtn As String

        Call selectTECMesto()
        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")




        Select Case d(0)

            Case "G"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and TipTehn='PC'"


            Case "O"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' and TipTehn='PC'"


            Case "K"

                sSQL = "SELECT count(*) as t_n FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' AND kabn ='" & sOffice & "' and TipTehn='PC'"


        End Select

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            zCtn = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If zCtn = 0 Then Exit Sub

        Select Case d(0)

            Case "G"

                sSQL = "SELECT * FROM kompy where filial ='" & sBranch & "' and tiptehn='PC'"


            Case "O"

                sSQL = "SELECT * FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' and tiptehn='PC'"


            Case "K"

                sSQL = "SELECT id FROM kompy where filial ='" & sBranch & "' and mesto='" & sDepartment & "' AND kabn ='" & sOffice & "' and tiptehn='PC'"


        End Select


        rs = New ADODB.Recordset

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intj As Integer = 1
        MRZD = True
        With rs
            .MoveFirst()
            Do While Not .EOF

                under_prn(.Fields("id").Value)


                If zCtn = intj Then
                    MRZD = False
                    'Call R_T_LOAD()
                End If

                intj = intj + 1

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        Dim newThread5 As New Thread(AddressOf R_T_LOAD)
        newThread5.Start()

        Dim newThread1 As New Thread(AddressOf STAT_INF_1)
        newThread1.Start()

    End Sub

    Private Sub MnuSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSendEmail.Click
        If lvServices.Items.Count = 0 Then Exit Sub
        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvServices.SelectedItems.Count - 1
            rCOUNT = (lvServices.SelectedItems(z).Text)
        Next

        If rCOUNT = 0 Then Exit Sub
        Call REMONT_SEND_MASTER(rCOUNT)

    End Sub

    Private Sub mnu_z_rasp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_z_rasp.Click

        If lvServices.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer


        For z = 0 To lvServices.SelectedItems.Count - 1
            rCOUNT = (lvServices.SelectedItems(z).Text)
        Next

        If rCOUNT = 0 Then Exit Sub

        Call SRASP(rCOUNT)
    End Sub

    Private Sub mnu_Z_to_Office_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Z_to_Office.Click
        If lvServices.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvServices.SelectedItems.Count - 1
            rCOUNT = (lvServices.SelectedItems(z).Text)
        Next

        If rCOUNT = 0 Then Exit Sub

        Call SRASP2(rCOUNT)

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub addServiseWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addServiseWork.Click
        On Error GoTo err_1
        frmservice_add_otvets.REMFU = True

        If lvRepair.Items.Count = 0 Then Exit Sub


        Dim rCOUNT As Integer

        For z = 0 To lvServices.SelectedItems.Count - 1
            rCOUNT = (lvServices.SelectedItems(z).Text)
        Next

        If rCOUNT = 0 Then Exit Sub

        frmserviceDesc.ZaiavkR = False

        frmserviceDesc.r1COUNT = rCOUNT

        Dim d() As String

        d = Split(lstGroups.SelectedNode.Tag, "|")
        Me.sPREF = d(0)
        Me.sCOUNT = d(1)

        If Len(Me.sCOUNT) = 0 Then Exit Sub


        frmservice_add_otvets.cmbMaster.Text = ""
        frmservice_add_otvets.txtOtzyv.Text = ""
        frmservice_add_otvets.cmbMaster.Text = ""
        frmservice_add_otvets.dtPic.Value = Date.Today
        frmservice_add_otvets.cmbStat.Text = ""
        frmservice_add_otvets.cmbOtv.Text = ""
        frmservice_add_otvets.cmbKrit.Text = ""
        frmservice_add_otvets.cmbMaster.Text = ""
        frmservice_add_otvets.cmbTip.Text = "Base"


        frmservice_add_otvets.ShowDialog(Me)

        Exit Sub
err_1:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub lvRepair_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRepair.SelectedIndexChanged

    End Sub
End Class

