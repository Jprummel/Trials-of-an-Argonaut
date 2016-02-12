using UnityEngine;
using System.Collections;

public class VoorbeeldRandomNumber : MonoBehaviour {


	private int randomGained;
	[SerializeField] private int _MissChance;
	[SerializeField] private int _BetweenChance;
	RandomGen randomGen;


	void Start () {
		randomGen = GetComponent<RandomGen>();

	}
	void Update()
	{
		Miss ();

	}

	void Miss()
	{
		randomGained = randomGen.RandomNumber (_BetweenChance);
		if (randomGained > _MissChance) 
		{
			Debug.Log ("Hallo ik ben meer dan  " + _MissChance+ " " + randomGained);
		}
	}
}
