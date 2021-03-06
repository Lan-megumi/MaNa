﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBtnScr : MonoBehaviour {

	
	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		CheckDate();
	}

	///<summary>
	///	通过此读取Player的公共战斗数据以及进入Player的计算方法,绑定于按钮上
	///</summary>
	public void CheckDate(){
		string type0=PlayerFightScr._instance.Re_N_Type();
		string num = PlayerFightScr._instance.Re_N_Num();
		if (num!="")
		{
			if (type0=="Damage")
			{
				PlayerDate._instance.AttackePlayer(int.Parse(num));
			}
			if (type0=="Cure")
			{
				PlayerDate._instance.CurePlayer(int.Parse(num));
				Debug.Log("Cure!"+num);
			}
		}else
		{
			Debug.Log("Player公共战斗脚本中的数值为空");
			ShowDetail();
		}
		PlayerFightScr._instance.InitDate();
	}
	///<summary>
	///	点击玩家显示详细数据的点击方法
	///</summary>
	public void ShowDetail(){
		int MaxHp=this.GetComponent<PlayerDate>().ReturnMaxHp();
		int Hp = this.GetComponent<PlayerDate>().ReturnHp();
		int MaxMana = this.GetComponent<PlayerDate>().ReturnMaxMana();
		int Mana = this.GetComponent<PlayerDate>().ReturnMana();
		// Debug.Log("Hp:"+Hp+" MaxHp:"+MaxHp);
		// Debug.Log("Mana:"+Mana+" MaxMana:"+MaxMana)
		string Headportrait=this.GetComponent<PlayerDate>().Re_Headportrait();

		Player_Deatil_Ui._instance.ShowHpDeatil(MaxHp,Hp);
		Player_Deatil_Ui._instance.ShowMannaDeatil(MaxMana,Mana);
		Player_Deatil_Ui._instance.ShowHeadportrait(Headportrait);

		//执行获取Ui并且显示方法
	}

}
