using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class linshiScr : MonoBehaviour {
	void Awake(){
		StartCoroutine("Time");
	}
	
	IEnumerator Time(){
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(4);
	}
}
