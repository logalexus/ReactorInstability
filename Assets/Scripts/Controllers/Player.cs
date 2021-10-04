using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    public static Player Instance;
    
    
    private void Awake()
    {
            Instance = this;
    }
    
    
    
    
}
