using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本主要用于获取鼠标指向的敌人
 */
public class BtnScr : MonoBehaviour {

	// Use this for initialization
	public GameObject Father;
	public int Damaged;
	public bool t =true;
	public string NTpye,Name ;

	public void GetFather(){
		
		
		if (t==true)
		{
			Father.GetComponent<EmenyScr>().UpdateBack(t);
			PublicFightScr._instance.Recvie_Father=returnFater();
			t=false;
		}else
		{
			Father.GetComponent<EmenyScr>().UpdateBack(t);
			PublicFightScr._instance.Recvie_Father=null;

			t=true;
		}

		
		if (NTpye=="Debuff")
		{
			if (Name=="Fire")
			{
				
			}
		}

	}
	public GameObject returnFater(){
		return Father;
	}
}
