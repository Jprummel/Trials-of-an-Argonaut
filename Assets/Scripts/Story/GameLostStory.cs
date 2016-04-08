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
        yield return new WaitForSeconds(3f);
        _storyText.text = "Pelias remained the king and his people suffered under his reign";
        yield return new WaitForSeconds(5f);
        _storyText.text = "Maybe next time the gods will send a real hero.";
        yield return new WaitForSeconds(4f);
        _storyText.text = "";
        _buttons.SetActive(true);
    }

}
