using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeItem : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float distanceToPass;

    private Vector3 startPosition;
    private float zPosition;

    private void OnEnable()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(0f, 0f, Time.deltaTime * moveSpeed);

        zPosition = transform.position.z;

        if (zPosition > distanceToPass)
        {
            transform.position = startPosition;
            gameObject.SetActive(false);
        }
    }

}
