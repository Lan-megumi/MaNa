using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TipsTextScript : MonoBehaviour {
	private GameObject Tips;
	public static TipsTextScript _instance;
	void Awake(){
		_instance=this;
	}
	// Use this for initialization
	void Start () {
		Tips=GameObject.Find("TipsTextCanvas/Tips");
		Tips.SetActive(false);
	}
	
	// Update is called once per frame
	public void ChangeTips(string text){
		Tips.SetActive(true);
		Tips.GetComponent<Text>().text=text;
		StartCoroutine("CloseTips");
	}
	IEnumerator CloseTips(){
		yield return new WaitForSeconds(1.2f);
		Tips.SetActive(false);

	}
	public void StopTips(){
		StopCoroutine("CloseTips");
		Tips.SetActive(false);
		
	}
}


