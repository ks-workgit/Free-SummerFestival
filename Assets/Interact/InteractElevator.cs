using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractElevator : MonoBehaviour
{
	[SerializeField] private AnomalyManager m_anomalyManager;
	[SerializeField] private GameObject m_riseButton, m_fallButton;
	[SerializeField] private PlayerCamera m_playerCamera;

	private void Update()
	{
		if (m_playerCamera.GetButton() == m_riseButton)
		{
			Debug.Log("‚¤‚¦");
		}
		else if (m_playerCamera.GetButton() == m_fallButton)
		{
			Debug.Log("‚µ‚½");
		}

	}
}
