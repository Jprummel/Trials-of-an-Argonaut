using UnityEngine;
using XInputDotNetPure; // Required in C#

public class ControllerVibration : MonoBehaviour
{
    bool            playerIndexSet = false;
    PlayerIndex     playerIndex;
    GamePadState    state;
    GamePadState    prevState;
    private float   vibrationStrength;
    private float   vibrationLength;
    private string  vibrationType;
    private bool    isVibrating;

    void Update()
    {
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState      = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);

        Vibration();
    }

    public void Vibrate(float newVibrationStrength, float newVibrationLength, string newVibrationType)
    {
        vibrationLength     = newVibrationLength;
        vibrationStrength   = newVibrationStrength;
        vibrationType       = newVibrationType;
    }

    private void Vibration()
    {
        if (vibrationStrength > 0)
        {
            if (vibrationType == "Heavy")
            {

                GamePad.SetVibration(playerIndex, vibrationStrength, 0);
                vibrationStrength -= Time.deltaTime / vibrationLength;
            }
            else if (vibrationType == "Light")
            {
                GamePad.SetVibration(playerIndex, 0, vibrationStrength);
                vibrationStrength -= Time.deltaTime / vibrationLength;
            }
            else if (vibrationType == "Both")
            {
                GamePad.SetVibration(playerIndex, vibrationStrength, vibrationStrength);
                vibrationStrength -= Time.deltaTime / vibrationLength;
            }
        }
    }
}