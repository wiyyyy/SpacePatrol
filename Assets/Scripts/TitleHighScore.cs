using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleHighScore : MonoBehaviour {

	public Text label;
	// Use this for initialization
	void Start()
	{
		Text canvas = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
		label.text = canvas.text;
		canvas.text = label.text + PlayerPrefs.GetInt ("HighScore").ToString();
	}
	

}
