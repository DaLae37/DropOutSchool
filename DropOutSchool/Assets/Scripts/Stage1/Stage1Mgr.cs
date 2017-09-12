using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage1Mgr : MonoBehaviour {
    //게임 제어 변수
    public int mapSize;
    public bool isGameOver;

    public GameObject GameOverPopUp;
    public GameObject GameClearPopUp;

    public GameObject morning;
    public GameObject night;

    //벽 관련 변수
    public GameObject walls1;
    public GameObject walls2;
    public GameObject[] wallList = new GameObject[2];

    public static Stage1Mgr instance;
	// Use this for initialization
	void Start () {
        instance = this;
        mapSize = 5;
        isGameOver = false;
        MapGenerator();
	}
	void MapGenerator()
    {
        ////세로쪽 도로 생성
        //for(int i=0; i<mapSize + 1; i++)
        //{
        //    GameObject p_g = new GameObject("Vertical" + (i + 1));
        //    for(int j=0; j<mapSize * 4; j++)
        //    {
        //        int instNum = 0;
        //        GameObject g = Instantiate(roadList[instNum]);
        //        g.transform.Rotate(new Vector3(0, 0, 90));
        //        g.transform.position = new Vector2(-(mapSize / 2) * 22.5f + (i * 18), ((mapSize+1) * 12) - 3 * (j + 1));
        //        g.transform.SetParent(p_g.transform);
        //    }
        //    p_g.transform.SetParent(roads.transform);
        //}
        ////가로쪽 도로 생성
        //for (int i = 0; i < mapSize + 1; i++)
        //{
        //    GameObject p_g = new GameObject("Horizontal" + (i + 1));
        //    for (int j = 0; j < mapSize * 6 + 1; j++)
        //    {
        //        int instNum = 0;
        //        GameObject g = Instantiate(roadList[instNum]);
        //        g.transform.position = new Vector2(-45 + j * 3, ((mapSize + 1) * 12 - 3) - 12 * i);
        //        g.transform.SetParent(p_g.transform);
        //    }
        //    p_g.transform.SetParent(roads.transform);
        //}

        //1벽 생성
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                GameObject g = Instantiate(wallList[Random.Range(0, wallList.Length)]);
                g.transform.position = new Vector2(-(mapSize/2) * 18 + (i * 18), 3 + (mapSize - j) * 12);
                g.transform.SetParent(walls1.transform);
            }
        }
        //2벽 생성
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                GameObject g = Instantiate(wallList[Random.Range(0, wallList.Length)]);
                g.transform.position = new Vector2(-200 -(mapSize / 2) * 18 + (i * 18), 3 + (mapSize - j) * 12);
                g.transform.SetParent(walls2.transform);
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
