using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {
    AdjustHealth ajusthealth;
    PlayerRoll playerroll;

    [SerializeField]private AudioSource _audio;
    [SerializeField]private AudioClip _damage;
    [SerializeField]private AudioClip _death;
    [SerializeField]private AudioClip _dodge;

    void Start () {
        ajusthealth = GetComponent<AdjustHealth>();
        playerroll = GetComponent<PlayerRoll>();
        _audio = GetComponent<AudioSource>();

    }
	
	public void DeathSound ()
    {
        _audio.clip = _death;
        _audio.Play();
    }

    public void DamageSound()
    {
        _audio.clip = _damage;
        _audio.Play();
    }

    public void DodgeSound()
    {
        _audio.clip = _dodge;
        _audio.Play();
    }

}
