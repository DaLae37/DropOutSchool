using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainSceneMgr : MonoBehaviour {
    public GameObject tutorialPanel;
    private void Start()
    {
        if(!PlayerPrefs.HasKey("profile"))
        {
            tutorialPanel.SetActive(true);
        }
    }
    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void profileScene()
    {
        SceneManager.LoadScene("tutorialScene");
    }
    public void settingScene()
    {
        SceneManager.LoadScene("settingScene");
    }
}
