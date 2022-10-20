using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pausePage;
    public GameObject RestartButton;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            pausePage.SetActive(true);
        }
    }
    public void Resume()
    {
        Cursor.visible = false;
        pausePage.SetActive(false);
    }
    public void Restart()
    {
        RestartButton.GetComponent<RestartGame>().Restart();
    }
    public void Option()
    {

    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
