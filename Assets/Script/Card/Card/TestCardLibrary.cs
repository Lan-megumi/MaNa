using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本用于实例化卡牌以及洗牌的功能
 */
public  class  TestCardLibrary:MonoBehaviour{
	public static TestCardLibrary _instance;
	TestCard EL01Fi = new TestCard("EL01Fi",(Type)0,(Element_type)0,(Rarity)0,"火花",1,25,(AttcakeType)0);
	TestCard EL02Fi = new TestCard("EL02Fi",(Type)0,(Element_type)0,(Rarity)0,"燃烧",3,40,(AttcakeType)0);
	TestCard EL03Fi = new TestCard("EL03Fi",(Type)0,(Element_type)0,(Rarity)1,"爆燃",6,55,(AttcakeType)4);
	TestCard EL04Fi = new TestCard("EL04Fi",(Type)0,(Element_type)0,(Rarity)2,"幽炎",5,60,(AttcakeType)0);
	TestCard EL05Fi = new TestCard("EL05Fi",(Type)0,(Element_type)0,(Rarity)2,"过热",7,0,(AttcakeType)0);
	TestCard EL06Fi = new TestCard("EL06Fi",(Type)0,(Element_type)0,(Rarity)0,"赤焰",2,35,(AttcakeType)0);
	TestCard EL07Fi = new TestCard("EL07Fi",(Type)0,(Element_type)0,(Rarity)1,"雷火",4,50,(AttcakeType)0);
	TestCard EL08Fi = new TestCard("EL08Fi",(Type)0,(Element_type)0,(Rarity)2,"天罡焱",7,70,(AttcakeType)0);
	TestCard EL09Fi = new TestCard("EL09Fi",(Type)0,(Element_type)0,(Rarity)2,"金灵律火",6,70,(AttcakeType)0);
	TestCard EL01Wa=new TestCard("EL01Wa",(Type)0,(Element_type)1,(Rarity)0,"飞溅",2,30,(AttcakeType)4);
	TestCard EL02Wa=new TestCard("EL02Wa",(Type)0,(Element_type)1,(Rarity)0,"清泉",4,25,(AttcakeType)2);
	TestCard EL03Wa=new TestCard("EL03Wa",(Type)0,(Element_type)1,(Rarity)1,"凝结",4,30,(AttcakeType)0);
	TestCard EL04Wa=new TestCard("EL04Wa",(Type)0,(Element_type)1,(Rarity)1,"暗潮",3,25,(AttcakeType)1);
	TestCard EL01C1=new TestCard("EL01C1",(Type)0,(Element_type)2,(Rarity)0,"蔓延",4,10,(AttcakeType)3);
	TestCard EL02C1=new TestCard("EL02C1",(Type)0,(Element_type)2,(Rarity)0,"轻盈",2,0,(AttcakeType)8);
	TestCard EL03C1=new TestCard("EL03C1",(Type)0,(Element_type)2,(Rarity)0,"旋风",3,40,(AttcakeType)4);
	TestCard EL04C1=new TestCard("EL04C1",(Type)0,(Element_type)2,(Rarity)3,"飓风迷域",6,30,(AttcakeType)1);
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
		Library0.Add(EL05Fi);
		Library0.Add(EL06Fi);
		Library0.Add(EL07Fi);
		Library0.Add(EL08Fi);
		Library0.Add(EL09Fi);
		Library0.Add(EL01Wa);
		Library0.Add(EL02Wa);
		Library0.Add(EL03Wa);
		Library0.Add(EL04Wa);
		Library0.Add(EL01C1);
		Library0.Add(EL02C1);
		Library0.Add(EL03C1);
		Library0.Add(EL04C1);
		Debug.Log("TestCardLib Star");
        
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
        TestMananger._instance.VisableCard();
	}

}
