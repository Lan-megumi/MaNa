using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicFightScr : MonoBehaviour {

	public GameObject Recvie_Father;
	// Use this for initialization
	public static PublicFightScr _instance;
	public string N_Name;
	public string N_Type;

	void Awake(){
		_instance=this;
	}
	public void StarFunction(string type){
		N_Type=type;
	}
	public void StarFunction2(string name){
		N_Name=name;
	}
	public string RetrunN_Name(){
		return N_Name;
	}
	public string RetrunN_Type(){
		return N_Type;
	}
	public void N_init(){
		Debug.Log("N_init!");
		N_Name=null;
		N_Type=null;
	}
}
