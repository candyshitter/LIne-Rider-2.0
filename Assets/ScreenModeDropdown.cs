using TMPro;
using UnityEngine;

public class ScreenModeDropdown : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TMP_Dropdown>().onValueChanged.AddListener(
            index => Screen.fullScreenMode = (FullScreenMode) index);
    }
}
