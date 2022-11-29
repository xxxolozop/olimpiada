using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motor : MonoBehaviour
{
    public float power = 0.0f;
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody> ().AddRelativeForce (0,power,0);        
    }
}
