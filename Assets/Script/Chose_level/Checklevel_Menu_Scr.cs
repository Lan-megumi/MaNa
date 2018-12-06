using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Checklevel_Menu_Scr : MonoBehaviour {
	public Image Name1Ui,Name2Ui,MenuUi;
	public bool Name1Bool,Name2Bool,MenuBool;
	public float alpha=0.0f;
	public int MenuNum=1;
	private Color c = Color.white;
	// Use this for initialization
	void Awake()
	{
		Name1UiOut();
		MenuUiOut();
		Inite();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount%10==0){
			//------------------------			
			if(Name1Bool==true&&alpha<=1.0f){
				alpha=alpha+0.4f;
				c.a=alpha;
				Name1Ui.color=c;
			}
			//------------------------
			if(Name2Bool==true){

			}
			//------------------------
			if(MenuBool==true&&alpha<=1.0f){
				alpha=alpha+0.4f;
				c.a=alpha;
				if(Checklevel_Scr.Instance.Re_i()>=0&&MenuNum==1){
					string name =Checklevel_Scr.Instance.Re_LevelName().Replace(" ","");
					Sprite pic = Resources.Load(name+"_detail",typeof(Sprite))as Sprite;
					MenuUi.sprite=pic;
					MenuNum++;
				}
				MenuUi.color=c;
			}
		}
	}
//------------------------------

	public void Name1UiEnter(){
		Name1Bool=true;
	}
	public void Name1UiOut(){
		// Name1Ui.enabled=false;
		Name1Bool=false;
		Inite();
		Name1Ui.color=c;
	}
	public void MenuUiEnter(){
		MenuBool=true;
	}
	public void MenuUiOut(){
		// Name1Ui.enabled=false;
		MenuBool=false;
		Inite();
		MenuUi.color=c;
	}
//------------------------------

	public void Inite(){
		alpha=0;
		c.a=0.0f;
		MenuNum=1;
	}
}
