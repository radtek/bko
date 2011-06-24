Public Class frmNetMag_selectSVT
    Private m_SortingColumn As ColumnHeader

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmNetMag_selectSVT_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        lvNetMagazin.Sorting = False
        'lvNetMagazin.Items.Clear()

    End Sub 'New

    Private Sub frmNetMag_selectSVT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SendFonts(Me)

        Call frmNetMag_selectSVT_LANG()

        lvNetMagazin.Sorting = False

        Call LOAD_SVT()
    End Sub

    Private Sub LOAD_SVT()

        'On Error GoTo err_

        lvNetMagazin.Sorting = False
        lvNetMagazin.Items.Clear()

        'frmNetMagazin.sBDO_count
        Dim sSQL As String


        Select Case frmNetMagazin.sBDO_Pref

            Case "G"

                sSQL = "SELECT Filial as one_par FROM SPR_FILIAL where id=" & frmNetMagazin.sBDO_count

            Case "O"

                sSQL = "SELECT Filial as one_par, N_Otd as two_par FROM SPR_OTD_FILIAL WHERE id=" & frmNetMagazin.sBDO_count

            Case "K"

                sSQL = "SELECT Name as tree_par, N_F as one_par, N_M as two_par FROM SPR_KAB where id=" & frmNetMagazin.sBDO_count

            Case "ROOT"


        End Select

        Dim A1, A2, A3 As String
        Dim rs As ADODB.Recordset

        If frmNetMagazin.sBDO_Pref = "ROOT" Then



        Else


            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)



            With rs

                Select Case frmNetMagazin.sBDO_Pref


                    Case "G"
                        A1 = .Fields("one_par").Value
                        A2 = "" '.Fields("two_par").Value
                        A3 = "" '.Fields("tree_par").Value

                    Case "O"

                        A1 = .Fields("one_par").Value
                        A2 = .Fields("two_par").Value
                        A3 = "" '.Fields("tree_par").Value


                    Case "K"

                        A1 = .Fields("one_par").Value
                        A2 = .Fields("two_par").Value
                        A3 = .Fields("tree_par").Value

                End Select


            End With

            rs.Close()
            rs = Nothing

        End If

        Select Case frmNetMagazin.sBDO_SVT_Pref

            Case "PC"

                Select Case frmNetMagazin.sBDO_Pref


                    Case "G"

                        sSQL = "SELECT * FROM kompy where tiptehn <> 'PC' AND PCL=0 AND filial='" & A1 & "' ORDER BY filial, mesto, kabn, net_name"

                    Case "O"

                        sSQL = "SELECT * FROM kompy where tiptehn <> 'PC' AND PCL=0 AND filial='" & A1 & "' AND mesto='" & A2 & "' ORDER BY filial, mesto, kabn, net_name"

                    Case "K"

                        sSQL = "SELECT * FROM kompy where tiptehn <> 'PC' AND PCL=0 AND filial='" & A1 & "' AND mesto='" & A2 & "' AND kabn='" & A3 & "' ORDER BY filial, mesto, kabn, net_name"
                        ' and tiptehn='PC' or tiptehn='Printer' or tiptehn='MFU' or tiptehn='FAX' or tiptehn='PHONE' or tiptehn='NET' or tiptehn='IBP'

                    Case "ROOT"

                        sSQL = "SELECT * FROM kompy where tiptehn <> 'PC' AND PCL=0 ORDER BY filial, mesto, kabn, net_name"

                End Select

            Case "NET"

                sSQL = "SELECT * FROM kompy where tiptehn='NET' ORDER BY filial, mesto, kabn, net_name"



        End Select





        Dim intCount As Decimal = 0

        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim LNGIniFile As New IniFile(sLANGPATH)

        lvNetMagazin.Sorting = False

        With rs
            .MoveFirst()
            Do While Not .EOF

                lvNetMagazin.Items.Add(.Fields("id").Value) 'col no. 1

                'lvNetMagazin.Items(CInt(intCount)).SubItems.Add("Компьютер")

                Select Case .Fields("tiptehn").Value

                    Case "PC"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG11", ""))

                        If Not IsDBNull(.Fields("INV_NO_SYSTEM").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_SYSTEM").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If


                    Case "Printer"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG6", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "KOpir"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG13", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "MONITOR"
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG3", ""))

                        If Not IsDBNull(.Fields("INV_NO_MONITOR").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_MONITOR").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If


                    Case "SCANER"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG8", ""))

                        If Not IsDBNull(.Fields("INV_NO_SCANER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_SCANER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "NET"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG14", ""))

                        If Not IsDBNull(.Fields("PRINTER_PROIZV_3").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("PRINTER_PROIZV_3").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If


                    Case "PHOTO"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG15", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "OT"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("NET_NAME").Value & " " & .Fields("TIP_COMPA").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "CNT"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("NET_NAME").Value & " " & .Fields("TIP_COMPA").Value)

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "ZIP"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG18", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "PHONE"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG16", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "MFU"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG7", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If


                    Case "FAX"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG17", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "USB"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG10", ""))
                    Case "IBP"


                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG9", ""))

                        If Not IsDBNull(.Fields("INV_NO_IBP").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_IBP").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "FS"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG5", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "SOUND"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG4", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "KEYB"
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG1", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                    Case "MOUSE"

                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG2", ""))

                        If Not IsDBNull(.Fields("INV_NO_PRINTER").Value) Then
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_PRINTER").Value)
                        Else
                            lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                        End If

                End Select



                If Not IsDBNull(.Fields("NET_NAME").Value) Then
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("NET_NAME").Value)
                Else
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("OTvetstvennyj").Value) Then
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("OTvetstvennyj").Value)
                Else
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("FILIAL").Value) Then
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("FILIAL").Value)
                Else
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("MESTO").Value) Then
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("MESTO").Value)
                Else
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("kabn").Value) Then
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("kabn").Value)
                Else
                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                End If


                intCount = intCount + 1
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing



        If frmNetMagazin.sBDO_SVT_Pref = "PC" Then
            '######################################################
            Select Case frmNetMagazin.sBDO_SVT_Pref

                Case "PC"

                    Select Case frmNetMagazin.sBDO_Pref


                        Case "G"

                            sSQL = "SELECT * FROM kompy where tiptehn = 'PC' AND filial='" & A1 & "' ORDER BY filial, mesto, kabn, net_name"

                        Case "O"

                            sSQL = "SELECT * FROM kompy where tiptehn = 'PC' AND filial='" & A1 & "' AND mesto='" & A2 & "' ORDER BY filial, mesto, kabn, net_name"

                        Case "K"

                            sSQL = "SELECT * FROM kompy where tiptehn = 'PC' AND filial='" & A1 & "' AND mesto='" & A2 & "' AND kabn='" & A3 & "' ORDER BY filial, mesto, kabn, net_name"
                            ' and tiptehn='PC' or tiptehn='Printer' or tiptehn='MFU' or tiptehn='FAX' or tiptehn='PHONE' or tiptehn='NET' or tiptehn='IBP'

                        Case "ROOT"

                            sSQL = "SELECT * FROM kompy where tiptehn = 'PC' ORDER BY filial, mesto, kabn, net_name"

                    End Select


            End Select
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            lvNetMagazin.Sorting = False

            With rs
                .MoveFirst()
                Do While Not .EOF

                    lvNetMagazin.Items.Add(.Fields("id").Value) 'col no. 1


                    lvNetMagazin.Items(CInt(intCount)).SubItems.Add(LNGIniFile.GetString("frmNetMagazin", "MSG11", ""))

                    If Not IsDBNull(.Fields("INV_NO_SYSTEM").Value) Then
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("INV_NO_SYSTEM").Value)
                    Else
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("NET_NAME").Value) Then
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("NET_NAME").Value)
                    Else
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("OTvetstvennyj").Value) Then
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("OTvetstvennyj").Value)
                    Else
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("FILIAL").Value) Then
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("FILIAL").Value)
                    Else
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("MESTO").Value) Then
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("MESTO").Value)
                    Else
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("kabn").Value) Then
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add(.Fields("kabn").Value)
                    Else
                        lvNetMagazin.Items(CInt(intCount)).SubItems.Add("")
                    End If


                    intCount = intCount + 1
                    .MoveNext()
                Loop
            End With
            rs.Close()
            rs = Nothing


            '######################################################
        End If

        ResList(lvNetMagazin)


        Exit Sub
