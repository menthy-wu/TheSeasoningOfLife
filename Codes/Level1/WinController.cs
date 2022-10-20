using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
	// public GameObject restartButton;
	// public GameObject backpack;
	// public GameObject springMap;
	// public GameObject player;
	public GameObject winCanvas;
	public GameObject BGMAudio;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "FinalGem")
		{
			// restartButton.SetActive(false);
			// backpack.SetActive(false);
			// springMap.SetActive(false);
			// player.SetActive(false);
			BGMAudio.SetActive(false);
			winCanvas.SetActive(true);
			Cursor.visible = true;

		}
	}

}
