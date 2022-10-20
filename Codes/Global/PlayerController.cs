using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public SceneManagers sm;
    public Tilemap AudioLayer1;
    public Tilemap AudioLayer2;
    public AudioManager am;
    public BackPack PlayerBackpack;
    public float NextSwitchCD = 1f; 
    public int TotalSeasons = 0;
    
    private float EndTimeout = 0;
    private int SeasonNumber = 0;
    
    private Vector2 movement;
    public GameObject specialCollider;
    public GameObject BearObject;
    public GameObject SwitchUnderBearObject;

    private bool onSwitchPoint = false;
    private bool NearBerryTree = false;
    private bool NearBear = false;

    public GameObject startingDialog;
    public GameObject magicAnimation;
    private void OnTriggerStay2D(Collider2D collision)
    {
        onSwitchPoint = collision.tag == "SwitchPoint";
        NearBerryTree = collision.tag == "BerryTree";
        NearBear = collision.tag == "Bear";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onSwitchPoint = collision.tag != "SwitchPoint";
        NearBerryTree = collision.tag == "BerryTree";
        NearBear = collision.tag == "Bear";
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
            GameObject magic = Instantiate(magicAnimation);
            magic.transform.position= transform.position;
            EndTimeout = NextSwitchCD + Time.time;
            SeasonNumber++;
            sm.ToggleMap();
        }

        if (movement.sqrMagnitude > 0.01) {
            if (SeasonNumber % TotalSeasons == 0) { // scene one
                am.PlayAudio(GetTileName(AudioLayer1));
            } else if(SeasonNumber % TotalSeasons == 1) {
                am.PlayAudio(GetTileName(AudioLayer2));
            }
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if (NearBerryTree) {
                PlayerBackpack.StoreItem("Berry");
            } else if (NearBear) {
                if(PlayerBackpack.GetSelectedSlotItemName() == "Berry") { // helping bear
                    PlayerBackpack.RemoveSelectedSlotItem();
                    BearObject.SetActive(false);
                    SwitchUnderBearObject.SetActive(true);
                }
            }
        }

        if (GameObject.Find("stair1") != null && GameObject.Find("stair2") != null && GameObject.Find("stair3") != null)
        {
            specialCollider.SetActive(false);
        } else {
            specialCollider.SetActive(true);
        }
        if (Input.anyKey)
        {
            startingDialog.SetActive(false);
        }

    }

    string GetTileName(Tilemap AudioLayer) {
        TileBase tb = AudioLayer.GetTile(AudioLayer.WorldToCell(transform.position));
        if (tb != null) return tb.name;
        return "Default"; 
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
