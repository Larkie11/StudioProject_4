using UnityEngine;
using System.Collections;

public class SFXVolume : MonoBehaviour
{
    AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("Vol", audio.volume);
    }
}
