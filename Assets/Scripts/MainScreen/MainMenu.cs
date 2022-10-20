using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuObject;
    public GameObject OptionMenuObject;
    public GameObject CreditsMenuObject;

    public void PlayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsClicked() {
        MainMenuObject.SetActive(false);
        OptionMenuObject.SetActive(true);
        CreditsMenuObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CreditsClicked() {
        MainMenuObject.SetActive(false);
        OptionMenuObject.SetActive(false);
        CreditsMenuObject.SetActive(true);
    }

    public void BackClicked() {
        MainMenuObject.SetActive(true);
        OptionMenuObject.SetActive(false);
        CreditsMenuObject.SetActive(false);
    }

}
