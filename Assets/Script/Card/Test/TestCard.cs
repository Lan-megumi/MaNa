using System.Collections;
using System.Collections.Generic;
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
