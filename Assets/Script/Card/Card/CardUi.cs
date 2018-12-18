using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本用于实例化卡牌
	定义对应卡牌属性的各个Text控件并且绑定，然后通过修改 text 将接收过来的参数强制转换为string逐个填充
 */
public class CardUi : MonoBehaviour {
	public Text IdText;
	public GameObject BchoseUi;
	public static CardUi _instance;
	public Image CardImage;
	Sprite Img,Deatil;

	void Awake(){
		_instance=this;
	}
	void Start () {
		
	}
	public void ChangeUiDate(string Cardid){
		IdText.text=Cardid;
	}
	//控制被选中时的卡牌效果
	public void Set_BchoseUi(bool f){
		BchoseUi.SetActive(f);
	}
	public void SetCardImage(){
		string id = this.GetComponent<TestCardScr>().Re_Cardid();
		Img = Resources.Load("Card/"+id+"/Image",typeof(Sprite))as Sprite;
		Deatil = Resources.Load("Card/"+id+"/Deatil",typeof(Sprite))as Sprite;
		if(Img!=null){
			CardImage.color=Color.white;
			CardImage.sprite=Img;
		}
		// Debug.Log("Card/"+id+"/Deatil");
		// Debug.Log("来自CardUi的报告:查找到的图片为:"+Img+" ,详细为:"+Deatil);
	}
	///<summary>
	///	该方法被卡牌的EvenTrr的脚本调用，用于改变图片，放大时变为详细图片
	///</summary>
	public void EvenTrr_LargeImg(bool i){
		if(i==true){
			CardImage.sprite=Deatil;
		}else{
			CardImage.sprite=Img;
		}

	}
	

}
