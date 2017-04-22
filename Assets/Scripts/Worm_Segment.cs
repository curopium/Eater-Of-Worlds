using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Segment : MonoBehaviour {

    public GameObject parent; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (parent == null) return;


        
        //translation
        //http://answers.unity3d.com/questions/390009/3d-snake-classical-movement-1.html
        Vector3 vector_From_Parent = transform.position - parent.transform.position;
        vector_From_Parent = vector_From_Parent.normalized * transform.localScale.y;
        transform.position = vector_From_Parent + parent.transform.position;

        //rotation
        Vector3 dir = parent.transform.position - transform.position;
        //the -90 degrees is a lazy hack so I dont have to change placeholder sprites
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
}
