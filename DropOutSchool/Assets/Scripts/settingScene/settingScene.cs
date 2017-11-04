using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingScene : MonoBehaviour {
    public GameObject soundPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleSoundPanel()
    {
        if (soundPanel.activeSelf)
            soundPanel.SetActive(false);
        else
            soundPanel.SetActive(true);
    }
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
}
