using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairButtonControler : MonoBehaviour
{
    [SerializeField] GameObject stairLeft;
    [SerializeField] GameObject stairLeftCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        stairLeft.SetActive(true);
        stairLeftCollider.SetActive(false);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        stairLeft.SetActive(false);
        stairLeftCollider.SetActive(true);
    }
}
