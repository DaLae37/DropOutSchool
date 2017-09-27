using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class selectSceneMgr : MonoBehaviour {
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void profileScene()
    {
        SceneManager.LoadScene("profileScene");
    }
    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
}
