using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    private PlayerAttack        _attack;
    private PlayerBlock         _block;
    private PlayerMovement      _movement;
    private CameraMovement      _rotation;
    private PlayerRoll          _dodge;
    public PauseGame            _pause;
    private ToggleEnableInput   _inputToggle;

    void Start()
    {
        _inputToggle    = GetComponent<ToggleEnableInput>();
        _attack         = GetComponent<PlayerAttack>();
        _block          = GetComponent<PlayerBlock>();
        _movement       = GetComponent<PlayerMovement>();
        _rotation       = GameObject.Find("CameraController").GetComponent<CameraMovement>();
        _dodge          = GetComponent<PlayerRoll>();
    }

	void Update () {
        XboxControllerInput();
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
            if (Input.GetButtonDown(InputAxes.A))
            {
                _dodge.RollX();
            }
        }

        float rightX = Input.GetAxis(InputAxes.RIGHTX); //RIGHT ANALOG X AXIS
        float rightY = Input.GetAxis(InputAxes.RIGHTY); //RIGHT ANALOG X AXIS
        
        if (rightX != 0)
        {
            _rotation.RotateX(150f, rightX);
        }

        if (rightY != 0)
        {
            //_rotation.RotateX(100f,rightY);
            _rotation.RotateY(100f, rightY);
        }

        if (Input.GetButtonDown(InputAxes.L3))
        {

        }

        if (Input.GetButtonDown(InputAxes.R3))
        {

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
            _pause.PauseToggle();
        }
        if (Input.GetButtonDown(InputAxes.BACK))
        {

        }

        //Idle
        if (!Input.anyKeyDown && leftY == 0 && leftX == 0)
        {
            AnimStateHandler.AnimStateGeneral(0);
        }
    }
}
