using UnityEngine;

public class DestructiveSurface : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.GetComponent<BallDestruction>().DestroySelf();
        }
    }
}