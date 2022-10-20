using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagers : MonoBehaviour
{
    public GameObject MapOne;
    public GameObject MapTwo;
    private bool Toggled;
    public GameObject DisappearInMapOneCollider;
    public GameObject ParticleEffects;
    public AudioManager2 am;

    
    void Start() {
        Toggled = MapOne.activeSelf;
        am.PlayAudio("SpringBGM");

    }

    public void ToggleMap() {
        MapOne.SetActive(!Toggled);
        MapTwo.SetActive(Toggled);
        DisappearInMapOneCollider.SetActive(!Toggled);
        ParticleEffects.SetActive(Toggled);
        Toggled = !Toggled;
        if (MapOne.activeSelf)
        {
            am.PlayAudio("SpringBGM");
        } else
        {
            am.PlayAudio("WinterBGM");
        }
    }
}
