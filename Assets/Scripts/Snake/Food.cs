using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        float x = Mathf.Round(Random.Range(gridArea.bounds.min.x, gridArea.bounds.max.x));
        float y = Mathf.Round(Random.Range(gridArea.bounds.min.y, gridArea.bounds.max.y));

        transform.position = new Vector3(x, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            RandomizePosition();
    }
}
