using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class BMCardLib  {
	BmBasic[] BmCardLibrary=new BmBasic[1];
	public void ChangeBm(string BmCardid){
		object b = Activator.CreateInstance(System.Type.GetType(BmCardid));
		BmCardLibrary[0]=(BmBasic)b;
	}
	
	public void UseBmRule1(){
		if (BmCardLibrary[0]!=null)
		{
			BmCardLibrary[0].Rule();
		}
	}
	public double[] UseBmRUle2(){
		double [] date={0,0,0,0,0};
		if (BmCardLibrary[0]!=null)
		{
			date=BmCardLibrary[0].Rule2();
		}
		return date;
	}
	
}
public class BmBasic{
	public string name=null;
	///<summary>
	///	Rule1方法为必定执行的方法
	///</summary>
	public virtual void Rule(){
		Debug.Log("BmBasic.Rule");
		name="BmBasic";
	}
	///<summary>
	///	Rule2方法为造成的伤害
	///</summary>
	public virtual double[] Rule2(){
		double[] d = {0,0,0,0,0,0};
		return d;
	}
	///<summary>
	///	Rule3方法为其他的方法
	///</summary>
	public virtual void Rule3(){
		Debug.Log("BmBasic.Rule3");
	}
	///<summary>
	///	Rule4方法为播放动画方法
	///</summary>
	public virtual string Rule4(){
		Debug.Log("BmBasic.Rule4");
		return Re_Name();
	}
	public string Re_Name(){
		return name;
	}
}
//----------------------------------
public class Bm01Fi:BmBasic{

	public override void Rule(){
		Debug.Log("Bm01Fi.Rule");
		name="Bm01Fi";
		this.Rule3();
	}
	public override double[] Rule2(){
		double[] d={100,1,1,0,0,0};
		return d;
	}
	public override void Rule3(){
		//改变场景
		GroundScr._instance.ChangeGround("Arena");
	}
}