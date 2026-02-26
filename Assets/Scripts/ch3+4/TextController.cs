using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text text;
    public GameObject roulette;
    RouletteController rouletteController;
    public bool flag = true;

    private string GetText(float rotAngle)
    {
        var s = new string[] { "凶", "大吉", "大凶", "小吉", "末吉", "中吉" };
        if (rotAngle < 30) return s[0];
        else if (rotAngle < 30 + 60 * 1) return s[1];
        else if (rotAngle < 30 + 60 * 2) return s[2];
        else if (rotAngle < 30 + 60 * 3) return s[3];
        else if (rotAngle < 30 + 60 * 4) return s[4];
        else if (rotAngle < 30 + 60 * 5) return s[5];
        else return s[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        rouletteController = roulette.GetComponent<RouletteController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rouletteController.rotSpeed < 0.01 && flag)
        {
            text.text = GetText(roulette.transform.rotation.eulerAngles.z);
            if (text.text is "大凶" or "大吉")
            {
                text.color = Color.red;
            }
            else
            {
                text.color = Color.black;
            }
            Debug.Log(text.text);
            flag = false;
        }
    }
}
