using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Attributes类的
	人物/敌人属性详解：
	Hp					生命值
	Mana			  法力值
	Rgs					魔法抗性
	Agi					速度/咏唱速度
	Imm				  异常抗性(immunity)
	Avd				   闪避
*/
public class Attributes  {
	public int Hp;
	public int  Mana;
	public int Rgs;
	public float Agi;
	public int Imm;
	public int Avd;
	public string Name;

	public virtual double Passivity_skill(int i){
		Debug.Log("这里是父类的被动技能");
		return 0.0;
	}
	
	public int GetHp{
		set{Hp=value;}
		get{ return Hp;}
	}
	public int GetMana{
		set{Mana=value;}
		get{ return Mana;}
	}
	public int GetRgs{
		set{Rgs=value;}
		get{ return Rgs;}
	}
	public float GetAgi{
		set{Agi=value;}
		get{ return Agi;}
	}
	public int GetImm{
		set{Imm=value;}
		get{ return Imm;}
	}
	public int GetAvd{
		set{Avd=value;}
		get{ return Avd;}
	}
	public string GetName{
		set{Name=value;}
		get{return Name;}
	}
}

