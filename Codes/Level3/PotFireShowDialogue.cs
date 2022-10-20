using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotFireShowDialogue : MonoBehaviour
{
    public GameObject dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "pot")
        {
            dialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "pot")
        {
            dialog.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    	if (collision.collider.gameObject.name == "pot")
    	{
    		dialog.SetActive(true);
    	}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    	if (collision.collider.gameObject.name == "pot")
    	{
    		dialog.SetActive(false);
    	}
    }
}
