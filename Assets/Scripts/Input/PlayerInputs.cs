using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    private PlayerAttack    _attack;
    private PlayerBlock     _block;
    private PlayerMovement  _movement;
    private Rotation        _rotation;
    private PlayerRoll      _dodge;
    private AdjustHealth    _health;
    private PauseGame _pause;

    void Start()
    {
        _attack         = GetComponent<PlayerAttack>();
        _block          = GetComponent<PlayerBlock>();
        _movement       = GetComponent<PlayerMovement>();
        _rotation       = GetComponent<Rotation>();
        _dodge          = GetComponent<PlayerRoll>();
        _health         = GetComponent<AdjustHealth>();
        _pause          = GetComponent<PauseGame>();

        //Cursor.visible  = false;
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
            //PCInput();
        }       
    }

    void PCInput()
    {

      /*  float leftX = Input.GetAxis(InputAxes.KEYX); //Keyboard X
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
            
        }*/
    }

    void XboxControllerInput()
    {
        //DPAD
        float dpadX = Input.GetAxis(InputAxes.DPADX); //DPAD X AXIS

        if (dpadX > 0)
        {

        }
        else if (dpadX < 0)
        {

        }

        float dpadY = Input.GetAxis(InputAxes.DPADY); //DPAD Y AXIS

        if (dpadY > 0)
        {

        }
        else if (dpadY < 0)
        {

        }

        //ANALOG STICKS
        float leftX = Input.GetAxis(InputAxes.LEFTX); //LEFT ANALOG X AXIS
        float leftY = Input.GetAxis(InputAxes.LEFTY); //LEFT ANALOG Y AXIS

        Vector3 inputVector = new Vector3(Input.GetAxis(InputAxes.LEFTX),0, -Input.GetAxis(InputAxes.LEFTY));
        if (leftX != 0 || leftY != 0)
        {
            _movement.Move(inputVector);

            _movement.handleAnimations(inputVector);
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

        }

        if (Input.GetButtonDown(InputAxes.R3))
        {
            _rotation.CenterCamera();
        }

        //FACE BUTTONS
        if (Input.GetButtonDown(InputAxes.A))
        {

        }

        if (Input.GetButton(InputAxes.B))
        {
            _block.Block();
        }
        else
        {
            _block.StopBlock();
        }
        
        if (Input.GetButtonDown(InputAxes.X))
        {
            _attack.Attack();
        }
        if (Input.GetButtonDown(InputAxes.Y))
        {

        }

        //BUMPERS & TRIGGERS

        //BUMPERS
        if (Input.GetButton(InputAxes.LB))
        {

        }
        if (Input.GetButtonDown(InputAxes.RB))
        {

        }

        //TRIGGERS
        float leftTrigger = Input.GetAxis(InputAxes.LT);
        float rightTrigger = Input.GetAxis(InputAxes.RT);

        if (leftTrigger > 0)
        {

        }
        if (rightTrigger > 0)
        {

        }

        //START & BACK
        if (Input.GetButtonDown(InputAxes.START))
        {
            _pause.Pause();
        }
        if (Input.GetButtonDown(InputAxes.BACK))
        {

        }

        //Combined Inputs
        if(Input.GetButtonDown(InputAxes.A)&& leftX != 0)
        {
            _dodge.RollX(leftX);
        }

        if(Input.GetButtonDown(InputAxes.A)&& leftY != 0)
        {
            _dodge.RollY(leftY);
        }

        //Idle
        if (!Input.anyKeyDown && leftY == 0 && leftX == 0)
        {
            AnimStateHandler.AnimStateGeneral(0);
        }
    }
}
