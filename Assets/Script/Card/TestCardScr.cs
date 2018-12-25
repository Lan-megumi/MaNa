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
	//用于储存第几个，从公共脚本中获取值
	public int i=0;

//--------------------------------------------------
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
		if (TestMananger._instance.Re_ChoseNum()>=2&&Re_Bool_Card()==false)
		{
			Debug.Log("来自TestCardSCr的报告：来自公共脚本信息表示已选择了两张牌");
		}else
		{
			if (Re_Bool_Card()!=true)
			{
				Bool_Card=true;
				//传递id方法，判断是否为第二个选取的卡牌
				//同时传递消息给公共脚本
				// Debug.Log("|"+Re_Cardid()+" |");
				CardCompound._instance.Saveid(Re_Cardid());
				CardCompound._instance.SetCost(Re_CardCost());

				TestMananger._instance.CheckChoseNum(Bool_Card);
				i=TestMananger._instance. Re_ChoseNum();

			}else
			{
				Bool_Card=false;
				TestMananger._instance.CheckChoseNum(Bool_Card);
				CardCompound._instance.Deletid(i);
				CardCompound._instance.DeletCost(i);

				i=0;
				//消除传递过去的id方法
				//同时传递消除的消息给公共脚本
			}
			// TestMananger._instance.CheckChoseNum(Bool_Card);
			this.GetComponent<CardUi>().Set_BchoseUi(Bool_Card);
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
	public void Init(){
		Bool_Card=false;
		i=0;
	}
}
