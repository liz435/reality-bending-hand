using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ArduinoController : MonoBehaviour
{
    // Having data sent and received in a separate thread to the main game thread stops unity from freezing
   static UdpClient udpClient;
   public static byte[] fingerPins = new byte[] {0,0,0,0,0,0};
   public static string ipAddress = "192.168.1.194"; // replace with your Arduino's IP address
   public static int port = 6000;
   public static byte[] finger = new byte[] {0,0,0,0,0,0};
  // public int pointId;

    void Start()
   {
     udpClient = new UdpClient();
     udpClient.Client.ReceiveTimeout = 50;
    //  Debug.Log("hi");
   }

   public static void Send(int pinNum, int val)
   {
     finger[pinNum] = (byte)val; 
 
          // Debug.Log(finger[0] + " "+finger[1]+" "+finger[2]+" "+ finger[3] + " "+finger[4]+" "+finger[5]);
     
 
     udpClient.Send(finger, finger.Length, ipAddress, port);
   } 
}