using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Stage1Mgr : MonoBehaviour {
    //학교 이름
    public Text txt1;
    public Text txt2;

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
    public GameObject[] morningWallList = new GameObject[2];
    public GameObject[] nightWallList = new GameObject[2];
    public const int WALL_H_SIZE = 18;
    public const int WALL_V_SIZE = 12;
    public static Stage1Mgr instance;

    //장애물 관련 변수
    List<int> blockXpos = new List<int>();
    List<int> blockYpos = new List<int>();

    public GameObject[] blockList = new GameObject[4];

    //시간 관련 변수
    float timer;
    public GameObject Hour;
    public GameObject Minute;

    // Use this for initialization
    bool isIn(int pos, bool isX)
    {
        if (isX)
        {
            for(int i=pos-3; i<pos+3; i++)
            {
                if (blockXpos.Contains(i))
                    return true;
            }
        }
        else
        {
            for (int i = pos - 3; i < pos + 3; i++)
            {
                if (blockYpos.Contains(i))
                    return true;
            }
        }
        return false;
    }
    void Start() {
        soundMgr.instance.GameSound();
        instance = this;

        string schoolName = PlayerPrefs.GetString("school");
        for (int i = 0; i < schoolName.Length; i++)
        {
            txt1.text += schoolName[i] + "\n";
        }
        txt2.text = txt1.text;

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
                int z = Random.Range(0, 2);
                GameObject g1 = Instantiate(morningWallList[z]);
                g1.transform.position = new Vector2(-(mapSize / 2) * 18 + (i * 18), 3 + (mapSize - j) * 12);
                g1.transform.SetParent(walls1.transform);
                GameObject g2 = Instantiate(nightWallList[z]);
                g2.transform.position = new Vector2(-200 - (mapSize / 2) * 18 + (i * 18), 3 + (mapSize - j) * 12);
                g2.transform.SetParent(walls2.transform);
            }
        }
        int minX = -(mapSize * WALL_H_SIZE / 2);
        int minY = 9 + (WALL_V_SIZE * mapSize);
        //장애물 생성1
        for (int i = 0; i < mapSize + 4; i++)
        {
            int posX = minX + i * WALL_H_SIZE;
            int posY = Random.Range(9, minY + 1);
            GameObject g = Instantiate(blockList[Random.Range(0, 3)]);
            blockXpos.Add(posX);
            blockYpos.Add(posY);
            g.transform.position = new Vector3(posX, posY, -0.2f);
            g.transform.GetChild(0).gameObject.SetActive(true);

            int NposX = minX + i * WALL_H_SIZE - 200;
            int NposY;
            do
            {
                NposY = Random.Range(9, minY + 1);
            } while (!isIn(NposY,false));
            GameObject gz = Instantiate(blockList[Random.Range(0, 3)]);
            blockXpos.Add(NposX);
            blockYpos.Add(NposY);
            gz.transform.position = new Vector3(NposX, NposY, -0.2f);
            gz.transform.GetChild(1).gameObject.SetActive(true);
        }
        //장애물 생성2
        for (int i = 0; i < mapSize + 4; i++)
        {
            int posX = Random.Range(minX, minX * -1 + 1);
            int posY = minY - i * WALL_V_SIZE;
            GameObject g = Instantiate(blockList[Random.Range(0, 3)]);
            blockXpos.Add(posX);
            blockYpos.Add(posY);
            g.transform.position = new Vector3(posX, posY, -0.2f);
            g.transform.GetChild(0).gameObject.SetActive(true);

            int NposX;
            int NposY = minY - i * WALL_V_SIZE;
            do
            {
                NposX = Random.Range(minX, minX * -1 + 1) - 200;
            } while (!isIn(NposX, true));
            GameObject gz = Instantiate(blockList[Random.Range(0, 3)]);
            blockXpos.Add(NposX);
            blockYpos.Add(NposY);
            gz.transform.position = new Vector3(NposX, NposY, -0.2f);
            gz.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
        if (PlayerCtrl.instance.isStarted)
        {
            timer += Time.deltaTime;
            Hour.transform.Rotate(new Vector3(0, 0, -0.5f * Time.deltaTime));
            Minute.transform.Rotate(new Vector3(0, 0, -6 * Time.deltaTime));
            if (timer >= 60.0f)
            {
                isGameOver = true;
                PlayerCtrl.instance.PlayerOff();
            }
        }
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
        soundMgr.instance.StartSound();
        SceneManager.LoadScene("selectScene");
    }
}
