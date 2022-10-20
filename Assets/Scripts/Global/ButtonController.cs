using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ButtonController : MonoBehaviour
{
	public GameObject unclickedButton;
    public GameObject clickedButton;

    public GameObject stair;
    public GameObject cam;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                unclickedButton.SetActive(false);
                clickedButton.SetActive(true);
                stair.SetActive(true);
                cam.GetComponent<cemeraGoBack>().showStair();
            }
        }

    }
    /*
    void OnMouseDown()
    {
    	unclickedButton.SetActive(false);
    	clickedButton.SetActive(true);
    	stair.SetActive(true);
    }*/
}
