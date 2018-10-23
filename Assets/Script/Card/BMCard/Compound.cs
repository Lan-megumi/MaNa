using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compound : MonoBehaviour {
	Dictionary <string ,string>d1=new Dictionary<string, string>();
	private string DicReturn;

	// Use this for initialization
	void Start () {
		d1.Add("1&2","1%2");
		d1.Add("2&1","1%2");

		FindDic("2","1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public string FindDic(string a1,string a2){
		DicReturn="";
		if(d1.ContainsKey(a1+"&"+a2)){
			DicReturn=d1[a1+"&"+a2];
		}
		Debug.Log("++"+DicReturn);
		return	DicReturn;
	}
}
