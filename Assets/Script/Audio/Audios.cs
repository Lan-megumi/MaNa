using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour {

    public AudioSource m_Audio;
    public AudioSource m_MainAudio;

    public AudioClip[] myMusicArray;
    private AudioClip myMusicclip;
    private AudioClip myMusicclip1;
    private AudioClip myMusicclip2;
    private AudioClip myMusicclip3;
    private AudioClip myMusicclip4;
    private AudioClip myMusicclip5;
    private AudioClip myMusicclip6;
    private AudioClip myMusicclip7;
    private AudioClip myMusicclip8;
    private AudioClip myMusicclip9;
    public AudioClip[] Bgm;
    private AudioClip m_Bgm;
    private AudioClip m_Bgm1;
    private AudioClip m_Bgm2;
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
        myMusicclip = Resources.Load("Audios/SoundEffects/a") as AudioClip;
        myMusicclip1 = Resources.Load("Audios/SoundEffects/aa") as AudioClip;
        myMusicclip2 = Resources.Load("Audios/SoundEffects/quantou") as AudioClip;
        myMusicclip3 = Resources.Load("Audios/SoundEffects/mubangji") as AudioClip;
        myMusicclip4 = Resources.Load("Audios/SoundEffects/shejian") as AudioClip;
        myMusicclip5 = Resources.Load("Audios/SoundEffects/chuiji") as AudioClip;
        myMusicclip6 = Resources.Load("Audios/SoundEffects/playjiao") as AudioClip;
        myMusicclip7 = Resources.Load("Audios/SoundEffects/Emenydie") as AudioClip;
        myMusicclip8 = Resources.Load("Audios/SoundEffects/Emenyjiao") as AudioClip;
        myMusicclip9 = Resources.Load("Audios/SoundEffects/buxue") as AudioClip;
        m_Bgm = Resources.Load("Audios/BGM/bgm") as AudioClip;
        m_Bgm1 = Resources.Load("Audios/BGM/bgm1") as AudioClip;
        m_Bgm2 = Resources.Load("Audios/BGM/bgmweizhi") as AudioClip;
        myMusicArray = new AudioClip[]{ myMusicclip, myMusicclip1, myMusicclip2,
            myMusicclip3, myMusicclip4, myMusicclip5,
            myMusicclip6 ,myMusicclip7,myMusicclip8,myMusicclip9};
        Bgm = new AudioClip[] { m_Bgm,m_Bgm1,m_Bgm2 };
        
        m_Audio = gameObject.GetComponent<AudioSource>();
        m_Audio.volume = SoundSetting._instance.slider.value;
        //m_Audio.clip = myMusicArray[1];
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
