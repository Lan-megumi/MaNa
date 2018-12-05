using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///	SceStar：作为储存场景数据、游戏小关进程的脚本,在大关卡没有胜利通过或失败时不会被销毁
///</summary>
public class SceStar : MonoBehaviour {
	
	public string SceGround,LevelName;
	///<summary>
	///	用于储存游戏到了哪一小关
	///</summary>
	public int LELnum=1;
	///<summary>
	///	用于储存当前大关的最大值
	///</summary>
	public int MaxLELnum=0;
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
	LELnum：为调用不同敌人组合的数字
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
	public int Re_LELNum(){
		return LELnum;
	}
	public void add_LELNum(){
		LELnum++;
	}
	///<summary>
	///	获取每个大关的最大小敌人阵列的接口
	///<summary>
	public int Re_MaxLELnum(){
		return MaxLELnum;
	}
	///<summary>
	/// 修改Re_MaxLELnum值的接口，一般在GameController Star方法中赋值
	///</summary>
	public void Set_MaxLELnum(int i){
		MaxLELnum=i;
	}
	
	
	
}
