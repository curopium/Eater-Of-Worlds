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
        // Player Control
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (v > 0f)
        {
            transform.Translate(v * Vector3.up * speed * Time.deltaTime);
        }
        if (h < 0f)
        {
            transform.Rotate(-h * Vector3.forward * -turn_rate * Time.deltaTime);
        }
        else if (h > 0f)
        {
            transform.Rotate(h * Vector3.forward * turn_rate * Time.deltaTime);
        }
    }
}
