using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    private float oldTime;

    // Use this for initialization
    void Start () {
        GameObject worm = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerLoc = worm.GetComponent<Transform>().position;
        playerLoc.z = this.transform.position.z;
        this.transform.position = playerLoc;
        oldTime = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        Transform ct = this.transform;
        GameObject worm = GameObject.FindGameObjectWithTag("Player");
        Worm_Head wormHead = worm.GetComponent<Worm_Head>();
        Vector3 playerLoc = worm.GetComponent<Transform>().position;
        playerLoc.z = ct.position.z;
        ct.position = Vector3.Lerp(ct.position, playerLoc, wormHead.currentSpeed);
        // TO TEST ScreenShake
        if (Input.GetKeyDown(KeyCode.Q))
            screenShake(1.5f);
        actualShake();
    }

    public void screenShake(float duration)
    {
        // in seconds
        oldTime = Time.time + duration;
    }
    private void actualShake()
    {
        // 0.2f is quite strong
        if (oldTime >= Time.time)
        {
            float str = 0.1f;
            float x = Random.Range(-str, str);
            float y = Random.Range(-str, str);
            this.transform.position += new Vector3(x, y, 0);
        }
    }

}
