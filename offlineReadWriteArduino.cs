using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;


public class offlineReadWriteArduino :MonoBehaviour {
	SerialPort stream = new SerialPort("/dev/cu.usbmodem1421", 57600);
	bool flip=false;
	string hold;
	// Use this for initialization
	void Start () {
		stream.Open ();

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q")) {

			if (flip == false)
				WriteToArduino ("ledOn ");
			else
				WriteToArduino ("ledOff ");
			flip = !flip;
		}
		hold = ReadFromArduino (1);
		if (hold != null&&hold.ToCharArray().Length>0) {
			if (hold.ToCharArray () [0] == '1') {
				gameObject.transform.localScale = new Vector3 (2, 2, 2);
			}
			if(hold.ToCharArray () [0] == '2')
				gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}
	}
	public string ReadFromArduino (int timeout) {


		stream.ReadTimeout = timeout;
		try {
			return stream.ReadLine();
		} 
		catch (System.Exception) {
			return null;
		}

	}
	public void WriteToArduino(string message) {
		stream.Write(message);

	}

}
