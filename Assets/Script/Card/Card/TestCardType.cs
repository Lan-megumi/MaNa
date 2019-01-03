using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	/*
		Type属性详解：
		对应卡牌属性中的 系 ，目前仅有元素系 Element
	 */
	public enum Type
	{
		Element
	}
	/*
		Element_type详解
		对应卡牌属性中的 类
	*/
	public enum Element_type
	{
		None,
		Fire,
		Water,
		Cloud
	}

	/*
		Rarity属性注解
		该属性用于表示稀有度
		zipp：			对应稀有度中的 白，英文网络意译 烂大街
		common：		对应稀有度中的 蓝，英文网络意译 常见的
		normal：		对应稀有度中的 紫，英文网络意译 一般的
		rare：			对于稀有度中的 金，英文网络意义 稀有的
	 */
	public enum Rarity
	{
		zipp,common,normal,rare
	}

	/*
		AttackeType属性详解
	*根据单词组成具体的属性
		0SingleDamage：单体伤害
		1GropupDamage：群体伤害
		2SingleCure：单体治疗
		3GropupCure：群体治疗
		4Sputtering: 溅射
		5SingleBuff： 单体buff
		6SingleDebuff： 单体Debuff
		7Empty: 空值
		8GroupBuff： 群体buff
		9GroupDeBuff： 群体Debuff

	 */
	public enum AttcakeType{
		SingleDamage,GroupDamage,SigeleCure,GroupCure,Sputtering,SingleBuff,SingleDebuff
		,Empty,GroupBuff,GroupDebuff
	}

