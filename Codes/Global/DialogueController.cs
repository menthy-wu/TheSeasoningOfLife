
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueController : MonoBehaviour
{
    public float delay = 0.02f;
    public string fullText;
    bool start = false;
    // private string currentText = "";

    public TextMeshProUGUI displayText;

    void Start()
    {
        // Debug.Log(fullText);
        //StartCoroutine(ShowText());
    }
    private void OnDisable()
    {
        start = false;
    }
    private void Update()
    {
       if(!start)
        {
            displayText.text = "";
            StartCoroutine(ShowText());
            start = true;
        }
    }
    IEnumerator ShowText()
    {
        foreach(char letter in fullText.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(delay);

        }
    }
}