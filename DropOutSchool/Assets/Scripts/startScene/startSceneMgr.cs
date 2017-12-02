using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startSceneMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
        soundMgr.instance.StartSound();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("mainScene");
        }
	}
}
