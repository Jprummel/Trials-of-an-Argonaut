using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameWonStory : MonoBehaviour {

    [SerializeField]private GameObject _buttons;
    [SerializeField]private Text _storyText;
	
    void Start () {
        StartCoroutine(EndGameStory());
	}

    IEnumerator EndGameStory()
    {
        _storyText.text = "And so Jason finished of the Khalkotauroi once and for all.";
        yield return new WaitForSeconds(3f);
        _storyText.text = "After the fight Jason challenged King Pelias to a duel for the throne";
        yield return new WaitForSeconds(3f);
        _storyText.text = "While King Pelias refused his people screamed and yelled at him 'Weak king, get into the arena'";
        yield return new WaitForSeconds(3f);
        _storyText.text = "He did not want to look like a weak king and before he knew it he was down there in front of Jason";
        yield return new WaitForSeconds(3f);
        _storyText.text = "However King Pelias was not a warrior and as soon as the battle began his head was rolling over the floor";
        yield return new WaitForSeconds(3f);
        _storyText.text = "Iolcos now has a new king and his name is Jason";
        yield return new WaitForSeconds(1f);
        _buttons.SetActive(true);
    }
}
