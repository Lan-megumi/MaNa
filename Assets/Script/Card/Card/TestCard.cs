using System.Collections;
using System.Collections.Generic;

/*
	该脚本用于实现卡牌的基本属性类
	Cardid						卡的id，是一个独立出来的字符串
	CardType 				  详见TestCardType脚本，是一个自定义的Type类型
	CardElement_type	详见TestCardType脚本，是一个自定义的Element_type类型
	CardRarity				   详见TestCardType脚本，是一个自定义的Rarity类型
	CardName 				卡的名字，是一个字符串
	---------2018.10.19--------
	CardCost					卡的消耗
	CardDamge				 卡的伤害
	---------2018.10.29--------
	CardAttType 			  卡的伤害类型，是一个自定义的AttcakeType类型
	---------2018.12.02--------
	CardCure					 卡的治疗数值
*/
public class TestCard{
	public  string Cardid;
	public   Type CardType;
	public  Element_type CardElement_type;
	public  Rarity CardRarity;
	public  string CardName;
	public int CardCost,CardDamge,CardCure;

	public AttcakeType CardAttType;
	// private readonly

	//新建牌库用到的方法
	// public TestCard(){
		
	// }
	//目前主要用到下面这个构造方法，没有传参的部分可用于继承的子类里填充数据
	public TestCard(string Cardid,Type CardType,Element_type CardElement_type,Rarity CardRarity,string CardName,int CardCose,int CardDamge,AttcakeType CardAttType,int CardCure){
		this.Cardid=Cardid;
		this.CardType=CardType;
		this.CardElement_type=CardElement_type;
		this.CardRarity=CardRarity;
		this.CardName=CardName;
		this.CardCost=CardCose;
		this.CardDamge=CardDamge;
		this.CardAttType=CardAttType;
		this.CardCure=CardCure;
	}
	
/*
	定义接口返回卡片属性
 */
	public string GetCardid{
		get{return Cardid;}
		
	}

	public Type GetCardType{
		get{return CardType;}
		
	}

	public Element_type GetCardElement_type{
		get{return CardElement_type;}
	}
	
	public Rarity GetCardRarity{
		get{return CardRarity;}
	}

	public string GetCardName{
		get{return CardName;}
	}
	public int GetCardCost{
		get{return CardCost;}
	}

	public int GetCardDamage{
		get{return CardDamge;}
	}

	public AttcakeType GetAttcakeType{
		get{return CardAttType;}
	}

	public int GetCardCure{
		get{return CardCure;}
	}

}
