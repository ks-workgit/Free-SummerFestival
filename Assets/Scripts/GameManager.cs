using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FadeController m_fadeController;

	private void Start()
	{
		m_fadeController.FadeOut(false);
	}
}
