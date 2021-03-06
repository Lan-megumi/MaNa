﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDate : MonoBehaviour {
/*
	Player脚本预想应有的功能
		在战斗场景游戏开始前读取存档获得玩家各项属性，无需新建实例
		在战斗场景战斗结束后更新玩家属性到存档中
			存档规范获取？
		敌人Ai可以通过此脚本调用到玩家的属性
			注意血量、Mana的最大值与当前值应作为两个不同的变量存在
		敌人的攻击技能实现理论通过调用该脚本

 */
	public static PlayerDate Instance;

    public static PlayerDate _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(PlayerDate))as PlayerDate;
            }
            return Instance;
        }
    }

/*
	准备用于接受玩家数据的变量
*/
	 public string Player_name="",Head_portrait="";
	 public int Hp,MaxHp,Mana,MaxMana,Rgs,Imm;
	 public float Agi,Avd;
	 //---------------------------------

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Testlinshi(){
		Debug.Log("临时玩家创建！");
		Hp=5000;MaxHp=Hp;Mana=600;MaxMana=Mana;Rgs=100;Imm=100;Avd=100;Agi=1f;
		Player_name="圣人惠她老公";
		Head_portrait="Player";
		this.GetComponent<PlayerUi>().UpdateName(Player_name);
		this.GetComponent<PlayerUi>().Update_HpSlider(MaxHp,Hp);
	}
	///<summary>
	/// 攻击玩家的方法
	///</summary>
	public int AttackePlayer(int damage){
		int Reckon= Hp-damage;
		if (Reckon<=0)
		{
			Debug.Log("玩家被击败了");
			BalanceScr._instance.StarUi(false);
		}
		Hp=Reckon;
		UpdateHp();
		return Reckon;
	}
	///<summary>
	///	治疗玩家的方法
	///</summary>
	public void CurePlayer(int Cure){
		int Reckon= Hp+Cure;
		if (Reckon>=MaxHp)
		{
			Hp=MaxHp;
		}else
		{
			Hp=Reckon;
		}
		UpdateHp();
	}
	public void UpdateHp(){
		this.GetComponent<PlayerUi>().Update_HpSlider(MaxHp,Hp);
	}
	///<summary>
	/// 方法的跳转接口
	///</summary>
	public void Fun_EvenTrr(bool n){
		this.GetComponent<PlayerUi>().PlayerTrri_Ui(n);
	}
	///<summary>
	///	该方法用于结算Mana值，如果需要消耗Mana请传入一个负数
	///</summary>
	public void ReckonMana(int i){
		Mana+=i;
		if(Mana+i>MaxMana){
			Mana=MaxMana;
		}
		Debug.Log("ReckonMana:"+Mana+" ,i:"+i);
		
	}

	///<summary>
	/// 接受场景Rule2改变的数据
	///</summary>
	public void ChangeDate(double[] d){
		MaxHp=(int)d[0];
		if(MaxMana<d[1]){
			int linshi = (int)d[1]-MaxMana;
			Mana+=linshi;
		}
		MaxMana=(int)d[1];
		Agi=(float)d[3];
		Avd=(float)d[5];
		

	}
//-----------------------------------------
	//以下分别为获取 玩家血量、最大血量、魔法抗性、异常抗性、闪避
	public int ReturnHp(){
		return Hp;
	}
	public int ReturnMaxHp(){
		return MaxHp;
	}
	public int ReturnRgs(){
		return Rgs;
	}
	public int ReturnImm(){
		return Imm;
	}
	public float ReturnAvd(){
		return Avd;
	}
	public int ReturnMaxMana(){
		return MaxMana;
	}
	public int ReturnMana(){
		return Mana;
	}
	public string Re_Headportrait(){
		return Head_portrait;
	}
//-----------------------------------------
	
	
}