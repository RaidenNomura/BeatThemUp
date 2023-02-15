using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Audio : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioClip[] playlist;

    public AudioSource EffectSource;
    public AudioClip[] EffectSound;

    private int musicIndex;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = playlist[0]; //get the first song
        MusicSource.Play(); // play it
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            PlayButton();
        }
    }
    public void PlayButton()
    {
        EffectSource.clip = EffectSound[0];
        EffectSource.Play();
    }
}
