using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanges : MonoBehaviour {
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //根据SceStar里的LELnum，改变AudioSource的clip(Audios里的myMusicclip[])
        if (SceStar.Instance.LELnum == 1)
        {
            //audio.clip = Audios.Instance.myMusicArray[2];
        }
        if (SceStar.Instance.LELnum == 2)
        {
            audio.clip = Audios.Instance.myMusicArray[2];
        }
        if (SceStar.Instance.LELnum == 3)
        {
            audio.clip = Audios.Instance.myMusicArray[1];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
