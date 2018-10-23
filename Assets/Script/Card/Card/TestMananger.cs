using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public string Cardid,Cardid1,Cardid2,Cardid3;
    public Type CardType;
    public Element_type CardEle;
    public Rarity CardRarity;
    public string CardName;

    public string CardName1, CardName2, CardName3;

    //----------------------------------------------------
    private bool bCard, bCard1, bCard2 = false;//融合条件，false已选，true未选
    public Text text, text1, text2;//是否选择


    

    public bool BCard, BCard1, BCard2;
    //-----------------------------------------------------	
    private int b, c = 0;
    private int d;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        text.text = "未选";
        text2.text = "未选";
        text1.text = "未选";

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
        if (bCard == false)
        {
            if (bCard1 == true && bCard2 == true)
            {
                text.text = "已选够2张";
            }
            else
            {
            text.text = "已选";
            bCard = true;
            }
            
        }
        else
        {
            text.text = "未选";
            bCard = false;
        }
        ShotAA();
    }
    public void ShotB()
    {
        BCard1 = true;
        if (bCard1 == false)
        {
            if (bCard == true && bCard2 == true)
            {
                text1.text = "已选够2张";
            }
            else
            {
                text1.text = "已选";
                bCard1 = true;
            }
        }
        else
        {
            text1.text = "未选";
            bCard1 = false;
        }
        ShotAA();
    }
    public void ShotC()
    {
        BCard2 = true;
        if (bCard2 == false)
        {
            if (bCard == true && bCard1 == true)
            {
                text2.text = "已选够2张";
            }
            else
            {
                text2.text = "已选";
                bCard2 = true;
            }
        }
        else
        {
            text2.text = "未选";
            bCard2 = false;
        }
        ShotAA();
    }

    public void button3()//点击融合，显示id,      （其余内容未补完）
    {
        if (bCard == true && bCard1 == true && bCard2 == true ||       //出牌条件，不得出单张或者3张
            bCard == true && bCard1 == false && bCard2 == false ||
            bCard == false && bCard1 == true && bCard2 == false ||
            bCard == false && bCard1 == false && bCard2 == true)
        {
            Debug.Log("这样出牌系不可以滴，一次必须出2张牌");

        }else {

        if (bCard == true) {        //第一张
            Cardid1 = Library1[d - 2].GetCardid;
                CardName1 = Library1[d - 2].GetCardName;
             Debug.Log("融合了:" + Cardid1);
       } 
        if (bCard1 == true)        //第二张
        {
             Cardid2 = Library1[d - 1].GetCardid;
            CardName2 = Library1[d - 1].GetCardName;
             Debug.Log("融合了" + Cardid2);
        }
        if (bCard2 == true)         //第三张
        {
            Cardid3 = Library1[d].GetCardid;
            CardName = Library1[d].GetCardName;
                Debug.Log("融合了" + Cardid3);
        }
        }
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
            
        }
    }
}
    


