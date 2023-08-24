using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Camera sceneCamera;

    private void Awake()
    {
        sceneCamera = Camera.main;
    }

    private void Update()
    {
        destroyWhenOffScreen();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case TagManager.Wall_Tag:
                Impact();                
                break;

            case TagManager.Enemy_Tag:
                other.gameObject.GetComponent<Enemy>().TakeDamage(1);

                //if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
                //{
                //    enemyComponent.TakeDamage(1);
                //}
                //Handle Enemy Collision

                Impact();
                  break;
        }   
    }

    private void destroyWhenOffScreen()
    {
        Vector2 screenPosition = sceneCamera.WorldToScreenPoint(transform.position);
        
        if(screenPosition.x < 0 || screenPosition.x > sceneCamera.pixelWidth || screenPosition.y < 0 || screenPosition.y > sceneCamera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }


    public void Impact()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
