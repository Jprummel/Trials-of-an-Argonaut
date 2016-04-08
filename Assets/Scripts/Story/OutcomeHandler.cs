using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OutcomeHandler : MonoBehaviour {

    [SerializeField]private GameObject _bull;
    [SerializeField]private GameObject _player;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_bull == null)
        {
            SceneManager.LoadScene(3);
        }
        if(_player == null)
        {
            SceneManager.LoadScene(4);
        }
	}


}
