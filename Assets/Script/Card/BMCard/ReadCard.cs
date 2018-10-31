using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本用于读取卡牌中的数据
	属于公共脚本
	以及非BM（最佳合成）卡牌的合成
 */
public class ReadCard : MonoBehaviour {
	public List<TestCard> Library2;
	public static ReadCard _instance;

	void Awake(){
		_instance=this;
	}

//------------------------------------------
	public string Cardid1,Cardid2;
	private int CardDamage1,CardDamage2;
	private AttcakeType CardAttackeType1,CardAttackeType2;
//------------------------------------------

	// Use this for initialization
	void Start () {
		Library2 = new List<TestCard>();
	}

//这里是公开的传入参数的方法
/*
	该传入参数将被作用于jo()方法中，并且是触发jo()方法的唯一接口
	*/
	public void SetId(string id1,string id2){
		Cardid1=id1;
		Cardid2=id2;
		jo();
	}

/*
	合成调用的方法
	目前暂时只是根据id找到卡牌对应的伤害没有根据伤害类型
*/
	public void jo(){
	//首先同步卡牌，因为牌库有可能被洗牌，不过好像洗了牌也不影响
		Library2=TestCardLibrary._instance.Library0;
		// Debug.Log("Card1"+Cardid1+" | Card2:"+Cardid2);
		for(int i =0 ;i<Library2.Count;i++){

		//获取Damage值和AttacakeType
			if (Library2[i].GetCardid==Cardid1)
			{
				CardDamage1+=Library2[i].GetCardDamage;
				CardAttackeType1=Library2[i].GetAttcakeType;

				Debug.Log("CardDamage1:"+CardDamage1);
			}
			if (Library2[i].GetCardid==Cardid2)
			{
				CardDamage2+=Library2[i].GetCardDamage;
				CardAttackeType2=Library2[i].GetAttcakeType;
				Debug.Log("CardDamage2:"+CardDamage2);
			}
			// Debug.Log("Id"+i+":"+Library2[i].GetCardid);
		}
		//获取结束后执行伤害合成计算
		int Reckon=CardDamage1+CardDamage2;
		Debug.Log("Reckon:"+Reckon);
		PublicFightScr._instance.StarFunction2(Reckon.ToString());
	}


	//在结算完成后执行清空数据初始化数据
	public void InitDate(){
		Cardid1=null;
		Cardid2=null;
		CardDamage1=0;
		CardDamage2=0;
		CardAttackeType1=0;
		CardAttackeType2=0;

	}

}
