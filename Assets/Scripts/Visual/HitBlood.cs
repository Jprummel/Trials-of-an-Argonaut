using UnityEngine;
using System.Collections;

public class HitBlood : MonoBehaviour 
{
    void Start()
    {
        StartCoroutine(RemoveBlood(2f));
    }

    IEnumerator RemoveBlood(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }

}
