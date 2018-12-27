using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inj : MonoBehaviour {
    public static Inj Instance;
    public static Inj _instance
    {
        get
        {
            if (null == Instance)
            {
                Instance = FindObjectOfType(typeof(Inj)) as Inj;
            }
            return Instance;
        }
    }
    public GameObject text;
    public Animator Anima;
    
    // Use this for initialization
    void Start () {
        text = GameObject.Find("text");
        Anima = this.GetComponent<Animator>();
	}
	public void StartRed()
    {
        Debug.Log("istext");
        Anima.SetBool("istext", true);
        
    }
    //public void AnimationInit()
    //{
    //    Anima.SetBool("istext", false);
    //}
    
}
