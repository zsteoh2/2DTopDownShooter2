using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        Weapon weapon = other.gameObject.GetComponentInChildren<Weapon>();
        if(weapon)
        {
            weapon.AddAmmo(30);
            Destroy(gameObject);
        }

    }
}
