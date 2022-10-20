using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePumpkinPie : MonoBehaviour
{

    SpriteRenderer mySpriteRenderer;
	public GameObject pumpkin;
	public GameObject pot;
	// public GameObject pumpkinPot;
	public GameObject pie;
	public GameObject fire;
	public GameObject fence;
	// public GameObject personDialog;


	private bool pumpkinIsCooking = false;

	private float interval = 3f;

    private float timer = 0;

    public Sprite potWithPumpkin;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    	if (collision.collider.gameObject.name == "pumpkin" && fire.activeSelf)
    	{
    		pumpkinIsCooking = true;
            mySpriteRenderer.sprite = potWithPumpkin;
    		pumpkin.SetActive(false);
    		// pumpkinPot.SetActive(true);

    		timer = 0;
    	}
    }

    public void makePie()
    {
    	if (pumpkinIsCooking)
    	{
    		pie.SetActive(true);
    		pot.SetActive(false);
    	}
    }

    void Update()
    {
    	timer += Time.deltaTime;
    	if (timer > interval)
        {
        	makePie();
        }

    }

}
