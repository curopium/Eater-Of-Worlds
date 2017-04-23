using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D col)
    {
        Worm_Head worm;
        if ( worm = col.gameObject.GetComponent<Worm_Head>())
        {
            Debug.Log("leaving!");
        }
    }
}
