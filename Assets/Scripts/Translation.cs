using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    [SerializeField, Range(-1f, 1f)]
    public float TimeScale;

    public float speed;

    public Vector3 position;

    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        position = new (position.x + speed * Time.deltaTime * TimeScale, position.y, position.z);
        transform.position = position;
    }
}