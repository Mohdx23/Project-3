using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
{
    //TODO: you will need more data than this, like clips to play and a way to know which clip is playing
    protected AudioSource audioSource;
    [SerializeField] AudioClip[] music;

    int Songnumber = -1;

    bool isUsed = false;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music[0];
    }

    public void PlayClip()
    {
        audioSource.clip = music[Songnumber];
        audioSource.Play();
        //TODO; this is where you might want to setup and ensure the desire clip is playing on the source
    }

    void Update()
    {
        if (!audioSource.isPlaying && isUsed)
        {
            Songnumber++;

            if (Songnumber > music.Length - 1)
                Songnumber = 0;

            PlayClip();
        }
    }
    
    public override void OnUse()
    {
        base.OnUse();
        isUsed = true;

        if (Songnumber < music.Length - 1)
        {
            Songnumber++;
            PlayClip();
        }
        else
        { 
        audioSource.Stop();
        Songnumber = 0;
        isUsed = false;
        }
        
    }
        //TODO; this where we need to go to next track and start and stop playing
}
