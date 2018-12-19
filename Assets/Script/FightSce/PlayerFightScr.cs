using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
/// 该脚本于 PublicFightScr 功能类似
///</summary>
public class PlayerFightScr : MonoBehaviour {
	public static PlayerFightScr Instance;

    public static PlayerFightScr _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(PlayerFightScr))as PlayerFightScr;
            }
            return Instance;
        }
    }
//---------------------------------------------------------
	public string N_Type;
	public string N_Num;
	// Use this for initialization
	void Start () {
		
	}
	///<summary>
	///	传入伤害类型，Damage or Cure
	///</summary>
	public void StarFuntion(string type0){
		N_Type=type0;
		//如果有Cure治疗效果，则传递参数给PlayerDate跳转参数给PlayerUi
		if(N_Type=="Cure"){
			PlayerDate._instance.Fun_EvenTrr(true);
		}
	}
	///<summary>
	///	传入伤害数值，类型string
	///</summary>
	public void StarFuntion2(string num){
		N_Num=num;
	}
	public string Re_N_Type(){
		return N_Type;
	}
	public string Re_N_Num(){
		return N_Num;
	}
	
//-----------------------------------------
	public void InitDate(){
		N_Type="";
		N_Num="";
		PlayerDate._instance.Fun_EvenTrr(false);

	}
}
