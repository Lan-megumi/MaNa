using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//引入Io流以及XML序列化
using System.IO;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour {
	public int Score;//	计分

	void Start(){
		
	}
	
	public void DealCards(){
		//洗牌
		BasicCardDeck.Instance.Shuffle();

		//
	}

	
}
