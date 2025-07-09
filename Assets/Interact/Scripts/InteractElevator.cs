using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractElevator : MonoBehaviour
{
	[SerializeField] private AnomalyManager m_anomalyManager;
	[SerializeField] private GameObject m_riseButton, m_fallButton;
	[SerializeField] private PlayerCamera m_playerCamera;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (m_playerCamera.GetButton() == m_riseButton)
			{
				RiseCheck();
				Debug.Log("うえ");
			}
			else if (m_playerCamera.GetButton() == m_fallButton)
			{
				FallCheck();
				Debug.Log("した");
			}
		}
	}

	// 上った時
	private void RiseCheck()
	{
		// 異変がない時
		if (m_anomalyManager.Anomary() == null)
		{
			// 正解
			m_anomalyManager.AnomalySet();
		}
		// 異変がある時
		else if (m_anomalyManager.Anomary())
		{
			// ミス
			m_anomalyManager.AnomalyInit();
		}
	}

	// 下った時
	private void FallCheck()
	{
		// 異変がある時
		if (m_anomalyManager.Anomary())
		{
			// 正解
			m_anomalyManager.AnomalySet();
		}
		// 異変がない時
		else if (m_anomalyManager.Anomary() == null)
		{
			// ミス
			m_anomalyManager.AnomalyInit();
		}
	}
}
