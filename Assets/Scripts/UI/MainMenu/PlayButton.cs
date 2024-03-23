using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    /// <summary>
    /// Button on which this script is attached.
    /// </summary>
    private Button _button;

    /// <summary>
    /// Name of the first lvl.
    /// </summary>
    [SerializeField]
    private string _firstLvlName;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LaunchGame);
    }

    /// <summary>
    /// Called to launch the game.
    /// </summary>
    private void LaunchGame()
    {
        StartCoroutine(WaitToLaunch());
    }

    /// <summary>
    /// Called to wait before to launching the game.
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitToLaunch()
    {
        yield return new WaitForSeconds(MainMenuManager.Instance.PlayMainFadeOut());
        SceneManager.LoadScene(_firstLvlName);
    }
}
