<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCartr_ADD
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblRealNumber = New System.Windows.Forms.Label
        Me.txtSerNumb = New System.Windows.Forms.TextBox
        Me.cmbProizv = New System.Windows.Forms.ComboBox
        Me.cmbTipC = New System.Windows.Forms.ComboBox
        Me.cmbModC = New System.Windows.Forms.ComboBox
        Me.cmbSostUstr = New System.Windows.Forms.ComboBox
        Me.cmbSaler = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSaleNumb = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtSale = New System.Windows.Forms.DateTimePicker
        Me.txtMemo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.chkNezap = New System.Windows.Forms.CheckBox
        Me.chkNZ = New System.Windows.Forms.CheckBox
        Me.chkIznos = New System.Windows.Forms.CheckBox
        Me.chkSPS = New System.Windows.Forms.CheckBox
        Me.chkNaSP = New System.Windows.Forms.CheckBox
        Me.txtCashe = New System.Windows.Forms.NumericUpDown
        CType(Me.txtCashe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "№"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Серийный номер:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Производитель:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Тип картриджа:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Модель:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(13, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "В составе устройства:"
        '
        'lblRealNumber
        '
        Me.lblRealNumber.AutoSize = True
        Me.lblRealNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRealNumber.Location = New System.Drawing.Point(140, 13)
        Me.lblRealNumber.Name = "lblRealNumber"
        Me.lblRealNumber.Size = New System.Drawing.Size(2, 15)
        Me.lblRealNumber.TabIndex = 6
        '
        'txtSerNumb
        '
        Me.txtSerNumb.Location = New System.Drawing.Point(140, 37)
        Me.txtSerNumb.Name = "txtSerNumb"
        Me.txtSerNumb.Size = New System.Drawing.Size(221, 20)
        Me.txtSerNumb.TabIndex = 7
        '
        'cmbProizv
        '
        Me.cmbProizv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbProizv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProizv.FormattingEnabled = True
        Me.cmbProizv.Location = New System.Drawing.Point(140, 65)
        Me.cmbProizv.Name = "cmbProizv"
        Me.cmbProizv.Size = New System.Drawing.Size(221, 21)
        Me.cmbProizv.TabIndex = 8
        '
        'cmbTipC
        '
        Me.cmbTipC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbTipC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipC.FormattingEnabled = True
        Me.cmbTipC.Location = New System.Drawing.Point(140, 92)
        Me.cmbTipC.Name = "cmbTipC"
        Me.cmbTipC.Size = New System.Drawing.Size(221, 21)
        Me.cmbTipC.TabIndex = 9
        '
        'cmbModC
        '
        Me.cmbModC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbModC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbModC.FormattingEnabled = True
        Me.cmbModC.Location = New System.Drawing.Point(140, 119)
        Me.cmbModC.Name = "cmbModC"
        Me.cmbModC.Size = New System.Drawing.Size(221, 21)
        Me.cmbModC.TabIndex = 10
        '
        'cmbSostUstr
        '
        Me.cmbSostUstr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSostUstr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSostUstr.Enabled = False
        Me.cmbSostUstr.FormattingEnabled = True
        Me.cmbSostUstr.Location = New System.Drawing.Point(140, 146)
        Me.cmbSostUstr.Name = "cmbSostUstr"
        Me.cmbSostUstr.Size = New System.Drawing.Size(221, 21)
        Me.cmbSostUstr.TabIndex = 11
        '
        'cmbSaler
        '
        Me.cmbSaler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSaler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSaler.FormattingEnabled = True
        Me.cmbSaler.Location = New System.Drawing.Point(140, 173)
        Me.cmbSaler.Name = "cmbSaler"
        Me.cmbSaler.Size = New System.Drawing.Size(221, 21)
        Me.cmbSaler.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Продавец:"
        '
        'txtSaleNumb
        '
        Me.txtSaleNumb.Location = New System.Drawing.Point(140, 200)
        Me.txtSaleNumb.Name = "txtSaleNumb"
        Me.txtSaleNumb.Size = New System.Drawing.Size(146, 20)
        Me.txtSaleNumb.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Счёт фактура:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Цена:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 255)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Дата приобретения:"
        '
        'dtSale
        '
        Me.dtSale.Location = New System.Drawing.Point(140, 255)
        Me.dtSale.Name = "dtSale"
        Me.dtSale.Size = New System.Drawing.Size(146, 20)
        Me.dtSale.TabIndex = 19
        Me.dtSale.Value = New Date(2010, 4, 1, 0, 0, 0, 0)
        '
        'txtMemo
        '
        Me.txtMemo.Location = New System.Drawing.Point(16, 349)
        Me.txtMemo.Multiline = True
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemo.Size = New System.Drawing.Size(345, 113)
        Me.txtMemo.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 333)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Примечания:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(16, 469)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 22
        Me.btnAdd.Text = "Добавить"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(97, 469)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Отмена"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkNezap
        '
        Me.chkNezap.AutoSize = True
        Me.chkNezap.Location = New System.Drawing.Point(16, 288)
        Me.chkNezap.Name = "chkNezap"
        Me.chkNezap.Size = New System.Drawing.Size(119, 17)
        Me.chkNezap.TabIndex = 24
        Me.chkNezap.Text = "Не заправляемый"
        Me.chkNezap.UseVisualStyleBackColor = True
        '
        'chkNZ
        '
        Me.chkNZ.AutoSize = True
        Me.chkNZ.Location = New System.Drawing.Point(141, 288)
        Me.chkNZ.Name = "chkNZ"
        Me.chkNZ.Size = New System.Drawing.Size(97, 17)
        Me.chkNZ.TabIndex = 25
        Me.chkNZ.Text = "Не заправлен"
        Me.chkNZ.UseVisualStyleBackColor = True
        '
        'chkIznos
        '
        Me.chkIznos.AutoSize = True
        Me.chkIznos.Location = New System.Drawing.Point(244, 288)
        Me.chkIznos.Name = "chkIznos"
        Me.chkIznos.Size = New System.Drawing.Size(72, 17)
        Me.chkIznos.TabIndex = 26
        Me.chkIznos.Text = "Изношен"
        Me.chkIznos.UseVisualStyleBackColor = True
        '
        'chkSPS
        '
        Me.chkSPS.AutoSize = True
        Me.chkSPS.Location = New System.Drawing.Point(16, 311)
        Me.chkSPS.Name = "chkSPS"
        Me.chkSPS.Size = New System.Drawing.Size(63, 17)
        Me.chkSPS.TabIndex = 27
        Me.chkSPS.Text = "Списан"
        Me.chkSPS.UseVisualStyleBackColor = True
        '
        'chkNaSP
        '
        Me.chkNaSP.AutoSize = True
        Me.chkNaSP.Location = New System.Drawing.Point(140, 311)
        Me.chkNaSP.Name = "chkNaSP"
        Me.chkNaSP.Size = New System.Drawing.Size(91, 17)
        Me.chkNaSP.TabIndex = 28
        Me.chkNaSP.Text = "На списание"
        Me.chkNaSP.UseVisualStyleBackColor = True
        '
        'txtCashe
        '
        Me.txtCashe.Location = New System.Drawing.Point(141, 229)
        Me.txtCashe.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.txtCashe.Name = "txtCashe"
        Me.txtCashe.Size = New System.Drawing.Size(145, 20)
        Me.txtCashe.TabIndex = 29
        '
        'frmCartr_ADD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 503)
        Me.Controls.Add(Me.txtCashe)
        Me.Controls.Add(Me.chkNaSP)
        Me.Controls.Add(Me.chkSPS)
        Me.Controls.Add(Me.chkIznos)
        Me.Controls.Add(Me.chkNZ)
        Me.Controls.Add(Me.chkNezap)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.dtSale)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSaleNumb)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbSaler)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbSostUstr)
        Me.Controls.Add(Me.cmbModC)
        Me.Controls.Add(Me.cmbTipC)
        Me.Controls.Add(Me.cmbProizv)
        Me.Controls.Add(Me.txtSerNumb)
        Me.Controls.Add(Me.lblRealNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCartr_ADD"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Добавление (Редактирование) картриджа"
        CType(Me.txtCashe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblRealNumber As System.Windows.Forms.Label
    Friend WithEvents txtSerNumb As System.Windows.Forms.TextBox
    Friend WithEvents cmbProizv As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipC As System.Windows.Forms.ComboBox
    Friend WithEvents cmbModC As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSostUstr As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSaler As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSaleNumb As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtSale As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkNezap As System.Windows.Forms.CheckBox
    Friend WithEvents chkNZ As System.Windows.Forms.CheckBox
    Friend WithEvents chkIznos As System.Windows.Forms.CheckBox
    Friend WithEvents chkSPS As System.Windows.Forms.CheckBox
    Friend WithEvents chkNaSP As System.Windows.Forms.CheckBox
    Friend WithEvents txtCashe As System.Windows.Forms.NumericUpDown
End Class
