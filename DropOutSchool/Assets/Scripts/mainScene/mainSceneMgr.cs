using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainSceneMgr : MonoBehaviour {
    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
