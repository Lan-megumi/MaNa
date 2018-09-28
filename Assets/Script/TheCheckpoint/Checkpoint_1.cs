using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkpoint_1 : MonoBehaviour {
	public GameObject Select_card_group;


	// Use this for initialization
	void Start () {
		Select_card_group.SetActive(false);							//隐藏选择关卡框
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Tne_Game_Name);
	}

	string Tne_Game_Name="1";

	public void Start_Game(string Tne_Game_Namein){

		Tne_Game_Name = Tne_Game_Namein;
		Select_card_group.SetActive(true);

	}	

	public void Group(){
		SceneManager.LoadScene(4,LoadSceneMode.Single);
	}
}
