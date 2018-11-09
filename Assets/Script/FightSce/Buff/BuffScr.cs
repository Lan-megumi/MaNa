using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	该脚本用于计算合成的两张牌的buff效果
	并触发
 */
public class BuffScr : MonoBehaviour {
	public string Buffid1,Buffid2,BuffName1,BuffName2;
	public float Buffrate1,Buffrate2,BuffNum1,BuffNum2;
	//用于接收计算出来的最终的rate
	public float Result_rate,Result_num;
	public string Result_name;
	
	public static BuffScr _instance;

	void Awake(){
		_instance=this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	
/*
	首先先获取第一张牌
	从ReadCard的jo（）方法中传值id1
 */
	public void Card1_Buff(string id){
		BuffLibrary._instance.FindBuff(id);
		Buffid1=BuffLibrary._instance.GetBuffid();
		BuffName1=BuffLibrary._instance.GetBuffName();
		Buffrate1=BuffLibrary._instance.GetBuffrate();
		BuffNum1=BuffLibrary._instance.GetBuffnum();
		BuffLibrary._instance.InitDate();
	}
/*
	然后是第二张牌
 */	
	public void Card2_Buff(string id){
		BuffLibrary._instance.FindBuff(id);
		Buffid2=BuffLibrary._instance.GetBuffid();
		BuffName2=BuffLibrary._instance.GetBuffName();
		Buffrate2=BuffLibrary._instance.GetBuffrate();
		BuffNum2=BuffLibrary._instance.GetBuffnum();
		BuffLibrary._instance.InitDate();
	}
/*
	准备好随机数
 */
	public float NewRandom(){
		System.Random rd = new System.Random();
		int a = rd.Next(100);
		float f =( float )(a * 0.01);
		// float f=Random.Range(0,1f);
		// Debug.Log("c#"+f+" |Unity"+ff);
		return f;
	}
	
/*
	然后开始计算
 */
	
	public void ReckonBuff(){
		// Debug.Log("ReckonBuff");
		float Rate = NewRandom();
		//首先是，当两张卡牌的buff一样的时候
		if (BuffName1==BuffName2)
		{
			/* 
				那么几率（rate）遵从 最终几率=高几率*（低几率+100%）
				相等也是同样
			*/
			if (Buffrate1>Buffrate2)
			{
				Result_rate=Buffrate1*(Buffrate2+1f);
			}else if (Buffrate2>Buffrate1)
			{
				Result_rate=Buffrate2*(Buffrate1+1f);
			}else
			{
				Result_rate=Buffrate2*(Buffrate1+1f);				
			}
			//然后执行伤害/数值相加
			Result_num=BuffNum1+BuffNum2;
			//给其类型赋值
			Result_name=BuffName1;
			// Debug.Log("BuffName1="+BuffName1);
			//当其命中的时候
			if (Rate+Result_rate>=1f)
			{
				PublicFightScr._instance.StarFunctoin3(Result_name);
				PublicFightScr._instance.StarFunction4(Result_num);
			}
		}else{
		//那么这里是不相等的情况

		}
		Debug.Log("Name:"+Result_name+" |Num:"+Result_num+" |Rate:"+Result_rate+" |Random:"+Rate);
	}


}
