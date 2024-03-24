using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlButton : MonoBehaviour
{
    /// <summary>
    /// Button on which this script is attached.
    /// </summary>
    private Button _button;

    /// <summary>
    /// Name of the lvl to launch.
    /// </summary>
    [SerializeField]
    private int _lvlNumber;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LaunchLvl);
    }

    /// <summary>
    /// Called to launch a lvl.
    /// </summary>
    private void LaunchLvl()
    {
        StartCoroutine(WaitFadeOut());
    }

    /// <summary>
    /// Called to wait the fade out before launching the lvl.
    /// </summary>
    private IEnumerator WaitFadeOut()
    {
        yield return new WaitForSeconds(MainMenuManager.Instance.PlayMapFadeOut());
        SceneManager.LoadScene("Level" + _lvlNumber.ToString());
    }
}
