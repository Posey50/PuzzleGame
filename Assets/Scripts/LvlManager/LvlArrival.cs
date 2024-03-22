using UnityEngine;

public class LvlArrival : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Win");
        }
    }
}
