using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeButtonController : MonoBehaviour
{
	public GameObject pipe1;
	public GameObject pipe2;
	public GameObject pipe3;
    SpriteRenderer mySpriteRenderer;

    private bool pipeFilled1 = false;
    private bool pipeFilled2 = false;
    private bool pipeFilled3 = false;

    public GameObject winterMap;
    public GameObject autumnMap;

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (autumnMap.activeSelf)
                {
                    pipe1.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                    pipe2.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                    pipe3.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                } else
                {
                    if (!pipeFilled1)
                    {
                        pipe1.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                    }
                    if (!pipeFilled2)
                    {
                        pipe2.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                    }
                    if (!pipeFilled3)
                    {
                        pipe3.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                    }
                }
                
            }
        }

    }

    void Update()
    {

        if (GameObject.Find("Special1").GetComponent<SpriteRenderer>().sprite.name == "pipeSpriteSheet_3")
        {
            pipeFilled1 = true;
        } 

        mySpriteRenderer = GameObject.Find("Special2").GetComponent<SpriteRenderer>();
        if (mySpriteRenderer.sprite.name == "pipeSpriteSheet_4")
        {
            pipeFilled2 = true;
        } 

        mySpriteRenderer = GameObject.Find("Special3").GetComponent<SpriteRenderer>();
        if (mySpriteRenderer.sprite.name == "pipeSpriteSheet_2")
        {
            pipeFilled3 = true;
        }

    }



}
