using UnityEngine;

public class CH6CameraController : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
    }
}
