using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Planet : MonoBehaviour {

    public GameObject broken_piece;
    public int number_pieces;
    float radius;
    public float hardness;
    public GameObject mainCamera;
    public List<GameObject> turrets;

    // Use this for initialization
    void Start () {
        turrets = new List<GameObject>();
        radius = gameObject.GetComponent<CircleCollider2D>().radius;
        mainCamera = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void killTurrets()
    {
        for(int i = 0; i < turrets.Count; i++)
        {
            Destroy(turrets[i]);
        }
    }

    void Explode ()
    {
        CameraBehaviour camScript = mainCamera.GetComponent<CameraBehaviour>();
        camScript.screenShake(0.5f);
        //killTurrets();
        for (int i = 0; i < number_pieces; i++)
        {   
            Vector3 random_point = Random.insideUnitCircle * radius;
            random_point.x += transform.position.x;
            random_point.y += transform.position.y;
            random_point.z += transform.position.z;

            GameObject clone = Instantiate(broken_piece, random_point, Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180))));
            clone.SetActive(true);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Worm_Head worm;
        if (worm = col.gameObject.GetComponent<Worm_Head>())
        {
            if (worm.get_velocity().x > hardness || worm.get_velocity().y > hardness)
            {
                Explode();
            }
        }
    }
}
