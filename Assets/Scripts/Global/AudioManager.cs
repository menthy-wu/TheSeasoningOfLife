using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] AudioSources;
    private Dictionary<string, int> AudioNameLookUp = new Dictionary<string, int>()
    {
        {"Default", 0},
        {"Snow", 0},
        {"Ice", 1},
        {"Grass", 2}
    };

    void Awake()
    {
        AudioSources = GetComponents<AudioSource>();
    }

    public void PlayAudio(string name) {
        AudioSource CurrentAudio = AudioSources[AudioNameLookUp[name]];
        if (!CurrentAudio.isPlaying) {
            CurrentAudio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
