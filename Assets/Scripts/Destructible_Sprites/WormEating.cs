using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEating : MonoBehaviour {

    public int Eating_Radius = 15; // unity units * 100
    public void Eat()
    {

        Vector2 eat_pos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, (float)Eating_Radius / 100);

        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("nom" + colliders[i].gameObject.name);
            //Debug.Log("eat_pos" + eat_pos);
            //Debug.Log("eat_rad" + Eating_Radius);
            if (colliders[i].GetComponent<DestructibleSprite>())
            {
                Debug.Log("ahh");
                colliders[i].GetComponent<DestructibleSprite>().ApplyDamage(eat_pos, Eating_Radius);
            }
         }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        if (go != null && go.layer == LayerMask.NameToLayer("Level"))
        {

            //Eat();
            //Debug.Log(go.name);
            if (go.GetComponent<DestructibleSprite>())
            {
                Vector2 eat_pos = new Vector2(transform.position.x, transform.position.y);
                Debug.Log("ahh");
                go.GetComponent<DestructibleSprite>().ApplyDamage(eat_pos, Eating_Radius);
            }
        }
    }
}
