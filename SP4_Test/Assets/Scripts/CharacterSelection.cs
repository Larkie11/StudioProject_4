using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    [SerializeField]
    Text description;
    [SerializeField]
    Text charName;

    private List<GameObject> sprites = new List<GameObject>();
    //Default index of the model
    private int selectionIndex = 0;
	// Use this for initialization
	void Start () {
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
	public void NextCharacter()
    {
        if (selectionIndex < sprites.Count-1)
        {
            sprites[selectionIndex].SetActive(false);
            selectionIndex++;
            sprites[selectionIndex].SetActive(true);
        }
    }
    public void PreviousCharacter()
    {
        if (selectionIndex > 0)
        {
            sprites[selectionIndex].SetActive(false);
            selectionIndex--;
            sprites[selectionIndex].SetActive(true);
        }
    }
    public void Selected()
    {
        GlobalScript.CharacterType = selectionIndex;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        description.text = GlobalScript.myCharacters[selectionIndex].description 
            + '\n' + "Speed: " + GlobalScript.myCharacters[selectionIndex].speed + '\n'
            + "Jump Power: " + GlobalScript.myCharacters[selectionIndex].jumpPower +
            '\n' + "Shield Duration: " + GlobalScript.myCharacters[selectionIndex].maxShield + 
            '\n' ;
        charName.text = GlobalScript.myCharacters[selectionIndex].name;
    }
}
