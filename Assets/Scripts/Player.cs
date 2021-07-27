using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joyStick;
    public float movementSpeed;

    float heading;
    public Rigidbody rigid;

    //Called every fixed frame-rate frame
    void FixedUpdate()
    {
        if (joyStick.Horizontal > 0 || joyStick.Vertical > 0 || joyStick.Horizontal < 0 || joyStick.Vertical < 0)
        {
            //Rotates the players forward direction toward joystick
            //direction and moves it towards that direction
            heading = Mathf.Atan2(joyStick.Horizontal, joyStick.Vertical);

            transform.rotation = Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f);

            rigid.velocity = transform.forward * Time.deltaTime * movementSpeed;
        }
        else
        {
            rigid.velocity = Vector3.zero; //Stops player movement
        }
    }
    
}
