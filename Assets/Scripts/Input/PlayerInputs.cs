using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    private PlayerAttack _attack;
    private PlayerMovement _movement;
    private PlayerRotation _rotation;
    private CameraRotation _camRotation;

    void Start()
    {
        _attack = GetComponent<PlayerAttack>();
        _movement = GetComponent<PlayerMovement>();
        _rotation = GetComponent<PlayerRotation>();
        _camRotation = GetComponent<CameraRotation>();
    }
  	// Update is called once per frame
	void Update () {
        Inputs();
    }

    void Inputs()
    {
        //DPAD
        float dpadX = Input.GetAxis(InputAxes.DPADX); //LEFT ANALOG X AXIS

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

        float dpadY = Input.GetAxis(InputAxes.DPADY); //LEFT ANALOG X AXIS

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

        float leftX = Input.GetAxis(InputAxes.LEFTX); //LEFT ANALOG X AXIS

        if(leftX > 0)
        {
            _movement.MoveX(leftX);     // Move right
        }else if(leftX < 0)
        {
            _movement.MoveX(leftX);     // Move left
        }

        float leftY = Input.GetAxis(InputAxes.LEFTY); //LEFT ANALOG Y AXIS
        
        if(leftY > 0)
        {
            _movement.MoveY(leftY);     //Move backward
        }else if(leftY < 0)
        {
            _movement.MoveY(leftY);     //Move forward
        }

        float rightX = Input.GetAxis(InputAxes.RIGHTX); //RIGHT ANALOG X AXIS

        if (rightX > 0)
        {
            _rotation.RotateY(rightX);  //Rotate Right
        }
        else if (rightX < 0)
        {
            _rotation.RotateY(rightX);  //Rotate left
        }

        float rightY = Input.GetAxis(InputAxes.RIGHTY); //RIGHT ANALOG X AXIS

        if (rightY > 0)
        {
            //Call movement function for rotating camera down
            Debug.Log("Rightstick down");
            _rotation.RotateX(rightY);  //Look down
        }
        else if (rightY < 0)
        {
            _rotation.RotateX(rightY);  //Look up
        }

        if (Input.GetButtonDown(InputAxes.L3))
        {
            //Function for clicking left analog
            Debug.Log("Leftstick click");
        }

        if (Input.GetButtonDown(InputAxes.R3))
        {
            //Function for clicking right analog
            Debug.Log("Rightstick click");
        }

        //FACE BUTTONS
        if(Input.GetButtonDown(InputAxes.A))
        {
            Debug.Log("A Pressed");
            _movement.Jump();
        }

        if(Input.GetButtonDown(InputAxes.B))
        {
            Debug.Log("B Pressed");
        }
        if (Input.GetButtonDown(InputAxes.X))
        {
            Debug.Log("X Pressed");
            _attack.Attack();
        }
        if (Input.GetButtonDown(InputAxes.Y))
        {
            Debug.Log("Y Pressed");
        }

        //BUMPERS & TRIGGERS

        //BUMPERS
        if (Input.GetButtonDown(InputAxes.LB))
        {
            Debug.Log("LB Pressed");
        }
        if (Input.GetButtonDown(InputAxes.RB))
        {
            Debug.Log("RB Pressed");
        }

        //TRIGGERS
        float leftTrigger = Input.GetAxis(InputAxes.LT);
        float rightTrigger = Input.GetAxis(InputAxes.RT);

        if (leftTrigger > 0)
        {
            Debug.Log("LT Pressed");
        }
        if (rightTrigger > 0)
        {
            Debug.Log("RT Pressed");
        }

        //START & BACK
        if (Input.GetButtonDown(InputAxes.START))
        {
            Debug.Log("Start Pressed");
        } 
        if (Input.GetButtonDown(InputAxes.BACK))
        {
            Debug.Log("Back Pressed");
        }
    }
}
