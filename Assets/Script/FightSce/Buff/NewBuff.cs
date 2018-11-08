using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	NewBuff
	用于填充对应Cardid的基础Buff效果
		Buff_id：与TestCard的Cardid一致
		Buff_name：用于查找是什么buff
		Buff_rate：用于储存buff命中几率
		Buff_Num：用于储存buff数值/伤害（燃烧限定）
 */
public class NewBuff {

	public string Buff_id;
	public string Buff_name;
	public float Buff_rate;
	public float Buff_Num;

	public NewBuff(string Buff_id,string Buff_name,float Buff_rate,float Buff_Num){
		this.Buff_id=Buff_id;
		this.Buff_name=Buff_name;
		this.Buff_rate=Buff_rate;
		this.Buff_Num=Buff_Num;
	}
	public string GetBuffid{
		get{return Buff_id;}
	}

	public string GetBuffname{
		get{return Buff_name;}
	}
	public float GetBuffrate{
		get{return Buff_rate;}
	}
	public float GetBuffNum{
		get{return Buff_Num;}
	}
}
