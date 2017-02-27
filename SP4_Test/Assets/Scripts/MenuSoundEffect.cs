using UnityEngine;
using System.Collections;

public class MenuSoundEffect : MonoBehaviour {
    [SerializeField]
    AudioClip selection;
    AudioSource currAudio;
    // Use this for initialization
    void Start () {
        currAudio = GetComponent<AudioSource>();
        Debug.Log(selection.name);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySelected()
    {
        currAudio.PlayOneShot(selection);
    }
}
