package com.pinelabs.billingapp;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class Settings extends JFrame {

	private JPanel contentPane;
	private JTextField tfIPAddress;
	private JTextField tfIPPort;
	Settings settings;

//	/**
//	 * Launch the application.
//	 */
//	public static void main(String[] args) {
//		EventQueue.invokeLater(new Runnable() {
//			public void run() {
//				try {
//					Settings frame = new Settings();
//					frame.setVisible(true);
//				} catch (Exception e) {
//					e.printStackTrace();
//				}
//			}
//		});
//	}

	/**
	 * Create the frame.
	 */
	public Settings() {
		settings = this;
		setTitle("Settings");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 300, 200);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblIpAddress = new JLabel("IP Address");
		lblIpAddress.setBounds(25, 26, 77, 14);
		contentPane.add(lblIpAddress);
		
		tfIPAddress = new JTextField();
		tfIPAddress.setText(BillingApp.hostIPAddress);
		tfIPAddress.setBounds(91, 23, 171, 20);
		contentPane.add(tfIPAddress);
		tfIPAddress.setColumns(10);
		
		JLabel lblIpPort = new JLabel("IP Port");
		
		lblIpPort.setBounds(25, 57, 77, 14);
		contentPane.add(lblIpPort);
		
		tfIPPort = new JTextField();
		tfIPPort.setText(BillingApp.hostPort+"");
		tfIPPort.setBounds(91, 54, 171, 20);
		contentPane.add(tfIPPort);
		tfIPPort.setColumns(10);
		
		JButton btnNewButton = new JButton("OK");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				String strIPAddress = tfIPAddress.getText().toString().trim();
				String strIPPort = tfIPPort.getText().toString().trim();
				if(strIPAddress.equalsIgnoreCase("") || strIPPort.equalsIgnoreCase("")){
				return;
				}
				try{
				BillingApp.hostIPAddress = strIPAddress;
				BillingApp.hostPort = Integer.parseInt(strIPPort);
				settings.dispose();
				}catch(Exception e){
					e.printStackTrace();
				}finally{
					
				}
			}
		});
		btnNewButton.setBounds(91, 103, 77, 23);
		contentPane.add(btnNewButton);
		
		JButton btnCancel = new JButton("Cancel");
		btnCancel.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				settings.dispose();
				return;
			}
		});
		btnCancel.setBounds(185, 103, 77, 23);
		contentPane.add(btnCancel);
	}
}
