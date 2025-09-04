using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
	[SerializeField] private FadeController m_fadeController;
	[SerializeField] private Image m_fadePanel;
	[SerializeField] private AudioSource m_bgm;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		// ÉVÅ[ÉìëJà⁄ÇµÇ»Ç¢
		m_fadeController.FadeOut(false);

		m_bgm.Play();
	}
}
