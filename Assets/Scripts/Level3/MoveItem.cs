using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
	public Rigidbody2D player;
	Vector2 lastPosition;
	private bool playerIsMoving = false;
    // Start is called before the first frame update
    void Start()
    {
    	lastPosition = player.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    	if (collision.gameObject.tag == "Player" && playerIsMoving)
    	{
    		gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    	} else 
    	{
    		gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    	}
    	// Debug.Log(player.velocity.sqrMagnitude);
    }

    // Update is called once per frame
    void Update()
    {
    	Vector2 currPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        if (lastPosition != currPosition)
        {
            playerIsMoving = true;
            lastPosition = currPosition;
        }

    }
}
