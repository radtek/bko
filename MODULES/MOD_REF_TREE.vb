Imports System.Threading

Module MOD_REF_TREE
    Private lbl_M_F As String
    Private lbl_M_F1 As String
    Private lbl_M_F2 As String
    Private FILIAL1, OTDEL1, KABINET1 As String
    Private lstgroups1 As TreeView
    Private BrancheNode1 As TreeNode
    Private DepatrmentNode1 As TreeNode
    Private OfficeNode1 As TreeNode


    Private Sub FILING_FILIAL()
        Dim zFIL As String

        If Len(FILIAL1) = 0 Then Exit Sub


        zFIL = FILIAL1



        Dim iA1, iA2, iA3, iA4, iA5, iA6, iA7, iA8 As String

        Dim sVISIBLE As String
 
        Dim sSQL4 As String

        Dim rs3 As ADODB.Recordset

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        sVISIBLE = objIniFile.GetString("general", "VisibleALL", "")
        KCKey = objIniFile.GetString("general", "DK", 0)
        DCKey = objIniFile.GetString("general", "Default", 0)
        'Вставляем технику если есть

        Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)

        Select Case sText

            Case 0

                sSQL4 = "SELECT id, mesto, filial, tip_compa, tiptehn, PSEVDONIM, NET_NAME, kabn, Spisan, OS, PRINTER_NAME_4,balans FROM kompy WHERE filial ='" & FILIAL1 & "' AND mesto ='" & OTDEL1 & "' AND kabn ='" & KABINET1 & "'  AND PCL =0 ORDER BY PSEVDONIM, tiptehn"

            Case 1

                sSQL4 = "SELECT id, mesto, filial, tip_compa, tiptehn, PSEVDONIM, NET_NAME, kabn, Spisan, OS, PRINTER_NAME_4,balans FROM kompy WHERE filial ='" & FILIAL1 & "' AND mesto ='" & OTDEL1 & "' AND kabn ='" & KABINET1 & "' AND PCL =0 ORDER BY tiptehn, PSEVDONIM"

        End Select


        rs3 = New ADODB.Recordset
        rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        With rs3
            .MoveFirst()

            Do While Not .EOF

                If Not IsDBNull(.Fields("tip_compa").Value) Then iA1 = .Fields("tip_compa").Value
                If Not IsDBNull(.Fields("NET_NAME").Value) Then iA2 = .Fields("NET_NAME").Value
                If Not IsDBNull(.Fields("PSEVDONIM").Value) Then iA3 = .Fields("PSEVDONIM").Value
                If Not IsDBNull(.Fields("Spisan").Value) Then iA4 = .Fields("Spisan").Value
                If Not IsDBNull(.Fields("tiptehn").Value) Then iA5 = .Fields("tiptehn").Value
                If Not IsDBNull(.Fields("OS").Value) Then iA6 = .Fields("OS").Value
                If Not IsDBNull(.Fields("PRINTER_NAME_4").Value) Then iA7 = .Fields("PRINTER_NAME_4").Value
                If Not IsDBNull(.Fields("Balans").Value) Then iA8 = .Fields("Balans").Value

                FILING_TREE(lstgroups1, iA5, iA1, iA2, iA3, .Fields("id").Value, iA4, BrancheNode1, iA6, iA7, iA8)

                .MoveNext()
            Loop
        End With
        rs3.Close()
        rs3 = Nothing


    End Sub

    Public Sub RefFilTree(ByVal lstgroups As TreeView)
        On Error GoTo ERR1

        lstgroups.HideSelection = False

        'frmComputers.gbTree.ForeColor = Color.Red

        'On Error Resume Next
        Dim sTEN As String
        Dim sVISIBLE As String
        Dim sSQL1 As String
        Dim sSQL2 As String
        Dim sSQL3 As String
        Dim sSQL4 As String
        Dim sSQL5 As String




        Dim iA1, iA2, iA3, iA4, iA5, iA6 As String


        Dim objIniFile As New IniFile(PrPath & "base.ini")
        sVISIBLE = objIniFile.GetString("general", "VisibleALL", "")
        KCKey = objIniFile.GetString("general", "DK", 0)
        DCKey = objIniFile.GetString("general", "Default", 0)

        Dim zBranche As String
        zBranche = objIniFile.GetString("general", "branche", "")

        Dim LNGIniFile As New IniFile(sLANGPATH)

        If Len(zBranche) = 0 Or zBranche = LNGIniFile.GetString("frmComputers", "MSG53", "") Then

            zBranche = "0"

        Else


        End If


        lstgroups.Nodes.Clear()




        lstgroups.ImageList = frmComputers.ilsCommands

        Dim rs As ADODB.Recordset
        Dim rs2 As ADODB.Recordset
        Dim rs3 As ADODB.Recordset
        Dim rs4 As ADODB.Recordset
        Dim rs5 As ADODB.Recordset
        Dim rs6 As ADODB.Recordset
        Dim rs7 As ADODB.Recordset

        rs3 = New ADODB.Recordset
        rs6 = New ADODB.Recordset


        Dim strItemText As String
        Dim unamS2, unamS As Integer


        rs7 = New ADODB.Recordset
        rs7.Open("SELECT count(*) as t_nim FROM SPR_KAB", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs7
            unamS2 = .Fields("t_nim").Value
        End With

        rs7.Close()
        rs7 = Nothing


        If unamS2 = 0 Then

        Else
            If sVISIBLE = 1 Then
                sSQL5 = "SELECT id, Name, N_F, N_M FROM SPR_KAB ORDER BY N_F, N_M, Name"
            Else
                sSQL5 = "SELECT id, Name, N_F, N_M FROM SPR_KAB where Arhiv=0 ORDER BY N_F, N_M, Name"
            End If

            rs7 = New ADODB.Recordset
            rs7.Open(sSQL5, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        End If


        'Компы


        rs6.Open("SELECT count(*) as t_n FROM SPR_MESTO", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs6
            unamS = .Fields("t_n").Value
        End With
        rs6.Close()
        rs6 = Nothing



        Dim unameS As String
        Dim unameS2 As String
        Dim unameS3 As String
        Dim unameS4 As String

        'Верхний нулевой уровень - вставляем название организации
        Dim rsG As ADODB.Recordset
        rsG = New ADODB.Recordset

        rsG.Open("SELECT ORG FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim ORG As String

        With rsG
            If Not IsDBNull(.Fields("ORG").Value) Then ORG = .Fields("ORG").Value
        End With

        rsG.Close()
        rsG = Nothing

        Dim nodeRoot As New TreeNode(ORG, 0, 0)
        nodeRoot.Tag = "ROOT" & GENID()
        lstgroups.Nodes.Add(nodeRoot)


        ''My.Application.DoEvents()

        'lstgroups.Invoke()

        'Филиалы Первый уровень дерева
        'Проверяем все показывать или только активные

        If zBranche = "0" Then

            If sVISIBLE = 1 Then
                sSQL1 = "SELECT id, Filial FROM SPR_FILIAL ORDER BY Filial"
            Else
                sSQL1 = "SELECT id, Filial FROM SPR_FILIAL where Arhiv=0 ORDER BY Filial"
            End If

        Else

            If sVISIBLE = 1 Then
                sSQL1 = "SELECT id, Filial FROM SPR_FILIAL where filial ='" & zBranche & "' ORDER BY Filial"
            Else
                sSQL1 = "SELECT id, Filial FROM SPR_FILIAL where Arhiv=0 and filial ='" & zBranche & "' ORDER BY Filial"
            End If

        End If



        rs = New ADODB.Recordset
        rs.Open(sSQL1, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                ''My.Application.DoEvents()
                Dim BrancheNode As New TreeNode(.Fields("filial").Value, 0, 0)
                BrancheNode.Tag = "G|" & .Fields("id").Value
                sTEN = "G|" & .Fields("id").Value
                nodeRoot.Nodes.Add(BrancheNode)


                FILIAL1 = .Fields("filial").Value
                OTDEL1 = ""
                KABINET1 = ""
                BrancheNode1 = BrancheNode
                lstgroups1 = lstgroups


                unameS = .Fields("filial").Value

                If KCKey = 0 And Len(DCKey) <> 0 Then

                    If DCKey = sTEN Then
                        lstgroups.SelectedNode = BrancheNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

                BrancheNode.ForeColor = Color.DarkBlue
                'BrancheNode.NodeFont = New Font(BrancheNode.NodeFont, FontStyle.Bold)


                'Вставляем технику если есть
                Dim cFil As String
                sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE filial ='" & unameS & "' AND mesto =''"
                rs3 = New ADODB.Recordset
                rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                With rs3
                    cFil = .Fields("t_n").Value
                End With
                rs3.Close()
                rs3 = Nothing


                If cFil <> 0 Then
                    My.Application.DoEvents()

                    'lstgroups.BeginInvoke(New MethodInvoker(AddressOf FILING_FILIAL))

                    If frmComputers.lstGroups.InvokeRequired Then
                        frmComputers.lstGroups.Invoke(New MethodInvoker(AddressOf FILING_FILIAL))
                    Else
                        Call FILING_FILIAL()
                    End If

                End If

                'Отделы в филиалах Второй уровень дерева

                If sVISIBLE = 1 Then
                    sSQL2 = "SELECT id, Filial, N_Otd FROM SPR_OTD_FILIAL WHERE filial='" & unameS & "' ORDER BY Filial, N_Otd"
                Else
                    sSQL2 = "SELECT id, Filial, N_Otd FROM SPR_OTD_FILIAL where filial='" & unameS & "' AND Arhiv=0 ORDER BY Filial, N_Otd"
                End If
                rs2 = New ADODB.Recordset
                rs2.Open(sSQL2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs2
                    .MoveFirst()
                    Do While Not .EOF

                        If .Fields("filial").Value = unameS Then

                            Dim DepatrmentNode As New TreeNode(.Fields("N_Otd").Value, 1, 1)
                            DepatrmentNode.Tag = "O|" & .Fields("id").Value
                            sTEN = "O|" & .Fields("id").Value
                            BrancheNode.Nodes.Add(DepatrmentNode)
                            unameS2 = .Fields("N_Otd").Value

                            DepatrmentNode1 = DepatrmentNode
                            BrancheNode1 = DepatrmentNode

                            OTDEL1 = .Fields("N_Otd").Value
                            KABINET1 = ""

                            If KCKey = 0 And Len(DCKey) <> 0 Then

                                If DCKey = sTEN Then
                                    lstgroups.SelectedNode = DepatrmentNode
                                    lstgroups.SelectedNode.Expand()
                                End If
                            End If

                            DepatrmentNode.ForeColor = Color.DarkGreen
                            'DepatrmentNode.NodeFont = New Font(DepatrmentNode.NodeFont, FontStyle.Italic)


                            sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE filial ='" & unameS & "' AND mesto ='" & unameS2 & "' AND kabn=''"
                            rs3 = New ADODB.Recordset
                            rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs3
                                cFil = .Fields("t_n").Value
                            End With
                            rs3.Close()
                            rs3 = Nothing


                            If cFil <> 0 Then
                                My.Application.DoEvents()

                                'lstgroups.BeginInvoke(New MethodInvoker(AddressOf FILING_FILIAL))

                                If frmComputers.lstGroups.InvokeRequired Then
                                    frmComputers.lstGroups.Invoke(New MethodInvoker(AddressOf FILING_FILIAL))
                                Else
                                    Call FILING_FILIAL()
                                End If


                              


                            End If


                            'Кабинеты Третий уровень дерева

                            If unamS2 > 0 Then

                                If sVISIBLE = 1 Then
                                    sSQL5 = "SELECT id, Name, N_F, N_M FROM SPR_KAB WHERE N_F='" & unameS & "' AND N_M ='" & unameS2 & "' ORDER BY N_F, N_M, Name"
                                Else
                                    sSQL5 = "SELECT id, Name, N_F, N_M FROM SPR_KAB where N_F='" & unameS & "' AND N_M ='" & unameS2 & "' AND Arhiv=0 ORDER BY N_F, N_M, Name"
                                End If

                                rs7 = New ADODB.Recordset
                                rs7.Open(sSQL5, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                With rs7
                                    .MoveFirst()
                                    Do While Not .EOF

                                        Dim OfficeNode As New TreeNode(.Fields("name").Value, 2, 2)
                                        OfficeNode.Tag = "K|" & .Fields("id").Value
                                        sTEN = "K|" & .Fields("id").Value
                                        DepatrmentNode.Nodes.Add(OfficeNode)

                                        OfficeNode1 = OfficeNode
                                        BrancheNode1 = OfficeNode
                                        KABINET1 = .Fields("name").Value

                                        unameS3 = .Fields("name").Value

                                        If KCKey = 0 And Len(DCKey) <> 0 Then

                                            If DCKey = sTEN Then
                                                lstgroups.SelectedNode = OfficeNode
                                                lstgroups.SelectedNode.Expand()
                                            End If
                                        End If

                                        OfficeNode.ForeColor = Color.DarkGoldenrod


                                        sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE filial ='" & unameS & "' AND mesto ='" & unameS2 & "' AND kabn='" & unameS3 & "'"
                                        rs3 = New ADODB.Recordset
                                        rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                                        With rs3
                                            cFil = .Fields("t_n").Value
                                        End With
                                        rs3.Close()
                                        rs3 = Nothing


                                        If cFil <> 0 Then
                                            My.Application.DoEvents()
                                            If frmComputers.lstGroups.InvokeRequired Then
                                                frmComputers.lstGroups.Invoke(New MethodInvoker(AddressOf FILING_FILIAL))
                                            Else
                                                Call FILING_FILIAL()
                                            End If



                                        End If

                                        .MoveNext()
                                    Loop
                                End With
                                rs7.Close()
                                rs7 = Nothing

                            End If
                            'Конец кабинетов



                        End If


                        .MoveNext()
                    Loop
                End With
                rs2.Close()
                rs2 = Nothing

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


        If KCKey = 0 And Len(DCKey) = 0 Then

            lstgroups.SelectedNode = nodeRoot
            Dim tNode As New TreeNode
            tNode = lstgroups.Nodes(0)
            tNode.Expand()

        End If


exitsub:


        Exit Sub
ERR1:
        'MsgBox Err.Description
        Select Case Err.Number
            Case 3021 'ignore, no entries in list
                'MsgBox(Err.Description, vbCritical, "KZ")
                Resume Next
            Case Else

                MsgBox(Err.Description, vbCritical, "KZ")

        End Select


    End Sub

    Public Sub FILING_TREE(ByVal lstgroups As TreeView, ByVal iTipTehn As String, ByVal TipPC As String, ByVal NET_NAME As String, ByVal PSEVDONIM As String, ByVal iD As String, ByVal Spisan As String, ByVal DepNode As TreeNode, ByVal OS As String, ByVal n_set As String, ByVal balans As String)

        Dim iC As String
        Dim iA As String
        Dim iB As String
        Dim sTREENAME As String
        Dim N_NAME As String
        Dim P_NAME As String
        Dim L_NAME As String
        Dim iPSid As Long

        Dim uNameS As String

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        KCKey = objIniFile.GetString("general", "DK", 0)
        DCKey = objIniFile.GetString("general", "Default", 0)
        sTREENAME = objIniFile.GetString("general", "NETNAME", "1")

        If iTipTehn = "PC" Then
            iC = TipPC
        Else
            iC = "Рабочая станция"
        End If

        If iC = "Ноутбук" Or iC = "notebook" Or iC = "Notebook" Or iC = "NoteBook" Then
            iC = "Ноутбук"
        End If

        If iC = "КПК" Or iC = "Pocket PC" Or iC = "Pocket" Or iC = "Palm" Then
            iC = "КПК"
        End If

        If iC = "Сервер" Or iC = "Server" Or iC = "Сервер для тонких клиентов" Or iC = "Сервер видео наблюдения" Then
            iC = "Сервер"
        End If

        'Pocket PC

        Select Case iC

            Case "Рабочая станция"
                iA = 4
                iB = 4

            Case "Сервер"

                iA = 3
                iB = 3

            Case "КПК"
                iA = 31
                iB = 31

            Case "Ноутбук"
                iA = 5
                iB = 5

            Case Else
                iA = 4
                iB = 4


        End Select


        'Определяем подчиненное оборудование (в составе)
        Dim d() As String

        If iTipTehn = "MONITOR" Then

            If Len(OS) > 0 Then
                d = Split(OS, "№")
            End If

        End If

        'Dim TEHNodePS As TreeNode

        Select Case sTREENAME

            Case 0
                N_NAME = NET_NAME
                P_NAME = PSEVDONIM

                If Len(N_NAME) = 0 Then
                    N_NAME = "NoName"
                End If

                If Len(P_NAME) = 0 Then
                    P_NAME = "NoName"
                End If
                L_NAME = N_NAME & " (" & P_NAME & ")"

            Case 2
                P_NAME = PSEVDONIM

                If Len(P_NAME) = 0 Then
                    P_NAME = "NoName"
                End If
                L_NAME = P_NAME

            Case 1

                N_NAME = NET_NAME
                If Len(N_NAME) = 0 Then
                    N_NAME = "NoName"
                End If

                L_NAME = N_NAME

        End Select

        ''My.Application.DoEvents()
        Select Case iTipTehn

            Case "CNT"

                Dim uname As String

                On Error Resume Next


                If Len(NET_NAME) = 0 Then

                    uname = ""

                Else

                    Dim rsOT As ADODB.Recordset
                    rsOT = New ADODB.Recordset
                    rsOT.Open("SELECT A FROM spr_other where Name ='" & NET_NAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rsOT
                        If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value
                    End With

                    rsOT.Close()
                    rsOT = Nothing

                End If

                Dim TEHNodePS As New TreeNode(L_NAME, uname, uname)
                'Dim TEHNode As New TreeNode(L_NAME, iA, iA)
                TEHNodePS.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNodePS)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNodePS.ForeColor = Color.Red

                End If


                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNodePS.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNodePS
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

                '#####################################################################
                '#####################################################################
                '#                          КОНТЕЙНЕР
                '#####################################################################
                '#####################################################################

                Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)
                Dim sSQL4 As String

                sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & iD

                Dim rs3 As ADODB.Recordset
                rs3 = New ADODB.Recordset
                rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                Dim sCount As String
                With rs3
                    sCount = .Fields("t_n").Value
                End With

                rs3.Close()
                rs3 = Nothing

                If sCount > 0 Then



                    Select Case sText

                        Case 0

                            sSQL4 = "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4 FROM kompy WHERE PCL =" & iD & " ORDER BY PSEVDONIM, tiptehn"

                        Case 1

                            sSQL4 = "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4 FROM kompy WHERE PCL =" & iD & " ORDER BY tiptehn, PSEVDONIM"

                    End Select


                    rs3 = New ADODB.Recordset
                    rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs3
                        .MoveFirst()

                        Do While Not .EOF

                            Select Case sTREENAME

                                Case 0
                                    N_NAME = .Fields("NET_NAME").Value
                                    P_NAME = .Fields("PSEVDONIM").Value

                                    If Len(N_NAME) = 0 Then
                                        N_NAME = "NoName"
                                    End If

                                    If Len(P_NAME) = 0 Then
                                        P_NAME = "NoName"
                                    End If
                                    L_NAME = N_NAME & " (" & P_NAME & ")"

                                Case 2
                                    P_NAME = .Fields("PSEVDONIM").Value

                                    If Len(P_NAME) = 0 Then
                                        P_NAME = "NoName"
                                    End If
                                    L_NAME = P_NAME

                                Case 1

                                    N_NAME = .Fields("NET_NAME").Value
                                    If Len(N_NAME) = 0 Then
                                        N_NAME = "NoName"
                                    End If

                                    L_NAME = N_NAME

                            End Select


                            Select Case .Fields("tiptehn").Value

                                Case "NET"
                                    Dim TEHNodePC As New TreeNode(L_NAME, 10, 10)
                                    TEHNodePC.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNodePC)
                                    iD = .Fields("id").Value


                                    Select Case n_set

                                        Case "Off"
                                            TEHNodePC.ForeColor = Color.Red

                                        Case "Defective"

                                            TEHNodePC.ForeColor = Color.Blue

                                        Case Else


                                            TEHNodePC.ForeColor = Color.Green

                                    End Select



                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNodePC.ForeColor = Color.Red
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNodePC.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = iD Then
                                            lstgroups.SelectedNode = TEHNodePC
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "PC"

                                    iC = .Fields("TIP_COMPA").Value


                                    If iC = "Ноутбук" Or iC = "notebook" Or iC = "Notebook" Or iC = "NoteBook" Then
                                        iC = "Ноутбук"
                                    End If

                                    If iC = "КПК" Or iC = "Pocket PC" Or iC = "Pocket" Or iC = "Palm" Then
                                        iC = "КПК"
                                    End If

                                    If iC = "Сервер" Or iC = "Server" Or iC = "Сервер для тонких клиентов" Or iC = "Сервер видео наблюдения" Then
                                        iC = "Сервер"
                                    End If

                                    'Pocket PC

                                    Select Case iC

                                        Case "Рабочая станция"
                                            iA = 4
                                            iB = 4

                                        Case "Сервер"

                                            iA = 3
                                            iB = 3

                                        Case "КПК"
                                            iA = 31
                                            iB = 31

                                        Case "Ноутбук"
                                            iA = 5
                                            iB = 5

                                        Case Else
                                            iA = 4
                                            iB = 4


                                    End Select


                                    Dim TEHNodePC As New TreeNode(L_NAME, iA, iB)
                                    iD = .Fields("id").Value
                                    TEHNodePC.Tag = "C|" & .Fields("id").Value
                                    iPSid = .Fields("id").Value

                                    TEHNodePS.Nodes.Add(TEHNodePC)

                                    'TEHNode.ForeColor = Color.Blue

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNodePC.ForeColor = Color.Red
                                        TEHNodePC.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNodePC.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNodePC
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If


                                    '########################################################################
                                    '########################################################################
                                    '########################################################################

                                    ' Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)
                                    ' Dim sSQL4 As String


                                    sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & iD

                                    'Dim rs3 As ADODB.Recordset
                                    rs3 = New ADODB.Recordset
                                    rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                    ' Dim sCount As String
                                    With rs3
                                        sCount = .Fields("t_n").Value
                                    End With

                                    rs3.Close()
                                    rs3 = Nothing

                                    If sCount > 0 Then



                                        Select Case sText

                                            Case 0

                                                sSQL4 = "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa FROM kompy WHERE PCL =" & iD & " ORDER BY PSEVDONIM, tiptehn"

                                            Case 1

                                                sSQL4 = "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa FROM kompy WHERE PCL =" & iD & " ORDER BY tiptehn, PSEVDONIM"

                                        End Select


                                        rs3 = New ADODB.Recordset
                                        rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                        With rs3
                                            .MoveFirst()

                                            Do While Not .EOF

                                                Select Case sTREENAME

                                                    Case 0
                                                        N_NAME = .Fields("NET_NAME").Value
                                                        P_NAME = .Fields("PSEVDONIM").Value

                                                        If Len(N_NAME) = 0 Then
                                                            N_NAME = "NoName"
                                                        End If

                                                        If Len(P_NAME) = 0 Then
                                                            P_NAME = "NoName"
                                                        End If
                                                        L_NAME = N_NAME & " (" & P_NAME & ")"

                                                    Case 2
                                                        P_NAME = .Fields("PSEVDONIM").Value

                                                        If Len(P_NAME) = 0 Then
                                                            P_NAME = "NoName"
                                                        End If
                                                        L_NAME = P_NAME

                                                    Case 1

                                                        N_NAME = .Fields("NET_NAME").Value
                                                        If Len(N_NAME) = 0 Then
                                                            N_NAME = "NoName"
                                                        End If

                                                        L_NAME = N_NAME

                                                End Select


                                                Select Case .Fields("tiptehn").Value


                                                    Case "Printer"
                                                        Dim TEHNode As New TreeNode(L_NAME, 7, 7)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "MFU"

                                                        Dim TEHNode As New TreeNode(L_NAME, 8, 8)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If


                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If


                                                    Case "SCANER"

                                                        Dim TEHNode As New TreeNode(L_NAME, 14, 14)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "ZIP"
                                                        Dim TEHNode As New TreeNode(L_NAME, 15, 15)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()

                                                            End If
                                                        End If

                                                    Case "PHONE"
                                                        Dim TEHNode As New TreeNode(L_NAME, 12, 12)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()

                                                            End If
                                                        End If


                                                    Case "OT"

                                                        ' Dim uname As String

                                                        On Error Resume Next


                                                        If Len(.Fields("tip_compa").Value) = 0 Then

                                                            uname = ""
                                                        Else

                                                            Dim rsOT As ADODB.Recordset
                                                            rsOT = New ADODB.Recordset
                                                            rsOT.Open("SELECT A FROM spr_other where Name ='" & .Fields("tip_compa").Value & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                                            With rsOT
                                                                '.MoveFirst()
                                                                'Do While Not .EOF

                                                                If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                                                                '.MoveNext()
                                                                'Loop
                                                            End With


                                                            rsOT.Close()
                                                            rsOT = Nothing


                                                        End If


                                                        If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                                                            iA = 16
                                                        Else
                                                            iA = uname
                                                        End If


                                                        Dim TEHNode As New TreeNode(L_NAME, iA, iA)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "MONITOR"

                                                        Dim TEHNode As New TreeNode(L_NAME, 17, 17)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If


                                                        '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                                                    Case "USB"
                                                        Dim TEHNode As New TreeNode(L_NAME, 64, 64)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)
                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "SOUND"
                                                        Dim TEHNode As New TreeNode(L_NAME, 44, 44)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)
                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If


                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "IBP"
                                                        Dim TEHNode As New TreeNode(L_NAME, 41, 41)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)
                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If


                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "FS"
                                                        Dim TEHNode As New TreeNode(L_NAME, 65, 65)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "KEYB"
                                                        Dim TEHNode As New TreeNode(L_NAME, 46, 46)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)
                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If

                                                    Case "MOUSE"
                                                        Dim TEHNode As New TreeNode(L_NAME, 47, 47)
                                                        TEHNode.Tag = "C|" & .Fields("id").Value
                                                        TEHNodePC.Nodes.Add(TEHNode)

                                                        If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                                            TEHNode.ForeColor = Color.Red
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                                        End If

                                                        If balans = "1" Or balans = "True" Or balans = "-1" Then
                                                            TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                                        End If

                                                        If KCKey <> 0 Then
                                                            If KCKey = .Fields("id").Value Then
                                                                lstgroups.SelectedNode = TEHNode
                                                                lstgroups.SelectedNode.Expand()
                                                            End If
                                                        End If
                                                        '--------------VIP_Graff Добавление новой перефирии Конец------------------

                                                    Case Else


                                                End Select


                                                .MoveNext()
                                            Loop
                                        End With
                                        rs3.Close()
                                        rs3 = Nothing

                                    End If


                                Case "Printer"

                                    Dim TEHNode As New TreeNode(L_NAME, 7, 7)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "MFU"

                                    Dim TEHNode As New TreeNode(L_NAME, 8, 8)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If


                                Case "SCANER"

                                    Dim TEHNode As New TreeNode(L_NAME, 14, 14)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "ZIP"
                                    Dim TEHNode As New TreeNode(L_NAME, 15, 15)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()

                                        End If
                                    End If

                                Case "PHONE"
                                    Dim TEHNode As New TreeNode(L_NAME, 12, 12)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()

                                        End If
                                    End If


                                Case "OT"

                                    'Dim uname As String

                                    On Error Resume Next


                                    If Len(.Fields("tip_compa").Value) = 0 Then

                                        uname = ""
                                    Else

                                        Dim rsOT As ADODB.Recordset
                                        rsOT = New ADODB.Recordset
                                        rsOT.Open("SELECT A FROM spr_other where Name ='" & .Fields("tip_compa").Value & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                        With rsOT
                                            '.MoveFirst()
                                            'Do While Not .EOF

                                            If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                                            '.MoveNext()
                                            'Loop
                                        End With


                                        rsOT.Close()
                                        rsOT = Nothing


                                    End If


                                    If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                                        iA = 16
                                    Else
                                        iA = uname
                                    End If


                                    Dim TEHNode As New TreeNode(L_NAME, iA, iA)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "MONITOR"

                                    Dim TEHNode As New TreeNode(L_NAME, 17, 17)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If


                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If


                                    '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                                Case "USB"
                                    Dim TEHNode As New TreeNode(L_NAME, 64, 64)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "SOUND"
                                    Dim TEHNode As New TreeNode(L_NAME, 44, 44)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "IBP"
                                    Dim TEHNode As New TreeNode(L_NAME, 41, 41)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "FS"
                                    Dim TEHNode As New TreeNode(L_NAME, 65, 65)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "KEYB"
                                    Dim TEHNode As New TreeNode(L_NAME, 46, 46)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "MOUSE"
                                    Dim TEHNode As New TreeNode(L_NAME, 47, 47)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If
                                    '--------------VIP_Graff Добавление новой перефирии Конец------------------

                                Case Else


                            End Select


                            .MoveNext()
                        Loop
                    End With
                    rs3.Close()
                    rs3 = Nothing

                End If


                '#####################################################################
                '#####################################################################
                '#####################################################################

            Case "PC"

                Dim TEHNodePS As New TreeNode(L_NAME, iA, iB)

                TEHNodePS.Tag = "C|" & iD
                iPSid = iD

                DepNode.Nodes.Add(TEHNodePS)

                'TEHNode.ForeColor = Color.Blue

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNodePS.ForeColor = Color.Red
                    TEHNodePS.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNodePS.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNodePS
                        lstgroups.SelectedNode.Expand()
                    End If
                End If


                '########################################################################
                '########################################################################
                '########################################################################

                Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)
                Dim sSQL4 As String


                sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & iD

                Dim rs3 As ADODB.Recordset
                rs3 = New ADODB.Recordset
                rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                Dim sCount As String
                With rs3
                    sCount = .Fields("t_n").Value
                End With

                rs3.Close()
                rs3 = Nothing

                If sCount > 0 Then



                    Select Case sText

                        Case 0

                            sSQL4 = "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4 FROM kompy WHERE PCL =" & iD & " ORDER BY PSEVDONIM, tiptehn"

                        Case 1

                            sSQL4 = "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4 FROM kompy WHERE PCL =" & iD & " ORDER BY tiptehn, PSEVDONIM"

                    End Select


                    rs3 = New ADODB.Recordset
                    rs3.Open(sSQL4, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs3
                        .MoveFirst()

                        Do While Not .EOF

                            Select Case sTREENAME

                                Case 0
                                    N_NAME = .Fields("NET_NAME").Value
                                    P_NAME = .Fields("PSEVDONIM").Value

                                    If Len(N_NAME) = 0 Then
                                        N_NAME = "NoName"
                                    End If

                                    If Len(P_NAME) = 0 Then
                                        P_NAME = "NoName"
                                    End If
                                    L_NAME = N_NAME & " (" & P_NAME & ")"

                                Case 2
                                    P_NAME = .Fields("PSEVDONIM").Value

                                    If Len(P_NAME) = 0 Then
                                        P_NAME = "NoName"
                                    End If
                                    L_NAME = P_NAME

                                Case 1

                                    N_NAME = .Fields("NET_NAME").Value
                                    If Len(N_NAME) = 0 Then
                                        N_NAME = "NoName"
                                    End If

                                    L_NAME = N_NAME

                            End Select


                            Select Case .Fields("tiptehn").Value


                                Case "Printer"
                                    Dim TEHNode As New TreeNode(L_NAME, 7, 7)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "MFU"

                                    Dim TEHNode As New TreeNode(L_NAME, 8, 8)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If


                                Case "SCANER"

                                    Dim TEHNode As New TreeNode(L_NAME, 14, 14)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "ZIP"
                                    Dim TEHNode As New TreeNode(L_NAME, 15, 15)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()

                                        End If
                                    End If

                                Case "PHONE"
                                    Dim TEHNode As New TreeNode(L_NAME, 12, 12)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()

                                        End If
                                    End If


                                Case "OT"

                                    Dim uname As String

                                    On Error Resume Next


                                    If Len(.Fields("tip_compa").Value) = 0 Then

                                        uname = ""
                                    Else

                                        Dim rsOT As ADODB.Recordset
                                        rsOT = New ADODB.Recordset
                                        rsOT.Open("SELECT A FROM spr_other where Name ='" & .Fields("tip_compa").Value & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                        With rsOT
                                            '.MoveFirst()
                                            'Do While Not .EOF

                                            If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                                            '.MoveNext()
                                            'Loop
                                        End With


                                        rsOT.Close()
                                        rsOT = Nothing


                                    End If


                                    If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                                        iA = 16
                                    Else
                                        iA = uname
                                    End If


                                    Dim TEHNode As New TreeNode(L_NAME, iA, iA)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "MONITOR"

                                    Dim TEHNode As New TreeNode(L_NAME, 17, 17)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)

                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If


                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If


                                    '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                                Case "USB"
                                    Dim TEHNode As New TreeNode(L_NAME, 64, 64)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "SOUND"
                                    Dim TEHNode As New TreeNode(L_NAME, 44, 44)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "IBP"
                                    Dim TEHNode As New TreeNode(L_NAME, 41, 41)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "FS"
                                    Dim TEHNode As New TreeNode(L_NAME, 65, 65)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "KEYB"
                                    Dim TEHNode As New TreeNode(L_NAME, 46, 46)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If

                                Case "MOUSE"
                                    Dim TEHNode As New TreeNode(L_NAME, 47, 47)
                                    TEHNode.Tag = "C|" & .Fields("id").Value
                                    TEHNodePS.Nodes.Add(TEHNode)
                                    If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                                        TEHNode.ForeColor = Color.Red
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                                    End If

                                    If balans = "1" Or balans = "True" Or balans = "-1" Then
                                        TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                                    End If

                                    If KCKey <> 0 Then
                                        If KCKey = .Fields("id").Value Then
                                            lstgroups.SelectedNode = TEHNode
                                            lstgroups.SelectedNode.Expand()
                                        End If
                                    End If
                                    '--------------VIP_Graff Добавление новой перефирии Конец------------------

                                Case Else


                            End Select


                            .MoveNext()
                        Loop
                    End With
                    rs3.Close()
                    rs3 = Nothing

                End If


            Case "Printer"
                Dim TEHNode As New TreeNode(L_NAME, 7, 7)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "MFU"

                Dim TEHNode As New TreeNode(L_NAME, 8, 8)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "KOpir"
                Dim TEHNode As New TreeNode(L_NAME, 9, 9)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "NET"

                Dim TEHNode As New TreeNode(L_NAME, 10, 10)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                Select Case n_set

                    Case "Off"
                        TEHNode.ForeColor = Color.Red

                    Case "Defective"

                        TEHNode.ForeColor = Color.Blue


                    Case Else

                        TEHNode.ForeColor = Color.Green

                End Select



                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "PHOTO"
                Dim TEHNode As New TreeNode(L_NAME, 11, 11)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "PHONE"
                Dim TEHNode As New TreeNode(L_NAME, 12, 12)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "FAX"
                Dim TEHNode As New TreeNode(L_NAME, 13, 13)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "SCANER"

                Dim TEHNode As New TreeNode(L_NAME, 14, 14)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "ZIP"
                Dim TEHNode As New TreeNode(L_NAME, 15, 15)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()

                    End If
                End If

            Case "OT"


                Dim uname As String

                On Error Resume Next


                If Len(TipPC) = 0 Then

                    uname = ""
                Else

                    Dim rsOT As ADODB.Recordset
                    rsOT = New ADODB.Recordset
                    rsOT.Open("SELECT A FROM spr_other where Name ='" & TipPC & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rsOT
                        '.MoveFirst()
                        'Do While Not .EOF

                        If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                        '    .MoveNext()

                        'Loop
                    End With


                    rsOT.Close()
                    rsOT = Nothing



                End If


                If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                    iA = 16
                Else
                    iA = uname
                End If


                Dim TEHNode As New TreeNode(L_NAME, iA, iA)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If


                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "MONITOR"


                Dim TEHNode As New TreeNode(L_NAME, 17, 17)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

                '--------------VIP_Graff Добавление новой перефирии Начало-----------------
            Case "USB"
                Dim TEHNode As New TreeNode(L_NAME, 64, 64)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)
                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If
                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "SOUND"
                Dim TEHNode As New TreeNode(L_NAME, 44, 44)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)
                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "IBP"
                Dim TEHNode As New TreeNode(L_NAME, 41, 41)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)
                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "FS"
                Dim TEHNode As New TreeNode(L_NAME, 65, 65)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)
                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "KEYB"
                Dim TEHNode As New TreeNode(L_NAME, 46, 46)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)
                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If

            Case "MOUSE"
                Dim TEHNode As New TreeNode(L_NAME, 47, 47)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)
                If Spisan = "1" Or Spisan = "True" Or Spisan = "-1" Then
                    TEHNode.ForeColor = Color.Red
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Strikeout)
                End If

                If balans = "1" Or balans = "True" Or balans = "-1" Then
                    TEHNode.NodeFont = New Font(lstgroups.Font, FontStyle.Italic)
                End If

                If KCKey <> 0 Then
                    If KCKey = iD Then
                        lstgroups.SelectedNode = TEHNode
                        lstgroups.SelectedNode.Expand()
                    End If
                End If
                '--------------VIP_Graff Добавление новой перефирии Конец------------------


            Case Else

        End Select



    End Sub



End Module
