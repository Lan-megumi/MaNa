using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public static StartGame _instance;
    private GameObject endButton,StartBt;
    public bool Startbool=false;

    private void Awake()
    {
        _instance = this;
    }
    public void StartButton()
    {
        endButton = GameObject.Find("endButton");
        StartBt = GameObject.Find("StartButton");        
        endButton.GetComponent<Button>().interactable = true;
        Startbool = true;
        CoroutineCountdown._instance.Agiss();
        //CoroutineCountdown._instance.NextTrun();
        StartBt.SetActive(false);
    }

}
