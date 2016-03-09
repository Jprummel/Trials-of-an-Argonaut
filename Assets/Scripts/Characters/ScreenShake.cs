using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    private Vector3 _originalPos;

    [SerializeField]private bool _shaking = false;
    [Range(0f,0.1f)]
    [SerializeField]private float _shakeAmount;

    void Awake()
    {
        //Save original position of the camera.
        _originalPos = Camera.main.gameObject.transform.localPosition;
    }
    
    void Update()
    {
        Shake(_shaking,_shakeAmount);
    }
    public void Shake(bool isShaking,float shakeAmount)
    {
        if(isShaking)
        {
            //Shake the camera random inside a sphere.
            Camera.main.gameObject.transform.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;
        }
        else
        {
            //Set the camera position back to original position.
            Camera.main.gameObject.transform.localPosition = _originalPos;
        }
    }
}