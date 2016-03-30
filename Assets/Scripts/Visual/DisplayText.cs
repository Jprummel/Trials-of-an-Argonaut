using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour 
{
    [SerializeField]private Text        _text;
    [SerializeField]private float       _fadeTime;
    [SerializeField]private Transform   _player;
    [SerializeField]private float       _checkDistance;
                    private bool        _displayInfo;

	void Start () 
    {
        _text.color = Color.clear;
	}
	
	void Update () 
    {
        FadeText();
        CheckForPlayer();
	}

    void CheckForPlayer()
    {
        if (_player != null)
        {
            _text.transform.LookAt(_player);
            float dist = Vector3.Distance(transform.position, _player.position);
            if (dist < _checkDistance)
            {
                _displayInfo = true;
            }
            else
            {
                _displayInfo = false;
            }
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
