using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAnimationSwitch : MonoBehaviour
{
    [SerializeField] float remainTime = 3;
    void Start()
    {
        Destroy(gameObject, remainTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
