<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmService_add
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
        Me.cmbCancel = New System.Windows.Forms.Button()
        Me.cmbAdd = New System.Windows.Forms.Button()
        Me.txtComent = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkClose = New System.Windows.Forms.CheckBox()
        Me.cmbTip = New System.Windows.Forms.ComboBox()
        Me.cmbKrit = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbOtv = New System.Windows.Forms.ComboBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRem = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHead = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtIsp = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtReg = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMast = New System.Windows.Forms.ComboBox()
        Me.cmbIst = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RemCashe = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.RemCashe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCancel
        '
        Me.cmbCancel.Location = New System.Drawing.Point(132, 532)
        Me.cmbCancel.Name = "cmbCancel"
        Me.cmbCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmbCancel.TabIndex = 54
        Me.cmbCancel.Text = "Отмена"
        Me.cmbCancel.UseVisualStyleBackColor = True
        '
        'cmbAdd
        '
        Me.cmbAdd.Location = New System.Drawing.Point(15, 532)
        Me.cmbAdd.Name = "cmbAdd"
        Me.cmbAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmbAdd.TabIndex = 53
        Me.cmbAdd.Text = "Добавить"
        Me.cmbAdd.UseVisualStyleBackColor = True
        '
        'txtComent
        '
        Me.txtComent.Location = New System.Drawing.Point(9, 438)
        Me.txtComent.Multiline = True
        Me.txtComent.Name = "txtComent"
        Me.txtComent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComent.Size = New System.Drawing.Size(426, 87)
        Me.txtComent.TabIndex = 52
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 422)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 13)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Действительный характер:"
        '
        'chkClose
        '
        Me.chkClose.AutoSize = True
        Me.chkClose.Location = New System.Drawing.Point(8, 402)
        Me.chkClose.Name = "chkClose"
        Me.chkClose.Size = New System.Drawing.Size(109, 17)
        Me.chkClose.TabIndex = 50
        Me.chkClose.Text = "Заявка закрыта"
        Me.chkClose.UseVisualStyleBackColor = True
        '
        'cmbTip
        '
        Me.cmbTip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbTip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTip.FormattingEnabled = True
        Me.cmbTip.Location = New System.Drawing.Point(115, 356)
        Me.cmbTip.Name = "cmbTip"
        Me.cmbTip.Size = New System.Drawing.Size(323, 21)
        Me.cmbTip.TabIndex = 49
        '
        'cmbKrit
        '
        Me.cmbKrit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbKrit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKrit.FormattingEnabled = True
        Me.cmbKrit.Location = New System.Drawing.Point(115, 329)
        Me.cmbKrit.Name = "cmbKrit"
        Me.cmbKrit.Size = New System.Drawing.Size(323, 21)
        Me.cmbKrit.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 359)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Тип:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 332)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Критичность:"
        '
        'cmbOtv
        '
        Me.cmbOtv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbOtv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOtv.FormattingEnabled = True
        Me.cmbOtv.Location = New System.Drawing.Point(115, 302)
        Me.cmbOtv.Name = "cmbOtv"
        Me.cmbOtv.Size = New System.Drawing.Size(323, 21)
        Me.cmbOtv.TabIndex = 45
        '
        'cmbStatus
        '
        Me.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(115, 275)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(323, 21)
        Me.cmbStatus.TabIndex = 44
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 305)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Ответственный:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 278)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Статус:"
        '
        'txtRem
        '
        Me.txtRem.Location = New System.Drawing.Point(115, 161)
        Me.txtRem.Multiline = True
        Me.txtRem.Name = "txtRem"
        Me.txtRem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRem.Size = New System.Drawing.Size(320, 109)
        Me.txtRem.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Сообщение:"
        '
        'txtHead
        '
        Me.txtHead.Location = New System.Drawing.Point(115, 135)
        Me.txtHead.Name = "txtHead"
        Me.txtHead.Size = New System.Drawing.Size(320, 20)
        Me.txtHead.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Заголовок:"
        '
        'dtIsp
        '
        Me.dtIsp.Location = New System.Drawing.Point(115, 109)
        Me.dtIsp.Name = "dtIsp"
        Me.dtIsp.Size = New System.Drawing.Size(128, 20)
        Me.dtIsp.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Срок исполнения:"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(115, 83)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(128, 20)
        Me.txtPhone.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Телефон:"
        '
        'dtReg
        '
        Me.dtReg.Location = New System.Drawing.Point(115, 56)
        Me.dtReg.Name = "dtReg"
        Me.dtReg.Size = New System.Drawing.Size(128, 20)
        Me.dtReg.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Дата регистрации:"
        '
        'cmbMast
        '
        Me.cmbMast.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMast.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMast.FormattingEnabled = True
        Me.cmbMast.Location = New System.Drawing.Point(115, 29)
        Me.cmbMast.Name = "cmbMast"
        Me.cmbMast.Size = New System.Drawing.Size(323, 21)
        Me.cmbMast.TabIndex = 31
        '
        'cmbIst
        '
        Me.cmbIst.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbIst.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIst.FormattingEnabled = True
        Me.cmbIst.Location = New System.Drawing.Point(115, 2)
        Me.cmbIst.Name = "cmbIst"
        Me.cmbIst.Size = New System.Drawing.Size(323, 21)
        Me.cmbIst.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Мастер:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Источник:"
        '
        'RemCashe
        '
        Me.RemCashe.Location = New System.Drawing.Point(318, 383)
        Me.RemCashe.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.RemCashe.Name = "RemCashe"
        Me.RemCashe.Size = New System.Drawing.Size(120, 20)
        Me.RemCashe.TabIndex = 55
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(249, 385)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Затраты:"
        '
        'frmService_add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 556)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.RemCashe)
        Me.Controls.Add(Me.cmbCancel)
        Me.Controls.Add(Me.cmbAdd)
        Me.Controls.Add(Me.txtComent)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.chkClose)
        Me.Controls.Add(Me.cmbTip)
        Me.Controls.Add(Me.cmbKrit)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbOtv)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtRem)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtHead)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtIsp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtReg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbMast)
        Me.Controls.Add(Me.cmbIst)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmService_add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Добавление (редактирование) заявки"
        CType(Me.RemCashe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbCancel As System.Windows.Forms.Button
    Friend WithEvents cmbAdd As System.Windows.Forms.Button
    Friend WithEvents txtComent As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkClose As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTip As System.Windows.Forms.ComboBox
    Friend WithEvents cmbKrit As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbOtv As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRem As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtHead As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtIsp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtReg As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMast As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIst As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RemCashe As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
