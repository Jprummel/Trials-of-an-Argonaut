using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour {

    [SerializeField]private GameObject[]    _bloodParticles;
    [SerializeField]private Transform       _particleSpawnPoint;

    public void SpawnParticles(int particleIndex)
    {
        GameObject bloodParticles       = (GameObject)Instantiate(_bloodParticles[particleIndex], _particleSpawnPoint.position, _bloodParticles[particleIndex].transform.rotation) as GameObject;
        bloodParticles.transform.parent = _particleSpawnPoint.transform;
    }
}
