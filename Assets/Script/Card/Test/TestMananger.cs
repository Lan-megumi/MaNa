using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	该脚本用于发牌以及实现实例化卡牌Ui功能
 */
public class TestMananger : MonoBehaviour {

	public List<GameObject> CardLibrary;
	public List<TestCard> Library1;

// //-----------------------------------------------------
//	定义用于接收卡牌属性的类
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
        VisableCard();

	}
	//用于更新牌组与牌库中的差异
	private void UpdateLibrary(){
		Library1= TestCardLibrary._instance.Library0;


	}
	//该方法功能为发牌，并且与Ui功能交互
	public void VisableCard(){
		UpdateLibrary();
		Debug.Log("1:"+Library1[1]);
		/*
			i上限为Ui界面牌的数量，3
		 */
		for (int i = 0; i < CardLibrary.Count; i++)
		{
			if (b==Library1.Count)
			{
                Debug.Log("aa" + Library1.Count);
                b =0;
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

