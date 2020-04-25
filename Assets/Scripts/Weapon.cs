using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static int bullets = 0;
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown ("Fire1")) {
            bullets++;
            if(bullets <= 6)
            {
            Shoot ();

            }
        }
    }

    void Shoot () {
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ammo")
        {
            bullets = 0;
            //collision.gameObject.SetActive(false);
           

        }

        //Debug.Log(collision.gameObject.name);
        //Destroy(collision.gameObject);
    }

    
}