using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour 
{
    [SerializeField]private Text _text;
    [SerializeField]private float _fadeTime;
    [SerializeField]private Transform _playerPos;
    [SerializeField]private float _checkDistance;
    private bool _displayInfo;

	// Use this for initialization
	void Start () 
    {
        _text.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () 
    {
        FadeText();
        CheckForPlayer();

	}

    void CheckForPlayer()
    {
        _text.transform.LookAt(_playerPos);
        float dist = Vector3.Distance(transform.position, _playerPos.position);
        if(dist < _checkDistance)
        {
            _displayInfo = true;
        }
        else
        {
            _displayInfo = false;
        }
    }

    void FadeText()
    {
        if(_displayInfo)
        {
            _text.color = Color.Lerp (_text.color, Color.white, _fadeTime * Time.deltaTime);
        }
        else
        {
            _text.color = Color.Lerp (_text.color, Color.clear, _fadeTime * Time.deltaTime);
        }
    }
}
