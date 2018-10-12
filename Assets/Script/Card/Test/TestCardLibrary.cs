using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本用于实例化卡牌以及洗牌的功能
 */
public  class  TestCardLibrary:MonoBehaviour{
	public static TestCardLibrary _instance;
	TestCard EL01Fi = new TestCard("EL01Fi",(Type)0,(Element_type)0,(Rarity)0,"火花");
	TestCard EL02Fi = new TestCard("EL02Fi",(Type)0,(Element_type)0,(Rarity)0,"燃烧");
	TestCard EL03Fi = new TestCard("EL03Fi",(Type)0,(Element_type)0,(Rarity)1,"爆燃");
	TestCard EL04Fi = new TestCard("EL04Fi",(Type)0,(Element_type)0,(Rarity)2,"幽炎");
	TestCard EL01Wa=new TestCard("EL01Wa",(Type)0,(Element_type)1,(Rarity)0,"飞溅");
	TestCard EL02Wa=new TestCard("EL02Wa",(Type)0,(Element_type)1,(Rarity)0,"清泉");
	TestCard EL03Wa=new TestCard("EL03Wa",(Type)0,(Element_type)1,(Rarity)1,"凝结");
	TestCard EL04Wa=new TestCard("EL04Wa",(Type)0,(Element_type)1,(Rarity)1,"暗潮");
	TestCard EL01C1=new TestCard("EL01C1",(Type)0,(Element_type)2,(Rarity)0,"蔓延");
	TestCard EL02C1=new TestCard("EL02C1",(Type)0,(Element_type)2,(Rarity)0,"轻盈");
	TestCard EL03C1=new TestCard("EL03C1",(Type)0,(Element_type)2,(Rarity)0,"旋风");
	TestCard EL04C1=new TestCard("EL04C1",(Type)0,(Element_type)2,(Rarity)3,"飓风迷域");
	// public Text IdText,TypeText,EleText,RarityText,NameText;
	public List<TestCard> Library0;
	private int n =0;
	private bool t =true;
	void Awake(){
		_instance=this;
	}
	void Start(){
		Library0=new List<TestCard>();
		Library0.Add(EL01Fi);
		Library0.Add(EL02Fi);
		Library0.Add(EL03Fi);
		Library0.Add(EL04Fi);
		Library0.Add(EL01Wa);
		Library0.Add(EL02Wa);
		Library0.Add(EL03Wa);
		Library0.Add(EL04Wa);
		Library0.Add(EL01C1);
		Library0.Add(EL02C1);
		Library0.Add(EL03C1);
		Library0.Add(EL04C1);
	}
	public void Card_EL01Fi(){

		if (t == true)
		{
			Debug.Log(Library0[0]+"Add Card!");
		}
	}
	//洗牌功能
	public void OrbLibrary(){
		System.Random random =new System.Random();
		Debug.Log("Random:"+random);
		List<TestCard> OrbList = new List<TestCard>();
		foreach(TestCard item in Library0){
				OrbList.Insert(random.Next(OrbList.Count+1),item);
			}
			Library0.Clear();									//清空
			foreach(TestCard item in OrbList){
				Library0.Add(item);
			}
			OrbList.Clear();	
	}

}
