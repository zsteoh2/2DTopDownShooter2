using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;

    public Transform firePoint;

    public float fireForce;

    public int currentClip = 30, maxClipSize = 30, currentAmmo, maxAmmoSize = 100;


    public void Fire()
    {
        if(currentClip > 0)
        {
            GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);

            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

            currentClip--;
        }
       
    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip; // how many bullet to refill clip
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo; // if currentAmmo - reloadAmount >= 0 , return reloadAmmount, means 如果弹药充足，才进行reload,否则不进行
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;

    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }
    
    
}
