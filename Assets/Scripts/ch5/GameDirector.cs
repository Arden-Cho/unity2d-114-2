using System;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject hpGauge;
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time % 900 == 0)
        {
            GameObject.Find("ArrowGenerator").GetComponent<ArrowGenerator>().IncreaseDiff();
        }
    }

    public void DecreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount -= .1f;
        if (hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            GameObject.Find("player").transform.position = new Vector3(0, -3.56f, 0);
            hpGauge.GetComponent<Image>().fillAmount = 1f;
        }
    }

    public void IncreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount = Math.Min(hpGauge.GetComponent<Image>().fillAmount + .2f, 1f);
    }
}
