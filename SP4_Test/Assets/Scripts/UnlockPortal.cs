using UnityEngine;
using System.Collections;

public class UnlockPortal : MonoBehaviour {
    public Animator ar;
    [SerializeField]
    Canvas canvas;
	// Use this for initialization
	void Start () {
        ar = GetComponent<Animator>();
        ar.speed = 0;
        canvas.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.enabled = true;
    }
    public void DisableCanvas()
    {
        canvas.enabled = false;
    }
    // Update is called once per frame
    void Update () {
        if (GlobalScript.howmanytokill < 5)
        {
        }
        else
        {
            ar.speed = 1;
        }

    }
}
