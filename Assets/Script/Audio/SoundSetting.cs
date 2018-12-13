using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSetting : MonoBehaviour {
    private GameObject Setting;

    public GameObject isOnGameObject;  
    public GameObject isOffGameObject;
    public GameObject isOnGameObject1;
    public GameObject isOffGameObject1;

    public AudioSource m_audiobg;
    private AudioSource m_audioef;

    public bool audioefbool;
    public bool audiobgbool;
    public Slider slider;
    // Use this for initialization
    
    public static SoundSetting _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start () {
        Setting = GameObject.Find("Setting");
        Setting.SetActive(false);
        
        m_audiobg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open()
    {
        Setting.SetActive(true);
    }
    public void Close()
    {
        Setting.SetActive(false);
    }
    //背景音乐
    public void OnValueChange(bool isOn)
    {
        isOffGameObject.SetActive(isOn);
        isOnGameObject.SetActive(!isOn);
        if (isOn==true)
        {
            m_audiobg.mute = true;
            audiobgbool = true;
        } else
        {
            m_audiobg.mute = false;
            audiobgbool = false;
        }
    }
    //音效
    public void OnValueChange1(bool isOn)
    {
        isOffGameObject1.SetActive(isOn);
        isOnGameObject1.SetActive(!isOn);
        if (isOn == true)
        {
            audioefbool = true;
        }
        else
        {
            audioefbool = false;
        }
        
    }
    public void SoundVolume()
    {
        m_audiobg.volume = slider.value;
    }
}
