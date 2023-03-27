using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float pointSize = 0.2f;
    void Start()
    {
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject point = gameObject.transform.GetChild(i).gameObject;
            point.transform.localScale = new Vector3(pointSize, pointSize, pointSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
