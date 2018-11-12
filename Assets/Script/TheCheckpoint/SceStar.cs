using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceStar : MonoBehaviour {
	
	public int SceNum;
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

	public void Set_SceNum(int i){
		SceNum=i;
		Debug.Log("SceNum:"+SceNum);
		
	}
	
	public int Re_SceNum(){
		return SceNum;
	}
	
}
