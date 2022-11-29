using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystic : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("copter").GetComponent<copter>().throttle = Input.GetAxis("throttle")*1f+13.45f;
        GameObject.Find("copter").GetComponent<copter>().targetYaw = Input.GetAxis("throttle")*2;
        GameObject.Find("copter").GetComponent<copter>().targetPitch = Input.GetAxis("throttle")*30;
        GameObject.Find("copter").GetComponent<copter>().targetRoll = Input.GetAxis("throttle")*30;
    }
}
//пропеллеры -1