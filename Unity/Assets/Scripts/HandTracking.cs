using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    // Update is called once per frame
    private void Start()
    {
        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        string[] points = data.Split(',');
    }

    void Update()
    {
        
        string[] points = parseDataToPoints(udpReceive.data);
        
        //0        1*3      2*3
        //x1,y1,z1,x2,y2,z2,x3,y3,z3
 
        for ( int i = 0; i<21; i++)
        {
            float x = 7-float.Parse(points[i * 3])/100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;
 
            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }

    private string[] parseDataToPoints(string data)
    {
         data = udpReceive.data;
 
        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        string[] points = data.Split(',');
        return points;
    }
}
