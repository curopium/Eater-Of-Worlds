using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Head : MonoBehaviour {

    public float speed;
    public float turn_rate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * -turn_rate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * turn_rate * Time.deltaTime);
        }

    }
}
