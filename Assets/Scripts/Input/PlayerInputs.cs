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
            Debug.Log("dpad right");
        }
        else if (dpadX < 0)
        {
            //Call movement function for dpad left
            Debug.Log("dpad left");
        }

        float dpadY = Input.GetAxis(InputAxes.dpadY); //LEFT ANALOG X AXIS

        if (dpadY > 0)
        {
            //Call movement function for dpad up
            Debug.Log("Dpad up");
        }
        else if (dpadY < 0)
        {
            //Call movement function for dpad down
            Debug.Log("Dpad down");
        }

        //ANALOG STICKS

        float leftX = Input.GetAxis(InputAxes.leftX); //LEFT ANALOG X AXIS

        if(leftX > 0)
        {
            //Call movement function for going right
            Debug.Log("Leftstick right");
        }else if(leftX < 0)
        {
            //Call movement function for going left
            Debug.Log("Leftstick left");
        }

        float leftY = Input.GetAxis(InputAxes.leftY); //LEFT ANALOG Y AXIS
        
        if(leftY > 0)
        {
            //Call movement function for going backward
            Debug.Log("Leftstick down");
        }else if(leftY < 0)
        {
            //Call movement function for going forward
            Debug.Log("Leftstick up");
        }

        float rightX = Input.GetAxis(InputAxes.rightX); //RIGHT ANALOG X AXIS

        if (rightX > 0)
        {
            //Call movement function for rotating right
            Debug.Log("Rightstick right");
        }
        else if (rightX < 0)
        {
            //Call movement function for rotating left
            Debug.Log("Rightstick left");
        }

        float rightY = Input.GetAxis(InputAxes.rightY); //RIGHT ANALOG X AXIS

        if (rightY > 0)
        {
            //Call movement function for rotating camera down
            Debug.Log("Rightstick down");
        }
        else if (rightY < 0)
        {
            //Call movement function for rotating camera up
            Debug.Log("Rightstick up");
        }

        if (Input.GetButtonDown(InputAxes.l3))
        {
            //Function for clicking left analog
            Debug.Log("Leftstick click");
        }

        if (Input.GetButtonDown(InputAxes.r3))
        {
            //Function for clicking right analog
            Debug.Log("Rightstick click");
        }

        //FACE BUTTONS
        if(Input.GetButtonDown(InputAxes.a))
        {
            Debug.Log("A Pressed");
        }

        if(Input.GetButtonDown(InputAxes.b))
        {
            Debug.Log("B Pressed");
        }
        if (Input.GetButtonDown(InputAxes.x))
        {
            Debug.Log("X Pressed");
        }
        if (Input.GetButtonDown(InputAxes.y))
        {
            Debug.Log("Y Pressed");
        }

        //BUMPERS & TRIGGERS

        //BUMPERS
        if (Input.GetButtonDown(InputAxes.lb))
        {
            Debug.Log("LB Pressed");
        }
        if (Input.GetButtonDown(InputAxes.rb))
        {
            Debug.Log("RB Pressed");
        }

        //TRIGGERS
        float leftTrigger = Input.GetAxis(InputAxes.lt);
        float rightTrigger = Input.GetAxis(InputAxes.rt);

        if (leftTrigger > 0)
        {
            Debug.Log("LT Pressed");
        }
        if (rightTrigger > 0)
        {
            Debug.Log("RT Pressed");
        }

        //START & BACK
        if (Input.GetButtonDown(InputAxes.start))
        {
            Debug.Log("Start Pressed");
        } 
        if (Input.GetButtonDown(InputAxes.back))
        {
            Debug.Log("Back Pressed");
        }
    }
}
