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

    public string Cardid1, Cardid2, Cardid3,Cardid4;  //获取三张卡牌的id

    private int d,b, c = 0;

   

    public Text text,text1,text2,text3;//已选或未选

    private bool[] bCardbool1;//获取TestMananger的bCardbool
    private string[] CardidStr;
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
         string a1=null, a2=null;  //构成  a1&a2 

        //获取选择的卡牌id

        string [] Linshiid=TestMananger._instance.Re_ids(); 

        for (int i = 0; i < Linshiid.Length; i++)
        {

            if (Linshiid[i]!=""&&a1==null)
            {
                Debug.Log("++00++");
                a1=Linshiid[i];
            } 
            if(Linshiid[i]!=""&&a1!=null){
               a2= Linshiid[i];
            }
        }
        // Debug.Log("a1 :"+a1+ " a2 :"+a2);
        FindDic(a1, a2);   
        
       
        TestMananger._instance.Fix();    //TestManager里面的fix方法，使选择变为未选
    }

    public string FindDic(string a1, string a2)   
    {
        DicReturn = "";
        if (d1.ContainsKey(a1 + "&" + a2))
        {
            
            DicReturn = d1[a1 + "&" + a2];
            Debug.Log("Bm合成卡牌");
        }
        else
        {
            Debug.Log("非Bm合成卡牌");
             ReadCard._instance.SetId(a1, a2);
        }
        // Debug.Log("++" + d1.ContainsKey(a1 + "&" + a2));
        // Debug.Log("Dic" + DicReturn);
        return DicReturn;
    }
}
