using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanges : MonoBehaviour {
    public AudioSource audiobg;
	// Use this for initialization
	void Start () {
        audiobg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        if (Checklevel_Scr.levelObj_i == 0) {  //Checklevel_Scr.levelObj_i控制大关
            //SceStar.Instance.LELnum控制小关内音乐clip
            audiobg.clip = Audios._instance.Bgm[2];
            audiobg.Play();
            if (SceStar.Instance.LELnum == 1)  
            {
                //audio.clip = Audios.Instance.Bgm[2];
            }
            if (SceStar.Instance.LELnum == 2)
            {
                //audio.clip = Audios.Instance.Bgm[2];
            }
            if (SceStar.Instance.LELnum == 3)
            {
                //audio.clip = Audios.Instance.Bgm[1];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
