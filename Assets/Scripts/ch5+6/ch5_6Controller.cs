using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ch5_6Controller : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("ch5");
        });
        btn2.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("ch6");
        });
    }
}
