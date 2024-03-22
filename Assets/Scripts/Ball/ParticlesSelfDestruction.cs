using System.Collections;
using UnityEngine;

public class ParticlesSelfDestruction : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Wait());
    }

    /// <summary>
    /// Coroutine to wait before destruction.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
