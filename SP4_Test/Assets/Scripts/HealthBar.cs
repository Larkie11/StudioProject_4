using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    float fillAmount;
    Image content;
    [SerializeField]
    int healthbarid;
    [SerializeField]
    Text text;
	// Use this for initialization
	void Start () {
        content = GetComponent<Image>();
	}
    void ChangeFill()
    {
        if (healthbarid == 3)
        {
            content.fillAmount = Map(GlobalScript.Zakhp, 0, 200, 0, 1);
            if (content.fillAmount <= 0.3F)
            {
                content.color = Color.red;
            }
            else
                content.color = Color.green;
        }

        if (healthbarid == 2)
        {
            content.fillAmount = Map(GlobalScript.CrimsonHealth, 0, 300, 0, 1);
            if (content.fillAmount <= 0.25F)
            {
                content.color = Color.red;
            }
            else if (content.fillAmount > 0.25F && content.fillAmount < 0.6F)
            {
                content.color = Color.yellow;
            }
            else
                content.color = Color.green;

            //if (GlobalScript.CrimsonHealth > 150)
            //{

            //}
            //else if (GlobalScript.CrimsonHealth > 75 && GlobalScript.CrimsonHealth < 150)
            //{

            //}
            //else if (GlobalScript.CrimsonHealth < 75)
            //{

            //}

        }

        if (healthbarid == 1)
        {
            content.fillAmount = Map(GlobalScript.GrifHealth, 0, 400, 0, 1);
            if (content.fillAmount <= 0.3F)
            {
                content.color = Color.red;
            }
            else
                content.color = Color.green;
        }

        if (healthbarid == 0)
        {
            content.fillAmount = Map(GlobalScript.Shield, 0, GlobalScript.myCharacters[GlobalScript.CharacterType].maxShield, 0, 1);
            if (text == null)
                text.GetComponent<Text>();
            if(text != null)
            text.text = (int)GlobalScript.Shield + " / " + GlobalScript.myCharacters[GlobalScript.CharacterType].maxShield;
        }

    }
    // Update is called once per frame
    void Update () {
        ChangeFill();
	}
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
