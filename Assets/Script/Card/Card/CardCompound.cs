using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    该脚本用于卡牌合成是否为BM（最佳合成）的判断
    以及是BM是所执行的操作
 */
public class CardCompound : MonoBehaviour {
    public static CardCompound _instance;
    public List<GameObject> CardLibrary;
    public List<TestCard> Library1;

    Dictionary<string, string> d1= new Dictionary<string, string>();
    private string DicReturn;

    public string Cardid;
    public Type CardType;
    public Element_type CardEle;
    public Rarity CardRarity;
    public string CardName;   

    public string Cardid1, Cardid2, Cardid3;  //获取三张卡牌的id

    private int d,b, c = 0;

    private string a1, a2;  //构成  a1&a2 

    public Text text,text1,text2;//已选或未选

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {

        d1.Add("EL01Fi&EL02Fi", "1%2");  //添加最佳卡牌
        d1.Add("EL02Fi&EL01Fi", "1%2");
    }

//ShowButton3
/*

 */
    public void ShowButton3()
    {
        //获取选择的卡牌id
        Cardid1 = TestMananger._instance.Cardid1;  
        Cardid2 = TestMananger._instance.Cardid2;
        Cardid3 = TestMananger._instance.Cardid3;
        Debug.Log("a1a1" + Cardid1);
        Debug.Log("a1a2" + Cardid2);
        Debug.Log("a1a3" + Cardid3);
    
        //if(TestMananger._instance.bCard == false&& TestMananger._instance.bCard1 == false)
        //{

        //}

        if (TestMananger._instance.bCard==false)  //第一张未被选择
        {
            a1 = Cardid2;
            a2 = Cardid3;
            // Debug.Log("第一"+a1);
            // Debug.Log("第一" + a2);  
        }
        if (TestMananger._instance.bCard1 == false)     //第二张未被选择
        {
            a1 = Cardid1;
            a2 = Cardid3;
            
            // Debug.Log("第二" + a1);
            // Debug.Log("第二" + a2);
        }
        if (TestMananger._instance.bCard2 == false)   //第三张未被选择
        {
            a1 = Cardid1;
            a2 = Cardid2;
            // Debug.Log("第三" + a1);
            // Debug.Log("第三" + a2);
            
        }
        text.text = "未选";  //融合后，已选择变为未选
        text1.text = "未选";
        text2.text = "未选";
        FindDic(a1, a2);   
        TestMananger._instance.Fix();    //TestManager里面的fix方法，使选择变为未选
    }

    public string FindDic(string a1, string a2)   
    {
        DicReturn = "";
        if (d1.ContainsKey(a1 + "&" + a2))
        {
            DicReturn = d1[a1 + "&" + a2];
        }
        else
        {
            ReadCard._instance.SetId(a1,a2);

        }
        // Debug.Log("++" + d1.ContainsKey(a1 + "&" + a2));
        // Debug.Log("Dic" + DicReturn);

        return DicReturn;
    }
}
