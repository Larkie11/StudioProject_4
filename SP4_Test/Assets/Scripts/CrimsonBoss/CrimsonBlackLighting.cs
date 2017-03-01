using UnityEngine;
using System.Collections;

public class CrimsonBlackLighting : MonoBehaviour {

    float speed = 3f;
    private Vector2 direction;
    GameObject player;
    float lifeTime = 3.0f;
    private int randNum;
    string toDrop;
	// Use this for initialization
	void Start () 
    {
        lifeTime = 3.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 position = transform.position;
        Vector2 playerPosition;
        playerPosition = player.transform.position;
        direction.x = (playerPosition.x - position.x);
        if (direction.x > 0)
        {
            direction.x = 1;
        }
        else
            direction.x = -1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(GlobalScript.CrimsonHealth > 200)
        {
            speed = 1;
        }
        else if (GlobalScript.CrimsonHealth > 75 && GlobalScript.CrimsonHealth < 200)
        {
            speed = 3;
        }
        else if (GlobalScript.CrimsonHealth < 75)
        {
            speed = 5;
        }


        transform.Translate(direction * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Destroy(gameObject);
            GlobalScript.CrimsonLightingEffect--;
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log(collision);
        if (GlobalScript.shieldisOn && collision.gameObject.tag == "Player")
        {
            randNum = Random.Range(0, 3);
            if (randNum == 0)
            {
                toDrop = "Powerup-Shield";
            }
            else if (randNum == 1)
            {
                toDrop = "weaponpickup";
            }
            else if (randNum == 2)
            {
                toDrop = "Powerup-Coin";
            }
            else
            {
                toDrop = "";
            }

            if (toDrop != "")
            {
                GameObject go = Instantiate(Resources.Load(toDrop), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            }
        }
    }
}
