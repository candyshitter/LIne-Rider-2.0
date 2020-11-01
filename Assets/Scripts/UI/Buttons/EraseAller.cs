using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseAller : MonoBehaviour
{
	public void EraseAll() => LineManager.DestroyLines();
}
