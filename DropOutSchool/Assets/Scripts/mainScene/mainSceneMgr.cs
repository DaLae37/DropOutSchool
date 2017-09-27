using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainSceneMgr : MonoBehaviour {
    private void Start()
    {
        if(PlayerPrefs.GetInt("profile") != 1)
        {
            SceneManager.LoadScene("tutorialScene");
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
}
