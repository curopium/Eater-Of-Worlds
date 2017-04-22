using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public float padding;
    private bool hit;

	// Use this for initialization
	void Start () {
        GameObject worm = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerLoc = worm.GetComponent<Transform>().position;
        playerLoc.z = this.transform.position.z;
        this.transform.position = playerLoc;
        float height = 2 * Camera.main.orthographicSize - padding;
        float width = Camera.main.aspect * height;
        this.GetComponent<BoxCollider2D>().size = new Vector2(width, height);
        hit = false;
    }
	
	// Update is called once per frame
	void Update () {
        Transform ct = this.transform;
        GameObject worm = GameObject.FindGameObjectWithTag("Player");
        Worm_Head wormHead = worm.GetComponent<Worm_Head>();
        Vector3 playerLoc = worm.GetComponent<Transform>().position;
        playerLoc.z = ct.position.z;
        if(hit)
            ct.position = Vector3.MoveTowards(ct.position, playerLoc, wormHead.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            hit = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            hit = true;
    }
}
