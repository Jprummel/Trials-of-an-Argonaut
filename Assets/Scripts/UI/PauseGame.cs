using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    public GameObject _pauseMenu;

    public void Pause()
    {
        _pauseMenu.SetActive(true);
    }
}