err_:
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub lvNetMagazin_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNetMagazin.DoubleClick

        Call Select_SVT()
        Me.Close()
    End Sub

    Private Sub Select_SVT()

        If lvNetMagazin.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        Dim sCNT As Integer


        For z = 0 To lvNetMagazin.SelectedItems.Count - 1
            sCNT = (lvNetMagazin.SelectedItems(z).Text)
        Next

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT * FROM kompy where id=" & sCNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sTXT As String
        Dim LNGIniFile As New IniFile(sLANGPATH)

        With rs

            Select Case .Fields("TipTehn").Value

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
                    frmNetMagazin.sBDO_SVT_count = sCNT

                Case Else

                    frmNetMag_Add.txtKom.Text = sTXT & ": " & .Fields("NET_NAME").Value & " , (" & LNGIniFile.GetString("frmNetMagazin", "MSG19", "") & " " & .Fields("OTvetstvennyj").Value & ")"
                    'frmNetMag_Add.txtKom.Text = LNGIniFile.GetString("frmNetMagazin", "MSG14", "") & ": " & .Fields("NET_NAME").Value & " , (" & LNGIniFile.GetString("frmNetMagazin", "MSG19", "") & " " & .Fields("OTvetstvennyj").Value & ")"
                    frmNetMagazin.sBDO_NET_count = sCNT

            End Select


        End With

        rs.Close()
        rs = Nothing





    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Select_SVT()
        Me.Close()
    End Sub


    Private Sub lvNetMagazin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvNetMagazin.SelectedIndexChanged

    End Sub
End Class