using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    GameObject player;
    bool left;
    bool right;
    Vector3 playerPos;
    Vector3 direction;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x < transform.position.x)
        {
            left = true;
        }
        else
            right = true;
        playerPos = player.transform.position;
        direction = (playerPos - transform.position).normalized;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
    }
    // Update is called once per frame
    void Update () {
        if (GlobalScript.isDead)
            Destroy(gameObject);
        // distance moved since last frame:
        float amtToMove = 5 * Time.deltaTime;
        // translate projectile in its forward direction:
       
            transform.position += direction * amtToMove;
        
    }
}
