using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour
{
    private OpenGate    _gate;
    private FadeScreen  _fade;


    void Start()
    {
        _gate = GameObject.Find("MenuGate").GetComponent<OpenGate>();
        _fade = GameObject.Find("FadeScreen").GetComponent<FadeScreen>();
    }

    public void MenuToCredits()
    {
        AnimStateHandler.AnimStateGeneral(1);
        PlaySoundButton();
    }

    public void CreditsToMenu()
    {
        AnimStateHandler.AnimStateGeneral(2);
        PlaySoundButton();
    }

    public void MenuToPlay()
    {
        AnimStateHandler.AnimStateGeneral(3);
        StartCoroutine(PlayAnimation());
        PlaySoundButton();
    }

    public void MenuToHowToPlay()
    {
        AnimStateHandler.AnimStateGeneral(4);
        PlaySoundButton();
    }

    public void HowToPlayToMenu()
    {
        AnimStateHandler.AnimStateGeneral(5);
        PlaySoundButton();
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

    private void PlaySoundButton()
    {
        AudioSource audio1 = GetComponent<AudioSource>();
        audio1.Play();
    }
}
