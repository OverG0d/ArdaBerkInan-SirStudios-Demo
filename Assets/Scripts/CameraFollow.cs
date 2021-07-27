using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform character;
    public float zDistance;
    public float yOffset;

    // Update is called once per frame
    void Update()
    {
       //Makes the camera follow the player
       transform.position = new Vector3(character.position.x, character.position.y + yOffset,
       character.position.z - zDistance);
    }
}
