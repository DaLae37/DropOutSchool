using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class profileSceneMgr : MonoBehaviour {
    public GameObject female;
    public GameObject male;
    public Text nameText;
    public Text schoolText;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("isFemale") == 1)
        {
            female.SetActive(true);
        }
        else
        {
            male.SetActive(true);
        }
        nameText.text = PlayerPrefs.GetString("name");
        schoolText.text = PlayerPrefs.GetString("school");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("mainScene");
    }
}
