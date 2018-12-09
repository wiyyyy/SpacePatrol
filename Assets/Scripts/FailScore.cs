using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FailScore : MonoBehaviour {

	public Text label;
	// Use this for initialization
	void Start()
	{
		Text canvas = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		label.text = canvas.text;
		canvas.text = label.text + PlayerPrefs.GetInt ("LastScore").ToString();
	}

}
