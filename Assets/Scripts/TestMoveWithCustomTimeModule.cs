using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveWithCustomTimeModule : MonoBehaviour
{
    public Vector3 Offset = Vector3.zero;
    public Vector3 originPosition;

    public float amplitude;
    public float frequency;

    private float currentTime = 0;
    void Start()
    {
        originPosition = transform.position;
    }

    void Update()
    {
        currentTime += TimeCustom.deltaTime;
        Offset = new Vector3(amplitude * Mathf.Sin(frequency * currentTime), 0, 0);
        transform.position = originPosition + Offset;
    }
}
