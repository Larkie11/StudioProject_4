using UnityEngine;
using System.Collections;

public class AutoDestroyAnimation : MonoBehaviour {
    [SerializeField]
    AudioClip warning;
    AudioSource audioEff;
    float destroy;
	// Use this for initialization
	void Start () {
        audioEff = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        audioEff.PlayOneShot(warning);
        destroy = 2F;
	}
	
	// Update is called once per frame
	void Update () {
        destroy -= Time.deltaTime;
        Debug.Log(destroy);

        if (destroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
