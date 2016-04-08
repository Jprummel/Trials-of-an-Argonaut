using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryIntro : MonoBehaviour {
    [SerializeField]private Text        _introText;
    [SerializeField]private Image       _loadingBar;
    [SerializeField]private AudioSource _introVoice;
                    private bool        _isLoadingGame;
                    private AsyncOperation async = null;
	
    void Start () 
    {
        StartCoroutine(Introduction());
	}

    void Update()
    {
        SkipIntro();
        if(_isLoadingGame)
        {
            StopCoroutine(Introduction());
            _introText.text = "Loading...";

            if(async != null)
            {
                _loadingBar.fillAmount = async.progress;
            }
        }

    }

    IEnumerator Introduction()
    {
        if (!_isLoadingGame)
        {
            yield return new WaitForSeconds(2);
            if (!_isLoadingGame)
            {
                _introVoice.Play();
                _introText.text = "Jason - the leader of the Argonauts - was captured during his adventure to retrieve the Golden Fleece.";
            }
            yield return new WaitForSeconds(5);
            _introText.text = "";
            yield return new WaitForSeconds(0.2f);
            if (!_isLoadingGame)
            {
                _introText.text = "He was captured by King Pelias.";
            }
            yield return new WaitForSeconds(2);
            _introText.text = "";
            yield return new WaitForSeconds(0.2f);
            if (!_isLoadingGame)
            {
                _introText.text = "Jason had to get the Golden Fleece in order to reclaim his throne...";
            }
            yield return new WaitForSeconds(3.5f);
            _introText.text = "";
            yield return new WaitForSeconds(0.2f);
            if (!_isLoadingGame)
            {
                _introText.text = "And become the rightful king of Iolcos";
            }
            yield return new WaitForSeconds(2);
            _introText.text = "";
            yield return new WaitForSeconds(0.2f);
            if (!_isLoadingGame)
            {
                _introText.text = "King Pelias however did not want to resign his throne.";
            }
            yield return new WaitForSeconds(3.3f);
            _introText.text = "";
            yield return new WaitForSeconds(0.2f);
            if (!_isLoadingGame)
            {
                _introText.text = "Because of this, King Pelias arranged a fight between Jason and the Khalkotauroi bull to get rid of Jason forever.";
            }
            yield return new WaitForSeconds(6.3f);
            _introText.text = "";
            yield return new WaitForSeconds(1f);
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        _introText.text = "Loading...";
        yield return new WaitForSeconds(1f);
        _loadingBar.fillAmount += 0.1f;
        yield return new WaitForSeconds(1f);
        _loadingBar.fillAmount += 0.1f;
        async = Application.LoadLevelAsync(2);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }

    void SkipIntro()
    {
        if (Input.anyKeyDown && !_isLoadingGame)
        {
            _isLoadingGame = true;
            _introVoice.Stop();
            StopCoroutine(Introduction());
            StartCoroutine(LoadLevel());
        }
    }
}
