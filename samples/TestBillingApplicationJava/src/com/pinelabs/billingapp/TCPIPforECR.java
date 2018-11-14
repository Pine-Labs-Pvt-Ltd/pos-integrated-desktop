package com.pinelabs.billingapp;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.math.BigInteger;
import java.net.InetAddress;
import java.net.Socket;

import javax.swing.JOptionPane;
import javax.swing.JTextArea;

/**
 * 
 * @author Pine Labs
 * @details TCPIPforECR thread is used to communicate with PADController over
 *          TCP/IP. This thread connects, sends/recieves CSV to and from
 *          PADController and finally disconnects the connection.
 * 
 */
public class TCPIPforECR extends Thread {
	public static final int MAX_MESSAGE_LENGTH = 12048;
	public static final int PLUTUS_BILLING_DATA_REQ = 0x0997;
	public static final int PLUTUS_BILLING_DATA_RES = 0x1997;
	public static boolean bIsEncryptionON = false;
	public Socket mmSocket;
	String m_szHostIP;
	int m_usHostPort;
	InputStream mmInputStream;
	OutputStream mmOutputStream;
	boolean m_bConnected;
	public String m_strCSV;
//	static Context context;

//	public Handler mHandler;

	public TCPIPforECR() {
		// TODO Auto-generated constructor stub
		m_szHostIP = "0.0.0.0";
		m_usHostPort = 0;
		m_bConnected = false;
		m_strCSV = "";
//		mHandler = null;
	}

//	public TCPIPforECR(Context ctx, String hostIP, int hostPort, String strCSV,
//			Handler handler) {
//		context = ctx;
//		m_szHostIP = hostIP;
//		m_usHostPort = hostPort;
//		m_bConnected = false;
//		m_strCSV = strCSV;
//		mHandler = handler;
//
//	}
	
	public TCPIPforECR(String hostIP, int hostPort, String strCSV) {
		m_szHostIP = hostIP;
		m_usHostPort = hostPort;
		m_bConnected = false;
		m_strCSV = strCSV;
	}

	/**
	 * in one run, it connects with the PADController, sends/receives message as
	 * CSV and then disconnects the connection.
	 */
	public void run() {
		// String strCSV = new String("4001,TX1234,1234,,,,,,,,,");
		// char[] chCSV = "4001,TX1234,1234,,,,,,,,,".toCharArray();
		ProgressDialogStartHandlerMessageSend("Processing Transaction...");
		char[] chCSV = m_strCSV.toCharArray();
		byte[] byteCSV = new byte[MAX_MESSAGE_LENGTH];
		byte[] byteCSVEncrypted = new byte[MAX_MESSAGE_LENGTH];
		int it = 0;
		// string to byte stream
		for (it = 0; it < chCSV.length; it++) {
			byteCSV[it] = (byte) (chCSV[it] & 0xFF);
		}
		int dataLength = chCSV.length;

		// Connection establisment
		if (!ConnectPADController()) {
//			Log.v("PADController", "unable to connect to host");
			ProgressDialogEndHandler("unable to connect to host");
			return;
		}
//		String hex = String.format("%040x", new BigInteger(byteCSV));
//		System.out.println("before encrypted data: "+hex);
//		
//		// sends CSV and get response CSV
//		if(bIsEncryptionON){
//			CryptoHandler crypt = new CryptoHandler();
//			crypt.XOREncrypt(byteCSV, dataLength, byteCSVEncrypted, dataLength);
////			for (it = 0; it < dataLength; it++) {
////				byteCSV[it] = (byte) (byteCSVEncrypted[it] & 0xFF);
////			}
//			byteCSV = new byte[MAX_MESSAGE_LENGTH];
//			for (it = 0; it < dataLength; it++) {
//				byteCSV[it] = (byte) (byteCSVEncrypted[it] & 0xFF);
//			}
//		}
//		
		String hex = String.format("%040x", new BigInteger(byteCSV));
		System.out.println("data: "+hex);
		
		String responseMessage = SendECRTxn(byteCSV, dataLength);
//		JOptionPane.showMessageDialog(null,"Response: "+responseMessage);
		showMessage(""+responseMessage);
		if (responseMessage.trim().equalsIgnoreCase("")) {
//			Log.v("PADController", "Send recieve failed with PADController");
			ProgressDialogEndHandler("Send/Recieve failed with PADController");
			DisconnectPADController();
			return;
		}

		// sends the UI Handler to print response Message
//		Message msg = mHandler
//				.obtainMessage(TestBillingAppActivity.RESPONSE_MESSAGE_DIALOG);
//		Bundle bundle = new Bundle();
//		bundle.putString(TestBillingAppActivity.RESPONSE_MESSAGE,
//				responseMessage);
//		msg.setData(bundle);
//		mHandler.sendMessage(msg);
		ProgressDialogEndHandler("");

		// disconnects Connection with PADController
		DisconnectPADController();
//		Log.v("PADController", "response prints: " + responseMessage);
	}
	
