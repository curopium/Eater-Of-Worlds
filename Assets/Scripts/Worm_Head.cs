using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Head : MonoBehaviour {

    public float acceleration;
    public float turn_rate;
    public float maxSpeed;
    public float currentSpeed;

	// Use this for initialization
	void Start () {
        currentSpeed = 0f;
	}
    
    // Update is called once per frame
    void Update () {
        // Player Control
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        // Forwards
        if (v > 0f)
        {
            currentSpeed = Mathf.Min(maxSpeed, currentSpeed + v * acceleration);
        }
        else
        {
            currentSpeed = Mathf.Max(0f, currentSpeed - acceleration);
        }
        // Slide around in space? Space is ice? Ice Space!
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);

        // Turning
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
