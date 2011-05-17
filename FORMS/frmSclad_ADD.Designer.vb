<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclad_ADD
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
        Me.nazvan = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.kol = New System.Windows.Forms.TextBox
        Me.ost = New System.Windows.Forms.TextBox
        Me.nomer_treb = New System.Windows.Forms.TextBox
        Me.postavshik = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.prim = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.price = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.nomer_plat = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.garant = New System.Windows.Forms.DateTimePicker
        Me.poluch = New System.Windows.Forms.DateTimePicker
        Me.cena_nds = New System.Windows.Forms.TextBox
        Me.cena_free = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.v_otdel = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.add = New System.Windows.Forms.Button
        Me.cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Наименование:"
        '
        'nazvan
        '
        Me.nazvan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.nazvan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.nazvan.FormattingEnabled = True
        Me.nazvan.Location = New System.Drawing.Point(12, 20)
        Me.nazvan.Name = "nazvan"
        Me.nazvan.Size = New System.Drawing.Size(345, 21)
        Me.nazvan.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Поступило:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Остаток:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(251, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Номер требования:"
        '
        'kol
        '
        Me.kol.Location = New System.Drawing.Point(12, 61)
        Me.kol.Name = "kol"
        Me.kol.Size = New System.Drawing.Size(100, 20)
        Me.kol.TabIndex = 5
        '
        'ost
        '
        Me.ost.Location = New System.Drawing.Point(129, 60)
        Me.ost.Name = "ost"
        Me.ost.Size = New System.Drawing.Size(100, 20)
        Me.ost.TabIndex = 6
        '
        'nomer_treb
        '
        Me.nomer_treb.Location = New System.Drawing.Point(254, 61)
        Me.nomer_treb.Name = "nomer_treb"
        Me.nomer_treb.Size = New System.Drawing.Size(103, 20)
        Me.nomer_treb.TabIndex = 7
        '
        'postavshik
        '
        Me.postavshik.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.postavshik.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.postavshik.FormattingEnabled = True
        Me.postavshik.Location = New System.Drawing.Point(12, 100)
        Me.postavshik.Name = "postavshik"
        Me.postavshik.Size = New System.Drawing.Size(345, 21)
        Me.postavshik.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Поставщик:"
        '
        'prim
        '
        Me.prim.Location = New System.Drawing.Point(12, 142)
        Me.prim.Multiline = True
        Me.prim.Name = "prim"
        Me.prim.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.prim.Size = New System.Drawing.Size(345, 125)
        Me.prim.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Примечание:"
        '
        'price
        '
        Me.price.Location = New System.Drawing.Point(12, 289)
        Me.price.Name = "price"
        Me.price.Size = New System.Drawing.Size(154, 20)
        Me.price.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 272)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Счёт:"
        '
        'nomer_plat
        '
        Me.nomer_plat.Location = New System.Drawing.Point(206, 288)
        Me.nomer_plat.Name = "nomer_plat"
        Me.nomer_plat.Size = New System.Drawing.Size(151, 20)
        Me.nomer_plat.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(208, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "№ Платежного поручения:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(203, 312)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Дата получения:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 312)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Гарантия:"
        '
        'garant
        '
        Me.garant.Location = New System.Drawing.Point(12, 328)
        Me.garant.Name = "garant"
        Me.garant.Size = New System.Drawing.Size(154, 20)
        Me.garant.TabIndex = 18
        '
        'poluch
        '
        Me.poluch.Location = New System.Drawing.Point(206, 328)
        Me.poluch.Name = "poluch"
        Me.poluch.Size = New System.Drawing.Size(151, 20)
        Me.poluch.TabIndex = 19
        '
        'cena_nds
        '
        Me.cena_nds.Location = New System.Drawing.Point(206, 371)
        Me.cena_nds.Name = "cena_nds"
        Me.cena_nds.Size = New System.Drawing.Size(151, 20)
        Me.cena_nds.TabIndex = 23
        '
        'cena_free
        '
        Me.cena_free.Location = New System.Drawing.Point(12, 371)
        Me.cena_free.Name = "cena_free"
        Me.cena_free.Size = New System.Drawing.Size(150, 20)
        Me.cena_free.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(203, 354)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Стоимость включая НДС:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 354)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Цена еденицы без НДС:"
        '
        'v_otdel
        '
        Me.v_otdel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.v_otdel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.v_otdel.FormattingEnabled = True
        Me.v_otdel.Location = New System.Drawing.Point(12, 414)
        Me.v_otdel.Name = "v_otdel"
        Me.v_otdel.Size = New System.Drawing.Size(345, 21)
        Me.v_otdel.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 398)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Переведено в филиал:"
        '
        'add
        '
        Me.add.Location = New System.Drawing.Point(12, 442)
        Me.add.Name = "add"
        Me.add.Size = New System.Drawing.Size(75, 23)
        Me.add.TabIndex = 26
        Me.add.Text = "Добавить"
        Me.add.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(116, 442)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 23)
        Me.cancel.TabIndex = 27
        Me.cancel.Text = "Отмена"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'frmSclad_ADD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 476)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.add)
        Me.Controls.Add(Me.v_otdel)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cena_nds)
        Me.Controls.Add(Me.cena_free)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.poluch)
        Me.Controls.Add(Me.garant)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.nomer_plat)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.price)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.prim)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.postavshik)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nomer_treb)
        Me.Controls.Add(Me.ost)
        Me.Controls.Add(Me.kol)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nazvan)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSclad_ADD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Добавить (редактировать) на склад"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nazvan As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents kol As System.Windows.Forms.TextBox
    Friend WithEvents ost As System.Windows.Forms.TextBox
    Friend WithEvents nomer_treb As System.Windows.Forms.TextBox
    Friend WithEvents postavshik As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents prim As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents price As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nomer_plat As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents garant As System.Windows.Forms.DateTimePicker
    Friend WithEvents poluch As System.Windows.Forms.DateTimePicker
    Friend WithEvents cena_nds As System.Windows.Forms.TextBox
    Friend WithEvents cena_free As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents v_otdel As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents add As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button
End Class
