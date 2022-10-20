using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController3 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public SceneManagers sm;

    public float NextSwitchCD = 1f; 
    public int TotalSeasons = 0;
    
    private float EndTimeout = 0;
    private int SeasonNumber = 0;
    
    private Vector2 movement;

    private bool onSwitchPoint = false;
    private bool NearBottle = false;

    public GameObject magicAnimation;

    public GameObject startingDialog;

    public GameObject bridge;
    public GameObject disableOnBridgeActive;
    public GameObject boxCollider;
    public GameObject bottle;
    public GameObject canvasBottle;



    private void OnTriggerStay2D(Collider2D collision)
    {
        onSwitchPoint = collision.tag == "SwitchPoint";
        NearBottle = collision.gameObject.name == "bottle";

        if (collision.name == "pumpkin" || collision.name == "pie" || collision.name == "pot" || collision.name == "sprite")
        {
            boxCollider.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onSwitchPoint = false;
        NearBottle = collision.gameObject.name == "bottle";
        if (collision.name == "pumpkin" || collision.name == "pie" || collision.name == "pot" || collision.name == "sprite")
        {
            boxCollider.SetActive(false);
        }

    }
    void Start() {
        EndTimeout = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.Space) && Time.time > EndTimeout && onSwitchPoint) {
            EndTimeout = NextSwitchCD + Time.time;
            SeasonNumber++;
            GameObject magic = Instantiate(magicAnimation);
            magic.transform.position = transform.position;
            sm.ToggleMap();
        }

        if (Input.anyKey)
        {
            startingDialog.SetActive(false);
        }

        if (bridge.activeSelf)
        {
            disableOnBridgeActive.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if (NearBottle)
            {
                bottle.SetActive(false);
                canvasBottle.SetActive(true);
            }
        }

    }


    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
