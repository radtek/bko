'Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Threading

Module MOD_INF_TECH_LOAD
    Private zID As String


    Public Sub LOADnet(ByVal sID As String)
        On Error Resume Next
        Dim unaPCL As String

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM kompy WHERE id =" & sID
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            frmComputers.lblSidNET.Text = .Fields("id").Value
            If Not IsDBNull(.Fields("PRINTER_NAME_1").Value) Then frmComputers.cmbNetDev.Text = .Fields("PRINTER_NAME_1").Value
            If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then frmComputers.cmbDevNet.Text = .Fields("PRINTER_SN_1").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_1").Value) Then frmComputers.PROiZV40.Text = .Fields("PRINTER_PROIZV_1").Value

            If Not IsDBNull(.Fields("PRINTER_NAME_2").Value) Then frmComputers.txtNetIP.Text = .Fields("PRINTER_NAME_2").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_2").Value) Then frmComputers.txtNetMac.Text = .Fields("PRINTER_PROIZV_2").Value
            If Not IsDBNull(.Fields("PRINTER_SN_2").Value) Then frmComputers.txtNetPort.Text = .Fields("PRINTER_SN_2").Value

            If Not IsDBNull(.Fields("PRINTER_PROIZV_3").Value) Then frmComputers.txtNetINN.Text = .Fields("PRINTER_PROIZV_3").Value
            If Not IsDBNull(.Fields("PRINTER_SN_3").Value) Then frmComputers.txtNetIsp.Text = .Fields("PRINTER_SN_3").Value

            If Not IsDBNull(.Fields("PRINTER_NAME_4").Value) Then frmComputers.cmbNetVkl.Text = .Fields("PRINTER_NAME_4").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_4").Value) Then frmComputers.cmbNetCable.Text = .Fields("PRINTER_PROIZV_4").Value
            If Not IsDBNull(.Fields("PRINTER_SN_4").Value) Then frmComputers.txtNetCableCat.Text = .Fields("PRINTER_SN_4").Value

            'If Not IsDBNull(.Fields("OTvetstvennyj").Value) Then frmComputers.txtNetNumberPorts.Text = .Fields("OTvetstvennyj").Value
            'If Not IsDBNull(.Fields("telephone").Value) Then frmComputers.cmbNETotv.Text = .Fields("telephone").Value


            If Not IsDBNull(.Fields("OTvetstvennyj").Value) Then frmComputers.cmbNETotv.Text = .Fields("OTvetstvennyj").Value
            If Not IsDBNull(.Fields("telephone").Value) Then frmComputers.txtNETphone.Text = .Fields("telephone").Value
            If Not IsDBNull(.Fields("port_2").Value) Then frmComputers.txtNetNumberPorts.Text = .Fields("port_2").Value


            If Not IsDBNull(.Fields("filial").Value) Then frmComputers.cmbNETBranch.Text = .Fields("filial").Value
            If Not IsDBNull(.Fields("mesto").Value) Then frmComputers.cmbNetDepart.Text = .Fields("mesto").Value
            If Not IsDBNull(.Fields("kabn").Value) Then frmComputers.cmbNETOffice.Text = .Fields("kabn").Value

            If Not IsDBNull(.Fields("SFAktNo").Value) Then frmComputers.txtNETSfN.Text = .Fields("SFAktNo").Value
            If Not IsDBNull(.Fields("CenaRub").Value) Then frmComputers.txtNETcash.Text = .Fields("CenaRub").Value
            If Not IsDBNull(.Fields("StoimRub").Value) Then frmComputers.txtNETSumm.Text = .Fields("StoimRub").Value
            If Not IsDBNull(.Fields("Zaiavk").Value) Then frmComputers.txtNETZay.Text = .Fields("Zaiavk").Value

            If Not IsDBNull(.Fields("DataVVoda").Value) Then frmComputers.dtNETdataVvoda.Value = .Fields("DataVVoda").Value
            If Not IsDBNull(.Fields("dataSF").Value) Then frmComputers.dtNETSFdate.Value = .Fields("dataSF").Value

            If Not IsDBNull(.Fields("Spisan").Value) Then frmComputers.chkNETspis.Checked = .Fields("Spisan").Value
            If Not IsDBNull(.Fields("Balans").Value) Then frmComputers.chkNETNNb.Checked = .Fields("Balans").Value

            'sBranch = .Fields("FILIAL").Value
            'sDepartment = .Fields("MESTO").Value
            'sOffice = .Fields("kabn").Value
            sName = frmComputers.cmbDevNet.Text

            If Not IsDBNull(.Fields("port_1").Value) Then frmComputers.txtNetSN.Text = .Fields("port_1").Value

            If Not IsDBNull(.Fields("PCL").Value) Then unaPCL = .Fields("PCL").Value

        End With

        rs.Close()
        rs = Nothing

        If Len(unaPCL) <> 0 Then

            rs = New ADODB.Recordset
            rs.Open("Select NET_NAME From kompy where id=" & unaPCL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                frmComputers.cmbCNTNet.Text = .Fields("NET_NAME").Value

            End With
            rs.Close()
            rs = Nothing
        End If


        '#############################################
        'Проверка есть ли контейнеры в справочнике
        '#############################################

        sSQL = "SELECT count(*) as t_n from spr_other where C='1'"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim A1 As String
        With rs
            A1 = .Fields("t_n").Value

        End With
        rs.Close()
        rs = Nothing

        Select Case A1
            Case 0
                frmComputers.cmbCNTNet.Visible = False
                frmComputers.lblPCLNET.Visible = False

            Case Else
                frmComputers.cmbCNTNet.Visible = True
                frmComputers.lblPCLNET.Visible = True

                Call LOAD_PCL(frmComputers.cmbNETBranch.Text, frmComputers.cmbNetDepart.Text, frmComputers.cmbNETOffice.Text, frmComputers.cmbCNTNet)
                'Call LOAD_PCL(frmComputers.cmbBranch.Text, frmComputers.cmbDepartment.Text, frmComputers.cmbOffice.Text, frmComputers.cmbPCLK)
        End Select

        '#############################################
        '#############################################
        '#############################################


        Call LOAD_GARs(sID, frmComputers.cmbNETPostav, frmComputers.dtGNETPr, frmComputers.dtGNETok)
        Call LOAD_NET_PORT(sID)
        Call LOAD_NOTES(sID, frmComputers.lvNotesNET)
        Call LOAD_REPAIR(sID, frmComputers.lvRepairNET)
        Call LOAD_DVIG_TEHN(sID, frmComputers.lvMovementNET)

    End Sub

    Public Sub LOAD_NET_PORT(ByVal sID As String)
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("SELECT count(*) as t_n FROM net_port WHERE id_net=" & sID, DB7, ADODB.CursorTypeEnum.adOpenKeyset)

        frmComputers.lvNetPort.Sorting = SortOrder.None
        frmComputers.lvNetPort.ListViewItemSorter = Nothing
        frmComputers.lvNetPort.Items.Clear()

        Dim UCount As Integer

        With rs1
            UCount = .Fields("t_n").Value
        End With
        rs1.Close()
        rs1 = Nothing


        If UCount > 0 Then

            rs1 = New ADODB.Recordset
            rs1.Open("SELECT * FROM net_port WHERE id_net=" & sID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            Dim intCount As Decimal = 0


            With rs1
                .MoveFirst()
                Do While Not .EOF


                    frmComputers.lvNetPort.Items.Add(.Fields("id").Value) 'col no. 1

                    If Not IsDBNull(.Fields("port").Value) Then
                        frmComputers.lvNetPort.Items(CInt(intCount)).SubItems.Add(.Fields("port").Value)
                    Else
                        frmComputers.lvNetPort.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("net_n").Value) Then
                        frmComputers.lvNetPort.Items(CInt(intCount)).SubItems.Add(.Fields("net_n").Value)
                    Else
                        frmComputers.lvNetPort.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("mac").Value) Then
                        frmComputers.lvNetPort.Items(CInt(intCount)).SubItems.Add(.Fields("mac").Value)
                    Else
                        frmComputers.lvNetPort.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    intCount = intCount + 1

                    .MoveNext()
                Loop
            End With
            rs1.Close()
            rs1 = Nothing

        Else

        End If

        ResList(frmComputers.lvNetPort)

    End Sub

    Public Sub LOADot(ByVal sID As String)
        On Error Resume Next
        Dim unaPCL As String

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM kompy WHERE id =" & sID
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            frmComputers.lblsIDOTH.Text = .Fields("id").Value

            If Not IsDBNull(.Fields("PRINTER_NAME_1").Value) Then frmComputers.cmbOTH.Text = .Fields("PRINTER_NAME_1").Value
            If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then frmComputers.txtOTHSN.Text = .Fields("PRINTER_SN_1").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_1").Value) Then frmComputers.PROiZV39.Text = .Fields("PRINTER_PROIZV_1").Value
            If Not IsDBNull(.Fields("port_1").Value) Then frmComputers.txtOTHmemo.Text = .Fields("port_1").Value
            If Not IsDBNull(.Fields("OTvetstvennyj").Value) Then frmComputers.cmbOTHotv.Text = .Fields("OTvetstvennyj").Value
            If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then frmComputers.txtOTHinnumber.Text = .Fields("INV_NO_PRINTER").Value

            If Not IsDBNull(.Fields("FILIAL").Value) Then frmComputers.cmbOTHFil.Text = .Fields("FILIAL").Value
            If Not IsDBNull(.Fields("MESTO").Value) Then frmComputers.cmbOTHDepart.Text = .Fields("MESTO").Value
            If Not IsDBNull(.Fields("kabn").Value) Then frmComputers.cmbOTHOffice.Text = .Fields("kabn").Value

            sName = .Fields("PRINTER_NAME_1").Value

            If Not IsDBNull(.Fields("NET_IP_1").Value) Then frmComputers.txtOTHIP.Text = .Fields("NET_IP_1").Value
            If Not IsDBNull(.Fields("NET_MAC_1").Value) Then frmComputers.txtOTHMAC.Text = .Fields("NET_MAC_1").Value
            If Not IsDBNull(.Fields("TIP_COMPA").Value) Then frmComputers.cmbOTHConnect.Text = .Fields("TIP_COMPA").Value

            frmComputers.txtOTHphone.Text = .Fields("TELEPHONE").Value


            If Not IsDBNull(.Fields("SFAktNo").Value) Then frmComputers.txtOTHSfN.Text = .Fields("SFAktNo").Value
            If Not IsDBNull(.Fields("CenaRub").Value) Then frmComputers.txtOTHcash.Text = .Fields("CenaRub").Value
            If Not IsDBNull(.Fields("StoimRub").Value) Then frmComputers.txtOTHSumm.Text = .Fields("StoimRub").Value
            If Not IsDBNull(.Fields("Zaiavk").Value) Then frmComputers.txtOTHZay.Text = .Fields("Zaiavk").Value

            If Not IsDBNull(.Fields("DataVVoda").Value) Then frmComputers.dtOTHdataVvoda.Value = .Fields("DataVVoda").Value
            If Not IsDBNull(.Fields("dataSF").Value) Then frmComputers.dtOTHSFdate.Value = .Fields("dataSF").Value

            If Not IsDBNull(.Fields("Spisan").Value) Then frmComputers.chkOTHspis.Checked = .Fields("Spisan").Value
            If Not IsDBNull(.Fields("Balans").Value) Then frmComputers.chkOTHNNb.Checked = .Fields("Balans").Value
            If Not IsDBNull(.Fields("PCL").Value) Then unaPCL = .Fields("PCL").Value

        End With

        rs.Close()
        rs = Nothing

        If Len(unaPCL) <> 0 Then

            rs = New ADODB.Recordset
            rs.Open("Select NET_NAME From kompy where id=" & unaPCL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                frmComputers.cmbOTHPCL.Text = .Fields("NET_NAME").Value

            End With
            rs.Close()
            rs = Nothing
        End If



        Call LOAD_GARs(sID, frmComputers.cmbOTHPostav, frmComputers.dtGOTHPr, frmComputers.dtGOTHok)
        'Call LOAD_NOTES(sID, frmComputers.lvNotesOTH)
        'Call LOAD_REPAIR(sID, frmComputers.lvRepairOTH)
        'Call LOAD_DVIG_TEHN(sID, frmComputers.lvMovementOTH)

    End Sub

    Public Sub LOADp(ByVal sID As String)
        On Error Resume Next

        Dim kol As Long
        Dim uname As String
        Dim rs1 As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL1 As String 'Переменная, где будет размещён SQL запрос
        Dim unaPCL As String

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM kompy WHERE id =" & sID
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            frmComputers.lblSidPRN.Text = .Fields("id").Value
            If Not IsDBNull(.Fields("PRINTER_NAME_1")) Then frmComputers.cmbPRN.Text = .Fields("PRINTER_NAME_1").Value
            If Not IsDBNull(.Fields("os")) Then frmComputers.cmbModCartr.Text = .Fields("os").Value

            If Len(frmComputers.cmbModCartr.Text) <> 0 Then
                Call frmComputers.Tip_Model_CARTR()
            End If

            If Not IsDBNull(.Fields("PRINTER_SN_1")) Then frmComputers.txtPRNSN.Text = .Fields("PRINTER_SN_1").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_1")) Then frmComputers.PROiZV38.Text = .Fields("PRINTER_PROIZV_1").Value
            If Not IsDBNull(.Fields("INV_NO_PRINTER")) Then frmComputers.txtPRNinnumber.Text = .Fields("INV_NO_PRINTER").Value
            If Not IsDBNull(.Fields("port_1")) Then frmComputers.cmbFormat.Text = .Fields("port_1").Value

            If Not IsDBNull(.Fields("FILIAL")) Then frmComputers.cmbPRNFil.Text = .Fields("FILIAL").Value
            If Not IsDBNull(.Fields("mesto")) Then frmComputers.cmbPRNDepart.Text = .Fields("mesto").Value
            If Not IsDBNull(.Fields("kabn")) Then frmComputers.cmbPRNOffice.Text = .Fields("kabn").Value

            If Not IsDBNull(.Fields("OTvetstvennyj")) Then frmComputers.cmbPRNotv.Text = .Fields("OTvetstvennyj").Value
            If Not IsDBNull(.Fields("TELEPHONE")) Then frmComputers.txtPRNphone.Text = .Fields("TELEPHONE").Value
            If Not IsDBNull(.Fields("NET_IP_1")) Then frmComputers.txtPrnIP.Text = .Fields("NET_IP_1").Value
            If Not IsDBNull(.Fields("NET_MAC_1")) Then frmComputers.txtPRNMAC.Text = .Fields("NET_MAC_1").Value

            If Not IsDBNull(.Fields("SFAktNo").Value) Then frmComputers.txtPRNSfN.Text = .Fields("SFAktNo").Value
            If Not IsDBNull(.Fields("CenaRub").Value) Then frmComputers.txtPRNcash.Text = .Fields("CenaRub").Value
            If Not IsDBNull(.Fields("StoimRub").Value) Then frmComputers.txtPRNSumm.Text = .Fields("StoimRub").Value
            If Not IsDBNull(.Fields("Zaiavk").Value) Then frmComputers.txtPRNZay.Text = .Fields("Zaiavk").Value

            If Not IsDBNull(.Fields("DataVVoda").Value) Then frmComputers.dtPRNdataVvoda.Value = .Fields("DataVVoda").Value
            If Not IsDBNull(.Fields("dataSF").Value) Then frmComputers.dtPRNSFdate.Value = .Fields("dataSF").Value

            If Not IsDBNull(.Fields("Spisan").Value) Then frmComputers.chkPRNspis.Checked = .Fields("Spisan").Value
            If Not IsDBNull(.Fields("Balans").Value) Then frmComputers.chkPRNNNb.Checked = .Fields("Balans").Value

            If Not IsDBNull(.Fields("PCL").Value) Then unaPCL = .Fields("PCL").Value

            If Not IsDBNull(.Fields("port_2").Value) Then frmComputers.cmbPRNConnect.Text = .Fields("port_2").Value


            'unaPCL
            'sBranch = .Fields("FILIAL").Value
            'sDepartment = .Fields("MESTO").Value
            'sOffice = .Fields("kabn").Value
            sName = .Fields("PRINTER_NAME_1").Value
            'txtPrnIP

            If Len(frmComputers.cmbModCartr.Text) = 0 Then

            Else


                sSQL1 = "SELECT * FROM spr_cart WHERE name='" & frmComputers.cmbTIPCartridg.Text & "'"
                rs1 = New ADODB.Recordset
                rs1.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs1
                    frmComputers.cmbTIPCartridg.Text = .Fields("A").Value
                End With

                rs1.Close()
                rs1 = Nothing

            End If

        End With


        If Len(unaPCL) <> 0 Then

            rs = New ADODB.Recordset
            rs.Open("Select NET_NAME From kompy where id=" & unaPCL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                frmComputers.cmbPCL.Text = .Fields("NET_NAME").Value

            End With
            rs.Close()
            rs = Nothing
        End If


        Call LOAD_CRT(sID)

        Call LOAD_GARs(sID, frmComputers.cmbPRNPostav, frmComputers.dtGPRNPr, frmComputers.dtGPRNok)

        'Call LOAD_NOTES(sID, frmComputers.lvNotesPRN)
        'Call LOAD_REPAIR(sID, frmComputers.lvRepairPRN)
        'Call LOAD_DVIG_TEHN(sID, frmComputers.lvMovementPRN)

    End Sub

    Public Sub LOAD_CRT(ByVal sID As String)
        On Error Resume Next
        'Обнаруженные картриджи
        frmComputers.lvPRNCartr.Items.Clear()
        frmComputers.lblPRNPage.Text = ""

        Dim kol As Long
        Dim uname As String
        Dim rs1 As ADODB.Recordset
        Dim sSQL1 As String

        sSQL1 = "SELECT COUNT(*) AS t_number FROM CARTRIDG WHERE USTR=" & sID
        rs1 = New ADODB.Recordset
        rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs1

            kol = .Fields("t_number").Value

        End With

        rs1.Close()
        rs1 = Nothing

        If kol = 0 Then

        Else

            Dim intCount As Decimal = 0
            Dim scid As Integer

            'Dim rs1 As ADODB.Recordset 'Объявляем рекордсет
            'Dim sSQL1 As String 'Переменная, где будет размещён SQL запрос

            sSQL1 = "SELECT * FROM CARTRIDG WHERE USTR=" & sID
            rs1 = New ADODB.Recordset
            rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


            With rs1
                .MoveFirst()
                Do While Not .EOF

                    frmComputers.lvPRNCartr.Items.Add(.Fields("id").Value) 'col no. 1
                    uname = .Fields("Model").Value
                    scid = .Fields("id").Value


                    Dim rs2 As ADODB.Recordset 'Объявляем рекордсет
                    Dim sSQL2 As String 'Переменная, где будет размещён SQL запрос

                    sSQL2 = "SELECT * FROM spr_cart where ID =" & uname
                    rs2 = New ADODB.Recordset
                    rs2.Open(sSQL2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs2
                        If Not IsDBNull(.Fields("name").Value) Then frmComputers.lvPRNCartr.Items(CInt(intCount)).SubItems.Add(.Fields("name").Value)
                    End With
                    rs2.Close()
                    rs2 = Nothing


                    If Not IsDBNull(.Fields("SN")) Then frmComputers.lvPRNCartr.Items(CInt(intCount)).SubItems.Add(.Fields("SN").Value)


                    Dim uname1 As Decimal = 0
                    Dim uname2 As Decimal = 0

                    sSQL2 = "SELECT Paper, STOIM FROM CARTRIDG_Z where ID_C =" & scid
                    rs2 = New ADODB.Recordset
                    rs2.Open(sSQL2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs2
                        .MoveFirst()
                        Do While Not .EOF
                            uname1 = uname1 + .Fields("Paper").Value
                            uname2 = uname2 + .Fields("STOIM").Value

                            .MoveNext()
                        Loop
                    End With

                    rs2.Close()
                    rs2 = Nothing



                    frmComputers.lblPRNPage.Text = uname1


                    sSQL2 = "SELECT COUNT(*) as total_num FROM CARTRIDG_Z where ID_C =" & scid
                    rs2 = New ADODB.Recordset
                    rs2.Open(sSQL2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs2

                        If Not IsDBNull(.Fields("total_num").Value) Then frmComputers.lvPRNCartr.Items(CInt(intCount)).SubItems.Add(.Fields("total_num").Value)

                    End With

                    rs2.Close()
                    rs2 = Nothing




                    frmComputers.lvPRNCartr.Items(CInt(intCount)).SubItems.Add(uname2)

                    intCount = intCount + 1

                    .MoveNext()
                Loop
            End With



        End If






        ResList(frmComputers.lvPRNCartr)
    End Sub

    Public Sub LOADt(ByVal sID As String)
        On Error Resume Next
        zID = sID

        Dim unaPCL As String

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM kompy WHERE id =" & sID
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        With rs
            'Процессоры

            frmComputers.lblsID.Text = .Fields("id").Value

            If Not IsDBNull(.Fields("CPU1").Value) Then frmComputers.cmbCPU1.Text = .Fields("CPU1").Value
            If Not IsDBNull(.Fields("CPUmhz1").Value) Then frmComputers.txtMHZ1.Text = .Fields("CPUmhz1").Value
            If Not IsDBNull(.Fields("CPUSocket1").Value) Then frmComputers.txtSoc1.Text = .Fields("CPUSocket1").Value
            If Not IsDBNull(.Fields("CPUProizv1").Value) Then frmComputers.PROizV1.Text = .Fields("CPUProizv1").Value

            If Not IsDBNull(.Fields("CPU2").Value) Then frmComputers.cmbCPU2.Text = .Fields("CPU2").Value
            If Not IsDBNull(.Fields("CPUmhz2").Value) Then frmComputers.txtMHZ2.Text = .Fields("CPUmhz2").Value
            If Not IsDBNull(.Fields("CPUSocket2").Value) Then frmComputers.txtSoc2.Text = .Fields("CPUSocket2").Value
            If Not IsDBNull(.Fields("CPUProizv2").Value) Then frmComputers.PROizV2.Text = .Fields("CPUProizv2").Value

            If Not IsDBNull(.Fields("CPU3").Value) Then frmComputers.cmbCPU3.Text = .Fields("CPU3").Value
            If Not IsDBNull(.Fields("CPUmhz3").Value) Then frmComputers.txtMHZ3.Text = .Fields("CPUmhz3").Value
            If Not IsDBNull(.Fields("CPUSocket3").Value) Then frmComputers.txtSoc3.Text = .Fields("CPUSocket3").Value
            If Not IsDBNull(.Fields("CPUProizv3").Value) Then frmComputers.PROizV3.Text = .Fields("CPUProizv3").Value

            If Not IsDBNull(.Fields("CPU4").Value) Then frmComputers.cmbCPU4.Text = .Fields("CPU4").Value
            If Not IsDBNull(.Fields("CPUmhz4").Value) Then frmComputers.txtMHZ4.Text = .Fields("CPUmhz4").Value
            If Not IsDBNull(.Fields("CPUSocket4").Value) Then frmComputers.txtSoc4.Text = .Fields("CPUSocket4").Value
            If Not IsDBNull(.Fields("CPUProizv4").Value) Then frmComputers.PROizV4.Text = .Fields("CPUProizv4").Value

            'Материнская плата
            If Not IsDBNull(.Fields("Mb").Value) Then frmComputers.cmbMB.Text = .Fields("Mb").Value
            If Not IsDBNull(.Fields("Mb_Chip").Value) Then frmComputers.txtChip.Text = .Fields("Mb_Chip").Value
            If Not IsDBNull(.Fields("Mb_Proizvod").Value) Then frmComputers.PROizV5.Text = .Fields("Mb_Proizvod").Value
            If Not IsDBNull(.Fields("Mb_Id").Value) Then frmComputers.txtSN_MB.Text = .Fields("Mb_Id").Value

            'Модули памяти

            If Not IsDBNull(.Fields("RAM_1").Value) Then frmComputers.cmbRAM1.Text = .Fields("RAM_1").Value
            If Not IsDBNull(.Fields("RAM_SN_1").Value) Then frmComputers.txtRamSN1.Text = .Fields("RAM_SN_1").Value
            If Not IsDBNull(.Fields("RAM_speed_1").Value) Then frmComputers.txtRamS1.Text = .Fields("RAM_speed_1").Value
            If Not IsDBNull(.Fields("RAM_PROIZV_1").Value) Then frmComputers.PROizV6.Text = .Fields("RAM_PROIZV_1").Value

            If Not IsDBNull(.Fields("RAM_2").Value) Then frmComputers.cmbRAM2.Text = .Fields("RAM_2").Value
            If Not IsDBNull(.Fields("RAM_speed_2").Value) Then frmComputers.txtRamS2.Text = .Fields("RAM_speed_2").Value
            If Not IsDBNull(.Fields("RAM_SN_2").Value) Then frmComputers.txtRamSN2.Text = .Fields("RAM_SN_2").Value
            If Not IsDBNull(.Fields("RAM_PROIZV_2").Value) Then frmComputers.PROizV7.Text = .Fields("RAM_PROIZV_2").Value

            If Not IsDBNull(.Fields("RAM_3").Value) Then frmComputers.cmbRAM3.Text = .Fields("RAM_3").Value
            If Not IsDBNull(.Fields("RAM_speed_3").Value) Then frmComputers.txtRamS3.Text = .Fields("RAM_speed_3").Value
            If Not IsDBNull(.Fields("RAM_SN_3").Value) Then frmComputers.txtRamSN3.Text = .Fields("RAM_SN_3").Value
            If Not IsDBNull(.Fields("RAM_PROIZV_3").Value) Then frmComputers.PROizV8.Text = .Fields("RAM_PROIZV_3").Value

            If Not IsDBNull(.Fields("RAM_4").Value) Then frmComputers.cmbRAM4.Text = .Fields("RAM_4").Value
            If Not IsDBNull(.Fields("RAM_speed_4").Value) Then frmComputers.txtRamS4.Text = .Fields("RAM_speed_4").Value
            If Not IsDBNull(.Fields("RAM_SN_4").Value) Then frmComputers.txtRamSN4.Text = .Fields("RAM_SN_4").Value
            If Not IsDBNull(.Fields("RAM_PROIZV_4").Value) Then frmComputers.PROizV9.Text = .Fields("RAM_PROIZV_4").Value

            'Жесткие диски

            If Not IsDBNull(.Fields("HDD_Name_1").Value) Then frmComputers.cmbHDD1.Text = .Fields("HDD_Name_1").Value
            If Not IsDBNull(.Fields("HDD_OB_1").Value) Then frmComputers.txtHDDo1.Text = .Fields("HDD_OB_1").Value
            If Not IsDBNull(.Fields("HDD_SN_1").Value) Then frmComputers.txtHDDsN1.Text = .Fields("HDD_SN_1").Value
            If Not IsDBNull(.Fields("HDD_PROIZV_1").Value) Then frmComputers.PROizV10.Text = .Fields("HDD_PROIZV_1").Value

            If Not IsDBNull(.Fields("HDD_Name_2").Value) Then frmComputers.cmbHDD2.Text = .Fields("HDD_Name_2").Value
            If Not IsDBNull(.Fields("HDD_OB_2").Value) Then frmComputers.txtHDDo2.Text = .Fields("HDD_OB_2").Value
            If Not IsDBNull(.Fields("HDD_SN_2").Value) Then frmComputers.txtHDDsN2.Text = .Fields("HDD_SN_2").Value
            If Not IsDBNull(.Fields("HDD_PROIZV_2").Value) Then frmComputers.PROizV11.Text = .Fields("HDD_PROIZV_2").Value

            If Not IsDBNull(.Fields("HDD_Name_3").Value) Then frmComputers.cmbHDD3.Text = .Fields("HDD_Name_3").Value
            If Not IsDBNull(.Fields("HDD_OB_3").Value) Then frmComputers.txtHDDo3.Text = .Fields("HDD_OB_3").Value
            If Not IsDBNull(.Fields("HDD_SN_3").Value) Then frmComputers.txtHDDsN3.Text = .Fields("HDD_SN_3").Value
            If Not IsDBNull(.Fields("HDD_PROIZV_3").Value) Then frmComputers.PROizV12.Text = .Fields("HDD_PROIZV_3").Value

            If Not IsDBNull(.Fields("HDD_Name_4").Value) Then frmComputers.cmbHDD4.Text = .Fields("HDD_Name_4").Value
            If Not IsDBNull(.Fields("HDD_OB_4").Value) Then frmComputers.txtHDDo4.Text = .Fields("HDD_OB_4").Value
            If Not IsDBNull(.Fields("HDD_SN_4").Value) Then frmComputers.txtHDDsN4.Text = .Fields("HDD_SN_4").Value
            If Not IsDBNull(.Fields("HDD_PROIZV_4").Value) Then frmComputers.PROizV13.Text = .Fields("HDD_PROIZV_4").Value

            'Видео карта
            If Not IsDBNull(.Fields("SVGA_NAME").Value) Then frmComputers.cmbSVGA1.Text = .Fields("SVGA_NAME").Value
            If Not IsDBNull(.Fields("SVGA_OB_RAM").Value) Then frmComputers.txtSVGAr1.Text = .Fields("SVGA_OB_RAM").Value
            If Not IsDBNull(.Fields("SVGA_SN").Value) Then frmComputers.txtSVGAs1.Text = .Fields("SVGA_SN").Value
            If Not IsDBNull(.Fields("SVGA_PROIZV").Value) Then frmComputers.PROizV14.Text = .Fields("SVGA_PROIZV").Value

            If Not IsDBNull(.Fields("SVGA2_NAME").Value) Then frmComputers.cmbSVGA2.Text = .Fields("SVGA2_NAME").Value
            If Not IsDBNull(.Fields("SVGA2_OB_RAM").Value) Then frmComputers.txtSVGAr2.Text = .Fields("SVGA2_OB_RAM").Value
            If Not IsDBNull(.Fields("SVGA2_SN").Value) Then frmComputers.txtSVGAs2.Text = .Fields("SVGA2_SN").Value
            If Not IsDBNull(.Fields("SVGA2_PROIZV").Value) Then frmComputers.PROizV15.Text = .Fields("SVGA2_PROIZV").Value

            'Звуковая карта

            If Not IsDBNull(.Fields("SOUND_NAME").Value) Then frmComputers.cmbSound.Text = .Fields("SOUND_NAME").Value
            'If Not IsDBNull(.fields("SVGA_OB_RAM").value) Then frmComputers.txtSoundB.Text = .fields("SVGA_OB_RAM").value
            If Not IsDBNull(.Fields("SOUND_SN").Value) Then frmComputers.txtSoundS.Text = .Fields("SOUND_SN").Value
            If Not IsDBNull(.Fields("SOUND_PROIZV").Value) Then frmComputers.PROizV16.Text = .Fields("SOUND_PROIZV").Value

            'Оптические накопители

            If Not IsDBNull(.Fields("CD_NAME").Value) Then frmComputers.cmbOPTIC1.Text = .Fields("CD_NAME").Value
            If Not IsDBNull(.Fields("CD_SPEED").Value) Then frmComputers.txtOPTICs1.Text = .Fields("CD_SPEED").Value
            If Not IsDBNull(.Fields("CD_SN").Value) Then frmComputers.txtOPTICsn1.Text = .Fields("CD_SN").Value
            If Not IsDBNull(.Fields("CD_PROIZV").Value) Then frmComputers.PROizV17.Text = .Fields("CD_PROIZV").Value

            If Not IsDBNull(.Fields("CDRW_NAME").Value) Then frmComputers.cmbOPTIC2.Text = .Fields("CDRW_NAME").Value
            If Not IsDBNull(.Fields("CDRW_SPEED").Value) Then frmComputers.txtOPTICs2.Text = .Fields("CDRW_SPEED").Value
            If Not IsDBNull(.Fields("CDRW_SN").Value) Then frmComputers.txtOPTICsn2.Text = .Fields("CDRW_SN").Value
            If Not IsDBNull(.Fields("CDRW_PROIZV").Value) Then frmComputers.PROizV18.Text = .Fields("CDRW_PROIZV").Value

            If Not IsDBNull(.Fields("DVD_NAME").Value) Then frmComputers.cmbOPTIC3.Text = .Fields("DVD_NAME").Value
            If Not IsDBNull(.Fields("DVD_SPEED").Value) Then frmComputers.txtOPTICs3.Text = .Fields("DVD_SPEED").Value
            If Not IsDBNull(.Fields("DVD_SN").Value) Then frmComputers.txtOPTICsn3.Text = .Fields("DVD_SN").Value
            If Not IsDBNull(.Fields("DVD_PROIZV").Value) Then frmComputers.PROizV19.Text = .Fields("DVD_PROIZV").Value

            'Сетевые карты
            If Not IsDBNull(.Fields("NET_NAME_1").Value) Then frmComputers.cmbNET1.Text = .Fields("NET_NAME_1").Value
            If Not IsDBNull(.Fields("NET_IP_1").Value) Then frmComputers.txtNETip1.Text = .Fields("NET_IP_1").Value
            If Not IsDBNull(.Fields("NET_MAC_1").Value) Then frmComputers.txtNETmac1.Text = .Fields("NET_MAC_1").Value
            If Not IsDBNull(.Fields("NET_PROIZV_1").Value) Then frmComputers.PROizV20.Text = .Fields("NET_PROIZV_1").Value

            If Not IsDBNull(.Fields("NET_NAME_2").Value) Then frmComputers.cmbNET2.Text = .Fields("NET_NAME_2").Value
            If Not IsDBNull(.Fields("NET_IP_2").Value) Then frmComputers.txtNETip2.Text = .Fields("NET_IP_2").Value
            If Not IsDBNull(.Fields("NET_MAC_2").Value) Then frmComputers.txtNETmac2.Text = .Fields("NET_MAC_2").Value
            If Not IsDBNull(.Fields("NET_PROIZV_2").Value) Then frmComputers.PROizV21.Text = .Fields("NET_PROIZV_2").Value

            'Дисковод
            If Not IsDBNull(.Fields("FDD_NAME").Value) Then frmComputers.cmbFDD.Text = .Fields("FDD_NAME").Value
            If Not IsDBNull(.Fields("FDD_SN").Value) Then frmComputers.txtSN.Text = .Fields("FDD_SN").Value
            'If Not IsDBNull(.fields("txtFDD_").value) Then frmComputers.txtFDD_.Text = .fields("txtFDD_").value
            If Not IsDBNull(.Fields("FDD_PROIZV").Value) Then frmComputers.PROizV22.Text = .Fields("FDD_PROIZV").Value

            'Кардридер
            If Not IsDBNull(.Fields("CREADER_NAME").Value) Then frmComputers.cmbCreader.Text = .Fields("CREADER_NAME").Value
            If Not IsDBNull(.Fields("CREADER_SN").Value) Then frmComputers.txtCreader1.Text = .Fields("CREADER_SN").Value
            If Not IsDBNull(.Fields("CREADER_PROIZV").Value) Then frmComputers.PROizV23.Text = .Fields("CREADER_PROIZV").Value

            'Модем
            If Not IsDBNull(.Fields("MODEM_NAME").Value) Then frmComputers.cmbModem.Text = .Fields("MODEM_NAME").Value
            If Not IsDBNull(.Fields("MODEM_SN").Value) Then frmComputers.txtModemSN.Text = .Fields("MODEM_SN").Value
            'If Not IsDBNull(.fields("txtFDD_").value) Then frmComputers.txtModem2.Text = .fields("txtFDD_").value
            If Not IsDBNull(.Fields("MODEM_PROIZV").Value) Then frmComputers.PROizV24.Text = .Fields("MODEM_PROIZV").Value

            'Корпус
            If Not IsDBNull(.Fields("CASE_NAME").Value) Then frmComputers.cmbCase.Text = .Fields("CASE_NAME").Value
            If Not IsDBNull(.Fields("CASE_SN").Value) Then frmComputers.txtCase1.Text = .Fields("CASE_SN").Value
            If Not IsDBNull(.Fields("CASE_PROIZV").Value) Then frmComputers.PROizV25.Text = .Fields("CASE_PROIZV").Value

            'Блок питания
            If Not IsDBNull(.Fields("BLOCK").Value) Then frmComputers.cmbBP.Text = .Fields("BLOCK").Value
            If Not IsDBNull(.Fields("SN_BLOCK").Value) Then frmComputers.txtBP1.Text = .Fields("SN_BLOCK").Value
            'If Not IsDBNull(.fields("txtFDD_").value) Then frmComputers.txtBP2.Text = .fields("txtFDD_").value
            If Not IsDBNull(.Fields("PROIZV_BLOCK").Value) Then frmComputers.PROizV26.Text = .Fields("PROIZV_BLOCK").Value

            'Производитель системного блока
            If Not IsDBNull(.Fields("SYS_PR").Value) Then frmComputers.PROizV27.Text = .Fields("SYS_PR").Value

            'Серийный номер системного блока
            If Not IsDBNull(.Fields("Ser_N_SIS").Value) Then frmComputers.txtSNSB.Text = .Fields("Ser_N_SIS").Value

            'Модель системного блока
            If Not IsDBNull(.Fields("PATH").Value) Then frmComputers.txtModSB.Text = .Fields("PATH").Value

            'USB
            If Not IsDBNull(.Fields("USB_NAME").Value) Then frmComputers.cmbUSB.Text = .Fields("USB_NAME").Value
            If Not IsDBNull(.Fields("USB_SN").Value) Then frmComputers.txtUSBSN.Text = .Fields("USB_SN").Value
            If Not IsDBNull(.Fields("USB_PROIZV").Value) Then frmComputers.PROizV41.Text = .Fields("USB_PROIZV").Value

            'PCI
            If Not IsDBNull(.Fields("PCI_NAME").Value) Then frmComputers.cmbPCI.Text = .Fields("PCI_NAME").Value
            If Not IsDBNull(.Fields("PCI_SN").Value) Then frmComputers.txtSNPCI.Text = .Fields("PCI_SN").Value
            If Not IsDBNull(.Fields("PCI_PROIZV").Value) Then frmComputers.PROizV42.Text = .Fields("PCI_PROIZV").Value




            'Монитор
            '1
            If Not IsDBNull(.Fields("MONITOR_NAME").Value) Then frmComputers.cmbMon1.Text = .Fields("MONITOR_NAME").Value
            If Not IsDBNull(.Fields("MONITOR_DUM").Value) Then frmComputers.txtMon1Dum.Text = .Fields("MONITOR_DUM").Value
            If Not IsDBNull(.Fields("MONITOR_SN").Value) Then frmComputers.txtMon1SN.Text = .Fields("MONITOR_SN").Value
            If Not IsDBNull(.Fields("MONITOR_PROIZV").Value) Then frmComputers.PROizV28.Text = .Fields("MONITOR_PROIZV").Value

            '2
            If Not IsDBNull(.Fields("MONITOR_NAME2").Value) Then frmComputers.cmbMon2.Text = .Fields("MONITOR_NAME2").Value
            If Not IsDBNull(.Fields("MONITOR_DUM2").Value) Then frmComputers.txtMon2Dum.Text = .Fields("MONITOR_DUM2").Value
            If Not IsDBNull(.Fields("MONITOR_SN2").Value) Then frmComputers.txtMon2SN.Text = .Fields("MONITOR_SN2").Value
            If Not IsDBNull(.Fields("MONITOR_PROIZV2").Value) Then frmComputers.PROizV29.Text = .Fields("MONITOR_PROIZV2").Value

            'Клавиатура
            If Not IsDBNull(.Fields("KEYBOARD_NAME").Value) Then frmComputers.cmbKeyb.Text = .Fields("KEYBOARD_NAME").Value
            If Not IsDBNull(.Fields("KEYBOARD_SN").Value) Then frmComputers.txtKeybSN.Text = .Fields("KEYBOARD_SN").Value
            If Not IsDBNull(.Fields("KEYBOARD_PROIZV").Value) Then frmComputers.PROizV30.Text = .Fields("KEYBOARD_PROIZV").Value

            'Мышь
            If Not IsDBNull(.Fields("MOUSE_NAME").Value) Then frmComputers.cmbMouse.Text = .Fields("MOUSE_NAME").Value
            If Not IsDBNull(.Fields("MOUSE_SN").Value) Then frmComputers.txtMouseSN.Text = .Fields("MOUSE_SN").Value
            If Not IsDBNull(.Fields("MOUSE_PROIZV").Value) Then frmComputers.PROizV31.Text = .Fields("MOUSE_PROIZV").Value

            'Колонки

            If Not IsDBNull(.Fields("AS_NAME").Value) Then frmComputers.cmbAsist.Text = .Fields("AS_NAME").Value
            If Not IsDBNull(.Fields("AS_SN").Value) Then frmComputers.txtAsistSN.Text = .Fields("AS_SN").Value
            If Not IsDBNull(.Fields("AS_PROIZV").Value) Then frmComputers.PROizV32.Text = .Fields("AS_PROIZV").Value

            'Сетевой фильтр
            If Not IsDBNull(.Fields("FILTR_NAME").Value) Then frmComputers.cmbFilter.Text = .Fields("FILTR_NAME").Value
            If Not IsDBNull(.Fields("FILTR_SN").Value) Then frmComputers.txtFilterSN.Text = .Fields("FILTR_SN").Value
            If Not IsDBNull(.Fields("FILTR_PROIZV").Value) Then frmComputers.PROizV33.Text = .Fields("FILTR_PROIZV").Value

            'ИБП
            If Not IsDBNull(.Fields("IBP_NAME").Value) Then frmComputers.cmbIBP.Text = .Fields("IBP_NAME").Value
            If Not IsDBNull(.Fields("IBP_SN").Value) Then frmComputers.txtSNIBP.Text = .Fields("IBP_SN").Value
            If Not IsDBNull(.Fields("IBP_PROIZV").Value) Then frmComputers.PROizV43.Text = .Fields("IBP_PROIZV").Value

            'Подключенные принтеры
            If Not IsDBNull(.Fields("PRINTER_NAME_1").Value) Then frmComputers.cmbPrinters1.Text = .Fields("PRINTER_NAME_1").Value
            If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then frmComputers.txtPrint1SN.Text = .Fields("PRINTER_SN_1").Value
            If Not IsDBNull(.Fields("PORT_1").Value) Then frmComputers.txtPrint1Port.Text = .Fields("PORT_1").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_1").Value) Then frmComputers.PROizV34.Text = .Fields("PRINTER_PROIZV_1").Value

            If Not IsDBNull(.Fields("PRINTER_NAME_2").Value) Then frmComputers.cmbPrinters2.Text = .Fields("PRINTER_NAME_2").Value
            If Not IsDBNull(.Fields("PRINTER_SN_2").Value) Then frmComputers.txtPrint2SN.Text = .Fields("PRINTER_SN_2").Value
            If Not IsDBNull(.Fields("PORT_2").Value) Then frmComputers.txtPrint2Port.Text = .Fields("PORT_2").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_2").Value) Then frmComputers.PROizV35.Text = .Fields("PRINTER_PROIZV_2").Value

            If Not IsDBNull(.Fields("PRINTER_NAME_3").Value) Then frmComputers.cmbPrinters3.Text = .Fields("PRINTER_NAME_3").Value
            If Not IsDBNull(.Fields("PRINTER_SN_3").Value) Then frmComputers.txtPrint3SN.Text = .Fields("PRINTER_SN_3").Value
            If Not IsDBNull(.Fields("PORT_3").Value) Then frmComputers.txtPrint3Port.Text = .Fields("PORT_3").Value
            If Not IsDBNull(.Fields("PRINTER_PROIZV_3").Value) Then frmComputers.PROizV36.Text = .Fields("PRINTER_PROIZV_3").Value

            If Not IsDBNull(.Fields("NET_NAME").Value) Then frmComputers.txtSNAME.Text = .Fields("NET_NAME").Value
            If Not IsDBNull(.Fields("PSEVDONIM").Value) Then frmComputers.txtPSEUDONIM.Text = .Fields("PSEVDONIM").Value

            If Not IsDBNull(.Fields("FILIAL").Value) Then frmComputers.cmbBranch.Text = .Fields("FILIAL").Value
            If Not IsDBNull(.Fields("MESTO").Value) Then frmComputers.cmbDepartment.Text = .Fields("MESTO").Value
            If Not IsDBNull(.Fields("kabn").Value) Then frmComputers.cmbOffice.Text = .Fields("kabn").Value

            'sBranch = .Fields("FILIAL").Value
            'sDepartment = .Fields("MESTO").Value
            'sOffice = .Fields("kabn").Value
            sName = .Fields("NET_NAME").Value

            If Not IsDBNull(.Fields("OTvetstvennyj").Value) Then frmComputers.cmbResponsible.Text = .Fields("OTvetstvennyj").Value
            If Not IsDBNull(.Fields("TELEPHONE").Value) Then frmComputers.txtPHONE.Text = .Fields("TELEPHONE").Value
            If Not IsDBNull(.Fields("TIP_COMPA").Value) Then frmComputers.cmbAppointment.Text = .Fields("TIP_COMPA").Value

            If Not IsDBNull(.Fields("INV_NO_SYSTEM").Value) Then frmComputers.txtSBSN.Text = .Fields("INV_NO_SYSTEM").Value
            If Not IsDBNull(.Fields("INV_NO_MONITOR").Value) Then frmComputers.txtMSN.Text = .Fields("INV_NO_MONITOR").Value
            If Not IsDBNull(.Fields("INV_NO_IBP").Value) Then frmComputers.IN_IBP.Text = .Fields("INV_NO_IBP").Value
            If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then frmComputers.IN_PRN.Text = .Fields("INV_NO_PRINTER").Value

            If .Fields("TIP_COMPA").Value = "Сервер" Then
                frmComputers.ChkPDC.Visible = True
            Else
                frmComputers.ChkPDC.Visible = False
            End If




            Dim Gar As Boolean

            If Not IsDBNull(.Fields("Garantia_Sist").Value) Then Gar = .Fields("Garantia_Sist").Value

            If Gar = False Then
                frmComputers.rbKompl.Checked = True
                For Each C In frmComputers.sSTAB1.TabPages(0).Controls
                    If TypeOf C Is GroupBox Then C.Cursor = Cursors.Hand
                Next C
                For Each C In frmComputers.sSTAB1.TabPages(1).Controls
                    If TypeOf C Is GroupBox Then C.Cursor = Cursors.Hand
                Next C
                For Each C In frmComputers.sSTAB1.TabPages(2).Controls
                    If TypeOf C Is GroupBox Then C.Cursor = Cursors.Hand
                Next C
            Else

                frmComputers.rbSist.Checked = True
                For Each C In frmComputers.sSTAB1.TabPages(0).Controls
                    If TypeOf C Is GroupBox Then C.Cursor = Cursors.Default
                Next C
                For Each C In frmComputers.sSTAB1.TabPages(1).Controls
                    If TypeOf C Is GroupBox Then C.Cursor = Cursors.Default
                Next C

                For Each C In frmComputers.sSTAB1.TabPages(2).Controls
                    If TypeOf C Is GroupBox Then C.Cursor = Cursors.Default
                Next C

                Call LOAD_GARs(sID, frmComputers.cmbPostav, frmComputers.dtGPr, frmComputers.dtGok)

            End If


            If Not IsDBNull(.Fields("SFAktNo").Value) Then frmComputers.txtPCSfN.Text = .Fields("SFAktNo").Value
            If Not IsDBNull(.Fields("CenaRub").Value) Then frmComputers.txtPCcash.Text = .Fields("CenaRub").Value
            If Not IsDBNull(.Fields("StoimRub").Value) Then frmComputers.txtPCSumm.Text = .Fields("StoimRub").Value
            If Not IsDBNull(.Fields("Zaiavk").Value) Then frmComputers.txtPCZay.Text = .Fields("Zaiavk").Value

            If Not IsDBNull(.Fields("DataVVoda").Value) Then frmComputers.dtPCdataVvoda.Value = .Fields("DataVVoda").Value
            If Not IsDBNull(.Fields("dataSF").Value) Then frmComputers.dtPCSFdate.Value = .Fields("dataSF").Value

            If Not IsDBNull(.Fields("Spisan").Value) Then frmComputers.chkPCspis.Checked = .Fields("Spisan").Value
            If Not IsDBNull(.Fields("Balans").Value) Then frmComputers.chkPCNNb.Checked = .Fields("Balans").Value
            If Not IsDBNull(.Fields("PCL").Value) Then unaPCL = .Fields("PCL").Value

        End With

        rs.Close()
        rs = Nothing

        If Len(unaPCL) <> 0 Then

            rs = New ADODB.Recordset
            rs.Open("Select NET_NAME From kompy where id=" & unaPCL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                frmComputers.cmbPCLK.Text = .Fields("NET_NAME").Value

            End With
            rs.Close()
            rs = Nothing
        End If

        '#############################################
        'Проверка есть ли контейнеры в справочнике
        '#############################################

        sSQL = "SELECT count(*) as t_n from spr_other where C='1'"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim A1 As String
        With rs
            A1 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case A1
            Case 0
                frmComputers.cmbPCLK.Visible = False
                frmComputers.Label88.Visible = False

            Case Else
                frmComputers.cmbPCLK.Visible = True
                frmComputers.Label88.Visible = True

                Call LOAD_PCL(frmComputers.cmbBranch.Text, frmComputers.cmbDepartment.Text, frmComputers.cmbOffice.Text, frmComputers.cmbPCLK)
        End Select

        '#############################################
        '#############################################
        '#############################################



        'Call LOAD_SOFT(sID, frmComputers.lstSoftware)
        'Call LOAD_USER(sID)
        'Call LOAD_NOTES(sID, frmComputers.lvNotes)
        'Call LOAD_REPAIR(sID, frmComputers.lvRepair)
        'Call LOAD_DVIG_TEHN(sID, frmComputers.lvMovement)

    End Sub

    Public Sub LOADmon(ByVal sID As String)
        On Error Resume Next
        Dim unaPCL As String
        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM kompy WHERE id =" & sID
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            frmComputers.lblsIDOTH.Text = .Fields("id").Value

            If Not IsDBNull(.Fields("MONITOR_NAME").Value) Then frmComputers.cmbOTH.Text = .Fields("MONITOR_NAME").Value
            If Not IsDBNull(.Fields("MONITOR_DUM").Value) Then frmComputers.txtMonDum.Text = .Fields("MONITOR_DUM").Value
            If Not IsDBNull(.Fields("MONITOR_SN").Value) Then frmComputers.txtOTHSN.Text = .Fields("MONITOR_SN").Value
            If Not IsDBNull(.Fields("MONITOR_PROIZV").Value) Then frmComputers.PROiZV39.Text = .Fields("MONITOR_PROIZV").Value
            If Not IsDBNull(.Fields("OTvetstvennyj").Value) Then frmComputers.cmbOTHotv.Text = .Fields("OTvetstvennyj").Value
            If Not IsDBNull(.Fields("INV_NO_MONITOR").Value) Then frmComputers.txtOTHinnumber.Text = .Fields("INV_NO_MONITOR").Value
            If Not IsDBNull(.Fields("port_1").Value) Then frmComputers.txtOTHmemo.Text = .Fields("port_1").Value
            'txtOTHmemo

            If Not IsDBNull(.Fields("FILIAL").Value) Then frmComputers.cmbOTHFil.Text = .Fields("FILIAL").Value
            If Not IsDBNull(.Fields("MESTO").Value) Then frmComputers.cmbOTHDepart.Text = .Fields("MESTO").Value
            If Not IsDBNull(.Fields("kabn").Value) Then frmComputers.cmbOTHOffice.Text = .Fields("kabn").Value

            'sName = .Fields("PRINTER_NAME_1").Value

            'If Not IsDBNull(.Fields("NET_IP_1").Value) Then frmComputers.txtOTHIP.Text = .Fields("NET_IP_1").Value
            'If Not IsDBNull(.Fields("NET_MAC_1").Value) Then frmComputers.txtOTHMAC.Text = .Fields("NET_MAC_1").Value
            'If Not IsDBNull(.Fields("TIP_COMPA").Value) Then frmComputers.cmbOTHConnect.Text = .Fields("TIP_COMPA").Value

            frmComputers.txtOTHphone.Text = .Fields("TELEPHONE").Value




            If Not IsDBNull(.Fields("SFAktNo").Value) Then frmComputers.txtOTHSfN.Text = .Fields("SFAktNo").Value
            If Not IsDBNull(.Fields("CenaRub").Value) Then frmComputers.txtOTHcash.Text = .Fields("CenaRub").Value
            If Not IsDBNull(.Fields("StoimRub").Value) Then frmComputers.txtOTHSumm.Text = .Fields("StoimRub").Value
            If Not IsDBNull(.Fields("Zaiavk").Value) Then frmComputers.txtOTHZay.Text = .Fields("Zaiavk").Value

            If Not IsDBNull(.Fields("DataVVoda").Value) Then frmComputers.dtOTHdataVvoda.Value = .Fields("DataVVoda").Value
            If Not IsDBNull(.Fields("dataSF").Value) Then frmComputers.dtOTHSFdate.Value = .Fields("dataSF").Value

            If Not IsDBNull(.Fields("Spisan").Value) Then frmComputers.chkOTHspis.Checked = .Fields("Spisan").Value
            If Not IsDBNull(.Fields("Balans").Value) Then frmComputers.chkOTHNNb.Checked = .Fields("Balans").Value
            If Not IsDBNull(.Fields("PCL").Value) Then unaPCL = .Fields("PCL").Value

        End With

        rs.Close()
        rs = Nothing


        If Len(unaPCL) <> 0 Then

            rs = New ADODB.Recordset
            rs.Open("Select NET_NAME From kompy where id=" & unaPCL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                frmComputers.cmbOTHPCL.Text = .Fields("NET_NAME").Value

            End With
            rs.Close()
            rs = Nothing
        End If




        Call LOAD_GARs(sID, frmComputers.cmbOTHPostav, frmComputers.dtGOTHPr, frmComputers.dtGOTHok)
        Call LOAD_NOTES(sID, frmComputers.lvNotesOTH)
        Call LOAD_REPAIR(sID, frmComputers.lvRepairOTH)
        Call LOAD_DVIG_TEHN(sID, frmComputers.lvMovementOTH)
    End Sub

    Public Sub LOAD_SOFT(ByVal sID As String, ByVal lstSoftware As ListView)
        On Error Resume Next
        lstSoftware.Items.Clear()


        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM SOFT_INSTALL WHERE Id_Comp =" & sID & " ORDER BY Soft, NomerSoftKomp"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intCount As Decimal = 0

        With rs
            .MoveFirst()
            Do While Not .EOF


                lstSoftware.Items.Add(.Fields("id").Value) 'col no. 1


                If Not IsDBNull(.Fields("NomerSoftKomp").Value) Then lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("NomerSoftKomp").Value)

                If Not IsDBNull(.Fields("Soft").Value) Then lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("Soft").Value)

                If Not IsDBNull(.Fields("L_key").Value) Then
                    lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("L_key").Value)
                Else
                    lstSoftware.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("t_lic").Value) Then
                    lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("t_lic").Value)
                Else
                    lstSoftware.Items(CInt(intCount)).SubItems.Add("")
                End If
                If Not IsDBNull(.Fields("d_p").Value) Then
                    lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("d_p").Value)
                Else
                    lstSoftware.Items(CInt(intCount)).SubItems.Add("")
                End If
                If Not IsDBNull(.Fields("d_o").Value) Then
                    lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("d_o").Value)
                Else
                    lstSoftware.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Publisher").Value) Then
                    lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("Publisher").Value)
                Else
                    lstSoftware.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("TIP").Value) Then
                    lstSoftware.Items(CInt(intCount)).SubItems.Add(.Fields("TIP").Value)
                Else
                    lstSoftware.Items(CInt(intCount)).SubItems.Add("")
                End If


                intCount = intCount + 1
                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing

        ResList(lstSoftware)
    End Sub

    Public Sub LOAD_USER(ByVal sID As String)
        On Error Resume Next
        frmComputers.lstUsers.Items.Clear()


        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM USER_COMP WHERE Id_Comp =" & sID & " ORDER BY USERNAME"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intCount As Decimal = 0

        With rs
            .MoveFirst()
            Do While Not .EOF
                frmComputers.lstUsers.Items.Add(.Fields("id").Value) 'col no. 1

                If Not IsDBNull(.Fields("FIO").Value) Then
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add(.Fields("FIO").Value)
                Else
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("USERNAME").Value) Then
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add(.Fields("USERNAME").Value)
                Else
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("EMAIL").Value) Then
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add(.Fields("EMAIL").Value)
                Else
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("icq").Value) Then
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add(.Fields("icq").Value)
                Else
                    frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add("")
                End If

                'If Not IsDBNull(.fields("jabber").value) Then
                'frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add(.fields("jabber").value)
                'Else
                'frmComputers.lstUsers.Items(CInt(intCount)).SubItems.Add("").value
                'End If


                intCount = intCount + 1
                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing

        ResList(frmComputers.lstUsers)

    End Sub

    Public Sub LOAD_NOTES(ByVal sID As String, ByVal lstGroups As ListView)
        On Error Resume Next
        lstGroups.Items.Clear()

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос
        sSQL = "SELECT * FROM Zametki WHERE Id_Comp =" & sID & " ORDER BY date DESC, id DESC"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intCount As Decimal = 0

        With rs
            .MoveFirst()
            Do While Not .EOF
                lstGroups.Items.Add(.Fields("id").Value) 'col no. 1

                If Not IsDBNull(.Fields("NomerZamKomp").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("NomerZamKomp").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Date").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Zametki").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Zametki").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Master").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                intCount = intCount + 1
                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing
        ResList(lstGroups)
    End Sub

    Public Sub LOAD_REPAIR(ByVal sID As String, ByVal lstGroups As ListView)
        On Error Resume Next
        lstGroups.Items.Clear()


        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос
        Dim uname As Integer


        rs = New ADODB.Recordset
        sSQL = "SELECT COUNT(*) AS t_number FROM Remont WHERE id_comp=" & sID & " AND PREF='" & frmComputers.sPREF & "'"
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            uname = .Fields("t_number").Value
        End With
        rs.Close()
        rs = Nothing

        'ResList(lstGroups)

        If uname = 0 Then Exit Sub



        Dim tID As Long

        'Dim rs As ADODB.Recordset 'Объявляем рекордсет
        'Dim sSQL As String 'Переменная, где будет размещён SQL запрос
        sSQL = "SELECT * FROM Remont WHERE id_comp=" & sID & " and PREF='" & frmComputers.sPREF & "' ORDER BY date DESC, id DESC"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intCount As Decimal = 0


        'intCount = 0
        'intCount = 0

        lstGroups.SmallImageList = frmserviceDesc.ilsCMD

        'Dim uname As Integer

        With rs
            .MoveFirst()
            Do While Not .EOF


                If .Fields("zakryt").Value = 1 Or .Fields("zakryt").Value = True Then

                    uname = 0
                Else
                    uname = 1

                End If

                Dim item As ListViewItem = lstGroups.Items.Add(.Fields(0).Value)
                item.ImageIndex = uname


                'lstGroups.Items.Add(.Fields("id").Value) 'col no. 1

                tID = .Fields("id").Value

                If Not IsDBNull(.Fields("NomerRemKomp").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("NomerRemKomp").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Date").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("name_of_remont").Value) Then

                    If Len(.Fields("name_of_remont").Value) = 0 Then

                        lstGroups.Items(CInt(intCount)).SubItems.Add(Left(.Fields("Remont").Value, 35) & "...")
                    Else
                        's = Right(.Fields("name_of_remont").Value, 50)
                        lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("name_of_remont").Value)
                    End If
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If



                If Not IsDBNull(.Fields("Uroven").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Master").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("vip").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("srok").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("srok").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("UserName").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                Dim rs1 As ADODB.Recordset 'Объявляем рекордсет
                Dim sSQL1 As String 'Переменная, где будет размещён SQL запрос
                sSQL1 = "SELECT COUNT(*) as t_n FROM remonty_plus WHERE id_rem =" & tID
                rs1 = New ADODB.Recordset
                rs1.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs1
                    If Not IsDBNull(.Fields("t_n").Value) Then
                        lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("t_n").Value)
                    Else
                        lstGroups.Items(CInt(intCount)).SubItems.Add("0")
                    End If
                End With

                rs1.Close()
                rs1 = Nothing


                intCount = intCount + 1
                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing

        ResList(lstGroups)

    End Sub

    Public Sub LOAD_DVIG_TEHN(ByVal sID As String, ByVal lstGroup As ListView)
        Dim sNom As Integer
        lstGroup.Items.Clear()

        Dim rscount As ADODB.Recordset 'Объявляем рекордсет
        rscount = New ADODB.Recordset
        rscount.Open("SELECT COUNT(*) AS total_number FROM dvig where id_comp=" & frmComputers.sCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rscount

            sNom = .Fields("total_number").Value

        End With

        rscount.Close()
        rscount = Nothing

        ResList(lstGroup)

        If sNom > 0 Then

            Dim rs As ADODB.Recordset 'Объявляем рекордсет
            Dim sSQL As String 'Переменная, где будет размещён SQL запрос

            sSQL = "SELECT ID_comp, data, id, oldmesto, newmesto, prich, time FROM dvig where id_comp=" & frmComputers.sCOUNT
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            Dim intCount As Decimal = 0
            With rs
                .MoveFirst()
                Do While Not .EOF
                    'NomR = .Fields(0)
                    lstGroup.Items.Add(.Fields("id").Value) 'col no. 1

                    If Not IsDBNull(.Fields("oldmesto").Value) Then
                        lstGroup.Items(CInt(intCount)).SubItems.Add(.Fields("oldmesto").Value)
                    Else
                        lstGroup.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("newmesto").Value) Then
                        lstGroup.Items(CInt(intCount)).SubItems.Add(.Fields("newmesto").Value)
                    Else
                        lstGroup.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("prich").Value) Then
                        lstGroup.Items(CInt(intCount)).SubItems.Add(.Fields("prich").Value)
                    Else
                        lstGroup.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("data").Value) Then
                        lstGroup.Items(CInt(intCount)).SubItems.Add(.Fields("data").Value)
                    Else
                        lstGroup.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("time").Value) Then
                        lstGroup.Items(CInt(intCount)).SubItems.Add(.Fields("time").Value)
                    Else
                        lstGroup.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    intCount = intCount + 1

                    .MoveNext()
                    'DoEvents
                Loop
            End With

            rs.Close()
            rs = Nothing

            ResList(lstGroup)

        End If



    End Sub

    Private Sub LOAD_GARs(ByVal sID As String, ByVal dPost As ComboBox, ByVal dtp As DateTimePicker, ByVal dto As DateTimePicker)

        Dim rsGa As ADODB.Recordset
        Dim A, B, C As String
        Dim dDate As Date
        rsGa = New ADODB.Recordset

        rsGa.Open("SELECT * FROM Garantia_sis WHERE id_Comp=" & sID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rsGa

            If Not IsDBNull(.Fields("Postav").Value) Then dPost.Text = .Fields("Postav").Value
            If Not IsDBNull(.Fields("Day").Value) Then A = .Fields("Day").Value
            If Not IsDBNull(.Fields("Month").Value) Then B = .Fields("Month").Value
            If Not IsDBNull(.Fields("Year").Value) Then C = .Fields("Year").Value

            dDate = A & "." & B & "." & C
            dtp.Value = dDate

            If Not IsDBNull(.Fields("Day_O").Value) Then A = .Fields("Day_O").Value
            If Not IsDBNull(.Fields("Month_O").Value) Then B = .Fields("Month_O").Value
            If Not IsDBNull(.Fields("Year_O").Value) Then C = .Fields("Year_O").Value

            dDate = A & "." & B & "." & C

            dto.Value = dDate

        End With
        rsGa.Close()
        rsGa = Nothing


    End Sub

    Public Sub LOAD_INF_BRANCHE(ByVal sID As String)
        'Dim sSQL As String
        'On Error GoTo err_
        frmComputers.lvNotesBR.Items.Clear()

        Dim SerD As String
        Dim rs As ADODB.Recordset


        Select Case frmComputers.sPREF

            Case "G"

                SerD = sID & "F"


            Case "O"

                SerD = sID & "O_F"

            Case "K"
                SerD = sID & "K"

        End Select

        Dim sSQL As String
        Dim sCN As String
        Dim sSQL1 As String
        Dim sSQL2 As String
        Dim sSQL3 As String


        sSQL1 = "Select * FROM SES_Pass where id_OF='" & SerD & "'"
        sSQL2 = "Select * FROM OTD_O where Id_OTD='" & SerD & "'"



        sSQL = "Select count(*) as t_n FROM SES_Pass where id_OF='" & SerD & "'"

        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            sCN = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        If sCN > 0 Then

            rs = New ADODB.Recordset
            rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs
                frmComputers.txtspplo.Text = .Fields("Ploshad").Value
                frmComputers.txtspvis.Text = .Fields("visota").Value
                frmComputers.txtspPloOneEVM.Text = .Fields("Pl1Pk").Value
                frmComputers.txtspObOneEVM.Text = .Fields("ob1Pk").Value
                frmComputers.cmbSpRemEVM.Text = .Fields("nalpom").Value
                frmComputers.cmbSpVent.Text = .Fields("vent").Value
                frmComputers.cmbSpWater.Text = .Fields("voda").Value
                frmComputers.cmbSpTeplo.Text = .Fields("kanal").Value
                frmComputers.cmbSpKanal.Text = .Fields("teplo").Value
                frmComputers.txtSpWall.Text = .Fields("otdelka").Value
                frmComputers.txtSpMebel.Text = .Fields("mebel").Value
            End With

            rs.Close()
            rs = Nothing
        End If


        sSQL = "Select count(*) as t_n FROM OTD_O where Id_OTD='" & SerD & "'"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            sCN = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCN > 0 Then


            rs = New ADODB.Recordset
            rs.Open(sSQL2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs
                frmComputers.txtBRAddress.Text = .Fields("ADRESS").Value
                frmComputers.txtBRBoss.Text = .Fields("OTV").Value
                frmComputers.txtBRPhone.Text = .Fields("Phone").Value

                If Not IsDBNull(.Fields("Prim").Value) Then
                    frmComputers.txtBRMemo.Text = .Fields("Prim").Value
                Else
                    frmComputers.txtBRMemo.Text = ""
                End If

            End With

            rs.Close()
            rs = Nothing
        End If


        sSQL = "Select count(*) as t_n FROM ZAM_OTD where ID_OTD='" & SerD & "'"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            sCN = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCN > 0 Then

            sSQL3 = "Select * FROM ZAM_OTD where ID_OTD='" & SerD & "' ORDER BY date DESC, id DESC"

            rs = New ADODB.Recordset
            rs.Open(sSQL3, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            Dim intCount As Decimal = 0

            With rs
                .MoveFirst()
                Do While Not .EOF
                    frmComputers.lvNotesBR.Items.Add(.Fields("id").Value) 'col no. 1

                    If Not IsDBNull(.Fields("ID_ZAM").Value) Then
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add(.Fields("ID_ZAM").Value)
                    Else
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("Date").Value) Then
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                    Else
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("ZAMETKA").Value) Then
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add(.Fields("ZAMETKA").Value)
                    Else
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("Master").Value) Then
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                    Else
                        frmComputers.lvNotesBR.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    intCount = intCount + 1
                    .MoveNext()
                Loop
            End With

            rs.Close()
            rs = Nothing
        End If

        Exit Sub
