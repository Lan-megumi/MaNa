using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本主要用于获取鼠标指向的敌人并进行伤害/Debuff/治疗计算
 */
public class EmenyBtnScr : MonoBehaviour {

	// Use this for initialization
	public GameObject Father;
	public bool t =true;
	public string NTpye,NName,NBuff;
    public int EnemyIndexof;
	private float N_Buff_num;
	private int z;


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
		NBuff=PublicFightScr._instance.RetrunN_Buff();
		N_Buff_num=PublicFightScr._instance.RetrunN_Buff_num();
        //获取父子间的属性
        EnemyIndexof= Father.GetComponent<EmenyScr>().EnemyIndex;
        z = EnemyIndexof;
        // Debug.Log("EnemyIndexof:" + z);


        if (NTpye!=null&&NName!=null)
		{
//----------------------------Debuff
			if (NBuff=="Fire")
			{
				//----------------------
				
				Father.GetComponent<CountDebuff>().AddFire();
				Father.GetComponent<CountDebuff>().Buffnum=N_Buff_num;
				
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
//----------------------------群体伤害
            if (NTpye == "R")
            {
                Debug.Log("NName:"+NName+" |index:"+EnemyIndexof);
                int n = int.Parse(NName);
                z = EnemyIndexof;
                //Debug.Log("zzz" + z);
                DmScr._instance.CountRelated(n,z);
            }
            //执行完所有操作后将 公共脚本值归零
            PublicFightScr._instance.N_init();
			InitDate();
			ReadCard._instance.InitDate();
		}
	}
	public GameObject returnFater(){
		return Father;
	}
	private void InitDate(){
		NName="";
		NTpye="";
		NBuff="";
		z=0;
		N_Buff_num=0;
	}
}
