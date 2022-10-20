using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private bool NearCaveEntrance;
    private bool NearIce;
    private bool NearIceCubeButton;
    private bool NearEnding;

    [SerializeField] GameObject stairRight;
    [SerializeField] GameObject stairRighCollidert;

    [SerializeField] GameObject WoodenFloor;
    [SerializeField] GameObject WoodenFloorCollider;

    public BackPack PlayerBackpack;
    public GameObject IceBlock;
    public GameObject DisappearObject1;
    public GameObject DisappearObject2;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision) {
        NearEnding = collision.tag == "EndingArea";
        NearCaveEntrance = collision.tag == "CaveEntrance";
        NearIce = collision.tag == "Ice";
        NearIceCubeButton = collision.tag == "IceCubeButton";
    }

    void OnTriggerExit2D(Collider2D collision) {
        NearEnding = false;
        NearCaveEntrance = false;
        NearIce = false;
        NearIceCubeButton = false;
    }

    // void Start()
    // {
    //     PlayerBackpack.StoreItem("Ice");
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)) {
            if (NearCaveEntrance && PlayerBackpack.HasItem("Axe")) {
                PlayerBackpack.DestroyItem("Axe");
                DisappearObject1.SetActive(false);
                DisappearObject2.SetActive(false);
            } else if (NearIce) {
                IceBlock.SetActive(false);
                PlayerBackpack.StoreItem("Ice");
            } else if (NearIceCubeButton && PlayerBackpack.HasItem("Ice")) {
                stairRight.SetActive(true);
                stairRighCollidert.SetActive(false);
                PlayerBackpack.DestroyItem("Ice");
            } else if (NearEnding && PlayerBackpack.HasItem("Wood")) {
                PlayerBackpack.DestroyItem("Wood");
                WoodenFloor.SetActive(true);
                WoodenFloorCollider.SetActive(false);
            }
        }
    }
}
