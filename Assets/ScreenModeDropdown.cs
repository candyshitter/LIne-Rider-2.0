using TMPro;
using UnityEngine;

public class ScreenModeDropdown : MonoBehaviour
{
    private void Start()
    {
        TMP_Dropdown dropdown;
        (dropdown = GetComponent<TMP_Dropdown>()).onValueChanged.AddListener(
            index => Screen.fullScreenMode = (FullScreenMode) index);
        dropdown.value = (int)Screen.fullScreenMode;
    }
}
