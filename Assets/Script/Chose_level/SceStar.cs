using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceStar : MonoBehaviour {
	
	public int SceNum;
	public string SceGround;
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
	
	// Update is called once per frame
/*
	该脚本用于改变场景传值的数据
	SceNum：为调用不同敌人组合的数字
	SceGround:为场地场景
*/
	public void Set_SceNum(int i){
		SceNum=i;
		if (i==1)
		{
			SceGround="Strom_labyrinth";
			Debug.Log("场景地图为飓风迷域 Strom_labyrinth");
		}
		if (i==2)
		{
			SceGround="Strom_labyrinth";
			Debug.Log("场景地图为飓风迷域 Strom_labyrinth");
		}
		if (i==3)
		{
			SceGround="Arena";
			Debug.Log("场景地图为飓风迷域 Arena");
		}
		// Debug.Log("SceNum:"+SceNum);
	}
	
	public int Re_SceNum(){
		return SceNum;
	}
	public string Re_SceGround(){
		return SceGround;
	}
	public void InitDate(){
		SceNum=0;
		SceGround="";
	}
	
	
}
