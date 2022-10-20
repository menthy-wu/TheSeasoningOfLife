using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
	public GameObject dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialog.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    	if (collision.gameObject.tag == "Player")
    	{
    		dialog.SetActive(true);
    	}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
    	if (collision.gameObject.tag == "Player")
    	{
    		dialog.SetActive(false);
    	}
    }
}
