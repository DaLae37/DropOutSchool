using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundMgr: MonoBehaviour {
    public static soundMgr instance;
    public AudioSource audio;
    public AudioClip game;
    public AudioClip start;
    public AudioClip crash;
    public AudioClip skill;
	// Use this for initialization
	void Awake () {
        audio = gameObject.AddComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartSound()
    {
        audio.clip = start;
        audio.loop = true;
        audio.Play();
    }

    public void GameSound()
    {
        audio.clip = game;
        audio.loop = true;
        audio.Play();
    }

    public void Skill()
    {
        audio.PlayOneShot(skill);
    }

    public void Crashed()
    {
        audio.PlayOneShot(crash);
    }
}
