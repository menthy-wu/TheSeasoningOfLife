using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level2PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public SceneManagers sm;
    public BackPack PlayerBackpack;
    public float NextSwitchCD = 1f; 
    public int TotalSeasons = 0;
    
    private float EndTimeout = 0;
    private int SeasonNumber = 0;
    
    private Vector2 movement;

    private bool onSwitchPoint = false;

    // puzzle maps
    [SerializeField]
    private PushPuzzle PuzzleMaps;

    TriangleMover Triangle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        onSwitchPoint = collision.tag == "SwitchPoint";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onSwitchPoint = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Triangle") {
            ContactPoint2D dir = collision.contacts[0];
            Triangle = collision.gameObject.GetComponent<TriangleMover>();
            bool MovedSuccessful = Triangle.MoveTo(dir.normal, PuzzleMaps.MapLookUp[Triangle.Map]);
            if (MovedSuccessful) {
                PuzzleMaps.RecalculateRayPosition(Triangle.Map, SeasonNumber % 2);
            }
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

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > EndTimeout && onSwitchPoint) {
            EndTimeout = NextSwitchCD + Time.time;
            SeasonNumber++;
            PuzzleMaps.RecalculateRayPosition("Puzzle1", SeasonNumber % 2);
            PuzzleMaps.RecalculateRayPosition("Puzzle2", SeasonNumber % 2);
            sm.ToggleMap();
        }

    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
