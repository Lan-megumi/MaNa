using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
	该脚本用于测试Debuff中的燃烧
 */
public class Test_Fire : MonoBehaviour {
	public Text TextHp,TextName,TextRound;
//------------------------------------------------
	//用于接收敌人血量
	private int emenyHp;


//------------------------------------------------
	//定义回合数，当前回合和上一回合
	private int Round=0,eldRound;
	//定义燃烧Debuff的叠加层数
	private int Firenum =0;
	
	// Use this for initialization
	void Start () {
		TextRound.text=Round.ToString();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddRound(){
		eldRound=Round;
		Round++;
		TextRound.text=Round.ToString();
		Fire();	
		Firenum=0;
	}
//------------------------------燃烧---------------------------
	//燃烧Debuff的计算方法
	public void Fire(){
		float f_hp=(float)emenyHp;
		f_hp-=f_hp*0.03f*Firenum;
		emenyHp=(int)f_hp;
		UpdateHp();
	}
	//对敌人附加了燃烧Debuff效果一层
	public void AddFire(){
		Firenum++;
	}

//------------------------------燃烧---------------------------

//------------------------------冰冻---------------------------
	public void Ice(){
		Debug.Log("未实现！");
	}
//------------------------------冰冻---------------------------

//以下是创建敌人的方法
	public void CreateEmeny1(){
			EmenyLibrary.Emeny1 emeny1=new EmenyLibrary.Emeny1();
			emeny1.initdate();
			Debug.Log(emeny1.GetHp);
			emenyHp=emeny1.GetHp;
			UpdateHp();
			TextName.text="Emeny1";
	}
	public void CreateEmeny2(){
			EmenyLibrary.Emeny2 emeny2=new EmenyLibrary.Emeny2();
			emeny2.initdate();
			Debug.Log(emeny2.GetHp);
			emenyHp=emeny2.GetHp;
			UpdateHp();
			TextName.text="Emeny2";
	}
	//更新 Hp的Ui
	public void UpdateHp(){
			TextHp.text=emenyHp.ToString();
	}
	
}
