using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ChangeLineCreator : MonoBehaviour
{
	[SerializeField] private LineEditorType lineEditorType = LineEditorType.Normal;
	private void Start() => GetComponent<Toggle>().onValueChanged.AddListener(state =>
		LineManager.Instance.EditorManager.SetLineCreator(lineEditorType));

}