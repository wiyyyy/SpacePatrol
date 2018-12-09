using UnityEngine;
using System.Collections;

public class ripOnTrigger : MonoBehaviour
{
	public float enemyHealth = 30.0f;

	public GameObject ripExplode;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "enemyBullet" && transform.tag == "Enemy")
		{
			
		} 
		if (col.tag == "enemyBullet" && transform.tag == "Player")
		{
			Debug.Log(GameManager.Instance.playerHealth);
			if (GameManager.Instance.playerHealth <= 0)
			{
				Instantiate (ripExplode, transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
			Instantiate (ripExplode, transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			GameManager.Instance.playerHealth -= 10.0f;
			GameManager.Instance.multipliers = 1.0f;


		} 
		if(col.tag == "playerBullet"&& transform.tag == "Enemy") 
		{
			if (enemyHealth <= 0)
			{
				Instantiate (ripExplode, transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
			Destroy (col.gameObject);
			enemyHealth -= Shoot.playerFirePower;
			GameManager.Instance.multipliers += 1.0f;
			GameManager.Instance.score = GameManager.Instance.score + (GameManager.Instance.multipliers * 10);
		}
		if (col.tag == "playerBullet" && transform.tag == "enemyBullet")
		{
			Instantiate (ripExplode, col.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			Instantiate (ripExplode, transform.position, Quaternion.identity);
			Destroy (transform.gameObject);
			GameManager.Instance.multipliers += 0.25f;
			GameManager.Instance.score = GameManager.Instance.score + (GameManager.Instance.multipliers * 2.5f);
		}
	}
}
