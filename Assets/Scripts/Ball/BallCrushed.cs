using UnityEngine;

public class BallCrushed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Environment")
        {
            GetComponentInParent<BallDestruction>().DestroySelf();
        }
    }
}
