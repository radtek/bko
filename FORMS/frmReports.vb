﻿Imports System.Threading

Public Class frmReports
    Private m_SortingColumn As ColumnHeader

    Private chkTeh(54) As Boolean
    Private cifTeh(54) As Long
    Private cifAll As Long
    Private pTEXT(2) As String
    Private TIPST As String


    Private Sub frmReports_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        frmMain.SaveInfTehButton.Enabled = False
        frmMain.ToolStripDropDownButton1.Enabled = False

    End Sub

    Private Sub frmReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SendFonts(Me)


        Call frmReports_LANG()
        Dim langIni As New IniFile(sLANGPATH)

        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG2", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG3", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG4", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG5", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG6", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG7", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG8", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG9", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG10", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG11", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG12", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG13", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG14", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG15", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG16", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG17", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG18", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG19", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG20", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG21", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG22", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG23", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG24", ""))
        cmnReport2Compl.Items.Add(langIni.GetString("frmReports", "MSG25", ""))


        cmbOthers.Items.Add(langIni.GetString("frmMain", "28", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "29", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "30", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "31", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "32", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "33", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "34", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "35", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "36", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "37", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "38", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "39", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "40", ""))
        cmbOthers.Items.Add(langIni.GetString("frmMain", "41", ""))
        cmbOthers.Items.Add(langIni.GetString("frmReports", "MSG1", ""))




        Dim rs As ADODB.Recordset

        rs = New ADODB.Recordset
        rs.Open("Select count(*) as t_n from SPR_TIP_PO", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sCOUNT As String
        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        If sCOUNT > 0 Then

            rs = New ADODB.Recordset
            rs.Open("Select name from SPR_TIP_PO", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs
                .MoveFirst()
                Do While Not .EOF

                    cmnReport2Compl.Items.Add(.Fields("name").Value)

                    .MoveNext()
                Loop
            End With
            rs.Close()
            rs = Nothing

        End If




        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG4", ""))
        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG5", ""))
        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG6", ""))
        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG7", ""))
        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG8", ""))
        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG9", ""))
        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG10", ""))
        cmbGar.Items.Add(langIni.GetString("frmReports", "MSG13", ""))


        FillComboNET(Me.cmbReport2fil, "FILIAL", "SPR_FILIAL", "", False, True)
        FillComboNET(Me.cmbBrancheCashe, "FILIAL", "SPR_FILIAL", "", False, True)
        ' FillComboNET(Me.cmbBrancheC, "FILIAL", "SPR_FILIAL", "", False, True)

        cmbBrancheCashe.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        cmbReport2fil.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        FillComboNET(Me.cmbBranche, "FILIAL", "SPR_FILIAL", "", False, True)
        cmbBranche.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        ' cmbBrancheC.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        'Отчет по ремонтам
        FillComboNET(Me.CmbRemont, "Name", "SPR_Master", "", False, True)
        CmbRemont.Items.Add(langIni.GetString("frmReports", "MSG1", ""))
        FillComboNET(Me.cmbUr, "uroven", "SPR_Uroven", "", False, True)
        'UROVEN
        FillComboNET(Me.cmbVip, "Name", "spr_vip", "", False, True)
        DTP.Value = Date.Today
        DTPD.Value = Date.Today

        DTP.Value = DTP.Value.AddDays(-1)
        DTPD.Value = DTPD.Value.AddDays(1)

        FillComboNET(Me.cmbOTV, "Name", "SPR_OTV", "", False, True)

        Dim intj As Integer

        For intj = 1998 To Date.Today.Year

            cmbYearCashe.Items.Add(intj)

        Next

        cmbYearCashe.Text = Date.Today.Year

    End Sub

    Public Sub Rem_clk()
        On Error GoTo Error_
        Dim poPs As String
        Dim Count1 As String
        Dim SP As Date
        Dim PP As Date

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        lvRemont.Items.Clear()

        If frmserviceDesc.ilsCMD.Images.Count = 0 Then

            Call frmservills_load()

        End If

        lvRemont.SmallImageList = frmserviceDesc.ilsCMD


        rs = New ADODB.Recordset
        rs.Open("Select COUNT(*) as tot_num FROM Remont", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            Count1 = .Fields("tot_num").Value
        End With

        rs.Close()
        rs = Nothing
        If Count1 = 0 Then Exit Sub

        Dim langIni As New IniFile(sLANGPATH)

        poPs = langIni.GetString("frmReports", "MSG1", "")




        If CmbRemont.Text <> poPs And chkFltr.Checked = False And chkUroven.Checked = False And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If

        If CmbRemont.Text <> poPs And chkFltr.Checked = False And chkUroven.Checked = True And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' AND uroven='" & cmbUr.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If

        If CmbRemont.Text <> poPs And chkFltr.Checked = False And chkUroven.Checked = True And ChckVip.Checked = True Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' AND uroven='" & cmbUr.Text & "' AND vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If

        If CmbRemont.Text <> poPs And chkFltr.Checked = False And ChckVip.Checked = True And chkUroven.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' AND vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If

        '#########
        If CmbRemont.Text = poPs And chkFltr.Checked = False And chkUroven.Checked = False And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If

        If CmbRemont.Text = poPs And chkFltr.Checked = False And chkUroven.Checked = True And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE uroven='" & cmbUr.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If

        If CmbRemont.Text = poPs And chkFltr.Checked = False And chkUroven.Checked = True And ChckVip.Checked = True Then
            sSQL = "SELECT * FROM Remont WHERE uroven='" & cmbUr.Text & "' AND vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If

        If CmbRemont.Text = poPs And chkFltr.Checked = False And ChckVip.Checked = True And chkUroven.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR
        End If
        '#########

        If CmbRemont.Text <> poPs And chkFltr.Checked = True And chkUroven.Checked = False And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        If CmbRemont.Text <> poPs And chkFltr.Checked = True And chkUroven.Checked = True And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' AND uroven='" & cmbUr.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        If CmbRemont.Text <> poPs And chkFltr.Checked = True And chkUroven.Checked = True And ChckVip.Checked = True Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' AND uroven='" & cmbUr.Text & "' AND vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        If CmbRemont.Text <> poPs And chkFltr.Checked = True And ChckVip.Checked = True And chkUroven.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE master='" & CmbRemont.Text & "' AND vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        If CmbRemont.Text = poPs And chkFltr.Checked = True And chkUroven.Checked = False And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        If CmbRemont.Text = poPs And chkFltr.Checked = True And chkUroven.Checked = True And ChckVip.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE uroven='" & cmbUr.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        If CmbRemont.Text = poPs And chkFltr.Checked = True And chkUroven.Checked = True And ChckVip.Checked = True Then
            sSQL = "SELECT * FROM Remont WHERE uroven='" & cmbUr.Text & "' AND vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        If CmbRemont.Text = poPs And chkFltr.Checked = True And ChckVip.Checked = True And chkUroven.Checked = False Then
            sSQL = "SELECT * FROM Remont WHERE vip='" & cmbVip.Text & "' ORDER BY date DESC, id DESC, zakryt"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            GoTo ADR2
        End If

        rs.Close()
        rs = Nothing

        Exit Sub
ADR:

        'ListViewLoad master_otch.lvRemont, rs
        Dim intCount As Decimal = 0
        Dim uname As Integer
        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case chkNZ.Checked

                    Case False


                        'lvRemont.Items.Add(.Fields("id").Value)

                        If .Fields("zakryt").Value = 1 Or .Fields("zakryt").Value = True Then
                            uname = 0
                        Else
                            uname = 1
                        End If

                        Dim item As ListViewItem = lvRemont.Items.Add(.Fields("id").Value)
                        item.ImageIndex = uname



                        lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                        lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Remont").Value)

                        If Not IsDBNull(.Fields("Uroven").Value) Then
                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                        Else
                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("Master").Value) Then
                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                        Else
                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("Comp_Name").Value) Then
                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Comp_Name").Value)
                        Else
                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("Mesto_Compa").Value) Then
                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Mesto_Compa").Value)
                        Else
                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("vip").Value) Then
                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                        Else
                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("UserName").Value) Then
                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                        Else
                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                        End If




                        If Not IsDBNull(.Fields("stoptime").Value) Then
                            Dim A1 As Integer
                            Dim A3, A2 As String

                            Dim age As Integer
                            age = DateDiff(DateInterval.Day, .Fields("startdate").Value, .Fields("stopdate").Value)
                            A1 = DateDiff(DateInterval.Minute, .Fields("starttime").Value, .Fields("stoptime").Value)

                            A2 = (A1 \ 60)
                            A1 = (A1 Mod 60)

                            A3 = age & " " & langIni.GetString("frmReports", "MSG42", "") & " " & A2 & ":" & A1 & " " & langIni.GetString("frmReports", "MSG43", "")


                            lvRemont.Items(CInt(intCount)).SubItems.Add(A3)
                        Else
                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                        End If



                        intCount = intCount + 1

                    Case Else



                        If .Fields("zakryt").Value = 0 Then

                            If .Fields("zakryt").Value = 1 Or .Fields("zakryt").Value = True Then
                                uname = 0
                            Else
                                uname = 1
                            End If

                            Dim item As ListViewItem = lvRemont.Items.Add(.Fields("id").Value)
                            item.ImageIndex = uname

                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Remont").Value)

                            If Not IsDBNull(.Fields("Uroven").Value) Then
                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                            Else
                                lvRemont.Items(CInt(intCount)).SubItems.Add("")

                            End If

                            If Not IsDBNull(.Fields("Master").Value) Then
                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                            Else
                                lvRemont.Items(CInt(intCount)).SubItems.Add("")

                            End If

                            If Not IsDBNull(.Fields("Comp_Name").Value) Then
                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Comp_Name").Value)
                            Else
                                lvRemont.Items(CInt(intCount)).SubItems.Add("")

                            End If

                            If Not IsDBNull(.Fields("Mesto_Compa").Value) Then
                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Mesto_Compa").Value)
                            Else
                                lvRemont.Items(CInt(intCount)).SubItems.Add("")

                            End If

                            If Not IsDBNull(.Fields("vip").Value) Then
                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                            Else
                                lvRemont.Items(CInt(intCount)).SubItems.Add("")

                            End If

                            If Not IsDBNull(.Fields("UserName").Value) Then
                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                            Else
                                lvRemont.Items(CInt(intCount)).SubItems.Add("")

                            End If


                            If Not IsDBNull(.Fields("stoptime").Value) Then
                                Dim A1 As Integer
                                Dim A3, A2 As String
                                Dim age As Integer
                                age = DateDiff(DateInterval.Day, .Fields("startdate").Value, .Fields("stopdate").Value)
                                A1 = DateDiff(DateInterval.Minute, .Fields("starttime").Value, .Fields("stoptime").Value)

                                A2 = (A1 \ 60)
                                A1 = (A1 Mod 60)

                                A3 = age & " " & langIni.GetString("frmReports", "MSG42", "") & " " & A2 & ":" & A1 & " " & langIni.GetString("frmReports", "MSG43", "")

                                lvRemont.Items(CInt(intCount)).SubItems.Add(A3)
                            Else
                                lvRemont.Items(CInt(intCount)).SubItems.Add("")

                            End If



                            intCount = intCount + 1
                        End If
                End Select


                'intCount = intCount + 1
                .MoveNext()
            Loop
            .MoveNext()

        End With



        rs.Close()
        rs = Nothing



        Exit Sub
ADR2:

        intCount = 0

        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case chkNZ.Checked

                    Case False

                        SP = rs.Fields("Date").Value
                        PP = rs.Fields("Date").Value

                        If SP >= DTP.Value Then
                            If SP <= DTPD.Value Then

                                If .Fields("zakryt").Value = 1 Or .Fields("zakryt").Value = True Then
                                    uname = 0
                                Else
                                    uname = 1
                                End If

                                Dim item As ListViewItem = lvRemont.Items.Add(.Fields("id").Value)
                                item.ImageIndex = uname


                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                                lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Remont").Value)

                                If Not IsDBNull(.Fields("Uroven").Value) Then
                                    lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                                Else
                                    lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                End If

                                If Not IsDBNull(.Fields("Master").Value) Then
                                    lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                                Else
                                    lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                End If

                                If Not IsDBNull(.Fields("Comp_Name").Value) Then
                                    lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Comp_Name").Value)
                                Else
                                    lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                End If

                                If Not IsDBNull(.Fields("Mesto_Compa").Value) Then
                                    lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Mesto_Compa").Value)
                                Else
                                    lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                End If

                                If Not IsDBNull(.Fields("vip").Value) Then
                                    lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                                Else
                                    lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                End If

                                If Not IsDBNull(.Fields("UserName").Value) Then
                                    lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                                Else
                                    lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                End If

                                If Not IsDBNull(.Fields("stoptime").Value) Then
                                    Dim A1 As Integer
                                    Dim A3, A2 As String
                                    Dim age As Integer
                                    age = DateDiff(DateInterval.Day, .Fields("startdate").Value, .Fields("stopdate").Value)
                                    A1 = DateDiff(DateInterval.Minute, .Fields("starttime").Value, .Fields("stoptime").Value)

                                    A2 = (A1 \ 60)
                                    A1 = (A1 Mod 60)

                                    A3 = age & " " & langIni.GetString("frmReports", "MSG42", "") & " " & A2 & ":" & A1 & " " & langIni.GetString("frmReports", "MSG43", "")

                                    lvRemont.Items(CInt(intCount)).SubItems.Add(A3)
                                Else
                                    lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                End If



                                intCount = intCount + 1

                            End If

                        End If




                    Case Else


                        If .Fields("zakryt").Value = 0 Then
                            SP = rs.Fields("Date").Value
                            PP = rs.Fields("Date").Value

                            If SP >= DTP.Value Then
                                If SP <= DTPD.Value Then

                                    If .Fields("zakryt").Value = 0 Then

                                        If .Fields("zakryt").Value = 1 Or .Fields("zakryt").Value = True Then
                                            uname = 0
                                        Else
                                            uname = 1
                                        End If

                                        Dim item As ListViewItem = lvRemont.Items.Add(.Fields("id").Value)
                                        item.ImageIndex = uname

                                        lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                                        lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Remont").Value)

                                        If Not IsDBNull(.Fields("Uroven").Value) Then
                                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                                        Else
                                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                        End If

                                        If Not IsDBNull(.Fields("Master").Value) Then
                                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                                        Else
                                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                        End If

                                        If Not IsDBNull(.Fields("Comp_Name").Value) Then
                                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Comp_Name").Value)
                                        Else
                                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                        End If

                                        If Not IsDBNull(.Fields("Mesto_Compa").Value) Then
                                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("Mesto_Compa").Value)
                                        Else
                                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                        End If

                                        If Not IsDBNull(.Fields("vip").Value) Then
                                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                                        Else
                                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                        End If

                                        If Not IsDBNull(.Fields("UserName").Value) Then
                                            lvRemont.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                                        Else
                                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                        End If

                                        If Not IsDBNull(.Fields("stoptime").Value) Then
                                            Dim A1 As Integer
                                            Dim A3, A2 As String
                                            Dim age As Integer
                                            age = DateDiff(DateInterval.Day, .Fields("startdate").Value, .Fields("stopdate").Value)
                                            A1 = DateDiff(DateInterval.Minute, .Fields("starttime").Value, .Fields("stoptime").Value)

                                            A2 = (A1 \ 60)
                                            A1 = (A1 Mod 60)

                                            A3 = age & " " & langIni.GetString("frmReports", "MSG42", "") & " " & A2 & ":" & A1 & " " & langIni.GetString("frmReports", "MSG43", "")



                                            lvRemont.Items(CInt(intCount)).SubItems.Add(A3)
                                        Else
                                            lvRemont.Items(CInt(intCount)).SubItems.Add("")

                                        End If


                                        intCount = intCount + 1
                                    End If

                                End If

                            End If
                        End If


                End Select


                .MoveNext()
            Loop
        End With



        rs.Close()
        rs = Nothing


        Exit Sub





        Exit Sub
