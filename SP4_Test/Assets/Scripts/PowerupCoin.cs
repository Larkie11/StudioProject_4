using UnityEngine;
using System.Collections;

public class PowerupCoin : MonoBehaviour {
    [SerializeField]
    AudioClip coin;
    AudioSource audioEff;
	// Use this for initialization
	void Start () {
        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GlobalScript.Score += 10;
            audioEff.PlayOneShot(coin);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
