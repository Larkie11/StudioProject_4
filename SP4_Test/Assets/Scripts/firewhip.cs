using UnityEngine;
using System.Collections;

public class firewhip : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    int whiptype;
    [SerializeField]
    int firewhipcount = 3;
    Vector2 aroundposition;


    private Vector3 zAxis = new Vector3(0, 0, 1);
    GameObject firechainhandler;
	void Start () {
        if(whiptype==1)
        {
            for (int i = 0; i < firewhipcount; i++)
            {
                Instantiate(Resources.Load("spike"), new Vector2(transform.position.x, transform.position.y + 2f + i * 7f), Quaternion.identity);
                Instantiate(Resources.Load("spike"), new Vector2(transform.position.x, transform.position.y - 2f + i * -7f), Quaternion.identity);
            }
        }
        if(whiptype==2)
        {
            for (int i = 0; i < firewhipcount; i++)
            {
          
            //   firechainhandler= (GameObject)Instantiate(Resources.Load("fire"), new Vector2(transform.position.x, transform.position.y + 2f + i * 2f), Quaternion.identity);
               Instantiate(Resources.Load("fire"), new Vector2(transform.position.x, transform.position.y + 2f + i * 2f), Quaternion.identity);
            }
        }
     
           
	
	}
	
	// Update is called once per frame
	void Update () {
       // firechainhandler.transform.RotateAround(aroundposition, zAxis, 100f * Time.deltaTime);
   //           transform.RotateAround(aroundposition, zAxis, 100f * Time.deltaTime);
        //spin
       
	}
}
