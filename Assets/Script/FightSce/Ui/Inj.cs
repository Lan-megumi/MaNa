using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inj : MonoBehaviour {
    public Text text;
    private int i=0;
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
    public Animator Anima;
    
    // Use this for initialization
    void Start () {
        text = GameObject.Find("Text").GetComponent<Text>();
        Anima = this.GetComponent<Animator>();
	}
    public void StartRed()
    {
        i++;
        if (i >= 5) {
            text.text = "要挂了";
        }
        Anima.SetBool("istext", true);
        StartCoroutine(Injure());
    }

    IEnumerator Injure()
    {
        yield return new WaitForSeconds(0.3f);
        Anima.SetBool("istext", false);
    }
}
