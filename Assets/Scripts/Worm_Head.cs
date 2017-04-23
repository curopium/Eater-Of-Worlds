using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Head : MonoBehaviour {

    public float speed;
    public float turn_rate;
    public float hunger;
    Vector3 prev_pos;
    Vector3 velocity;
    float current_speed;
    UnityEngine.UI.Slider hunger_slider;
    UnityEngine.UI.Slider speed_slider;

    // Use this for initialization
    void Start () {
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

        Vector3 current_pos = transform.position;

        velocity = (current_pos - prev_pos) / Time.deltaTime;
        current_speed = Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y);

        speed_slider.value = Mathf.Clamp(current_speed / speed, 0, 1);

        prev_pos = current_pos;

    }

    public Vector3 get_velocity()
    {
        return velocity;
    }

    public void feed(int food_value)
    {
        hunger = hunger + food_value;
    }
}
