using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretScript : MonoBehaviour {

    private Transform target;
    private Enemy victim;

    [Header("Attributes")]
    public float range = 2f;
    public float turnSpeed = 2f;
    public float fireRate = 0.5f;
    public float damage = 10f;


    [Header("Configured")]
    public string enemyTag = "enemy";
    private float fireCountdown = 0f;

	//Ajas meess
	//public float Starthealth = //need to referenec the health in Enemy script
	//private float health - the health thats used only for the HPbar
	//end of ajas mess

	Animator anim;


	//SOUND,  if applied to prefabs, stops you from being able to buy a bear
	AudioSource slapSound;



	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

		//Ajas help 
		anim = this.GetComponent<Animator>();
		//end of Ajas help

		//Ajas mess healthbar
		//health = Starthealth
		//end of ajas mess

		//SOUND
		slapSound = this.GetComponent<AudioSource>();

	}

	
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestDistance > distanceToEnemy)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
               
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }


    }

	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        //third try
//        Vector3 dir = target.position - transform.position; // direction from our position to the target
//        Quaternion lookRotation = Quaternion.LookRotation(dir);
//        Vector3 rotation = lookRotation.eulerAngles;
//        transform.rotation = Quaternion.Euler(0f, 0f, rotation.z);
       
        //second try
//        var targetPoint = target.transform.position;
//        var targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
//        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);    
//        transform.rotation = Quaternion.Euler(new Vector3(0f,  0f, transform.rotation.eulerAngles.z));

        //third try
        // Vector3 dir = target.position - transform.position;
        // Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // transform.rotation = Quaternion.Euler(0f, 0f , rotation.z);


        if (fireCountdown <= 0f)
        {
            BearAttack();
            fireCountdown = 1f / fireRate;


        }
        fireCountdown -= Time.deltaTime;
	}

    void BearAttack()
    {
        anim.SetTrigger ("isAttacking");


        if(target.GetComponent<Enemy>() != null)
        {
            target.GetComponent<Enemy>().getDamaged(damage);

        }
		else
        if(target.GetComponent<Enemy2>() != null)
        {
            target.GetComponent<Enemy2>().getDamaged(damage);
        }
		
        if(target.GetComponent<EnemyBoss>() != null)
        {
            target.GetComponent<EnemyBoss>().getDamaged(damage);

        }
		//SOUND
		slapSound.Play();

	
	}
		

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
