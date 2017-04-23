using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;
    public float lifeTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Vector3.up * speed * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Worm_Head worm;
        Worm_Segment body;
        if (worm = col.gameObject.GetComponent<Worm_Head>())
        {
            worm.damage(damage);
        }
        else if (body = col.gameObject.GetComponent<Worm_Segment>())
        {
            body.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
