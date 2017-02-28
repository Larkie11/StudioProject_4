using UnityEngine;
using System.Collections;

public class PowerupShield : MonoBehaviour {
    [SerializeField]
    AudioClip shield;
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
        if (collision.tag == "Player")
        {
            audioEff.PlayOneShot(shield);
            GlobalScript.Shield += 5;
            Destroy(gameObject);
        }
    }
}
