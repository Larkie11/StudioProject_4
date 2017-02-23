using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    Button button;
    [SerializeField]
    Button button2;
    AsyncOperation ao;
    // Use this for initialization
    void Start () {
        loadingScreenBG.enabled = false;
        progBar.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadingScreen(string LevelName)
    {
        if(button!=null)
        button.gameObject.SetActive(false);
        if (button2 != null)
            button2.gameObject.SetActive(false);
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
        loadingText.text = loadingText.text + (int)(ao.progress * 100) + " % ";
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
