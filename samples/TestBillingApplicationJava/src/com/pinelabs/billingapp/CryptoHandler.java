
package com.pinelabs.billingapp;


/**
 * @Details: ENCRYPTION DECRYPTION APIS.
 * @author  Pine Labs
 * @details 
 *
 */

public class CryptoHandler{
	/**
	 * @Details circular Left rotate of rot @times times
	 * @param rot
	 * @param times
	 * @return rotated byte
	 */
	byte RotL(byte rot, int times)
	{
	     while((times-- > 0)){
	    	  rot = (byte)((((rot<<1)) | ((rot & 0x80)>>7)));
	     }
	     return rot;
	}
	
	/**
	 * @Details circular Right rotate of rot @times times
	 * @param rot
	 * @param times
	 * @return rotated byte
	 */
	byte RotR(byte rot, int times)
	{
	        while((times-- > 0)){	        	
	        	rot = (byte)((((rot>>1) & 0x7F) | ((rot & 0x01)<<7)));
	        }
	        return rot;
	}
	
	/**
	 * @Details: XOR Encrypt the data based on circular rotate of XOR data
	 * @param rawdata
	 * @param cipherlen
	 * @param encrypted
	 * @param lenBuff
	 */
	void XOREncrypt(byte[] rawdata, int cipherlen, byte[] encrypted,int lenBuff)
	{
		char PM_KEY[] = {'G','O','D','I','S','G','R','E','A','T'};
	
		byte PM_XOR   = (byte) 0xFF;
		int key_sz = PM_KEY.length;
		short i ;

		for(i=0; i<cipherlen; ++i)
		{
			encrypted[i]=(byte) (RotL((byte) (rawdata[i]^ PM_XOR), (int)(PM_KEY[i%key_sz])) );
		}
	}
	
	/**
	 * @Details: Decrypt the data based on circular rotate and then XORing the result
	 * @param cipherdata
	 * @param cipherlen
	 * @param decrypted
	 */
	void XORDecrypt(byte[] cipherdata, int cipherlen, byte[] decrypted)
	{
         char PM_KEY[] = {'G','O','D','I','S','G','R','E','A','T'};
         
         byte PM_XOR   = (byte) 0xFF;
         int key_sz = PM_KEY.length;
         short i = 0;

	    for(i=0; i<cipherlen; ++i){
	    	decrypted[i]=(byte) ((RotR(cipherdata[i], (PM_KEY[i%key_sz])) ^ PM_XOR) &0xFF) ;
	    }
	        decrypted[i]=0x00 ;
	}
	
}







