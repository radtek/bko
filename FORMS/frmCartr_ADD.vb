Public Class frmCartr_ADD
    Public EDTRCART As Boolean
    Public EDTIDTr As Decimal
    Public CRTFU As Boolean

    Private Sub frmCartr_ADD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        FillComboNET(Me.cmbProizv, "PROIZV", "SPR_PROIZV", "", False, True)
        FillComboNET(Me.cmbSaler, "Name", "SPR_Postav", "", False, True)
        FillComboNET(Me.cmbModC, "name", "spr_cart", "", False, True)

        Call LANG_frmCartr_ADD()

        Dim objIniFile As New IniFile(sLANGPATH)

        cmbTipC.Items.Clear()
        cmbTipC.Items.Add(objIniFile.GetString("frmCartr_ADD", "MSG1", ""))
        cmbTipC.Items.Add(objIniFile.GetString("frmCartr_ADD", "MSG2", ""))
        cmbTipC.Items.Add(objIniFile.GetString("frmCartr_ADD", "MSG3", ""))
        cmbTipC.Items.Add(objIniFile.GetString("frmCartr_ADD", "MSG4", ""))
        cmbTipC.Items.Add(objIniFile.GetString("frmCartr_ADD", "MSG5", ""))
        cmbTipC.Items.Add(objIniFile.GetString("frmCartr_ADD", "MSG6", ""))

        'dtSale.Value = Date.Today


        If EDTRCART = True Then

            Label6.Enabled = True
            cmbSostUstr.Enabled = True

        Else

            Label6.Enabled = False
            cmbSostUstr.Enabled = False

        End If



        Dim sSQL As String
        Dim Counter As Decimal
        Dim rs As ADODB.Recordset
        sSQL = "SELECT COUNT(*) AS total_number FROM kompy"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            Counter = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing


        If Counter > 0 Then
            cmbSostUstr.Items.Clear()
            rs = New ADODB.Recordset
            rs.Open("SELECT * FROM kompy", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs
                .MoveFirst()
                Do While Not .EOF
                    If .Fields("TipTehn").Value = "Printer" Or .Fields("TipTehn").Value = "KOpir" Or .Fields("TipTehn").Value = "MFU" Then
                        cmbSostUstr.Items.Add(.Fields("PRINTER_NAME_1").Value & " (" & .Fields("filial").Value & "/" & .Fields("mesto").Value & ")" & " № " & .Fields("id").Value)
                    Else
                    End If
                    .MoveNext()
                    'DoEvents
                Loop
            End With
            rs.Close()
            rs = Nothing

        End If



        'If Not IsDBNull(.Fields("os")) Then frmComputers.cmbModCartr.Text = .Fields("os").Value
        If EDTRCART = False Then

            rs = New ADODB.Recordset
            rs.Open("SELECT os FROM kompy where id=" & frmCRT3.cCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs

                cmbModC.Text = .Fields("os").Value

            End With
            rs.Close()
            rs = Nothing

        End If




        Exit Sub


    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim uname As String
        Dim uname2 As String
        Dim uname3 As String
        Dim uname4 As String

        uname = cmbProizv.Text

        If Not (RSExists("PROYZV", "PROiZV", cmbProizv.Text)) Then
            AddPr(cmbProizv.Text)
        End If

        If Not (RSExists("Postav", "name", cmbSaler.Text)) Then
            AddOnePar(cmbSaler.Text, "NAME", "SPR_Postav", cmbSaler)
        End If

        If Not (RSExists("CARTR", "name", cmbModC.Text)) Then

            AddTreePar(cmbModC.Text, cmbTipC.Text, cmbProizv.Text, "spr_cart", cmbModC)

        End If

        Dim PROYZV As ADODB.Recordset
        PROYZV = New ADODB.Recordset
        PROYZV.Open("SELECT * FROM SPR_PROIZV WHERE Proizv='" & uname & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With PROYZV
            uname = .Fields("Id").Value
        End With
        PROYZV.Close()
        PROYZV = Nothing

        uname2 = cmbModC.Text

        If Not (RSExists("CARTR", "name", cmbModC.Text)) Then
            'AddCARTR(Combo2.Text, Combo4.Text, Combo3.Text)
        End If

        Dim CARTR As ADODB.Recordset
        CARTR = New ADODB.Recordset
        CARTR.Open("SELECT * FROM spr_cart WHERE name='" & uname2 & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With CARTR
            uname2 = .Fields("id").Value
        End With
        CARTR.Close()
        CARTR = Nothing


        If EDTRCART = True Then

            uname3 = cmbSostUstr.Text

            Dim BASECOMP As ADODB.Recordset
            BASECOMP = New ADODB.Recordset
            BASECOMP.Open("SELECT * FROM kompy", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            With BASECOMP

                If Len(cmbSostUstr.Text) = 0 Then
                    uname3 = 0
                Else
                    .MoveFirst()
                    Do While Not .EOF
                        If uname3 = .Fields("PRINTER_NAME_1").Value & " (" & .Fields("filial").Value & "/" & .Fields("mesto").Value & ")" & " № " & .Fields("id").Value Then
                            uname3 = .Fields("id").Value
                        End If
                        .MoveNext()
                        'DoEvents
                    Loop

                End If
            End With
            BASECOMP.Close()
            BASECOMP = Nothing


        Else

            uname3 = frmCRT3.cCOUNT

        End If




        uname4 = cmbSaler.Text


        If Len(cmbSaler.Text) = 0 Then

            uname4 = 0

        Else

            If Not (RSExists("Postav", "name", cmbSaler.Text)) Then
                ' AddPost(cmbSaler.Text)
            End If

            Dim Postav As ADODB.Recordset
            Postav = New ADODB.Recordset
            Postav.Open("SELECT * FROM SPR_Postav WHERE Name='" & uname4 & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With Postav
                uname4 = .Fields("id").Value
            End With
            Postav.Close()
            Postav = Nothing

        End If




        Dim sSQL As String
        If EDTRCART = True Then
            sSQL = "SELECT * FROM CARTRIDG WHERE id = " & EDTIDTr
        Else

            sSQL = "SELECT * FROM CARTRIDG"

        End If

        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        If Len(txtSerNumb.Text) = 0 Then txtSerNumb.Text = "Б\Н"
        If Len(txtSaleNumb.Text) = 0 Then txtSaleNumb.Text = 0
        If Len(txtCashe.Text) = 0 Then txtCashe.Text = 0

        With rs1
            If EDTRCART = True Then
            Else
                .AddNew()
            End If

            .Fields("SN").Value = txtSerNumb.Text
            .Fields("Proizv").Value = uname
            .Fields("TIP").Value = cmbTipC.Text
            .Fields("Model").Value = uname2
            .Fields("USTR").Value = uname3
            .Fields("PROD").Value = uname4
            .Fields("SCHET").Value = txtSaleNumb.Text
            .Fields("Cena").Value = txtCashe.Text
            .Fields("DATA").Value = dtSale.Value
            .Fields("NZap").Value = chkNezap.Checked
            .Fields("NeZap").Value = chkNZ.Checked
            .Fields("Iznos").Value = chkIznos.Checked
            .Fields("Spisan").Value = chkSPS.Checked
            .Fields("NaSpisanie").Value = chkNaSP.Checked
            .Fields("PRIM").Value = txtMemo.Text
            .Fields("PREF").Value = 0

            .Update()
        End With

        rs1.Close()
        rs1 = Nothing




        If CRTFU = True Then

            Call LOAD_CRT(frmComputers.sCOUNT)

        Else

            'Call frmCRT3.Load_C(frmCRT3.cCOUNT)

        End If

        Dim objIniFile As New IniFile(sLANGPATH)
        Me.btnAdd.Text = objIniFile.GetString("frmCartr_ADD", "btnAdd", "")
        CRTFU = False
        Me.Close()

        Exit Sub
    End Sub

    Private Sub cmbSostUstr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSostUstr.SelectedIndexChanged

    End Sub

    Private Sub cmbModC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModC.SelectedIndexChanged

        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim sSQL As String
        Dim uNI As String
        rs = New ADODB.Recordset



        sSQL = "SELECT * FROM spr_cart WHERE Name = '" & cmbModC.Text & "'"

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If Not IsDBNull(.Fields("proizv").Value) Then uNI = .Fields("proizv").Value

            Dim PROYZV As ADODB.Recordset
            PROYZV = New ADODB.Recordset
            PROYZV.Open("SELECT * FROM SPR_PROIZV WHERE iD=" & uNI, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With PROYZV
                cmbProizv.Text = .Fields("proizv").Value
            End With
            PROYZV.Close()
            PROYZV = Nothing

            If Not IsDBNull(.Fields("A").Value) Then cmbTipC.Text = .Fields("A").Value

        End With

        rs.Close()
        rs = Nothing

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class