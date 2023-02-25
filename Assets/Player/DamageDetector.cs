using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    PlayerMovement movement;

    private void Awake() 
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update() 
    {
            
    }
}