	public void showMessage(String text){
//		String text = "one two three four five six seven eight nine ten ";
		  JTextArea textArea = new JTextArea(text);
		  textArea.setColumns(50);
		  textArea.setLineWrap( true );
		  textArea.setWrapStyleWord( true );
//		  textArea.append(text);
//		  textArea.append(text);
//		  textArea.append(text);
//		  textArea.append(text);
//		  textArea.append(text);
		  textArea.setSize(textArea.getPreferredSize().width, 1);
		  textArea.setBackground(null);
		  JOptionPane.showMessageDialog(
		   null, textArea, "Response", JOptionPane.PLAIN_MESSAGE);
	}

	/**
	 * API to send Handler Message to UI to start Progress Dialog with message.
	 * 
	 * @param message
	 *            message to show in progress dialog
	 */
	public void ProgressDialogStartHandlerMessageSend(String message) {
//		Message msg = mHandler
//				.obtainMessage(TestBillingAppActivity.PROGRESS_DIALOG_START);
//		Bundle bundle = new Bundle();
//		bundle.putString(TestBillingAppActivity.PROGRESS_MESSAGE, message);
//		msg.setData(bundle);
//		mHandler.sendMessage(msg);
	}

	/**
	 * API to send Handler Message to UI to end Progress Dialog and shows toast
	 * message.
	 * 
	 * @param message
	 *            toast message
	 */
	public void ProgressDialogEndHandler(String message) {
//		Message msg = mHandler
//				.obtainMessage(TestBillingAppActivity.PROGRESS_DIALOG_END);
//		Bundle bundle = new Bundle();
//		bundle.putString(TestBillingAppActivity.PROGRESS_MESSAGE, message);
//		msg.setData(bundle);
//		mHandler.sendMessage(msg);
		showMessage(message);
	}

	/**
	 * API to establish TCP/IP connection with PADController Server.
	 * 
	 * @return true if connection established successfully else false
	 */
	public boolean ConnectPADController() {
		boolean result = true;

		if (!m_bConnected) {
			try {
//				InetAddress serverAddr = InetAddress.getByName(m_szHostIP);
//				Log.v("TestBillingApp", "server Address: " + serverAddr
//						+ " port: " + m_usHostPort);
				mmSocket = new Socket(m_szHostIP, m_usHostPort);
				// set max receive buffer size and socket timeout.
				mmSocket.setReceiveBufferSize(6000);
				mmSocket.setSoTimeout(180000);

				// if socket is connected, get Input/Output Streams
				// for read and write
				if (mmSocket.isConnected()) {
					mmInputStream = mmSocket.getInputStream();
					mmOutputStream = mmSocket.getOutputStream();
					m_bConnected = true;
				}
			} catch (NullPointerException e) {
				// TODO: handle exception
				e.printStackTrace();
				return false;
			} catch (IOException e) {
				// TODO: handle exception
				e.printStackTrace();
				return false;
			} catch (Exception e) {
				// TODO: handle exception
				e.printStackTrace();
				return false;
			}
		}
		return result;
	}

	/**
	 * API to disconnect TCP/IP connection established
	 * 
	 * @return true if connection disconnected successfully else false
	 */
	public boolean DisconnectPADController() {
		if (m_bConnected) {
			try {
				if (mmSocket != null) {
					mmSocket.close();
				}
				if (mmInputStream != null) {
					mmInputStream.close();
				}
				if (mmOutputStream != null) {
					mmOutputStream.close();
				}
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
				return false;
			}
			return true;
		} else {
			return false;
		}
	}

	/**
	 * API to write on TCP/IP channel.
	 * 
	 * @param dataBuffer
	 *            data buffer in byte Array
	 * @param dataLength
	 *            buffer length
	 * @return true if successfully write else false
	 */
	public boolean sendDataToPADController(byte[] dataBuffer, int dataLength) {
		boolean result = false;
		if (!m_bConnected) {
			return result;
		}

		try {
			mmOutputStream.write(dataBuffer, 0, dataLength);
			mmOutputStream.flush();
			result = true;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return false;
		} catch (IndexOutOfBoundsException e) {
			// TODO: handle exception
			e.printStackTrace();
			return false;
		}

		return result;
	}

