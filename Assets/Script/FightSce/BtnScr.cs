using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScr : MonoBehaviour {

	// Use this for initialization
	public GameObject Father;
	public int Damaged;
	public bool t =true;

	public void GetFather(){
		
		Debug.Log(Father.name);
		if (t==true)
		{
			Father.GetComponent<EmenyScr>().UpdateBack(t);

			t=false;
		}else
		{
			Father.GetComponent<EmenyScr>().UpdateBack(t);
			t=true;
		}

	}
}
