<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim label14 As System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.label26 = New System.Windows.Forms.Label
        Me.invoiceNo2 = New System.Windows.Forms.TextBox
        Me.label24 = New System.Windows.Forms.Label
        Me.label23 = New System.Windows.Forms.Label
        Me.merchantName = New System.Windows.Forms.TextBox
        Me.label9 = New System.Windows.Forms.Label
        Me.trackingID = New System.Windows.Forms.TextBox
        Me.label16 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label19 = New System.Windows.Forms.Label
        Me.output = New System.Windows.Forms.TextBox
        Me.merchantAdd = New System.Windows.Forms.TextBox
        Me.label17 = New System.Windows.Forms.Label
        Me.label22 = New System.Windows.Forms.Label
        Me.hostResponse = New System.Windows.Forms.TextBox
        Me.acquirerBankCode = New System.Windows.Forms.TextBox
        Me.acquirer = New System.Windows.Forms.TextBox
        Me.label13 = New System.Windows.Forms.Label
        Me.merchantID = New System.Windows.Forms.TextBox
        Me.label18 = New System.Windows.Forms.Label
        Me.retrivalNo = New System.Windows.Forms.TextBox
        Me.label12 = New System.Windows.Forms.Label
        Me.label21 = New System.Windows.Forms.Label
        Me.batchNo = New System.Windows.Forms.TextBox
        Me.city = New System.Windows.Forms.TextBox
        Me.remark = New System.Windows.Forms.TextBox
        Me.label20 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.approvalCode = New System.Windows.Forms.TextBox
        Me.label15 = New System.Windows.Forms.Label
        Me.terminalID = New System.Windows.Forms.TextBox
        Me.cardType = New System.Windows.Forms.TextBox
        Me.Bank_code = New System.Windows.Forms.TextBox
        Me.label25 = New System.Windows.Forms.Label
        Me.TxnType = New System.Windows.Forms.ComboBox
        Me.Reset = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.track2 = New System.Windows.Forms.TextBox
        Me.track1 = New System.Windows.Forms.TextBox
        Me.invoiceNo = New System.Windows.Forms.TextBox
        Me.amount = New System.Windows.Forms.TextBox
        Me.crdHolder = New System.Windows.Forms.TextBox
        Me.CardHolder = New System.Windows.Forms.Label
        Me.isSwipeEntry = New System.Windows.Forms.CheckBox
        label14 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'label14
        '
        label14.AutoSize = True
        label14.Location = New System.Drawing.Point(365, 235)
        label14.Name = "label14"
        label14.Size = New System.Drawing.Size(61, 13)
        label14.TabIndex = 62
        label14.Text = "Terminal ID"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(261, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "StartTxn"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.Location = New System.Drawing.Point(363, 324)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(59, 13)
        Me.label26.TabIndex = 87
        Me.label26.Text = "Invoice No"
        '
        'invoiceNo2
        '
        Me.invoiceNo2.Location = New System.Drawing.Point(454, 321)
        Me.invoiceNo2.Name = "invoiceNo2"
        Me.invoiceNo2.Size = New System.Drawing.Size(100, 20)
        Me.invoiceNo2.TabIndex = 86
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Location = New System.Drawing.Point(365, 45)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(85, 13)
        Me.label24.TabIndex = 85
        Me.label24.Text = "Response String"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(572, 293)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(71, 13)
        Me.label23.TabIndex = 84
        Me.label23.Text = "Merchant city"
        '
        'merchantName
        '
        Me.merchantName.Location = New System.Drawing.Point(454, 264)
        Me.merchantName.Name = "merchantName"
        Me.merchantName.Size = New System.Drawing.Size(100, 20)
        Me.merchantName.TabIndex = 78
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(363, 98)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(63, 13)
        Me.label9.TabIndex = 58
        Me.label9.Text = "Tracking ID"
        '
        'trackingID
        '
        Me.trackingID.Location = New System.Drawing.Point(454, 96)
        Me.trackingID.Name = "trackingID"
        Me.trackingID.Size = New System.Drawing.Size(100, 20)
        Me.trackingID.TabIndex = 65
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(588, 184)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(46, 13)
        Me.label16.TabIndex = 71
        Me.label16.Text = "Acquirer"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(481, -26)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(80, 17)
        Me.label10.TabIndex = 57
        Me.label10.Text = "Response"
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.Location = New System.Drawing.Point(363, 267)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(83, 13)
        Me.label19.TabIndex = 77
        Me.label19.Text = "Merchant Name"
        '
        'output
        '
        Me.output.Location = New System.Drawing.Point(454, 12)
        Me.output.Multiline = True
        Me.output.Name = "output"
        Me.output.Size = New System.Drawing.Size(335, 72)
        Me.output.TabIndex = 63
        '
        'merchantAdd
        '
        Me.merchantAdd.Location = New System.Drawing.Point(454, 151)
        Me.merchantAdd.Name = "merchantAdd"
        Me.merchantAdd.Size = New System.Drawing.Size(335, 20)
        Me.merchantAdd.TabIndex = 83
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(578, 212)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(66, 13)
        Me.label17.TabIndex = 72
        Me.label17.Text = "Merchant ID"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(363, 154)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(93, 13)
        Me.label22.TabIndex = 82
        Me.label22.Text = "Merchant Address"
        '
        'hostResponse
        '
        Me.hostResponse.Location = New System.Drawing.Point(454, 177)
        Me.hostResponse.Name = "hostResponse"
        Me.hostResponse.Size = New System.Drawing.Size(100, 20)
        Me.hostResponse.TabIndex = 67
        '
        'acquirerBankCode
        '
        Me.acquirerBankCode.Location = New System.Drawing.Point(454, 293)
        Me.acquirerBankCode.Name = "acquirerBankCode"
        Me.acquirerBankCode.Size = New System.Drawing.Size(100, 20)
        Me.acquirerBankCode.TabIndex = 81
        '
        'acquirer
        '
        Me.acquirer.Location = New System.Drawing.Point(650, 177)
        Me.acquirer.Name = "acquirer"
        Me.acquirer.Size = New System.Drawing.Size(139, 20)
        Me.acquirer.TabIndex = 74
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(363, 208)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(52, 13)
        Me.label13.TabIndex = 61
        Me.label13.Text = "Batch No"
        '
        'merchantID
        '
        Me.merchantID.Location = New System.Drawing.Point(648, 205)
        Me.merchantID.Name = "merchantID"
        Me.merchantID.Size = New System.Drawing.Size(141, 20)
        Me.merchantID.TabIndex = 75
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(578, 238)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(66, 13)
        Me.label18.TabIndex = 73
        Me.label18.Text = "Retrieval No"
        '
        'retrivalNo
        '
        Me.retrivalNo.Location = New System.Drawing.Point(649, 235)
        Me.retrivalNo.Name = "retrivalNo"
        Me.retrivalNo.Size = New System.Drawing.Size(140, 20)
        Me.retrivalNo.TabIndex = 76
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(363, 180)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(80, 13)
        Me.label12.TabIndex = 60
        Me.label12.Text = "Host Response"
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(363, 296)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(73, 13)
        Me.label21.TabIndex = 80
        Me.label21.Text = "acquirer Code"
        '
        'batchNo
        '
        Me.batchNo.Location = New System.Drawing.Point(454, 205)
        Me.batchNo.Name = "batchNo"
        Me.batchNo.Size = New System.Drawing.Size(100, 20)
        Me.batchNo.TabIndex = 68
        '
        'city
        '
        Me.city.Location = New System.Drawing.Point(648, 293)
        Me.city.Name = "city"
        Me.city.Size = New System.Drawing.Size(141, 20)
        Me.city.TabIndex = 79
        '
        'remark
        '
        Me.remark.Location = New System.Drawing.Point(648, 264)
        Me.remark.Name = "remark"
        Me.remark.Size = New System.Drawing.Size(141, 20)
        Me.remark.TabIndex = 56
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Location = New System.Drawing.Point(600, 264)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(39, 13)
        Me.label20.TabIndex = 55
        Me.label20.Text = "remark"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(363, 124)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(77, 13)
        Me.label11.TabIndex = 59
        Me.label11.Text = "Approval Code"
        '
        'approvalCode
        '
        Me.approvalCode.Location = New System.Drawing.Point(454, 122)
        Me.approvalCode.Name = "approvalCode"
        Me.approvalCode.Size = New System.Drawing.Size(100, 20)
        Me.approvalCode.TabIndex = 66
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(585, 126)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(56, 13)
        Me.label15.TabIndex = 69
        Me.label15.Text = "Card Type"
        '
        'terminalID
        '
        Me.terminalID.Location = New System.Drawing.Point(454, 235)
        Me.terminalID.Name = "terminalID"
        Me.terminalID.Size = New System.Drawing.Size(100, 20)
        Me.terminalID.TabIndex = 64
        '
        'cardType
        '
        Me.cardType.Location = New System.Drawing.Point(642, 121)
        Me.cardType.Name = "cardType"
        Me.cardType.Size = New System.Drawing.Size(147, 20)
        Me.cardType.TabIndex = 70
        '
        'Bank_code
        '
        Me.Bank_code.Location = New System.Drawing.Point(108, 309)
        Me.Bank_code.Name = "Bank_code"
        Me.Bank_code.Size = New System.Drawing.Size(100, 20)
        Me.Bank_code.TabIndex = 106
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.BackColor = System.Drawing.SystemColors.Control
        Me.label25.Location = New System.Drawing.Point(15, 25)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(25, 13)
        Me.label25.TabIndex = 99
        Me.label25.Text = "Txn"
        '
        'TxnType
        '
        Me.TxnType.FormattingEnabled = True
        Me.TxnType.Items.AddRange(New Object() {"4001 SALE", "4006 VOID", "4007 PRE-AUTH", "4008 SALE_COMPLETE", "4015 TIP ADJUST"})
        Me.TxnType.Location = New System.Drawing.Point(106, 21)
        Me.TxnType.Name = "TxnType"
        Me.TxnType.Size = New System.Drawing.Size(204, 21)
        Me.TxnType.TabIndex = 97
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(261, 325)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(75, 23)
        Me.Reset.TabIndex = 94
        Me.Reset.Text = "Reset"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(140, -1)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(68, 17)
        Me.label1.TabIndex = 88
        Me.label1.Text = "Request"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.SystemColors.Control
        Me.label2.Location = New System.Drawing.Point(15, 51)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(43, 13)
        Me.label2.TabIndex = 98
        Me.label2.Text = "Amount"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(15, 316)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(60, 13)
        Me.label8.TabIndex = 105
        Me.label8.Text = "Bank Code"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(15, 231)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(41, 13)
        Me.label6.TabIndex = 103
        Me.label6.Text = "Track2"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(15, 133)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(41, 13)
        Me.label5.TabIndex = 102
        Me.label5.Text = "Track1"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(15, 81)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(59, 13)
        Me.label3.TabIndex = 100
        Me.label3.Text = "Invoice No"
        '
        'track2
        '
        Me.track2.Location = New System.Drawing.Point(106, 212)
        Me.track2.Multiline = True
        Me.track2.Name = "track2"
        Me.track2.Size = New System.Drawing.Size(204, 65)
        Me.track2.TabIndex = 96
        '
        'track1
        '
        Me.track1.Location = New System.Drawing.Point(106, 126)
        Me.track1.Multiline = True
        Me.track1.Name = "track1"
        Me.track1.Size = New System.Drawing.Size(204, 61)
        Me.track1.TabIndex = 95
        '
        'invoiceNo
        '
        Me.invoiceNo.Location = New System.Drawing.Point(106, 74)
        Me.invoiceNo.Name = "invoiceNo"
        Me.invoiceNo.Size = New System.Drawing.Size(100, 20)
        Me.invoiceNo.TabIndex = 91
        '
        'amount
        '
        Me.amount.Location = New System.Drawing.Point(106, 48)
        Me.amount.Name = "amount"
        Me.amount.Size = New System.Drawing.Size(100, 20)
        Me.amount.TabIndex = 89
        '
        'crdHolder
        '
        Me.crdHolder.Location = New System.Drawing.Point(642, 96)
        Me.crdHolder.Name = "crdHolder"
        Me.crdHolder.Size = New System.Drawing.Size(148, 20)
        Me.crdHolder.TabIndex = 108
        '
        'CardHolder
        '
        Me.CardHolder.AutoSize = True
        Me.CardHolder.Location = New System.Drawing.Point(575, 104)
        Me.CardHolder.Name = "CardHolder"
        Me.CardHolder.Size = New System.Drawing.Size(60, 13)
        Me.CardHolder.TabIndex = 107
        Me.CardHolder.Text = "CardHolder"
        '
        'isSwipeEntry
        '
        Me.isSwipeEntry.AutoSize = True
        Me.isSwipeEntry.Location = New System.Drawing.Point(213, 102)
        Me.isSwipeEntry.Name = "isSwipeEntry"
        Me.isSwipeEntry.Size = New System.Drawing.Size(86, 17)
        Me.isSwipeEntry.TabIndex = 109
        Me.isSwipeEntry.Text = "isSwipeEntry"
        Me.isSwipeEntry.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 356)
        Me.Controls.Add(Me.isSwipeEntry)
        Me.Controls.Add(Me.crdHolder)
        Me.Controls.Add(Me.CardHolder)
        Me.Controls.Add(Me.Bank_code)
        Me.Controls.Add(Me.label25)
        Me.Controls.Add(Me.TxnType)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.track2)
        Me.Controls.Add(Me.track1)
        Me.Controls.Add(Me.invoiceNo)
        Me.Controls.Add(Me.amount)
        Me.Controls.Add(Me.label26)
        Me.Controls.Add(Me.invoiceNo2)
        Me.Controls.Add(Me.label24)
        Me.Controls.Add(Me.label23)
        Me.Controls.Add(Me.merchantName)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.trackingID)
        Me.Controls.Add(Me.label16)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label19)
        Me.Controls.Add(Me.output)
        Me.Controls.Add(Me.merchantAdd)
        Me.Controls.Add(Me.label17)
        Me.Controls.Add(Me.label22)
        Me.Controls.Add(Me.hostResponse)
        Me.Controls.Add(Me.acquirerBankCode)
        Me.Controls.Add(Me.acquirer)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.merchantID)
        Me.Controls.Add(Me.label18)
        Me.Controls.Add(Me.retrivalNo)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.label21)
        Me.Controls.Add(Me.batchNo)
        Me.Controls.Add(Me.city)
        Me.Controls.Add(Me.remark)
        Me.Controls.Add(Me.label20)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(label14)
        Me.Controls.Add(Me.approvalCode)
        Me.Controls.Add(Me.label15)
        Me.Controls.Add(Me.terminalID)
        Me.Controls.Add(Me.cardType)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "SampleBillingApp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents label26 As System.Windows.Forms.Label
    Private WithEvents invoiceNo2 As System.Windows.Forms.TextBox
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents merchantName As System.Windows.Forms.TextBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents trackingID As System.Windows.Forms.TextBox
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents output As System.Windows.Forms.TextBox
    Private WithEvents merchantAdd As System.Windows.Forms.TextBox
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents hostResponse As System.Windows.Forms.TextBox
    Private WithEvents acquirerBankCode As System.Windows.Forms.TextBox
    Private WithEvents acquirer As System.Windows.Forms.TextBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents merchantID As System.Windows.Forms.TextBox
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents retrivalNo As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents batchNo As System.Windows.Forms.TextBox
    Private WithEvents city As System.Windows.Forms.TextBox
    Private WithEvents remark As System.Windows.Forms.TextBox
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents approvalCode As System.Windows.Forms.TextBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents terminalID As System.Windows.Forms.TextBox
    Private WithEvents cardType As System.Windows.Forms.TextBox
    Private WithEvents Bank_code As System.Windows.Forms.TextBox
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents TxnType As System.Windows.Forms.ComboBox
    Private WithEvents Reset As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents track2 As System.Windows.Forms.TextBox
    Private WithEvents track1 As System.Windows.Forms.TextBox
    Private WithEvents invoiceNo As System.Windows.Forms.TextBox
    Private WithEvents amount As System.Windows.Forms.TextBox
    Private WithEvents crdHolder As System.Windows.Forms.TextBox
    Private WithEvents CardHolder As System.Windows.Forms.Label
    Friend WithEvents isSwipeEntry As System.Windows.Forms.CheckBox

End Class
