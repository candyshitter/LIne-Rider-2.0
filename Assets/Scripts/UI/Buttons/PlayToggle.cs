using UnityEngine;
using UnityEngine.UI;

public class PlayToggle : MonoBehaviour
{
	public static PlayToggle Instance { get; private set; }
	private Toggle _toggle;

	private void Awake()
	{
		Instance = this;
		_toggle = GetComponent<Toggle>();
	}

	private void Start() => 
		_toggle.onValueChanged.AddListener(
		state => GameStateHolder.IsPlaying = state);

	public static void Reset() => Instance._toggle.isOn = false;
}