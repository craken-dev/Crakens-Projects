using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject ambient_music;
    [SerializeField] private GameObject death_music;
    [SerializeField] private AudioClip death_sound;

    public void DieBirdSong()
    {
        ambient_music.SetActive(false);
        death_music.SetActive(true);
    }

    public void HitSound()
    {
        death_music.GetComponent<AudioSource>().PlayOneShot(death_sound);
    }
}
