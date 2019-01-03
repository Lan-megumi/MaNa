using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本用于实例化卡牌以及洗牌的功能
 */
public  class  TestCardLibrary:MonoBehaviour{
	public static TestCardLibrary _instance;
	TestCard EL01Fi = new TestCard("EL01Fi",(Type)0,(Element_type)1,(Rarity)0,"火花",1,25,(AttcakeType)0,0);
	TestCard EL02Fi = new TestCard("EL02Fi",(Type)0,(Element_type)1,(Rarity)0,"灼烧",3,40,(AttcakeType)0,0);
    TestCard EL03Fi = new TestCard("EL03Fi",(Type)0,(Element_type)1,(Rarity)0,"炽焰",2,40,(AttcakeType)0,0);
    TestCard EL04Fi = new TestCard("EL04Fi",(Type)0,(Element_type)1,(Rarity)1,"爆燃",6,45,(AttcakeType)4,0);
    TestCard EL05Fi = new TestCard("EL05Fi",(Type)0,(Element_type)1,(Rarity)1,"雷火",4,50,(AttcakeType)0,0);
    TestCard EL06Fi = new TestCard("EL06Fi",(Type)0,(Element_type)1,(Rarity)1,"绯焰",4,45,(AttcakeType)0,0);
    TestCard EL07Fi = new TestCard("EL07Fi",(Type)0,(Element_type)1,(Rarity)2,"幽炎",5,60,(AttcakeType)0,0);
    TestCard EL08Fi = new TestCard("EL08Fi",(Type)0,(Element_type)1,(Rarity)2,"过热",4,50,(AttcakeType)0,0);
    TestCard EL09Fi = new TestCard("EL09Fi",(Type)0,(Element_type)1,(Rarity)2,"天罡焱",7,70,(AttcakeType)0,0);
    TestCard EL10Fi = new TestCard("EL10Fi",(Type)0,(Element_type)1,(Rarity)2,"雨焰",6,40,(AttcakeType)1,0);
    TestCard EL11Fi = new TestCard("EL11Fi",(Type)0,(Element_type)1,(Rarity)3,"金灵律火",6,70,(AttcakeType)0,0);
    TestCard EL12Fi = new TestCard("EL12Fi",(Type)0,(Element_type)1,(Rarity)3,"炼狱",8,70,(AttcakeType)1,0);
    
    TestCard EL01Wa=new TestCard("EL01Wa",(Type)0,(Element_type)2,(Rarity)0,"飞溅",2,30,(AttcakeType)4,0);
    TestCard EL02Wa=new TestCard("EL02Wa",(Type)0,(Element_type)2,(Rarity)0,"清泉",4,25,(AttcakeType)2,40);
    TestCard EL03Wa=new TestCard("EL03Wa",(Type)0,(Element_type)2,(Rarity)1,"凝结",4,30,(AttcakeType)0,0);
    TestCard EL04Wa=new TestCard("EL04Wa",(Type)0,(Element_type)2,(Rarity)1,"暗潮",3,25,(AttcakeType)1,0);
    TestCard EL05Wa=new TestCard("EL05Wa",(Type)0,(Element_type)2,(Rarity)1,"暴雪",4,30,(AttcakeType)1,0);
    TestCard EL06Wa=new TestCard("EL06Wa",(Type)0,(Element_type)2,(Rarity)1,"翻涌",3,40,(AttcakeType)4,10);
    TestCard EL07Wa=new TestCard("EL07Wa",(Type)0,(Element_type)2,(Rarity)1,"破浪",3,50,(AttcakeType)0,0);
    TestCard EL08Wa=new TestCard("EL08Wa",(Type)0,(Element_type)2,(Rarity)2,"逝潮",4,30,(AttcakeType)1,0);
    TestCard EL09Wa=new TestCard("EL09Wa",(Type)0,(Element_type)2,(Rarity)2,"碧涛",4,40,(AttcakeType)4,10);
    TestCard EL10Wa=new TestCard("EL10Wa",(Type)0,(Element_type)2,(Rarity)2,"渗透",4,40,(AttcakeType)0,0);
    TestCard EL11Wa=new TestCard("EL11Wa",(Type)0,(Element_type)2,(Rarity)3,"洛水",4,25,(AttcakeType)2,40);
    TestCard EL12Wa=new TestCard("EL12Wa",(Type)0,(Element_type)2,(Rarity)3,"绝寒",8,70,(AttcakeType)1,0);

