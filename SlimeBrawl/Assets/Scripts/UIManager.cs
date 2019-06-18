/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   UIManager.cs
  Description :   manage level transitions and main menu ui
  Author      :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira.Rus8080@mediadesign.school.nz
********************/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MyGameUIManager : MonoBehaviour
{
    public string LevelName;
    public string NextLevel;
    public GameObject LevelSelector;
    public GameObject ResetWindow;
    public GameObject BackGroundRestart;
    public GameObject BackGroundText;
    private bool Pause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Check", 0);
        SceneManager.LoadScene(LevelName);


    }
    public void OpenBackgroundSelectLevel()
    {
        LevelSelector.SetActive(true);
    }
    public void CloseBackgroundSelectLevel()
    {
        LevelSelector.SetActive(false);
    }
    public void EndGame()
    {

        Application.Quit();

    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void GoToNextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Check", 0);
        SceneManager.LoadScene(NextLevel);
    }
    public void GoToCredit()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Check", 0);
        SceneManager.LoadScene("Credit Scene");

    }
    public void GoToLevel1()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Check", 0);
        SceneManager.LoadScene("Level1");

    }
    public void GoToLevel2()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Check", 0);
        SceneManager.LoadScene("Level2");
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        //PlayerPrefs.SetInt ("Check", 0);//
        SceneManager.LoadScene("Opening Scene");
    }
    public void ResetData()
    {
        Time.timeScale = 1;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetWarningOpen()
    {
        ResetWindow.SetActive(true);
    }
    public void ResetWarningClose()
    {
        ResetWindow.SetActive(false);
    }
    public void PauseGame()
    {
        if (Pause == false)
        {
            BackGroundRestart.SetActive(true);
            Time.timeScale = 0;
            Pause = true;
        }
        else if (Pause == true)
        {
            BackGroundRestart.SetActive(false);
            Time.timeScale = 1;
            Pause = false;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Level1");
    }
}

