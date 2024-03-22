using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    /// <summary>
    /// Text which shows remaining lifes.
    /// </summary>
    private TMP_Text _remainingLifes;

    private void Awake()
    {
        _remainingLifes = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        LvlManager.Instance.NewNumberOfLifes += UpdateUI;
    }

    /// <summary>
    /// Called to update the number of lifes on screen.
    /// </summary>
    /// <param name="newNumberOfLifes"> New number of lifes to update. </param>
    private void UpdateUI(int newNumberOfLifes)
    {
        _remainingLifes.SetText("x" + newNumberOfLifes.ToString());
    }
}
