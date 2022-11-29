using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject player;
    public float offsetX = -5;
    public float offsetZ = -10;
    public float maxDist = 2;
    public float playerVelocity = 10;
    public float offsetY = -5;
    private float movementX;
    private float movementY;
    private float movementZ;
    void Update()
    {
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x))/maxDist;
        movementY = ((player.transform.position.y + offsetY - this.transform.position.y))/maxDist;
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z))/maxDist;
        this.transform.position += new Vector3((movementX*playerVelocity*Time.deltaTime),(movementY*playerVelocity*Time.deltaTime),(movementZ*playerVelocity*Time.deltaTime))  ;      
    }
}
