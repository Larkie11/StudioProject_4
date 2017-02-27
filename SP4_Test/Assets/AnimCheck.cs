using UnityEngine;
using System.Collections;

public class AnimCheck : MonoBehaviour {

    Animator anim;
    private float move = 0f;
        SpriteRenderer Sr;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        Sr = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        move = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("State", 3);
        }
        else
        {
            anim.SetInteger("State", 0);
        }

        if (move == 0)
        {
            anim.SetInteger("State", 0);
        }

        if (move > 0)
        {
            Sr.flipX = false;
            anim.SetInteger("State", 1);
        }
        else if (move < 0)
        {
            Sr.flipX = true;
            anim.SetInteger("State", 1);
        }
	}


}
