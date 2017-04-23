using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject target;
    public GameObject projectile;
    public float fireRate;
    public float fireRange;
    private float nextFire;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        aim();
        if (Time.time > nextFire && distance < fireRange)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    void aim()
    {
        Vector3 aim_vector = target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(aim_vector.y, aim_vector.x) * Mathf.Rad2Deg;
        //anohter -90 degree hack
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
    }

    void fire()
    {
        GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.SetActive(true);
    }
}
