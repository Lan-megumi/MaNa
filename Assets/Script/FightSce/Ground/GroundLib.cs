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
	public int ReckonDamaged(double[] date){
		double Fina=0;
		Fina = GroundLibrary[0].Rule(date);
		
		return (int)Fina;
	
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
		public virtual double Rule(double[] date){
			return 0;
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
			double Reckon = date[0]*1;
			return Reckon;
		}  
	}
	///<summary>
	/// 竞技场
	///</summary>
	public class Arena:Ground{

		public override double Rule(double[] date){
			Debug.Log("Arena.Rule所有伤害提升3%");
			double Reckon = date[0]+date[0]*0.03;
			return Reckon;
		} 
	}



