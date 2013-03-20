Module MOD_ADD_FUNCTION
    Public Function AddPr(ByVal sGroupName As String) As Long
        On Error GoTo ERR1
        If Len(sGroupName) = 0 Then Exit Function
        If sGroupName = "<N/A>" Then Exit Function


        If Len(sGroupName) = 0 Or sGroupName = " " Or Len(sGroupName) < 3 Then Exit Function

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM SPR_PROIZV", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            If Len(sGroupName) > 0 Or sGroupName <> "NoName" Or Len(sGroupName) > 1 Then
                .AddNew()
                .Fields("PROIZV").Value = sGroupName

                .Update()
            Else
            End If
        End With

        rs.Close()
        rs = Nothing

        AddPr = 1

        Exit Function
        ERR1:
        AddPr = - 1
    End Function

    Public Function AddOnePar(ByVal sGroupName As String, ByVal sColumns As String, ByVal sTABLE As String,
                              ByVal sCOMBO As ComboBox) As Long

        On Error GoTo ERR1
        If Len(sGroupName) = 0 Then Exit Function

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM " & sTABLE, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


        With rs

            .AddNew()
            .Fields(sColumns).Value = sGroupName

            If TipTehn = "CNT" Then
                .Fields("C").Value = 1
            End If

            .Update()

        End With

        rs.Close()
        rs = Nothing

        sCOMBO.Items.Add(sGroupName)

        AddOnePar = 1

        Exit Function
        ERR1:
        AddOnePar = - 1
        MsgBox(Err.Description)
    End Function

    Public Function AddTwoPar(ByVal sGroupName As String, ByVal sPR As String, ByVal sTABLE As String,
                              ByVal sCOMBO As ComboBox) As Long
        On Error GoTo ERR1

        Dim uname As Integer

        If Len(sGroupName) = 0 Then Exit Function

        If Len(sPR) < 3 Then sPR = "NoName"


        If Not RSExists("PROYZV", "PROiZV", sPR) Then
            AddPr(sPR)
        End If
        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM SPR_PROIZV WHERE Proizv ='" & sPR & "'", DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                If sPR = .Fields("Proizv").Value Then
                    uname = .Fields("id").Value

                Else

                End If
                .MoveNext()
                'DoEvents
            Loop
        End With
        rs.Close()
        rs = Nothing

        rs = New Recordset
        rs.Open("SELECT * FROM " & sTABLE, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            .AddNew()
            .Fields("Name").Value = sGroupName
            .Fields("proizv").Value = uname

            .Update()

        End With
        rs.Close()
        rs = Nothing

        sCOMBO.Items.Add(sGroupName)

        AddTwoPar = 1

        Exit Function
        ERR1:
        AddTwoPar = - 1
    End Function

    Public Function AddFOwPar(ByVal sGroupName As String, ByVal sMHZ As String, ByVal sSoc As String,
                              ByVal sPR As String, ByVal sTABLE As String, ByVal sCOMBO As ComboBox) As Long
        On Error GoTo ERR1

        If Len(sGroupName) = 0 Then Exit Function
        Dim uname As Integer


        If Len(sPR) < 3 Then sPR = "NoName"

        If Not (RSExists("PROYZV", "PROiZV", Trim(sPR))) Then
            AddPr(Trim(sPR))
        End If

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM SPR_PROIZV WHERE Proizv ='" & sPR & "'", DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                If sPR = .Fields("Proizv").Value Then
                    uname = .Fields("id").Value
                Else
                End If
                .MoveNext()
                'DoEvents
            Loop
        End With
        rs.Close()
        rs = Nothing

        rs = New Recordset
        rs.Open("SELECT * FROM " & sTABLE, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            .AddNew()
            .Fields("Name").Value = sGroupName
            .Fields("Proizv").Value = uname
            .Fields("A").Value = sMHZ
            .Fields("B").Value = sSoc
            .Update()

        End With
        rs.Close()
        rs = Nothing

        sCOMBO.Items.Add(sGroupName)
        'frmContacts.PROizV(0).AddItem(sPR)
        '
        'frmContacts.CPU(1).AddItem(sGroupName)
        'frmContacts.PROizV(1).AddItem(sPR)


        AddFOwPar = 1

        Exit Function
        ERR1:
        AddFOwPar = - 1
    End Function

    Public Function AddTreePar(ByVal sGroupName As String, ByVal sMHZ As String, ByVal sPR As String,
                               ByVal sTABLE As String, ByVal sCOMBO As ComboBox) As Long
        On Error GoTo ERR1
        If Len(sGroupName) = 0 Then Exit Function
        Dim uname As Integer

        If Len(sPR) < 3 Then sPR = "NoName"

        If Not RSExists("PROYZV", "PROiZV", sPR) Then
            AddPr(sPR)
        End If

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM SPR_PROIZV WHERE Proizv ='" & sPR & "'", DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF

                If sPR = .Fields("Proizv").Value Then
                    uname = .Fields("id").Value
                Else

                End If
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        rs = New Recordset
        rs.Open("SELECT * FROM " & sTABLE, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .AddNew()

            .Fields("Name").Value = sGroupName
            .Fields("a").Value = sMHZ
            .Fields("proizv").Value = uname
            .Update()

        End With
        rs.Close()
        rs = Nothing

        sCOMBO.Items.Add(sGroupName)


        AddTreePar = 1
        Exit Function
        ERR1:
        AddTreePar = - 1
    End Function

    Public Function AddDepartment(ByVal sBR As String, ByVal sDP As String) As Long

        On Error GoTo ERR1
        If Len(sBR) = 0 Then Exit Function
        If Len(sDP) = 0 Then Exit Function

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM SPR_OTD_FILIAL", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


        With rs

            .AddNew()
            .Fields("N_OTD").Value = sDP
            .Fields("FILIAL").Value = sBR

            .Update()

        End With

        rs.Close()
        rs = Nothing


        AddDepartment = 1

        Exit Function
        ERR1:
        AddDepartment = - 1
    End Function

    Public Function AddOffice(ByVal sBR As String, ByVal sDP As String, ByVal sOFF As String) As Long

        On Error GoTo ERR1
        If Len(sBR) = 0 Then Exit Function
        If Len(sDP) = 0 Then Exit Function
        If Len(sOFF) = 0 Then Exit Function

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM SPR_KAB", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


        With rs

            .AddNew()
            .Fields("N_M").Value = sDP
            .Fields("N_F").Value = sBR
            .Fields("Name").Value = sOFF
            .Update()

        End With

        rs.Close()
        rs = Nothing


        AddOffice = 1

        Exit Function
        ERR1:
        AddOffice = - 1
    End Function
End Module
