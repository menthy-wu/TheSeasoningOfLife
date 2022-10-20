using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectWater : MonoBehaviour
{
	public GameObject canvasBottle;
	public GameObject collectDialog;
	public Image canvasBottleImage;
	public Sprite bottle0;
	public Sprite bottle1;
	public Sprite bottle2;
	public Sprite bottle3;
	public Sprite bottle4;
	public Sprite bottle5;

	private int currWaterLevel = 0;

	private void OnCollisionStay2D(Collision2D collision)
    {
        if (canvasBottle.activeSelf)
        {
        	collectDialog.SetActive(true);
        	if (Input.GetKeyDown(KeyCode.J) && currWaterLevel < 5)
            {
                currWaterLevel++;
                // Debug.Log(currWaterLevel);
                if (currWaterLevel == 0)
                {
                	canvasBottleImage.sprite = bottle0;
                } else if (currWaterLevel == 1)
                {
                	canvasBottleImage.sprite = bottle1;
                } else if (currWaterLevel == 2)
                {
                	canvasBottleImage.sprite = bottle2;
                } else if (currWaterLevel == 3)
                {
                	canvasBottleImage.sprite = bottle3;
                } else if (currWaterLevel == 4)
                {
                	canvasBottleImage.sprite = bottle4;
                } else
                {
                	currWaterLevel = 5;
                	canvasBottleImage.sprite = bottle5;
                }
            }
        }
    }
	private void OnCollisionExit2D(Collision2D collision)
    {
        collectDialog.SetActive(false);
    }


}
