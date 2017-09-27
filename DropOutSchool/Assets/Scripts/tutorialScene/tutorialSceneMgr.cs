using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class tutorialSceneMgr : MonoBehaviour {

    public GameObject genderPoP;
    public GameObject gender;
    public GameObject namePoP;
    public GameObject namePanel;
    public GameObject FemaleImage;
    public GameObject MaleImage;
    public Text nameText;
    public Text schoolText;
    bool isFemale;
	// Use this for initialization
	void Start () {
        isFemale = false;
        if (PlayerPrefs.HasKey("isFemale"))
        {
            gender.SetActive(false);
            namePanel.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Female()
    {
        isFemale = true;
        unHideGenderPopUp();
    }
    public void Male()
    {
        isFemale = false;
        unHideGenderPopUp();
    }
    public void Yes()
    {
        if (isFemale)
        {
            PlayerPrefs.SetInt("isFemale", 1);
            FemaleImage.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("isFemale", 0);
            MaleImage.SetActive(true);
        }
        HideGenderPopUp();
        gender.SetActive(false);
        namePanel.SetActive(true);
    }
    public void HideGenderPopUp()
    {
        genderPoP.SetActive(false);
    }
    public void unHideGenderPopUp()
    {
        genderPoP.SetActive(true);
    }
    public void HideNamePop()
    {
        namePoP.SetActive(false);
    }
    public void unHideNamePop()
    {
        namePoP.SetActive(true);
    }
    public void NameYes()
    {
        PlayerPrefs.SetString("name",nameText.text);
        PlayerPrefs.SetString("school", schoolText.text);
        PlayerPrefs.SetInt("profile", 1);
        SceneManager.LoadScene("mainScene");
    }
}
