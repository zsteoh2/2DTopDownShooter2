using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject impactEffect;


    public void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Wall":
                Impact();
                 break;

            case "Enemy":
                //other.GameObject.GetComponent<MyEnemyScript>().TakeDamage();
                //Handle Enemy Collision
                Impact();
                  break;
        }   
    }


    public void Impact()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
