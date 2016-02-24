using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitHealthBar : MonoBehaviour 
{
    [SerializeField]private Image _healthBar;
    [SerializeField]private float _fadeTime;
    [SerializeField]private Transform _playerPos;
    [SerializeField]private float _checkDistance;
    private bool _displayInfo;

	void Start () 
    {
        _healthBar.color = Color.clear;
	}

	void Update () 
    {
        FadeHealthBar();
        CheckForPlayer();
	}

    void CheckForPlayer()
    {
        _healthBar.transform.LookAt(_playerPos);
        float dist = Vector3.Distance(transform.position, _playerPos.position);
        if (dist < _checkDistance)
        {
            _displayInfo = true;
        }
        else
        {
            _displayInfo = false;
        }
    }

    void FadeHealthBar()
    {
        if (_displayInfo)
        {
            _healthBar.color = Color.Lerp(_healthBar.color, Color.white, _fadeTime * Time.deltaTime);
        }
        else
        {
            _healthBar.color = Color.Lerp(_healthBar.color, Color.clear, _fadeTime * Time.deltaTime);
        }
    }
}
