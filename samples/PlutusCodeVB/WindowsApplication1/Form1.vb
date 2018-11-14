Imports System

Public Class Form1

    Public Sub New()
        InitializeComponent()
    End Sub


    Private Sub ParseCSV(ByVal str As String, ByRef vValues() As String, ByRef index As Integer, ByVal delimiter As Char)
        'this function parses the CSV string recieved from Plutus into an array of strings seperating on the basis of the delimiter comma(,)
        Dim pos As Integer = 0
        Dim ch As Char = "\0"
        Dim Quote As Char = """c"
        Dim currentQuote As Char = "\0"
        index = 0
        Dim quoted As Boolean = False
        Dim token As String = ""
        Dim tokenComplete As Boolean = False        'indicates if the current token is read to be added to the result vector
        Dim len As Integer = str.Length             'length of the input-string
        While len > pos
            ch = str(pos)
            Dim addChar As Boolean = True
            If ch = Quote Then
                If quoted = False Then
                    quoted = True
                    currentQuote = ch               ' don't add the quote-char to the token
                    addChar = False
                Else                                ' check if it is the matching character to close it
                    If currentQuote = ch Then       ' close quote and reset the quote character
                        quoted = False
                        currentQuote = "\0"

                        ' don't add the quote-char to the token
                        addChar = False
                        If (String.IsNullOrEmpty(token)) Then  '"" type value
                            'Parser.
                            'vValues.push_back( token );
                            vValues.SetValue(token, index)
                            index = index + 1
                            'clear the contents
                            token = ""
                            'build the next token
                            tokenComplete = False
                        End If

                    End If ' else
                End If
            End If

            ' ... if the delimiter isn't preserved
            If quoted = False Then
                ' if a delimiter is provided and the char isn't protected by
                ' quote or escape char
                If (ch = delimiter) Then

                    ' if ch is a delimiter and the token string isn't empty
                    ' the token is complete
                    If Not (String.IsNullOrEmpty(token)) Then
                        tokenComplete = True
                    End If
                    ' don't add the delimiter to the token
                    addChar = False
                End If
            End If

            ' ... if the delimiter is preserved - add it as a token		

            ' add the character to the token
            If addChar = True Then
                ' add the current char
                token += ch
            End If

            ' add the token if it is complete
            If (tokenComplete = True And Not String.IsNullOrEmpty(token)) Then
                'add the token string
                vValues.SetValue(token, index)
                index = index + 1

                ' clear the contents
                token = ""

                ' build the next token
                tokenComplete = False
            End If
            ' repeat for the next character
            pos = pos + 1
        End While          ' while
        ' add the final token
        If Not String.IsNullOrEmpty(token) Then
            vValues.SetValue(token, index)
            index = index + 1
        End If
    End Sub
    Private Enum Response
        TrackID = 0
        AppCode
        HostResponse
        CardNumber
        ExpirationDate
        CardHolderName
        CardType
        InvoiceNumber
        BatchNumber
        TerminalID
        LoyaltiPoints
        Remarks
        AcquirerName
        MechantID
        RetrievalRefNumber
        CardEntryMode
        NameOnReceipt
        MerchantName
        MerchantAdd
        Merchantcity
        PlutusVersion
        AcquirerBankCode
        TimeOFTransaction = 32
    End Enum

    Private Sub Reset_Output()
        trackingID.Text = ""
        approvalCode.Text = ""
        hostResponse.Text = ""            ' reset all entries to NULL
        'CardHolder.Text = ""
        cardType.Text = ""
        batchNo.Text = ""
        terminalID.Text = ""
        invoiceNo2.Text = ""
        remark.Text = ""
        acquirer.Text = ""
        merchantID.Text = ""
        retrivalNo.Text = ""
        crdHolder.Text = ""
        merchantName.Text = ""
        acquirerBankCode.Text = ""
        city.Text = ""
        merchantAdd.Text = ""
        output.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click         'This function handles StartTxn button click event
        Dim comma As Char = ","
        Dim SALE As Integer = 4001
        Dim SALE_COMPLETE As Integer = 4008
        Dim VOIDED As Integer = 4006
        Dim PREAUTH As Integer = 4007
        Dim TIP_ADJUST As Integer = 4015

        Reset_Output()
        'InitializeComponent()

        Dim transnType As Integer = SALE
        If TxnType.Text = "4001 SALE" Then transnType = SALE
        If TxnType.Text = "4006 VOID" Then transnType = VOIDED
        If TxnType.Text = "4007 PRE-AUTH" Then transnType = PREAUTH
        If TxnType.Text = "4008 SALE_COMPLETE" Then transnType = SALE_COMPLETE
        If TxnType.Text = "4015 TIP ADJUST" Then transnType = TIP_ADJUST

        Dim Billing_Reference_No As String = "TX12345690"  'Billing reference no. from the billing application, hardcoded for the time
        Dim ExchangeObj As PlutusExchangeLib.ExchangeObj = New PlutusExchangeLib.ExchangeObj()  'Initializing PlutusExchangeObj

        Dim swipeEntry As String = "FALSE"        ' Write text to the console.
        If transnType = SALE Or transnType = PREAUTH Then
            'If Not String.IsNullOrEmpty(cardNo.Text) = True Then
            '    If Not String.IsNullOrEmpty(yearBox.Text) = True Then
            '        If Not String.IsNullOrEmpty(monthsBox.Text) = True Then
            '            swipeEntry = "FALSE"
            '        End If
            '    End If
            If isSwipeEntry.Checked = True Then
                swipeEntry = "TRUE"
            Else
                swipeEntry = "FALSE"
            End If

            'If swipeEntry = "TRUE" Then
            '    If track1.Text = "" Or track2.Text = "" Then
            '        MessageBox.Show("Track1 and Track2 can not be empty")
            '        Return
            '    End If
            'Else
            '    If cardNo.Text = "" Then
            '        MessageBox.Show("Please Give Proper Card Number.")
            '        Return
            '    End If

            '    If yearBox.Text = "" Or monthsBox.Text = "" Then
            '        MessageBox.Show("Please Give Proper Expiry Date.")
            '        Return
            '    End If
            'End If
        End If


        If transnType = VOIDED Or transnType = SALE_COMPLETE Or transnType = TIP_ADJUST Then             'Validation Checks      
            If invoiceNo.Text = "" Then
                MessageBox.Show("Please Give Proper Invoice Number.")
                Return
            End If

            If (Bank_code.Text = "") Then
                MessageBox.Show("Please Give Proper Bank code.")
                Return
            End If

            If transnType = SALE_COMPLETE Or transnType = TIP_ADJUST Then
                If amount.Text = "" Then
                    MessageBox.Show("Please Give Proper Amount.")
                    Return
                End If
            End If
        End If
        ' Preparing Request String
        Dim requestString As String = Billing_Reference_No + comma + amount.Text + comma + Bank_code.Text + comma
        'If swipeEntry = "TRUE" Then
        'If isCardNoEntry.Checked = False Then
        requestString = requestString + track1.Text + comma
        'Else
        '    requestString = requestString + cardNo.Text + comma
        'End If

        'If swipeEntry = "TRUE" Then
        'If isCardNoEntry.Checked = False Then
        requestString = requestString + track2.Text
        'Else
        'requestString = requestString + yearBox.Text + monthsBox.Text
        'End If
        requestString = requestString + comma + invoiceNo.Text + comma + swipeEntry + comma + terminalID.Text + comma + comma + comma

        Try
            ExchangeObj.PL_TriggerTransaction(transnType, requestString)           'API Call
        Catch
            MessageBox.Show("Exception occurred in communication to Plutus application. Please retry")
            Return
        End Try
        output.Text = requestString

        Dim Index As Integer

        Dim vValues(32) As String

        Index = 0
        ParseCSV(requestString, vValues, Index, ",")
        Index = Index - 1
        If transnType = SALE Or transnType = PREAUTH Then
            If (Index >= Response.AppCode) Then
                If vValues(Response.AppCode).Length > 0 Then
                    MessageBox.Show("Transaction Successful")
                Else
                    MessageBox.Show("Transaction Failed")
                End If
            End If
        End If

        If transnType = VOIDED Or transnType = SALE_COMPLETE Or transnType = TIP_ADJUST Then
            If (vValues(0).Equals("APPROVED", StringComparison.OrdinalIgnoreCase)) Then
                MessageBox.Show("Transaction Successful")
            Else
                MessageBox.Show("Transaction Failed")
            End If
        End If

        ' DISPLAYING DETAILED RESPONSE IN VARIOUS TEXT BOXES
        If transnType = SALE Or transnType = PREAUTH Then
            ' If there is Response. And presence of non-zero length approval code string , it indicates successful authorization of transaction.
            If Index >= Response.AppCode Then             'count should start from 1 instead of 0 so 1 added
                'Response string if a response for transaction was received from bank switch. Otherwise, if any error occurs before response is received, this is an empty string.
                If Index >= Response.HostResponse Then      'count should start from 1 instead of 0 so 1 added
                    'Description of error, if an error occurs. Otherwise, empty string. An empty string in this field DOES NOT imply successful transaction authorization
                    If Index >= Response.Remarks Then       'count should start from 1 instead of 0 so 1 added
                        'Checking if Transaction is through, where response for all of the values are present in list and it does not meet OUT OF BOUNDs while accessing the list 
                        If Index >= Response.AcquirerBankCode Then 'count should start from 1 instead of 0 so 1 added
                            trackingID.Text = vValues(Response.TrackID)             'ePLResponse values are defined enums
                            approvalCode.Text = vValues(Response.AppCode)
                            hostResponse.Text = vValues(Response.HostResponse)
                            crdHolder.Text = vValues(Response.CardHolderName)
                            cardType.Text = vValues(Response.CardType)
                            invoiceNo.Text = vValues(Response.InvoiceNumber)
                            invoiceNo2.Text = vValues(Response.InvoiceNumber)
                            batchNo.Text = vValues(Response.BatchNumber)
                            terminalID.Text = vValues(Response.TerminalID)
                            remark.Text = vValues(Response.Remarks)
                            acquirer.Text = vValues(Response.AcquirerName)
                            merchantID.Text = vValues(Response.MechantID)
                            retrivalNo.Text = vValues(Response.RetrievalRefNumber)
                            crdHolder.Text = vValues(Response.NameOnReceipt)
                            merchantName.Text = vValues(Response.MerchantName)
                            acquirerBankCode.Text = vValues(Response.AcquirerBankCode)
                            city.Text = vValues(Response.Merchantcity)
                            merchantAdd.Text = vValues(Response.MerchantAdd)
                        Else
                            trackingID.Text = vValues(Response.TrackID)
                            approvalCode.Text = vValues(Response.AppCode)
                            hostResponse.Text = vValues(Response.HostResponse)
                            crdHolder.Text = vValues(Response.CardHolderName)
                            cardType.Text = vValues(Response.CardType)
                            invoiceNo.Text = vValues(Response.InvoiceNumber)
                            invoiceNo2.Text = vValues(Response.InvoiceNumber)
                            batchNo.Text = vValues(Response.BatchNumber)
                            terminalID.Text = vValues(Response.TerminalID)
                            remark.Text = vValues(Response.Remarks)
                        End If
                    End If
                Else
                    trackingID.Text = vValues(Response.TrackID)
                    approvalCode.Text = vValues(Response.AppCode)
                    hostResponse.Text = vValues(Response.HostResponse)
                End If
            Else
                trackingID.Text = vValues(Response.TrackID)
                approvalCode.Text = vValues(Response.AppCode)
            End If

        End If

        If transnType = VOIDED Or transnType = SALE_COMPLETE Or transnType = TIP_ADJUST Then
            remark.Text = vValues(0)
        End If
    End Sub

    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset.Click             'This function handles StartTxn button click event
        trackingID.Text = ""
        amount.Text = ""
        approvalCode.Text = ""
        hostResponse.Text = ""            ' reset all entries to NULL
        'cardNo.Text = ""
        'CardHolder.Text = ""
        cardType.Text = ""
        invoiceNo.Text = ""
        batchNo.Text = ""
        terminalID.Text = ""
        invoiceNo2.Text = ""
        track1.Text = ""
        track2.Text = ""
        remark.Text = ""
        acquirer.Text = ""
        merchantID.Text = ""
        retrivalNo.Text = ""
        crdHolder.Text = ""
        'yearBox.Text = ""
        'monthsBox.Text = ""
        merchantName.Text = ""
        acquirerBankCode.Text = ""
        city.Text = ""
        merchantAdd.Text = ""
        output.Text = ""
    End Sub

    Private Sub OnTxTypeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxnType.SelectedIndexChanged
        Reset_Click(sender, e)
    End Sub
End Class
