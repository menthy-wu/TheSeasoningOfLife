using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSeasonController : MonoBehaviour
{
	public GameObject springMap;
	public GameObject winterMap;
	public AudioManager2 am;

	
    // Update is called once per frame
    void Update()
    {
    	if (springMap.activeSelf)
    	{
    		am.PlayAudio("SpringBGM");
    	} else
    	{
    		am.PlayAudio("WinterBGM");
    	}
        

    }
}
