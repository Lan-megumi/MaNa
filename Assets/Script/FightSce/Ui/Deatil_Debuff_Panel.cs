using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///	该脚本用于创建Deatil面板上的Debuff实例
///</summary>
public class Deatil_Debuff_Panel : MonoBehaviour {
	//用于储存生成物体的Obj
	public GameObject DebuffObj;
	//用于储存玩家身上的Debuff数组
	public int[] Player_DebuffArray;
	//用于储存玩家身上的Debuff数组
	public int[] Enemy_DebuffArray;
	// Use this for initialization
	void Awake () {
		//初始化数组，长度为5
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
