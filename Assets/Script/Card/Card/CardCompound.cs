using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCompound : MonoBehaviour {
    public static CardCompound _instance;
    public List<GameObject> CardLibrary;
    public List<TestCard> Library1;

    public string Cardid;
    public Type CardType;
    public Element_type CardEle;
    public Rarity CardRarity;
    public string CardName;
    public string Cardid1, Cardid2, Cardid3;

    private int d,b, c = 0;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        
    }

    public void ShowC()
    {
        Cardid1 = TestMananger._instance.Cardid1;
        Cardid2 = TestMananger._instance.Cardid2;
        Cardid3 = TestMananger._instance.Cardid3;

        if(Cardid1 == "EL01Wa" && Cardid2 == "EL03Fi"||
            Cardid2 == "EL01Wa" && Cardid1 == "EL03Fi"||
                Cardid1 == "EL01Wa" && Cardid3 == "EL03Fi"||
                Cardid3 == "EL01Wa" && Cardid1 == "EL03Fi"
            )
        {
            Debug.Log("最佳组合:蒸汽爆炸");
        }

    }

    
    public void Compound()
    {

    }
   
}
