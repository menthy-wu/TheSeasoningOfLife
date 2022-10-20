using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController3 : MonoBehaviour
{
 //    public GameObject restartButton;
	// public GameObject autumnMap;
	// public GameObject player;
	public GameObject winCanvas;
	public GameObject BGMAudio;
	// public GameObject sceneObjects;
	// public GameObject finalGem;
	// public GameObject switchPoints;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "FinalGem")
		{
			// restartButton.SetActive(false);
			// autumnMap.SetActive(false);
			// player.SetActive(false);
			BGMAudio.SetActive(false);
			winCanvas.SetActive(true);
			Cursor.visible = true;
			// sceneObjects.SetActive(false);
			// finalGem.SetActive(false);
			// switchPoints.SetActive(false);

		}
	}
}
