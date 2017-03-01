using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;

public class FacebookCheck: MonoBehaviour {
    [SerializeField]
    GameObject sharebutton;
    [SerializeField]
    Text text;
    private void Awake()
    {
        if(!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }
    // Use this for initialization
    public void LogIn()
    {
        FB.LogInWithReadPermissions(callback:OnLogIn);
    }
    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            AccessToken token = AccessToken.CurrentAccessToken;
            //token.UserId
            //text.text = token.UserId;
        }
        else
            Debug.Log("Canceled login");
    }
	// Use this for initialization
	void Start () {
 
        text.text = "You have cleared the game! Your score was " + GlobalScript.Score +"!";
#if UNITY_STANDALONE
        sharebutton.SetActive(false);
#endif
    }
    public void Share()
    {
        FB.ShareLink(contentTitle: "Let's play", contentURL: new System.Uri("http://www.youtube.com"), contentDescription: "I reached a score of " + GlobalScript.Score + "!",callback:OnShare);
    }
    private void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log(result.Error);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
