using UnityEngine;
using System.Collections;

public class CrimsonBlackLighting : MonoBehaviour {

    public float speed = 3f;
    private Vector2 direction;
    public GameObject player;
    public float lifeTime = 3.0f;

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
}
