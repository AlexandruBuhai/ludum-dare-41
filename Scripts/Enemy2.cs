using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour {

    private Transform target;
    private int wavePointIndex = 0;
   
    [Header ("Attributes")]
	public float startHealth = 20f;
    public float speed = 10f;
    public int reward = 3;
    
    private Animator anim; 
    private float health = 20f;

	public Image healthBar;

 
	// Use this for initialization
	void Start () {
        target = Waypoints2.points2[0];
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
            PlayerStats.Money += reward;
            Destroy(gameObject);
           
        }

    }
    void GetNextWaypoint()
    {

        if (wavePointIndex >= Waypoints2.points2.Length - 1)
        {
			
            //TODO disable sprite renderer
            Destroy(gameObject);
            return;
				
        }
        wavePointIndex += 1;
        target = Waypoints2.points2[wavePointIndex];

    }
		

}
