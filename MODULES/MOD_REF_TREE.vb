


Module MOD_REF_TREE
    Private lbl_M_F As String
    Private lbl_M_F1 As String
    Private lbl_M_F2 As String
    Private FILIAL1, OTDEL1, KABINET1 As String
    Private lstgroups1 As TreeView
    Private BrancheNode1 As TreeNode
    Private DepatrmentNode1 As TreeNode
    Private OfficeNode1 As TreeNode
    Private FontStyl As FontStyle
    Private iA1, iA2, iA3, iA4, iA5, iA6, iA7, iA8, iID As String

    Private Sub FILING_FILIAL()
        On Error Resume Next

        If Len(FILIAL1) = 0 Then Exit Sub

        Dim sSQL4 As String

        Dim objIniFile As New IniFile(PrPath & "base.ini")

        Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)

        Select Case sText

            Case 0

                sSQL4 =
                    "SELECT id, mesto, filial, tip_compa, tiptehn, PSEVDONIM, NET_NAME, kabn, Spisan, OS, PRINTER_NAME_4,balans FROM kompy WHERE filial ='" &
                    FILIAL1 & "' AND mesto ='" & OTDEL1 & "' AND kabn ='" & KABINET1 &
                    "'  AND PCL =0 ORDER BY PSEVDONIM, tiptehn"

            Case 1

                sSQL4 =
                    "SELECT id, mesto, filial, tip_compa, tiptehn, PSEVDONIM, NET_NAME, kabn, Spisan, OS, PRINTER_NAME_4,balans FROM kompy WHERE filial ='" &
                    FILIAL1 & "' AND mesto ='" & OTDEL1 & "' AND kabn ='" & KABINET1 &
                    "' AND PCL =0 ORDER BY tiptehn, PSEVDONIM"

        End Select

        Dim rs3 As Recordset
        rs3 = New Recordset
        rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

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

                iID = .Fields("id").Value

                FILING_TREE(lstgroups1, iA5, iA1, iA2, iA3, iID, iA4, BrancheNode1, iA6, iA7, iA8)


                .MoveNext()
            Loop
        End With
        rs3.Close()
        rs3 = Nothing
    End Sub

    Public Sub RefFilTree(ByVal lstgroups As TreeView)
        On Error GoTo ERR1

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

        Select Case zBranche

            Case "0"

                zBranche = "0"

            Case LNGIniFile.GetString("frmComputers", "MSG53", "Все")

                zBranche = "0"

        End Select

        lstgroups.Nodes.Clear()

        Select Case sICONS

            Case "32*32"

                sICONS = sICONS

                frmComputers.ilsCommands.ImageSize = New Size(32, 32)
                Tree_Icons_Feel(frmComputers.ilsCommands, "sCMP", "pic\tree\")
            Case Else

                sICONS = "24*24"
                frmComputers.ilsCommands.ImageSize = New Size(24, 24)
                Tree_Icons_Feel(frmComputers.ilsCommands, "sCMP", "pic\tree\")
        End Select

        lstgroups.ImageList = frmComputers.ilsCommands

        Dim rs As Recordset
        Dim rs2 As Recordset
        Dim rs3 As Recordset
        Dim rs4 As Recordset

        Dim strItemText As String
        Dim unamS2, unamS As Integer

        rs = New Recordset
        rs.Open("SELECT count(*) as t_nim FROM SPR_KAB", DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            unamS2 = .Fields("t_nim").Value
        End With
        rs.Close()
        rs = Nothing

        'Компы

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MESTO", DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            unamS = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        Dim unameS As String
        Dim unameS2 As String
        Dim unameS3 As String
        Dim unameS4 As String

        'Верхний нулевой уровень - вставляем название организации

        rs = New Recordset
        rs.Open("SELECT ORG FROM CONFIGURE", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim ORG As String

        With rs
            If Not IsDBNull(.Fields("ORG").Value) Then ORG = .Fields("ORG").Value
        End With

        rs.Close()
        rs = Nothing

        Dim nodeRoot As New TreeNode(ORG, 69, 69)
        nodeRoot.Tag = "ROOT" & GENID()
        lstgroups.Nodes.Add(nodeRoot)

        'Филиалы Первый уровень дерева
        'Проверяем все показывать или только активные

        Select Case zBranche

            Case "0"
                Select Case sVISIBLE

                    Case 1
                        sSQL1 = "SELECT id, Filial FROM SPR_FILIAL ORDER BY Filial"
                    Case Else
                        sSQL1 = "SELECT id, Filial FROM SPR_FILIAL where Arhiv=0 ORDER BY Filial"

                End Select

            Case Else

                Select Case sVISIBLE

                    Case 1
                        sSQL1 = "SELECT id, Filial FROM SPR_FILIAL where filial ='" & zBranche & "' ORDER BY Filial"
                    Case Else
                        sSQL1 = "SELECT id, Filial FROM SPR_FILIAL where Arhiv=0 and filial ='" & zBranche & "' ORDER BY Filial"

                End Select

        End Select

        rs = New Recordset
        rs.Open(sSQL1, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                'My.Application.DoEvents()
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

                    Select Case DCKey

                        Case sTEN

                            lstgroups.SelectedNode = BrancheNode
                            lstgroups.SelectedNode.Expand()

                    End Select

                End If

                BrancheNode.ForeColor = Color.DarkBlue

                'Вставляем технику если есть
                Dim cFil As String
                sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE filial ='" & unameS & "' AND mesto =''"
                rs4 = New Recordset
                rs4.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
                With rs4
                    cFil = .Fields("t_n").Value
                End With
                rs4.Close()
                rs4 = Nothing

                Select Case cFil
                    Case 0
                    Case Else
                        Call FILING_FILIAL()
                End Select

                'Отделы в филиалах Второй уровень дерева

                Select Case sVISIBLE

                    Case 1
                        sSQL2 = "SELECT id, Filial, N_Otd FROM SPR_OTD_FILIAL WHERE filial='" & unameS &
                            "' ORDER BY Filial, N_Otd"
                    Case Else
                        sSQL2 = "SELECT id, Filial, N_Otd FROM SPR_OTD_FILIAL where filial='" & unameS &
                                                    "' AND Arhiv=0 ORDER BY Filial, N_Otd"

                End Select

                rs2 = New Recordset
                rs2.Open(sSQL2, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

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

                                Select Case DCKey

                                    Case sTEN

                                        lstgroups.SelectedNode = DepatrmentNode
                                        lstgroups.SelectedNode.Expand()

                                End Select


                            End If

                            DepatrmentNode.ForeColor = Color.DarkGreen
                            'DepatrmentNode.NodeFont = New Font(DepatrmentNode.NodeFont, FontStyle.Italic)


                            sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE filial ='" & unameS & "' AND mesto ='" &
                                    unameS2 & "' AND kabn=''"
                            rs4 = New Recordset
                            rs4.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
                            With rs4
                                cFil = .Fields("t_n").Value
                            End With
                            rs4.Close()
                            rs4 = Nothing

                            Select Case cFil
                                Case 0
                                Case Else
                                    Call FILING_FILIAL()
                            End Select

                            'Кабинеты Третий уровень дерева

                            If unamS2 > 0 Then

                                If sVISIBLE = 1 Then
                                    sSQL5 = "SELECT id, Name, N_F, N_M FROM SPR_KAB WHERE N_F='" & unameS &
                                            "' AND N_M ='" & unameS2 & "' ORDER BY N_F, N_M, Name"
                                Else
                                    sSQL5 = "SELECT id, Name, N_F, N_M FROM SPR_KAB where N_F='" & unameS &
                                            "' AND N_M ='" & unameS2 & "' AND Arhiv=0 ORDER BY N_F, N_M, Name"
                                End If

                                rs3 = New Recordset
                                rs3.Open(sSQL5, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                                With rs3
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

                                            Select Case DCKey

                                                Case sTEN

                                                    lstgroups.SelectedNode = OfficeNode
                                                    lstgroups.SelectedNode.Expand()

                                            End Select

                                        End If

                                        OfficeNode.ForeColor = Color.DarkGoldenrod

                                        sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE filial ='" & unameS &
                                                "' AND mesto ='" & unameS2 & "' AND kabn='" & unameS3 & "'"
                                        rs4 = New Recordset
                                        rs4.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
                                        With rs4
                                            cFil = .Fields("t_n").Value
                                        End With
                                        rs4.Close()
                                        rs4 = Nothing


                                        Select Case cFil
                                            Case 0
                                            Case Else
                                                Call FILING_FILIAL()
                                        End Select

                                        .MoveNext()
                                    Loop
                                End With
                                rs3.Close()
                                rs3 = Nothing

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


        Select Case Err.Number
            Case 3021 'ignore, no entries in list
                ' MsgBox(Err.Description, vbCritical, ProGramName)
                Resume Next
            Case Else

                MsgBox(Err.Description, vbCritical, ProGramName)

        End Select

        ' lstgroups.SelectedNode.ExpandAll()
    End Sub

    Private Sub FILING_TREE(ByVal lstgroups As TreeView, ByVal iTipTehn As String, ByVal TipPC As String,
                            ByVal NET_NAME As String, ByVal PSEVDONIM As String, ByVal iD As String,
                            ByVal Spisan As String, ByVal DepNode As TreeNode, ByVal OS As String, ByVal n_set As String,
                            ByVal balans As String)

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

                If N_NAME = P_NAME Then

                    L_NAME = N_NAME

                Else

                    L_NAME = N_NAME & " (" & P_NAME & ")"

                End If

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

        'My.Application.DoEvents()

        Select Case iTipTehn

            Case "CNT"

                Dim uname As String

                On Error Resume Next


                If Len(NET_NAME) = 0 Then

                    uname = ""

                Else

                    Dim rsOT As Recordset
                    rsOT = New Recordset
                    rsOT.Open("SELECT A FROM spr_other where Name ='" & NET_NAME & "'", DB7,
                              CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rsOT
                        If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value
                    End With

                    rsOT.Close()
                    rsOT = Nothing

                End If

                Dim TEHNodeCNT As New TreeNode(L_NAME, uname, uname)
                TEHNodeCNT.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNodeCNT)

                Call checkOther(lstgroups, iD, TEHNodeCNT, Spisan, balans)

                Call checkRemont(iD, TEHNodeCNT)

               

                '#####################################################################
                '#####################################################################
                '#                          КОНТЕЙНЕР
                '#####################################################################
                '#####################################################################

                Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)
                Dim sSQL4 As String

                sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & iD

                Dim rs3 As Recordset
                rs3 = New Recordset
                rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                Dim sCount As String
                With rs3
                    sCount = .Fields("t_n").Value
                End With

                rs3.Close()
                rs3 = Nothing

                If sCount > 0 Then

                    Select Case sText

                        Case 0

                            sSQL4 =
                                "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4,balans FROM kompy WHERE PCL =" &
                                iD & " ORDER BY PSEVDONIM, tiptehn"

                        Case 1

                            sSQL4 =
                                "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4,balans FROM kompy WHERE PCL =" &
                                iD & " ORDER BY tiptehn, PSEVDONIM"

                    End Select


                    rs3 = New Recordset
                    rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs3
                        .MoveFirst()

                        Do While Not .EOF
                            Spisan = .Fields("Spisan").Value
                            balans = .Fields("balans").Value

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
                                    TEHNodeCNT.Nodes.Add(TEHNodePC)
                                    iD = .Fields("id").Value

                                    Call checkRemont(.Fields("id").Value, TEHNodePC)

                                    Select Case n_set

                                        Case "Off"
                                            TEHNodePC.ForeColor = Color.Red

                                        Case "Defective"

                                            TEHNodePC.ForeColor = Color.Blue

                                        Case Else

                                            TEHNodePC.ForeColor = Color.Green

                                    End Select


                                    Call checkOther(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans)


                                Case "PC"

                                    iC = .Fields("TIP_COMPA").Value

                                    If iC = "Ноутбук" Or iC = "notebook" Or iC = "Notebook" Or iC = "NoteBook" Then
                                        iC = "Ноутбук"
                                    End If

                                    If iC = "КПК" Or iC = "Pocket PC" Or iC = "Pocket" Or iC = "Palm" Then
                                        iC = "КПК"
                                    End If

                                    If _
                                        iC = "Сервер" Or iC = "Server" Or iC = "Сервер для тонких клиентов" Or
                                        iC = "Сервер видео наблюдения" Then
                                        iC = "Сервер"
                                    End If

                                    'Pocket PC

                                    Select Case iC

                                        Case "Рабочая станция"
                                            iA = 4


                                        Case "Сервер"

                                            iA = 3

                                        Case "КПК"
                                            iA = 31

                                        Case "Ноутбук"
                                            iA = 5

                                        Case Else
                                            iA = 4

                                    End Select

                                    Dim TEHNodePC As New TreeNode(L_NAME, iA, iA)
                                    iD = .Fields("id").Value
                                    TEHNodePC.Tag = "C|" & .Fields("id").Value
                                    iPSid = .Fields("id").Value

                                    TEHNodeCNT.Nodes.Add(TEHNodePC)

                                    Call checkRemont(.Fields("id").Value, TEHNodePC)

                                    Call checkOther(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans)


                                    '#####################################################################
                                    '#####################################################################
                                    '#                          Компьютер в контейнере
                                    '#####################################################################
                                    '#####################################################################

                                    ' Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)
                                    ' Dim sSQL4 As String


                                    sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & iD

                                    'Dim rs3 As ADODB.Recordset
                                    rs3 = New Recordset
                                    rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                                    ' Dim sCount As String
                                    With rs3
                                        sCount = .Fields("t_n").Value
                                    End With

                                    rs3.Close()
                                    rs3 = Nothing

                                    Select Case sCount

                                        Case 0

                                        Case Else

                                            Select Case sText

                                                Case 0

                                                    sSQL4 =
                                                        "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,balans FROM kompy WHERE PCL =" &
                                                        iD & " ORDER BY PSEVDONIM, tiptehn"

                                                Case 1

                                                    sSQL4 =
                                                        "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,balans FROM kompy WHERE PCL =" &
                                                        iD & " ORDER BY tiptehn, PSEVDONIM"

                                            End Select

                                            rs3 = New Recordset
                                            rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                                            With rs3
                                                .MoveFirst()

                                                Do While Not .EOF

                                                    Spisan = .Fields("Spisan").Value
                                                    balans = .Fields("balans").Value

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

                                                            If N_NAME = P_NAME Then

                                                                L_NAME = N_NAME

                                                            Else

                                                                L_NAME = N_NAME & " (" & P_NAME & ")"

                                                            End If

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

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 7)

                                                        Case "MFU"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 8)

                                                        Case "SCANER"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 14)

                                                        Case "ZIP"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 15)

                                                        Case "PHONE"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 12)

                                                        Case "OT"

                                                            ' Dim uname As String

                                                            On Error Resume Next


                                                            If Len(.Fields("tip_compa").Value) = 0 Then

                                                                uname = ""

                                                            Else

                                                                Dim rsOT As Recordset
                                                                rsOT = New Recordset
                                                                rsOT.Open(
                                                                    "SELECT A FROM spr_other where Name ='" &
                                                                    .Fields("tip_compa").Value & "'", DB7,
                                                                    CursorTypeEnum.adOpenDynamic,
                                                                    LockTypeEnum.adLockOptimistic)

                                                                With rsOT

                                                                    If Not IsDBNull(.Fields("A").Value) Then _
                                                                        uname = .Fields("A").Value

                                                                End With

                                                                rsOT.Close()
                                                                rsOT = Nothing


                                                            End If

                                                            If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" _
                                                                Then
                                                                iA = 16
                                                            Else
                                                                iA = uname
                                                            End If

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, iA)

                                                        Case "MONITOR"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 17)

                                                            '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                                                        Case "USB"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 18)

                                                        Case "SOUND"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 44)

                                                        Case "IBP"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 41)

                                                        Case "FS"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 61)

                                                        Case "KEYB"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 46)

                                                        Case "MOUSE"

                                                            Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC,
                                                                              Spisan, balans, L_NAME, 47)

                                                            '--------------VIP_Graff Добавление новой перефирии Конец------------------

                                                        Case Else


                                                    End Select


                                                    .MoveNext()
                                                Loop
                                            End With
                                            rs3.Close()
                                            rs3 = Nothing

                                    End Select

                                    '#####################################################################
                                    '#####################################################################
                                    '#                          Техника в контейнере
                                    '#####################################################################
                                    '#####################################################################

                                Case "PHOTO"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME, 11)


                                Case "Printer"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      7)


                                Case "MFU"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      8)


                                Case "SCANER"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      14)


                                Case "ZIP"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      15)

                                Case "PHONE"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      12)

                                Case "OT"

                                    'Dim uname As String

                                    On Error Resume Next


                                    If Len(.Fields("tip_compa").Value) = 0 Then

                                        uname = ""
                                    Else

                                        Dim rsOT As Recordset
                                        rsOT = New Recordset
                                        rsOT.Open(
                                            "SELECT A FROM spr_other where Name ='" & .Fields("tip_compa").Value & "'",
                                            DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                                        With rsOT

                                            If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                                        End With


                                        rsOT.Close()
                                        rsOT = Nothing


                                    End If


                                    If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                                        iA = 16
                                    Else
                                        iA = uname
                                    End If


                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      iA)

                                Case "MONITOR"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      17)


                                    '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                                Case "USB"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      18)

                                Case "SOUND"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      44)

                                Case "IBP"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      41)


                                Case "FS"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      61)


                                Case "KEYB"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      46)


                                Case "MOUSE"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodeCNT, Spisan, balans, L_NAME,
                                                      47)

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
                '#                          Компьютер
                '#####################################################################
                '#####################################################################

            Case "PC"

                Dim TEHNodePC As New TreeNode(L_NAME, iA, iB)

                TEHNodePC.Tag = "C|" & iD
                iPSid = iD

                DepNode.Nodes.Add(TEHNodePC)

                Call checkRemont(iD, TEHNodePC)
                Call checkOther(lstgroups, iD, TEHNodePC, Spisan, balans)


                '########################################################################
                '########################################################################
                '########################################################################

                Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)
                Dim sSQL4 As String


                sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & iD

                Dim rs3 As Recordset
                rs3 = New Recordset
                rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                Dim sCount As String
                With rs3
                    sCount = .Fields("t_n").Value
                End With

                rs3.Close()
                rs3 = Nothing

                If sCount > 0 Then

                    Select Case sText

                        Case 0

                            sSQL4 =
                                "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4,balans FROM kompy WHERE PCL =" &
                                iD & " ORDER BY PSEVDONIM, tiptehn"

                        Case 1

                            sSQL4 =
                                "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4,balans FROM kompy WHERE PCL =" &
                                iD & " ORDER BY tiptehn, PSEVDONIM"

                    End Select

                    rs3 = New Recordset
                    rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs3
                        .MoveFirst()

                        Do While Not .EOF

                            Spisan = .Fields("Spisan").Value
                            balans = .Fields("balans").Value

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

                                    If N_NAME = P_NAME Then

                                        L_NAME = N_NAME

                                    Else

                                        L_NAME = N_NAME & " (" & P_NAME & ")"

                                    End If

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

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      7)

                                Case "MFU"


                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      8)


                                Case "SCANER"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      14)

                                Case "ZIP"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      15)

                                Case "PHONE"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      12)


                                Case "OT"

                                    Dim uname As String

                                    On Error Resume Next


                                    If Len(.Fields("tip_compa").Value) = 0 Then

                                        uname = ""
                                    Else

                                        Dim rsOT As Recordset
                                        rsOT = New Recordset
                                        rsOT.Open(
                                            "SELECT A FROM spr_other where Name ='" & .Fields("tip_compa").Value & "'",
                                            DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                                        With rsOT

                                            If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                                        End With

                                        rsOT.Close()
                                        rsOT = Nothing

                                    End If

                                    If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                                        iA = 16
                                    Else
                                        iA = uname
                                    End If

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      iA)

                                Case "MONITOR"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      17)


                                    '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                                Case "USB"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      18)

                                Case "SOUND"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      44)


                                Case "IBP"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      41)


                                Case "FS"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      61)


                                Case "KEYB"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      46)

                                Case "MOUSE"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePC, Spisan, balans, L_NAME,
                                                      47)

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

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 7)

            Case "MFU"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 8)

            Case "KOpir"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 9)


            Case "NET"

                Dim TEHNode As New TreeNode(L_NAME, 10, 10)
                TEHNode.Tag = "C|" & iD
                DepNode.Nodes.Add(TEHNode)

                Call checkRemont(iD, TEHNode)

                Select Case n_set

                    Case "Off"
                        TEHNode.ForeColor = Color.Red

                    Case "Defective"

                        TEHNode.ForeColor = Color.Blue

                    Case Else

                        TEHNode.ForeColor = Color.Green

                End Select


                Call checkOther(lstgroups, iD, TEHNode, Spisan, balans)


            Case "PHOTO"

                iA = 11
                iB = 11

                Dim TEHNodePHOTO As New TreeNode(L_NAME, iA, iB)

                TEHNodePHOTO.Tag = "C|" & iD
                iPSid = iD

                DepNode.Nodes.Add(TEHNodePHOTO)

                Call checkRemont(iD, TEHNodePHOTO)

                Call checkOther(lstgroups, iD, TEHNodePHOTO, Spisan, balans)

                Dim sText As String = objIniFile.GetString("general", "Tree_S", 0)
                Dim sSQL4 As String


                sSQL4 = "SELECT count(*) as t_n FROM kompy WHERE PCL =" & iD

                Dim rs3 As Recordset
                rs3 = New Recordset
                rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                Dim sCount As String
                With rs3
                    sCount = .Fields("t_n").Value
                End With

                rs3.Close()
                rs3 = Nothing

                If sCount > 0 Then


                    Select Case sText

                        Case 0

                            sSQL4 =
                                "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4,balans FROM kompy WHERE PCL =" &
                                iD & " ORDER BY PSEVDONIM, tiptehn"

                        Case 1

                            sSQL4 =
                                "SELECT id, tiptehn, PSEVDONIM, NET_NAME, Spisan, tip_compa,PRINTER_NAME_4,balans FROM kompy WHERE PCL =" &
                                iD & " ORDER BY tiptehn, PSEVDONIM"

                    End Select


                    rs3 = New Recordset
                    rs3.Open(sSQL4, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs3
                        .MoveFirst()

                        Do While Not .EOF

                            Spisan = .Fields("Spisan").Value
                            balans = .Fields("balans").Value

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

                                    If N_NAME = P_NAME Then

                                        L_NAME = N_NAME

                                    Else

                                        L_NAME = N_NAME & " (" & P_NAME & ")"

                                    End If

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

                                Case "OT"

                                    Dim uname As String

                                    On Error Resume Next

                                    If Len(.Fields("tip_compa").Value) = 0 Then

                                        uname = ""
                                    Else

                                        Dim rsOT As Recordset
                                        rsOT = New Recordset
                                        rsOT.Open(
                                            "SELECT A FROM spr_other where Name ='" & .Fields("tip_compa").Value & "'",
                                            DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                                        With rsOT

                                            If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                                        End With

                                        rsOT.Close()
                                        rsOT = Nothing

                                    End If

                                    If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                                        iA = 16
                                    Else
                                        iA = uname
                                    End If

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePHOTO, Spisan, balans, L_NAME,
                                                      iA)

                                Case "USB"

                                    Filling_TREE_DATA(lstgroups, .Fields("id").Value, TEHNodePHOTO, Spisan, balans, L_NAME,
                                                      18)

                                Case Else

                            End Select

                            .MoveNext()
                        Loop
                    End With
                    rs3.Close()
                    rs3 = Nothing

                End If

            Case "PHONE"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 12)

            Case "FAX"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 13)

            Case "SCANER"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 14)

            Case "ZIP"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 15)

            Case "OT"

                Dim uname As String

                On Error Resume Next

                If Len(TipPC) = 0 Then

                    uname = ""
                Else

                    Dim rsOT As Recordset
                    rsOT = New Recordset
                    rsOT.Open("SELECT A FROM spr_other where Name ='" & TipPC & "'", DB7, CursorTypeEnum.adOpenDynamic,
                              LockTypeEnum.adLockOptimistic)

                    With rsOT

                        If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value

                    End With

                    rsOT.Close()
                    rsOT = Nothing

                End If

                If Len(uname) = 0 Or uname = " " Or uname = " 0" Or uname = "" Then
                    iA = 16
                Else
                    iA = uname
                End If

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, iA)

            Case "MONITOR"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 17)

                '--------------VIP_Graff Добавление новой перефирии Начало-----------------
            Case "USB"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 18)

            Case "SOUND"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 44)

            Case "IBP"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 41)

            Case "FS"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 61)

            Case "KEYB"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 46)

            Case "MOUSE"

                Filling_TREE_DATA(lstgroups, iD, DepNode, Spisan, balans, L_NAME, 47)

                '--------------VIP_Graff Добавление новой перефирии Конец------------------

            Case Else

        End Select
    End Sub

    Public Sub Filling_TREE_DATA(ByVal lstgroups As TreeView, ByVal sID As Integer, ByVal TEHNodePCL As TreeNode,
                                 ByVal Spisan As String, ByVal balans As String, ByVal L_NAME As String,
                                 ByVal sNUM As Decimal)

        Dim TEHNodeCNT As New TreeNode(L_NAME, sNUM, sNUM)
        TEHNodeCNT.Tag = "C|" & sID
        TEHNodePCL.Nodes.Add(TEHNodeCNT)


        Call checkRemont(sID, TEHNodeCNT)

        Call checkOther(lstgroups, sID, TEHNodeCNT, Spisan, balans)

    End Sub

    Private Sub checkRemont(ByVal sID As Integer, ByVal TEHNodePCL As TreeNode)

        Select Case remVisible

            Case True

                Dim rs As Recordset
                rs = New Recordset
                Dim sSQL As String

                sSQL = "Select count(*) as t_n FROM Remont Where id_comp=" & sID & " and zakryt = 0"

                Dim tmpCount As Integer = 0

                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                tmpCount = rs.Fields("t_n").Value

                rs.Close()
                rs = Nothing

                Select Case tmpCount

                    Case 0

                    Case Else

                        TEHNodePCL.BackColor = Color.Red

                End Select

        End Select


    End Sub

    Private Sub checkOther(ByVal lstgroups As TreeView, ByVal sID As Integer, ByVal TEHNodeCNT As TreeNode,
                                 ByVal Spisan As String, ByVal balans As String)


        Select Case SPVisible

            Case True

                Select Case Spisan

                    Case "1"
                        TEHNodeCNT.ForeColor = Color.DimGray
                        TEHNodeCNT.NodeFont = New Font(lstgroups.Font, 8)
                    Case "True"
                        TEHNodeCNT.ForeColor = Color.DimGray
                        TEHNodeCNT.NodeFont = New Font(lstgroups.Font, 8)
                    Case "-1"
                        TEHNodeCNT.ForeColor = Color.DimGray
                        TEHNodeCNT.NodeFont = New Font(lstgroups.Font, 8)
                End Select

        End Select

        Select Case NBVisible

            Case True

                If balans = "1" Or balans = "True" Or balans = "-1" Then

                    Select Case Spisan

                        Case "1"
                            TEHNodeCNT.NodeFont = New Font(lstgroups.Font, 10)
                        Case "True"
                            TEHNodeCNT.NodeFont = New Font(lstgroups.Font, 10)
                        Case "-1"
                            TEHNodeCNT.NodeFont = New Font(lstgroups.Font, 10)

                        Case Else

                            TEHNodeCNT.NodeFont = New Font(lstgroups.Font, 2)

                    End Select

                End If

        End Select


        Select Case KCKey
            Case sID
                lstgroups.SelectedNode = TEHNodeCNT
                lstgroups.SelectedNode.Expand()
        End Select


    End Sub

End Module
