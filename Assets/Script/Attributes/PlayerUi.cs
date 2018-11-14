using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUi : MonoBehaviour {
/*
	该脚本用于绑定Player的Ui
 */
	public Text Name,Mana;
	public Slider HpSlider;
	// Use this for initialization
	void Start () {
		// Update_HpSlider(1000,1100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void UpdateMana(int num){
		Mana.text=num.ToString();
	}
	public void UpdateName(string text){
		Name.text=text;
	}
	public void Update_HpSlider(int Maxnum,int NowNum){
		double i = (double)NowNum/(double)Maxnum;
		// Debug.Log(i);
		HpSlider.value=(float)i;
	}
}
