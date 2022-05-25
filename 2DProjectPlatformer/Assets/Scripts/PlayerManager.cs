using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isGameEnd;
    public GameObject gameOverScreen;
    public static Vector2 lastCheckPointPos = new Vector2(-1, -0.2f);
    public static int numberOfBananas;
    public TextMeshProUGUI bananasText;
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;
    public GameObject pauseMenuScreen;
    public GameObject finalScreen;
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        isGameOver = false;
        isGameEnd = false;
        //GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bananasText.text = numberOfBananas.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        if (isGameEnd)
        {
            finalScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        lastCheckPointPos.x = -1f;
        lastCheckPointPos.y = -0.2f;
        numberOfBananas = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}
