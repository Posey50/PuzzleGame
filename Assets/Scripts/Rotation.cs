using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotation : MonoBehaviour
{
    [SerializeField, Range(-1f, 1f)]
    public float TimeScale;

    public float speedRotation;

    public Vector3 rotation;

    public Animator animator;

    void Start()
    {
        rotation = transform.rotation.eulerAngles;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotation = new (rotation.x, rotation.y + speedRotation * Time.deltaTime * TimeScale, rotation.z);
        //transform.rotation = Quaternion.Euler(rotation);

        animator.SetFloat("TimeScale", TimeScale);
    }
}
