using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Chunk : MonoBehaviour {

    public int food_value;
    public float turn_rate;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turn_rate * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Worm_Head worm;
        if (worm = col.gameObject.GetComponent<Worm_Head>())
        {
            worm.feed(food_value);
            Destroy(gameObject);
        }
    }
}
