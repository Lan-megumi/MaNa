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
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
		合成调用的方法
		目前暂时只是根据id找到卡牌对应的伤害没有根据伤害类型
	*/
	public void jo(){
		Library2=TestCardLibrary._instance.Library0;
		for(int i =0 ;i<Library2.Count;i++){
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
		SetDamaged();
	}
	//这里是传入参数的方法
	private void SetId(string id1,string id2){
		Cardid1=id1;
		Cardid2=id2;
	}
	//
	public void SetDamaged(){
		int Reckon=CardDamage1+CardDamage2;
		Debug.Log("Reckon:"+Reckon);

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
