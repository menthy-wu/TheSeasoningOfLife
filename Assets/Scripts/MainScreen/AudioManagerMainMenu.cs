using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMainMenu : MonoBehaviour
{
    public AudioSource sound;
    public List<AudioClip> clips = new List<AudioClip>();
    private Dictionary<string, int> AudioLookUp = new Dictionary<string, int>()
    {
    	{"hover", 0},
    	{"clicked", 1}
    };

    public void PlayAudio(string name) {
    	sound.clip = clips[AudioLookUp[name]];
    	sound.Play();
    }

}
