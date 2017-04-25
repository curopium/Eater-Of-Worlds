using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

    public GameObject projectile;
    public GameObject target;
    public GameObject bulletSpawn;
    public int health;
    public float speed;
    public float rotation_speed;
    public float fireRate;
    public float fireRange;
    public float minFavouredDistance;
    public float maxFavouredDistance;
    public float outOfRange;
    public float foodValue;
    private float nextFire;
    private float distance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(target.transform.position, transform.position);
        maintainDistance();
        aim();
        if (Time.time > nextFire && distance < fireRange)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    void aim ()
    {
        Vector3 aim_vector = target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(aim_vector.y, aim_vector.x) * Mathf.Rad2Deg;
        //anohter -90 degree hack
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
    }

    void maintainDistance()
    {
        if (distance < outOfRange)
        {
            if (distance < minFavouredDistance)
            {
                transform.Translate(speed * Vector3.up * -speed * Time.deltaTime);
            }
            else if (distance > maxFavouredDistance)
            {
                transform.Translate(speed * Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    void fire ()
    {
        GameObject clone = Instantiate(projectile, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        clone.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Worm_Head worm;
        if (worm = col.gameObject.GetComponent<Worm_Head>())
        {
            worm.heal(foodValue);
            Destroy(gameObject);
        }

        
    }
}