err_:

    End Sub

    Public Sub SHED_CHECK()
        Dim rs As ADODB.Recordset

        Dim sSQL, SERT, SERT2 As String
        Dim LNGIniFile As New IniFile(sLANGPATH)


        sSQL = "SELECT COUNT(*) AS total_number FROM Sheduler"

        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            SERT = .Fields("total_number").Value
        End With

        rs.Close()
        rs = Nothing



        If SERT > 0 Then
            frmMain.lblShed.Visible = True
            'frmMain lblShed
            'LNGIniFile.GetString("frmMain", "lblShed", "")
            frmMain.lblShed.Text = LNGIniFile.GetString("frmMain", "lblShed", "") & " " & "(" & "0" & "/" & SERT$ & ")"

            sSQL = "SELECT COUNT(*) AS total_number FROM Sheduler Where foruser='" & UserNames & "'"

            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs
                SERT2 = .Fields("total_number").Value
            End With
            rs.Close()
            rs = Nothing

            If SERT2 > 0 Then

                sSQL = "SELECT DATA, FORUSER, OPIS FROM Sheduler Where foruser='" & UserNames & "'"

                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                Dim intj As Integer
                intj = 0
                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        If .Fields(0).Value <= Date.Today.AddDays(-3) Or .Fields(0).Value >= Date.Today.AddDays(+3) Then

                        Else

                            If .Fields(1).Value = UserNames Then
                                intj = intj + 1

                                frmMain.lblShed.Text = LNGIniFile.GetString("frmMain", "lblShed", "") & " " & "(" & intj & "/" & SERT$ & ")"
                                frmMain.lblShed.ForeColor = Color.Red

                            Else
                            End If
                        End If

                        .MoveNext()
                        'DoEvents
                    Loop
                End With

                rs.Close()
                rs = Nothing

            Else

                frmMain.lblShed.Text = LNGIniFile.GetString("frmMain", "lblShed", "") & " " & "(" & "0" & "/" & SERT$ & ")"
                frmMain.lblShed.ForeColor = Color.Black

            End If


        Else

            frmMain.lblShed.Visible = False
        End If

        'frmMain.lblShed.Text = "Напоминания "


    End Sub

    Public Sub REM_CHECK()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        On Error Resume Next

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

            frmMain.lblRem.Visible = True

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
            'LNGIniFile.GetString("frmMain", "lblRem", "") & " " & 
            frmMain.lblRem.Text = LNGIniFile.GetString("frmMain", "lblRem", "") & " " & "(" & "0" & "/" & SERT & ")"

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

                    frmMain.lblRem.Text = LNGIniFile.GetString("frmMain", "lblRem", "") & " " & "(" & SERT3 & "/" & SERT & ")"
                    frmMain.lblRem.ForeColor = Color.Red


                Else

                    frmMain.lblRem.Text = LNGIniFile.GetString("frmMain", "lblRem", "") & " " & "(" & "0" & "/" & SERT & ")"
                    frmMain.lblRem.ForeColor = Color.Black

                End If

            Else

                frmMain.lblRem.Text = LNGIniFile.GetString("frmMain", "lblRem", "") & " " & "(" & "0" & "/" & SERT & ")"

            End If


        Else

            frmMain.lblRem.Visible = False
        End If



    End Sub

    Public Sub ExLoadParFow(ByVal sCombo1 As String, ByVal sText1 As TextBox, ByVal sText2 As TextBox, ByVal sCombo2 As ComboBox, ByVal sTABLE As String)

        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim sSQL As String
        Dim uNI As String
        rs = New ADODB.Recordset



        sSQL = "SELECT * FROM " & sTABLE & " WHERE Name = '" & sCombo1 & "'"

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("proizv").Value) Then uNI = .Fields("proizv").Value

            Dim PROYZV As ADODB.Recordset
            PROYZV = New ADODB.Recordset
            PROYZV.Open("SELECT * FROM SPR_PROIZV WHERE iD=" & uNI, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With PROYZV
                sCombo2.Text = .Fields("proizv").Value
            End With
            PROYZV.Close()
            PROYZV = Nothing

            If Not IsDBNull(.Fields("A").Value) Then sText1.Text = .Fields("A").Value
            If Not IsDBNull(.Fields("B").Value) Then sText2.Text = .Fields("B").Value
        End With

        rs.Close()
        rs = Nothing


    End Sub

    Public Sub ExLoadParTree(ByVal sCombo1 As String, ByVal sText1 As TextBox, ByVal sCombo2 As ComboBox, ByVal sTABLE As String)

        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim sSQL As String
        Dim uNI As String
        rs = New ADODB.Recordset



        sSQL = "SELECT * FROM " & sTABLE & " WHERE Name = '" & sCombo1 & "'"

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("proizv").Value) Then uNI = .Fields("proizv").Value

            Dim PROYZV As ADODB.Recordset
            PROYZV = New ADODB.Recordset
            PROYZV.Open("SELECT * FROM SPR_PROIZV WHERE iD=" & uNI, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With PROYZV
                sCombo2.Text = .Fields("proizv").Value
            End With
            PROYZV.Close()
            PROYZV = Nothing

            If Not IsDBNull(.Fields("A").Value) Then sText1.Text = .Fields("A").Value

        End With

        rs.Close()
        rs = Nothing


    End Sub

    Public Sub ExLoadParTwo(ByVal sCombo1 As String, ByVal sCombo2 As ComboBox, ByVal sTABLE As String)

        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim sSQL As String
        Dim uNI As String
        rs = New ADODB.Recordset



        sSQL = "SELECT * FROM " & sTABLE & " WHERE Name = '" & sCombo1 & "'"

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("proizv").Value) Then uNI = .Fields("proizv").Value

            Dim PROYZV As ADODB.Recordset
            PROYZV = New ADODB.Recordset
            PROYZV.Open("SELECT * FROM SPR_PROIZV WHERE iD=" & uNI, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With PROYZV
                sCombo2.Text = .Fields("proizv").Value
            End With
            PROYZV.Close()
            PROYZV = Nothing

        End With

        rs.Close()
        rs = Nothing


    End Sub

    Public Sub REMONT_SEND_MASTER(ByVal sID As String)

        Dim sSQL, sSQL1, a1, b1, c1, d1, e1, g1, h1, i1, j1, k1, l1, PREFs, m1, smtp, frm, srok As String

        sSQL = "SELECT * FROM Remont where id =" & sID

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            a1 = .Fields("Date").Value
            b1 = .Fields("Id_Comp").Value
            c1 = .Fields("Remont").Value
            d1 = .Fields("Master").Value
            e1 = .Fields("otvetstv").Value
            g1 = .Fields("name_of_remont").Value
            l1 = .Fields("istochnik").Value
            PREFs = .Fields("PREF").Value

            srok = .Fields("srok").Value
        End With
        rs.Close()
        rs = Nothing

        sSQL1 = "SELECT * FROM SPR_Master where Name ='" & d1 & "'"
        rs = New ADODB.Recordset
        rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            m1 = .Fields("B").Value
            smtp = .Fields("C").Value
        End With
        rs.Close()
        rs = Nothing

        sSQL1 = "SELECT * FROM CONFIGURE"
        rs = New ADODB.Recordset
        rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            frm = .Fields("nr").Value
        End With
        rs.Close()
        rs = Nothing

        If PREFs = "C" Then

            sSQL1 = "SELECT * FROM kompy where id =" & b1
            rs = New ADODB.Recordset
            rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            With rs
                h1 = .Fields("NET_NAME").Value
                i1 = .Fields("FILIAL").Value
                j1 = .Fields("MESTO").Value
                k1 = .Fields("kabn").Value
            End With
            rs.Close()
            rs = Nothing

        Else

            Select Case PREFs

                Case "G"


                    sSQL1 = "SELECT * FROM SPR_FILIAL where id =" & b1
                    rs = New ADODB.Recordset
                    rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    With rs
                        i1 = .Fields("FILIAL").Value

                    End With
                    rs.Close()
                    rs = Nothing

                Case "O"

                    sSQL1 = "SELECT * FROM SPR_OTD_FILIAL where id =" & b1
                    rs = New ADODB.Recordset
                    rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    With rs
                        i1 = .Fields("FILIAL").Value
                        j1 = .Fields("N_Otd").Value
                        'k1 = .Fields("MESTO").Value

                    End With
                    rs.Close()
                    rs = Nothing

                Case "K"

                    sSQL1 = "SELECT * FROM SPR_KAB where id =" & b1
                    rs = New ADODB.Recordset
                    rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    With rs
                        i1 = .Fields("N_F").Value
                        j1 = .Fields("N_M").Value
                        k1 = .Fields("Name").Value

                    End With
                    rs.Close()
                    rs = Nothing

            End Select

        End If

        If Len(m1) <> 0 Then

        Else

            MsgBox("Отсутствует электронная почта у мастера", MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If

        If Len(smtp) <> 0 Then

        Else

            MsgBox("Не указан сервер SMTP", MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If


        If Len(frm) = 0 Then

            MsgBox("Не заполнен адрес для ответа", MsgBoxStyle.Information, ProGramName)
            Exit Sub

        End If



        If Len(l1) = 0 Then l1 = "Источник не известен. "


        i1 = "Филиал - " & i1 & ", "
        j1 = "Отдел - " & j1 & ", "
        k1 = "Кабинет - " & k1 & ". "
        h1 = "Объект - " & h1 & " "


        Dim Subject As String
        Dim Body As String

        Dim bAns As Boolean = True
        Dim sParams As String


        Dim sTEXT As TextBox
        sTEXT = New TextBox
        sTEXT.Multiline = True
        sTEXT.Text = "Здравствуйте " & d1 & ", " _
 + vbNewLine + "получено сообщение от " & l1 & ": " _
 & vbNewLine & c1 _
 & vbNewLine & "Срок исполнения: " & srok _
 & vbNewLine & h1 _
 & vbNewLine & i1 _
 & vbNewLine & j1 _
 & vbNewLine & k1

        Subject = "БКО::Ремонт " & g1
        sParams = m1

        On Error GoTo err_

        Dim client As New SmtpClient(smtp)
        Dim fromAdr As MailAddress = New MailAddress(frm, ProGramName, System.Text.Encoding.UTF8)
        Dim toAdr As MailAddress = New MailAddress(m1)
        Dim message As MailMessage = New MailMessage(fromAdr, toAdr)
        message.Subject = Subject
        message.SubjectEncoding = System.Text.Encoding.UTF8

        message.Body = sTEXT.Text
        message.BodyEncoding = System.Text.Encoding.UTF8
        'Dim attach As New Attachment("c:\1.txt")
        'message.Attachments.Add(attach)

        client.Send(message)
        message.Dispose()

        sTEXT = Nothing


        MsgBox("Сообщение отправлено", MsgBoxStyle.Information, ProGramName)
        Exit Sub
err_:
        MsgBox(Err.Description)

    End Sub

End Module
