using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainScene(string SceneToLoad)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneToLoad);
        
        
    }
    public void QuitScene()
    {
        Application.Quit(); // This line quits the application.
    }

}
