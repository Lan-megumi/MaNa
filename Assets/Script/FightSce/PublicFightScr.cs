using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicFightScr : MonoBehaviour {
/*
	该脚本为公共脚本
 */
	public GameObject Recvie_Father;
	// Use this for initialization
	public static PublicFightScr _instance;
	public string N_Name;
	public string N_Type;

	void Awake(){
		_instance=this;
	}
//------------------------------------------------------------
	/*
		该方法用于对敌人造成伤害的方法
		逻辑：
		首选先传入类型，伤害(Damaged)or治疗(Cure)orDebuff，修改值
			上面三个分别为暗号，会在 BtnScr 通过下面两个的Retrun方法来读取
		所规定的传值规范
			Damaged - (string)int
			Cure - (string)int
			Debuff - string

	问题:
		一次只支持一种类型的传值，如果卡牌有附加效果该方法要执行两次
		StarFunction2传值类型是string，当你只传入伤害值时需要转为 int=>string，	
			同时另一边接收的时候需要再将值强制转换 string=>int
			出现这种问题主要是为了迎合Debuff传入的Debuff暗号
	 */
	public void StarFunction(string type){
		N_Type=type;
	}
	public void StarFunction2(string name){
		N_Name=name;
	}

	public string RetrunN_Name(){
		
		return N_Name;
	}
	public string RetrunN_Type(){
		return N_Type;
	}
//------------------------------------------------------------

	public void N_init(){
		Debug.Log("N_init!");
		N_Name=null;
		N_Type=null;
	}
}
