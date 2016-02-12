using UnityEngine;
using System.Collections;

public class RandomGen : MonoBehaviour {
	//MaxChange zodat je zelf kan aangven uit de hoeveel je een getal wilt krijgen.

	public int RandomNumber(int maxChange)
	{
		int _randomNumber = Random.Range (0, maxChange);
		return _randomNumber;
	}
}
