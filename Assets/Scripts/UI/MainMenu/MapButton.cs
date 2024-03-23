using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    /// <summary>
    /// Button on which this script is attached.
    /// </summary>
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(GoToMap);
    }

    /// <summary>
    /// Called to go to map menu.
    /// </summary>
    private void GoToMap()
    {
        MainMenuManager.Instance.SwitchToMap();
    }
}