    TestCard EL01Cl=new TestCard("EL01Cl",(Type)0,(Element_type)3,(Rarity)0,"蔓延",3,10,(AttcakeType)1,0);
    TestCard EL02Cl=new TestCard("EL02Cl",(Type)0,(Element_type)3,(Rarity)0,"轻盈",2,15,(AttcakeType)8,0);
    TestCard EL03Cl=new TestCard("EL03Cl",(Type)0,(Element_type)3,(Rarity)0,"悲风",3,40,(AttcakeType)4,0);
    TestCard EL04Cl=new TestCard("EL04Cl",(Type)0,(Element_type)3,(Rarity)1,"氤氲",3,20,(AttcakeType)8,0);
    TestCard EL05Cl=new TestCard("EL05Cl",(Type)0,(Element_type)3,(Rarity)1,"狂风",4,25,(AttcakeType)1,0);
    TestCard EL06Cl=new TestCard("EL06Cl",(Type)0,(Element_type)3,(Rarity)1,"涡旋",3,50,(AttcakeType)0,0);
    TestCard EL07Cl=new TestCard("EL07Cl",(Type)0,(Element_type)3,(Rarity)2,"气浪",4,70,(AttcakeType)0,10);
    TestCard EL08Cl=new TestCard("EL08Cl",(Type)0,(Element_type)3,(Rarity)2,"风挽",4,40,(AttcakeType)4,20);
    TestCard EL09Cl=new TestCard("EL09Cl",(Type)0,(Element_type)3,(Rarity)2,"风痕",4,60,(AttcakeType)0,0);
    TestCard EL10Cl=new TestCard("EL10Cl",(Type)0,(Element_type)3,(Rarity)3,"迷域",6,30,(AttcakeType)1,0);
    TestCard EL11Cl=new TestCard("EL11Cl",(Type)0,(Element_type)3,(Rarity)3,"苍穹",7,50,(AttcakeType)1,0);
    TestCard EL12Cl=new TestCard("EL12Cl",(Type)0,(Element_type)3,(Rarity)3,"风语",6,55,(AttcakeType)1,0);
    // public Text IdText,TypeText,EleText,RarityText,NameText;
    public List<TestCard> Library0;
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
        Library0.Add(EL10Fi);
        Library0.Add(EL11Fi);
        Library0.Add(EL12Fi);

        Library0.Add(EL01Wa);
		Library0.Add(EL02Wa);
		Library0.Add(EL03Wa);
		Library0.Add(EL04Wa);
        Library0.Add(EL05Wa);
        Library0.Add(EL06Wa);
        Library0.Add(EL07Wa);
        Library0.Add(EL08Wa);
        Library0.Add(EL09Wa);
        Library0.Add(EL10Wa);
        Library0.Add(EL11Wa);
        Library0.Add(EL12Wa);

        Library0.Add(EL01Cl);
		Library0.Add(EL02Cl);
		Library0.Add(EL03Cl);
		Library0.Add(EL04Cl);
        Library0.Add(EL05Cl);
        Library0.Add(EL06Cl);
        Library0.Add(EL07Cl);
        Library0.Add(EL08Cl);
        Library0.Add(EL09Cl);
        Library0.Add(EL10Cl);
        Library0.Add(EL11Cl);
        Library0.Add(EL12Cl);
        // Debug.Log("TestCardLib Star");

    }
	
	/*
	洗牌功能
		由于牌库体制尚未健全，使用洗牌功能有一定几率出现以下Bug
	*洗牌后手牌出现两张一摸一样的牌,在12.5版本以前不存在会出现两张一模一样的卡牌
	*打出去的牌下回合立即抽到，理由同上
		Bug本质：
	发牌是根据 Libray0 数组的下标来发牌，而洗牌则是重新打乱Library0数组的内
	每一个数据的位置，所以由于发牌机制的不健全逻辑不完整是有可能出现上述Bug的。
	*/
	public void OrbLibrary(){
		System.Random random =new System.Random();
		// Debug.Log("Random:"+random);
		List<TestCard> OrbList = new List<TestCard>();
		foreach(TestCard item in Library0){
				OrbList.Insert(random.Next(OrbList.Count+1),item);
			}
			Library0.Clear();									//清空
			foreach(TestCard item in OrbList){
				Library0.Add(item);
			}
			OrbList.Clear();
        // TestMananger._instance.VisableCard();
	}

}
