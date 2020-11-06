using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
	[SerializeField] private GameObject settingsMenu;

	private void Start() => 
		GetComponent<Button>().onClick.AddListener(
			() => settingsMenu.SetActive(true));

	private void Awake()
	{
		Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
	}
}
