using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour {

    public AudioSource[] m_ArrayMusic;
    private AudioSource m_music1;
    private AudioSource m_music2;
    private AudioSource m_music3;
    private AudioSource m_music4;
    // Use this for initialization
    public static Audios _instant;
    private void Awake()
    {
        _instant = this;
    }
    void Start () {
        m_ArrayMusic = gameObject.GetComponents<AudioSource>();
        m_music1 = m_ArrayMusic[0];
        m_music2 = m_ArrayMusic[1];
        m_music3 = m_ArrayMusic[2];
        m_music4 = m_ArrayMusic[3];
        m_music1.Stop();
        m_music2.Stop();
        m_music3.Stop();
        m_music4.Stop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
