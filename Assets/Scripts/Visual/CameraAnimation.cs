using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour 
{
    private OpenGate _gate;
    private FadeScreen _fade;

    void Start()
    {
        _gate = GameObject.Find("MenuGate").GetComponent<OpenGate>();
        _fade = GameObject.Find("FadeScreen").GetComponent<FadeScreen>();
    }

    public void MenuToCredits()
    {
        AnimStateHandler.AnimStateGeneral(1);
    }

    public void CreditsToMenu()
    {
        AnimStateHandler.AnimStateGeneral(2);
    }

    public void MenuToPlay()
    {
        AnimStateHandler.AnimStateGeneral(3);
        StartCoroutine(PlayAnimation());
        
    }

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(1f);
        _gate.Open();
        yield return new WaitForSeconds(1f);
        _fade.EndScene();
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(1);
    }
}