Error_:

    End Sub

    Private Sub cmbReport2fil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReport2fil.SelectedIndexChanged
        On Error GoTo err
        cmbReport2Department.Items.Clear()
        Dim langIni As New IniFile(sLANGPATH)

        If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") Then
            cmbReport2Department.Items.Add(langIni.GetString("frmReports", "MSG1", ""))
            Exit Sub

        End If

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT * FROM SPR_OTD_FILIAL WHERE filial ='" & cmbReport2fil.Text & "' order by N_Otd", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        With rs
            .MoveFirst()
            Do While Not .EOF

                cmbReport2Department.Items.Add(.Fields("N_Otd").Value)

                .MoveNext()
            Loop
        End With

        cmbReport2Department.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        rs.Close()
        rs = Nothing

err:

    End Sub

    Private Sub cmbReport2Department_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReport2Department.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor


        Call LOAD_REPORT_COMPL()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LOAD_REPORT_COMPL()
        Dim langIni As New IniFile(sLANGPATH)

        lvReport2Cl.Sorting = SortOrder.None
        lvReport2Cl.ListViewItemSorter = Nothing

        If Len(cmbReport2fil.Text) = 0 Then Exit Sub
        If Len(cmbReport2Department.Text) = 0 Then Exit Sub
        If Len(cmnReport2Compl.Text) = 0 Then Exit Sub

        '#################
        Dim Parametr As String
        Dim unam1 As String
        On Error Resume Next

        Dim sSQL As String

        On Error GoTo Error_

        lvReport2Cl.Items.Clear()



        'If cmbReport2fil.Text = Totd Then cmbReport2fil.Text = "
        'FILIAL.Close
        'Dim FILIAL As ADODB.Recordset
        'FILIAL = New ADODB.Recordset
        'FILIAL.Open("SELECT * FROM SPR_FILIAL", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        ''End With
        'CPU

        chkReport2Prn.Visible = False

        Select Case Trim(cmnReport2Compl.Text)

            Case langIni.GetString("frmReports", "MSG25", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT net_name, COUNT(net_name) as tot_num FROM kompy WHERE tiptehn = 'OT' group by net_name"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(net_name) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'OT' group by net_name"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(net_name) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'OT' group by net_name"

                    End If
                End If


            Case langIni.GetString("frmReports", "MSG21", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'MFU' group by net_name"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'MFU' group by net_name"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'MFU' group by net_name"

                    End If
                End If


            Case langIni.GetString("frmReports", "MSG24", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PHOTO' group by net_name"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PHOTO' group by net_name"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PHOTO' group by net_name"

                    End If
                End If

            Case langIni.GetString("frmReports", "MSG23", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'FAX' group by net_name"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'FAX' group by net_name"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'FAX' group by net_name"

                    End If
                End If





                'Êîïèðû
            Case langIni.GetString("frmReports", "MSG20", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'KOpir' group by net_name"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'KOpir' group by net_name"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'KOpir' group by net_name"

                    End If
                End If




            Case langIni.GetString("frmReports", "MSG22", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PHONE' group by net_name"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PHONE' group by net_name"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT net_name, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PHONE' group by net_name"

                    End If
                End If






            Case langIni.GetString("frmReports", "MSG13", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                    'sSQL = "SELECT cpus.cpu1, Count(*) AS tot_num FROM (SELECT cpu1 FROM kompy union all SELECT cpu2 FROM kompy union all SELECT cpu3 FROM kompy union all SELECT cpu4 FROM kompy) AS cpus GROUP BY cpus.cpu1"
                    sSQL = "SELECT cpus.cpu1, Count(*) AS tot_num FROM (SELECT cpu1 FROM kompy WHERE tiptehn = 'PC' union all SELECT cpu2 FROM kompy WHERE tiptehn = 'PC'  union all SELECT cpu3 FROM kompy WHERE tiptehn = 'PC'  union all SELECT cpu4 FROM kompy WHERE tiptehn = 'PC') AS cpus GROUP BY cpus.cpu1"
                    'sSQL = "SELECT cpus.cpu1, Count(*) AS tot_num FROM (SELECT cpu1 FROM kompy union all SELECT cpu2 FROM kompy union all SELECT cpu3 FROM kompy union all SELECT cpu4 FROM kompy) AS cpus GROUP BY cpus.cpu1"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.cpu1, Count(*) AS tot_num FROM (SELECT cpu1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT cpu2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC'  union all SELECT cpu3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC'  union all SELECT cpu4 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.cpu1"
                    Else
                        sSQL = "SELECT cpus.cpu1, Count(*) AS tot_num FROM (SELECT cpu1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT cpu2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT cpu3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT cpu4 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.cpu1"
                    End If
                End If


            Case langIni.GetString("frmReports", "MSG15", "")

                Select Case DB_N

                    Case "MySQL"

                        If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                            sSQL = "SELECT cpu1, count(*) as tot_num FROM (SELECT CONCAT(cpu1,' ', cpumhz1) as cpu1 FROM kompy union all SELECT CONCAT(cpu2,' ', cpumhz2) FROM kompy union all SELECT CONCAT(cpu3,' ', cpumhz3) FROM kompy union all SELECT CONCAT(cpu4,' ', cpumhz4) FROM kompy) AS cpus group by cpu1"

                        Else

                            If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                                sSQL = "SELECT cpu1, count(*) as tot_num FROM (SELECT CONCAT(cpu1,' ', cpumhz1) as cpu1 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT CONCAT(cpu2,' ', cpumhz2) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC'  union all SELECT CONCAT(cpu3,' ', cpumhz3) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC'  union all SELECT CONCAT(cpu4,' ', cpumhz4) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' ) AS cpus group by cpu1"
                            Else
                                sSQL = "SELECT cpu1, count(*) as tot_num FROM (SELECT CONCAT(cpu1,' ', cpumhz1) as cpu1 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT CONCAT(cpu2,' ', cpumhz2) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT CONCAT(cpu3,' ', cpumhz3) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT CONCAT(cpu4,' ', cpumhz4) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus group by cpu1"
                            End If
                        End If


                    Case Else

                        If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                            sSQL = "SELECT cpu1, count(*) as tot_num FROM (SELECT (cpu1+' '+ cpumhz1) as cpu1 FROM kompy union all SELECT (cpu2+' '+ cpumhz2) FROM kompy union all SELECT (cpu3+' '+ cpumhz3) FROM kompy union all SELECT (cpu4+' '+ cpumhz4) FROM kompy) AS cpus group by cpu1"

                        Else

                            If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                                sSQL = "SELECT cpu1, count(*) as tot_num FROM (SELECT (cpu1+' '+ cpumhz1) as cpu1 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT (cpu2+' '+ cpumhz2) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC'  union all SELECT (cpu3+' '+ cpumhz3) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC'  union all SELECT (cpu4+' '+ cpumhz4) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC') AS cpus group by cpu1"

                            Else
                                sSQL = "SELECT cpu1, count(*) as tot_num FROM (SELECT (cpu1+' '+ cpumhz1) as cpu1 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT (cpu2+' '+ cpumhz2) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT (cpu3+' '+ cpumhz3) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT (cpu4+' '+ cpumhz4) FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus group by cpu1"

                            End If
                        End If


                End Select

            Case langIni.GetString("frmReports", "MSG7", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    sSQL = "SELECT mb, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PC' group by mb"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then


                        sSQL = "SELECT mb, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' group by mb"

                    Else

                        sSQL = "SELECT mb, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' group by mb"

                    End If
                End If






            Case langIni.GetString("frmReports", "MSG4", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT SVGA_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PC' group by SVGA_NAME"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT SVGA_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' group by SVGA_NAME"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT SVGA_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' group by SVGA_NAME"

                    End If
                End If




            Case langIni.GetString("frmReports", "MSG5", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT cpus.HDD_Name_1, Count(*) AS tot_num FROM (SELECT HDD_Name_1 FROM kompy WHERE tiptehn = 'PC' union all SELECT HDD_Name_2 FROM kompy union all SELECT HDD_Name_3 FROM kompy union all SELECT  HDD_Name_4 FROM kompy) AS cpus GROUP BY cpus.HDD_Name_1"
                    sSQL = "SELECT cpus.HDD_Name_1, Count(*) AS tot_num FROM (SELECT HDD_Name_1 FROM kompy WHERE tiptehn = 'PC' union all SELECT HDD_Name_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT HDD_Name_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT  HDD_Name_4 FROM kompy WHERE tiptehn = 'PC' ) AS cpus GROUP BY cpus.HDD_Name_1"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.HDD_Name_1, Count(*) AS tot_num FROM (SELECT HDD_Name_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT HDD_Name_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT HDD_Name_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT  HDD_Name_4 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' ) AS cpus GROUP BY cpus.HDD_Name_1"

                    Else
                        sSQL = "SELECT cpus.HDD_Name_1, Count(*) AS tot_num FROM (SELECT HDD_Name_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT HDD_Name_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT HDD_Name_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT HDD_Name_4 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.HDD_Name_1"

                    End If
                End If


            Case langIni.GetString("frmReports", "MSG14", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                    'sSQL = "SELECT cpus.NET_NAME_1, Count(*) AS tot_num FROM (SELECT NET_NAME_1 FROM kompy union all SELECT NET_NAME_2 FROM kompy) AS cpus GROUP BY cpus.NET_NAME_1"
                    sSQL = "SELECT cpus.NET_NAME_1, Count(*) AS tot_num FROM (SELECT NET_NAME_1 FROM kompy WHERE tiptehn = 'PC' union all SELECT NET_NAME_2 FROM kompy WHERE tiptehn = 'PC' ) AS cpus GROUP BY cpus.NET_NAME_1"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.NET_NAME_1, Count(*) AS tot_num FROM (SELECT NET_NAME_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT NET_NAME_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' ) AS cpus GROUP BY cpus.NET_NAME_1"

                    Else
                        sSQL = "SELECT cpus.NET_NAME_1, Count(*) AS tot_num FROM (SELECT NET_NAME_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT NET_NAME_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.NET_NAME_1"

                    End If
                End If

            Case langIni.GetString("frmReports", "MSG8", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    sSQL = "SELECT MODEM_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PC' group by MODEM_NAME"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then


                        sSQL = "SELECT MODEM_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' group by MODEM_NAME"

                    Else

                        sSQL = "SELECT MODEM_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' group by MODEM_NAME"

                    End If
                End If



            Case langIni.GetString("frmReports", "MSG3", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    sSQL = "SELECT USB_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PC' group by USB_NAME"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then


                        sSQL = "SELECT USB_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' group by USB_NAME"

                    Else

                        sSQL = "SELECT USB_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' group by USB_NAME"

                    End If
                End If




            Case langIni.GetString("frmReports", "MSG2", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    sSQL = "SELECT PCI_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PC' group by PCI_NAME"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then


                        sSQL = "SELECT PCI_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' group by PCI_NAME"

                    Else

                        sSQL = "SELECT PCI_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' group by PCI_NAME"

                    End If
                End If


            Case langIni.GetString("frmReports", "MSG19", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                    'sSQL = "SELECT cpus.CD_NAME, Count(*) AS tot_num FROM (SELECT CD_NAME FROM kompy union all SELECT CDRW_NAME FROM kompy union all SELECT DVD_NAME FROM kompy) AS cpus GROUP BY cpus.CD_NAME"
                    sSQL = "SELECT cpus.CD_NAME, Count(*) AS tot_num FROM (SELECT CD_NAME FROM kompy WHERE tiptehn = 'PC' union all SELECT CDRW_NAME FROM kompy WHERE tiptehn = 'PC'  union all SELECT DVD_NAME FROM kompy WHERE tiptehn = 'PC') AS cpus GROUP BY cpus.CD_NAME"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.CD_NAME, Count(*) AS tot_num FROM (SELECT CD_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT CDRW_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC'  union all SELECT DVD_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.CD_NAME"
                    Else
                        sSQL = "SELECT cpus.CD_NAME, Count(*) AS tot_num FROM (SELECT CD_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT CDRW_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT DVD_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.CD_NAME"
                    End If
                End If



            Case langIni.GetString("frmReports", "MSG9", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                    'sSQL = "SELECT cpus.MONITOR_NAME, Count(*) AS tot_num FROM (SELECT MONITOR_NAME FROM kompy union all SELECT MONITOR_NAME2 FROM kompy) AS cpus GROUP BY cpus.MONITOR_NAME"
                    sSQL = "SELECT cpus.MONITOR_NAME, Count(*) AS tot_num FROM (SELECT MONITOR_NAME FROM kompy union all SELECT MONITOR_NAME2 FROM kompy) AS cpus GROUP BY cpus.MONITOR_NAME"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.MONITOR_NAME, Count(*) AS tot_num FROM (SELECT MONITOR_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' union all SELECT MONITOR_NAME2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "') AS cpus GROUP BY cpus.MONITOR_NAME"

                    Else
                        sSQL = "SELECT cpus.MONITOR_NAME, Count(*) AS tot_num FROM (SELECT MONITOR_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' union all SELECT MONITOR_NAME2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "') AS cpus GROUP BY cpus.MONITOR_NAME"

                    End If
                End If


            Case langIni.GetString("frmReports", "MSG9", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT SOUND_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'PC' group by SOUND_NAME"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT SOUND_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' group by SOUND_NAME"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT SOUND_NAME, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' group by SOUND_NAME"

                    End If
                End If




            Case langIni.GetString("frmReports", "MSG10", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                    'sSQL = "SELECT cpus.RAM_1, Count(*) AS tot_num FROM (SELECT RAM_1 FROM kompy union all SELECT RAM_2 FROM kompy union all SELECT RAM_3 FROM kompy union all SELECT  RAM_4 FROM kompy) AS cpus GROUP BY cpus.RAM_1"
                    sSQL = "SELECT cpus.RAM_1, Count(*) AS tot_num FROM (SELECT RAM_1 FROM kompy WHERE tiptehn = 'PC' union all SELECT RAM_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT RAM_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT  RAM_4 FROM kompy WHERE tiptehn = 'PC' ) AS cpus GROUP BY cpus.RAM_1"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.RAM_1, Count(*) AS tot_num FROM (SELECT RAM_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT RAM_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT RAM_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT  RAM_4 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' ) AS cpus GROUP BY cpus.RAM_1"

                    Else
                        sSQL = "SELECT cpus.RAM_1, Count(*) AS tot_num FROM (SELECT RAM_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT RAM_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT RAM_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT RAM_4 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.RAM_1"

                    End If
                End If



            Case langIni.GetString("frmReports", "MSG12", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                    'sSQL = "SELECT cpus.HDD_PROIZV_1, Count(*) AS tot_num FROM (SELECT HDD_PROIZV_1 FROM kompy union all SELECT HDD_PROIZV_2 FROM kompy union all SELECT HDD_PROIZV_3 FROM kompy union all SELECT  HDD_PROIZV_4 FROM kompy) AS cpus GROUP BY cpus.HDD_PROIZV_1"
                    sSQL = "SELECT cpus.HDD_PROIZV_1, Count(*) AS tot_num FROM (SELECT HDD_PROIZV_1 FROM kompy WHERE tiptehn = 'PC' union all SELECT HDD_PROIZV_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT HDD_PROIZV_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT  HDD_PROIZV_4 FROM kompy WHERE tiptehn = 'PC' ) AS cpus GROUP BY cpus.HDD_PROIZV_1"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.HDD_PROIZV_1, Count(*) AS tot_num FROM (SELECT HDD_PROIZV_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT HDD_PROIZV_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT HDD_PROIZV_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT  HDD_PROIZV_4 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' ) AS cpus GROUP BY cpus.HDD_PROIZV_1"

                    Else
                        sSQL = "SELECT cpus.HDD_PROIZV_1, Count(*) AS tot_num FROM (SELECT HDD_PROIZV_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT HDD_PROIZV_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT HDD_PROIZV_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT HDD_PROIZV_4 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.HDD_PROIZV_1"

                    End If
                End If

                '#PRINTERS
                '######################################################
            Case langIni.GetString("frmReports", "MSG11", "")

                chkReport2Prn.Visible = True

                Select Case chkReport2Prn.Checked


                    Case 0


                        If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                            sSQL = "SELECT net_name as cpus, COUNT(tiptehn) as tot_num  FROM kompy WHERE tiptehn = 'Printer' group by net_name"

                        Else

                            If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                                sSQL = "SELECT net_name as cpus, COUNT(tiptehn) as tot_num  FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'Printer' group by net_name"

                            Else
                                sSQL = "SELECT net_name as cpus, COUNT(tiptehn) as tot_num  FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'Printer' group by net_name"

                            End If
                        End If

                    Case 1

                        If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                            sSQL = "SELECT cpus.PRINTER_NAME_1, Count(*) AS tot_num FROM (SELECT PRINTER_NAME_1 FROM kompy WHERE tiptehn = 'PC' union all SELECT PRINTER_NAME_2 FROM kompy WHERE tiptehn = 'PC' union all SELECT PRINTER_NAME_3 FROM kompy WHERE tiptehn = 'PC' union all SELECT  PRINTER_NAME_4 FROM kompy WHERE tiptehn = 'PC') AS cpus GROUP BY cpus.PRINTER_NAME_1"

                        Else

                            If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                                sSQL = "SELECT cpus.PRINTER_NAME_1, Count(*) AS tot_num FROM (SELECT PRINTER_NAME_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT PRINTER_NAME_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT PRINTER_NAME_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT  PRINTER_NAME_4 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' ) AS cpus GROUP BY cpus.PRINTER_NAME_1"

                            Else
                                sSQL = "SELECT cpus.PRINTER_NAME_1, Count(*) AS tot_num FROM (SELECT PRINTER_NAME_1 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT PRINTER_NAME_2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT PRINTER_NAME_3 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC' union all SELECT PRINTER_NAME_4 FROM kompy  WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.PRINTER_NAME_1"

                            End If
                        End If


                End Select

                'ÓÑÒÀÍÎÂËÅÍÍÛÉ ÑÎÔÒ

            Case langIni.GetString("frmReports", "MSG16", "")
                Dim intCount As Integer = 0

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    sSQL = "SELECT SOFT_INSTALL.Soft, COUNT(SOFT_INSTALL.Soft) as tot_num FROM SOFT_INSTALL, kompy WHERE SOFT_INSTALL.Id_Comp=kompy.ID group by SOFT_INSTALL.Soft order by SOFT_INSTALL.Soft"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        sSQL = "SELECT SOFT_INSTALL.Soft, COUNT(SOFT_INSTALL.Soft) as tot_num FROM SOFT_INSTALL, kompy WHERE SOFT_INSTALL.Id_Comp=kompy.ID AND kompy.FILIAL='" & cmbReport2fil.Text & "' group by SOFT_INSTALL.Soft order by SOFT_INSTALL.Soft"

                    Else

                        sSQL = "SELECT SOFT_INSTALL.Soft, COUNT(SOFT_INSTALL.Soft) as tot_num FROM SOFT_INSTALL, kompy WHERE SOFT_INSTALL.Id_Comp=kompy.ID AND kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' group by SOFT_INSTALL.Soft order by SOFT_INSTALL.Soft"

                    End If

                End If



            Case langIni.GetString("frmReports", "MSG17", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                    'sSQL = "SELECT cpus.Monitor_dum, Count(*) AS tot_num FROM (SELECT Monitor_dum FROM kompy union all SELECT Monitor_dum2 FROM kompy) AS cpus GROUP BY cpus.Monitor_dum"
                    sSQL = "SELECT cpus.Monitor_dum, Count(*) AS tot_num FROM (SELECT Monitor_dum FROM kompy WHERE tiptehn = 'PC' union all SELECT Monitor_dum2 FROM kompy WHERE tiptehn = 'PC' ) AS cpus GROUP BY cpus.Monitor_dum"
                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then
                        sSQL = "SELECT cpus.Monitor_dum, Count(*) AS tot_num FROM (SELECT Monitor_dum FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' union all SELECT Monitor_dum2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'PC' ) AS cpus GROUP BY cpus.Monitor_dum"

                    Else
                        sSQL = "SELECT cpus.Monitor_dum, Count(*) AS tot_num FROM (SELECT Monitor_dum FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC'union all SELECT Monitor_dum2 FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'PC') AS cpus GROUP BY cpus.Monitor_dum"

                    End If
                End If

            Case langIni.GetString("frmReports", "MSG18", "")

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    'sSQL = "SELECT NET_NAME FROM kompy WHERE (kompy.tiptehn) = 'MFU'"
                    sSQL = "SELECT PRINTER_SN_1, COUNT(tiptehn) as tot_num FROM kompy WHERE tiptehn = 'NET' group by PRINTER_SN_1"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT PRINTER_SN_1, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' AND tiptehn = 'NET' group by PRINTER_SN_1"

                    Else
                        'sSQL = "SELECT NET_NAME FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND kompy.tiptehn = 'MFU'"
                        sSQL = "SELECT PRINTER_SN_1, COUNT(tiptehn) as tot_num FROM kompy WHERE kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' AND tiptehn = 'NET' group by PRINTER_SN_1"

                    End If
                End If


            Case Else

                If cmbReport2fil.Text = langIni.GetString("frmReports", "MSG1", "") And cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                    sSQL = "SELECT SOFT_INSTALL.Soft, COUNT(SOFT_INSTALL.Soft) as tot_num FROM SOFT_INSTALL, kompy WHERE SOFT_INSTALL.Id_Comp=kompy.ID and SOFT_INSTALL.TIP='" & cmnReport2Compl.Text & "' group by SOFT_INSTALL.Soft order by SOFT_INSTALL.Soft"

                Else

                    If cmbReport2Department.Text = langIni.GetString("frmReports", "MSG1", "") Then

                        sSQL = "SELECT SOFT_INSTALL.Soft, COUNT(SOFT_INSTALL.Soft) as tot_num FROM SOFT_INSTALL, kompy WHERE SOFT_INSTALL.Id_Comp=kompy.ID and SOFT_INSTALL.TIP='" & cmnReport2Compl.Text & "' AND kompy.FILIAL='" & cmbReport2fil.Text & "' group by SOFT_INSTALL.Soft order by SOFT_INSTALL.Soft"

                    Else

                        sSQL = "SELECT SOFT_INSTALL.Soft, COUNT(SOFT_INSTALL.Soft) as tot_num FROM SOFT_INSTALL, kompy WHERE SOFT_INSTALL.Id_Comp=kompy.ID and SOFT_INSTALL.TIP='" & cmnReport2Compl.Text & "' AND kompy.FILIAL='" & cmbReport2fil.Text & "' and kompy.MESTO='" & cmbReport2Department.Text & "' group by SOFT_INSTALL.Soft order by SOFT_INSTALL.Soft"

                    End If

                End If

        End Select



        Dim intj As Integer = 0

        'On Error Resume Next
        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        With rs
            .MoveFirst()
            Do While Not .EOF


                If Not IsDBNull(.Fields(0).Value) Then
                    If Len(.Fields(0).Value) > 1 Then
                        lvReport2Cl.Items.Add(.Fields(0).Value)
                        lvReport2Cl.Items(intj).SubItems.Add(.Fields("tot_num").Value)
                        intj = intj + 1
                    Else
                    End If
                End If


                .MoveNext()
                'DoEvents
            Loop
        End With
        rs.Close()
        rs = Nothing


        ResList(Me.lvReport2Cl)
        'ListViewRavn master_otch.lvReport2Cl, master_otch

        Exit Sub
Error_:
        'MsgBox(Err.Description)
    End Sub

    Private Sub cmnReport2Compl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnReport2Compl.SelectedIndexChanged
        Call LOAD_REPORT_COMPL()
    End Sub

    Private Sub chkReport2Prn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReport2Prn.CheckedChanged
        Call LOAD_REPORT_COMPL()
    End Sub

    Private Sub lvReport2Cl_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvReport2Cl.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
          lvReport2Cl.Columns(e.Column)
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

        lvReport2Cl.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvReport2Cl.Sort()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        lvRemont.Sorting = SortOrder.None
        lvRemont.ListViewItemSorter = Nothing

        Call Rem_clk()
        ResList(Me.lvRemont)
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub lvRemont_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRemont.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
          lvRemont.Columns(e.Column)
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

        lvRemont.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvRemont.Sort()
    End Sub


    Private Sub cmbBranche_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranche.SelectedIndexChanged
        On Error GoTo err_
        Dim langIni As New IniFile(sLANGPATH)

        cmbDepartment.Items.Clear()

        If cmbBranche.Text = langIni.GetString("frmReports", "MSG1", "") Then

            cmbDepartment.Items.Add(langIni.GetString("frmReports", "MSG1", ""))
            cmbDepartment.Text = langIni.GetString("frmReports", "MSG1", "")

            cmbOffice.Text = langIni.GetString("frmReports", "MSG1", "")

            Exit Sub
        End If

        If Len(cmbDepartment.Text) = 0 Then cmbDepartment.Text = langIni.GetString("frmReports", "MSG1", "")

        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("select count(*) as t_n from SPR_OTD_FILIAL WHERE Filial='" & cmbBranche.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sCNN As Integer

        With rs1
            sCNN = .Fields("t_n").Value
        End With

        rs1.Close()
        rs1 = Nothing


        If sCNN > 0 Then

            rs1 = New ADODB.Recordset

            rs1.Open("select * from SPR_OTD_FILIAL WHERE Filial='" & cmbBranche.Text & "' ORDER BY N_Otd", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


            cmbDepartment.Items.Clear()

            With rs1
                .MoveFirst()
                Do While Not .EOF

                    If Not IsDBNull(.Fields("N_Otd").Value) Then cmbDepartment.Items.Add(.Fields("N_Otd").Value)

                    .MoveNext()
                Loop
            End With

            cmbDepartment.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

            rs1.Close()
            rs1 = Nothing

        Else
            cmbDepartment.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        End If

        Exit Sub
err_:
        ' MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim langIni As New IniFile(sLANGPATH)

        If Len(cmbBranche.Text) = 0 Then cmbBranche.Text = langIni.GetString("frmReports", "MSG1", "")
        If Len(cmbDepartment.Text) = 0 Then cmbDepartment.Text = langIni.GetString("frmReports", "MSG1", "")
        If Len(cmbOffice.Text) = 0 Then cmbOffice.Text = langIni.GetString("frmReports", "MSG1", "")


        Me.Cursor = Cursors.WaitCursor
        LvKompOtd.Sorting = SortOrder.None
        LvKompOtd.ListViewItemSorter = Nothing


        Dim Contrl As Control





        On Error Resume Next
        LvKompOtd.Sorting = False

        LvKompOtd.Columns.Clear()
        LvKompOtd.Items.Clear()

        LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(48)", ""))

        Dim intj As Long
        intj = 0


        If chk_K1.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(1)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K2.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(2)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K3.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(3)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K4.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(4)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K5.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(5)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K6.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(6)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K7.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(7)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K8.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(8)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K9.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(9)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K10.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(10)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K11.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(11)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K12.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(12)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K13.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(13)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K14.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(14)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K15.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(15)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K16.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(16)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K17.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(17)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K18.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(18)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K19.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(19)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K20.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(20)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K21.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(21)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K22.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(22)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K23.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(23)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K24.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(24)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K25.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(25)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K26.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(26)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K27.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(27)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K28.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(28)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K29.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(29)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K30.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(30)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K31.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(31)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K32.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(32)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K33.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(33)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K34.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(34)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K35.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(35)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K36.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(36)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K37.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(37)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K38.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(38)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K39.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(39)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K40.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(40)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K41.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(41)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K42.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(42)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K47.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(49)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K43.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(43)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K44.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(44)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K45.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(45)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K48.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(70)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K49.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(71)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K50.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(72)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K51.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(73)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If

        If chk_K52.Checked = True Then
            LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(74)", ""), 100, HorizontalAlignment.Left)
            cifTeh(intj + 1) = LvKompOtd.Columns.Count
        End If


        Call Pereschet()
        Call Refresh_otdellist()

        ResList(Me.LvKompOtd)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Pereschet()

        Dim intj As Long = 0

        If chk_K1.Checked = 1 Then
            intj = intj + 1
            cifTeh(1) = intj
        Else
            cifTeh(1) = 0
        End If

        If chk_K2.Checked = True Then
            intj = intj + 1
            cifTeh(2) = intj
        Else
            cifTeh(2) = 0
        End If

        If chk_K3.Checked = True Then
            intj = intj + 1
            cifTeh(3) = intj
        Else
            cifTeh(3) = 0
        End If

        If chk_K4.Checked = True Then
            intj = intj + 1
            cifTeh(4) = intj
        Else
            cifTeh(4) = 0
        End If

        If chk_K5.Checked = True Then
            intj = intj + 1
            cifTeh(5) = intj
        Else
            cifTeh(5) = 0
        End If

        If chk_K6.Checked = True Then
            intj = intj + 1
            cifTeh(6) = intj
        Else
            cifTeh(6) = 0
        End If

        If chk_K7.Checked = True Then
            intj = intj + 1
            cifTeh(7) = intj
        Else
            cifTeh(7) = 0
        End If
        If chk_K8.Checked = True Then
            intj = intj + 1
            cifTeh(8) = intj
        Else
            cifTeh(8) = 0
        End If

        If chk_K9.Checked = True Then
            intj = intj + 1
            cifTeh(9) = intj
        Else
            cifTeh(9) = 0
        End If
        If chk_K10.Checked = True Then
            intj = intj + 1
            cifTeh(10) = intj
        Else
            cifTeh(10) = 0
        End If
        If chk_K11.Checked = True Then
            intj = intj + 1
            cifTeh(11) = intj
        Else
            cifTeh(11) = 0
        End If
        If chk_K12.Checked = True Then
            intj = intj + 1
            cifTeh(12) = intj
        Else
            cifTeh(12) = 0
        End If
        If chk_K13.Checked = True Then
            intj = intj + 1
            cifTeh(13) = intj
        Else
            cifTeh(13) = 0
        End If
        If chk_K14.Checked = True Then
            intj = intj + 1
            cifTeh(14) = intj
        Else
            cifTeh(14) = 0
        End If
        If chk_K15.Checked = True Then
            intj = intj + 1
            cifTeh(15) = intj
        Else
            cifTeh(15) = 0
        End If
        If chk_K16.Checked = True Then
            intj = intj + 1
            cifTeh(16) = intj
        Else
            cifTeh(16) = 0
        End If
        If chk_K17.Checked = True Then
            intj = intj + 1
            cifTeh(17) = intj
        Else
            cifTeh(17) = 0
        End If
        If chk_K18.Checked = True Then
            intj = intj + 1
            cifTeh(18) = intj
        Else
            cifTeh(18) = 0
        End If
        If chk_K19.Checked = True Then
            intj = intj + 1
            cifTeh(19) = intj
        Else
            cifTeh(19) = 0
        End If
        If chk_K20.Checked = True Then
            intj = intj + 1
            cifTeh(20) = intj
        Else
            cifTeh(20) = 0
        End If
        If chk_K21.Checked = True Then
            intj = intj + 1
            cifTeh(21) = intj
        Else
            cifTeh(21) = 0
        End If
        If chk_K22.Checked = True Then
            intj = intj + 1
            cifTeh(22) = intj
        Else
            cifTeh(22) = 0
        End If
        If chk_K23.Checked = True Then
            intj = intj + 1
            cifTeh(23) = intj
        Else
            cifTeh(23) = 0
        End If
        If chk_K24.Checked = True Then
            intj = intj + 1
            cifTeh(24) = intj
        Else
            cifTeh(24) = 0
        End If
        If chk_K25.Checked = True Then
            intj = intj + 1
            cifTeh(25) = intj
        Else
            cifTeh(25) = 0
        End If
        If chk_K26.Checked = True Then
            intj = intj + 1
            cifTeh(26) = intj
        Else
            cifTeh(26) = 0
        End If
        If chk_K27.Checked = True Then
            intj = intj + 1
            cifTeh(27) = intj
        Else
            cifTeh(27) = 0
        End If
        If chk_K28.Checked = True Then
            intj = intj + 1
            cifTeh(28) = intj
        Else
            cifTeh(28) = 0
        End If
        If chk_K29.Checked = True Then
            intj = intj + 1
            cifTeh(29) = intj
        Else
            cifTeh(29) = 0
        End If
        If chk_K30.Checked = True Then
            intj = intj + 1
            cifTeh(30) = intj
        Else
            cifTeh(30) = 0
        End If
        If chk_K31.Checked = True Then
            intj = intj + 1
            cifTeh(31) = intj
        Else
            cifTeh(31) = 0
        End If
        If chk_K32.Checked = True Then
            intj = intj + 1
            cifTeh(32) = intj
        Else
            cifTeh(32) = 0
        End If
        If chk_K33.Checked = True Then
            intj = intj + 1
            cifTeh(33) = intj
        Else
            cifTeh(33) = 0
        End If
        If chk_K34.Checked = True Then
            intj = intj + 1
            cifTeh(34) = intj
        Else
            cifTeh(34) = 0
        End If
        If chk_K35.Checked = True Then
            intj = intj + 1
            cifTeh(35) = intj
        Else
            cifTeh(35) = 0
        End If
        If chk_K36.Checked = True Then
            intj = intj + 1
            cifTeh(36) = intj
        Else
            cifTeh(36) = 0
        End If
        If chk_K37.Checked = True Then
            intj = intj + 1
            cifTeh(37) = intj
        Else
            cifTeh(37) = 0
        End If

        If chk_K38.Checked = True Then
            intj = intj + 1
            cifTeh(38) = intj
        Else
            cifTeh(38) = 0
        End If

        If chk_K39.Checked = True Then
            intj = intj + 1
            cifTeh(39) = intj
        Else
            cifTeh(39) = 0
        End If

        If chk_K40.Checked = True Then
            intj = intj + 1
            cifTeh(40) = intj
        Else
            cifTeh(40) = 0
        End If
        If chk_K41.Checked = True Then
            intj = intj + 1
            cifTeh(41) = intj
        Else
            cifTeh(41) = 0
        End If
        If chk_K42.Checked = True Then
            intj = intj + 1
            cifTeh(42) = intj
        Else
            cifTeh(42) = 0
        End If

        If chk_K47.Checked = True Then
            intj = intj + 1
            cifTeh(47) = intj
        Else
            cifTeh(47) = 0
        End If

        If chk_K43.Checked = True Then
            intj = intj + 1
            cifTeh(43) = intj
        Else
            cifTeh(43) = 0
        End If
        If chk_K44.Checked = True Then
            intj = intj + 1
            cifTeh(44) = intj
        Else
            cifTeh(44) = 0
        End If

        If chk_K45.Checked = True Then
            intj = intj + 1
            cifTeh(45) = intj
        Else
            cifTeh(45) = 0
        End If


        If chk_K46.Checked = True Then
            intj = intj + 1
            cifTeh(46) = intj
        Else
            cifTeh(46) = 0
        End If

        If chk_K48.Checked = True Then
            intj = intj + 1
            cifTeh(48) = intj
        Else
            cifTeh(48) = 0
        End If

        If chk_K49.Checked = True Then
            intj = intj + 1
            cifTeh(49) = intj
        Else
            cifTeh(49) = 0
        End If

        If chk_K50.Checked = True Then
            intj = intj + 1
            cifTeh(50) = intj
        Else
            cifTeh(50) = 0
        End If

        If chk_K51.Checked = True Then
            intj = intj + 1
            cifTeh(51) = intj
        Else
            cifTeh(51) = 0
        End If

        If chk_K52.Checked = True Then
            intj = intj + 1
            cifTeh(52) = intj
        Else
            cifTeh(52) = 0
        End If

    End Sub

    Private Sub Refresh_otdellist()
        On Error GoTo Error_
        Dim langIni As New IniFile(sLANGPATH)


        If Len(cmbBranche.Text) = 0 Then Exit Sub
        If Len(cmbDepartment.Text) = 0 Then cmbDepartment.Text = langIni.GetString("frmReports", "MSG1", "")
        If Len(cmbOffice.Text) = 0 Then cmbOffice.Text = langIni.GetString("frmReports", "MSG1", "")


        Call Pereschet()


        pTEXT(1) = langIni.GetString("frmReports", "MSG1", "")


        If optPC.Checked = True Then TIPST = "PC"

        If optOTH.Checked = True Then TIPST = "OTH"


        Select Case TIPST


            Case "PC"

                Call Refr_KOMPL_PC()


            Case "OTH"

                Call Refr_KOMPL_OTHER()

        End Select

        'ListViewRavn(master_otch.LvKompOtd, master_otch)


        Exit Sub
Error_:
        Debug.Print(Err.Description)

    End Sub

    Private Sub Refr_KOMPL_PC()
        On Error GoTo Error_
        'On Error Resume Next



        LvKompOtd.Items.Clear()



        Dim sSQL As String


        If cmbBranche.Text = pTEXT(1) Then
            sSQL = "SELECT * FROM kompy WHERE tiptehn = 'PC' ORDER BY FILIAL, NET_NAME"
        Else
        End If

        If cmbBranche.Text = pTEXT(2) Then
            sSQL = "SELECT * FROM kompy WHERE mesto = '" & cmbDepartment.Text & "' and tiptehn = 'PC' ORDER BY mesto, NET_NAME"
        Else
        End If

        If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text <> pTEXT(1) And cmbBranche.Text <> pTEXT(2) Then
            sSQL = "SELECT * FROM kompy WHERE tiptehn = 'PC' and filial = '" & cmbBranche.Text & "' AND mesto = '" & cmbDepartment.Text & "' ORDER BY FILIAL, NET_NAME"
        Else
        End If

        If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text = pTEXT(1) And cmbOffice.Text = pTEXT(1) Then
            sSQL = "SELECT * FROM kompy WHERE tiptehn = 'PC' and filial = '" & cmbBranche.Text & "' ORDER BY FILIAL, NET_NAME"
        Else
        End If


        If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text <> pTEXT(1) And cmbBranche.Text <> pTEXT(2) And cmbOffice.Text <> pTEXT(1) Then
            sSQL = "SELECT * FROM kompy WHERE tiptehn = 'PC' and filial = '" & cmbBranche.Text & "' AND mesto = '" & cmbDepartment.Text & "' AND kabn='" & cmbOffice.Text & "' ORDER BY FILIAL, NET_NAME"
        Else
        End If

        'If cmbBranche.Text = pTEXT(1) And cmbDepartment.Text = pTEXT(1) And cmbOffice.Text = pTEXT(1) Then
        '    sSQL = "SELECT * FROM kompy WHERE tiptehn = 'PC' ORDER BY FILIAL, NET_NAME"
        'Else
        'End If

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        Dim unamS As String
        Dim intj As Long = 0

        Dim A1, A2, A3, A4 As String

        With rs
            .MoveFirst()
            Do Until rs.EOF



                LvKompOtd.Items.Add(.Fields("NET_NAME").Value) 'col no. 1

                'If Len(.Fields("nomerPC").Value) <> 0 Then unamS = .Fields("nomerPC").Value Else 
                unamS = .Fields("Id").Value


                A1 = .Fields("CPU1").Value & " " & .Fields("CPUmhz1").Value
                A2 = .Fields("CPU2").Value & " " & .Fields("CPUmhz2").Value
                A3 = .Fields("CPU3").Value & " " & .Fields("CPUmhz3").Value
                A4 = .Fields("CPU4").Value & " " & .Fields("CPUmhz4").Value


                'LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("CPU1").Value & " " & .Fields("CPUmhz1").Value & " / " & .Fields("CPU2").Value & " " & .Fields("CPUmhz2").Value & " / " & .Fields("CPU3").Value & " " & .Fields("CPUmhz3").Value & " / " & .Fields("CPU4").Value & " " & .Fields("CPUmhz4").Value)

                If chkTeh(1) = True Then

                    If Len(A1) > 3 Then
                        A1 = A1
                    End If

                    If Len(A2) > 3 Then
                        A1 = A1 & " / " & A2
                    End If

                    If Len(A3) > 3 Then
                        A1 = A1 & " / " & A3
                    End If

                    If Len(A4) > 3 Then
                        A1 = A1 & " / " & A4
                    End If

                    LvKompOtd.Items(CInt(intj)).SubItems.Add(A1)
                End If






                If chkTeh(2) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("MB").Value)
                If chkTeh(3) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("SVGA_NAME").Value & " " & .Fields("SVGA_OB_RAM").Value)
                If chkTeh(4) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("SOUND_NAME").Value)


                If chkTeh(5) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_Name_1").Value & ", " & .Fields("HDD_OB_1").Value)
                If chkTeh(6) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_SN_1").Value)

                If chkTeh(7) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_Name_2").Value & ", " & .Fields("HDD_OB_2").Value)
                If chkTeh(8) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_SN_2").Value)

                If chkTeh(9) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_Name_3").Value & ", " & .Fields("HDD_OB_3").Value)
                If chkTeh(10) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_SN_3").Value)

                If chkTeh(11) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_Name_4").Value & ", " & .Fields("HDD_OB_4").Value)
                If chkTeh(12) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("HDD_SN_4").Value)

                'Память
                If chkTeh(13) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("RAM_1").Value)
                If chkTeh(14) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("RAM_2").Value)
                If chkTeh(15) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("RAM_3").Value)
                If chkTeh(16) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("RAM_4").Value)


                If chkTeh(17) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("CD_NAME").Value & " " & .Fields("CD_SPEED").Value)
                If chkTeh(18) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("CDRW_NAME").Value & " " & .Fields("CDRW_SPEED").Value)
                If chkTeh(19) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("DVD_NAME").Value & " " & .Fields("DVD_SPEED").Value)

                If chkTeh(20) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("NET_NAME_1").Value)
                If chkTeh(21) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("NET_NAME_2").Value)


                If chkTeh(22) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("NET_IP_1").Value)
                If chkTeh(23) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("NET_IP_2").Value)

                If chkTeh(24) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("NET_MAC_1").Value)
                If chkTeh(25) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("NET_MAC_2").Value)

                If chkTeh(26) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("FDD_NAME").Value)


                If chkTeh(27) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("SYS_PR").Value)
                If chkTeh(28) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("Ser_N_SIS").Value)

                If chkTeh(29) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("MONITOR_NAME").Value)
                If chkTeh(30) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("MONITOR_SN").Value)
                If chkTeh(31) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("PRINTER_NAME_1").Value)
                If chkTeh(32) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("PRINTER_NAME_2").Value)
                If chkTeh(33) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("PRINTER_NAME_3").Value)
                If chkTeh(34) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("AS_NAME").Value)
                If chkTeh(35) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("MODEM_NAME").Value)
                If chkTeh(36) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("KEYBOARD_NAME").Value)

                If chkTeh(37) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("MOUSE_NAME").Value)

                If chkTeh(38) = True Then
                    If Not IsDBNull(.Fields("CASE_NAME").Value) Then
                        LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("CASE_NAME").Value)
                    Else
                        LvKompOtd.Items(CInt(intj)).SubItems.Add("")

                    End If


                End If


                If chkTeh(39) = True Then
                    If Not IsDBNull(.Fields("BLOCK").Value) Then
                        LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("BLOCK").Value)
                    Else
                        LvKompOtd.Items(CInt(intj)).SubItems.Add("")

                    End If

                End If


                If chkTeh(40) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_SYSTEM").Value)
                If chkTeh(41) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_MONITOR").Value)
                If chkTeh(42) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_IBP").Value)
                If chkTeh(47) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                If chkTeh(43) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("PSEVDONIM").Value)
                If chkTeh(44) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("OtvetstvennyJ").Value)


                If Len(.Fields("filial").Value) = 0 Then
                    If chkTeh(45) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("mesto").Value)
                Else
                    If chkTeh(45) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("filial").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                End If

                If chkTeh(48) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("StoimRub").Value)

                If chkTeh(49) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("DataVVoda").Value)


                If chkTeh(50) = True Then

                    Dim rsP As ADODB.Recordset
                    rsP = New ADODB.Recordset

                    rsP.Open("SELECT count(*) as t_n FROM Garantia_sis where id_Comp =" & .Fields("id").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    Dim sUNAME As Integer
                    With rsP
                        sUNAME = .Fields("t_n").Value
                    End With
                    rsP.Close()
                    rsP = Nothing

                    If sUNAME > 0 Then

                        rsP = New ADODB.Recordset

                        rsP.Open("SELECT postav FROM Garantia_sis where id_Comp =" & .Fields("id").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rsP
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("postav").Value)
                        End With
                        rsP.Close()
                        rsP = Nothing

                    Else

                        LvKompOtd.Items(CInt(intj)).SubItems.Add("")

                    End If


                    'LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("SYS_PR").Value)
                End If


                If chkTeh(51) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("TIP_COMPA").Value)





                If chkTeh(52) = True Then

                    Dim rsP As ADODB.Recordset
                    rsP = New ADODB.Recordset

                    rsP.Open("SELECT count(*) as t_n FROM USER_COMP where ID_COMP =" & .Fields("id").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    Dim sUNAME As Integer
                    With rsP
                        sUNAME = .Fields("t_n").Value
                    End With
                    rsP.Close()
                    rsP = Nothing

                    If sUNAME > 0 Then

                        rsP = New ADODB.Recordset

                        rsP.Open("SELECT FIO FROM USER_COMP where ID_COMP =" & .Fields("id").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rsP
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("FIO").Value)
                        End With
                        rsP.Close()
                        rsP = Nothing

                    Else

                        LvKompOtd.Items(CInt(intj)).SubItems.Add("")

                    End If

                End If





                'If chkTeh(46) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(unamS)

                intj = intj + 1
                .MoveNext()
            Loop

        End With
        rs.Close()
        rs = Nothing




        Exit Sub
Error_:
        Debug.Print(Err.Description)
        MsgBox(Err.Description)
    End Sub

    Private Sub Refr_KOMPL_OTHER()

        On Error GoTo Error_

        On Error Resume Next
        Dim langIni As New IniFile(sLANGPATH)



        LvKompOtd.Items.Clear()

        Dim rs As ADODB.Recordset
        Dim sSQL As String

        'cmbOthers<>pTEXT(1)



        If cmbOthers.Text = pTEXT(1) Then

            If cmbBranche.Text = pTEXT(1) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn <> 'PC' ORDER BY FILIAL, NET_NAME"
            Else
            End If

            If cmbBranche.Text = pTEXT(2) Then
                sSQL = "SELECT * FROM kompy WHERE mesto = '" & cmbDepartment.Text & "' and tiptehn <> 'PC' ORDER BY mesto, NET_NAME"
            Else
            End If

            If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text <> pTEXT(1) And cmbBranche.Text <> pTEXT(2) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn <> 'PC' and filial = '" & cmbBranche.Text & "' AND mesto = '" & cmbDepartment.Text & "' ORDER BY FILIAL, NET_NAME"
            Else
            End If


            If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text = pTEXT(1) And cmbOffice.Text = pTEXT(1) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn <> 'PC' and filial = '" & cmbBranche.Text & "' ORDER BY FILIAL, NET_NAME"
            Else
            End If


            If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text <> pTEXT(1) And cmbBranche.Text <> pTEXT(2) And cmbOffice.Text <> pTEXT(1) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn <> 'PC' and filial = '" & cmbBranche.Text & "' AND mesto = '" & cmbDepartment.Text & "' AND kabn='" & cmbOffice.Text & "' ORDER BY FILIAL, NET_NAME"
            Else
            End If

        Else

            Dim sTEXTP


            Select Case cmbOthers.Text

                Case langIni.GetString("frmMain", "28", "")

                    sTEXTP = "KOpir"

                Case langIni.GetString("frmMain", "29", "")

                    sTEXTP = "Printer"


                Case langIni.GetString("frmMain", "30", "")

                    sTEXTP = "MFU"


                Case langIni.GetString("frmMain", "31", "")

                    sTEXTP = "NET"


                Case langIni.GetString("frmMain", "32", "")

                    sTEXTP = "PHONE"

                Case langIni.GetString("frmMain", "33", "")

                    sTEXTP = "PHOTO"

                Case langIni.GetString("frmMain", "34", "")


                    sTEXTP = "FAX"


                Case langIni.GetString("frmMain", "35", "")

                   
                    sTEXTP = "MONITOR"

                Case langIni.GetString("frmMain", "36", "")

                    sTEXTP = "ZIP"

                Case langIni.GetString("frmMain", "37", "")

                    sTEXTP = "SCANER"

                Case langIni.GetString("frmMain", "38", "")

                    sTEXTP = "OT"

                Case langIni.GetString("frmMain", "39", "")

                    sTEXTP = "USB"

                Case langIni.GetString("frmMain", "40", "")

                    sTEXTP = "SOUND"

                Case langIni.GetString("frmMain", "41", "")

                    sTEXTP = "IBP"

                Case Else



            End Select



            If cmbBranche.Text = pTEXT(1) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn ='" & sTEXTP & "' ORDER BY FILIAL, NET_NAME"
            Else
            End If

            If cmbBranche.Text = pTEXT(2) Then
                sSQL = "SELECT * FROM kompy WHERE mesto = '" & cmbDepartment.Text & "' and tiptehn = '" & sTEXTP & "' ORDER BY mesto, NET_NAME"
            Else
            End If

            If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text <> pTEXT(1) And cmbBranche.Text <> pTEXT(2) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn = '" & sTEXTP & "' and filial = '" & cmbBranche.Text & "' AND mesto = '" & cmbDepartment.Text & "' ORDER BY FILIAL, NET_NAME"
            Else
            End If


            If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text = pTEXT(1) And cmbOffice.Text = pTEXT(1) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn = '" & sTEXTP & "' and filial = '" & cmbBranche.Text & "' ORDER BY FILIAL, NET_NAME"
            Else
            End If


            If cmbBranche.Text <> pTEXT(1) And cmbDepartment.Text <> pTEXT(1) And cmbBranche.Text <> pTEXT(2) And cmbOffice.Text <> pTEXT(1) Then
                sSQL = "SELECT * FROM kompy WHERE tiptehn = '" & sTEXTP & "' and filial = '" & cmbBranche.Text & "' AND mesto = '" & cmbDepartment.Text & "' AND kabn='" & cmbOffice.Text & "' ORDER BY FILIAL, NET_NAME"
            Else
            End If

        End If




        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)





        LvKompOtd.Columns.Clear()
        LvKompOtd.Columns.Add((langIni.GetString("frmReports", "B(49)", "")), 1, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add((langIni.GetString("frmReports", "B(50)", "")), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add((langIni.GetString("frmReports", "B(51)", "")), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add((langIni.GetString("frmReports", "B(52)", "")), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add((langIni.GetString("frmReports", "B(53)", "")), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add((langIni.GetString("frmReports", "B(54)", "")), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add((langIni.GetString("frmReports", "B(55)", "")), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(70)", ""), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(71)", ""), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add(langIni.GetString("frmReports", "B(72)", ""), 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add("IP", 100, HorizontalAlignment.Left)
        LvKompOtd.Columns.Add("MAC", 100, HorizontalAlignment.Left)
        'If chkTeh(49) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("DataVVoda").Value)
        'If chkTeh(50) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("SYS_PR").Value)

        Dim intj As Long = 0
        Dim unamS As String


        With rs
            .MoveFirst()
            Do Until rs.EOF


                If cmbBranche.Text = rs.Fields("mesto").Value Or cmbBranche.Text = pTEXT(1) Or cmbBranche.Text = rs.Fields("filial").Value Then


                    LvKompOtd.Items.Add(.Fields("Id").Value)

                    If rs.Fields("tiptehn").Value = "MONITOR" Then
                        'LvKompOtd.Items.Add(.Fields("MONITOR_NAME").Value)

                        LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("MONITOR_NAME").Value)
                    Else
                        'LvKompOtd.Items.Add(.Fields("NET_NAME").Value)
                        LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("NET_NAME").Value)
                        'mesto_.Visible = True
                    End If


                    If Len(.Fields("filial").Value) = 0 Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("mesto").Value) Else LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("filial").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)

                    '###################################################################
                    'Вычисляем поставщика
                    '###################################################################

                    Dim rsP As ADODB.Recordset
                    rsP = New ADODB.Recordset

                    rsP.Open("SELECT count(*) as t_n FROM Garantia_sis where id_Comp =" & .Fields("id").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    Dim sUNAME As Integer
                    Dim tUNAME As String

                    With rsP
                        sUNAME = .Fields("t_n").Value
                    End With
                    rsP.Close()
                    rsP = Nothing

                    If sUNAME > 0 Then

                        rsP = New ADODB.Recordset

                        rsP.Open("SELECT postav FROM Garantia_sis where id_Comp =" & .Fields("id").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rsP
                            tUNAME = .Fields("postav").Value
                        End With
                        rsP.Close()
                        rsP = Nothing

                    Else

                        tUNAME = ""

                    End If

                    '###################################################################
                    '###################################################################
                    '###################################################################


                    Select Case .Fields("tiptehn").Value


                        Case "PHOTO"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(56)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                            'If chkTeh(49) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("DataVVoda").Value)
                            'If chkTeh(50) = True Then LvKompOtd.Items(CInt(intj)).SubItems.Add(.Fields("SYS_PR").Value)

                        Case "PHONE"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(57)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "FAX"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(58)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "SCANER"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(59)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "ZIP"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(60)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "OT"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("TIP_COMPA").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "KEYB"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("TIP_COMPA").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "MOUSE"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("TIP_COMPA").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)



                        Case "MONITOR"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(61)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("MONITOR_SN").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_MONITOR").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                            'INV_NO_MONITOR
                        Case "NET"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(62)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PORT_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_PROIZV_3").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "Printer"


                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(63)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "KOpir"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(64)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "MFU"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(65)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "USB"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(66)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "SOUND"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(67)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "IBP"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(68)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                        Case "FS"

                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("OtvetstvennyJ").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(langIni.GetString("frmReports", "B(69)", ""))
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("PRINTER_SN_1").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("INV_NO_PRINTER").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("StoimRub").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("DataVVoda").Value)
                            LvKompOtd.Items(CInt(intj)).SubItems.Add(tUNAME)

                    End Select


                    LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("NET_IP_1").Value)
                    LvKompOtd.Items(CInt(intj)).SubItems.Add(rs.Fields("NET_MAC_1").Value)

                    intj = intj + 1


                Else
                End If
                .MoveNext()
            Loop
        End With

        Exit Sub
Error_:
        Debug.Print(Err.Description)

    End Sub

    Private Sub optPC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPC.CheckedChanged
        TIPST = "PC"
        gbSN.Enabled = True
        gbPer.Enabled = True
        gbInf.Enabled = True

        cmbOthers.Visible = False
    End Sub

    Private Sub optOTH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOTH.CheckedChanged
        Dim langIni As New IniFile(sLANGPATH)

        TIPST = "OTH"

        gbSN.Enabled = False
        gbPer.Enabled = False
        gbInf.Enabled = False


        cmbOthers.Visible = True
        cmbOthers.Text = (langIni.GetString("frmReports", "MSG1", ""))


    End Sub

    Private Sub chk_K15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K15.CheckedChanged
        Select Case chk_K15.Checked

            Case True
                chkTeh(15) = True
            Case Else
                chkTeh(15) = False
        End Select
    End Sub

    Private Sub chk_K17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K17.CheckedChanged
        Select Case chk_K17.Checked

            Case True
                chkTeh(17) = True
            Case Else
                chkTeh(17) = False
        End Select
    End Sub

    Private Sub chk_K16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K16.CheckedChanged
        Select Case chk_K16.Checked

            Case True
                chkTeh(16) = True
            Case Else
                chkTeh(16) = False
        End Select
    End Sub

    Private Sub chk_K18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K18.CheckedChanged
        Select Case chk_K18.Checked

            Case True
                chkTeh(18) = True
            Case Else
                chkTeh(18) = False
        End Select
    End Sub

    Private Sub chk_K19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K19.CheckedChanged
        Select Case chk_K19.Checked

            Case True
                chkTeh(19) = True
            Case Else
                chkTeh(19) = False
        End Select
    End Sub

    Private Sub chk_K20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K20.CheckedChanged
        Select Case chk_K20.Checked

            Case True
                chkTeh(20) = True
            Case Else
                chkTeh(20) = False
        End Select
    End Sub

    Private Sub chk_K21_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K21.CheckedChanged
        Select Case chk_K21.Checked

            Case True
                chkTeh(21) = True
            Case Else
                chkTeh(21) = False
        End Select
    End Sub

    Private Sub chk_K22_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K22.CheckedChanged
        Select Case chk_K22.Checked

            Case True
                chkTeh(22) = True
            Case Else
                chkTeh(22) = False
        End Select
    End Sub

    Private Sub chk_K23_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K23.CheckedChanged
        Select Case chk_K23.Checked

            Case True
                chkTeh(23) = True
            Case Else
                chkTeh(23) = False
        End Select
    End Sub

    Private Sub chk_K24_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K24.CheckedChanged
        Select Case chk_K24.Checked

            Case True
                chkTeh(24) = True
            Case Else
                chkTeh(24) = False
        End Select
    End Sub

    Private Sub chk_K25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K25.CheckedChanged
        Select Case chk_K25.Checked

            Case True
                chkTeh(25) = True
            Case Else
                chkTeh(25) = False
        End Select
    End Sub

    Private Sub chk_K27_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K27.CheckedChanged
        Select Case chk_K27.Checked

            Case True
                chkTeh(27) = True
            Case Else
                chkTeh(27) = False
        End Select
    End Sub

    Private Sub chk_K26_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K26.CheckedChanged
        Select Case chk_K26.Checked

            Case True
                chkTeh(26) = True
            Case Else
                chkTeh(26) = False
        End Select
    End Sub

    Private Sub chk_K28_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K28.CheckedChanged
        Select Case chk_K28.Checked

            Case True
                chkTeh(28) = True
            Case Else
                chkTeh(28) = False
        End Select
    End Sub

    Private Sub chk_K1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K1.CheckedChanged

        Select Case chk_K1.Checked

            Case True
                chkTeh(1) = True
            Case Else
                chkTeh(1) = False
        End Select


    End Sub

    Private Sub chk_K2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K2.CheckedChanged

        Select Case chk_K2.Checked

            Case True
                chkTeh(2) = True
            Case Else
                chkTeh(2) = False
        End Select
    End Sub

    Private Sub chk_K3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K3.CheckedChanged

        Select Case chk_K3.Checked

            Case True
                chkTeh(3) = True
            Case Else
                chkTeh(3) = False
        End Select

    End Sub

    Private Sub chk_K4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K4.CheckedChanged
        Select Case chk_K4.Checked

            Case True
                chkTeh(4) = True
            Case Else
                chkTeh(4) = False
        End Select
    End Sub

    Private Sub chk_K5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K5.CheckedChanged
        Select Case chk_K5.Checked

            Case True
                chkTeh(5) = True
            Case Else
                chkTeh(5) = False
        End Select
    End Sub

    Private Sub chk_K6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K6.CheckedChanged
        Select Case chk_K6.Checked

            Case True
                chkTeh(6) = True
            Case Else
                chkTeh(6) = False
        End Select
    End Sub

    Private Sub chk_K7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K7.CheckedChanged
        Select Case chk_K7.Checked

            Case True
                chkTeh(7) = True
            Case Else
                chkTeh(7) = False
        End Select
    End Sub

    Private Sub chk_K8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K8.CheckedChanged
        Select Case chk_K8.Checked

            Case True
                chkTeh(8) = True
            Case Else
                chkTeh(8) = False
        End Select
    End Sub

    Private Sub chk_K9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K9.CheckedChanged
        Select Case chk_K9.Checked

            Case True
                chkTeh(9) = True
            Case Else
                chkTeh(9) = False
        End Select
    End Sub

    Private Sub chk_K10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K10.CheckedChanged
        Select Case chk_K10.Checked

            Case True
                chkTeh(10) = True
            Case Else
                chkTeh(10) = False
        End Select
    End Sub

    Private Sub chk_K11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K11.CheckedChanged
        Select Case chk_K11.Checked

            Case True
                chkTeh(11) = True
            Case Else
                chkTeh(11) = False
        End Select
    End Sub

    Private Sub chk_K12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K12.CheckedChanged
        Select Case chk_K12.Checked

            Case True
                chkTeh(12) = True
            Case Else
                chkTeh(12) = False
        End Select
    End Sub

    Private Sub chk_K13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K13.CheckedChanged
        Select Case chk_K13.Checked

            Case True
                chkTeh(13) = True
            Case Else
                chkTeh(13) = False
        End Select
    End Sub

    Private Sub chk_K14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K14.CheckedChanged
        Select Case chk_K14.Checked

            Case True
                chkTeh(14) = True
            Case Else
                chkTeh(14) = False
        End Select
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartment.SelectedIndexChanged
        '
        Dim langIni As New IniFile(sLANGPATH)

        On Error GoTo err_

        cmbOffice.Items.Clear()

        If cmbDepartment.Text = langIni.GetString("frmReports", "MSG1", "") Then

            cmbOffice.Items.Add(langIni.GetString("frmReports", "MSG1", ""))
            cmbOffice.Text = langIni.GetString("frmReports", "MSG1", "")


            Exit Sub
        End If

        If Len(cmbOffice.Text) = 0 Then cmbOffice.Text = langIni.GetString("frmReports", "MSG1", "")

        Dim rs1 As ADODB.Recordset

        rs1 = New ADODB.Recordset
        rs1.Open("select count(*) as t_n from SPR_KAB WHERE N_F='" & cmbBranche.Text & "' AND N_M='" & cmbDepartment.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sCNN As Integer

        With rs1
            sCNN = .Fields("t_n").Value
        End With

        rs1.Close()
        rs1 = Nothing


        If sCNN > 0 Then
            rs1 = New ADODB.Recordset
            rs1.Open("select * from SPR_KAB WHERE N_F='" & cmbBranche.Text & "' AND N_M='" & cmbDepartment.Text & "' ORDER BY Name", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


            With rs1
                .MoveFirst()
                Do While Not .EOF

                    If Not IsDBNull(.Fields("Name").Value) Then cmbOffice.Items.Add(.Fields("Name").Value)

                    .MoveNext()
                Loop
            End With

            cmbOffice.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

            rs1.Close()
            rs1 = Nothing
        Else

            cmbOffice.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        End If



        Exit Sub
err_:
        'MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)

    End Sub

    Private Sub chk_K29_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K29.CheckedChanged
        Select Case chk_K29.Checked

            Case True
                chkTeh(29) = True
            Case Else
                chkTeh(29) = False
        End Select
    End Sub

    Private Sub chk_K30_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K30.CheckedChanged
        Select Case chk_K30.Checked

            Case True
                chkTeh(30) = True
            Case Else
                chkTeh(30) = False
        End Select
    End Sub

    Private Sub chk_K31_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K31.CheckedChanged
        Select Case chk_K31.Checked

            Case True
                chkTeh(31) = True
            Case Else
                chkTeh(31) = False
        End Select
    End Sub

    Private Sub chk_K32_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K32.CheckedChanged
        Select Case chk_K32.Checked

            Case True
                chkTeh(32) = True
            Case Else
                chkTeh(32) = False
        End Select
    End Sub

    Private Sub chk_K33_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K33.CheckedChanged
        Select Case chk_K33.Checked

            Case True
                chkTeh(33) = True
            Case Else
                chkTeh(33) = False
        End Select
    End Sub

    Private Sub chk_K34_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K34.CheckedChanged
        Select Case chk_K34.Checked

            Case True
                chkTeh(34) = True
            Case Else
                chkTeh(34) = False
        End Select
    End Sub

    Private Sub chk_K36_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K36.CheckedChanged
        Select Case chk_K36.Checked

            Case True
                chkTeh(36) = True
            Case Else
                chkTeh(36) = False
        End Select
    End Sub

    Private Sub chk_K35_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K35.CheckedChanged
        Select Case chk_K35.Checked

            Case True
                chkTeh(35) = True
            Case Else
                chkTeh(35) = False
        End Select
    End Sub

    Private Sub chk_K37_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K37.CheckedChanged
        Select Case chk_K37.Checked

            Case True
                chkTeh(37) = True
            Case Else
                chkTeh(37) = False
        End Select
    End Sub

    Private Sub chk_K38_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K38.CheckedChanged
        Select Case chk_K38.Checked

            Case True
                chkTeh(38) = True
            Case Else
                chkTeh(38) = False
        End Select
    End Sub

    Private Sub chk_K39_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K39.CheckedChanged
        Select Case chk_K39.Checked

            Case True
                chkTeh(39) = True
            Case Else
                chkTeh(39) = False
        End Select
    End Sub

    Private Sub chk_K40_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K40.CheckedChanged
        Select Case chk_K40.Checked

            Case True
                chkTeh(40) = True
            Case Else
                chkTeh(40) = False
        End Select
    End Sub

    Private Sub chk_K41_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K41.CheckedChanged
        Select Case chk_K41.Checked

            Case True
                chkTeh(41) = True
            Case Else
                chkTeh(41) = False
        End Select
    End Sub

    Private Sub chk_K42_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K42.CheckedChanged
        Select Case chk_K42.Checked

            Case True
                chkTeh(42) = True
            Case Else
                chkTeh(42) = False
        End Select
    End Sub

    Private Sub chk_K43_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K43.CheckedChanged
        Select Case chk_K43.Checked

            Case True
                chkTeh(43) = True
            Case Else
                chkTeh(43) = False
        End Select
    End Sub

    Private Sub chk_K44_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K44.CheckedChanged
        Select Case chk_K44.Checked

            Case True
                chkTeh(44) = True
            Case Else
                chkTeh(44) = False
        End Select
    End Sub

    Private Sub chk_K45_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K45.CheckedChanged
        Select Case chk_K45.Checked

            Case True
                chkTeh(45) = True
            Case Else
                chkTeh(45) = False
        End Select
    End Sub

    Private Sub LvKompOtd_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles LvKompOtd.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
     LvKompOtd.Columns(e.Column)
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

        LvKompOtd.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        LvKompOtd.Sort()
    End Sub

    Private Sub cmbGar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGar.SelectedIndexChanged

        Dim newThread1 As New Thread(AddressOf GaRanT_Load_t)
        newThread1.Start()
        ''newThread1.Priority = 4

    End Sub

    Private Sub GaRanT_Load_t()

        Me.BeginInvoke(New MethodInvoker(AddressOf GaRanT_Load))

    End Sub


    Private Sub GaRanT_Load()
        Dim ZakZ As String
        Dim dp As Date
        Dim nom As Integer
        Dim Nam As String
        Dim Komp As String
        Dim NameKomp As String
        Dim intj As Long = 0

        On Error GoTo Error_
        lvGar.Items.Clear()

        Dim Today As Date
        Dim Millenium As Date
        Dim retval

        Dim d, m, g, dat As String

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос
        Dim rs2 As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL2 As String 'Переменная, где будет размещён SQL запрос
        Dim rs3 As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL3 As String 'Переменная, где будет размещён SQL запрос



        sSQL2 = "SELECT * FROM Garantia_sis"
        rs2 = New ADODB.Recordset
        rs2.Open(sSQL2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        sSQL3 = "SELECT * FROM garant_comp"
        rs3 = New ADODB.Recordset
        rs3.Open(sSQL3, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim rscount As ADODB.Recordset 'Объявляем рекордсет
        rscount = New ADODB.Recordset
        rscount.Open("SELECT COUNT(*) AS total_number FROM Garantia_sis", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim SERT As String
        With rscount

            SERT = .Fields("total_number").Value

        End With

        rscount.Close()
        rscount = Nothing

        Dim langIni As New IniFile(sLANGPATH)

        On Error Resume Next
        With rs2

            If SERT$ > 0 Then

                .MoveFirst()
                Do While Not .EOF

                    If Not IsDBNull(.Fields("Id_Comp").Value) Then nom = .Fields("Id_Comp").Value


                    Select Case cmbGar.Text

                        Case langIni.GetString("frmReports", "MSG4", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("SVGA_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing

                        Case langIni.GetString("frmReports", "MSG5", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("HDD_Name_1").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing


                        Case langIni.GetString("frmReports", "MSG6", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("SOUND_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing

                        Case langIni.GetString("frmReports", "MSG7", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("Mb").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing

                        Case langIni.GetString("frmReports", "MSG8", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("MODEM_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing

                        Case langIni.GetString("frmReports", "MSG9", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("MONITOR_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing

                        Case langIni.GetString("frmReports", "MSG10", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("RAM_1").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing


                        Case langIni.GetString("frmReports", "MSG13", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("CPU1").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing

                    End Select

                    sSQL = "SELECT * FROM kompy where id=" & nom
                    rs = New ADODB.Recordset
                    rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    With rs
                        .MoveFirst()
                        Do While Not .EOF

                            Nam = langIni.GetString("frmReports", "MSG26", "") & ": " & .Fields("NET_NAME").Value & " " & langIni.GetString("frmReports", "MSG27", "") & ": " & .Fields("MESTO").Value & "/" & .Fields("FILIAL").Value

                            .MoveNext()
                            'DoEvents
                        Loop
                    End With
                    rs.Close()
                    rs = Nothing

                    'Вычисление окончания гарантии
                    d$ = .Fields("day_o").Value
                    m$ = .Fields("month_o").Value
                    g$ = .Fields("Year_o").Value

                    dat$ = d & "." & m & "." & g
                    If dat$ = "0.0.0" Or dat$ = ".." Then
                        dat$ = Date.Today.AddDays(-1)
                    End If

                    Today = Date.Today
                    Millenium = dat$
                    retval = DateDiff("d", Today, Millenium)
                    ZakZ = CStr(retval)


                    'If Len(dat) = 0 Then
                    'ZakZ = ""
                    'Else
                    'dp = dat
                    'ZakZ = dp - date
                    'End If

                    If ZakZ < 0 Then
                        ZakZ = "X"
                    End If


                    If Len(NameKomp) = 0 Or NameKomp = langIni.GetString("frmReports", "MSG28", "") Or NameKomp = langIni.GetString("frmReports", "MSG29", "") Then
                    Else

                        lvGar.Items.Add(NameKomp)
                        lvGar.Items(CInt(intj)).SubItems.Add(Nam)
                        lvGar.Items(CInt(intj)).SubItems.Add(.Fields("day_o").Value & "." & .Fields("month_o").Value & "." & .Fields("Year_o").Value)
                        lvGar.Items(CInt(intj)).SubItems.Add(ZakZ)
                        lvGar.Items(CInt(intj)).SubItems.Add("+")

                        intj = intj + 1
                    End If
                    .MoveNext()
                    'DoEvents

                Loop
            End If
        End With

        rscount = New ADODB.Recordset
        rscount.Open("SELECT COUNT(*) AS total_number FROM garant_comp", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rscount

            SERT$ = .Fields("total_number").Value

        End With

        rscount.Close()
        rscount = Nothing


        With rs3
            If SERT$ > 0 Then
                .MoveFirst()
                Do While Not .EOF

                    nom = .Fields("Id_comp").Value

                    Select Case cmbGar.Text

                        'd$ = "0"
                        'm$ = "0"
                        'g$ = "0"


                        Case langIni.GetString("frmReports", "MSG4", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("SVGA_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With

                            rs.Close()
                            rs = Nothing

                            d$ = .Fields("SVGA_DPo").Value
                            m$ = .Fields("SVGA_MPo").Value
                            g$ = .Fields("SVGA_GPo").Value

                        Case langIni.GetString("frmReports", "MSG5", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("HDD_Name_1").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing
                            d$ = .Fields("HDD_DPo").Value
                            m$ = .Fields("HDD_MPo").Value
                            g$ = .Fields("HDD_GPo").Value

                        Case langIni.GetString("frmReports", "MSG6", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("SOUND_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing
                            d$ = .Fields("SOUND_DPo").Value
                            m$ = .Fields("SOUND_MPo").Value
                            g$ = .Fields("SOUND_GPo").Value


                        Case langIni.GetString("frmReports", "MSG7", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("Mb").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing
                            d$ = .Fields("MB_DPo").Value
                            m$ = .Fields("MB_MPo").Value
                            g$ = .Fields("MB_GPo").Value

                        Case langIni.GetString("frmReports", "MSG8", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("MODEM_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing
                            d$ = .Fields("MODEM_DPo").Value
                            m$ = .Fields("MODEM_MPo").Value
                            g$ = .Fields("MODEM_GPo").Value

                        Case langIni.GetString("frmReports", "MSG9", "")

                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("MONITOR_NAME").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing
                            d$ = .Fields("MONITOR_DPo").Value
                            m$ = .Fields("MONITOR_MPo").Value
                            g$ = .Fields("MONITOR_GPo").Value


                        Case langIni.GetString("frmReports", "MSG10", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("RAM_1").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing
                            d$ = .Fields("RAM_DPo").Value
                            m$ = .Fields("RAM_MPo").Value
                            g$ = .Fields("RAM_GPo").Value

                        Case langIni.GetString("frmReports", "MSG13", "")
                            sSQL = "SELECT * FROM kompy where id=" & nom
                            rs = New ADODB.Recordset
                            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                .MoveFirst()
                                Do While Not .EOF
                                    If .Fields("id").Value = nom Then
                                        NameKomp = .Fields("CPU1").Value
                                    End If
                                    .MoveNext()
                                    'DoEvents
                                Loop
                            End With
                            rs.Close()
                            rs = Nothing
                            d$ = .Fields("CPU_DPo").Value
                            m$ = .Fields("CPU_MPo").Value
                            g$ = .Fields("CPU_GPo").Value


                    End Select

                    sSQL = "SELECT * FROM kompy where id=" & nom
                    rs = New ADODB.Recordset
                    rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    With rs
                        .MoveFirst()
                        Do While Not .EOF
                            If .Fields("id").Value = nom Then
                                Nam = langIni.GetString("frmReports", "MSG26", "") & ": " & .Fields("NET_NAME").Value & " " & langIni.GetString("frmReports", "MSG27", "") & " : " & .Fields("MESTO").Value & "/" & .Fields("FILIAL").Value
                            End If
                            .MoveNext()
                            'DoEvents
                        Loop
                    End With
                    rs.Close()
                    rs = Nothing

                    dat$ = d & "." & m & "." & g
                    If dat$ = "0.0.0" Or dat$ = ".." Then
                        dat$ = Date.Today '- 1
                    End If

                    'Dim Today As Date
                    'Dim Millenium As Date

                    'im retval
                    Today = Date.Today
                    Millenium = dat$
                    retval = DateDiff("d", Today, Millenium)
                    ZakZ = CStr(retval)

                    'If Len(dat) = 0 Then
                    'ZakZ = ""
                    'Else
                    'dp = dat
                    'ZakZ = dp - date
                    'End If

                    If ZakZ < 0 Then
                        ZakZ = "X"
                    End If


                    'If dat$ = date.today Then
                    'dat$ = "Не заполнено"
                    'Else
                    'End If



                    If Len(NameKomp) = 0 Or NameKomp = langIni.GetString("frmReports", "MSG28", "") Or NameKomp = langIni.GetString("frmReports", "MSG29", "") Then
                    Else

                        lvGar.Items.Add(NameKomp)
                        lvGar.Items(CInt(intj)).SubItems.Add(Nam)
                        lvGar.Items(CInt(intj)).SubItems.Add(dat$)
                        lvGar.Items(CInt(intj)).SubItems.Add(ZakZ)
                        lvGar.Items(CInt(intj)).SubItems.Add("-")

                        intj = intj + 1
                    End If


                    .MoveNext()
                    'DoEvents

                Loop

            End If
        End With

        'ListViewRavn(master_otch.lvGar, master_otch)


        'rs.Close()
        rs2.Close()
        rs3.Close()
        ' rs = Nothing
        rs2 = Nothing
        rs3 = Nothing
        'Screen.MousePointer = vbDefault

        ResList(Me.lvGar)

        Exit Sub

Error_:
        ResList(Me.lvGar)
    End Sub


    Private Sub btnSendToOffice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendToOffice.Click
        On Error GoTo Err_

        If LvKompOtd.Items.Count = 0 Then Exit Sub

        Select Case sOfficePACK

            Case "OpenOffice.org"

                ExportListViewToCalc(LvKompOtd, sSTAB1.TabPages(0).Text)

            Case Else

                ExportListViewToExcel(LvKompOtd, sSTAB1.TabPages(0).Text)

        End Select

        Exit Sub
Err_:
        MsgBox("Error " & Err.Number & " " & Err.Description)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error GoTo Err_

        If lvReport2Cl.Items.Count = 0 Then Exit Sub


        Select Case sOfficePACK

            Case "OpenOffice.org"

                ExportListViewToCalc(lvReport2Cl, sSTAB1.TabPages(1).Text)

            Case Else

                ExportListViewToExcel(lvReport2Cl, sSTAB1.TabPages(1).Text)

        End Select



        Exit Sub
Err_:
        MsgBox("Error " & Err.Number & " " & Err.Description)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        On Error GoTo Err_

        If lvRemont.Items.Count = 0 Then Exit Sub




        Select Case sOfficePACK

            Case "OpenOffice.org"

                ExportListViewToCalc(lvRemont, sSTAB1.TabPages(2).Text)

            Case Else

                ExportListViewToExcel(lvRemont, sSTAB1.TabPages(2).Text)

        End Select


        Exit Sub
Err_:
        MsgBox("Error " & Err.Number & " " & Err.Description)
    End Sub

    Private Sub cmbOTV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOTV.SelectedIndexChanged
        On Error GoTo err_

        Me.Cursor = Cursors.WaitCursor

        Dim rs As ADODB.Recordset 'Объявляем рекордсет

        Dim Count As String
        lvOTV.Items.Clear()

        rs = New ADODB.Recordset
        rs.Open("Select COUNT(*) as tot_num FROM kompy where OTvetstvennyj='" & cmbOTV.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            Count = .Fields("tot_num").Value
        End With

        rs.Close()
        rs = Nothing

        If Count = 0 Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        rs = New ADODB.Recordset
        rs.Open("Select * FROM kompy where OTvetstvennyj='" & cmbOTV.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim intj As Integer
        Dim langIni As New IniFile(sLANGPATH)
        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case .Fields("tiptehn").Value

                    Case "PC"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG26", "") & " - " & .Fields("NET_NAME").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_SYSTEM").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("Ser_N_SIS").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "Printer"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG30", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If


                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "MFU"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG30", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "OT"
                        Dim unameZ As String

                        If Not IsDBNull(.Fields("TIP_COMPA").Value) Then unameZ = .Fields("TIP_COMPA").Value

                        If Len(unameZ) = 0 Then

                            unameZ = langIni.GetString("frmReports", "MSG25", "") & " - (" & .Fields("TIP_COMPA").Value & ") " & .Fields("NET_NAME").Value
                        Else

                            unameZ = .Fields("TIP_COMPA").Value & " - " & .Fields("NET_NAME").Value
                        End If


                        lvOTV.Items.Add(unameZ)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1


                    Case "KOpir"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG31", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "NET"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG32", "") & " - " & .Fields("NET_NAME").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_PROIZV_3").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("port_1").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "PHOTO"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG24", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "PHONE"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG22", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "FAX"

                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG23", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "SCANER"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG33", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "ZIP"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG34", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1


                    Case "MONITOR"
                        lvOTV.Items.Add(langIni.GetString("frmReports", "MSG9", "") & " - " & .Fields("NET_NAME").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_MONITOR").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("MONITOR_SN").Value)
                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1


                    Case "USB"
                        Dim unameZ As String

                        If Not IsDBNull(.Fields("TIP_COMPA").Value) Then unameZ = .Fields("TIP_COMPA").Value

                        If Len(unameZ) = 0 Then

                            unameZ = langIni.GetString("frmReports", "MSG3", "") & " - (" & .Fields("TIP_COMPA").Value & ") " & .Fields("NET_NAME").Value
                        Else

                            unameZ = .Fields("TIP_COMPA").Value & " - " & .Fields("NET_NAME").Value
                        End If


                        lvOTV.Items.Add(unameZ)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1



                    Case "SOUND"
                        Dim unameZ As String

                        If Not IsDBNull(.Fields("TIP_COMPA").Value) Then unameZ = .Fields("TIP_COMPA").Value

                        If Len(unameZ) = 0 Then

                            unameZ = langIni.GetString("frmReports", "MSG35", "") & " - (" & .Fields("TIP_COMPA").Value & ") " & .Fields("NET_NAME").Value
                        Else

                            unameZ = .Fields("TIP_COMPA").Value & " - " & .Fields("NET_NAME").Value
                        End If


                        lvOTV.Items.Add(unameZ)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1


                    Case "IBP"
                        Dim unameZ As String

                        If Not IsDBNull(.Fields("TIP_COMPA").Value) Then unameZ = .Fields("TIP_COMPA").Value

                        If Len(unameZ) = 0 Then

                            unameZ = langIni.GetString("frmReports", "MSG36", "") & " - (" & .Fields("TIP_COMPA").Value & ") " & .Fields("NET_NAME").Value
                        Else

                            unameZ = .Fields("TIP_COMPA").Value & " - " & .Fields("NET_NAME").Value
                        End If


                        lvOTV.Items.Add(unameZ)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                    Case "FS"
                        Dim unameZ As String

                        If Not IsDBNull(.Fields("TIP_COMPA").Value) Then unameZ = .Fields("TIP_COMPA").Value

                        If Len(unameZ) = 0 Then

                            unameZ = langIni.GetString("frmReports", "MSG37", "") & " - (" & .Fields("TIP_COMPA").Value & ") " & .Fields("NET_NAME").Value
                        Else

                            unameZ = .Fields("TIP_COMPA").Value & " - " & .Fields("NET_NAME").Value
                        End If


                        lvOTV.Items.Add(unameZ)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("PRINTER_SN_1").Value) Then
                            lvOTV.Items(intj).SubItems.Add(.Fields("PRINTER_SN_1").Value)
                        Else
                            lvOTV.Items(intj).SubItems.Add("")

                        End If

                        lvOTV.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                End Select

                .MoveNext()
                'DoEvents
            Loop
        End With



        rs.Close()
        rs = Nothing

        ResList(Me.lvOTV)

        Me.Cursor = Cursors.Default

        Exit Sub
err_:
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub cmbBrancheCashe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrancheCashe.SelectedIndexChanged
        On Error GoTo err
        cmbDepartmentCashe.Items.Clear()
        Dim langIni As New IniFile(sLANGPATH)

        If cmbBrancheCashe.Text = langIni.GetString("frmReports", "MSG1", "") Then
            cmbDepartmentCashe.Items.Add(langIni.GetString("frmReports", "MSG1", ""))
            Exit Sub

        End If

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT * FROM SPR_OTD_FILIAL WHERE filial ='" & cmbBrancheCashe.Text & "' order by N_Otd", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        With rs
            .MoveFirst()
            Do While Not .EOF

                cmbDepartmentCashe.Items.Add(.Fields("N_Otd").Value)

                .MoveNext()
            Loop
        End With

        cmbDepartmentCashe.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

        rs.Close()
        rs = Nothing

err:
    End Sub

    Private Sub btnCashe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashe.Click
        Me.Cursor = Cursors.WaitCursor

        lvCashe.Items.Clear()
        Dim langIni As New IniFile(sLANGPATH)


        If Len(cmbYearCashe.Text) = 0 Then Exit Sub
        If Len(cmbBrancheCashe.Text) = 0 Then Exit Sub
        If Len(cmbDepartmentCashe.Text) = 0 Then Exit Sub

        On Error Resume Next


        Dim rs As ADODB.Recordset
        Dim sSQL As String

        rs = New ADODB.Recordset

        If cmbBrancheCashe.Text = langIni.GetString("frmReports", "MSG1", "") And cmbDepartmentCashe.Text = langIni.GetString("frmReports", "MSG1", "") Then

            sSQL = "SELECT * FROM kompy where DataVVoda like '%" & cmbYearCashe.Text & "%'"

        End If

        If cmbBrancheCashe.Text <> langIni.GetString("frmReports", "MSG1", "") And cmbDepartmentCashe.Text = langIni.GetString("frmReports", "MSG1", "") Then

            sSQL = "SELECT * FROM kompy where filial ='" & cmbBrancheCashe.Text & "' AND DataVVoda like '%" & cmbYearCashe.Text & "%'"

        End If

        If cmbBrancheCashe.Text <> langIni.GetString("frmReports", "MSG1", "") And cmbDepartmentCashe.Text <> langIni.GetString("frmReports", "MSG1", "") Then

            sSQL = "SELECT * FROM kompy where filial ='" & cmbBrancheCashe.Text & "' AND mesto='" & cmbDepartmentCashe.Text & "' AND DataVVoda like '%" & cmbYearCashe.Text & "%'"

        End If

        Dim Uname() As String

        Dim Uname2 As Integer
        Uname2 = 0

        Dim intj As Integer
        intj = 0

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                Uname(2) = 0

                If Not IsDBNull(.Fields("DataVVoda").Value) Then Uname = Split(.Fields("DataVVoda").Value, ".")


                ' If Uname(2) = cmbYearCashe.Text Then

                Select Case .Fields("tiptehn").Value

                    Case "PC"

                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG26", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "Printer"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG30", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "MFU"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG21", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "OT"

                        If Len(.Fields("TIP_COMPA").Value) = 0 Then


                            lvCashe.Items.Add(langIni.GetString("frmReports", "MSG25", "") & " - (" & .Fields("TIP_COMPA").Value & ") " & .Fields("NET_NAME").Value)

                        Else

                            lvCashe.Items.Add(.Fields("TIP_COMPA").Value & " - " & .Fields("NET_NAME").Value)

                        End If


                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1

                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "KOpir"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG31", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "NET"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG32", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "PHOTO"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG24", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "PHONE"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG22", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "FAX"

                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG23", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "SCANER"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG33", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "ZIP"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG34", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value


                    Case "MONITOR"
                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG9", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value


                    Case "USB"

                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG3", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "SOUND"

                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG35", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "IBP"

                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG36", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value

                    Case "FS"

                        lvCashe.Items.Add(langIni.GetString("frmReports", "MSG37", "") & " - " & .Fields("NET_NAME").Value)

                        If Not IsDBNull(.Fields("CenaRub").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("CenaRub").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DataVVoda").Value) Then
                            lvCashe.Items(intj).SubItems.Add(.Fields("DataVVoda").Value)
                        Else
                            lvCashe.Items(intj).SubItems.Add("")
                        End If

                        lvCashe.Items(intj).SubItems.Add(.Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value)
                        intj = intj + 1
                        Uname2 = Uname2 + .Fields("CenaRub").Value


                End Select

                ' End If

                .MoveNext()
                'DoEvents
            Loop
        End With

        rs.Close()
        rs = Nothing



        If cmbBrancheCashe.Text = langIni.GetString("frmReports", "MSG1", "") And cmbDepartmentCashe.Text = langIni.GetString("frmReports", "MSG1", "") Then


            'Заправки
            Dim Coun1 As Long

            Dim rscount As ADODB.Recordset 'Объявляем рекордсет
            rscount = New ADODB.Recordset
            rscount.Open("SELECT COUNT(*) AS total_number FROM CARTRIDG_Z", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rscount
                Coun1 = .Fields("total_number").Value
            End With

            rscount.Close()
            rscount = Nothing


            If Coun1 > 0 Then
                rscount = New ADODB.Recordset
                rscount.Open("SELECT * FROM CARTRIDG_Z", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                Dim A2, B2, D2 As String

                Dim C2 As Integer

                With rscount
                    .MoveFirst()
                    Do While Not .EOF = True

                        Uname(2) = 0

                        If Not IsDBNull(.Fields("DATAZAP").Value) Then Uname = Split(.Fields("DATAZAP").Value, ".")

                        If Uname(2) = cmbYearCashe.Text Then


                            A2 = .Fields("ID_C").Value

                            rs = New ADODB.Recordset
                            rs.Open("SELECT model, ustr FROM CARTRIDG WHERE id =" & A2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                A2 = .Fields("model").Value
                                C2 = .Fields("ustr").Value

                            End With
                            rs.Close()
                            rs = Nothing

                            rs = New ADODB.Recordset
                            rs.Open("SELECT name FROM spr_cart WHERE id =" & A2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                            With rs
                                B2 = .Fields("name").Value
                            End With
                            rs.Close()
                            rs = Nothing


                            If C2 = 0 Or Len(C2) = 0 Then

                            Else
                                rs = New ADODB.Recordset
                                rs.Open("SELECT filial, mesto, kabn, NET_NAME FROM kompy WHERE id =" & C2, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                                With rs
                                    D2 = .Fields("FILIAL").Value & "/" & .Fields("mesto").Value & "/" & .Fields("kabn").Value
                                    B2 = B2 & " (" & .Fields("NET_NAME").Value & ")"
                                End With
                                rs.Close()
                                rs = Nothing

                            End If


                            lvCashe.Items.Add(langIni.GetString("frmReports", "MSG38", "") & " - " & B2)


                            If Not IsDBNull(.Fields("STOIM").Value) Then
                                lvCashe.Items(intj).SubItems.Add(.Fields("STOIM").Value)
                            Else
                                lvCashe.Items(intj).SubItems.Add("")
                            End If

                            If Not IsDBNull(.Fields("DATAZAP").Value) Then
                                lvCashe.Items(intj).SubItems.Add(.Fields("DATAZAP").Value)
                            Else
                                lvCashe.Items(intj).SubItems.Add("")
                            End If

                            lvCashe.Items(intj).SubItems.Add(D2)
                            intj = intj + 1

                            Uname2 = Uname2 + .Fields("STOIM").Value


                        End If


                        .MoveNext()
                    Loop
                End With

                rscount.Close()
                rscount = Nothing

            End If

            Coun1 = 0

            rscount = New ADODB.Recordset
            rscount.Open("SELECT COUNT(*) AS total_number FROM Sclad", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rscount
                Coun1 = .Fields("total_number").Value
            End With


            rscount.Close()
            rscount = Nothing


            If Coun1 > 0 Then
                rscount = New ADODB.Recordset
                rscount.Open("SELECT * FROM Sclad", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rscount
                    .MoveFirst()
                    Do While Not .EOF = True

                        Uname(2) = 0

                        If Not IsDBNull(.Fields("DaysAndTimes").Value) Then Uname = Split(.Fields("DaysAndTimes").Value, ".")

                        If Uname(2) = cmbYearCashe.Text Then


                            lvCashe.Items.Add(langIni.GetString("frmReports", "MSG39", "") & " - " & .Fields("ComplectName").Value & "(" & .Fields("Prim").Value & ")")


                            If Not IsDBNull(.Fields("Cena").Value) Then
                                lvCashe.Items(intj).SubItems.Add(.Fields("Cena").Value)
                            Else
                                lvCashe.Items(intj).SubItems.Add("")
                            End If

                            If Not IsDBNull(.Fields("DaysAndTimes").Value) Then
                                lvCashe.Items(intj).SubItems.Add(.Fields("DaysAndTimes").Value)
                            Else
                                lvCashe.Items(intj).SubItems.Add("")
                            End If

                            lvCashe.Items(intj).SubItems.Add("Склад (" & .Fields("Otdel").Value & ")")
                            intj = intj + 1

                            Uname2 = Uname2 + .Fields("Cena").Value


                        End If


                        .MoveNext()
                    Loop
                End With

                rscount.Close()
                rscount = Nothing

            End If


            'Затраты на ремонт
            Coun1 = 0

            rscount = New ADODB.Recordset
            rscount.Open("SELECT COUNT(*) AS total_number FROM Remont", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rscount
                Coun1 = .Fields("total_number").Value
            End With


            rscount.Close()
            rscount = Nothing


            If Coun1 > 0 Then
                rscount = New ADODB.Recordset
                rscount.Open("SELECT * FROM Remont", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rscount
                    .MoveFirst()
                    Do While Not .EOF = True

                        Uname(2) = 0

                        If Not IsDBNull(.Fields("Date").Value) Then Uname = Split(.Fields("Date").Value, ".")

                        If Uname(2) = cmbYearCashe.Text Then

                            If .Fields("Summ").Value = 0 Or Len(.Fields("Summ").Value) = 0 Then


                            Else


                                lvCashe.Items.Add(langIni.GetString("frmReports", "MSG40", "") & " - " & .Fields("Comp_Name").Value)


                                If Not IsDBNull(.Fields("Summ").Value) Then
                                    lvCashe.Items(intj).SubItems.Add(.Fields("Summ").Value)
                                Else
                                    lvCashe.Items(intj).SubItems.Add("")
                                End If

                                If Not IsDBNull(.Fields("Date").Value) Then
                                    lvCashe.Items(intj).SubItems.Add(.Fields("Date").Value)
                                Else
                                    lvCashe.Items(intj).SubItems.Add("")
                                End If

                                lvCashe.Items(intj).SubItems.Add(.Fields("Mesto_Compa").Value)
                                intj = intj + 1

                            End If

                            Uname2 = Uname2 + .Fields("Summ").Value


                        End If


                        .MoveNext()
                    Loop
                End With

                rscount.Close()
                rscount = Nothing

            End If


        End If

        If Uname2 > 0 Then
            lvCashe.Items.Add(langIni.GetString("frmReports", "MSG41", ""))
            lvCashe.Items(intj).SubItems.Add(Uname2)
            lvCashe.Items(intj).SubItems.Add(Date.Today)
            lvCashe.Items(intj).SubItems.Add("")
        End If

        ResList(Me.lvCashe)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnCacheOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCacheOff.Click
        On Error GoTo Err_

        If lvCashe.Items.Count = 0 Then Exit Sub


         Select sOfficePACK

            Case "OpenOffice.org"

                ExportListViewToCalc(lvCashe, sSTAB1.TabPages(5).Text)


            Case Else

                ExportListViewToExcel(lvCashe, sSTAB1.TabPages(5).Text)


        End Select




        Exit Sub
Err_:
        MsgBox("Error " & Err.Number & " " & Err.Description)
    End Sub

    Private Sub btnCRZakSendOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCRZakSendOff.Click


        Me.Cursor = Cursors.WaitCursor

        Call blanks_my_o_ZKP()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub lvRemont_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRemont.SelectedIndexChanged

    End Sub

    Private Sub lvRemont_ItemMouseHover(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemMouseHoverEventArgs) Handles lvRemont.ItemMouseHover
        Dim stext As String
        stext = e.Item.SubItems(1).Text & vbCrLf & e.Item.SubItems(2).Text & vbCrLf & vbCrLf & e.Item.SubItems(3).Text & vbCrLf & vbCrLf & e.Item.SubItems(5).Text

        ToolTip1.ToolTipTitle = ProGramName

        If e.Item.SubItems(3).Text Is Nothing Then


        Else

            ToolTip1.SetToolTip(lvRemont, WordWrap(stext))

        End If
    End Sub

    Friend Function WordWrap(ByVal MessageText As String) As String
        Dim Words() As String = Split(MessageText, " ")

        Dim LineLen As Integer
        WordWrap = ""

        For i As Integer = 0 To Words.Length - 1
            WordWrap &= Words(i) & " "
            LineLen += (Words(i).Length + 1)

            ' Add a wrap if adding next word overflows
            If i < Words.Length - 1 Then

                If LineLen + Words(i + 1).Length >= 40 Then
                    WordWrap &= vbCrLf
                    LineLen = 0
                End If
            End If
        Next
        Return WordWrap

    End Function

    Private Sub lvRemont_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRemont.MouseMove
        If lvRemont.GetItemAt(e.X, e.Y) Is Nothing Then
            ToolTip1.RemoveAll()
        End If
    End Sub

    Private Sub lvReport2Cl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvReport2Cl.SelectedIndexChanged

    End Sub

    Private Sub TableLayoutPanel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub chk_K47_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K47.CheckedChanged
        Select Case chk_K47.Checked

            Case True
                chkTeh(47) = True
            Case Else
                chkTeh(47) = False
        End Select
    End Sub


    Private Sub cmbOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOffice.SelectedIndexChanged

        'Call Refresh_otdellist()

    End Sub

    Private Sub chk_K48_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K48.CheckedChanged
        Select Case chk_K48.Checked

            Case True
                chkTeh(48) = True
            Case Else
                chkTeh(48) = False
        End Select
    End Sub

    Private Sub chk_K49_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K49.CheckedChanged
        Select Case chk_K49.Checked

            Case True
                chkTeh(49) = True
            Case Else
                chkTeh(49) = False
        End Select
    End Sub

    Private Sub chk_K50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K50.CheckedChanged
        Select Case chk_K50.Checked

            Case True
                chkTeh(50) = True
            Case Else
                chkTeh(50) = False
        End Select
    End Sub

    Private Sub chk_K51_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K51.CheckedChanged
        Select Case chk_K51.Checked

            Case True
                chkTeh(51) = True
            Case Else
                chkTeh(51) = False
        End Select
    End Sub

    Private Sub chk_K52_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K52.CheckedChanged
        Select Case chk_K52.Checked

            Case True
                chkTeh(52) = True
            Case Else
                chkTeh(52) = False
        End Select
    End Sub

    '    Private Sub cmbBrancheC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrancheC.SelectedIndexChanged
    '        On Error GoTo err_
    '        Dim langIni As New IniFile(sLANGPATH)

    '        cmbDepartmentC.Items.Clear()

    '        If cmbBrancheC.Text = langIni.GetString("frmReports", "MSG1", "") Then

    '            cmbDepartmentC.Items.Add(langIni.GetString("frmReports", "MSG1", ""))
    '            cmbDepartmentC.Text = langIni.GetString("frmReports", "MSG1", "")

    '            cmbOfficeC.Text = langIni.GetString("frmReports", "MSG1", "")

    '            Exit Sub
    '        End If

    '        If Len(cmbDepartmentC.Text) = 0 Then cmbDepartmentC.Text = langIni.GetString("frmReports", "MSG1", "")

    '        Dim rs1 As ADODB.Recordset
    '        rs1 = New ADODB.Recordset
    '        rs1.Open("select count(*) as t_n from SPR_OTD_FILIAL WHERE Filial='" & cmbBrancheC.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '        Dim sCNN As Integer

    '        With rs1
    '            sCNN = .Fields("t_n").Value
    '        End With

    '        rs1.Close()
    '        rs1 = Nothing


    '        If sCNN > 0 Then

    '            rs1 = New ADODB.Recordset

    '            rs1.Open("select * from SPR_OTD_FILIAL WHERE Filial='" & cmbBrancheC.Text & "' ORDER BY N_Otd", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


    '            cmbDepartmentC.Items.Clear()

    '            With rs1
    '                .MoveFirst()
    '                Do While Not .EOF

    '                    If Not IsDBNull(.Fields("N_Otd").Value) Then cmbDepartmentC.Items.Add(.Fields("N_Otd").Value)

    '                    .MoveNext()
    '                Loop
    '            End With

    '            cmbDepartmentC.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

    '            rs1.Close()
    '            rs1 = Nothing

    '        Else
    '            cmbDepartmentC.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

    '        End If

    '        Exit Sub
    'err_:
    '        ' MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    '    End Sub

    '    Private Sub cmbOfficeC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOfficeC.SelectedIndexChanged

    '        'lvCRT
    '        Dim sSQL As String
    '        sSQL = "SELECT CARTRIDG.Id, CARTRIDG.SN, CARTRIDG.TIP, spr_cart.Name, (SELECT count(*) FROM CARTRIDG_Z WHERE CARTRIDG_Z.id_c= CARTRIDG.id) AS zap, (SELECT Proizv FROM SPR_PROIZV WHERE SPR_PROIZV.id= CARTRIDG.Proizv) AS Proizv, (SELECT filial+'/'+mesto+'/'+kabn FROM kompy WHERE kompy.id= CARTRIDG.ustr) AS MESTO, (SELECT sum(STOIM) FROM CARTRIDG_Z WHERE CARTRIDG_Z.id_c= CARTRIDG.id) AS Summa FROM CARTRIDG INNER JOIN spr_cart ON CARTRIDG.Model = spr_cart.Id"


    '        Dim rs As ADODB.Recordset 'Объявляем рекордсет

    '        Dim Count As String
    '        lvCRT.Items.Clear()


    '        rs = New ADODB.Recordset
    '        rs.Open("Select COUNT(*) as tot_num FROM CARTRIDG", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

    '        With rs
    '            Count = .Fields("tot_num").Value
    '        End With

    '        rs.Close()
    '        rs = Nothing

    '        If Count = 0 Then
    '            Me.Cursor = Cursors.Default
    '            Exit Sub
    '        End If


    '        rs = New ADODB.Recordset
    '        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '        Dim intj As Integer
    '        ' Dim langIni As New IniFile(sLANGPATH)

    '        With rs
    '            .MoveFirst()
    '            Do While Not .EOF


    '                lvCRT.Items.Add(.Fields("name").Value)
    '                lvCRT.Items(intj).SubItems.Add(.Fields("mesto").Value)
    '                lvCRT.Items(intj).SubItems.Add(.Fields("zap").Value)
    '                lvCRT.Items(intj).SubItems.Add("")
    '                lvCRT.Items(intj).SubItems.Add(.Fields("Summa").Value)
    '                intj = intj + 1

    '                .MoveNext()
    '                'DoEvents
    '            Loop
    '        End With



    '        rs.Close()
    '        rs = Nothing

    '        ResList(Me.lvOTV)


    '    End Sub

    '    Private Sub cmbDepartmentC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartmentC.SelectedIndexChanged
    '    Dim langIni As New IniFile(sLANGPATH)

    '        On Error GoTo err_

    '        cmbOfficeC.Items.Clear()

    '        If cmbDepartmentC.Text = langIni.GetString("frmReports", "MSG1", "") Then

    '            cmbOfficeC.Items.Add(langIni.GetString("frmReports", "MSG1", ""))
    '            cmbOfficeC.Text = langIni.GetString("frmReports", "MSG1", "")


    '            Exit Sub
    '        End If

    '        If Len(cmbOfficeC.Text) = 0 Then cmbOfficeC.Text = langIni.GetString("frmReports", "MSG1", "")

    '    Dim rs1 As ADODB.Recordset

    '        rs1 = New ADODB.Recordset
    '        rs1.Open("select count(*) as t_n from SPR_KAB WHERE N_F='" & cmbBrancheC.Text & "' AND N_M='" & cmbDepartmentC.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '    Dim sCNN As Integer

    '        With rs1
    '            sCNN = .Fields("t_n").Value
    '        End With

    '        rs1.Close()
    '        rs1 = Nothing


    '        If sCNN > 0 Then
    '            rs1 = New ADODB.Recordset
    '            rs1.Open("select * from SPR_KAB WHERE N_F='" & cmbBrancheC.Text & "' AND N_M='" & cmbDepartmentC.Text & "' ORDER BY Name", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


    '            With rs1
    '                .MoveFirst()
    '                Do While Not .EOF

    '                    If Not IsDBNull(.Fields("Name").Value) Then cmbOfficeC.Items.Add(.Fields("Name").Value)

    '                    .MoveNext()
    '                Loop
    '            End With

    '            cmbOfficeC.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

    '            rs1.Close()
    '            rs1 = Nothing
    '        Else

    '            cmbOfficeC.Items.Add(langIni.GetString("frmReports", "MSG1", ""))

    '        End If



    '        Exit Sub
    'err_:
    '    'MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    '    End Sub

    Private Sub lvRemont_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRemont.DoubleClick

        LoadRepairEdit(lvRemont)

    End Sub

    Private Sub LoadRepairEdit(ByVal lvList As ListView)

        If lvList.Items.Count = 0 Then Exit Sub

        If uLevelRepEd = False And uLevel <> "Admin" Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvList.SelectedItems.Count - 1
            rCOUNT = (lvList.SelectedItems(z).Text)
        Next


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

        frmService_add.Text = LNGIniFile.GetString("frmserviceDesc", "MSG1", "") '& " " & lvList.SelectedItems(z).SubItems(5).Text

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


    Private Sub chk_K46_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_K46.CheckedChanged

        Select Case chk_K46.Checked

            Case True

                For Each C In TableLayoutPanel7.Controls
                    If TypeOf C Is CheckBox Then C.Checked = True
                Next C

                For Each C In TableLayoutPanel8.Controls
                    If TypeOf C Is CheckBox Then C.Checked = True
                Next C

                For Each C In TableLayoutPanel9.Controls
                    If TypeOf C Is CheckBox Then C.Checked = True
                Next C

            Case False

                For Each C In TableLayoutPanel7.Controls
                    If TypeOf C Is CheckBox Then C.Checked = False
                Next C

                For Each C In TableLayoutPanel8.Controls
                    If TypeOf C Is CheckBox Then C.Checked = False
                Next C

                For Each C In TableLayoutPanel9.Controls
                    If TypeOf C Is CheckBox Then C.Checked = False
                Next C
                'gbInf

        End Select



    End Sub


End Class