using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
	[SerializeField] private FadeController m_fadeController;
	[SerializeField] private Image m_fadePanel;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		// ƒV[ƒ“‘JˆÚ‚µ‚È‚¢
		m_fadeController.FadeOut(false);
	}
}
