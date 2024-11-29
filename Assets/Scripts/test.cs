using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    int y = 180;
    Quaternion rotation;
    private void Start()
    {
       
             rotation = Quaternion.Euler(0, 0, y);
            transform.rotation = rotation;
            print("y: " + y );
            
        
    }
    
}