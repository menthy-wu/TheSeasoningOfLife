using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButtonController : MonoBehaviour
{
	public GameObject fire;
  // public GameObject otherButton;
	public GameObject fireColliders;
  // private bool buttonPressed = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
      // buttonPressed = true;
      Debug.Log(collision.gameObject.name);
      fire.SetActive(false);
      fireColliders.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      fire.SetActive(true);
      fireColliders.SetActive(true);
      

    }
}
