using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cemeraGoBack : MonoBehaviour
{
    CinemachineVirtualCamera cmvc;
    public GameObject player;
    public GameObject stairs;
    public GameObject gem;

    void Start()
    {
         cmvc = GetComponent<CinemachineVirtualCamera>();
        StartCoroutine("ShowPlayer");
    }
    void Update()
    {
    }
    public void showStair()
    {
        cmvc.Follow = stairs.transform;
        StartCoroutine("ShowPlayer");
    }
    IEnumerator ShowPlayer()
    {
        yield return new WaitForSeconds(2f);
        cmvc.Follow = player.transform;
    }
    IEnumerator showGem()
    {
        yield return new WaitForSeconds(2f);
        cmvc.Follow = gem.transform;
    }
}
