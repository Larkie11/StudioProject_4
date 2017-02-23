using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetScreen : MonoBehaviour {
    List<string> Sizes = new List<string>();
    Resolution[] resolutions;
    int currSelection = 0;
    [SerializeField]
    Text text;
    [SerializeField]
    Text fs;
    [SerializeField]
    Slider slider;
    bool fullScreen;
    // Use this for initialization
    private void Awake()
    {
        slider.value = PlayerPrefs.GetFloat("Volume");
        fullScreen = Screen.fullScreen; 
    }
    public void OnValueChange()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
	void Start () {
        text = text.GetComponent<Text>();
        resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            print(res.width + "x" + res.height);
        }
        //Sizes.Add("1280x1080");
    }
    public void PreviousScreenSize()
    {
        if (currSelection > 0)
            currSelection--;
    }
    public void NextScreenSize()
    {
        if (currSelection <= resolutions.Length)
            currSelection++;
    }
    public void SetFS()
    {
        fullScreen = true;
    }
    public void SetWindowed()
    {
        fullScreen = false;
    }
    public void Apply()
    {
        Screen.SetResolution(resolutions[currSelection].width, resolutions[currSelection].height, fullScreen);
        PlayerPrefs.SetInt("Width", resolutions[currSelection].width);
        PlayerPrefs.SetInt("Height", resolutions[currSelection].height);
        if(fullScreen == true)
            PlayerPrefs.SetString("FS", "true");
        else
            PlayerPrefs.SetString("FS", "false");
    }
    // Update is called once per frame
    void Update () {

        text.text = resolutions[currSelection].width + " x " + resolutions[currSelection].height;
        if (fullScreen)
            fs.text = "Yes";
        else
            fs.text = "No";
	}
}
