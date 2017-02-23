using UnityEngine;
using System.Collections;

public class UnlockPortal : MonoBehaviour {
    public Animator ar;
    [SerializeField]
    Canvas canvas;
    GameObject player;
	// Use this for initialization
	void Start () {
        ar = GetComponent<Animator>();
        ar.speed = 0;
        canvas.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void DisableCanvas()
    {
        canvas.enabled = false;
    }
    // Update is called once per frame
    void Update () {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (GlobalScript.howmanytokill < 5)
        {
        }
        else
        {
            ar.speed = 1;
        }
        if (GlobalScript.howmanytokill >= 5 && transform.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position))
            canvas.enabled = true;
    }
}
