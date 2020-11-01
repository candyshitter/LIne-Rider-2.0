using UnityEngine;
using UnityEngine.UI;

public class CameraFollowToggle : MonoBehaviour
{
    private void Start()
    {
        Toggle toggle;
        (toggle = GetComponent<Toggle>()).onValueChanged.AddListener(
            CameraFollow.Instance.HandleToggleChanged);
        if(toggle.isOn)
            CameraFollow.Instance.HandleToggleChanged(true);
    }
}
