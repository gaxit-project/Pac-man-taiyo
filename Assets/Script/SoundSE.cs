using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SoundSE : MonoBehaviour
{
    public static AudioClip[] sound;
    public AudioClip[] sound_se;

    public static AudioSource audioSource_tmp;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        audioSource_tmp = audioSource;
        sound = new AudioClip[sound_se.Length];


        for (int i = 0; i < sound_se.Length; i++)
        {
            sound[i] = sound_se[i];
        }
    }

    public static void cookie()
    {
        audioSource_tmp.PlayOneShot(sound[0]);
    }
    public static void eatghost()
    {
        audioSource_tmp.PlayOneShot(sound[1]);
    }
    public static void gogame()
    {
        audioSource_tmp.PlayOneShot(sound[2]);
    }
    public static void start()
    {
        audioSource_tmp.PlayOneShot(sound[3]);
    }
}