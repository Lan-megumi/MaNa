using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebuffUi : MonoBehaviour {
	private GameObject T_Fire,T_Ice,T_Fear,T_Dizzy,T_IceAche;
	public static DebuffUi _instance;
	
	void Awake(){
		_instance=this;
	}

	// Use this for initialization
	void Start () {
		T_Fire=GameObject.Find("DebuffText/FireText");
		T_Ice=GameObject.Find("DebuffText/IceText");
		T_Fear=GameObject.Find("DebuffText/FearText");
		T_Dizzy=GameObject.Find("DebuffText/DizzyText");
		T_IceAche=GameObject.Find("DebuffText/IceAcheText");
		
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
