using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("wm");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadCharSelection()
    {
        SceneManager.LoadScene("Character Selection");
    }
    public void LoadWMBoss()
    {
        //SceneManager.LoadScene("wmboss");
        
    }
}
