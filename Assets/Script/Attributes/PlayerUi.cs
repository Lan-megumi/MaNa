using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUi : MonoBehaviour {
/*
	该脚本用于绑定Player的Ui
 */
	public Text Name;
	public Image Trri_img;
	public Slider HpSlider;
	public bool IfCure_Bm;
	// Use this for initialization
	void Start () {
		// Update_HpSlider(1000,1100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateName(string text){
		Name.text=text;
	}
	public void Update_HpSlider(int Maxnum,int NowNum){
		double i = (double)NowNum/(double)Maxnum;
		// Debug.Log(i);
		HpSlider.value=(float)i;
	}

	public void PlayerTrri_Ui(bool d){
		if(d==true){
			if(IfCure_Bm==true){
				Trri_img.gameObject.SetActive(true);
			}
		}else{
			if(IfCure_Bm==true){
				Trri_img.gameObject.SetActive(false);
			}
			// Trri_img.gameObject.SetActive(false);

		}
	}
	///<summary>
	/// Cure部分Ui显示效果
	///</summary>
	public void Set_IfCure_Bm(bool t){
		IfCure_Bm=t;
	}
}