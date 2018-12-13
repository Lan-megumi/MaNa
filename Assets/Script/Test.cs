using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	public GameObject dd;
	public void dddd(){
		dd.GetComponent<RectTransform>().anchoredPosition+=new Vector2(100,0);
	}
}
