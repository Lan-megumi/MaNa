using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本用于实例化卡牌
	定义对应卡牌属性的各个Text控件并且绑定，然后通过修改 text 将接收过来的参数强制转换为string逐个填充
 */
public class CardUi : MonoBehaviour {
	public Text IdText,TypeText,EleText,RarityText,NameText;
	public static CardUi _instance;

	void Awake(){
		_instance=this;
	}
	void Start () {
		
	}
	public void ChangeUi(string Cardid,Type CardType,Element_type CardEle,Rarity CardRarity,string CardName){
		IdText.text=Cardid;
		 TypeText.text=CardType.ToString();
		 EleText.text=CardEle.ToString();
		 RarityText.text=CardRarity.ToString();
		 NameText.text=CardName.ToString();
	}
	

}
