using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public string Cardid1, Cardid2, Cardid3;

    private int d,b, c = 0;
    private string a1, a2;

    public Text text,text1,text2;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {

        d1.Add("EL01Fi&EL02Fi", "1%2");
        d1.Add("EL02Fi&EL01Fi", "1%2");
    }

    public void ShowButton3()
    {
        Cardid1 = TestMananger._instance.Cardid1;
        Cardid2 = TestMananger._instance.Cardid2;
        Cardid3 = TestMananger._instance.Cardid3;
        Debug.Log("a1a1" + Cardid1);
        Debug.Log("a1a2" + Cardid2);
        Debug.Log("a1a3" + Cardid3);
    

        if (TestMananger._instance.bCard==false)
        {
            a1 = Cardid2;
            a2 = Cardid3;
            Debug.Log("1a1"+a1);
            Debug.Log("1a2"+a2);  
        }
        if (TestMananger._instance.bCard1 == false)
        {
            a1 = Cardid1;
            a2 = Cardid3;
            
            Debug.Log("2a1" + a1);
            Debug.Log("2a2" + a2);
        }
        if (TestMananger._instance.bCard2 == false)
        {
            a1 = Cardid1;
            a2 = Cardid2;
            Debug.Log("3a1" + a1);
            Debug.Log("3a2" + a2);
            
        }
        text.text = "未选";
        text1.text = "未选";
        text2.text = "未选";
        FindDic(a1, a2);
    }

    public string FindDic(string a1, string a2)
    {
        DicReturn = "";
        if (d1.ContainsKey(a1 + "&" + a2))
        {
            DicReturn = d1[a1 + "&" + a2];
        }
        Debug.Log("++" + d1.ContainsKey(a1 + "&" + a2));
        Debug.Log("Dic" + DicReturn);

        return DicReturn;
    }
}
