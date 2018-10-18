using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	该脚本用于发牌以及实现实例化卡牌Ui功能
 */
public class TestMananger : MonoBehaviour
{

    public static TestMananger _instance;

    public List<GameObject> CardLibrary;
    public List<TestCard> Library1;

    // //-----------------------------------------------------
    //	定义用于接收卡牌属性的类
    [HideInInspector]
    public string Cardid;
    public Type CardType;
    public Element_type CardEle;
    public Rarity CardRarity;
    public string CardName;

    public bool BCard, BCard1, BCard2 = false;
    //-----------------------------------------------------	
    private int b, c = 0;
    private int d;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        Library1 = new List<TestCard>();
        VisableCard();
    }
    //用于更新牌组与牌库中的差异
    private void UpdateLibrary()
    {
        Library1 = TestCardLibrary._instance.Library0;
    }
   
    public void ShotA()
    {
        BCard = true;
        ShotAA();
    }
    public void ShotB()
    {
        BCard1 = true;
        ShotAA();
    }
    public void ShotC()
    {
        BCard2 = true;
        ShotAA();
    }

    //该方法功能为发牌，并且与Ui功能交互
    public void VisableCard()
    {
        UpdateLibrary();
        //Debug.Log("1:" + Library1[1]);
        /*
			i上限为Ui界面牌的数量，3
		 */
        for (int i = 0; i < CardLibrary.Count; i++)
        {
            if (b == Library1.Count)
            {
                Debug.Log("aa" + Library1.Count);
                b = 0;
            }
            Cardid = Library1[b].GetCardid;
            CardType = Library1[b].GetCardType;
            CardEle = Library1[b].GetCardElement_type;
            CardRarity = Library1[b].GetCardRarity;
            CardName = Library1[b].GetCardName;

            CardLibrary[i].GetComponent<CardUi>().ChangeUi(Cardid, CardType, CardEle, CardRarity, CardName);
            d =b;
            b++;
            

        }
    }
    public void ShotAA()
    {
        Debug.Log("------------------");
        Debug.Log("ShotAA-d:" + d);
        if (BCard2 == true)
        {
            Cardid = Library1[d].GetCardid;
            CardType = Library1[d].GetCardType;
            CardEle = Library1[d].GetCardElement_type;
            CardRarity = Library1[d].GetCardRarity;
            CardName = Library1[d].GetCardName;
            Debug.Log(Cardid);
            Debug.Log(CardType);
            Debug.Log(CardEle);
            Debug.Log(CardRarity);
            Debug.Log(CardName);
            BCard2 = false;
            //return;
        }
        if (BCard1 == true)
        {

            Cardid = Library1[d - 1].GetCardid;
            CardType = Library1[d - 1].GetCardType;
            CardEle = Library1[d - 1].GetCardElement_type;
            CardRarity = Library1[d - 1].GetCardRarity;
            CardName = Library1[d - 1].GetCardName;
            Debug.Log(Cardid);
            Debug.Log(CardType);
            Debug.Log(CardEle);
            Debug.Log(CardRarity);
            Debug.Log(CardName);
            BCard1 = false;
            //return;
        }
        if (BCard == true)
        {
            Cardid = Library1[d - 2].GetCardid;
            CardType = Library1[d - 2].GetCardType;
            CardEle = Library1[d - 2].GetCardElement_type;
            CardRarity = Library1[d - 2].GetCardRarity;
            CardName = Library1[d - 2].GetCardName;

            Debug.Log(Cardid);
            Debug.Log(CardType);
            Debug.Log(CardEle);
            Debug.Log(CardRarity);
            Debug.Log(CardName);
            BCard = false;
            //return;
        }
    }
}
    


