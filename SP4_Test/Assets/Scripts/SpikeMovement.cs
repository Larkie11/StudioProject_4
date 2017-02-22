using UnityEngine;
using System.Collections;

public class SpikeMovement : MonoBehaviour {

    Vector3 originalpos;
    float posY;
    float moveTo;
    bool moveUp = true;
	// Use this for initialization
	void Start () {
        posY = transform.position.y;
        originalpos = transform.position;
        moveTo = posY + 1.3F;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveUp)
        {
            if (posY < moveTo)
                posY += Time.deltaTime * 1.2F;
            else
                moveUp = false;
        }
        else if(!moveUp)
        {
            if (posY > originalpos.y)
                posY -= Time.deltaTime * 1.2F;
            else
                moveUp = true;
        }
        transform.position = new Vector3(transform.position.x, posY, 0);
	}
}
