using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本主要用于获取鼠标指向的敌人并进行伤害/Debuff/治疗计算
 */
public class EmenyBtnScr : MonoBehaviour {

	// Use this for initialization
	public GameObject Father;
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
		//在这里根据接受Debuff的不同来进行不同的操作
			if (NBuff=="Fire")
			{
				//----------------------
				
				Father.GetComponent<CountDebuff>().AddFire();
				Father.GetComponent<CountDebuff>().Buffnum=N_Buff_num;
				
			}
			//冰冻
			if (NBuff=="Ice")
			{
				Father.GetComponent<CountDebuff>().AddIce();
				// Father.GetComponent<CountDebuff>().
			}
			//冻伤的增加回合事件是一回合+2
			if (NBuff=="IceAche")
			{
				Father.GetComponent<CountDebuff>().AddIceAche(2);
				
			}
			//眩晕
			if (NBuff=="Dizzy")
			{
				Father.GetComponent<CountDebuff>().AddDizzyNum();
				
			}
			//恐惧
			if (NBuff=="Fear")
			{
				Father.GetComponent<CountDebuff>().AddFear();
				
			}
			//寒冷 增加一层冻伤效果
			if (NBuff=="Cold")
			{
				Father.GetComponent<CountDebuff>().AddIceAche(1);
				
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
		Enemy_Deatil_Ui._instance.Init_Bchose_Deail();
		this.GetComponentInParent<EmenyScr>().Set_BchoseDeatil(true);
        //点击事件工作二：显示Deatil面板相关数据
		if(this.gameObject!=null){
       	 	this.GetComponentInParent<EmenyScr>().Set_Enemy_Deatil_Ui();
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
