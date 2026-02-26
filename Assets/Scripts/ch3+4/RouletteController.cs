using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 0;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = Random.value * 100;
            text.GetComponent<TextController>().flag = true;
        }

        transform.Rotate(0, 0, rotSpeed);

        if (Random.value > .5f) rotSpeed *= .97f;
    }
}
