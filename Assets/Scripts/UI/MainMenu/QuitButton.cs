using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    /// <summary>
    /// Button on which this script is attached.
    /// </summary>
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(QuitGame);
    }

    /// <summary>
    /// Called to quit the game.
    /// </summary>
    private void QuitGame()
    {
        StartCoroutine(WaitToQuit());
    }

    /// <summary>
    /// Called to wait before to quiting.
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitToQuit()
    {
        yield return new WaitForSeconds(MainMenuManager.Instance.PlayMainFadeOut());
        Application.Quit();
    }
}
