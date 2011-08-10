'Imports System.Drawing
'Imports System.Collections
'Imports System.ComponentModel
'Imports System.Xml
'Imports System.Xml.XPath

Module modLang


    Public Sub frmNetMag_selectSVT_LANG()

        frmNetMag_selectSVT.lvNetMagazin.Columns.Clear()

        Dim LNGIniFile As New IniFile(sLANGPATH)

        'lvNetMagazin
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin1", ""), 1, HorizontalAlignment.Left)
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin2", ""), 50, HorizontalAlignment.Left)
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin3", ""), 50, HorizontalAlignment.Left)
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin4", ""), 50, HorizontalAlignment.Left)
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin5", ""), 50, HorizontalAlignment.Left)
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin6", ""), 30, HorizontalAlignment.Left)
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin7", ""), 100, HorizontalAlignment.Left)
        frmNetMag_selectSVT.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMag_selectSVT", "lvNetMagazin8", ""), 100, HorizontalAlignment.Left)


        ResList(frmNetMag_selectSVT.lvNetMagazin)

        frmNetMag_selectSVT.Text = LNGIniFile.GetString("frmNetMag_selectSVT", "frmNetMag_selectSVT ", "")
        frmNetMag_selectSVT.Button1.Text = LNGIniFile.GetString("frmNetMag_selectSVT", "Button1", "")
        frmNetMag_selectSVT.Button2.Text = LNGIniFile.GetString("frmNetMag_selectSVT", "Button2", "")


    End Sub

    Public Sub frmNetMag_Add_LANG()

        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmNetMag_Add.Text = LNGIniFile.GetString("frmNetMag_Add", "frmNetMag_Add ", "")

        frmNetMag_Add.Label1.Text = LNGIniFile.GetString("frmNetMag_Add", "Label1 ", "")
        frmNetMag_Add.Label2.Text = LNGIniFile.GetString("frmNetMag_Add", "Label2 ", "")
        frmNetMag_Add.Label3.Text = LNGIniFile.GetString("frmNetMag_Add", "Label3 ", "")
        frmNetMag_Add.Label4.Text = LNGIniFile.GetString("frmNetMag_Add", "Label4 ", "")
        frmNetMag_Add.Label5.Text = LNGIniFile.GetString("frmNetMag_Add", "Label5 ", "")
        frmNetMag_Add.Label6.Text = LNGIniFile.GetString("frmNetMag_Add", "Label6 ", "")
        frmNetMag_Add.Label7.Text = LNGIniFile.GetString("frmNetMag_Add", "Label7 ", "")
        frmNetMag_Add.Label8.Text = LNGIniFile.GetString("frmNetMag_Add", "Label8 ", "")
        frmNetMag_Add.Label9.Text = LNGIniFile.GetString("frmNetMag_Add", "Label9 ", "")
        frmNetMag_Add.Label10.Text = LNGIniFile.GetString("frmNetMag_Add", "Label10 ", "")
        frmNetMag_Add.Label11.Text = LNGIniFile.GetString("frmNetMag_Add", "Label11 ", "")
        frmNetMag_Add.Label13.Text = LNGIniFile.GetString("frmNetMag_Add", "Label13 ", "")
        frmNetMag_Add.Label14.Text = LNGIniFile.GetString("frmNetMag_Add", "Label14 ", "")

        frmNetMag_Add.GroupBox1.Text = LNGIniFile.GetString("frmNetMag_Add", "GroupBox1", "")
        frmNetMag_Add.GroupBox2.Text = LNGIniFile.GetString("frmNetMag_Add", "GroupBox2 ", "")

        frmNetMag_Add.Button1.Text = LNGIniFile.GetString("frmNetMag_Add", "Button1 ", "")
        frmNetMag_Add.Button2.Text = LNGIniFile.GetString("frmNetMag_Add", "Button2 ", "")



    End Sub


    Public Sub frmMagazin_LANG()

        frmNetMagazin.lvNetMagazin.Columns.Clear()
        Dim LNGIniFile As New IniFile(sLANGPATH)


        'lvNetMagazin
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin1", ""), 1, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin2", ""), 50, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin3", ""), 50, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin4", ""), 50, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin5", ""), 50, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin6", ""), 30, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin7", ""), 100, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin8", ""), 100, HorizontalAlignment.Left)

        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin12", ""), 100, HorizontalAlignment.Left)

        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin9", ""), 100, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin10", ""), 100, HorizontalAlignment.Left)
        frmNetMagazin.lvNetMagazin.Columns.Add(LNGIniFile.GetString("frmNetMagazin", "lvNetMagazin11", ""), 100, HorizontalAlignment.Left)

        ResList(frmNetMagazin.lvNetMagazin)

        frmNetMagazin.gbTree.Text = LNGIniFile.GetString("frmNetMagazin", "gbTree", "")
        frmNetMagazin.tsbExcell.Text = LNGIniFile.GetString("frmNetMagazin", "tsbExcell", "")
        frmNetMagazin.Text = LNGIniFile.GetString("frmNetMagazin", "frmNetMagazin", "")


    End Sub


    Public Sub frmCartr3_Lang()
        Dim objIniFile As New IniFile(sLANGPATH)


        frmCRT3.lvCartZAP.Columns.Add(objIniFile.GetString("frmCRT3", "lvCartZAP1", ""), 20, HorizontalAlignment.Left)
        frmCRT3.lvCartZAP.Columns.Add(objIniFile.GetString("frmCRT3", "lvCartZAP2", ""), 50, HorizontalAlignment.Left)
        frmCRT3.lvCartZAP.Columns.Add(objIniFile.GetString("frmCRT3", "lvCartZAP3", ""), 70, HorizontalAlignment.Left)
        frmCRT3.lvCartZAP.Columns.Add(objIniFile.GetString("frmCRT3", "lvCartZAP4", ""), 100, HorizontalAlignment.Left)
        frmCRT3.lvCartZAP.Columns.Add(objIniFile.GetString("frmCRT3", "lvCartZAP5", ""), 60, HorizontalAlignment.Left)
        frmCRT3.lvCartZAP.Columns.Add(objIniFile.GetString("frmCRT3", "lvCartZAP6", ""), 100, HorizontalAlignment.Left)

        frmCRT3.lvCRTMove.Columns.Add(objIniFile.GetString("frmCRT3", "lvCRTMove1", ""), 20, HorizontalAlignment.Left)
        frmCRT3.lvCRTMove.Columns.Add(objIniFile.GetString("frmCRT3", "lvCRTMove2", ""), 100, HorizontalAlignment.Left)
        frmCRT3.lvCRTMove.Columns.Add(objIniFile.GetString("frmCRT3", "lvCRTMove3", ""), 100, HorizontalAlignment.Left)
        frmCRT3.lvCRTMove.Columns.Add(objIniFile.GetString("frmCRT3", "lvCRTMove4", ""), 300, HorizontalAlignment.Left)
        frmCRT3.lvCRTMove.Columns.Add(objIniFile.GetString("frmCRT3", "lvCRTMove5", ""), 50, HorizontalAlignment.Left)
        frmCRT3.lvCRTMove.Columns.Add(objIniFile.GetString("frmCRT3", "lvCRTMove6", ""), 50, HorizontalAlignment.Left)

        frmCRT3.Text = objIniFile.GetString("frmCRT3", "frmCRT3", "")
        frmCRT3.gbTree.Text = objIniFile.GetString("frmCRT3", "gbTree", "")
        frmCRT3.Label1.Text = objIniFile.GetString("frmCRT3", "Label1", "")
        frmCRT3.Label2.Text = objIniFile.GetString("frmCRT3", "Label2", "")
        frmCRT3.Label3.Text = objIniFile.GetString("frmCRT3", "Label3", "")
        frmCRT3.Label4.Text = objIniFile.GetString("frmCRT3", "Label4", "")
        frmCRT3.Label5.Text = objIniFile.GetString("frmCRT3", "Label5", "")
        frmCRT3.Label6.Text = objIniFile.GetString("frmCRT3", "Label6", "")
        frmCRT3.Label7.Text = objIniFile.GetString("frmCRT3", "Label7", "")
        frmCRT3.Label8.Text = objIniFile.GetString("frmCRT3", "Label8", "")
        frmCRT3.Label9.Text = objIniFile.GetString("frmCRT3", "Label9", "")
        frmCRT3.Label10.Text = objIniFile.GetString("frmCRT3", "Label10", "")
        frmCRT3.Label11.Text = objIniFile.GetString("frmCRT3", "Label11", "")

        frmCRT3.TabControl1.TabPages("TabPage1").Text = objIniFile.GetString("frmCRT3", "TabControl1.TabPage1", "")
        frmCRT3.TabControl1.TabPages("TabPage2").Text = objIniFile.GetString("frmCRT3", "TabControl1.TabPage2", "")
        frmCRT3.TabControl1.TabPages("TabPage3").Text = objIniFile.GetString("frmCRT3", "TabControl1.TabPage3", "")

        frmCRT3.chkIznos.Text = objIniFile.GetString("frmCRT3", "chkIznos", "")
        frmCRT3.chkSPS.Text = objIniFile.GetString("frmCRT3", "chkSPS", "")
        frmCRT3.chkNezap.Text = objIniFile.GetString("frmCRT3", "chkNezap", "")
        frmCRT3.chkNZ.Text = objIniFile.GetString("frmCRT3", "chkNZ", "")
        frmCRT3.chkNaSP.Text = objIniFile.GetString("frmCRT3", "chkNaSP", "")
        frmCRT3.btnAdd.Text = objIniFile.GetString("frmCRT3", "btnAdd", "")
        frmCRT3.btnCancel.Text = objIniFile.GetString("frmCRT3", "btnCancel", "")
        frmCRT3.btnDelete.Text = objIniFile.GetString("frmCRT3", "btnDelete", "")

        frmCRT3.btnZapAdd.Text = objIniFile.GetString("frmCRT3", "btnZapAdd", "")
        frmCRT3.btnZapDel.Text = objIniFile.GetString("frmCRT3", "btnZapDel", "")
        frmCRT3.btnZapReport.Text = objIniFile.GetString("frmCRT3", "btnZapReport", "")




        'ResList(frmCRT3.lvCartZAP)
        'ResList(frmCRT3.lvCRTMove)
        ''ResList(frmCartr2.LVCart)
        'lvCartZAP

    End Sub

    Public Sub LANG_frmCartr_ADD_ZAp()
        Dim objIniFile As New IniFile(sLANGPATH)


        frmCartr_Add_Zap.Text = objIniFile.GetString("frmCartr_Add_Zap", "frmCartr_Add_Zap", "")

        frmCartr_Add_Zap.Label1.Text = objIniFile.GetString("frmCartr_Add_Zap", "Label1", "")
        frmCartr_Add_Zap.Label2.Text = objIniFile.GetString("frmCartr_Add_Zap", "Label2", "")
        frmCartr_Add_Zap.Label3.Text = objIniFile.GetString("frmCartr_Add_Zap", "Label3", "")
        frmCartr_Add_Zap.Label4.Text = objIniFile.GetString("frmCartr_Add_Zap", "Label4", "")
        frmCartr_Add_Zap.Label5.Text = objIniFile.GetString("frmCartr_Add_Zap", "Label5", "")
        frmCartr_Add_Zap.Label6.Text = objIniFile.GetString("frmCartr_Add_Zap", "Label6", "")
        frmCartr_Add_Zap.Label7.Text = objIniFile.GetString("frmCartr_Add_Zap", "Label7", "")

        frmCartr_Add_Zap.chkRef.Text = objIniFile.GetString("frmCartr_Add_Zap", "chkRef", "")
        frmCartr_Add_Zap.btnAdd.Text = objIniFile.GetString("frmCartr_Add_Zap", "btnAdd", "")
        frmCartr_Add_Zap.btnCancel.Text = objIniFile.GetString("frmCartr_Add_Zap", "btnCancel", "")

    End Sub

    Public Sub LANG_frmCartr_ADD()
        Dim objIniFile As New IniFile(sLANGPATH)


        frmCartr_ADD.Text = objIniFile.GetString("frmCartr_ADD", "frmCartr_ADD", "")
        frmCartr_ADD.Label1.Text = objIniFile.GetString("frmCartr_ADD", "Label1", "")
        frmCartr_ADD.Label2.Text = objIniFile.GetString("frmCartr_ADD", "Label2", "")
        frmCartr_ADD.Label3.Text = objIniFile.GetString("frmCartr_ADD", "Label3", "")
        frmCartr_ADD.Label4.Text = objIniFile.GetString("frmCartr_ADD", "Label4", "")
        frmCartr_ADD.Label5.Text = objIniFile.GetString("frmCartr_ADD", "Label5", "")
        frmCartr_ADD.Label6.Text = objIniFile.GetString("frmCartr_ADD", "Label6", "")
        frmCartr_ADD.Label7.Text = objIniFile.GetString("frmCartr_ADD", "Label7", "")
        frmCartr_ADD.Label8.Text = objIniFile.GetString("frmCartr_ADD", "Label8", "")
        frmCartr_ADD.Label9.Text = objIniFile.GetString("frmCartr_ADD", "Label9", "")
        frmCartr_ADD.Label10.Text = objIniFile.GetString("frmCartr_ADD", "Label10", "")
        frmCartr_ADD.Label11.Text = objIniFile.GetString("frmCartr_ADD", "Label11", "")

        frmCartr_ADD.chkNezap.Text = objIniFile.GetString("frmCartr_ADD", "chkNezap", "")
        frmCartr_ADD.chkNZ.Text = objIniFile.GetString("frmCartr_ADD", "chkNZ", "")
        frmCartr_ADD.chkIznos.Text = objIniFile.GetString("frmCartr_ADD", "chkIznos", "")
        frmCartr_ADD.chkSPS.Text = objIniFile.GetString("frmCartr_ADD", "chkSPS", "")
        frmCartr_ADD.chkNaSP.Text = objIniFile.GetString("frmCartr_ADD", "chkNaSP", "")
        frmCartr_ADD.btnAdd.Text = objIniFile.GetString("frmCartr_ADD", "btnAdd", "")
        'frmCartr_ADD.btnAdd2.Text = objIniFile.GetString("frmCartr_ADD", "btnAdd2", "")
        frmCartr_ADD.btnCancel.Text = objIniFile.GetString("frmCartr_ADD", "btnCancel", "")

    End Sub

    Public Sub LANG_frmserviceDesk()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmserviceDesc.lvRem.Columns.Clear()
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem1", ""), 20, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem3", ""), 30, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem4", ""), 90, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem5", ""), 300, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem6", ""), 100, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem7", ""), 100, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem8", ""), 100, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem9", ""), 90, HorizontalAlignment.Left)
        frmserviceDesc.lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem10", ""), 100, HorizontalAlignment.Left)


        frmserviceDesc.lvRem2.Columns.Clear()
        frmserviceDesc.lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_1", ""), 20, HorizontalAlignment.Left)
        frmserviceDesc.lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_2", ""), 90, HorizontalAlignment.Left)
        frmserviceDesc.lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_3", ""), 100, HorizontalAlignment.Left)
        frmserviceDesc.lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_4", ""), 300, HorizontalAlignment.Left)

        'ResList(frmserviceDesc.lvRem)
        'ResList(frmserviceDesc.lvRem2)


        frmserviceDesc.Text = LNGIniFile.GetString("frmserviceDesc", "frmserviceDesc", "")
        frmserviceDesc.gbTree.Text = LNGIniFile.GetString("frmserviceDesc", "gbTree", "")
        frmserviceDesc.btn_Z_to_Office.Text = LNGIniFile.GetString("frmserviceDesc", "btn_Z_to_Office", "")
        frmserviceDesc.gbRem.Text = LNGIniFile.GetString("frmserviceDesc", "gbRem", "")
        frmserviceDesc.btnRemAdd.Text = LNGIniFile.GetString("frmserviceDesc", "btnRemAdd", "")
        frmserviceDesc.btnSBTAdd.Text = LNGIniFile.GetString("frmserviceDesc", "btnSBTAdd", "")
        frmserviceDesc.btnRemDel.Text = LNGIniFile.GetString("frmserviceDesc", "btnRemDel", "")
        frmserviceDesc.chkNZ.Text = LNGIniFile.GetString("frmserviceDesc", "chkNZ", "")
        frmserviceDesc.CheckBox2.Text = LNGIniFile.GetString("frmserviceDesc", "CheckBox2", "")
        frmserviceDesc.btnSendEmail.Text = LNGIniFile.GetString("frmserviceDesc", "btnSendEmail", "")
        frmserviceDesc.Button1.Text = LNGIniFile.GetString("frmserviceDesc", "Button1", "")
        frmserviceDesc.gbRem2.Text = LNGIniFile.GetString("frmserviceDesc", "gbRem2", "")

    End Sub

    Public Sub frmSearch_Lang()
        Dim objIniFile As New IniFile(sLANGPATH)


        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch1", ""), 20, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch2", ""), 100, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch3", ""), 100, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch4", ""), 100, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch5", ""), 100, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch6", ""), 100, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch7", ""), 100, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch8", ""), 100, HorizontalAlignment.Left)
        frmSearch.lstSearch.Columns.Add(objIniFile.GetString("frmSearch", "lstSearch9", ""), 100, HorizontalAlignment.Left)

        'ResList(frmSearch.lstSearch)

        frmSearch.Text = objIniFile.GetString("frmSearch", "frmSearch", "")
        frmSearch.gbSearch.Text = objIniFile.GetString("frmSearch", "gbSearch", "")

        frmSearch.Label1.Text = objIniFile.GetString("frmSearch", "Label1", "")
        frmSearch.CheckBox1.Text = objIniFile.GetString("frmSearch", "CheckBox1", "")
        frmSearch.CheckBox2.Text = objIniFile.GetString("frmSearch", "CheckBox2", "")
        frmSearch.Button1.Text = objIniFile.GetString("frmSearch", "Button1", "")
        frmSearch.btnOfSend.Text = objIniFile.GetString("frmSearch", "btnOfSend", "")


    End Sub

    Public Sub frmService_add_Lang()
        Dim objIniFile As New IniFile(sLANGPATH)
        frmService_add.Text = objIniFile.GetString("frmService_add", "frmService_add", "")
        frmService_add.Label1.Text = objIniFile.GetString("frmService_add", "Label1", "")
        frmService_add.Label2.Text = objIniFile.GetString("frmService_add", "Label2", "")
        frmService_add.Label3.Text = objIniFile.GetString("frmService_add", "Label3", "")
        frmService_add.Label4.Text = objIniFile.GetString("frmService_add", "Label4", "")
        frmService_add.Label5.Text = objIniFile.GetString("frmService_add", "Label5", "")
        frmService_add.Label6.Text = objIniFile.GetString("frmService_add", "Label6", "")
        frmService_add.Label7.Text = objIniFile.GetString("frmService_add", "Label7", "")
        frmService_add.Label8.Text = objIniFile.GetString("frmService_add", "Label8", "")
        frmService_add.Label9.Text = objIniFile.GetString("frmService_add", "Label9", "")
        frmService_add.Label10.Text = objIniFile.GetString("frmService_add", "Label10", "")
        frmService_add.Label11.Text = objIniFile.GetString("frmService_add", "Label11", "")
        frmService_add.Label12.Text = objIniFile.GetString("frmService_add", "Label12", "")
        frmService_add.Label13.Text = objIniFile.GetString("frmService_add", "Label13", "")

        frmService_add.chkClose.Text = objIniFile.GetString("frmService_add", "chkClose", "")
        frmService_add.cmbAdd.Text = objIniFile.GetString("frmService_add", "cmbAdd", "")
        frmService_add.cmbCancel.Text = objIniFile.GetString("frmService_add", "cmbCancel", "")


    End Sub

    Public Sub frmservice_add_otvets_Lang()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmservice_add_otvets.Text = LNGIniFile.GetString("frmservice_add_otvets", "frmservice_add_otvets", "")
        frmservice_add_otvets.GroupBox1.Text = LNGIniFile.GetString("frmservice_add_otvets", "GroupBox1", "")

        frmservice_add_otvets.Label1.Text = LNGIniFile.GetString("frmservice_add_otvets", "Label1", "")
        frmservice_add_otvets.Label2.Text = LNGIniFile.GetString("frmservice_add_otvets", "Label2", "")
        frmservice_add_otvets.chcClose.Text = LNGIniFile.GetString("frmservice_add_otvets", "chcClose", "")
        frmservice_add_otvets.Label3.Text = LNGIniFile.GetString("frmservice_add_otvets", "Label3", "")
        frmservice_add_otvets.gbExt.Text = LNGIniFile.GetString("frmservice_add_otvets", "gbExt", "")
        frmservice_add_otvets.Label4.Text = LNGIniFile.GetString("frmservice_add_otvets", "Label4", "")
        frmservice_add_otvets.Label5.Text = LNGIniFile.GetString("frmservice_add_otvets", "Label5", "")
        frmservice_add_otvets.Label6.Text = LNGIniFile.GetString("frmservice_add_otvets", "Label6", "")
        frmservice_add_otvets.Label7.Text = LNGIniFile.GetString("frmservice_add_otvets", "Label7", "")
        frmservice_add_otvets.cmdAdd.Text = LNGIniFile.GetString("frmservice_add_otvets", "cmdAdd", "")
        frmservice_add_otvets.cmdCancel.Text = LNGIniFile.GetString("frmservice_add_otvets", "cmdCancel", "")



    End Sub

    Public Sub frmDirectory_Lang()
        Dim objIniFile As New IniFile(sLANGPATH)


        frmDirectory.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 20, HorizontalAlignment.Left)
        frmDirectory.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)
        frmDirectory.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory3", ""), 300, HorizontalAlignment.Left)

        'ResList(frmDirectory.lvDirectory)

        frmDirectory.Text = objIniFile.GetString("frmDirectory", "frmDirectory", "")

        frmDirectory.gbSpr.Text = objIniFile.GetString("frmDirectory", "gbSpr", "")
        frmDirectory.Label1.Text = objIniFile.GetString("frmDirectory", "Label1", "")
        frmDirectory.Label2.Text = objIniFile.GetString("frmDirectory", "Label2", "")
        frmDirectory.Label3.Text = objIniFile.GetString("frmDirectory", "Label3", "")
        frmDirectory.Label4.Text = objIniFile.GetString("frmDirectory", "Label4", "")

        frmDirectory.gb1.Text = objIniFile.GetString("frmDirectory", "gb1", "")
        frmDirectory.gb2.Text = objIniFile.GetString("frmDirectory", "gb2", "")
        frmDirectory.chkVisibleSTR.Text = objIniFile.GetString("frmDirectory", "chkVisibleSTR", "")
        frmDirectory.btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")

        frmDirectory.Button2.Text = objIniFile.GetString("frmDirectory", "Button2", "")
        frmDirectory.btnCancell.Text = objIniFile.GetString("frmDirectory", "btnCancell", "")
        frmDirectory.Button3.Text = objIniFile.GetString("frmDirectory", "Button3", "")


    End Sub

    Public Sub frmSclad_Lang()
        Dim objIniFile As New IniFile(sLANGPATH)


        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad1", ""), 20, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad2", ""), 150, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad3", ""), 50, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad4", ""), 50, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad5", ""), 100, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad6", ""), 65, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad7", ""), 120, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad8", ""), 50, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad9", ""), 67, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad10", ""), 67, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad11", ""), 67, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad12", ""), 67, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad13", ""), 67, HorizontalAlignment.Left)
        frmSclad.lvSclad.Columns.Add(objIniFile.GetString("frmSclad", "lvSclad14", ""), 67, HorizontalAlignment.Left)

        'ResList(frmSclad.lvSclad)


        frmSclad.Text = objIniFile.GetString("frmSclad", "frmSclad", "")

        frmSclad.btnAdd.Text = objIniFile.GetString("frmSclad", "btnAdd", "")
        frmSclad.btnDel.Text = objIniFile.GetString("frmSclad", "btnDel", "")
        frmSclad.btnTREB.Text = objIniFile.GetString("frmSclad", "btnTREB", "")
        frmSclad.btnOffice.Text = objIniFile.GetString("frmSclad", "btnOffice", "")


    End Sub

    Public Sub LANG_frmSclad_ADD()
        Dim objIniFile As New IniFile(sLANGPATH)
        frmSclad_ADD.Text = objIniFile.GetString("frmSclad_ADD", "frmSclad_ADD", "")

        frmSclad_ADD.Label1.Text = objIniFile.GetString("frmSclad_ADD", "Label1", "")
        frmSclad_ADD.Label2.Text = objIniFile.GetString("frmSclad_ADD", "Label2", "")
        frmSclad_ADD.Label3.Text = objIniFile.GetString("frmSclad_ADD", "Label3", "")
        frmSclad_ADD.Label4.Text = objIniFile.GetString("frmSclad_ADD", "Label4", "")
        frmSclad_ADD.Label5.Text = objIniFile.GetString("frmSclad_ADD", "Label5", "")
        frmSclad_ADD.Label6.Text = objIniFile.GetString("frmSclad_ADD", "Label6", "")
        frmSclad_ADD.Label7.Text = objIniFile.GetString("frmSclad_ADD", "Label7", "")
        frmSclad_ADD.Label8.Text = objIniFile.GetString("frmSclad_ADD", "Label8", "")
        frmSclad_ADD.Label9.Text = objIniFile.GetString("frmSclad_ADD", "Label9", "")
        frmSclad_ADD.Label10.Text = objIniFile.GetString("frmSclad_ADD", "Label10", "")
        frmSclad_ADD.Label11.Text = objIniFile.GetString("frmSclad_ADD", "Label11", "")
        frmSclad_ADD.Label12.Text = objIniFile.GetString("frmSclad_ADD", "Label12", "")
        frmSclad_ADD.Label13.Text = objIniFile.GetString("frmSclad_ADD", "Label13", "")

        frmSclad_ADD.add.Text = objIniFile.GetString("frmSclad_ADD", "add", "")
        frmSclad_ADD.cancel.Text = objIniFile.GetString("frmSclad_ADD", "cancel", "")




    End Sub

    Public Sub LANG_frmSclad_treb()
        Dim objIniFile As New IniFile(sLANGPATH)

        frmSclad_treb.Label1.Text = objIniFile.GetString("frmSclad_treb", "Label1", "")
        frmSclad_treb.Label2.Text = objIniFile.GetString("frmSclad_treb", "Label2", "")
        frmSclad_treb.Label3.Text = objIniFile.GetString("frmSclad_treb", "Label3", "")
        frmSclad_treb.Label4.Text = objIniFile.GetString("frmSclad_treb", "Label4", "")
        frmSclad_treb.Label5.Text = objIniFile.GetString("frmSclad_treb", "Label5", "")
        frmSclad_treb.Label6.Text = objIniFile.GetString("frmSclad_treb", "Label6", "")
        frmSclad_treb.Label7.Text = objIniFile.GetString("frmSclad_treb", "Label7", "")
        frmSclad_treb.Label8.Text = objIniFile.GetString("frmSclad_treb", "Label8", "")
        frmSclad_treb.Label9.Text = objIniFile.GetString("frmSclad_treb", "Label9", "")
        frmSclad_treb.Label10.Text = objIniFile.GetString("frmSclad_treb", "Label10", "")

        frmSclad_treb.Text = objIniFile.GetString("frmSclad_treb", "frmSclad_treb", "")
        frmSclad_treb.btnVipiska.Text = objIniFile.GetString("frmSclad_treb", "btnVipiska", "")
        frmSclad_treb.btnCancel.Text = objIniFile.GetString("frmSclad_treb", "btnCancel", "")


    End Sub

    Public Sub frmSetup_Lang()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmSetup.lvFindDB.Columns.Add(LNGIniFile.GetString("frmSetup", "lvFindDB1", ""), 20, HorizontalAlignment.Left)
        frmSetup.lvFindDB.Columns.Add(LNGIniFile.GetString("frmSetup", "lvFindDB2", ""), 300, HorizontalAlignment.Left)
        frmSetup.lvFindDB.Columns.Add(LNGIniFile.GetString("frmSetup", "lvFindDB3", ""), 70, HorizontalAlignment.Left)

        'lvPrUsers
        frmSetup.lvPrUsers.Columns.Add(LNGIniFile.GetString("frmSetup", "lvPrUsers1", ""), 20, HorizontalAlignment.Left)
        frmSetup.lvPrUsers.Columns.Add(LNGIniFile.GetString("frmSetup", "lvPrUsers2", ""), 100, HorizontalAlignment.Left)
        frmSetup.lvPrUsers.Columns.Add(LNGIniFile.GetString("frmSetup", "lvPrUsers3", ""), 200, HorizontalAlignment.Left)
        frmSetup.lvPrUsers.Columns.Add(LNGIniFile.GetString("frmSetup", "lvPrUsers4", ""), 70, HorizontalAlignment.Left)

        ''ResList(frmSetup.lvPrUsers)


        frmSetup.Text = LNGIniFile.GetString("frmSetup", "frmSetup", "")

        frmSetup.SStab1.TabPages("TabPage1").Text = LNGIniFile.GetString("frmSetup", "SStab1_1", "")
        frmSetup.SStab1.TabPages("TabPage3").Text = LNGIniFile.GetString("frmSetup", "SStab1_2", "")
        frmSetup.SStab1.TabPages("TabPage4").Text = LNGIniFile.GetString("frmSetup", "SStab1_3", "")
        frmSetup.SStab1.TabPages("TabPage5").Text = LNGIniFile.GetString("frmSetup", "SStab1_4", "")

        frmSetup.gbSetup.Text = LNGIniFile.GetString("frmSetup", "gbSetup", "")

        frmSetup.chkUpdate.Text = LNGIniFile.GetString("frmSetup", "chkUpdate", "")
        frmSetup.chkSNPro.Text = LNGIniFile.GetString("frmSetup", "chkSNPro", "")
        frmSetup.chkSheduler.Text = LNGIniFile.GetString("frmSetup", "chkSheduler", "")
        frmSetup.chkMenuServices.Text = LNGIniFile.GetString("frmSetup", "chkMenuServices", "")

        frmSetup.chkArhiv2exit.Text = LNGIniFile.GetString("frmSetup", "chkArhiv2exit", "")
        frmSetup.lblDefaultModul.Text = LNGIniFile.GetString("frmSetup", "lblDefaultModul", "")
        frmSetup.lblSortTree.Text = LNGIniFile.GetString("frmSetup", "lblSortTree", "")
        frmSetup.lblOffice.Text = LNGIniFile.GetString("frmSetup", "lblOffice", "")
        frmSetup.lblOtchet.Text = LNGIniFile.GetString("frmSetup", "lblOtchet", "")
        frmSetup.lblDB.Text = LNGIniFile.GetString("frmSetup", "lblDB", "")
        frmSetup.GroupBox1.Text = LNGIniFile.GetString("frmSetup", "GroupBox1", "")
        frmSetup.Label9.Text = LNGIniFile.GetString("frmSetup", "Label9", "")
        frmSetup.Button2.Text = LNGIniFile.GetString("frmSetup", "Button2", "")
        frmSetup.gbTree_o.Text = LNGIniFile.GetString("frmSetup", "gbTree_o", "")
        frmSetup.RadioButton1.Text = LNGIniFile.GetString("frmSetup", "RadioButton1", "")
        frmSetup.RadioButton2.Text = LNGIniFile.GetString("frmSetup", "RadioButton2", "")
        frmSetup.RadioButton3.Text = LNGIniFile.GetString("frmSetup", "RadioButton3", "")
        frmSetup.GroupBox2.Text = LNGIniFile.GetString("frmSetup", "GroupBox2", "")
        frmSetup.RadioButton4.Text = LNGIniFile.GetString("frmSetup", "RadioButton4", "")
        frmSetup.RadioButton5.Text = LNGIniFile.GetString("frmSetup", "RadioButton5", "")
        frmSetup.RadioButton6.Text = LNGIniFile.GetString("frmSetup", "RadioButton6", "")
        frmSetup.RadioButton7.Text = LNGIniFile.GetString("frmSetup", "RadioButton7", "")

        frmSetup.RadioButton8.Text = LNGIniFile.GetString("frmSetup", "RadioButton8", "")
        frmSetup.RadioButton9.Text = LNGIniFile.GetString("frmSetup", "RadioButton9", "")
        frmSetup.Label6.Text = LNGIniFile.GetString("frmSetup", "Label6", "")
        frmSetup.Label7.Text = LNGIniFile.GetString("frmSetup", "Label7", "")
        frmSetup.Label8.Text = LNGIniFile.GetString("frmSetup", "Label8", "")
        frmSetup.Label10.Text = LNGIniFile.GetString("frmSetup", "Label10", "")
        frmSetup.btnSave.Text = LNGIniFile.GetString("frmSetup", "btnSave", "")

        frmSetup.Button1.Text = LNGIniFile.GetString("frmSetup", "Button1", "")
        frmSetup.Label1.Text = LNGIniFile.GetString("frmSetup", "Label1", "")
        frmSetup.Label2.Text = LNGIniFile.GetString("frmSetup", "Label2", "")
        frmSetup.Label3.Text = LNGIniFile.GetString("frmSetup", "Label3", "")
        frmSetup.Label4.Text = LNGIniFile.GetString("frmSetup", "Label4", "")
        frmSetup.Label5.Text = LNGIniFile.GetString("frmSetup", "Label5", "")
        frmSetup.btnEnc.Text = LNGIniFile.GetString("frmSetup", "btnEnc", "")
        frmSetup.btnAdd.Text = LNGIniFile.GetString("frmSetup", "btnAdd", "")
        frmSetup.btnDel.Text = LNGIniFile.GetString("frmSetup", "btnDel", "")
        frmSetup.btnCancel.Text = LNGIniFile.GetString("frmSetup", "btnCancel", "")
        frmSetup.gbUsers.Text = LNGIniFile.GetString("frmSetup", "gbUsers", "")
        frmSetup.gbUserLevel.Text = LNGIniFile.GetString("frmSetup", "gbUserLevel", "")
        frmSetup.chkSetup.Text = LNGIniFile.GetString("frmSetup", "chkSetup", "")
        frmSetup.chkTehAdd.Text = LNGIniFile.GetString("frmSetup", "chkTehAdd", "")
        frmSetup.chkTehDel.Text = LNGIniFile.GetString("frmSetup", "chkTehDel", "")
        frmSetup.chkNotesAdd.Text = LNGIniFile.GetString("frmSetup", "chkNotesAdd", "")
        frmSetup.chkNotesDel.Text = LNGIniFile.GetString("frmSetup", "chkNotesDel", "")
        frmSetup.chkRepAdd.Text = LNGIniFile.GetString("frmSetup", "chkRepAdd", "")
        frmSetup.chkRepEd.Text = LNGIniFile.GetString("frmSetup", "chkRepEd", "")
        frmSetup.chkRepDel.Text = LNGIniFile.GetString("frmSetup", "chkRepDel", "")
        frmSetup.chkCart.Text = LNGIniFile.GetString("frmSetup", "chkCart", "")
        frmSetup.chkWarehause.Text = LNGIniFile.GetString("frmSetup", "chkWarehause", "")
        frmSetup.chkPO.Text = LNGIniFile.GetString("frmSetup", "chkPO", "")
        frmSetup.chkPOAdd.Text = LNGIniFile.GetString("frmSetup", "chkPOAdd", "")
        frmSetup.chkPODel.Text = LNGIniFile.GetString("frmSetup", "chkPODel", "")


        frmSetup.chkDVIG.Text = LNGIniFile.GetString("frmSetup", "chkDVIG", "")
        frmSetup.chkREMONT.Text = LNGIniFile.GetString("frmSetup", "chkREMONT", "")
        frmSetup.chkPOu.Text = LNGIniFile.GetString("frmSetup", "chkPOu", "")
        frmSetup.chkVSUst.Text = LNGIniFile.GetString("frmSetup", "chkVSUst", "")
        frmSetup.chk_no_log.Text = LNGIniFile.GetString("frmSetup", "chk_no_log", "")
        frmSetup.gbMyBlank.Text = LNGIniFile.GetString("frmSetup", "gbMyBlank", "")


    End Sub

    Public Sub frmARHIV_Lang()
        Dim objIniFile As New IniFile(sLANGPATH)

        'frmARHIV.lstArh.Columns.Add("id", 20, HorizontalAlignment.Left)
        'frmARHIV.lstArh.Columns.Add(("Архив"), 300, HorizontalAlignment.Left)

        frmARHIV.Text = objIniFile.GetString("frmARHIV", "frmARHIV", "")
        frmARHIV.btnZipUp.Text = objIniFile.GetString("frmARHIV", "btnZipUp", "")
        frmARHIV.btnUnZip.Text = objIniFile.GetString("frmARHIV", "btnUnZip", "")


    End Sub

    Public Sub frmComputers_Lang()
        On Error GoTo err_

        Dim objIniFile As New IniFile(sLANGPATH)



        frmComputers.addRemToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "addRemToolStripMenuItem", "")
        frmComputers.CartrAddToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "CartrAddToolStripMenuItem", "")
        frmComputers.CopyToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "CopyToolStripMenuItem", "")
        frmComputers.UpdateToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "UpdateToolStripMenuItem", "")
        frmComputers.DeleteToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "DeleteToolStripMenuItem", "")
        frmComputers.ОтделитьПринтерыИМониторыToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "ОтделитьПринтерыИМониторыToolStripMenuItem", "")
        frmComputers.ВернутьПерефериюToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "ВернутьПерефериюToolStripMenuItem", "")

        frmComputers.MassRazdelPerf.Text = objIniFile.GetString("frmComputers", "ОтделитьПринтерыИМониторыToolStripMenuItem", "")
        frmComputers.MassObedPerf.Text = objIniFile.GetString("frmComputers", "ВернутьПерефериюToolStripMenuItem", "")
        'MassObedPerf
        'MassRazdelPerf


        frmComputers.mnuDeltoBranch.Text = objIniFile.GetString("frmComputers", "mnuDeltoBranch", "")
        frmComputers.addFoldertoBranch.Text = objIniFile.GetString("frmComputers", "addFoldertoBranch", "")
        frmComputers.DeleteBranche.Text = objIniFile.GetString("frmComputers", "DeleteBranche", "")
        frmComputers.RepAddBrToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "RepAddBrToolStripMenuItem", "")
        frmComputers.SoftInstallToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "SoftInstallToolStripMenuItem", "")
        frmComputers.ПаспортКомпьютераToolStripMenuItem.Text = objIniFile.GetString("frmComputers", "ПаспортКомпьютераToolStripMenuItem", "")

        frmComputers.lstUsers.Columns.Add(objIniFile.GetString("frmComputers", "lstUsers1", ""), 20, HorizontalAlignment.Left)
        frmComputers.lstUsers.Columns.Add(objIniFile.GetString("frmComputers", "lstUsers2", ""), 300, HorizontalAlignment.Left)
        frmComputers.lstUsers.Columns.Add(objIniFile.GetString("frmComputers", "lstUsers3", ""), 100, HorizontalAlignment.Left)
        frmComputers.lstUsers.Columns.Add(objIniFile.GetString("frmComputers", "lstUsers4", ""), 100, HorizontalAlignment.Left)
        frmComputers.lstUsers.Columns.Add(objIniFile.GetString("frmComputers", "lstUsers5", ""), 75, HorizontalAlignment.Left)
        frmComputers.lstUsers.Columns.Add(objIniFile.GetString("frmComputers", "lstUsers6", ""), 75, HorizontalAlignment.Left)


        LANG_REPAIR(frmComputers.lvRepairPRN)
        LANG_REPAIR(frmComputers.lvRepair)
        LANG_REPAIR(frmComputers.lvRepairOTH)
        LANG_REPAIR(frmComputers.lvRepairNET)
        LANG_REPAIR(frmComputers.lvRepairBR)

        LANG_NOTES(frmComputers.lvNotes)
        LANG_NOTES(frmComputers.lvNotesPRN)
        LANG_NOTES(frmComputers.lvNotesOTH)
        LANG_NOTES(frmComputers.lvNotesNET)
        LANG_NOTES(frmComputers.lvNotesBR)


        LANG_SOFT(frmComputers.lstSoftware)

        LANG_MOVEMENT(frmComputers.lvMovement)
        LANG_MOVEMENT(frmComputers.lvMovementOTH)
        LANG_MOVEMENT(frmComputers.lvMovementPRN)
        LANG_MOVEMENT(frmComputers.lvMovementNET)


        frmComputers.lvNetPort.Columns.Add(objIniFile.GetString("frmComputers", "lvNetPort1", ""), 20, HorizontalAlignment.Left)
        frmComputers.lvNetPort.Columns.Add(objIniFile.GetString("frmComputers", "lvNetPort2", ""), 50, HorizontalAlignment.Left)
        frmComputers.lvNetPort.Columns.Add(objIniFile.GetString("frmComputers", "lvNetPort3", ""), 300, HorizontalAlignment.Left)
        frmComputers.lvNetPort.Columns.Add(objIniFile.GetString("frmComputers", "lvNetPort4", ""), 100, HorizontalAlignment.Left)

        frmComputers.lvPRNCartr.Columns.Add(objIniFile.GetString("frmComputers", "lvPRNCartr1", ""), 20, HorizontalAlignment.Left)
        frmComputers.lvPRNCartr.Columns.Add(objIniFile.GetString("frmComputers", "lvPRNCartr2", ""), 300, HorizontalAlignment.Left)
        frmComputers.lvPRNCartr.Columns.Add(objIniFile.GetString("frmComputers", "lvPRNCartr3", ""), 100, HorizontalAlignment.Left)
        frmComputers.lvPRNCartr.Columns.Add(objIniFile.GetString("frmComputers", "lvPRNCartr4", ""), 100, HorizontalAlignment.Left)
        frmComputers.lvPRNCartr.Columns.Add(objIniFile.GetString("frmComputers", "lvPRNCartr5", ""), 75, HorizontalAlignment.Left)

        frmComputers.Text = objIniFile.GetString("frmComputers", "frmComputers", "")
        frmComputers.gbTree.Text = objIniFile.GetString("frmComputers", "gbTree", "")
        frmComputers.chkVisibleSTR.Text = objIniFile.GetString("frmComputers", "chkVisibleSTR", "")
        frmComputers.gbStat.Text = objIniFile.GetString("frmComputers", "gbStat", "")
        frmComputers.lblT_All_T.Text = objIniFile.GetString("frmComputers", "lblT_All_T", "")
        frmComputers.lblT_O_T.Text = objIniFile.GetString("frmComputers", "lblT_O_T", "")
        frmComputers.sSTAB1.TabPages("TabPage6").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(6)", "")
        frmComputers.sSTAB1.TabPages("TabPage1").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(1)", "")
        frmComputers.sSTAB1.TabPages("TabPage2").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(2)", "")
        frmComputers.sSTAB1.TabPages("TabPage3").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(3)", "")
        frmComputers.sSTAB1.TabPages("TabPage4").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(4)", "")
        frmComputers.sSTAB1.TabPages("TabPage5").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(5)", "")
        frmComputers.sSTAB1.TabPages("TabPage7").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(7)", "")
        frmComputers.sSTAB1.TabPages("TabPage8").Text = objIniFile.GetString("frmComputers", "sSTAB1.TabPages(8)", "")

        Call INFO_P_LANG(frmComputers.lblBranch, frmComputers.lblDepartment, frmComputers.lblOffice, frmComputers.lblResponsible, frmComputers.lblPhone, frmComputers.Label84)

        frmComputers.lblNetName.Text = objIniFile.GetString("frmComputers", "lblNetName", "")
        frmComputers.lblPseudonym.Text = objIniFile.GetString("frmComputers", "lblPseudonym", "")
        frmComputers.lblAppointment.Text = objIniFile.GetString("frmComputers", "lblAppointment", "")

        frmComputers.gbInNumber.Text = objIniFile.GetString("frmComputers", "gbInNumber", "")
        frmComputers.Label16.Text = objIniFile.GetString("frmComputers", "Label16", "")
        frmComputers.Label17.Text = objIniFile.GetString("frmComputers", "Label17", "")
        frmComputers.Label18.Text = objIniFile.GetString("frmComputers", "Label18", "")
        frmComputers.Label19.Text = objIniFile.GetString("frmComputers", "Label19", "")


        frmComputers.gbMovement.Text = objIniFile.GetString("frmComputers", "gbMovement", "")

        frmComputers.gbcpu.Text = objIniFile.GetString("frmComputers", "gbcpu", "")
        frmComputers.gbMB.Text = objIniFile.GetString("frmComputers", "gbMB", "")
        frmComputers.gbRAM.Text = objIniFile.GetString("frmComputers", "gbRAM", "")
        frmComputers.gbHDD.Text = objIniFile.GetString("frmComputers", "gbHDD", "")
        frmComputers.gbSVGA.Text = objIniFile.GetString("frmComputers", "gbSVGA", "")
        frmComputers.gbSOUND.Text = objIniFile.GetString("frmComputers", "gbSOUND", "")
        frmComputers.gbOptical.Text = objIniFile.GetString("frmComputers", "gbOptical", "")
        frmComputers.gbNetwork.Text = objIniFile.GetString("frmComputers", "gbNetwork", "")
        frmComputers.gbFDD.Text = objIniFile.GetString("frmComputers", "gbFDD", "")
        frmComputers.gbCreader.Text = objIniFile.GetString("frmComputers", "gbCreader", "")
        frmComputers.gbModem.Text = objIniFile.GetString("frmComputers", "gbModem", "")
        frmComputers.gbCase.Text = objIniFile.GetString("frmComputers", "gbCase", "")
        frmComputers.gbBP.Text = objIniFile.GetString("frmComputers", "gbBP", "")
        frmComputers.gbUSB.Text = objIniFile.GetString("frmComputers", "gbUSB", "")
        frmComputers.gbPCI.Text = objIniFile.GetString("frmComputers", "gbPCI", "")
        frmComputers.gbSBP.Text = objIniFile.GetString("frmComputers", "gbSBP", "")
        frmComputers.gbMonitor.Text = objIniFile.GetString("frmComputers", "gbMonitor", "")
        frmComputers.gbKeyboard.Text = objIniFile.GetString("frmComputers", "gbKeyboard", "")
        frmComputers.gbMouse.Text = objIniFile.GetString("frmComputers", "gbMouse", "")
        frmComputers.gbAsystem.Text = objIniFile.GetString("frmComputers", "gbAsystem", "")
        frmComputers.gbFilter.Text = objIniFile.GetString("frmComputers", "gbFilter", "")
        frmComputers.gbIBP.Text = objIniFile.GetString("frmComputers", "gbIBP", "")
        frmComputers.gbPrinters.Text = objIniFile.GetString("frmComputers", "gbPrinters", "")

        frmComputers.lblUsername.Text = objIniFile.GetString("frmComputers", "lblUsername", "")
        frmComputers.lblSurname.Text = objIniFile.GetString("frmComputers", "lblSurname", "")
        frmComputers.lblICQ.Text = objIniFile.GetString("frmComputers", "lblICQ", "")
        frmComputers.lblEMAIL.Text = objIniFile.GetString("frmComputers", "lblEMAIL", "")
        frmComputers.Label36.Text = objIniFile.GetString("frmComputers", "Label36", "")
        frmComputers.lbluserPassword.Text = objIniFile.GetString("frmComputers", "lbluserPassword", "")
        frmComputers.lblJabber.Text = objIniFile.GetString("frmComputers", "lblJabber", "")
        frmComputers.lblEmailPass.Text = objIniFile.GetString("frmComputers", "lblEmailPass", "")
        frmComputers.ChkPDC.Text = objIniFile.GetString("frmComputers", "ChkPDC", "")
        frmComputers.cmdUserAdd.Text = objIniFile.GetString("frmComputers", "cmdUserAdd", "")
        frmComputers.cmdUserDel.Text = objIniFile.GetString("frmComputers", "cmdUserDel", "")
        frmComputers.cmdUserPassEncript.Text = objIniFile.GetString("frmComputers", "cmdUserPassEncript", "")
        frmComputers.btnUserCancel.Text = objIniFile.GetString("frmComputers", "btnUserCancel", "")

        Call NOTES_P_LANG(frmComputers.gbNotes, frmComputers.btnNotesAdd, frmComputers.btnNotesDel, frmComputers.btnNotesCancel)

        frmComputers.gbRepair.Text = objIniFile.GetString("frmComputers", "gbRepair", "")

        frmComputers.gbGuarantee.Text = objIniFile.GetString("frmComputers", "gbGuarantee", "")
        frmComputers.rbKompl.Text = objIniFile.GetString("frmComputers", "rbKompl", "")
        frmComputers.rbSist.Text = objIniFile.GetString("frmComputers", "rbSist", "")

        Call GARANT_P_LANG(frmComputers.gbSeller, frmComputers.Label20, frmComputers.Label22, frmComputers.Label21)

        Call SALE_P_LANG(frmComputers.gbSale, frmComputers.Label43, frmComputers.Label44, frmComputers.Label44, frmComputers.chkPCspis, frmComputers.Label46, frmComputers.Label47, frmComputers.Label48, frmComputers.chkPCNNb)

        'Отделы
        frmComputers.sSTAB5.TabPages("TabPage19").Text = objIniFile.GetString("frmComputers", "sSTAB5.TabPages(19)", "")
        frmComputers.sSTAB5.TabPages("TabPage20").Text = objIniFile.GetString("frmComputers", "sSTAB5.TabPages(20)", "")
        frmComputers.sSTAB5.TabPages("TabPage21").Text = objIniFile.GetString("frmComputers", "sSTAB5.TabPages(21)", "")

        frmComputers.Label70.Text = objIniFile.GetString("frmComputers", "Label70", "")
        frmComputers.Label69.Text = objIniFile.GetString("frmComputers", "Label69", "")
        frmComputers.Label68.Text = objIniFile.GetString("frmComputers", "Label68", "")
        frmComputers.Label67.Text = objIniFile.GetString("frmComputers", "Label67", "")

        frmComputers.gbBRRemont.Text = objIniFile.GetString("frmComputers", "gbBRRemont", "")
        frmComputers.Label82.Text = objIniFile.GetString("frmComputers", "Label82", "")
        frmComputers.Label81.Text = objIniFile.GetString("frmComputers", "Label81", "")
        frmComputers.Label80.Text = objIniFile.GetString("frmComputers", "Label80", "")
        frmComputers.Label79.Text = objIniFile.GetString("frmComputers", "Label79", "")
        frmComputers.Label78.Text = objIniFile.GetString("frmComputers", "Label78", "")
        frmComputers.Label77.Text = objIniFile.GetString("frmComputers", "Label77", "")
        frmComputers.Label76.Text = objIniFile.GetString("frmComputers", "Label76", "")
        frmComputers.Label75.Text = objIniFile.GetString("frmComputers", "Label75", "")
        frmComputers.Label74.Text = objIniFile.GetString("frmComputers", "Label74", "")
        frmComputers.Label73.Text = objIniFile.GetString("frmComputers", "Label73", "")
        frmComputers.Label72.Text = objIniFile.GetString("frmComputers", "Label72", "")
        frmComputers.Label71.Text = objIniFile.GetString("frmComputers", "Label71", "")
        frmComputers.btnOfficeSend.Text = objIniFile.GetString("frmComputers", "btnOfficeSend", "")

        Call NOTES_P_LANG(frmComputers.gbBRNotes, frmComputers.btnBRNotesAdd, frmComputers.btnBRNotesDel, frmComputers.btnBRNotesCancel)

        'Вкладка принтеры

        frmComputers.sSTAB2.TabPages("TabPage9").Text = objIniFile.GetString("frmComputers", "sSTAB2.TabPages(9)", "")
        frmComputers.sSTAB2.TabPages("TabPage23").Text = objIniFile.GetString("frmComputers", "sSTAB2.TabPages(23)", "")
        frmComputers.sSTAB2.TabPages("TabPage10").Text = objIniFile.GetString("frmComputers", "sSTAB2.TabPages(10)", "")
        frmComputers.sSTAB2.TabPages("TabPage16").Text = objIniFile.GetString("frmComputers", "sSTAB2.TabPages(16)", "")
        frmComputers.gbPRN.Text = objIniFile.GetString("frmComputers", "gbPRN", "")
        frmComputers.lblFormat.Text = objIniFile.GetString("frmComputers", "lblFormat", "")

        Call INFO_P_LANG(frmComputers.lblPRNFil, frmComputers.lblPRNDepart, frmComputers.lblPRNOffice, frmComputers.lblPRNotv, frmComputers.lblPRNphone, frmComputers.Label85)

        frmComputers.lblPRNConnect.Text = objIniFile.GetString("frmComputers", "lblPRNConnect", "")
        frmComputers.lblInNumber.Text = objIniFile.GetString("frmComputers", "lblInNumber", "")
        frmComputers.lblTIPCartridg.Text = objIniFile.GetString("frmComputers", "lblTIPCartridg", "")
        frmComputers.lblModCartr.Text = objIniFile.GetString("frmComputers", "lblModCartr", "")
        frmComputers.lblPRNprintPage.Text = objIniFile.GetString("frmComputers", "lblPRNprintPage", "")
        frmComputers.lblPrnIP.Text = objIniFile.GetString("frmComputers", "lblPrnIP", "")
        frmComputers.lblPrnMAC.Text = objIniFile.GetString("frmComputers", "lblPrnMAC", "")
        frmComputers.Label83.Text = objIniFile.GetString("frmComputers", "Label83", "")
        frmComputers.gbPRNCartr.Text = objIniFile.GetString("frmComputers", "gbPRNCartr", "")

        Call NOTES_P_LANG(frmComputers.gbPRNNotes, frmComputers.btnPRNNotesAdd, frmComputers.btnPRNNotesDel, frmComputers.btnPRNNotesCancel)

        frmComputers.gbPRNRemont.Text = objIniFile.GetString("frmComputers", "gbRepair", "")

        Call GARANT_P_LANG(frmComputers.gbPostPRN, frmComputers.Label4, frmComputers.Label2, frmComputers.Label1)
        Call SALE_P_LANG(frmComputers.gbSalePRN, frmComputers.Label54, frmComputers.Label53, frmComputers.Label52, frmComputers.chkPRNspis, frmComputers.Label51, frmComputers.Label50, frmComputers.Label49, frmComputers.chkPRNNNb)

        'Вкладка сетевое оборудование

        frmComputers.sSTAB4.TabPages("TabPage13").Text = objIniFile.GetString("frmComputers", "sSTAB4.TabPages(13)", "")
        frmComputers.sSTAB4.TabPages("TabPage14").Text = objIniFile.GetString("frmComputers", "sSTAB4.TabPages(14)", "")
        frmComputers.sSTAB4.TabPages("TabPage24").Text = objIniFile.GetString("frmComputers", "sSTAB4.TabPages(24)", "")
        frmComputers.sSTAB4.TabPages("TabPage15").Text = objIniFile.GetString("frmComputers", "sSTAB4.TabPages(15)", "")
        frmComputers.sSTAB4.TabPages("TabPage17").Text = objIniFile.GetString("frmComputers", "sSTAB4.TabPages(17)", "")

        frmComputers.gbNet.Text = objIniFile.GetString("frmComputers", "gbNet", "")
        frmComputers.gbExNet.Text = objIniFile.GetString("frmComputers", "gbExNet", "")
        frmComputers.Label27.Text = objIniFile.GetString("frmComputers", "Label27", "")
        frmComputers.Label23.Text = objIniFile.GetString("frmComputers", "Label23", "")
        frmComputers.Label13.Text = objIniFile.GetString("frmComputers", "Label13", "")
        frmComputers.Label26.Text = objIniFile.GetString("frmComputers", "Label26", "")
        frmComputers.Label12.Text = objIniFile.GetString("frmComputers", "Label12", "")
        frmComputers.Label25.Text = objIniFile.GetString("frmComputers", "Label25", "")
        frmComputers.Label15.Text = objIniFile.GetString("frmComputers", "Label15", "")
        frmComputers.Label11.Text = objIniFile.GetString("frmComputers", "Label11", "")
        frmComputers.Label24.Text = objIniFile.GetString("frmComputers", "Label24", "")
        frmComputers.Label14.Text = objIniFile.GetString("frmComputers", "Label14", "")

        Call INFO_P_LANG(frmComputers.Label32, frmComputers.Label31, frmComputers.Label30, frmComputers.Label29, frmComputers.Label28, frmComputers.Label86)

        frmComputers.gbNetPortMapping.Text = objIniFile.GetString("frmComputers", "gbNetPortMapping", "")
        frmComputers.Label35.Text = objIniFile.GetString("frmComputers", "Label35", "")
        frmComputers.Label34.Text = objIniFile.GetString("frmComputers", "Label34", "")
        frmComputers.Label33.Text = objIniFile.GetString("frmComputers", "Label33", "")


        Call NOTES_P_LANG(frmComputers.gbNETNotes, frmComputers.btnNETAdd, frmComputers.btnNETNotesDel, frmComputers.btnNETNotesCancel)
        frmComputers.gbNETRemont.Text = objIniFile.GetString("frmComputers", "gbRepair", "")

        Call GARANT_P_LANG(frmComputers.gbPostNET, frmComputers.Label39, frmComputers.Label38, frmComputers.Label37)
        Call SALE_P_LANG(frmComputers.gbSaleNet, frmComputers.Label60, frmComputers.Label59, frmComputers.Label58, frmComputers.chkNETspis, frmComputers.Label57, frmComputers.Label56, frmComputers.Label55, frmComputers.chkNETNNb)


        'Другое оборудование

        frmComputers.sSTAB3.TabPages("TabPage11").Text = objIniFile.GetString("frmComputers", "sSTAB3.TabPages(11)", "")
        frmComputers.sSTAB3.TabPages("TabPage22").Text = objIniFile.GetString("frmComputers", "sSTAB3.TabPages(22)", "")
        frmComputers.sSTAB3.TabPages("TabPage12").Text = objIniFile.GetString("frmComputers", "sSTAB3.TabPages(12)", "")
        frmComputers.sSTAB3.TabPages("TabPage18").Text = objIniFile.GetString("frmComputers", "sSTAB3.TabPages(18)", "")

        frmComputers.gbOTh.Text = objIniFile.GetString("frmComputers", "gbOTh", "")
        frmComputers.Label3.Text = objIniFile.GetString("frmComputers", "Label3", "")

        Call INFO_P_LANG(frmComputers.Label9, frmComputers.Label8, frmComputers.Label7, frmComputers.Label6, frmComputers.Label5, frmComputers.Label87)

        frmComputers.lblTipOther.Text = objIniFile.GetString("frmComputers", "lblTipOther", "")
        frmComputers.Label10.Text = objIniFile.GetString("frmComputers", "Label10", "")
        frmComputers.lblOTPCL.Text = objIniFile.GetString("frmComputers", "lblOTPCL", "")
        frmComputers.lblOtIp.Text = objIniFile.GetString("frmComputers", "lblOtIp", "")
        frmComputers.lblOTMac.Text = objIniFile.GetString("frmComputers", "lblOTMac", "")

        Call NOTES_P_LANG(frmComputers.gbOTHNotes, frmComputers.btnOTHAdd, frmComputers.btnOTHNotesDel, frmComputers.btnOTHNotesCancel)
        frmComputers.gbOTHRemont.Text = objIniFile.GetString("frmComputers", "gbRepair", "")

        Call GARANT_P_LANG(frmComputers.gbPostOTH, frmComputers.Label42, frmComputers.Label41, frmComputers.Label40)
        Call SALE_P_LANG(frmComputers.gbSaleOTH, frmComputers.Label66, frmComputers.Label65, frmComputers.Label64, frmComputers.chkOTHspis, frmComputers.Label63, frmComputers.Label62, frmComputers.Label61, frmComputers.chkOTHNNb)

        frmComputers.Label88.Text = objIniFile.GetString("frmComputers", "Label83", "")
        frmComputers.lblPCLNET.Text = objIniFile.GetString("frmComputers", "Label83", "")

        frmComputers.Label89.Text = objIniFile.GetString("frmComputers", "Label89", "")

        'EditService
        'DeleteService

        frmComputers.EditService.Text = objIniFile.GetString("frmComputers", "EditService", "")
        frmComputers.DeleteService.Text = objIniFile.GetString("frmComputers", "DeleteService", "")

        frmComputers.MnuSendEmail.Text = objIniFile.GetString("frmComputers", "MnuSendEmail", "")
        frmComputers.mnu_Z_to_Office.Text = objIniFile.GetString("frmComputers", "mnu_Z_to_Office", "")
        frmComputers.mnu_z_rasp.Text = objIniFile.GetString("frmComputers", "mnu_z_rasp", "")

        frmComputers.addServiseWork.Text = objIniFile.GetString("frmserviceDesc", "btnSBTAdd", "")

        Exit Sub

