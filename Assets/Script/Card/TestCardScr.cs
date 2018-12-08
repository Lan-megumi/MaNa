using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///	该脚本用于绑定在卡牌Ui上，同时储存卡牌的信息以及点击卡牌时提供的方法
///</summary>
public class TestCardScr : MonoBehaviour {

	///	卡牌的id，这个变量会经常被用到
	public string Cardid="";

	///	卡牌的消耗，用于将来的消耗判断
	public int CardCost;

	///	判断卡牌是否被选中，这个变量会经常被用到
	public bool Bool_Card=false;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	///<summary>
	///	该方法为主要为填值,第一个值为id,第二个值为消耗cost
	///</summary>
	public void SetDate(string id,int cardcost){
		Cardid=id;
		CardCost=cardcost;
	}
	///<summary>
	///	卡牌的Button事件
	///</summary>
	public void TestCardBtn(){
		//在执行之前需要询问公共脚本数量
		if (true)
		{
			
		}
		if (Re_Bool_Card()!=true)
		{
			Bool_Card=true;
			//传递id方法，判断是否为第二个选取的卡牌
			//同时传递消息给公共脚本
			Debug.Log("|"+Re_Cardid()+" |");
		}else
		{
			Bool_Card=false;
			//消除传递过去的id方法
			//同时传递消除的消息给公共脚本
		}
	}

//---------------------------
	//返回接口
	public string Re_Cardid(){
		return Cardid;
	}
	public int Re_CardCost(){
		return CardCost;
	}
	public bool Re_Bool_Card(){
		return Bool_Card;
	}
}
