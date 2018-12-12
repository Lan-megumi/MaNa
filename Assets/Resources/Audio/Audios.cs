using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour {

    public AudioSource m_Audio;
    

    public AudioClip[] myMusicArray;
    
    // Use this for initialization
    public static Audios _instant;
    private void Awake()
    {
        _instant = this;
    }
    void Start () {
       m_Audio = gameObject.GetComponent<AudioSource>();
       m_Audio.clip= myMusicArray[1]; 

    }
	
	// Update is called once per frame
	void Update () {
    }
}
