using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    float fillAmount;
    Image content;
    [SerializeField]
    int healthbarid;
	// Use this for initialization
	void Start () {
        content = GetComponent<Image>();
	}
    void ChangeFill()
    {
        if (healthbarid == 1)
        {
            content.fillAmount = Map(GlobalScript.GrifHealth, 0, 50, 0, 1);
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
            Debug.Log(content.fillAmount);
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
