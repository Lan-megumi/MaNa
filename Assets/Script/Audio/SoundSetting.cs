using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSetting : MonoBehaviour {
    private GameObject Setting;//喇叭图标
    private bool isSetting;//音乐控制界面显示
    //背景音乐选择btn
    public GameObject isOnGameObject;  
    public GameObject isOffGameObject;
    //音效选择btn
    public GameObject isOnGameObject1;
    public GameObject isOffGameObject1;


    public AudioSource m_audiobg;//背景音乐控件
    //跳转后是否开启背景音乐/音效
    public bool audioefbool; 
    public bool audiobgbool;
    public Slider slider;//音量滑动条
    // Use this for initialization
    
    public static SoundSetting _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start () {
        
        Setting = GameObject.Find("Setting");
        Setting.SetActive(false);
        isSetting = false;
        m_audiobg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open()
    {
        if (isSetting == false)
        {
            Setting.SetActive(true);
            isSetting = true;
        }
        else
        {
            Setting.SetActive(false);
            isSetting = false;
        }
        
    }
    public void Close()
    {
        Setting.SetActive(false);
    }
    //背景音乐Toggle
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
    //音效Toggle
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
