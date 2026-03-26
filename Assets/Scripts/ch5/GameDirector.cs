using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject hpGauge;
    int time = 0;

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
            SceneManager.LoadScene("ch5+6");
        }
    }

    public void IncreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount = Math.Min(hpGauge.GetComponent<Image>().fillAmount + .2f, 1f);
    }
}
