using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour
{
	public float speed = 1.0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Renderer>().material.mainTextureOffset += new Vector2(speed*Time.deltaTime,0);
	}
}
