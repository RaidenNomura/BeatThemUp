using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioClip[] playlist;

    public AudioSource PlayerEffectSource;
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

    }
    public void PlayAttack()
    {
        PlayerEffectSource.clip = EffectSound[0];
        PlayerEffectSource.Play();
    }
}
