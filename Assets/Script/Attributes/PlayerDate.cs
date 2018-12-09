using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDate : MonoBehaviour {
/*
	Player脚本预想应有的功能
		在战斗场景游戏开始前读取存档获得玩家各项属性，无需新建实例
		在战斗场景战斗结束后更新玩家属性到存档中
			存档规范获取？
		敌人Ai可以通过此脚本调用到玩家的属性
			注意血量、Mana的最大值与当前值应作为两个不同的变量存在
		敌人的攻击技能实现理论通过调用该脚本

 */
	public static PlayerDate Instance;

    public static PlayerDate _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(PlayerDate))as PlayerDate;
            }
            return Instance;
        }
    }

/*
	准备用于接受玩家数据的变量
*/
	 public string Player_name="";
	 public int Hp,MaxHp,Mana,MaxMana,Rgs,Imm,Avd;
	 public float Agi;
	 //---------------------------------

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Testlinshi(){
		Debug.Log("临时玩家创建！");
		Hp=5000;MaxHp=Hp;Mana=600;MaxMana=Mana;Rgs=100;Imm=100;Avd=100;Agi=1f;
		Player_name="圣人惠她老公";
		this.GetComponent<PlayerUi>().UpdateName(Player_name);
		this.GetComponent<PlayerUi>().Update_HpSlider(MaxHp,Hp);
	}
	///<summary>
	/// 攻击玩家的方法
	///</summary>
	public int AttackePlayer(int damage){
		int Reckon= Hp-damage;
		if (Reckon<=0)
		{
			Debug.Log("玩家被击败了");
		}
		Hp=Reckon;
		UpdateHp();
		return Reckon;
	}
	///<summary>
	///	治疗玩家的方法
	///</summary>
	public void CurePlayer(int Cure){
		int Reckon= Hp+Cure;
		if (Reckon>=MaxHp)
		{
			Hp=MaxHp;
		}else
		{
			Hp=Reckon;
		}
		UpdateHp();
	}
	public void UpdateHp(){
		this.GetComponent<PlayerUi>().Update_HpSlider(MaxHp,Hp);
	}
//-----------------------------------------
	//以下分别为获取 玩家血量、最大血量、魔法抗性、异常抗性、闪避
	public int ReturnHp(){
		return Hp;
	}
	public int ReturnMaxHp(){
		return MaxHp;
	}
	public int ReturnRgs(){
		return Rgs;
	}
	public int ReturnImm(){
		return Imm;
	}
	public int ReturnAvd(){
		return Avd;
	}
	public int ReturnMaxMana(){
		return MaxMana;
	}
	public int ReturnMana(){
		return Mana;
	}
//-----------------------------------------
	
	
}