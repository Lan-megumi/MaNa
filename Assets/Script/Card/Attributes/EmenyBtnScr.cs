using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本主要用于获取鼠标指向的敌人并进行伤害/Debuff/治疗计算
 */
public class EmenyBtnScr : MonoBehaviour {

	// Use this for initialization
	public GameObject Father;
	public int Damaged;
	public bool t =true;
	public string NTpye,NName ;

/*
	该方法附着在每个敌人身上，每个敌人都有一个GetFather()方法
	GetFather 可以获取到敌人物体携带的Btn的父子件，
		父子件里面有该敌人的数据、独立的计算Debuff脚本
 */
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
/*
	读取 PublicFightScr 脚本的值
*/
		NTpye=PublicFightScr._instance.RetrunN_Type();
		NName=PublicFightScr._instance.RetrunN_Name();
		if (NTpye!=null&&NName!=null)
		{
//----------------------------Debuff
			if (NTpye=="Debuff")
			{
				//----------------------
				if (NName=="Fire")
				{
					Father.GetComponent<CountDebuff>().AddFire();
				}
				
			}
//----------------------------Damaged
			if (NTpye=="Damaged")
			{
				Debug.Log(NName);
				int n = int.Parse(NName);
				Father.GetComponent<EmenyScr>().CountDamaged(true,n);
			}
//----------------------------Cure
			if (NTpye=="Cure")
			{
				int n = int.Parse(NName);
				Father.GetComponent<EmenyScr>().CountDamaged(false,n);
			}
	//执行完所有操作后将 公共脚本值归零
			PublicFightScr._instance.N_init();
		}

		
		
	}
	public GameObject returnFater(){
		return Father;
	}
}
