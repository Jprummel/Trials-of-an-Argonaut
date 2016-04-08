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
        _storyText.text = "King Pelias did not feel much for the idea of a battle with Jason.";
        yield return new WaitForSeconds(3f);
        _storyText.text = "But after a hefty chant from the audience 'Finish him! show him who he is dealing with!' Pelias had no choice but to face Jason. ";
        yield return new WaitForSeconds(3f);
        _storyText.text = "The fight wasn't much of a spectacle as Jason almost instantly forced Pelias down to his knees and removed his head with a single swift cut";
        yield return new WaitForSeconds(3f);
        _storyText.text = "Iolcos now has a new king and his name is Jason";
        yield return new WaitForSeconds(1f);
        _buttons.SetActive(true);
    }
}
