using UnityEngine;
using UnityEngine.UI;

public class UISliderStep : MonoBehaviour
{
    public float stepAmount;
    Slider mySlider = null;

    float numberOfSteps = 0;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        numberOfSteps = mySlider.maxValue / stepAmount;
    }

    public void Fixed()
    {
        float range = (mySlider.value / mySlider.maxValue) * numberOfSteps;
        int ceil = Mathf.CeilToInt(range);
        mySlider.value = ceil * stepAmount;
    }
}
