    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmScr : MonoBehaviour
{
    public static DmScr Instance;

    public static DmScr _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(DmScr))as DmScr;
            }
            return Instance;
        }
    }
    public List<GameObject> emenyObj2;   //创列表
    public float[] Hp;

    // Use this for initialization
    void Awake()
    {

    }
    void Start()
    {
        emenyObj2 = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    //点击，全体减血 （true，100）
    public void Dm(int num)
    {
        Debug.Log("0" + emenyObj2);
        for (int g = 0; g < emenyObj2.Count; g++)
        {
            emenyObj2[g].GetComponent<EmenyScr>().CountDamaged(true, num);
            
        }
    }
/*
    溅射伤害代码
    根据点击事件所传回的 index传入方法中的 z 值中来判断溅射哪些对象
 */
    public void CountRelated(int n, int z)
    {
        // Debug.Log("n:" + n);
        // Debug.Log("z:" + z);
        if (z == 0 && DmScr._instance.emenyObj2.Count == 1)
        {
            emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
        if (z == 0)
        {
            emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
            emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
    /*
        选择中间的时候有分三个敌人和两个敌人的情况
     */
        if (z == 1)
        {
            if (emenyObj2.Count>2)
            {
                 emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
                 emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
                 emenyObj2[2].GetComponent<EmenyScr>().CountDamaged(true, n);
            }else if(emenyObj2.Count==2)
            {
                emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
                emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
            }
           
        }
        if (z == 2)
        {
            emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
            emenyObj2[2].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
    }
}
