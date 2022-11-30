public Camera camera1;
public Camera camera2;
...

void Start()
{
    camera1.enabled = true;
    camera2.enabled = false;
    ...
}

void Update()
{
    if(Input.GetKeyDown(KeyCode.Alpha1))
    {
         camera1.enabled = true;
         camera2.enabled = false;
         ...
    }
    else if(Input.GetKeyDown(KeyCode.Alpha2))
    {
         camera1.enabled = false;
         camera2.enabled = true;
         ...
    }
    ...
}
