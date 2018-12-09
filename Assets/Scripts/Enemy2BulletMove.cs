using UnityEngine;
using System.Collections;

public class Enemy2BulletMove : MonoBehaviour {

	public Vector3 direction = Vector3.left;
	public float speed = 1.0f;

	Transform player;

	// Use this for initialization
	void Start ()
	{
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		player = go.transform;
	}


	// Update is called once per frame
	void Update ()
	{
		if(player)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		}
	}
}
