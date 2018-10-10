using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
