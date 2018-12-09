using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
	public GameObject enemyBullet;
	public static float firePower = 1.0f;

	Transform playerPosition;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("enemyShoot",1.5f,Random.Range(1.0f,1.8f));
	}

	void Awake()
	{
		if(!playerPosition)
		{
			playerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}
	// Update is called once per frame
	void Update ()
	{

	}
	void enemyShoot()
	{
		Instantiate (enemyBullet, transform.position + (playerPosition.position - transform.position).normalized, Quaternion.identity);
	}
}
