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

    //벽 관련 변수
    public GameObject walls;
    public GameObject[] wallList = new GameObject[2];
    enum WALL_NUM
    {
        STRAIGHT,
        CROSS,
        TURN,
        THREE_POINT
    }

    //길 관련 변수
    public GameObject roads;
    public GameObject[] roadList = new GameObject[4];

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
        //세로쪽 도로 생성
        for(int i=0; i<mapSize + 1; i++)
        {
            GameObject p_g = new GameObject("Vertical" + (i + 1));
            for(int j=0; j<mapSize * 4; j++)
            {
                int instNum = 0;
                GameObject g = Instantiate(roadList[instNum]);
                g.transform.Rotate(new Vector3(0, 0, 90));
                g.transform.position = new Vector2(-(mapSize / 2) * 22.5f + (i * 18), ((mapSize+1) * 12) - 3 * (j + 1));
                g.transform.SetParent(p_g.transform);
            }
            p_g.transform.SetParent(roads.transform);
        }
        //가로쪽 도로 생성
        for (int i = 0; i < mapSize + 1; i++)
        {
            GameObject p_g = new GameObject("Horizontal" + (i + 1));
            for (int j = 0; j < mapSize * 6; j++)
            {
                int instNum = 0;
                GameObject g = Instantiate(roadList[instNum]);
                g.transform.position = new Vector2(-45 + j * 3, ((mapSize + 1) * 12 - 3) - 12 * i);
                g.transform.SetParent(p_g.transform);
            }
            p_g.transform.SetParent(roads.transform);
        }
        //벽 생성
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                GameObject g = Instantiate(wallList[Random.Range(0, wallList.Length)]);
                g.transform.position = new Vector2(-(mapSize/2) * 18 + (i * 18), 3 + (mapSize - j) * 12);
                g.transform.SetParent(walls.transform);
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
