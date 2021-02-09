using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    
    public void SetColorRed()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void SetColorBlue ()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
