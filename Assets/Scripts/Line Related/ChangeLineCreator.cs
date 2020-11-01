using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeLineCreator : MonoBehaviour
{
	[SerializeField] private LineEditorType lineEditorType = LineEditorType.Normal;
	private void Awake() => GetComponent<Button>().onClick.AddListener(
		() => LineManager.Instance.LineEditorManager.SetLineCreator(lineEditorType));

}