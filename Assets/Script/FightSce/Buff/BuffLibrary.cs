
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本用于储存buff
	同时具有根据id查找buff的功能
 */
public class BuffLibrary : MonoBehaviour {
	public static BuffLibrary _instance;
	public List<NewBuff> BuffLibrary0;
	//--------------------------------------------------
	NewBuff EL01Fi=new NewBuff("EL01Fi","Fire",0.18f,0.03f);
	NewBuff EL02Fi=new NewBuff("EL02Fi","Fire",0.3f,0.03f);
	NewBuff EL03Fi=new NewBuff("EL03Fi","Fire",0.3f,0.05f);
	NewBuff EL04Fi=new NewBuff("EL04Fi","Fear",0.3f,0);
	NewBuff EL05Fi=new NewBuff("EL05Fi","Other",0,0);//-8%当前生命翻倍伤害
	NewBuff EL08Fi=new NewBuff("EL08Fi","Fire",0.5f,0.08f);
	NewBuff EL09Fi=new NewBuff("EL09Fi","Other",0,0);//清除敌方buff
	NewBuff EL03Wa=new NewBuff("EL03Wa","IceAche",0.3f,0);
	NewBuff EL04Wa=new NewBuff("EL04Wa","Cold",1f,0);//寒冷，增加一层冻伤
	NewBuff EL02Cl=new NewBuff("EL02Cl","Othre",1f,0.1f);//增加10闪避
	NewBuff EL03Cl=new NewBuff("EL03Cl","Cold",1f,0);//寒冷，增加一层冻伤
	NewBuff EL04Cl=new NewBuff("EL04Cl","Othre",1f,0.1f);//增加10闪避






	//--------------------------------------------------
	//用于接收查找到的buff属性
	public string BuffId,BuffName;
	public float Buffrate,BuffNum;
	//--------------------------------------------------

	// Use this for initialization
	void Start () {
		BuffLibrary0=new List<NewBuff>();
		BuffLibrary0.Add(EL01Fi);
		BuffLibrary0.Add(EL02Fi);
		BuffLibrary0.Add(EL03Fi);
		BuffLibrary0.Add(EL04Fi);
		BuffLibrary0.Add(EL05Fi);
		BuffLibrary0.Add(EL08Fi);
		BuffLibrary0.Add(EL09Fi);
		BuffLibrary0.Add(EL03Wa);
		BuffLibrary0.Add(EL04Wa);
		BuffLibrary0.Add(EL02Cl);
		BuffLibrary0.Add(EL03Cl);
		BuffLibrary0.Add(EL04Cl);
	}
	
	// Update is called once per frame
	public bool FindBuff(string id){
		string linshi_id=id;
		bool T=false;
		for (int i = 0; i < BuffLibrary0.Count; i++)
		{
			if (BuffLibrary0[i].GetBuffid==linshi_id)
			{
				BuffId=BuffLibrary0[i].GetBuffid;
				BuffName=BuffLibrary0[i].GetBuffname;
				Buffrate=BuffLibrary0[i].GetBuffrate;
				BuffNum=BuffLibrary0[i].GetBuffNum;
				T=true;
				break;
			}
		}
		return T;
	}
//-------------------------------------
	//返回特定值的方法
	public string GetBuffid(){
		return BuffId;
	}
	public string GetBuffName(){
		return BuffName;
	}
	public float GetBuffrate(){
		return Buffrate;
	}
	public float GetBuffnum(){
		return BuffNum;
	}
//-------------------------------------
	//初始化
	public void InitDate(){
		BuffId="";
		BuffName="";
		Buffrate=0;
		BuffNum=0;
	}
	
}
