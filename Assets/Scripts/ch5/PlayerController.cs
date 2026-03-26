using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
            if (transform.position.x <= -3)
            {
                transform.Translate(-2 * (transform.position.x + .1f), 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
            if (transform.position.x >= 3)
            {
                transform.Translate(-2 * (transform.position.x + .1f), 0, 0);
            }
        }
    }
}
