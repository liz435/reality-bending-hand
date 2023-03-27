using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class PointController : MonoBehaviour
{   UdpClient udpClient;
    public string ipAddress = "192.168.1.194"; // replace with your Arduino's IP address
    public int port = 6000;
    private byte[] finger = new byte[] { 0,0,0,0,0,0 };
    public int pointId ;

    // Start is called before the first frame update
    void Start()
    {
        udpClient = new UdpClient();
        udpClient.Client.ReceiveTimeout = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // byte[] data = new byte[] { 0,0,0,0 }; 
        // udpClient.Send(data, data.Length, ipAddress, port);
    }

    private void OnCollisionEnter(Collision collision)
    {
   
    Color objColor;
    objColor = collision.gameObject.GetComponent<MeshRenderer>().material.color;

    float H, S, V;
    Color.RGBToHSV(objColor, out H, out S, out V);

    Debug.Log(objColor.r + " "+ objColor.g + " "+ objColor.b+ " "+ objColor.a + " ");
    


    float myH = 100*H;
    int value = Mathf.FloorToInt(myH);
    Debug.Log(value +"H");

        ArduinoController.Send(pointId, value);
    

    
 
     }

    private void OnCollisionExit(Collision collision)
    {
      
        // byte k = 0;
       // EventManager.Touch(pointId,k);
     //   byte[] data = new byte[] { 0,0,0,0,0,0 }; 
        // finger[pointId] = k;
        //  udpClient.Send(finger, finger.Length, ipAddress, port);
         ArduinoController.Send(pointId, 0);
    }
}
