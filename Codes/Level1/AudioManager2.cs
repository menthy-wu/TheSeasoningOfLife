using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public AudioSource sound;
	public List<AudioClip> clips = new List<AudioClip>();
    private Dictionary<string, int> AudioNameLookUp = new Dictionary<string, int>()
    {
        {"SpringBGM", 0},
        {"WinterBGM", 1}
    };

    public void PlayAudio(string name) {
        sound.clip = clips[AudioNameLookUp[name]];
        sound.Play();
    }

}
