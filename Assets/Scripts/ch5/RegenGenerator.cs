using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 5;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-3, 3);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
