using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Card_EvenTrr_Scr : MonoBehaviour {
	RectTransform rect,new_rect;
	// Use this for initialization
	void Start () {
		rect = this.GetComponent<RectTransform>();
		


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void testFun(){
		// Debug.Log("rect.rect:"+rect.rect);
		// Debug.Log("rect.pivot:"+rect.pivot);
		rect.sizeDelta=rect.sizeDelta*1.2f;
		// Debug.Log("rect.sizeDelta:"+rect.sizeDelta);
		
	}
	public void testFun2(){
		// Debug.Log("rect.rect:"+rect.rect);
		// Debug.Log("rect.pivot:"+rect.pivot);
		rect.sizeDelta=rect.sizeDelta/1.2f;
		// Debug.Log("rect.sizeDelta:"+rect.sizeDelta);
		
	}
}
