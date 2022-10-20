using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager2 : MonoBehaviour
{
    public GameObject MapOne;
    public GameObject MapTwo;
    private bool Toggled;
    public GameObject DisappearInMapOneCollider;
    public GameObject ParticleEffects;

    
    void Start() {
        Toggled = MapOne.activeSelf;

    }

    public void ToggleMap() {
        MapOne.SetActive(!Toggled);
        MapTwo.SetActive(Toggled);
        DisappearInMapOneCollider.SetActive(!Toggled);
        ParticleEffects.SetActive(Toggled);
        Toggled = !Toggled;

    }
}
