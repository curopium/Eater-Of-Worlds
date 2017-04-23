using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Planet : MonoBehaviour {

    public GameObject broken_piece;
    public int number_pieces;
    public float radius;

	// Use this for initialization
	void Start () {
        radius = gameObject.GetComponent<CircleCollider2D>().radius;
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy ()
    {
        for(int i = 0; i < number_pieces; i++)
        {   
            Vector3 random_point = Random.insideUnitCircle * radius;
            random_point.x += transform.position.x;
            random_point.y += transform.position.y;
            random_point.z += transform.position.z;

   

            GameObject clone = Instantiate(broken_piece, random_point, Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180))));
            clone.SetActive(true);
        }
    }
}
