using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonShowDialogue : MonoBehaviour
{
	public GameObject dialog;
    public GameObject dialog2;
    public GameObject fence;
    private bool pumpkinGiven = false;


	public GameObject pie;

    private float interval = 5f;

    private float timer = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
    	if (collision.gameObject.tag == "Player" && !pumpkinGiven)
    	{
    		dialog.SetActive(true);
    	} else if (collision.collider.gameObject.name == "pie")
        {
            pumpkinGiven = true;
            pie.SetActive(false);
            dialog2.SetActive(true);
            timer = 0;
            fence.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialog.SetActive(false);
            
        } else if (collision.collider.gameObject.name == "pie")
        {
            pie.SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            dialog2.SetActive(false);
        }

    }

    
}
