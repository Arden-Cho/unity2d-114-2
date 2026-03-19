using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CH6PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public Text clock;

    const float jumpForce = 680f;
    const float walkForce = 30f;
    const float maxWalkSpeed = 2f;
    int ticks = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ticks % Application.targetFrameRate == 0)
        {
            clock.text = (int.Parse(clock.text) + 1).ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0)
        {
            animator.SetTrigger("JumpTrigger");
            rigid2D.AddForce(transform.up * jumpForce);
        }

        int direction = 0;
        if (Input.GetKey(KeyCode.RightArrow)) direction = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) direction = -1;

        float speedx = Mathf.Abs(rigid2D.velocity.x);

        if (speedx < maxWalkSpeed)
        {
            rigid2D.AddForce(direction * walkForce * transform.right);
        }

        if (direction != 0)
        {
            transform.localScale = new Vector3(direction, 1, 1);
        }

        if (rigid2D.velocity.y == 0)
        {
            animator.speed = speedx / 2;
        }
        else
        {
            animator.speed = 1;
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("ch6");
        }

        if (Mathf.Abs(transform.position.x) >= 2.3)
        {
            transform.position = new Vector3(-(transform.position.x * .9f), transform.position.y, transform.position.z);
        }

        ticks++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("ch6_ClearScene");
    }
}
