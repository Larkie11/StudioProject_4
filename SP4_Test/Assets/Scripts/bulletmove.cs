using UnityEngine;
using System.Collections;

public class bulletmove : MonoBehaviour
{

    public float tempspeed = 15.0f;
    Vector2 mouseinput;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
   
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, tempspeed * Time.deltaTime);
         rb.velocity = direction*tempspeed;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    






    }
}
