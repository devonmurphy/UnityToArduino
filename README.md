# UnityToArduino

This code communicates from Unity to Arduino by using the serial port. 

Unity to Arduino

Unity can send/recieve data over the serial port by using System.IO.ports. When the key “q” is pressed in Unity, it sends the command “ledOn” over serial. Arduino reads the serial port and checks if what it receives is a command. If the command is “ledOn” then Arduino will set ledPin # 8 to HIGH. If “q” is pressed again then Unity will send the command “ledOff” to Arduino.

Arduino to Unity

Arduino can also send signals over the serial port with Serial.Write(). When a push button is pressed, Arduino will send the command “1111111”. When it is released Arduino will send the message “2222222”. Unity can read these messages through stream.ReadLine(). Unity increases the scale of the gameObject effected by the offlineReadWriteArduino.cs script if the last signal read was 1’s. This gives the button the functionality of making a box on screen appear large while the button is held down. 