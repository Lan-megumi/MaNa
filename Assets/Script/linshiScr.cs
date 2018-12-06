using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class linshiScr : MonoBehaviour {
	public Text Anim_Text;
	public Image Back_Image;
	public RawImage Cover;
	public int Text_num=1;
	public float Cover_alpha=1.0f;
	public Color color = Color.black;
	
	public string note="";
	void Awake(){
		StartCoroutine("Time0");
        UpdateImg();
	}
	 /// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(Time.frameCount%5==0){
			if(Cover_alpha<=0){

			}else{
				Cover_alpha=Cover_alpha-0.1f;
				// Debug.Log("alhpa="+Cover_alpha);
				color.a=Cover_alpha;
				Cover.color=color;
			}
			
		}
		//每间隔二十帧执行一次
		if(Time.frameCount%20==0){
			Text_num++;
			if(Text_num>4){
				Text_num=0;
			}
			for (int i = 0; i <= Text_num; i++)
			{
				note=note+".";	
			}
			Anim_Text.text=note;
			note="";
		}
		
	}
    public void UpdateImg()
    {
        //SanFran_Outtrainingground
        GameObject SceDate = GameObject.Find("SceneDate");
        string d= SceDate.GetComponent<SceStar>().Re_LevelName().Replace(" ","");
        Sprite pic = Resources.Load(d, typeof(Sprite)) as Sprite;
        // Debug.Log(pic + " d");
        Back_Image.sprite = pic;
    }
	
	IEnumerator Time0(){
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(4);
	}
}
