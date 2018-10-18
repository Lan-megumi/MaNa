using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
	该脚本用于测试Debuff中的燃烧
 */
public class CountDebuff : MonoBehaviour {
	public Text TextHp,TextName,TextRound;
//------------------------------------------------
	//用于接收敌人血量
	private int EmenyHp;

	public List<Attributes> EmenyList;
//------------------------------------------------
	//定义回合数，当前回合和上一回合
	private int Round=0,eldRound;

/*
	定义Debuff的叠加层数
	Fire：燃烧
	Ice：冰冻
	IceAche：冻伤
	Dizzy:眩晕
	Fear:恐惧
 */
	private int FireNum =0,IceNum=0,IceAcheNum=0,DizzyNum=0,FearNum=0;
	
	// Use this for initialization
	void Start () {
		TextRound.text=Round.ToString();		
	}


	//玩家/敌人回合结束后，判断敌方是否有(回合开始结算)Debuff需要结算
	public void ComputeDebuff(){

		if (IceNum!=0)
		{
			Ice();
		}
		if (FireNum!=0)
		{
			Fire();
		}
	
		if (DizzyNum!=0)
		{
			Dizzy();
		}
		if (FearNum!=0)
		{
			Fear();
		}
	}
	public void AddRound(){
		eldRound=Round;
		Round++;
		TextRound.text=Round.ToString();
		ComputeDebuff();
	}
//------------------------------燃烧---------------------------
	//燃烧Debuff的计算方法
	public void Fire(){
		if (IceAcheNum!=0)
		{
			IceAcheNum=0;
			DebuffUi._instance.ChangeIceAche(IceAcheNum);
		}
		float f_hp=(float)EmenyHp;
		f_hp-=f_hp*0.03f*FireNum;
		EmenyHp=(int)f_hp;
		//完成计算后结算数据显示Ui
		FireNum--;
		UpdateHp();
		DebuffUi._instance.ChangeFire(FireNum);

	}
	//对敌人附加了燃烧Debuff效果一层
	public void AddFire(){
		FireNum++;
		DebuffUi._instance.ChangeFire(FireNum);

	}



//------------------------------冰冻---------------------------
	public void Ice(){
		//当冻伤buff消失时，冰冻效果也会消失
		if(IceAcheNum==0){
			IceNum=0;
			DebuffUi._instance.ChangeIce(IceNum);
		}
		if (IceNum==4)
		{
			DizzyNum++;
			Dizzy();
			IceNum=0;
			DebuffUi._instance.ChangeIce(IceNum);

		}	
	}
	public void AddIce(){
		IceNum++;
		DebuffUi._instance.ChangeIce(IceNum);

	}


//------------------------------冻伤（回合结束计算）---------------------------
	public void IceAche(){
		if (IceAcheNum!=0)
		{
			int IceAcheDamage=10;
			EmenyHp-=IceAcheDamage;
			IceNum++;
			DebuffUi._instance.ChangeIce(IceNum);

		}
		IceAcheNum--;
		DebuffUi._instance.ChangeIceAche(IceAcheNum);

	}
	public void AddIceAche(){
		IceAcheNum+=2;
		DebuffUi._instance.ChangeIceAche(IceAcheNum);
	}



//------------------------------晕眩---------------------------
	//眩晕实现：直接增加行动速度=目标初始速度
	public void Dizzy(){
		Debug.Log("眩晕未实现！");
		DizzyNum=0;
		DebuffUi._instance.ChangeDizzy(DizzyNum);
	}
	public void AddDizzyNum(){
		DizzyNum++;
		DebuffUi._instance.ChangeDizzy(DizzyNum);
	}

//------------------------------恐惧---------------------------
	//降低伤害降低命中
	public void Fear(){
		Debug.Log("恐惧未实现！");
		FearNum-=1;
		DebuffUi._instance.ChangeFear(FearNum);
	}
	public void AddFear(){
		FearNum++;
		DebuffUi._instance.ChangeFear(FearNum);

	}
//------------------------------寒冷---------------------------
	//效果，延长冻伤时间
	public void Cold(){
		IceAcheNum++;
		DebuffUi._instance.ChangeIceAche(IceAcheNum);
	}



//以下是创建敌人的方法
	public void CreateEmeny1(){
			EmenyLibrary.Emeny1 emeny1=new EmenyLibrary.Emeny1();
			emeny1.initdate();
			//得到血量
			EmenyHp=emeny1.GetHp;
			UpdateHp();
			TextName.text="Emeny1";
	}
	public void CreateEmeny2(){
			EmenyLibrary.Emeny2 emeny2=new EmenyLibrary.Emeny2();
			emeny2.initdate();
			Debug.Log(emeny2.GetHp);
			EmenyHp=emeny2.GetHp;
			UpdateHp();
			TextName.text="Emeny2";
	}
	//更新 Hp的Ui
	public void UpdateHp(){
			TextHp.text=EmenyHp.ToString();
	}
	
}
