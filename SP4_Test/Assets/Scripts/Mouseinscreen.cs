using UnityEngine;
using System.Collections;

public class Mouseinscreen : MonoBehaviour {

    
    public float MouseSensitivity = 0.1f;

    //Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
	// Use this for initialization
	void Start () {
       
	
	}
	
 void Crosshair()
    {
    
        GameObject crosshair = GameObject.Find("crosshair");

            Vector2 temp = Input.mousePosition;
            //Cursor.visible = false;
            temp = Camera.main.ScreenToWorldPoint(temp);
            crosshair.transform.position = Vector2.Lerp(transform. position, temp, MouseSensitivity);

           
        

    }

    
	// Update is called once per frame
	void Update () {




        Crosshair();
	}
}
