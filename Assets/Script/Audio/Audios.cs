using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour {

    public AudioSource m_Audio;
    private AudioSource m_MainAudio;

    public AudioClip[] myMusicArray;
    private AudioClip myMusicclip;
    private AudioClip myMusicclip1;
    private AudioClip myMusicclip2;
    private AudioClip myMusicclip3;
    private AudioClip myMusicclip4;
    private AudioClip myMusicclip5;
    private AudioClip myMusicclip6;
    private AudioClip myMusicclip7;
    // Use this for initialization

    public static Audios Instance;

    public static Audios _instance
    {
        get
        {
            if (null == Instance)
            {
                Instance = FindObjectOfType(typeof(Audios)) as Audios;
            }
            return Instance;
        }
    }
    
    void Start () {

        myMusicclip = Resources.Load("Audios/a") as AudioClip;
        myMusicclip1 = Resources.Load("Audios/b") as AudioClip;
        myMusicclip2 = Resources.Load("Audios/buxue") as AudioClip;
        myMusicclip3 = Resources.Load("Audios/mubangji") as AudioClip;
        myMusicclip4 = Resources.Load("Audios/shejian") as AudioClip;
        myMusicclip5 = Resources.Load("Audios/Emenyj") as AudioClip;
        myMusicclip6 = Resources.Load("Audios/playj") as AudioClip;
        myMusicclip7 = Resources.Load("Audios/Emenydie") as AudioClip;
        myMusicArray = new AudioClip[]{ myMusicclip, myMusicclip1, myMusicclip2,
            myMusicclip3, myMusicclip4, myMusicclip5,
            myMusicclip6 ,myMusicclip7};

        
        m_Audio = gameObject.GetComponent<AudioSource>();
        m_Audio.volume = SoundSetting._instance.slider.value;
        m_Audio.clip = myMusicArray[1];
        m_MainAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        m_MainAudio.volume= SoundSetting._instance.slider.value;

        if (SoundSetting._instance.audiobgbool == true)
        {
            m_MainAudio.mute = true;

        }
        else
        {
            m_MainAudio.mute = false;
        }
        
        if (SoundSetting._instance.audioefbool == true)
        {
            m_Audio.mute = true;
            
        }else
        {
            m_Audio.mute = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
