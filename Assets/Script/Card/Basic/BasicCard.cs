using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本用于定义基础牌的类别
	属性：
	名字String
	卡牌伤害int
	卡牌索引int
 */
public class BasicCard {

	private readonly string CardName;
	private readonly Damaged CardDamaged;
	private readonly int CardIndexof;
	//新建牌用到的方法
	public BasicCard(string CardsName,Damaged CardsDamaged,int CardsIndexof){
		this.CardName=CardsName;
		this.CardDamaged=CardsDamaged;
		this.CardIndexof=CardsIndexof;
	}
/*
	定义函数返回卡片属性
 */

	public string GetCardName{
		get{return CardName;}
	}
	public Damaged  GetCardDamaged{
		get{return CardDamaged;}
	}
	public int GetCardsIndexof{
		get{return CardIndexof;}
	}
}
