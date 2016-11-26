using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoSend : MonoBehaviour {

	static SerialPort arduino;

	private static void setupArduino(){
		arduino = new SerialPort("COM3", 9600);
		arduino.ReadTimeout = 50;
		arduino.Open();
	}

	public static void WriteToArduino(string msg){
		if (arduino == null)
			setupArduino ();
		
		arduino.WriteLine (msg);
		arduino.BaseStream.Flush();
		Debug.Log ("written to arduino!");
	}

	public static void WriteToArduino(int val){
		//writes a 00-99 value to arduino;
		if(val > 255) val = 255;
		if (val < 0) val = 0;
		var msg = val.ToString ();
		msg = msg + '\n';
		WriteToArduino (msg);

	}

}
