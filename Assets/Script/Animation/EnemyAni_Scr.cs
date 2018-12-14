using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	Animator设置是注意Animation Clip的Has Exit Time
	这个的意思是等这个状态播放完才会执行其他的状态。
 */

///<summary>
///	敌人动画播放脚本
///</summary>
public class EnemyAni_Scr : MonoBehaviour {
	public Image FatherObj;
	public Animator Anim;


	// Use this for initialization
	void Start () {
		FatherObj=this.GetComponent<Image>();

		Anim=this.GetComponent<Animator>();
	}
	
	// Update is called once per frama
	public void StarDamged(){
		Anim.SetBool("IfDamage",true);
	}
	public void StarCure(){
		Anim.SetBool("IfCure",true);
	}
	public void StarDie(){
		Anim.SetBool("IfDie",true);
	}
	//方便动画获取脚本做的跳转值DmScr脚本内的方法
	public void DieFun(){
		DmScr._instance. DestoryEnemy();
	}
	//执行播放完动画后帧的调用脚本
	public void AnimationInit(){
		Anim.SetBool("IfDamage",false);
		Anim.SetBool("IfCure",false);
		Anim.SetBool("IfDie",false);

	}
}
