using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本主要用于更改Debuff Ui
 */
public class DebuffUi : MonoBehaviour {
	public Text T_Fire,T_Ice,T_Fear,T_Dizzy,T_IceAche;
	
	// Use this for initialization
	void Start () {

		
	}
	public void ChangeFire(int a){
		T_Fire.GetComponent<Text>().text="Fire:"+a.ToString();
	}
	public void ChangeIce(int a){
		T_Ice.GetComponent<Text>().text="Ice:"+a.ToString();
	}
	public void ChangeFear(int a){
		T_Fear.GetComponent<Text>().text="Fear:"+a.ToString();
	}
	public void ChangeDizzy(int a){
		T_Dizzy.GetComponent<Text>().text="Dizzy:"+a.ToString();
	}
	public void ChangeIceAche(int a){
		T_IceAche.GetComponent<Text>().text="IceAche:"+a.ToString();
	}


}
