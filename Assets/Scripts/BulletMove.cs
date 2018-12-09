using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour
{
	public Vector3 direction = Vector3.left;
	public float speed = 0.5f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += direction.normalized * speed * Time.deltaTime;
	}
}
