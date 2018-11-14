using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUi : MonoBehaviour {
/*
	该脚本用于绑定Player的Ui
 */
	public Text Hp,Name,Mana;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void UpdateHp(int num){
		Hp.text=num.ToString();
	}
	public void UpdateMana(int num){
		Mana.text=num.ToString();
	}
	public void UpdateName(string text){
		Name.text=text;
	}
}
