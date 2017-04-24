using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {

    public int numberStars = 2000;
    public int spaceSize = 20;
    public ParticleSystem.Particle[] particles;
    public ParticleSystem particleSystem;

    // Use this for initialization
    void Start () {
        particles = new ParticleSystem.Particle[numberStars];


        for (int i = 0; i < numberStars; i++)
        {
            particles[i].position = Random.insideUnitSphere * spaceSize;
            particles[i].startSize = Random.Range(0.05f, 0.05f);
            particles[i].startColor = new Color(0, 1, 1, 1);
        }

        particleSystem = gameObject.GetComponent<ParticleSystem>();

        particleSystem.SetParticles(particles, particles.Length);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
