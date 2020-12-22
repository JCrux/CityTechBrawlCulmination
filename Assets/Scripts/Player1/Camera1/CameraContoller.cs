using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
       transform.position = new Vector3(player.position.x, 3.1f, transform.position.z);
    } 
}

