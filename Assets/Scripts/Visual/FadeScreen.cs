using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {

    private Image _fadeScreen;
    private float _fadeInSpeed = 0.6f;          // Speed that the screen fades to and from black.
    private float _fadeOutSpeed = 3f;
    private bool _sceneStarting = true;                      // Whether or not the scene is still fading in.
    private bool _sceneEnding = false;
	// Use this for initialization
	void Start () 
    {
        _fadeScreen = GetComponent<Image>();
        _fadeScreen.color = Color.black;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
	    // If the scene is starting...
        if(_sceneStarting)
        {   // ... call the StartScene function.
            StartScene();
        }
        if(_sceneEnding)
        {
            FadeToBlack();
        }
	}

    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        _fadeScreen.color = Color.Lerp(_fadeScreen.color, Color.clear, _fadeInSpeed * Time.fixedDeltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        _fadeScreen.color = Color.Lerp(_fadeScreen.color, Color.black, _fadeOutSpeed * Time.fixedDeltaTime);
    }

    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (_fadeScreen.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the GUITexture.
            _fadeScreen.color = Color.clear;
            _fadeScreen.enabled = false;

            // The scene is no longer starting.
            _sceneStarting = false;
        }
    }

    public void EndScene ()
    {
        // Make sure the texture is enabled.
        _fadeScreen.enabled = true;
        
        // Start fading towards black.
        _sceneEnding = true;
        
        // If the screen is almost black...
        if(_fadeScreen.color.a >= 0.95f)
            // ... reload the level.
            Application.LoadLevel(0);
    }
}

