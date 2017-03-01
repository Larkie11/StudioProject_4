using UnityEngine;
using System.Collections;

public class BoxHolder : MonoBehaviour {

    [SerializeField]
    AudioClip BoxSound;

    AudioSource audioEff;

	// Use this for initialization
	void Start () {
        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioEff.PlayOneShot(BoxSound);
        collision.transform.position = transform.position;
        collision.GetComponent<BoxCollider2D>().enabled = false;
        collision.GetComponent<Rigidbody2D>().isKinematic = true;
        GlobalScript.BoxCounter++;
        Destroy(gameObject);
    }
}
