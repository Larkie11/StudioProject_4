using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    
    void Update()
    {


  
#if UNITY_STANDALONE
                    
          if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Fire();
        }
#endif

#if UNITY_ANDROID
                     // Debug.Log("Android");
                     if(Input.touchCount>0)
                     {
                         if (Input.GetTouch(0).phase == TouchPhase.Ended)
                         {
                             Fire();
                         }
                     }
        
            
#endif
        
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
