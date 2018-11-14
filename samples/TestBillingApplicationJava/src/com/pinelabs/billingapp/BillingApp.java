package com.pinelabs.billingapp;

import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.logging.Logger;

import javax.naming.ldap.Rdn;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.border.EmptyBorder;
import javax.swing.text.View;
import javax.swing.JTextArea;

public class BillingApp extends JFrame {

	public JPanel contentPane;
	public JTextField tfMemoNumber;
	public JTextField tfBankCode;
	public JTextField tfTransactionType;
	public JTextField tfAmount;
	public JTextField tfInvoiceNumber;
	JTextField tfXMLText;
	JTextArea taXMLOutput;
	
	public JRadioButton rdbtnTrue;
	public JRadioButton rdbtnFalse;
	
	public Logger LOGGER = Logger.getLogger(BillingApp.class.getName());
	
	public static String hostIPAddress = "127.0.0.1";			//local host IP Address
//	public static int hostPort = 11892;
	public static int hostPort = 8082;

	
	public TCPIPforECR objTcpIpECR;
	
	public static final String TXN_VOID = "4006";
	
	public String strTransactionType = "";
	public String strMemoNumber = "";
	public String strAmount = "";
	public String strBankCode = "";
	public String strTrackData1 = "";
	public String strTrackData2 = "";
	public String strInvoiceNumber = "";
	public String strIsSwipeEntry = "";
	public String strTerminalID = "";
	public String strRFU1 = "";
	public String strRFU2 = "";

	public String printDump = "";

	//default value to print dump edit text box
	public String tempCSV = "0;False;True;1;***********************|"
			+ "0;True;True;2;Print Stores|"
			+ "0;Flase;True;3;Pine Labs Pvt. Ltd.|"
			+ "0;Flase;True;4;Noida - 201301|"
			+ "0;False;True;5;***********************|"
			+ "0;False;False;6;Memo#   :        1234|"
			+ "0;False;False;7;DATE    :    21/05/12|"
			+ "0;False;False;8;TIME    :    12:49:52|"
			+ "0;False;False;9;INVOICE :     0000445|" + "0;False;False;10;|"
			+ "0;True;True;11;SALE|"
			+ "0;False;False;12;------------------------|"
			+ "0;False;False;13;  ITEMS           TOTAL|"
			+ "0;False;False;14;------------------------|"
			+ "0;False;False;15;1.Sofa Set     Rs.29000|"
			+ "0;False;False;16;2.Dining Table Rs.17500|"
			+ "0;False;False;17;3.Table Lamp    Rs.3450|"
			+ "0;False;False;18;------------------------|"
			+ "0;False;False;19;Total Amount:   Rs.49950|"
			+ "0;False;False;20;Vat              Rs.1500|"
			+ "0;False;False;21;------------------------|"
			+ "0;True;True;22;Net Payable:   Rs.51450|"
			+ "0;False;False;23;------------------------|"
			+ "0;False;False;24;|" + "0;False;False;25;SIGN: ...............|"
			+ "0;True;True;26;Mayank Aggarwal|" + "0;False;False;27;|"
			+ "0;False;False;28;***********************|"
			+ "0;False;False;29;Thank You for Shopping|"
			+ "0;False;False;30;CoustmerCare:9123456790|"
			+ "0;False;False;31;Price is what you pay..|"
			+ "0;False;False;32;Value is what you get..|"
			+ "0;False;False;33;***********************|"
			+ "0;False;False;34;|" + "1;True;True;35;19000004|"
			+ "0;False;False;36;|" + "2;True;True;37;123456789|"
			+ "0;False;False;38;|" + "0;False;False;39;|"
			+ "0;False;False;40;|";

	public String strCSV = "";

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					BillingApp frame = new BillingApp();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public BillingApp() {
		setTitle("Billing App");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 504, 514);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel label = new JLabel("");
		label.setBounds(5, 5, 732, 0);
		contentPane.add(label);
		
		JLabel lblMemoNumber = new JLabel("Memo Number*");
		lblMemoNumber.setBounds(61, 52, 138, 14);
		contentPane.add(lblMemoNumber);
		
		tfMemoNumber = new JTextField();
		tfMemoNumber.setBounds(226, 49, 230, 20);
		contentPane.add(tfMemoNumber);
		tfMemoNumber.setColumns(10);
		
