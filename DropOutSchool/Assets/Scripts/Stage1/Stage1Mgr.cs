using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage1Mgr : MonoBehaviour {
    bool [][]roadData = new bool[10][];
    bool[][] mapData = new bool[10][];
    public bool isGameOver;
    public GameObject tiles;
    public GameObject GameOverPopUp;
    public GameObject GameClearPopUp;
    public static Stage1Mgr instance;
	// Use this for initialization
	void Start () {
        instance = this;
        isGameOver = false;
        for (int i=0; i<mapData.Length; i++)
        {
            roadData[i] = new bool[10];
            mapData[i] = new bool[10];
            for (int j = 0; j < mapData[i].Length; j++)
            {
                
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void unHideClearPoP()
    {
        GameClearPopUp.SetActive(true);
    }
    public void unHideGameOverPoP()
    {
        GameOverPopUp.SetActive(true);
    }
    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }
}
