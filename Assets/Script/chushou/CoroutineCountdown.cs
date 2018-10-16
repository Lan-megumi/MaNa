using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineCountdown : MonoBehaviour
{
    public static CoroutineCountdown _instance;


    public Text text;

    public Text time1;
    public Text time2;

    public int tt1 = 0;
    public int tt2 = 0;

    private int i = 1;
    private float a=7;
    private float b=10;
    private float c ;
    private float d;

    public GameObject bt1;
    GameObject bt11;
    GameObject bt2;
    GameObject bt21;

    public Text targetTextObject;
    public Slider targetSliderOject;
    public Text targetTextObject1;
    public Slider targetSliderOject1;

    private void Awake()
    {
        _instance = this;
        c = 1 / a;
        d = 1/b;
        Debug.Log("cc" + c);
        Debug.Log("dd" + d);
    }
    

    void Start()
    {
        t1(); //谁先出手
       
    }
   
    void  Update()
    {
        
        
        targetTextObject.text = "滑动值为 " + targetSliderOject.value;
        targetTextObject1.text = "滑动值为 " + targetSliderOject1.value;
        time1.text = tt1.ToString();
        time2.text = tt2.ToString();
        

        if (i == 1)
        {
            a--;
            b--;
            //
            targetSliderOject.value += c;
            if (targetSliderOject.value  ==1)
            {
                targetSliderOject.value=0;
            }
            targetSliderOject1.value += d;
            if (targetSliderOject1.value ==1)
            {
                targetSliderOject1.value = 0;
            }


        }
        if (a <= 0)
        {
            i = -1;
            time2.text = b.ToString();
            
            Player1();
            Player2();
        }

        if (b <= 0)
        {
            i = -1;
            time1.text = a.ToString();
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

    
    




