using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject unit;
    public GameObject target;
    public float spawnTime;
    public float agroRange;
    private float nextFire;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (Time.time > nextFire && distance < agroRange)
        {
            nextFire = Time.time + spawnTime;
            spawn();
        }
    }

    void spawn ()
    {
        GameObject clone = Instantiate(unit, spawnPoint.transform.position, spawnPoint.transform.rotation);
        clone.SetActive(true);
    }
}
