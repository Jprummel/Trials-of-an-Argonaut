using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    private Vector3         _originalPos;
    private BullBehaviour   _bullBehaviour;

    void Start()
    {
        //Save original position of the camera.
        _originalPos    = Camera.main.gameObject.transform.localPosition;
        _bullBehaviour  = GameObject.FindGameObjectWithTag(Tags.BULL).GetComponent<BullBehaviour>();
    }
    
    void Update()
    {
        Shake(_bullBehaviour.isCharging,0.1f);
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