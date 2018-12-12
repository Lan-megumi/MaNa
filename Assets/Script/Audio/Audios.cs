using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour {

    public AudioSource m_Audio;
    private AudioSource m_MainAudio;

    public AudioClip[] myMusicArray;
    
    // Use this for initialization
    public static Audios _instant;

    
    private void Awake()
    {
        _instant = this;
    }

    void Start () {
        m_Audio = gameObject.GetComponent<AudioSource>();
        m_Audio.volume = SoundSetting._instance.slider.value;
        m_Audio.clip = myMusicArray[1];
        m_MainAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
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
