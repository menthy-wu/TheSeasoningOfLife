using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PipeMazeController : MonoBehaviour
{
	SpriteRenderer mySpriteRenderer;

	public GameObject Section1;
	public GameObject Section2;
	public GameObject Section3;
	public GameObject Section4;
	public GameObject Special1;
	public GameObject Special2;
	public GameObject Special3;


	public Sprite WaterSprite1;
	public Sprite WaterSprite2;
	public Sprite WaterSprite3;

	public Sprite EmptySprite1;
	public Sprite EmptySprite2;
	public Sprite EmptySprite3;

	public GameObject water;
	public GameObject button;
	public GameObject dirt;
	public GameObject dirtColliders;

	public GameObject autumnMap;
	public GameObject winterMap;


    // Start is called before the first frame update
    void Start()
    {
        // mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Special1.transform).localEulerAngles.z == 0 || (Special1.transform).localEulerAngles.z == 90)
        {
        	mySpriteRenderer = GameObject.Find("Special1").GetComponent<SpriteRenderer>();

        	mySpriteRenderer.sprite = WaterSprite1;
        	
        	if ((Special1.transform).localEulerAngles.z == 0)
        	{
        		Section2.SetActive(true);
        		if ((Special2.transform).localEulerAngles.z == 0 || (Special2.transform).localEulerAngles.z == 90)
        		{
        			mySpriteRenderer = GameObject.Find("Special2").GetComponent<SpriteRenderer>();
        			mySpriteRenderer.sprite = WaterSprite2;
        			if ((Special2.transform).localEulerAngles.z == 0)
        			{
        				Section3.SetActive(true);
        				if ((Special3.transform).localEulerAngles.z % 360 == 0)
        				{
        					mySpriteRenderer = GameObject.Find("Special3").GetComponent<SpriteRenderer>();
        					mySpriteRenderer.sprite = WaterSprite3;
        					if ((Special3.transform).localEulerAngles.z % 360 == 0)
        					{
        						Section4.SetActive(true);
        						button.SetActive(false);

        						if (autumnMap.activeSelf)
        						{
        							water.SetActive(true);
	        						dirt.SetActive(false);
	        						dirtColliders.SetActive(false);
	        					} 
        						
        					}
        					else 
        					{
        						Section4.SetActive(false);
        					}
        				} else
        				{
		        			mySpriteRenderer = GameObject.Find("Special3").GetComponent<SpriteRenderer>();
		        			mySpriteRenderer.sprite = EmptySprite3;
		        			Section4.SetActive(false);
        				}
        			}
        			else
        			{
        				Section3.SetActive(false);
        			}
        		} else
        		{
        			mySpriteRenderer = GameObject.Find("Special2").GetComponent<SpriteRenderer>();
        			mySpriteRenderer.sprite = EmptySprite2;
        			mySpriteRenderer = GameObject.Find("Special3").GetComponent<SpriteRenderer>();
        			mySpriteRenderer.sprite = EmptySprite3;
        			Section3.SetActive(false);
        			Section4.SetActive(false);
        		}
        	} else
        	{
        		Section2.SetActive(false);
        		Section3.SetActive(false);
        		Section4.SetActive(false);
        		// mySpriteRenderer = GameObject.Find("Special2").GetComponent<SpriteRenderer>();
        		// mySpriteRenderer.sprite = EmptySprite2;
        	}
        	
        } else 
        {
        	mySpriteRenderer = GameObject.Find("Special1").GetComponent<SpriteRenderer>();
        	mySpriteRenderer.sprite = EmptySprite1;
        	mySpriteRenderer = GameObject.Find("Special2").GetComponent<SpriteRenderer>();
        	mySpriteRenderer.sprite = EmptySprite2;
        	mySpriteRenderer = GameObject.Find("Special3").GetComponent<SpriteRenderer>();
        	mySpriteRenderer.sprite = EmptySprite3;

        	Section2.SetActive(false);
        	Section3.SetActive(false);
        	Section4.SetActive(false);
        	// Special2.SetActive(false);
        	// emptySpecial2.SetActive(true);
        }
    }
}
