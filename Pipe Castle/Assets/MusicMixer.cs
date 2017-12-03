using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicMixer : MonoBehaviour {

    private AudioSource music;
    private AudioSource coinSound;
    private AudioSource jumpSound;
    private AudioSource heartSound;
    private AudioSource revealSound;
    private AudioSource hitSound;
    private AudioSource hurtSound;
    private AudioSource squishSound;

     void Start()
    {
        AudioSource[] sounds = GetComponents<AudioSource>();
        music = sounds[0];
        coinSound = sounds[1];
        jumpSound = sounds[2];
        heartSound = sounds[3];
        revealSound = sounds[4];
        hitSound = sounds[5];
        hurtSound = sounds[6];
        squishSound = sounds[7];

        if (PlayerPrefs.GetInt("music", 1) == 0) 
        {
            music.Stop();
        }
    }

	// Update is called once per frame
	void Update () {
	}

    public void PlayHeart()
    {
        PlaySFX(heartSound);
    }

    public void PlayPowerUp()
    {
        PlaySFX(coinSound);
    }

    public void PlayCoin()
    {
        PlaySFX(coinSound);
    }

    public void PlayJump()
    {
        PlaySFX(jumpSound);
    }

    public void PlayReveal()
    {
        PlaySFX(revealSound);
    }

    public void PlayHit()
    {
        PlaySFX(hitSound);
    }

    public void PlayHurt()
    {
        PlaySFX(hurtSound);
    }

    public void PlaySquish()
    {
        PlaySFX(squishSound);
    }

    private void PlaySFX(AudioSource sound)
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            sound.Play();
        }
    }
}