		JLabel lblBankCode = new JLabel("Bank Code");
		lblBankCode.setBounds(61, 89, 138, 14);
		contentPane.add(lblBankCode);
		
		tfBankCode = new JTextField();
		tfBankCode.setBounds(226, 86, 230, 20);
		contentPane.add(tfBankCode);
		tfBankCode.setColumns(10);
		
		JLabel lblTxnType = new JLabel("Txn Type*");
		lblTxnType.setBounds(61, 124, 138, 14);
		contentPane.add(lblTxnType);
		
		tfTransactionType = new JTextField();
		tfTransactionType.setBounds(226, 121, 230, 20);
		contentPane.add(tfTransactionType);
		tfTransactionType.setColumns(10);
		
		JLabel lblTxnThroughSwipe = new JLabel("Txn Through Swipe");
		lblTxnThroughSwipe.setBounds(61, 155, 138, 14);
		contentPane.add(lblTxnThroughSwipe);
		
		rdbtnTrue = new JRadioButton("TRUE");
		rdbtnTrue.setHorizontalAlignment(SwingConstants.LEFT);
		rdbtnTrue.setSelected(true);
		rdbtnTrue.setVerticalAlignment(SwingConstants.TOP);
		rdbtnTrue.setBounds(226, 151, 65, 23);
		contentPane.add(rdbtnTrue);
		
		rdbtnFalse = new JRadioButton("FALSE");
		rdbtnFalse.setHorizontalAlignment(SwingConstants.LEFT);
		rdbtnFalse.setVerticalAlignment(SwingConstants.TOP);
		rdbtnFalse.setBounds(324, 151, 109, 23);
		contentPane.add(rdbtnFalse);
		
//		JPanel panel = new JPanel();
//		FlowLayout flowLayout = (FlowLayout) panel.getLayout();
//		flowLayout.setAlignment(FlowLayout.LEADING);
//		panel.setBounds(226, 145, 150, 23);
//	    panel.add(rdbtnTrue);
//	    panel.add(rdbtnFalse);
//	    contentPane.add(panel);
	    
	    ButtonGroup group = new ButtonGroup();
	    group.add(rdbtnTrue);
	    group.add(rdbtnFalse);
		
		JLabel lblAmount = new JLabel("Amount*");
		lblAmount.setBounds(61, 184, 138, 14);
		contentPane.add(lblAmount);
		
		tfAmount = new JTextField();
		tfAmount.setBounds(226, 181, 230, 20);
		contentPane.add(tfAmount);
		tfAmount.setColumns(10);
		
		JLabel lblInvoiceNumber = new JLabel("Invoice Number");
		lblInvoiceNumber.setBounds(61, 215, 138, 14);
		contentPane.add(lblInvoiceNumber);
		
		tfInvoiceNumber = new JTextField();
		tfInvoiceNumber.setBounds(226, 212, 230, 20);
		contentPane.add(tfInvoiceNumber);
		tfInvoiceNumber.setColumns(10);
		
