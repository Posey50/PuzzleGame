using UnityEngine.UI;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    /// <summary>
    /// Button on which this script is attached.
    /// </summary>
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(GoToMain);
    }

    /// <summary>
    /// Called to go to main menu.
    /// </summary>
    private void GoToMain()
    {
        MainMenuManager.Instance.SwitchToMain();
    }
}
