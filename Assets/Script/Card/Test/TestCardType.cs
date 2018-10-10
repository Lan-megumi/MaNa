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

