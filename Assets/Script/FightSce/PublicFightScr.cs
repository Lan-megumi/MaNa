using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///战斗场景中继脚本，用于储存临时对敌人造成伤害的类型、数值、Debuff效果，同时能被敌人的功能脚本读取到
///</summary>
public class PublicFightScr : MonoBehaviour {
/*
	该脚本为公共脚本
 */
	public GameObject Recvie_Father;
	// Use this for initialization
	public static PublicFightScr _instance;
	public string N_Name;
	public string N_Type;
	public string N_Buff;
	public float N_Buff_num;
   

    void Awake(){
		_instance=this;
	}
//------------------------------------------------------------
	/*
		该方法用于对敌人造成伤害的方法
		StarFunction传入类型，StarFunction3专用于buff。,StarFunction2传入数值
		逻辑：
		
		首选先传入类型，伤害(Damaged)or治疗(Cure)orDebuff，修改值
		上面三个分别为暗号，会在 BtnScr 通过下面两个的Retrun方法来读取
		所规定的传值规范
			Damaged - (string)int
			Cure - (string)int
			(Debuff) - (string)float


	 */
	 ///<summary>
	 ///传入类型，接收三个值Damaged , Cure , R
	 ///</summary>
	public void StarFunction(string type){
		N_Type=type;
	}
	public void StarFunction2(string name){
		N_Name=name;
	}
	///<summary>
	///Buff触发使用的Function,传入参数由卡牌合成后的返回而定
	///</summary>
	public void StarFunctoin3(string name){
		N_Buff=name;
	}
	public void StarFunction4(float num){
		N_Buff_num=num;
	}
   

    public string RetrunN_Name(){
		
		return N_Name;
	}
	public string RetrunN_Type(){
		return N_Type;
	}
	public string RetrunN_Buff(){
		return N_Buff;
	}
	public float RetrunN_Buff_num(){
		return N_Buff_num;
	}
    


    //------------------------------------------------------------
	///<summary>
	/// pulicFightScr-初始化数据
	///</summary>
    public void N_init(){
		// Debug.Log("N_init!");
		N_Name=null;
		N_Type=null;
		N_Buff=null;
		N_Buff_num=0;

	}
}
