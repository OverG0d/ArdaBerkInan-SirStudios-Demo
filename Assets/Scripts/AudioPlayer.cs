using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;

    public AudioSource source;
    public static AudioPlayer Instance { get { return instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        //Plays the passed in clip at a specific volume
        source.PlayOneShot(clip, volume);
    }

}
