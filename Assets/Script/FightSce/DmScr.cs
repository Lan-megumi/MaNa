using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmScr : MonoBehaviour
{
    public static DmScr _instance;
    public List<GameObject> emenyObj2;   //创列表
    public float[] Hp;

    // Use this for initialization
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        emenyObj2 = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    //全体减血 （传入伤害数值）
    public void Dm(int num)
    {
        Debug.Log("0" + emenyObj2);
        for (int g = 0; g < emenyObj2.Count; g++)
        {
            emenyObj2[g].GetComponent<EmenyScr>().CountDamaged(true, num);
            
        }
    }
    //群体治疗(待实装)
    public void DmCure(int num){

    }

    public void CountRelated(int n,int z) 
    {
        Debug.Log("n:" + n);
        Debug.Log("z:" + z);
        if (z == 0&& DmScr._instance.emenyObj2.Count==1)
        {
            DmScr._instance.emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
        if(z==0)
        {
            DmScr._instance.emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
        if (z == 1)
        {
            DmScr._instance.emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[2].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
        if(z==2)
        {
            DmScr._instance.emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[2].GetComponent<EmenyScr>().CountDamaged(true,n);
        }
    } 
}
