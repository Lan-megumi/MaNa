using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	基础牌牌库：
	功能包含 发牌 洗牌 
 */
public class BasicCardDeck {
	private static BasicCardDeck _instance;

	private List<BasicCard> Library;					//泛型集合

	public static BasicCardDeck Instance{
		get{
			if (_instance == null)
			{
				_instance = new BasicCardDeck();
			}
			return _instance;
		}
	}
	//-------------------------获取牌库中的属性-----------------------------------
	//获取牌库中牌的总数
	public int CardsCount{
		get{return Library.Count;}
	}
	//获取牌库中某一牌的伤害
	public Damaged CardsDamage(int n){
		return Library[n].GetCardDamaged;
	}
	//-------------------------获取牌库中的属性-----------------------------------

	//索引
	public BasicCard this[int index]{
		get{return Library[index];}
	}
	//
	
	//创建一副牌
	private BasicCardDeck(){
		// Debug.Log("BasicCardDeck"+Library);
		Library=new List<BasicCard>();
		CreateBasicCard();
	}
	void CreateBasicCard(){
		for (int name = 0; name < 5; name++)
		{
			for (int damage = 0; damage < 5 ;damage++)
			{
				Damaged d = (Damaged)damage;
				string n = "BasicCard "+name.ToString();
				int indexof = name;
				
				//调用新建牌用到的方法
				BasicCard card = new BasicCard(n,d,indexof);

				Library.Add(card);
			}
		}
		//创建特殊牌

		// BasicCard cardTT=new BasicCard();
		// Library.Add(cardTT);
	}


	/*
		洗牌功能
		新建一个同样为BasicCard类型的泛型集合 newList，用于临时储存。
		将BasicCard已经新建好的数据通过Random打乱
		然后通过 Insert 来插入值？
		清空原有Library，将 newList中的数据重新Add回去
		最后将newList清空以便下一次洗牌的使用
	*/
	public void Shuffle(){
		Debug.Log("牌库总数"+CardsCount);
		Debug.Log("01d"+CardsDamage(0));
		Debug.Log("21d"+CardsDamage(20));


		if (CardsCount>=25)
		{
			Debug.Log("洗牌！");
			System.Random random=new System.Random();
			List<BasicCard> newList = new List<BasicCard>();

			foreach(BasicCard item in Library){
				newList.Insert(random.Next(newList.Count+1),item);
			}
			Library.Clear();									//清空
			foreach(BasicCard item in newList){
				Library.Add(item);
			}
			newList.Clear();									
		}
	}

	/*
		发牌功能
	 */
	public BasicCard DealCard(){
		//每发一张牌就要从牌库中减去一张牌
		BasicCard ret = Library[Library.Count-1];
		//发牌过后需要从牌库移除
		Library.Remove(ret);
		return ret;
	}
	
	public void AddCard(BasicCard bcard){
		Library.Add(bcard);
	}
}
