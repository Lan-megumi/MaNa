using System.Collections;
using System.Collections.Generic;

/*
	该脚本用于实现卡牌的基本属性类
	Cardid						卡的id，是一个独立出来的字符串
	CardType 				  详见TestCardType脚本，是一个自定义的Type类型
	CardElement_type	详见TestCardType脚本，是一个自定义的Element_type类型
	CardRarity				   详见TestCardType脚本，是一个自定义的Rarity类型
	CardName 				卡的名字，是一个字符串
 */
public class TestCard{
	public  string Cardid;
	public   Type CardType;
	public  Element_type CardElement_type;
	public  Rarity CardRarity;
	public  string CardName;
	// private readonly

	//新建牌库用到的方法
	public TestCard(){
		
	}
	//目前主要用到下面这个构造方法，没有传参的部分可用于继承的子类里填充数据
	public TestCard(string Cardid,Type CardType,Element_type CardElement_type,Rarity CardRarity,string CardName){
		this.Cardid=Cardid;
		this.CardType=CardType;
		this.CardElement_type=CardElement_type;
		this.CardRarity=CardRarity;
		this.CardName=CardName;
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



}
