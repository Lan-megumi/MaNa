using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceStar : MonoBehaviour {
	

	public string SceGround,LevelName;
	public static SceStar _instance;
	//更规范的 单例写法  调用时 脚本名+Instance+方法
	public static SceStar Instance{
		get{
			if (null==_instance)
			{
				_instance=FindObjectOfType(typeof(SceStar))as SceStar;
			}
			return _instance;
		}
	}
	
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(this);
		
	}
	

/*
	该脚本用于改变场景传值的数据
	传值 i :关卡名
	LevelName : 关卡名
	SceNum：为调用不同敌人组合的数字
	SceGround:为场地场景
*/
	public void Set_SceNum(string i){
		LevelName=i;
		// SceNum=i;
		if (i=="San Fran_Out training ground")
		{
			SceGround="None";
			Debug.Log("场景地图没有 None");
		}
		
	}
	
	public string Re_SceGround(){
		return SceGround;
	}
	public string Re_LevelName(){
		return LevelName;
	}
	public void InitDate(){
		SceGround="";
		LevelName="";
	}
	
	
}
