using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private readonly List<Transform> segments = new();
    [SerializeField] Transform segmentPrefab;
    private const int initialSize = 7;
    private const float timestep = .16F;
    private float timestepAccumulator = 0;
    private float speed = 1;

    private void Start()
    {
        ResetState();
    }

    private void IncreaseSpeed()
    {
        speed += .3F;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (direction != Vector2.down)
                direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (direction != Vector2.up)
                direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (direction != Vector2.right)
                direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (direction != Vector2.left)
                direction = Vector2.right;
        }
        timestepAccumulator += Time.deltaTime * speed;
        while (timestepAccumulator >= timestep)
        {
            MyFixedUpdate();
            timestepAccumulator -= timestep;
        }
    }

    private void MyFixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
            segments[i].position = segments[i - 1].position;

        transform.position = new Vector3(Mathf.Round(transform.position.x) + direction.x, Mathf.Round(transform.position.y) + direction.y, 0);
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[^1].position;
        segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
            Destroy(segments[i].gameObject);

        segments.Clear();
        segments.Add(transform);

        for (int i = 1; i < initialSize; i++)
            segments.Add(Instantiate(segmentPrefab));

        transform.position = Vector3.zero;

        speed = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            Grow();
            IncreaseSpeed();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            ResetState();
        }
        else if (collision.CompareTag("Poison"))
        {
            if (segments.Count < 4)
            {
                ResetState();
            }
            else
            {
                for (int i = segments.Count - 1; i >= segments.Count - 3; i--)
                {
                    Destroy(segments[i].gameObject);
                }
                segments.RemoveRange(segments.Count - 3, 3);
            }
        }
    }
}
