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
    //点击，全体减血 （true，100）
    public void Dm()
    {
        Debug.Log("0" + emenyObj2);
        for (int g = 0; g < emenyObj2.Count; g++)
        {
            emenyObj2[g].GetComponent<EmenyScr>().CountDamaged(true, 100);
            
        }
    }  
}
