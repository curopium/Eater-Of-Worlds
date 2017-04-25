using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Head : MonoBehaviour, Damagable {

    public GameObject child;
    public float acceleration;
    bool IAmDeceased;
    public float turn_rate;
    public float maxSpeed;
    public float currentSpeed;
    public float hunger;
    public int eaten_objects;
    Vector3 prev_pos;
    Vector3 velocity;
    float current_turning_speed;
    

    // Use this for initialization
    void Start () {
        IAmDeceased = false;
        currentSpeed = 0f;
        prev_pos = transform.position;
    }

    public void detach()
    {
        child.GetComponent<Worm_Segment>().detach();
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if (IAmDeceased) return;
        Vector3 pos = this.GetComponent<Transform>().position;
        if (transform.position.x > 41) {
            this.GetComponent<Transform>().position = new Vector3(-40, pos.y, pos.z);
            Camera.main.transform.position = new Vector3(-40, pos.y, -10);
        }
        if (transform.position.x < -41) {
            this.GetComponent<Transform>().position = new Vector3(40, pos.y, pos.z);
            Camera.main.transform.position = new Vector3(40, pos.y, -10);
        }
        if (transform.position.y > 31) {
            this.GetComponent<Transform>().position = new Vector3(pos.x, -30, pos.z);
            Camera.main.transform.position = new Vector3(pos.x, -30, -10);
        }
        if (transform.position.y < -31) {
            this.GetComponent<Transform>().position = new Vector3(pos.x, 30, pos.z);
            Camera.main.transform.position = new Vector3(pos.x, 30, -10);
        }

        hunger -= Time.deltaTime;

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
        //Debug.Log(velocity);
        current_turning_speed = Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y);

        prev_pos = current_pos;

    }

    public Vector3 get_velocity()
    {
        return velocity;
    }

    public void heal(float food_value)
    {
        eaten_objects = +1;
        GameObject.Find("GameMaster").GetComponent<GameController>().increaseScore(25);
        hunger = hunger + food_value;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void damage(float dmg)
    {
        hunger -= dmg;
    }

    public bool isDead()
    {
        return hunger <= 0f;
    }
    public void die()
    {
        IAmDeceased = true;
    }

}
