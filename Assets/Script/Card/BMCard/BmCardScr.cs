using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///	该脚本用于BmCard对外接口，包含伤害的实装
///</summary>
public class BmCardScr : MonoBehaviour {
	public static BmCardScr Instance;

    public static BmCardScr _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(BmCardScr))as BmCardScr;
            }
            return Instance;
        }
    }
//----------------------------------------
	public BMCardLib BmLib;

	// Use this for initialization
	void Awake () {
		BmLib=new BMCardLib();
	}
///<summary>
///	Bm卡牌的对外接口
///</summary>
	public void ChangeBm(string name){
		BmLib.ChangeBm(name);
		BmLib.UseBmRule1();
		BmReckon(BmLib.UseBmRUle2());
	}
	
///<summary>
///	用于合成后改变战斗场景的数据
///</summary>
	public void BmReckon(double[] d){
		Debug.Log("来自BmCardScr的报告：传入的Bm第一位数是 "+d[0]);
		if(d[0]!=0){
			//处理场景影响伤害的部分
			GroundLib gb=GroundScr._instance.groundLib;
			d[0]=gb.ReckonRule1(d);
			int Reckon=(int)d[0];

			if(d[2]==0){
				PublicFightScr._instance.StarFunction2(Reckon.ToString());
				PublicFightScr._instance.StarFunction("Damaged");
			}else if(d[2]==1){
				DmScr._instance.Dm(Reckon);
			}else if(d[2]==1){
				PublicFightScr._instance.StarFunction("R");
				PublicFightScr._instance.StarFunction2(Reckon.ToString());
			}
		}
		if(d[3]!=0){
			PlayerFightScr._instance.StarFuntion("Cure");
			PlayerFightScr._instance.StarFuntion2(((int)d[3]).ToString());
		}

	}
	
}
