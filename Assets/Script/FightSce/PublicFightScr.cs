using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicFightScr : MonoBehaviour {

	public GameObject Recvie_Father;
	// Use this for initialization
	public static PublicFightScr _instance;
	public string N_Debuff;
	public string N_Type;

	void Awake(){
		_instance=this;
	}
	public void StarFunction(string i,string type){
		N_Debuff=i;
		N_Type=type;
	}
	public string RetrunN_Debuff(){
		return N_Debuff;
	}
	public string RetrunN_Type(){
		return N_Type;
	}
}
