using UnityEngine;
using System.Collections;

public class BullSound : MonoBehaviour {

    [SerializeField]private AudioSource _audio;
    [SerializeField]private AudioClip   _hitbull;
    [SerializeField]private AudioClip _pillar;
    // Use this for initialization
    void Start () {
        _audio = GetComponent<AudioSource>();
    }

    public void HitBullSound()
    {
        _audio.clip = _hitbull;
        _audio.Play();
    }

    public void PillarHitSound()
    {
        _audio.clip = _pillar;
        _audio.Play();
    }
}