	/**
	 * API to read data sent from PADController
	 * 
	 * @param dataBuffer
	 *            read buffer
	 * @param dataLength
	 *            buffer length to be captured
	 * @return true if successfully read else false
	 */
	public boolean receiveDataFromPADController(byte[] dataBuffer,
			int[] dataLength) {
		boolean result = false;
		if (!m_bConnected) {
			return result;
		}

		try {
			dataLength[0] = mmInputStream.read(dataBuffer);
			result = dataLength[0] > 0 ? true : false;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return false;
		} catch (IndexOutOfBoundsException e) {
			// TODO: handle exception
			e.printStackTrace();
			return false;
		}
		return result;

	}

	/**
	 * @details: This API sends the prepared CSV to PADController and receives
	 *           return message from PADController
	 * @param byteCSV
	 *            CSV in byte Array
	 * @param nDataLength
	 *            CSV data length
	 * @return response string, if error or no response empty string would be
	 *         sent
	 */
	public String SendECRTxn(byte[] byteCSV, int nDataLength) {

		String strResponse = "";
		byte chResponse[] = new byte[MAX_MESSAGE_LENGTH];
		byte chBuffer[] = new byte[MAX_MESSAGE_LENGTH];
		int nOffset = 0;

		// Source ID
		chBuffer[nOffset++] = 0x10;
		chBuffer[nOffset++] = 0x00;

		// Func Code
		chBuffer[nOffset++] = (PLUTUS_BILLING_DATA_REQ >> 8) & 0xFF;
		chBuffer[nOffset++] = (byte) (PLUTUS_BILLING_DATA_REQ & 0xFF);

		// Data Length
		chBuffer[nOffset++] = (byte) ((nDataLength >> 8) & 0xFF);
		chBuffer[nOffset++] = (byte) (nDataLength & 0xFF);

		// The CSV prepared will be sent as data to this packet.
		for (int i = 0; i < nDataLength; i++) {
			chBuffer[nOffset + i] = byteCSV[i];
		}
		nOffset += nDataLength;

		// last byte set
		chBuffer[nOffset++] = (byte) 0xFF;

		String str = "";
		for (int it = 0; it < nOffset; it++) {
			str += (char) chBuffer[it];
		}
		
		String hex = String.format("%040x", new BigInteger(chBuffer));
		System.out.println("data: "+hex);
//		Log.v("TestBillingApp", "message to be sent: " + str);

		// send data to PADController
		boolean nDataRecv = sendDataToPADController(chBuffer, nOffset);
		// if data send unsuccessful return with empty response string
		if (!nDataRecv) {
			strResponse = "";
			return strResponse;
		}

		int[] dataLength = new int[2];
		chResponse = new byte[MAX_MESSAGE_LENGTH];

		// recieve data from PADController
		nDataRecv = receiveDataFromPADController(chResponse, dataLength);
		// if data read unsuccessful return with empty response string
		if (!nDataRecv) {
			strResponse = "";
			return strResponse;
		}

		// get Function Code(3rd & 4th byte)
		int nFuncCode = 0X0000;
		nFuncCode = (chResponse[2] & 0xFF);
		nFuncCode = ((nFuncCode & 0xFF) << 8);
		nFuncCode |= (chResponse[3] & 0xFF);

		// get Error Code (5th and 6th byte)
		int nErrCode = 0X0000;
		nErrCode = (chResponse[4] & 0xFF);
		nErrCode = ((nErrCode & 0xFF) << 8);
		nErrCode |= (chResponse[5] & 0xFF);

		// get DataLength (7th and 8th byte)
		nDataLength = 0X0000;
		nDataLength = (chResponse[6] & 0xFF);
		nDataLength = ((nDataLength & 0xFF) << 8);
		nDataLength |= (chResponse[7] & 0xFF);

		char[] byteResponse = new char[MAX_MESSAGE_LENGTH];
		// after 8 bytes, response consist of response string.
		// Copy it in a string and return it over.
		for (int i = 0; i < nDataLength; i++) {
			byteResponse[i] = (char) chResponse[i + 8];
			if (byteResponse[i] == ',') {
				strResponse += " ";
			}
			strResponse += byteResponse[i] + "";
		}
//		Log.v("TestBillingApp", "Response: " + strResponse);
		return strResponse;
	}

}
