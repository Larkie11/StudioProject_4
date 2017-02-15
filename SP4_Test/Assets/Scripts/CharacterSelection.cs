using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour {

    private List<GameObject> sprites;
    //Default index of the model
    private int selectionIndex = 0;
	// Use this for initialization
	void Start () {
        sprites = new List<GameObject>();
        foreach(Transform t in transform)
        {
            sprites.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        sprites[selectionIndex].SetActive(true);
	}
    public void SelectCharacter(int index)
    {
        if (index == selectionIndex)
            return;
        if (index < 0 || index >= sprites.Count)
            return;
        sprites[selectionIndex].SetActive(false);
        selectionIndex = index;
        sprites[selectionIndex].SetActive(true);
    }
	public void ChangeCharacter()
    {
        Debug.Log("AA");
        sprites[selectionIndex].SetActive(false);
        selectionIndex++;
        sprites[selectionIndex].SetActive(true);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            SelectCharacter(3);
	}
}
