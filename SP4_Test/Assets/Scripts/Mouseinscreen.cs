using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mouseinscreen : MonoBehaviour
{

    bool onjoystick = false;
    bool touch1onjoy = false;
    [SerializeField]
    float MouseSensitivity = 0.1f;

    GameObject joybutton;


    void Start()
    {
        joybutton = GameObject.Find("MobileJoystick");





    }



    void Crosshair()
    {






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
                GameObject crosshair = GameObject.Find("crosshair");

                Vector2 temp = Input.GetTouch(i).position;
                //Cursor.visible = false;
                temp = Camera.main.ScreenToWorldPoint(temp);
                crosshair.transform.position = Vector2.Lerp(transform.position, temp, MouseSensitivity);
            }
        }





#endif





#if UNITY_STANDALONE

          GameObject crosshair = GameObject.Find("crosshair");

                Vector2 temp = Input.mousePosition;
                //Cursor.visible = false;
                temp = Camera.main.ScreenToWorldPoint(temp);
                crosshair.transform.position = Vector2.Lerp(transform.position, temp, MouseSensitivity);
#endif
    }


    void Update()
    {


        Crosshair();
    }
}
