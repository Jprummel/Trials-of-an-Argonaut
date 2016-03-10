using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    private PlayerAttack    _attack;
    private PlayerBlock     _block;
    private PlayerMovement  _movement;
    private Rotation        _rotation;
    private PlayerRoll      _dodge;
    private AdjustHealth    _health;

    void Start()
    {
        _attack         = GetComponent<PlayerAttack>();
        _block          = GetComponent<PlayerBlock>();
        _movement       = GetComponent<PlayerMovement>();
        _rotation       = GetComponent<Rotation>();
        _dodge          = GetComponent<PlayerRoll>();
        _health         = GetComponent<AdjustHealth>();

        Cursor.visible  = false;
    }
  	// Update is called once per frame
	void Update () {
        Inputs();
    }

    void Inputs()
    {
        if (_health.CanUseInput())
        {
            XboxControllerInput();
            PCInput();
        }       
    }

    void PCInput()
    {

        float leftX = Input.GetAxis(InputAxes.KEYX); //Keyboard X
        float leftY = Input.GetAxis(InputAxes.KEYY); //Keyboard Y

        if (leftX != 0)  //X Axis Movement
        {
            _movement.MoveX(leftX);
        }

        if (leftY != 0)  //Y Axis Movement
        {
            _movement.MoveY(leftY);
        }

        float rightX = Input.GetAxis(InputAxes.MOUSEX); //RIGHT ANALOG X AXIS
        float rightY = Input.GetAxis(InputAxes.MOUSEY); //RIGHT ANALOG X AXIS

        if (rightX != 0) //Y Axis Camera Rotation (X Axis on stick)
        {
            _rotation.RotateX(20f,rightX);
        }

        if (rightY != 0) //X Axis Camera Rotation (Y Axis on stick)
        {
            _rotation.RotateY(50f,rightY);
            
        }
    }

    void XboxControllerInput()
    {
        //DPAD
        float dpadX = Input.GetAxis(InputAxes.DPADX); //DPAD X AXIS

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

        float dpadY = Input.GetAxis(InputAxes.DPADY); //DPAD Y AXIS

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
        float leftY = Input.GetAxis(InputAxes.LEFTY); //LEFT ANALOG Y AXIS

        if (leftX != 0)  //X Axis Movement
        {
            _movement.MoveX(leftX);
        }

        if (leftY != 0)  //Y Axis Movement
        {
            _movement.MoveY(leftY);
        }


        float rightX = Input.GetAxis(InputAxes.RIGHTX); //RIGHT ANALOG X AXIS
        float rightY = Input.GetAxis(InputAxes.RIGHTY); //RIGHT ANALOG X AXIS

        if (rightX != 0) //Y Axis Camera Rotation (X Axis on stick)
        {
            _rotation.RotateY(150f,rightX);
        }

        if (rightY != 0) //X Axis Camera Rotation (Y Axis on stick)
        {
            _rotation.RotateX(100f,rightY);
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
            _rotation.CenterCamera();
        }

        //FACE BUTTONS
        if (Input.GetButtonDown(InputAxes.A))
        {
            Debug.Log("A Pressed");
        }

        if (Input.GetButton(InputAxes.B))
        {
            Debug.Log("B Pressed");
            _block.Block();
        }
        else
        {
            _block.StopBlock();
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
        if (Input.GetButton(InputAxes.LB))
        {
            _block.Block();
            Debug.Log(_block.IsBlocking());
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

        //Combined Inputs
        if(Input.GetButtonDown(InputAxes.A)&& leftX != 0)
        {
            _dodge.RollX(leftX);
            Debug.Log("They see me rolling");
        }

        if(Input.GetButtonDown(InputAxes.A)&& leftY != 0)
        {
            _dodge.RollY(leftY);
            Debug.Log("They hating");
        }

        //Idle
        if (!Input.anyKeyDown && leftY == 0 && leftX == 0)
        {
            AnimStateHandler.AnimStateGeneral(0);
        }
    }
}
