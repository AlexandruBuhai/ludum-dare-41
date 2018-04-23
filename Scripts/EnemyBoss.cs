using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour {

	private Transform target;
	private int wavePointIndex = 0;

	[Header ("Attributes")]
	public float startHealth = 200f;
	public float speed = 10f;

	private Animator anim; 
	private float health = 200f;

	public Image healthBar;

	public GameObject gameOverObj;
	public Text gameOverText;

	// Use this for initialization
	void Start () {
		target = Waypoints.points[0];
		anim = GetComponent<Animator>();
		health = startHealth; 
	}

	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - this.transform.position;
		if(dir.y < -1f && dir.x < 1f)
		{
			anim.SetBool("goingDown", true);
		}
		else if(dir.y > -1f && dir.x > 1f)
		{
			anim.SetBool("goingDown", false);
		}
		else if(dir.y > 1f && dir.x < 1f)
		{
			anim.SetBool("goingUp", true);
		}
		else if(dir.y > 0f && dir.y < 1f && dir.x < 1f)
		{
			anim.SetBool("goingUp", false);
		}
		transform.Translate(dir.normalized * speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWaypoint();
		}

	}

	public void getDamaged(float damage)
	{
		health -= damage;
		healthBar.fillAmount = health / startHealth;

		if(health <= 0f)
		{	
			// if (!gameOverObj.activeInHierarchy) 
			// {
			// 	gameOverObj.SetActive (true);
			// 	gameOverText.text = "YOU WIN";
			// 	gameOverObj.GetComponent<AudioSource> ().enabled = false;
			// }
			UnityEngine.SceneManagement.SceneManager.LoadScene("Fishing");

			PlayerStats.Money += 1;
			Destroy(gameObject);
		}

	}
	void GetNextWaypoint()
	{

		if (wavePointIndex >= Waypoints.points.Length - 1)
		{

			//TODO disable sprite renderer
			Destroy(gameObject);
			return;

		}
		wavePointIndex += 1;
		target = Waypoints.points[wavePointIndex];

	}


}

