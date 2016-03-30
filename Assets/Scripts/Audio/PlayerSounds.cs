using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {
                    
                    private AdjustHealth adjustHealth;
                    private PlayerRoll playerRoll;

    [SerializeField]private AudioSource _audio;
    [SerializeField]private AudioClip   _damage;
    [SerializeField]private AudioClip   _death;
    [SerializeField]private AudioClip   _dodge;

    void Start () {
        adjustHealth    = GetComponent<AdjustHealth>();
        playerRoll      = GetComponent<PlayerRoll>();
        _audio          = GetComponent<AudioSource>();

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
