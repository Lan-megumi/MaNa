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
	public string NTpye,NName ;

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
		NTpye=PublicFightScr._instance.RetrunN_Type();
		NName=PublicFightScr._instance.RetrunN_Name();
		if (NTpye!=null)
		{
//----------------------------
			if (NTpye=="Debuff")
			{
				//----------------------
				if (NName=="Fire")
				{
					Father.GetComponent<CountDebuff>().AddFire();
				}
				//----------------------
			}
//----------------------------
			if (NTpye=="Damaged")
			{
				Debug.Log(NName);
				int n = int.Parse(NName);
				Father.GetComponent<EmenyScr>().CountDamaged(true,n);
			}
			if (NTpye=="Cure")
			{
				int n = int.Parse(NName);
				Father.GetComponent<EmenyScr>().CountDamaged(false,n);
			}
			PublicFightScr._instance.N_init();
		}

		
		
	}
	public GameObject returnFater(){
		return Father;
	}
}
