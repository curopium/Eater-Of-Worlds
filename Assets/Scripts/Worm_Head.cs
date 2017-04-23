using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Head : MonoBehaviour, Damagable {

    public float acceleration;
    public float turn_rate;
    public float maxSpeed;
    public float currentSpeed;
    public float hunger;
    Vector3 prev_pos;
    Vector3 velocity;
    float current_turning_speed;
    UnityEngine.UI.Slider hunger_slider;
    UnityEngine.UI.Slider speed_slider;

    // Use this for initialization
    void Start () {
		currentSpeed = 0f;
        prev_pos = transform.position;

        GameObject slider = GameObject.Find("HungerSlider");
        hunger_slider = slider.GetComponent<UnityEngine.UI.Slider>();

        slider = GameObject.Find("SpeedSlider");
        speed_slider = slider.GetComponent<UnityEngine.UI.Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        

        hunger -= Time.deltaTime;
        hunger_slider.value = Mathf.Clamp(hunger / 100, 0, 1);

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

        Vector3 current_pos = transform.position;

        velocity = (current_pos - prev_pos) / Time.deltaTime;
        current_turning_speed = Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y);

        speed_slider.value = Mathf.Clamp(current_turning_speed / maxSpeed, 0, 1);

        prev_pos = current_pos;

    }

    public Vector3 get_velocity()
    {
        return velocity;
    }

    public void heal(float food_value)
    {
        hunger = hunger + food_value;
    }

    public void damage(float dmg)
    {
        hunger -= dmg;
    }

    public bool isDead()
    {
        return hunger <= 0;
    }

}
