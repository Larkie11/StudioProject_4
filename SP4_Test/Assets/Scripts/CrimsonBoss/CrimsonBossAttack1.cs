using UnityEngine;
using System.Collections;

public class CrimsonBossAttack1 : MonoBehaviour {

    public float speed = 20.0f;
    private Vector2 direction;
    public GameObject player;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector2 position = transform.position;
        Vector2 playerPosition;
        playerPosition = player.transform.position;
        rb.velocity = (playerPosition - position).normalized;
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(rb.velocity * speed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