err_:
        MsgBox(Err.Description)
    End Sub

    Public Sub LANG_NOTES(ByVal lstGroups As ListView)

        Dim objIniFile As New IniFile(sLANGPATH)

        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstNOTES1", ""), 20, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstNOTES2", ""), 30, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstNOTES3", ""), 75, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstNOTES4", ""), 300, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstNOTES5", ""), 100, HorizontalAlignment.Left)

        'ResList(lstGroups)
    End Sub

    Private Sub LANG_MOVEMENT(ByVal lstGroup As ListView)
        Dim objIniFile As New IniFile(sLANGPATH)


        lstGroup.Columns.Add(objIniFile.GetString("frmComputers", "lstMOVEMENT1", ""), 20, HorizontalAlignment.Left)
        lstGroup.Columns.Add(objIniFile.GetString("frmComputers", "lstMOVEMENT2", ""), 100, HorizontalAlignment.Left)
        lstGroup.Columns.Add(objIniFile.GetString("frmComputers", "lstMOVEMENT3", ""), 100, HorizontalAlignment.Left)
        lstGroup.Columns.Add(objIniFile.GetString("frmComputers", "lstMOVEMENT4", ""), 300, HorizontalAlignment.Left)
        lstGroup.Columns.Add(objIniFile.GetString("frmComputers", "lstMOVEMENT5", ""), 50, HorizontalAlignment.Left)
        lstGroup.Columns.Add(objIniFile.GetString("frmComputers", "lstMOVEMENT6", ""), 50, HorizontalAlignment.Left)

    End Sub

    Public Sub LANG_REPAIR(ByVal lstGroups As ListView)
        Dim objIniFile As New IniFile(sLANGPATH)


        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont1", ""), 20, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont2", ""), 30, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont3", ""), 90, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont4", ""), 300, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont5", ""), 100, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont6", ""), 100, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont7", ""), 100, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont8", ""), 90, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont9", ""), 100, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstRemont10", ""), 30, HorizontalAlignment.Left)

        'ResList(lstGroups)

    End Sub

    Public Sub LANG_SOFT(ByVal lstGroups As ListView)
        Dim objIniFile As New IniFile(sLANGPATH)

        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT1", ""), 1, HorizontalAlignment.Left)

        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT9", ""), 20, HorizontalAlignment.Left)

        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT2", ""), 300, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT3", ""), 100, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT4", ""), 100, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT5", ""), 60, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT6", ""), 60, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT7", ""), 200, HorizontalAlignment.Left)
        lstGroups.Columns.Add(objIniFile.GetString("frmComputers", "lstSOFT8", ""), 100, HorizontalAlignment.Left)

        'ResList(lstGroups)

    End Sub

    Private Sub NOTES_P_LANG(ByVal gb As GroupBox, ByVal badd As Button, ByVal bdel As Button, ByVal bcancel As Button)
        Dim objIniFile As New IniFile(sLANGPATH)

        gb.Text = objIniFile.GetString("frmComputers", "gbNotes", "")
        badd.Text = objIniFile.GetString("frmComputers", "btnNotesAdd", "")
        bdel.Text = objIniFile.GetString("frmComputers", "btnNotesDel", "")
        bcancel.Text = objIniFile.GetString("frmComputers", "btnNotesCancel", "")

    End Sub

    Private Sub GARANT_P_LANG(ByVal gbS As GroupBox, ByVal lb1 As Label, ByVal lb2 As Label, ByVal lb3 As Label)
        Dim objIniFile As New IniFile(sLANGPATH)

        gbS.Text = objIniFile.GetString("frmComputers", "gbSeller", "")
        lb1.Text = objIniFile.GetString("frmComputers", "Label20", "")
        lb2.Text = objIniFile.GetString("frmComputers", "Label22", "")
        lb3.Text = objIniFile.GetString("frmComputers", "Label21", "")
    End Sub

    Private Sub SALE_P_LANG(ByVal gbS As GroupBox, ByVal lb1 As Label, ByVal lb2 As Label, ByVal lb3 As Label, ByVal chkS As CheckBox, ByVal lb4 As Label, ByVal lb5 As Label, ByVal lb6 As Label, ByVal chkN As CheckBox)
        Dim objIniFile As New IniFile(sLANGPATH)

        gbS.Text = objIniFile.GetString("frmComputers", "gbSale", "")
        lb1.Text = objIniFile.GetString("frmComputers", "Label43", "")
        lb2.Text = objIniFile.GetString("frmComputers", "Label44", "")
        lb3.Text = objIniFile.GetString("frmComputers", "Label45", "")
        chkS.Text = objIniFile.GetString("frmComputers", "chkPCspis", "")
        lb4.Text = objIniFile.GetString("frmComputers", "Label46", "")
        lb5.Text = objIniFile.GetString("frmComputers", "Label47", "")
        lb6.Text = objIniFile.GetString("frmComputers", "Label48", "")
        chkN.Text = objIniFile.GetString("frmComputers", "chkPCNNb", "")

    End Sub

    Private Sub INFO_P_LANG(ByVal lb1 As Label, ByVal lb2 As Label, ByVal lb3 As Label, ByVal lb4 As Label, ByVal lb5 As Label, ByVal lb6 As Label)
        Dim objIniFile As New IniFile(sLANGPATH)

        lb1.Text = objIniFile.GetString("frmComputers", "lblBranch", "")
        lb2.Text = objIniFile.GetString("frmComputers", "lblDepartment", "")
        lb3.Text = objIniFile.GetString("frmComputers", "lblOffice", "")
        lb4.Text = objIniFile.GetString("frmComputers", "lblResponsible", "")
        lb5.Text = objIniFile.GetString("frmComputers", "lblPhone", "")
        lb6.Text = objIniFile.GetString("frmComputers", "Label84", "")


    End Sub

    Public Sub frmLogin_Lang()


        'Dim langIni As New IniFile(LangPath)
        'frmLogin.lblSUBD.Text = langini.GetString("forms", "l1001", "")
        'frmLogin.lblBase.Text = langini.GetString("forms", "l1002", "")
        'frmLogin.lblUser.Text = langini.GetString("forms", "l1003", "")
        'frmLogin.lblPassword.Text = langini.GetString("forms", "l1004", "")

    End Sub

    Public Sub frmSoftware_Lang()

        LANG_SOFT(frmSoftware.lstSoftware)

        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmSoftware.Text = LNGIniFile.GetString("frmSoftware", "frmSoftware", "")

        frmSoftware.gbTree.Text = LNGIniFile.GetString("frmSoftware", "gbTree", "")

        frmSoftware.gbSoftware.Text = LNGIniFile.GetString("frmSoftware", "gbSoftware", "")
        frmSoftware.Label1.Text = LNGIniFile.GetString("frmSoftware", "Label1", "")
        frmSoftware.Label2.Text = LNGIniFile.GetString("frmSoftware", "Label2", "")
        frmSoftware.Label4.Text = LNGIniFile.GetString("frmSoftware", "Label4", "")
        frmSoftware.Label3.Text = LNGIniFile.GetString("frmSoftware", "Label3", "")
        frmSoftware.Label5.Text = LNGIniFile.GetString("frmSoftware", "Label5", "")
        frmSoftware.Label7.Text = LNGIniFile.GetString("frmSoftware", "Label7", "")
        frmSoftware.Label6.Text = LNGIniFile.GetString("frmSoftware", "Label6", "")
        frmSoftware.CheckBox1.Text = LNGIniFile.GetString("frmSoftware", "CheckBox1", "")
        frmSoftware.btnAdd.Text = LNGIniFile.GetString("frmSoftware", "btnAdd", "")
        frmSoftware.btnDelete.Text = LNGIniFile.GetString("frmSoftware", "btnDelete", "")
        frmSoftware.btnCancel.Text = LNGIniFile.GetString("frmSoftware", "btnCancel", "")


    End Sub

    Public Sub LANG_frmSQL()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmSQL.Text = LNGIniFile.GetString("frmSQL", "frmSQL", "")

        frmSQL.btnExecute.Text = LNGIniFile.GetString("frmSQL", "btnExecute", "")

        frmSQL.btnClear.Text = LNGIniFile.GetString("frmSQL", "btnClear", "")
        frmSQL.btnResSend.Text = LNGIniFile.GetString("frmSQL", "btnResSend", "")
        frmSQL.btnSave.Text = LNGIniFile.GetString("frmSQL", "btnSave", "")
        frmSQL.btnDelete.Text = LNGIniFile.GetString("frmSQL", "btnDelete", "")


    End Sub

    Public Sub LANG_frmTreb_Act_treb()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmTreb_Act_treb.Text = LNGIniFile.GetString("frmTreb_Act_treb", "frmTreb_Act_treb", "")

        frmTreb_Act_treb.Label1.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label1", "")
        frmTreb_Act_treb.Label2.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label2", "")
        frmTreb_Act_treb.Label3.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label3", "")
        frmTreb_Act_treb.Label4.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label4", "")
        frmTreb_Act_treb.Label5.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label5", "")
        frmTreb_Act_treb.Label6.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label6", "")
        frmTreb_Act_treb.Label7.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label7", "")
        frmTreb_Act_treb.Label8.Text = LNGIniFile.GetString("frmTreb_Act_treb", "Label8", "")


        frmTreb_Act_treb.cmdAdd.Text = LNGIniFile.GetString("frmTreb_Act_treb", "cmdAdd", "")
        frmTreb_Act_treb.cmdCancel.Text = LNGIniFile.GetString("frmTreb_Act_treb", "cmdCancel", "")



    End Sub


    Public Sub frmReports_LANG()
        Dim langIni As New IniFile(sLANGPATH)


        frmReports.lvReport2Cl.Columns.Add((langIni.GetString("frmReports", "lvReport2Cl1", "")), 300, HorizontalAlignment.Left)
        frmReports.lvReport2Cl.Columns.Add((langIni.GetString("frmReports", "lvReport2Cl2", "")), 100, HorizontalAlignment.Left)

        'ResList(frmReports.lvReport2Cl)

        'lvRemont
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont1", ""), 15, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont2", ""), 70, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont3", ""), 300, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont4", ""), 70, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont5", ""), 70, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont6", ""), 70, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont7", ""), 70, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont8", ""), 70, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont9", ""), 30, HorizontalAlignment.Left)
        frmReports.lvRemont.Columns.Add(langIni.GetString("frmReports", "lvRemont10", ""), 30, HorizontalAlignment.Left)
        'ResList(frmReports.lvRemont)

        frmReports.lvGar.Columns.Add(langIni.GetString("frmReports", "lvGar1", ""), 100, HorizontalAlignment.Left)
        frmReports.lvGar.Columns.Add(langIni.GetString("frmReports", "lvGar2", ""), 100, HorizontalAlignment.Left)
        frmReports.lvGar.Columns.Add(langIni.GetString("frmReports", "lvGar3", ""), 75, HorizontalAlignment.Left)
        frmReports.lvGar.Columns.Add(langIni.GetString("frmReports", "lvGar4", ""), 70, HorizontalAlignment.Left)
        frmReports.lvGar.Columns.Add(langIni.GetString("frmReports", "lvGar5", ""), 70, HorizontalAlignment.Left)

        'ResList(frmReports.lvGar)

        frmReports.lvOTV.Columns.Add(langIni.GetString("frmReports", "lvOTV1", ""), 250, HorizontalAlignment.Left)
        frmReports.lvOTV.Columns.Add(langIni.GetString("frmReports", "lvOTV2", ""), 100, HorizontalAlignment.Left)
        frmReports.lvOTV.Columns.Add(langIni.GetString("frmReports", "lvOTV3", ""), 100, HorizontalAlignment.Left)
        frmReports.lvOTV.Columns.Add(langIni.GetString("frmReports", "lvOTV4", ""), 200, HorizontalAlignment.Left)

        'ResList(frmReports.lvOTV)

        frmReports.lvCashe.Columns.Add(langIni.GetString("frmReports", "lvCashe1", ""), 350, HorizontalAlignment.Left)
        frmReports.lvCashe.Columns.Add(langIni.GetString("frmReports", "lvCashe2", ""), 150, HorizontalAlignment.Left)
        frmReports.lvCashe.Columns.Add(langIni.GetString("frmReports", "lvCashe3", ""), 75, HorizontalAlignment.Left)
        frmReports.lvCashe.Columns.Add(langIni.GetString("frmReports", "lvCashe4", ""), 200, HorizontalAlignment.Left)

        'ResList(frmReports.lvCashe)



        frmReports.Text = langIni.GetString("frmReports", "frmReports", "")

        frmReports.sSTAB1.TabPages("TabPage1").Text = langIni.GetString("frmReports", "TabPage1", "")
        frmReports.sSTAB1.TabPages("TabPage2").Text = langIni.GetString("frmReports", "TabPage2", "")
        frmReports.sSTAB1.TabPages("TabPage3").Text = langIni.GetString("frmReports", "TabPage3", "")
        frmReports.sSTAB1.TabPages("TabPage4").Text = langIni.GetString("frmReports", "TabPage4", "")
        frmReports.sSTAB1.TabPages("TabPage5").Text = langIni.GetString("frmReports", "TabPage5", "")
        frmReports.sSTAB1.TabPages("TabPage6").Text = langIni.GetString("frmReports", "TabPage6", "")

        frmReports.Label6.Text = langIni.GetString("frmReports", "Label6", "")
        frmReports.Label7.Text = langIni.GetString("frmReports", "Label7", "")
        frmReports.Label13.Text = langIni.GetString("frmReports", "Label13", "")
        frmReports.optPC.Text = langIni.GetString("frmReports", "optPC", "")
        frmReports.optOTH.Text = langIni.GetString("frmReports", "optOTH", "")
        frmReports.gbSN.Text = langIni.GetString("frmReports", "gbSN", "")
        frmReports.chk_K1.Text = langIni.GetString("frmReports", "chk_K1", "")
        frmReports.chk_K2.Text = langIni.GetString("frmReports", "chk_K2", "")
        frmReports.chk_K3.Text = langIni.GetString("frmReports", "chk_K3", "")
        frmReports.chk_K4.Text = langIni.GetString("frmReports", "chk_K4", "")
        frmReports.chk_K5.Text = langIni.GetString("frmReports", "chk_K5", "")
        frmReports.chk_K6.Text = langIni.GetString("frmReports", "chk_K6", "")
        frmReports.chk_K7.Text = langIni.GetString("frmReports", "chk_K7", "")
        frmReports.chk_K8.Text = langIni.GetString("frmReports", "chk_K8", "")
        frmReports.chk_K9.Text = langIni.GetString("frmReports", "chk_K9", "")
        frmReports.chk_K10.Text = langIni.GetString("frmReports", "chk_K10", "")
        frmReports.chk_K11.Text = langIni.GetString("frmReports", "chk_K11", "")
        frmReports.chk_K12.Text = langIni.GetString("frmReports", "chk_K12", "")
        frmReports.chk_K13.Text = langIni.GetString("frmReports", "chk_K13", "")
        frmReports.chk_K14.Text = langIni.GetString("frmReports", "chk_K14", "")
        frmReports.chk_K15.Text = langIni.GetString("frmReports", "chk_K15", "")
        frmReports.chk_K16.Text = langIni.GetString("frmReports", "chk_K16", "")
        frmReports.chk_K17.Text = langIni.GetString("frmReports", "chk_K17", "")
        frmReports.chk_K18.Text = langIni.GetString("frmReports", "chk_K18", "")
        frmReports.chk_K19.Text = langIni.GetString("frmReports", "chk_K19", "")
        frmReports.chk_K20.Text = langIni.GetString("frmReports", "chk_K20", "")
        frmReports.chk_K21.Text = langIni.GetString("frmReports", "chk_K21", "")
        frmReports.chk_K22.Text = langIni.GetString("frmReports", "chk_K22", "")
        frmReports.chk_K23.Text = langIni.GetString("frmReports", "chk_K23", "")
        frmReports.chk_K24.Text = langIni.GetString("frmReports", "chk_K24", "")
        frmReports.chk_K25.Text = langIni.GetString("frmReports", "chk_K25", "")
        frmReports.chk_K26.Text = langIni.GetString("frmReports", "chk_K26", "")
        frmReports.chk_K27.Text = langIni.GetString("frmReports", "chk_K27", "")
        frmReports.chk_K28.Text = langIni.GetString("frmReports", "chk_K28", "")

        frmReports.gbPer.Text = langIni.GetString("frmReports", "gbPer", "")
        frmReports.chk_K29.Text = langIni.GetString("frmReports", "chk_K29", "")
        frmReports.chk_K30.Text = langIni.GetString("frmReports", "chk_K30", "")
        frmReports.chk_K31.Text = langIni.GetString("frmReports", "chk_K31", "")
        frmReports.chk_K32.Text = langIni.GetString("frmReports", "chk_K32", "")
        frmReports.chk_K33.Text = langIni.GetString("frmReports", "chk_K33", "")
        frmReports.chk_K34.Text = langIni.GetString("frmReports", "chk_K34", "")
        frmReports.chk_K35.Text = langIni.GetString("frmReports", "chk_K35", "")
        frmReports.chk_K36.Text = langIni.GetString("frmReports", "chk_K36", "")
        frmReports.chk_K37.Text = langIni.GetString("frmReports", "chk_K37", "")
        frmReports.chk_K38.Text = langIni.GetString("frmReports", "chk_K38", "")
        frmReports.chk_K39.Text = langIni.GetString("frmReports", "chk_K39", "")

        frmReports.gbInf.Text = langIni.GetString("frmReports", "gbInf", "")
        frmReports.chk_K40.Text = langIni.GetString("frmReports", "chk_K40", "")
        frmReports.chk_K41.Text = langIni.GetString("frmReports", "chk_K41", "")
        frmReports.chk_K42.Text = langIni.GetString("frmReports", "chk_K42", "")
        frmReports.chk_K43.Text = langIni.GetString("frmReports", "chk_K43", "")
        frmReports.chk_K44.Text = langIni.GetString("frmReports", "chk_K44", "")
        frmReports.chk_K45.Text = langIni.GetString("frmReports", "chk_K45", "")
        frmReports.chk_K46.Text = langIni.GetString("frmReports", "chk_K46", "")
        frmReports.chk_K47.Text = langIni.GetString("frmReports", "chk_K47", "")
        frmReports.chk_K48.Text = langIni.GetString("frmReports", "chk_K48", "")
        frmReports.chk_K49.Text = langIni.GetString("frmReports", "chk_K49", "")
        frmReports.chk_K50.Text = langIni.GetString("frmReports", "chk_K50", "")
        frmReports.chk_K51.Text = langIni.GetString("frmReports", "chk_K51", "")
        frmReports.chk_K52.Text = langIni.GetString("frmReports", "chk_K52", "")

        frmReports.btnUpdate.Text = langIni.GetString("frmReports", "btnUpdate", "")
        frmReports.btnSendToOffice.Text = langIni.GetString("frmReports", "btnSendToOffice", "")


        frmReports.lblReport2Cl.Text = langIni.GetString("frmReports", "lblReport2Cl", "")

        frmReports.Label1.Text = langIni.GetString("frmReports", "Label1", "")
        frmReports.Label2.Text = langIni.GetString("frmReports", "Label2", "")
        frmReports.Button1.Text = langIni.GetString("frmReports", "Button1", "")
        frmReports.Button2.Text = langIni.GetString("frmReports", "Button2", "")
        frmReports.chkReport2Prn.Text = langIni.GetString("frmReports", "chkReport2Prn", "")

        frmReports.Label3.Text = langIni.GetString("frmReports", "Label3", "")
        frmReports.btnRefresh.Text = langIni.GetString("frmReports", "btnRefresh", "")
        frmReports.Button3.Text = langIni.GetString("frmReports", "Button3", "")

        frmReports.chkFltr.Text = langIni.GetString("frmReports", "chkFltr", "")
        frmReports.Label4.Text = langIni.GetString("frmReports", "Label4", "")
        frmReports.Label5.Text = langIni.GetString("frmReports", "Label5", "")
        frmReports.chkUroven.Text = langIni.GetString("frmReports", "chkUroven", "")
        frmReports.ChckVip.Text = langIni.GetString("frmReports", "ChckVip", "")

        frmReports.chkNZ.Text = langIni.GetString("frmReports", "chkNZ", "")
        frmReports.Label8.Text = langIni.GetString("frmReports", "Label8", "")
        frmReports.Label9.Text = langIni.GetString("frmReports", "Label9", "")
        frmReports.btnCRZakSendOff.Text = langIni.GetString("frmReports", "btnCRZakSendOff", "")
        frmReports.Label12.Text = langIni.GetString("frmReports", "Label12", "")


        frmReports.Label11.Text = langIni.GetString("frmReports", "Label11", "")
        frmReports.Label10.Text = langIni.GetString("frmReports", "Label10", "")
        frmReports.btnCashe.Text = langIni.GetString("frmReports", "btnCashe", "")
        frmReports.btnCacheOff.Text = langIni.GetString("frmReports", "btnCacheOff", "")



        'frmReports.lvCRT.Columns.Add("Модель", 100, HorizontalAlignment.Left)
        'frmReports.lvCRT.Columns.Add("Установлен\Не установлен", 70, HorizontalAlignment.Left)
        'frmReports.lvCRT.Columns.Add("Заправок", 70, HorizontalAlignment.Left)
        'frmReports.lvCRT.Columns.Add("Востановлен", 70, HorizontalAlignment.Left)
        'frmReports.lvCRT.Columns.Add("Затраты", 70, HorizontalAlignment.Left)

        'ResList(frmReports.lvCRT)

    End Sub

    Public Sub frmAct_treb_LANG()
        Dim objIniFile As New IniFile(sLANGPATH)


        frmAct_Treb.lvACTSP.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvACTSP1", ""), 20, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP2", "")), 70, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP3", "")), 75, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP4", "")), 100, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP5", "")), 100, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP6", "")), 75, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP7", "")), 75, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP8", "")), 75, HorizontalAlignment.Left)
        frmAct_Treb.lvACTSP.Columns.Add((objIniFile.GetString("frmAct_Treb", "lvACTSP9", "")), 75, HorizontalAlignment.Left)


        frmAct_Treb.lvACTVV.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvACTVV1", ""), 20, HorizontalAlignment.Left)
        frmAct_Treb.lvACTVV.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvACTVV2", ""), 70, HorizontalAlignment.Left)
        frmAct_Treb.lvACTVV.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvACTVV3", ""), 70, HorizontalAlignment.Left)
        frmAct_Treb.lvACTVV.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvACTVV4", ""), 75, HorizontalAlignment.Left)
        frmAct_Treb.lvACTVV.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvACTVV5", ""), 100, HorizontalAlignment.Left)
        frmAct_Treb.lvACTVV.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvACTVV6", ""), 100, HorizontalAlignment.Left)


        frmAct_Treb.lvTREB.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvTREB1", ""), 20, HorizontalAlignment.Left)
        frmAct_Treb.lvTREB.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvTREB2", ""), 70, HorizontalAlignment.Left)
        frmAct_Treb.lvTREB.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvTREB3", ""), 70, HorizontalAlignment.Left)
        frmAct_Treb.lvTREB.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvTREB4", ""), 75, HorizontalAlignment.Left)
        frmAct_Treb.lvTREB.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvTREB5", ""), 100, HorizontalAlignment.Left)
        frmAct_Treb.lvTREB.Columns.Add(objIniFile.GetString("frmAct_Treb", "lvTREB6", ""), 100, HorizontalAlignment.Left)

        frmAct_Treb.Text = objIniFile.GetString("frmAct_Treb", "frmAct_Treb", "")
        frmAct_Treb.TabControl1.TabPages("TabPage1").Text = objIniFile.GetString("frmAct_Treb", "TabPage1", "")
        frmAct_Treb.TabControl1.TabPages("TabPage2").Text = objIniFile.GetString("frmAct_Treb", "TabPage2", "")
        frmAct_Treb.TabControl1.TabPages("TabPage3").Text = objIniFile.GetString("frmAct_Treb", "TabPage3", "")

        frmAct_Treb.btnAVOSadd.Text = objIniFile.GetString("frmAct_Treb", "btnAVOSadd", "")
        frmAct_Treb.btnAVOSdel.Text = objIniFile.GetString("frmAct_Treb", "btnAVOSdel", "")
        frmAct_Treb.btnAVOSofsend.Text = objIniFile.GetString("frmAct_Treb", "btnAVOSofsend", "")


        frmAct_Treb.btnTRadd.Text = objIniFile.GetString("frmAct_Treb", "btnTRadd", "")
        frmAct_Treb.btnTRdel.Text = objIniFile.GetString("frmAct_Treb", "btnTRdel", "")
        frmAct_Treb.btnTRofSend.Text = objIniFile.GetString("frmAct_Treb", "btnTRofSend", "")

        frmAct_Treb.btnASPadd.Text = objIniFile.GetString("frmAct_Treb", "btnASPadd", "")
        frmAct_Treb.btnASPdel.Text = objIniFile.GetString("frmAct_Treb", "btnASPdel", "")
        frmAct_Treb.btnASPofsend.Text = objIniFile.GetString("frmAct_Treb", "btnASPofsend", "")

        'frmAct_Treb

    End Sub

    Public Sub frmSheduler_LANG()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmSheduler.Text = LNGIniFile.GetString("frmSheduler", "frmSheduler", "")



        frmSheduler.lstShed.Columns.Add(LNGIniFile.GetString("frmSheduler", "lstShed1", ""), 15, HorizontalAlignment.Left)
        frmSheduler.lstShed.Columns.Add(LNGIniFile.GetString("frmSheduler", "lstShed2", ""), 70, HorizontalAlignment.Left)
        frmSheduler.lstShed.Columns.Add(LNGIniFile.GetString("frmSheduler", "lstShed3", ""), 300, HorizontalAlignment.Left)
        frmSheduler.lstShed.Columns.Add(LNGIniFile.GetString("frmSheduler", "lstShed4", ""), 70, HorizontalAlignment.Left)



        frmSheduler.Label1.Text = LNGIniFile.GetString("frmSheduler", "Label1", "")
        frmSheduler.Label2.Text = LNGIniFile.GetString("frmSheduler", "Label2", "")
        frmSheduler.btnAdd.Text = LNGIniFile.GetString("frmSheduler", "btnAdd", "")
        frmSheduler.btnDel.Text = LNGIniFile.GetString("frmSheduler", "btnDel", "")
        frmSheduler.btnClear.Text = LNGIniFile.GetString("frmSheduler", "btnClear", "")
        frmSheduler.btnAll.Text = LNGIniFile.GetString("frmSheduler", "btnAll", "")


    End Sub

    Public Sub LANG_frm_os3()
        Dim objIniFile As New IniFile(sLANGPATH)


        frm_os3.Label1.Text = objIniFile.GetString("frm_os3", "Label1", "")
        frm_os3.Label2.Text = objIniFile.GetString("frm_os3", "Label2", "")
        frm_os3.Label3.Text = objIniFile.GetString("frm_os3", "Label3", "")
        frm_os3.Label4.Text = objIniFile.GetString("frm_os3", "Label4", "")
        frm_os3.Label5.Text = objIniFile.GetString("frm_os3", "Label5", "")
        frm_os3.Label6.Text = objIniFile.GetString("frm_os3", "Label6", "")
        frm_os3.Label7.Text = objIniFile.GetString("frm_os3", "Label7", "")
        frm_os3.Label8.Text = objIniFile.GetString("frm_os3", "Label8", "")
        frm_os3.Label9.Text = objIniFile.GetString("frm_os3", "Label9", "")
        frm_os3.Label10.Text = objIniFile.GetString("frm_os3", "Label10", "")
        frm_os3.Button1.Text = objIniFile.GetString("frm_os3", "Button1", "")
        frm_os3.Button2.Text = objIniFile.GetString("frm_os3", "Button2", "")
        frm_os3.Text = objIniFile.GetString("frm_os3", "frm_os3", "") 'frm_os3





    End Sub

    Public Sub LANG_frm_wmi()

        Dim objIniFile As New IniFile(sLANGPATH)

        frm_wmi.Label1.Text = objIniFile.GetString("frm_wmi", "Label1", "")
        frm_wmi.Label2.Text = objIniFile.GetString("frm_wmi", "Label2", "")
        frm_wmi.Label3.Text = objIniFile.GetString("frm_wmi", "Label3", "")
        frm_wmi.Label4.Text = objIniFile.GetString("frm_wmi", "Label4", "")

        frm_wmi.Button1.Text = objIniFile.GetString("frm_wmi", "Button1", "")
        frm_wmi.Button2.Text = objIniFile.GetString("frm_wmi", "Button2", "")
        frm_wmi.Text = objIniFile.GetString("frm_wmi", "frm_wmi", "")

    End Sub

    Public Sub LANG_frmACT_OS_Act_treb()
        Dim objIniFile As New IniFile(sLANGPATH)

        frmACT_OS_Act_treb.Text = objIniFile.GetString("frmACT_OS_Act_treb", "frmACT_OS_Act_treb", "")
        frmACT_OS_Act_treb.Label1.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label1", "")
        frmACT_OS_Act_treb.Label2.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label2", "")
        frmACT_OS_Act_treb.Label3.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label3", "")
        frmACT_OS_Act_treb.Label4.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label4", "")
        frmACT_OS_Act_treb.Label5.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label5", "")
        frmACT_OS_Act_treb.Label6.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label6", "")
        frmACT_OS_Act_treb.Label7.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label7", "")
        frmACT_OS_Act_treb.Label8.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label8", "")
        frmACT_OS_Act_treb.Label9.Text = objIniFile.GetString("frmACT_OS_Act_treb", "Label9", "")

        frmACT_OS_Act_treb.akt_add.Text = objIniFile.GetString("frmACT_OS_Act_treb", "akt_add", "")
        frmACT_OS_Act_treb.akt_cancel.Text = objIniFile.GetString("frmACT_OS_Act_treb", "akt_cancel", "")


    End Sub

    Public Sub LANG_frmGAR_CPL()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmGarCPL.Text = LNGIniFile.GetString("frmGarCPL", "frmGarCPL", "")
        frmGarCPL.gbcpu.Text = LNGIniFile.GetString("frmGarCPL", "gbcpu", "")
        frmGarCPL.gbPost.Text = LNGIniFile.GetString("frmGarCPL", "gbPost", "")
        frmGarCPL.Label4.Text = LNGIniFile.GetString("frmGarCPL", "Label4", "")
        frmGarCPL.Label2.Text = LNGIniFile.GetString("frmGarCPL", "Label2", "")
        frmGarCPL.Label1.Text = LNGIniFile.GetString("frmGarCPL", "Label1", "")
        frmGarCPL.btnAdd.Text = LNGIniFile.GetString("frmGarCPL", "btnAdd", "")
        frmGarCPL.btnCancel.Text = LNGIniFile.GetString("frmGarCPL", "btnCancel", "")


    End Sub

    Public Sub LANG_frmLOG()
        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmLOG.Text = LNGIniFile.GetString("frmLOG", "frmLOG", "")
        frmLOG.RBPrLog.Text = LNGIniFile.GetString("frmLOG", "RBPrLog", "")
        frmLOG.rbMove.Text = LNGIniFile.GetString("frmLOG", "rbMove", "")
        frmLOG.rbUpdate.Text = LNGIniFile.GetString("frmLOG", "rbUpdate", "")
        frmLOG.Label1.Text = LNGIniFile.GetString("frmLOG", "Label1", "")
        frmLOG.Label2.Text = LNGIniFile.GetString("frmLOG", "Label2", "")
        frmLOG.btnUpdate.Text = LNGIniFile.GetString("frmLOG", "btnUpdate", "")

    End Sub

    Public Sub LANG_frmLogin()

        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmLogin.Text = LNGIniFile.GetString("frmLogin", "frmLogin", "")
        frmLogin.lblSUBD.Text = LNGIniFile.GetString("frmLogin", "lblSUBD", "")
        frmLogin.gbsql.Text = LNGIniFile.GetString("frmLogin", "gbsql", "")
        frmLogin.lblServer.Text = LNGIniFile.GetString("frmLogin", "lblServer", "")
        frmLogin.Label1.Text = LNGIniFile.GetString("frmLogin", "Label1", "")
        frmLogin.Label2.Text = LNGIniFile.GetString("frmLogin", "Label2", "")
        frmLogin.Label3.Text = LNGIniFile.GetString("frmLogin", "Label3", "")
        frmLogin.Label4.Text = LNGIniFile.GetString("frmLogin", "Label4", "")
        frmLogin.Button1.Text = LNGIniFile.GetString("frmLogin", "Button1", "")
        frmLogin.gbData.Text = LNGIniFile.GetString("frmLogin", "gbData", "")
        frmLogin.lblBase.Text = LNGIniFile.GetString("frmLogin", "lblBase", "")
        frmLogin.lblUser.Text = LNGIniFile.GetString("frmLogin", "lblUser", "")
        frmLogin.lblPassword.Text = LNGIniFile.GetString("frmLogin", "lblPassword", "")
        frmLogin.Label5.Text = LNGIniFile.GetString("frmLogin", "Label5", "")

        frmLogin.btnLogin.Text = LNGIniFile.GetString("frmLogin", "btnLogin", "")
        frmLogin.btnCancel.Text = LNGIniFile.GetString("frmLogin", "btnCancel", "")



    End Sub

    Public Sub LANG_frmMain()


        Dim LNGIniFile As New IniFile(sLANGPATH)

        'frmMain.Text = LNGIniFile.GetString("frmMain", "frmMain", "")
        frmMain.FileMenu.Text = LNGIniFile.GetString("frmMain", "FileMenu", "")
        frmMain.NewToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "NewToolStripMenuItem", "")
        frmMain.ПроверитьОбновлениеToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "1", "")
        frmMain.MailToAuthors.Text = LNGIniFile.GetString("frmMain", "MailToAuthors", "")
        frmMain.ФорумToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "2", "")
        frmMain.BugTrackerToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "BugTrackerToolStripMenuItem", "")

        'frmMain.BugMaiSend.Text = LNGIniFile.GetString("frmMain", "BugTrackerToolStripMenuItem", "")
        'BugMaiSend


        frmMain.ExitToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "ExitToolStripMenuItem", "")
        frmMain.УчётToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "3", "")
        frmMain.FrmComputersMenuItem.Text = LNGIniFile.GetString("frmMain", "FrmComputersMenuItem", "")
        frmMain.УчётЗаявокремонтовToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "4", "")
        frmMain.УчётКартриджейToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "5", "")
        frmMain.УчётПрограммногоОбеспеченияToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "6", "")
        frmMain.СкладToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "7", "")
        frmMain.СправочникиToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "8", "")
        frmMain.СправочникиОборудованияToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "9", "")
        frmMain.ОрганизацияToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "10", "")
        frmMain.ОтчётыToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "11", "")
        frmMain.БланкиToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "12", "")
        frmMain.ПаспортКомпьютераToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "13", "")
        frmMain.ПаспортМФУToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "14", "")
        frmMain.ПаспортСетевогоОборудованияToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "15", "")
        frmMain.ПаспортПринтераToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "16", "")
        frmMain.ПаспортКопираToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "17", "")
        frmMain.ПаспортСканераToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "18", "")
        frmMain.МойБланкToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "19", "")
        frmMain.ЖурналыПрограммыToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "20", "")
        frmMain.АктытребованияToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "21", "")
        frmMain.ToolsMenu.Text = LNGIniFile.GetString("frmMain", "ToolsMenu", "")
        frmMain.OptionsToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "OptionsToolStripMenuItem", "")
        frmMain.ОбслуживаниеБДToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "22", "")
        frmMain.CompareDBToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "CompareDBToolStripMenuItem", "")
        frmMain.ЗапросыToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "23", "")
        frmMain.CleerDBToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "CleerDBToolStripMenuItem", "")
        frmMain.QRCodeTestingToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "QRCodeTestingToolStripMenuItem", "")
        frmMain.ViewMenu.Text = LNGIniFile.GetString("frmMain", "ViewMenu", "")
        frmMain.ToolBarToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "ToolBarToolStripMenuItem", "")
        frmMain.StatusBarToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "StatusBarToolStripMenuItem", "")
        frmMain.LabelPanelToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "LabelPanelToolStripMenuItem", "")
        frmMain.WindowsMenu.Text = LNGIniFile.GetString("frmMain", "WindowsMenu", "")
        frmMain.CascadeToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "CascadeToolStripMenuItem", "")
        frmMain.TileVerticalToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "TileVerticalToolStripMenuItem", "")
        frmMain.TileHorizontalToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "TileHorizontalToolStripMenuItem", "")
        frmMain.CloseAllToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "CloseAllToolStripMenuItem", "")
        frmMain.ArrangeIconsToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "ArrangeIconsToolStripMenuItem", "")
        frmMain.HelpMenu.Text = LNGIniFile.GetString("frmMain", "HelpMenu", "")
        frmMain.ToolStripDropDownButton1.Text = LNGIniFile.GetString("frmMain", "ToolStripDropDownButton1", "")
        frmMain.ЗагрузитьИзEverestiniToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "24", "")
        frmMain.ЗагрузитьИзASTRA32ToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "25", "")
        frmMain.ЗагрузитьЧерезWMIToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "26", "")
        frmMain.ЗагрузитьИзCSVEverestToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "27", "")
        frmMain.HANDINSERTToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "HANDINSERTToolStripMenuItem", "")
        frmMain.КопирToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "28", "")
        frmMain.ПринтерToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "29", "")
        frmMain.МФУToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "30", "")
        frmMain.СетевоеОборудованиеToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "31", "")
        frmMain.ТелефонToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "32", "")
        frmMain.ФотоаппаратToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "33", "")
        frmMain.ФаксToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "34", "")
        frmMain.МониторToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "35", "")
        frmMain.ДисководZIPToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "36", "")
        frmMain.СканерToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "37", "")
        frmMain.ДругоеОборудованиеToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "38", "")
        frmMain.NewToolStripButton.Text = LNGIniFile.GetString("frmMain", "NewToolStripButton", "")
        frmMain.SaveInfTehButton.Text = LNGIniFile.GetString("frmMain", "SaveInfTehButton", "")
        frmMain.ArhToolZipbutton.Text = LNGIniFile.GetString("frmMain", "ArhToolZipbutton", "")
        frmMain.ToolStripButton1.Text = LNGIniFile.GetString("frmMain", "ToolStripButton1", "")
        frmMain.lblShed.Text = LNGIniFile.GetString("frmMain", "lblShed", "")
        frmMain.lblRem.Text = LNGIniFile.GetString("frmMain", "lblRem", "")

        frmMain.USBУстройстваToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "39", "")
        frmMain.АккустическиеСистемыToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "40", "")
        frmMain.БесперебойникиToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "41", "")
        frmMain.ПерефирийныеУстройстваToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "42", "")

        frmMain.ИнвентаризацияToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "43", "")


        frmMain.КлавиатураToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "44", "")
        frmMain.МышьToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "45", "")
        frmMain.СетевыеФильтрыToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "46", "")
        frmMain.СтатистическиеОтчетыToolStripMenuItem.Text = LNGIniFile.GetString("frmMain", "47", "")

        frmMain.netMagmnu.Text = LNGIniFile.GetString("frmMain", "netMagmnu", "")
        'netMagmnu

        'СетевыеФильтрыToolStripMenuItem
        'КлавиатураToolStripMenuItem
        'МышьToolStripMenuItem

    End Sub
End Module
