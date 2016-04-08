using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLostStory : MonoBehaviour {
    
    [SerializeField]private GameObject _buttons;
    [SerializeField]private Text _storyText;
	
	void Start () {
        StartCoroutine(GameLost());
	}

    IEnumerator GameLost()
    {
        _storyText.text = "The gods did not favor Jason on that day";
        yield return new WaitForSeconds(1);
        _storyText.text = "Pelias was still the king and his people suffered under his reign";
        yield return new WaitForSeconds(1);
        _storyText.text = "";
        yield return new WaitForSeconds(1);
        _storyText.text = "";
        yield return new WaitForSeconds(1);
        _storyText.text = "";
        yield return new WaitForSeconds(1);
        _buttons.SetActive(true);
    }

}
