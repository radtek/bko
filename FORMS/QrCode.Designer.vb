<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QrCode
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEncode = New System.Windows.Forms.Button
        Me.txtSize = New System.Windows.Forms.TextBox
        Me.txtEncodeData = New System.Windows.Forms.TextBox
        Me.cboCorrectionLevel = New System.Windows.Forms.ComboBox
        Me.cboVersion = New System.Windows.Forms.ComboBox
        Me.cboEncoding = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.picEncode = New System.Windows.Forms.PictureBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnDecode = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.txtDecodedData = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.picDecode = New System.Windows.Forms.PictureBox
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.picEncode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.picDecode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(823, 479)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnPrint)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.btnEncode)
        Me.TabPage1.Controls.Add(Me.txtSize)
        Me.TabPage1.Controls.Add(Me.txtEncodeData)
        Me.TabPage1.Controls.Add(Me.cboCorrectionLevel)
        Me.TabPage1.Controls.Add(Me.cboVersion)
        Me.TabPage1.Controls.Add(Me.cboEncoding)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.picEncode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(815, 453)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Encode"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(257, 376)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(164, 376)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnEncode
        '
        Me.btnEncode.Location = New System.Drawing.Point(72, 376)
        Me.btnEncode.Name = "btnEncode"
        Me.btnEncode.Size = New System.Drawing.Size(75, 23)
        Me.btnEncode.TabIndex = 11
        Me.btnEncode.Text = "Encode"
        Me.btnEncode.UseVisualStyleBackColor = True
        '
        'txtSize
        '
        Me.txtSize.Location = New System.Drawing.Point(72, 327)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(100, 20)
        Me.txtSize.TabIndex = 10
        Me.txtSize.Text = "4"
        '
        'txtEncodeData
        '
        Me.txtEncodeData.Location = New System.Drawing.Point(72, 224)
        Me.txtEncodeData.Name = "txtEncodeData"
        Me.txtEncodeData.Size = New System.Drawing.Size(457, 20)
        Me.txtEncodeData.TabIndex = 9
        Me.txtEncodeData.Text = "Squee&Dragon"
        '
        'cboCorrectionLevel
        '
        Me.cboCorrectionLevel.FormattingEnabled = True
        Me.cboCorrectionLevel.Items.AddRange(New Object() {"L", "M", "Q", "H"})
        Me.cboCorrectionLevel.Location = New System.Drawing.Point(321, 256)
        Me.cboCorrectionLevel.Name = "cboCorrectionLevel"
        Me.cboCorrectionLevel.Size = New System.Drawing.Size(208, 21)
        Me.cboCorrectionLevel.TabIndex = 8
        '
        'cboVersion
        '
        Me.cboVersion.FormattingEnabled = True
        Me.cboVersion.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40"})
        Me.cboVersion.Location = New System.Drawing.Point(72, 292)
        Me.cboVersion.Name = "cboVersion"
        Me.cboVersion.Size = New System.Drawing.Size(121, 21)
        Me.cboVersion.TabIndex = 7
        '
        'cboEncoding
        '
        Me.cboEncoding.FormattingEnabled = True
        Me.cboEncoding.Items.AddRange(New Object() {"AlphaNumeric", "Numeric", "Byte"})
        Me.cboEncoding.Location = New System.Drawing.Point(72, 256)
        Me.cboEncoding.Name = "cboEncoding"
        Me.cboEncoding.Size = New System.Drawing.Size(121, 21)
        Me.cboEncoding.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 330)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Size"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(234, 259)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "CorrectionLevel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Version"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Encoding"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data"
        '
        'picEncode
        '
        Me.picEncode.Location = New System.Drawing.Point(7, 7)
        Me.picEncode.Name = "picEncode"
        Me.picEncode.Size = New System.Drawing.Size(800, 212)
        Me.picEncode.TabIndex = 0
        Me.picEncode.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnDecode)
        Me.TabPage2.Controls.Add(Me.btnOpen)
        Me.TabPage2.Controls.Add(Me.txtDecodedData)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.picDecode)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(815, 453)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Decode"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnDecode
        '
        Me.btnDecode.Location = New System.Drawing.Point(108, 291)
        Me.btnDecode.Name = "btnDecode"
        Me.btnDecode.Size = New System.Drawing.Size(75, 23)
        Me.btnDecode.TabIndex = 13
        Me.btnDecode.Text = "Decode"
        Me.btnDecode.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(11, 291)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 12
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtDecodedData
        '
        Me.txtDecodedData.Location = New System.Drawing.Point(71, 237)
        Me.txtDecodedData.Name = "txtDecodedData"
        Me.txtDecodedData.Size = New System.Drawing.Size(457, 20)
        Me.txtDecodedData.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Data"
        '
        'picDecode
        '
        Me.picDecode.Location = New System.Drawing.Point(4, 4)
        Me.picDecode.Name = "picDecode"
        Me.picDecode.Size = New System.Drawing.Size(803, 217)
        Me.picDecode.TabIndex = 0
        Me.picDecode.TabStop = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'QrCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 479)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "QrCode"
        Me.Text = "QrCode"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.picEncode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.picDecode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents txtEncodeData As System.Windows.Forms.TextBox
    Friend WithEvents cboCorrectionLevel As System.Windows.Forms.ComboBox
    Friend WithEvents cboVersion As System.Windows.Forms.ComboBox
    Friend WithEvents cboEncoding As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picEncode As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEncode As System.Windows.Forms.Button
    Friend WithEvents picDecode As System.Windows.Forms.PictureBox
    Friend WithEvents btnDecode As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtDecodedData As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
