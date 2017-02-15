using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }


    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

  

}
