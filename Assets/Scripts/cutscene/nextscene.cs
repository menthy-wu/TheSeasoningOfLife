using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
    [SerializeField] GameObject lastText;
    [SerializeField] GameObject pressAny;
    bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void goToNextScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    // Update is called once per frame
    void Update()
    {
        if(lastText.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            pressAny.SetActive(true);
            end = true;
        }
        if(end)
        {
            if(Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
