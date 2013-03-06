Module MOD_ALTER_DB

    Public Sub ALTER_DB17351()

        On Error GoTo err_

        If _DBALTER = False Then Exit Sub

        Dim rs As ADODB.Recordset
        Dim sSQL17351, sSQL1734, sSQLver As String

        sSQL17351 = "ALTER TABLE Remont ADD GARANT Date"

        sSQLver = "Update CONFIGURE SET access='1.7.3.5.1' WHERE access<>'1.7.3.5.1'"

        Select Case DB_N

            Case "MS SQL 2008"

                sSQL17351 = "ALTER TABLE " & DBtabl & ".dbo.Remont ADD GARANT datetime"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "MS SQL"

                sSQL17351 = "ALTER TABLE " & DBtabl & ".dbo.Remont ADD GARANT datetime"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "MS Access"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "MySQL"

                sSQL17351 = "ALTER TABLE Remont ADD COLUMN GARANT Date"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case "MySQL (MyODBC 5.1)"

                sSQL17351 = "ALTER TABLE Remont ADD COLUMN GARANT Date"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case "PostgreSQL"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case "SQLLite"


            Case "DSN"

                rs = New ADODB.Recordset
                rs.Open(sSQL17351, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

        End Select

        rs = New ADODB.Recordset
        rs.Open(sSQLver, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        _DBALTER = False


        Exit Sub
err_:
        ' MsgBox(Err.Description)
        rs = Nothing
        _DBALTER = True
    End Sub

    '    Public Sub ALTER_DB1735()
    '        On Error GoTo err_

    '        If _DBALTER = False Then Exit Sub

    '        Dim rs As ADODB.Recordset
    '        Dim sSQL, sSQLver As String

    '        sSQL = "ALTER TABLE kompy ADD SNMP_COMMUNITY TEXT, SNMP YESNO"


    '        Select Case DB_N

    '            Case "MS SQL 2008"

    '                sSQL = "ALTER TABLE " & DBtabl & ".dbo.kompy ADD SNMP_COMMUNITY TEXT, SNMP tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MS SQL"

    '                sSQL = "ALTER TABLE " & DBtabl & ".dbo.kompy ADD SNMP_COMMUNITY TEXT, SNMP tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MS Access"

    '                sSQL = "ALTER TABLE kompy ADD SNMP_COMMUNITY TEXT, SNMP LOGICAL"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MySQL"

    '                sSQL = "ALTER TABLE 'kompy' ADD COLUMN 'SNMP_COMMUNITY' TEXT, ADD COLUMN 'SNMP' tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "MySQL (MyODBC 5.1)"

    '                sSQL = "ALTER TABLE 'kompy' ADD COLUMN 'SNMP_COMMUNITY' TEXT, ADD COLUMN 'SNMP' tinyint(4) DEFAULT '0'"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "PostgreSQL"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '            Case "SQLLite"


    '            Case "DSN"

    '                rs = New ADODB.Recordset
    '                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '                rs = Nothing

    '        End Select

    '        Call ALTER_DB17351()


    '        Exit Sub
    'err_:
    '        MsgBox(Err.Description)
    '        rs = Nothing
    '        _DBALTER = True

    '    End Sub

End Module