		JButton btnPrintDump = new JButton("Print Dump");
		btnPrintDump.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				onPrintDumpButtonClick() ;
			}
		});
		btnPrintDump.setBounds(61, 270, 116, 23);
		contentPane.add(btnPrintDump);
		
		JButton btnTransaction = new JButton("Transaction");
		btnTransaction.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				onDoAnyTransactionClick();
			}
		});
		btnTransaction.setBounds(226, 270, 116, 23);
		contentPane.add(btnTransaction);
		
		JButton btnSettings = new JButton("Settings");
		btnSettings.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				EventQueue.invokeLater(new Runnable() {
					public void run() {
						try {
							Settings frame = new Settings();
							frame.setVisible(true);
							frame.setDefaultCloseOperation ( JFrame.HIDE_ON_CLOSE );
						} catch (Exception e) {
							e.printStackTrace();
						}
					}
				});
			}
		});
		btnSettings.setBounds(61, 316, 116, 23);
		contentPane.add(btnSettings);
		
		JButton btnReset = new JButton("Reset");
		btnReset.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				tfMemoNumber.setText("");
				tfBankCode.setText("");
				tfTransactionType.setText("");
				tfAmount.setText("");
				tfInvoiceNumber.setText("");
				rdbtnTrue.setSelected(true);
			}
		});
		btnReset.setBounds(226, 316, 116, 23);
		contentPane.add(btnReset);
		
		tfMemoNumber.setText("1234");
		tfBankCode.setText("01");
		tfTransactionType.setText("4001");
		tfAmount.setText("4000");
		tfInvoiceNumber.setText("5678");
		rdbtnTrue.setSelected(true);
		
		JButton btnStop = new JButton("STOP");
		btnStop.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				onStopEMITxn();
			}
		});
		btnStop.setBounds(367, 270, 89, 23);
		contentPane.add(btnStop);
		
		JButton btnUpdate = new JButton("UPDATE");
		btnUpdate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				//onUpdateEMITxn();
				onDoTskMngrTxn();
			}
		});
		btnUpdate.setBounds(367, 316, 89, 23);
		contentPane.add(btnUpdate);
		
		JLabel lblXmlText = new JLabel("XML Text");
		lblXmlText.setBounds(61, 245, 89, 14);
		contentPane.add(lblXmlText);
		
		tfXMLText = new JTextField();
		tfXMLText.setBounds(226, 239, 230, 20);
		contentPane.add(tfXMLText);
		tfXMLText.setColumns(10);
		
		taXMLOutput = new JTextArea();
		taXMLOutput.setLineWrap(true);
		taXMLOutput.setText("OUTPUT");
		taXMLOutput.setBounds(61, 350, 395, 114);
		contentPane.add(taXMLOutput);
	}
	
	public void onStopEMITxn(){
		objTcpIpECR = new TCPIPforECR("192.168.100.176", 8997, "");
		if (!objTcpIpECR.ConnectPADController()) {
//			Log.v("PADController", "unable to connect to host");
			objTcpIpECR.ProgressDialogEndHandler("unable to connect to host");
			return;
		}
		
		int mti = 0x0A;
		sendRecieveFunction(mti);
		
		objTcpIpECR.DisconnectPADController();
		
	}
	
	public void onUpdateEMITxn(){
		objTcpIpECR = new TCPIPforECR("192.168.100.224", 8997, "");
		if (!objTcpIpECR.ConnectPADController()) {
//			Log.v("PADController", "unable to connect to host");
			objTcpIpECR.ProgressDialogEndHandler("unable to connect to host");
			return;
		}
		
		int mti = 0x09;
		sendRecieveFunction(mti);
		
		objTcpIpECR.DisconnectPADController();
		
	}
	
	public void sendRecieveFunction(int MTI){
		byte uchResponseData[] = new byte[500];
		int iOffset = 0;
		
		
		//Header Data
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;

		//Source Code
		uchResponseData[iOffset++] = 	0x50;
		uchResponseData[iOffset++] =  	0x01;
		
		//Function Code
		uchResponseData[iOffset++] = (byte) (MTI & 0xFF);

		//Data Length
		uchResponseData[iOffset++] = 0x00;
		uchResponseData[iOffset++] = 0x01;
		
		//Data
		uchResponseData[iOffset++] = 0x01;

		//FOOTER
		uchResponseData[iOffset++] = (byte) 0xFF;
		
		// send data to PADController
		boolean nDataRecv = objTcpIpECR.sendDataToPADController(uchResponseData, iOffset);
		// if data send unsuccessful return with empty response string
		if (!nDataRecv) {
			return ;
		}

		int[] dataLength = new int[2];
		byte[] chResponse = new byte[1000];

		// recieve data from PADController
		nDataRecv = objTcpIpECR.receiveDataFromPADController(chResponse, dataLength);
		// if data read unsuccessful return with empty response string
		if (!nDataRecv) {
			return;
		}
		String strOut = bytesToHex(chResponse, dataLength[0]);
		System.out.println("received buffer: "+strOut);
	}
	
	
	
	public void onDoAnyTransactionClick() {
//		Log.v("TestBillingApp", "inside onDoAnyTransactionClick");

		strAmount = tfAmount.getText().toString().trim();
		strMemoNumber = tfMemoNumber.getText().toString().trim();
		strBankCode = tfBankCode.getText().toString().trim();
		strTransactionType = tfTransactionType.getText().toString().trim();
//		strTransactionType = spinnerText;
		strInvoiceNumber = tfInvoiceNumber.getText().toString().trim();

		//check for Memo Number
//		if (strMemoNumber.equalsIgnoreCase("")) {
//			
//			return;
//		}
		
		//if transaction type is Void Then check for Bank Code too.
		if (strTransactionType.equalsIgnoreCase(TXN_VOID) && strBankCode.equalsIgnoreCase("")) {
			
			return;
		}

		//check for Transaction Type
		if (strTransactionType.equalsIgnoreCase("")) {
			
			return;
		}

		//check for Amount
//		if (strAmount.equalsIgnoreCase("")) {
//			
//			return;
//		}

		//if transaction type is Void Then check for invoice number too.
//		if (strTransactionType.equalsIgnoreCase(TXN_VOID) && strInvoiceNumber.equalsIgnoreCase("")) {
//			
//			return;
//		}

		//if isSwipeEntry false else always true
		if (rdbtnFalse.isSelected()) {
			strIsSwipeEntry = "FALSE";
		} else {
			strIsSwipeEntry = "TRUE";
		}

		strCSV = strTransactionType + ","; 			// 0. Transaction Type
		strCSV += strMemoNumber + ","; 				// 1. Billing Reference Number
		strCSV += strAmount + ","; 					// 2. Total EFT Amount
		strCSV += strBankCode + ","; 				// 3. Bank Code
		strCSV += strTrackData1 + ","; 				// 4. Track Data 1
		strCSV += strTrackData2 + ","; 				// 5. Track Data 2
		strCSV += strInvoiceNumber + ","; 			// 6. Invoice Number
		strCSV += strIsSwipeEntry + ","; 			// 7. Is Swipe Entry
		strCSV += strTerminalID + ","; 				// 8. Terminal ID
		strCSV += strRFU1 + ","; 					// 9. RFU1
		strCSV += strRFU2 + ","; 					// 10. RFU12

		JOptionPane.showMessageDialog(null,"request: "+strCSV);
		LOGGER.info("request: "+strCSV);
		//create thread for TCPIPforECR and start the thread.
		objTcpIpECR = new TCPIPforECR(hostIPAddress, hostPort, strCSV);
		objTcpIpECR.start();
	}
	
	public void onPrintDumpButtonClick() {
//		Log.v("TestBillingApp", "inside onPrintDumpButtonClick");
//				strCSV = "4216" + ",,,,,,,,," + tempCSV + ",,";
				strCSV = "4216" + ",,,,,,,,,," + tempCSV + ",";
				JOptionPane.showMessageDialog(null,"request: "+strCSV);
				Thread objTcpIpECR = new TCPIPforECR(hostIPAddress,
						hostPort, strCSV);
				objTcpIpECR.start();
	}
	
	final protected static char[] hexArray = "0123456789ABCDEF".toCharArray();
	public static String bytesToHex(byte[] bytes, int iLen) {
	    char[] hexChars = new char[iLen * 2];
	    for ( int j = 0; j < iLen; j++ ) {
	        int v = bytes[j] & 0xFF;
	        hexChars[j * 2] = hexArray[v >>> 4];
	        hexChars[j * 2 + 1] = hexArray[v & 0x0F];
	    }
	    return new String(hexChars);
	}
	
	
	public void sendRecieveTskMgrFunction(int MTI, String csInputXML){
		byte uchResponseData[] = new byte[5000];
		int iOffset = 0;
		
		
		//Header Data
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;
		uchResponseData[iOffset++] =  (byte) 0xFF;

		//Source Code
		uchResponseData[iOffset++] = 	0x60;
		uchResponseData[iOffset++] =  	0x01;
		
		//Function Code
		uchResponseData[iOffset++] = (byte) (MTI & 0xFF);

		
		int iDataLen = csInputXML.length();
		int iLen = iDataLen + 4;
		//Data Length
		uchResponseData[iOffset++] = (byte) ((iLen >> 8) & 0xFF);
		uchResponseData[iOffset++] = (byte) (iLen & 0xFF);
		
		uchResponseData[iOffset++] = 0x40;
		uchResponseData[iOffset++] = 0x01;
		
		//Data Length
		uchResponseData[iOffset++] = (byte) ((iDataLen >> 8) & 0xFF);
		uchResponseData[iOffset++] = (byte) (iDataLen & 0xFF);
		
		char[] byteInputXML = csInputXML.toCharArray(); 
		for (int i = 0; i < csInputXML.length(); i++) {
			uchResponseData[iOffset + i] = (byte) byteInputXML[i];
		}
		iOffset += csInputXML.length();

		//FOOTER
		uchResponseData[iOffset++] = (byte) 0xFF;
		
		String strIn = bytesToHex(uchResponseData, iOffset);
		System.out.println("Sent buffer: "+strIn);
		
		// send data to PADController
		boolean nDataRecv = objTcpIpECR.sendDataToPADController(uchResponseData, iOffset);
		// if data send unsuccessful return with empty response string
		if (!nDataRecv) {
			taXMLOutput.setText("Send Failed");
			return ;
		}

		int[] dataLength = new int[2];
		byte[] chResponse = new byte[10000];

		// recieve data from PADController
		nDataRecv = objTcpIpECR.receiveDataFromPADController(chResponse, dataLength);
		// if data read unsuccessful return with empty response string
		if (!nDataRecv) {
			taXMLOutput.setText("Receive Failed");
			return;
		}
		String strOut = bytesToHex(chResponse, dataLength[0]);
		System.out.println("received buffer: "+strOut);
		
		String strResponse = "";
		// if data read unsuccessful return with empty response string
				if (!nDataRecv) {
					strResponse = "";
					return ;
				}

				// get Function Code(3rd & 4th byte)
				int nFuncCode = 0X0000;
				iOffset = 5;
				nFuncCode = (chResponse[iOffset++] & 0xFF);
				nFuncCode = ((nFuncCode & 0xFF) << 8);
				nFuncCode |= (chResponse[iOffset++] & 0xFF);

				int nMTI = (chResponse[iOffset++] & 0xFF);
				
				// get Error Code (5th and 6th byte)
				int nErrCode = 0X0000;
				nErrCode = (chResponse[iOffset++] & 0xFF);
				nErrCode = ((nErrCode & 0xFF) << 8);
				nErrCode |= (chResponse[iOffset++] & 0xFF);

				// get DataLength (7th and 8th byte)
				int nDataLength = 0X0000;
				nDataLength = (chResponse[iOffset++] & 0xFF);
				nDataLength = ((nDataLength & 0xFF) << 8);
				nDataLength |= (chResponse[iOffset++] & 0xFF);
				
				int nTag = 0X0000;
				int nTagLen = 0x0000;
				if(nDataLength > 0){		
					nTag = (chResponse[iOffset++] & 0xFF);
					nTag = ((nTag & 0xFF) << 8);
					nTag |= (chResponse[iOffset++] & 0xFF);
					
					nTagLen = (chResponse[iOffset++] & 0xFF);
					nTagLen = ((nTagLen & 0xFF) << 8);
					nTagLen |= (chResponse[iOffset++] & 0xFF);
	
					char[] byteResponse = new char[10000];
					// after 8 bytes, response consist of response string.
					// Copy it in a string and return it over.
					for (int i = 0; i < nTagLen; i++) {
						byteResponse[i] = (char) chResponse[i + iOffset];
						strResponse += byteResponse[i] + "";
					}
				}
//				Log.v("TestBillingApp", "Response: " + strResponse);

				taXMLOutput.setText("Func Code: "+ nFuncCode + 
									" Error Code: "+ nErrCode +
									" Data Len: "+ nDataLength +
									" Tag: " + nTag + 
									" Tag Len: " + nTagLen + 
									" response: " + strResponse);
				
	}
	
	
	public void onDoTskMngrTxn(){
		objTcpIpECR = new TCPIPforECR(hostIPAddress, 8990, "");
		if (!objTcpIpECR.ConnectPADController()) {
//			Log.v("PADController", "unable to connect to host");
			objTcpIpECR.ProgressDialogEndHandler("unable to connect to host");
			return;
		}
		
		int mti = 0x09;
		String csinputXML = tfXMLText.getText();
		sendRecieveTskMgrFunction(mti, csinputXML);
		
		objTcpIpECR.DisconnectPADController();
		
	}
}
