using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMananger : MonoBehaviour {

	public List<GameObject> CardLibrary;
	public List<TestCard> Library1;

// //-----------------------------------------------------
	private string Cardid;
	private Type CardType;
	private Element_type CardEle;
	private Rarity CardRarity;
	private string CardName;
	
	
//-----------------------------------------------------	
	private int b,c=0;
	void Start(){
		Library1=new List<TestCard>();
		Debug.Log("0:"+Library1);

	}
	private void UpdateLibrary(){
		Library1= TestCardLibrary._instance.Library0;
	}
	public void VisableCard(){
		UpdateLibrary();
		Debug.Log("1:"+Library1[1]);
		/*
			i上限为Ui界面牌的数量，3
		 */
		for (int i = 0; i < CardLibrary.Count; i++)
		{
			if (b==4)
			{
				b=0;
			}
				Cardid=Library1[b].GetCardid;
				CardType=Library1[b].GetCardType;
				CardEle=Library1[b].GetCardElement_type;
				CardRarity=Library1[b].GetCardRarity;
				CardName=Library1[b].GetCardName;
			
				CardLibrary[i].GetComponent<CardUi>().ChangeUi(Cardid,CardType,CardEle,CardRarity,CardName);
			b++;
			
		}
		
	}
}

