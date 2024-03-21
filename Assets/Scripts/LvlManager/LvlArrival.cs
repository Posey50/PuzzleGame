using UnityEngine;

public class LvlArrival : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            Debug.Log("Win");
        }
    }
}
