using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<Camera> Cameras;

    private void Start()
    {
        EnableCamera(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnableCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnableCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EnableCamera(2);
        }

     
    }

    private void EnableCamera(int n)
    {
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras[n].enabled = true;
    }
}
