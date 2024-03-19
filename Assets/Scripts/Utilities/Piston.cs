using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    /// <summary>
    /// Range of the piston.
    /// </summary>
    [SerializeField, Range (1, 10)]
    private int _range;

    /// <summary>
    /// List of all animator controllers with different ranges.
    /// </summary>
    [SerializeField]
    private List<RuntimeAnimatorController> _animatorControllers = new ();

    /// <summary>
    /// Animator of the object.
    /// </summary>
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator> ();
        _animator.runtimeAnimatorController = _animatorControllers[_range - 1];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireMesh(GetComponent<MeshFilter>().sharedMesh, 0, transform.position + transform.right * _range, transform.rotation, transform.localScale);
    }
}
