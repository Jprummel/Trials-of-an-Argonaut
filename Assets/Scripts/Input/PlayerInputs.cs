using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Inputs();
	}

    void Inputs()
    {
        //DPAD
        float dpadX = Input.GetAxis(InputAxes.dpadX); //LEFT ANALOG X AXIS

        if (dpadX > 0)
        {
            //Call movement function for dpad right
        }
        else if (dpadX < 0)
        {
            //Call movement function for dpad left
        }

        float dpadY = Input.GetAxis(InputAxes.dpadY); //LEFT ANALOG X AXIS

        if (dpadY > 0)
        {
            //Call movement function for dpad up
        }
        else if (dpadY < 0)
        {
            //Call movement function for dpad down
        }
        //ANALOG STICKS

        float leftX = Input.GetAxis(InputAxes.leftX); //LEFT ANALOG X AXIS

        if(leftX > 0)
        {
            //Call movement function for going right
        }else if(leftX < 0)
        {
            //Call movement function for going left
        }

        float leftY = Input.GetAxis(InputAxes.leftY); //LEFT ANALOG Y AXIS
        
        if(leftY > 0)
        {
            //Call movement function for going backward
        }else if(leftY < 0)
        {
            //Call movement function for going forward
        }

        float rightX = Input.GetAxis(InputAxes.rightX); //RIGHT ANALOG X AXIS

        if (rightX > 0)
        {
            //Call movement function for rotating right
        }
        else if (rightX < 0)
        {
            //Call movement function for rotating left
        }

        float rightY = Input.GetAxis(InputAxes.rightY); //RIGHT ANALOG X AXIS

        if (rightY > 0)
        {
            //Call movement function for rotating camera down
        }
        else if (rightY < 0)
        {
            //Call movement function for rotating camera up
        }

        if (Input.GetButtonDown(InputAxes.l3))
        {
            //Function for clicking left analog
        }

        if (Input.GetButtonDown(InputAxes.r3))
        {
            //Function for clicking right analog
        }

        //FACE BUTTONS
        if(Input.GetButtonDown(InputAxes.a))
        {

        }

        if(Input.GetButtonDown(InputAxes.b))
        {

        }
        if (Input.GetButtonDown(InputAxes.x))
        {

        }
        if (Input.GetButtonDown(InputAxes.y))
        {

        }

        //BUMPERS & TRIGGERS
        if (Input.GetButtonDown(InputAxes.lb))
        {

        }
        if (Input.GetButtonDown(InputAxes.rb))
        {

        }
        if (Input.GetButtonDown(InputAxes.lt))
        {

        }
        if (Input.GetButtonDown(InputAxes.rt))
        {

        }

        //START & BACK
        if (Input.GetButtonDown(InputAxes.start))
        {

        } if (Input.GetButtonDown(InputAxes.back))
        {

        }
    }
}
