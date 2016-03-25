using UnityEngine;
using System.Collections;

public class OpenGate : MonoBehaviour
{

    [SerializeField]
    private float _gateSpeed;
    [SerializeField]
    private bool _isOpen = false;
    [SerializeField]
    private ParticleSystem _smoke;

    void Awake()
    {
        _smoke.Stop();
    }

    void Update()
    {
        if (_isOpen)
        {
            if (transform.localPosition.y < 500f)
            {
                transform.Translate(Vector3.up * _gateSpeed * Time.deltaTime);
            }
        }
        else if (!_isOpen)
        {
            if (transform.localPosition.y > 160f)
            {
                transform.Translate(Vector3.down * _gateSpeed * Time.deltaTime);
            }
        }
    }

    public void Open()
    {
        _isOpen = true;
        _smoke.Play();
        PlaySoundButton();
    }

    private void PlaySoundButton()
    {
        AudioSource audio1 = GetComponent<AudioSource>();
        audio1.Play();
    }
}
