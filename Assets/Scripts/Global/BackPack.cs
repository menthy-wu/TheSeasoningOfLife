using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    [SerializeField] GameObject bag1;
    [SerializeField] GameObject bag2;
    [SerializeField] GameObject bag3;
    [SerializeField] GameObject bag4;
    [SerializeField] GameObject bag5;
    [SerializeField] GameObject bag6;
    public GameObject BackpackObject;
    public int BackpackSize = 6;
    GameObject[] boxes;
    GameObject[] Slots;

    public List<GameObject> _ItemList = new List<GameObject>();
    private Dictionary<string, GameObject> ItemList = new Dictionary<string, GameObject>(); 

    public int SelectedItemSlot = 0;


    void Start()
    {
        boxes = new GameObject[6] { bag1, bag2, bag3, bag4, bag5, bag6 };
        Slots = new GameObject[6];

        // initializing item list
        // Current list:
        // "Empty"
        // "Berry"

        foreach(GameObject item in _ItemList) {
            ItemList.Add(item.name, item);
        }

        // initializing backpack
        for(int i = 0; i < BackpackSize; i++)
            Slots[i] = ItemList["Empty"];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchSlotTo(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchSlotTo(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SwitchSlotTo(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            SwitchSlotTo(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            SwitchSlotTo(4);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            SwitchSlotTo(5);
    }
    public void deleteStuff(int num)
    {
        Destroy(Slots[num]);
    }

    public string GetSelectedSlotItemName() {
        return Slots[SelectedItemSlot].name;
    }

    public void RemoveSelectedSlotItem() {
        Destroy(Slots[SelectedItemSlot]);
        Slots[SelectedItemSlot] = ItemList["Empty"];
    }

    public void SwitchSlotTo(int num)
    {
        SelectedItemSlot = num;
    }

    public void StoreItem(string name)
    {
        if(BackpackIsFull()) return;
        for (int i = 0; i < 6; i++)
        {
            if (Slots[i].name == "Empty")
            {
                GameObject _TempObejct = Instantiate(ItemList[name]);
                _TempObejct.name = name; // overwrite the "(clone)" that's added
                Slots[i] = _TempObejct;
                Slots[i].transform.position = boxes[i].transform.position;
                Slots[i].transform.SetParent(BackpackObject.transform);
                break;
            }
        }
    }

    public bool BackpackIsFull() {
        return getBackpackSize() >= 6;
    }

    public bool HasItem(string name) {
        foreach(GameObject Slot in Slots) {
            if (Slot.name == name) return true;
        }
        return false;
    }

    public void DestroyItem(string name) {
        for(int i = 0; i < Slots.Length; i++) {
            if (Slots[i].name == name) {
                Destroy(Slots[i]);
                Slots[i] = ItemList["Empty"];
            }
        }
    }

    public int getBackpackSize() {
        int size = 0;
        foreach(GameObject Slot in Slots) {
            if (Slot.name != "Empty") size++;
        }
        return size;
    }
}
