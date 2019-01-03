using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

/*
	该脚本用于存储场景计算公式，并且使其能被正确的调用
	实现思路
	通过外部方法将传入的场景名字(string)类型导入至UponGround(string)方法中，使其生成对应场景的类
	开放 ReckonDamaged(double[]) 方法作为接口进行运算
*/
public class GroundLib  {
	// Use this for initialization
	// List<Ground> GroundLibrary=new List<Ground>();
	Ground[] GroundLibrary=new Ground[1];
	

///<summary>
/// 这里是调用公式的接口会返回一个强制转换为int值的数字给 ReadCard.Reckon重新接收
///</summary>
	public int ReckonRule1(double[] date){
		double Fina=0;
		Fina = GroundLibrary[0].Rule(date);
		
		return (int)Fina;
	
	}
///<summary>
/// Rule2会返回一个人物属性数组
///</summary>
	public double[] ReckonRule2(){
		
		double[] d = GroundLibrary[0].Rule2();
		return d;
	
	}
///<summary>
/// Rule2Init会返回一个人物属性数组
///</summary>
	public double[] ReckonRule2Init(){
		double[]d=null;
		if (GroundLibrary[0]==null)
		{	
		}else{
			d = GroundLibrary[0].Rule2Init();
		}
		
		return d;
	}

///<summary>
/// Rule3：随机攻击效果,返回一个数组
///</summary>
	public double[] ReckonRule3(){
		
		double[] d= GroundLibrary[0].Rule3();
		return d;
	
	}
///<summary>
///	这个方法是将对应场景的类生成出来的方法
///		,场景影响伤害的公式在类中继承父类的 Rule(double[])方法中
///</summary>
	public void UponGround(string GroundName){
		//MethodInfo Ground_Class=GroundType.GetMethod(GroundName);
		object b = Activator.CreateInstance(System.Type.GetType(GroundName));
		Debug.Log("被置顶的场景类型:"+b.GetType());
		GroundLibrary[0]=((Ground)b);
		GroundLibrary[0].name=GroundName;
	}
}
 
//----------

	public class Ground  {
		public string name;
		// Use this for initialization
		///<summary>
		///	Rule方法用于场景专属的影响伤害效果,传入的double数组应为伤害规范数组，返回一个double类型变量或数组
		///</summary>
		public virtual double Rule(double[] date){
			Debug.Log("执行了基础场景的Rule方法");
			return 0;
		}
		///<summary>
		///	Rule2方法用于影响当前场景的人的属性,返回的double数组应为属性规范数组
		///</summary>
		public virtual double[] Rule2(){
			Debug.Log("执行了基础场景的Rule2方法");

			double[] d={0,0,0,0,0,0};
			
			return d;
		}
		///<summary>
		///	Rule2Init方法用于场景切换前执行，改回被扣减的属性,传入的double数组应为属性规范数组,返回一个double类型变量或数组
		///</summary>
		public virtual double[] Rule2Init(){
			Debug.Log("执行了基础场景的Rule2Init方法");

			double[] d={0,0,0,0,0,0};

			return d;
		}
		///<summary>
		///	Rule3方法用于随机攻击的效果,返回一个double类型的数组，里面储存伤害值以及类型
		///</summary>
		public virtual double[] Rule3(){
			Debug.Log("执行了基础场景的Rule3方法");
			double[]d={0,0,0,0,0,0};
			return d;
		}
		public string GetName{
			set{name=value;}
			get{return name;}
		}
		
	}
	///<summary>
	/// 无场景
	///</summary>
	public class None:Ground{
		
		public override double Rule(double[] date){
			Debug.Log("None.Rule");
			double Reckon = date[0]*1;
			return Reckon;
		}  
	}
	///<summary>
	/// 飓风迷域(未实现)
	///</summary>
	public class Strom_labyrinth:Ground{

		public override double Rule(double[] date){
			Debug.Log("Strom_labyrinth.Rule");
			if(date[1]==1){
				date[0]*=(1-0.15);
			}else if (date[1]==3)
			{
				date[0]*=1.20;
			}
			double Reckon=date[0];
			return Reckon;
		}  
		public override double[] Rule2(){
			double[] date={
				0,0,0,0,0,-0.05
			};
			return date;
		}

		public override double[] Rule2Init(){
			double[] date={
				0,0,0,0,0,0.05
			};
			return date;
		}
	}
	///<summary>
	/// 竞技场
	///</summary>
	public class Arena:Ground{
		float Rate=0.0f;
		public override double[] Rule3(){
			Debug.Log("Arena.Rule3");
			double [] reckonDeatil={0,0,0};
			int Reckon = 0;//第一位数
			int AttcakeType=99;//第二位数
			System.Random rd = new System.Random();
			float f = (float)(rd.Next(100)*0.01);
			// Debug.Log("Arena:f"+f);
			if (0.7+f+Rate>=1)
			{
				Reckon=10;
				AttcakeType=1;
				Rate=0.0f;
			}else{
				Rate+=0.1f;
			}
			reckonDeatil[0]=(double)Reckon;
			reckonDeatil[1]=(double)AttcakeType;
			return reckonDeatil;
		} 
	}



