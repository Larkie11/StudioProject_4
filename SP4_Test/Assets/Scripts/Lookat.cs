using UnityEngine;
using System.Collections;

public class Lookat : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;
    GameObject joybutton;
    // Use this for initialization
    void Start()
    {
        joybutton = GameObject.Find("MobileJoystick");
    }

    // Update is called once per frame
    void Update()
    {

        // Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        //RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, Targethitting);
        //.DrawLine(firePointPosition, mousePosition, Color.white);
        // Vector2 directiontomouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // Physics2D.Raycast(start, directiontomouse,100);

#if UNITY_STANDALONE
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

#endif


#if UNITY_ANDROID




    
        for (var i = 0; i < Input.touchCount; i++)
        {
            if ((joybutton.GetComponent<Collider2D>().bounds.Contains(Input.GetTouch(i).position)))
            {
                //touching joystick
                var touch1 = Input.GetTouch(i);


                // means touch 1 = on joystick 
                //do nothing 
            }
            else if (!(joybutton.GetComponent<Collider2D>().bounds.Contains(Input.GetTouch(i).position)))
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position) - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            }
        }








#endif

    }


}
