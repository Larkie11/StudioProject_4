using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Loading : MonoBehaviour {
    bool isFakeLoadingBar = false;
    float fakeIncrement = 0F;
    float fakeTiming = 0F;
    [SerializeField]
    Image loadingScreenBG;
    [SerializeField]
    Slider progBar;
    [SerializeField]
    Text loadingText;
    [SerializeField]
    List<GameObject> Buttons = new List<GameObject>();
    int width = 0;
    int height = 0;
    AsyncOperation ao;
    string fs;
    private void Awake()
    {
        width = PlayerPrefs.GetInt("Width");
        height = PlayerPrefs.GetInt("Height");
        fs = PlayerPrefs.GetString("FS");
        if (width != 0 && height != 0)
        {
            if(fs == "true")
                Screen.SetResolution(width, height, true);
            else if (fs == "false")
                Screen.SetResolution(width, height, false);

        }
    }
    // Use this for initialization
    void Start () {
        loadingScreenBG.enabled = false;
        progBar.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadingScreen(string LevelName)
    {
        for(int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].gameObject.SetActive(false);
        }
        GlobalScript.enemyCount = 0;
        GlobalScript.isDead = false;
       
        loadingScreenBG.enabled = true;
        progBar.gameObject.SetActive(true);

        loadingText.gameObject.SetActive(true);

        loadingText.text = "Loading ";
        if (!isFakeLoadingBar)
        {
            StartCoroutine(LoadLevelWithRealProgress(LevelName));
        }
        else
        {
            StartCoroutine(LoadLevelWithFakeProgress());
        }
    }
    IEnumerator LoadLevelWithRealProgress(string levelName)
    {
        yield return new WaitForSeconds(1);
        ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            progBar.value = ao.progress;
            if (ao.progress == 0.9F)
            {
                progBar.value = 1F;
                loadingText.text = "Loaded!";
                
                ao.allowSceneActivation = true;
            }
            Debug.Log(ao.progress);
            yield return null;
        }
    }

    IEnumerator LoadLevelWithFakeProgress()
    {
        yield return new WaitForSeconds(1);

        while(progBar.value != 1F)
        {
            progBar.value += fakeIncrement;
            yield return new WaitForSeconds(fakeTiming);
        }

        while (progBar.value == 1F)
        {
            loadingText.text = "Press 'F' to continue";
            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(1);
            }
            yield return null;
        }
    }
}
