using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///	该脚本绑定在Debuff单个实例上，属于非公共脚本
///</summary>
public class Deatil_Debuff_Ui : MonoBehaviour {
	public Text BuffNum_Ui;
	public Image Buff_Pic;
	// Use this for initialization
	
	public void SetBuffImg(string name){
		Debug.Log("name:"+name);
		Sprite pic = Resources.Load("Debuff/"+name,typeof(Sprite))as Sprite;
		Debug.Log("Pic:"+pic);
		Buff_Pic.sprite=pic;
	}
	public void SetBuffNum(int i){
		BuffNum_Ui.text=i.ToString();
	}
	public void DestroyObj(){
		Destroy(this);
	}
}