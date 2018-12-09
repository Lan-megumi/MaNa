using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Deatil_Debuff_Ui : MonoBehaviour {
	public Text BuffNum_Ui;
	public Image Buff_Pic;
	// Use this for initialization
	
	public void SetBuffImg(string name){
		Sprite pic = Resources.Load("Debuff/"+name,typeof(Sprite))as Sprite;
		Debug.Log("Pic:"+pic);
		Buff_Pic.sprite=pic;
	}
	public void SetBuffNum(int i){
		BuffNum_Ui.text=i.ToString();
	}
}