using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineCountdown : MonoBehaviour
{
    public static CoroutineCountdown _instance;

    public Text text;//谁回合
    private int i = 1;
    private int b = 10;//玩家2初始速度
    private int a = 7;//玩家1初始速度
    public GameObject bt1;
    GameObject bt11;
    GameObject bt2;
    GameObject bt21;

    
    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        t1(); //谁先出手
    }

    void Update()
    {
        if (i == 1)
        {
            a--;
            b--;

        }
        if (a <= 0)
        {
            i = -1;
            
            Player2();
            Player1();
        }

        if (b <= 0)
        {
            i = -1;
            Player1();
            Player2();
            
        }
        Debug.Log("a=" + a);
        Debug.Log("b=" + b);
    }

    public void t1()
    {
        if (i == -1 & a <= 0)
        {
            i = 1;
            a = 7;
            
        }
        if (i == -1 & b <= 0)
        {
            i = 1;
            b = 10;
            
            
        }
    }
    public void Player1()//我方回合，禁止对面
    {
        text.text = "我方回合";
        GameObject bt1 = GameObject.Find("Canvas/Button1");
        GameObject bt11 = GameObject.Find("Canvas/Button11");
        Button Bt1 = (Button)bt1.GetComponent<Button>();
        Button Bt11 = (Button)bt11.GetComponent<Button>();
        
        Bt1.interactable = true;
        Bt11.interactable = true;
        if (b == 0)
        {
            Bt1.interactable = false;
            Bt11.interactable = false;
        }
    }
    public void Player2()//敌方回合，禁止对面
    {
        text.text = "敌方回合";
        GameObject bt2 = GameObject.Find("Canvas/Button2");
        GameObject bt21 = GameObject.Find("Canvas/Button21");
        Button Bt2 = (Button)bt2.GetComponent<Button>();
        Button Bt21 = (Button)bt21.GetComponent<Button>();
        Bt2.interactable = true;
        Bt21.interactable = true;
        
        if (a == 0)
        {
            Bt2.interactable = false;
            Bt21.interactable = false;
        }
    }
}

    
    




