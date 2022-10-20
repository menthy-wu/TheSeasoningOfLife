using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController2 : MonoBehaviour
{
    public GameObject winCanvas;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "FinalGem")
		{
			
			winCanvas.SetActive(true);
			Cursor.visible = true;

		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.name == "FinalGem")
		{
			
			winCanvas.SetActive(true);
			Cursor.visible = true;

		}
	}

}
