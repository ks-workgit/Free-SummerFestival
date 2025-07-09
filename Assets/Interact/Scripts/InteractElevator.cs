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
				Debug.Log("����");
			}
			else if (m_playerCamera.GetButton() == m_fallButton)
			{
				FallCheck();
				Debug.Log("����");
			}
		}
	}

	// �������
	private void RiseCheck()
	{
		// �ٕς��Ȃ���
		if (m_anomalyManager.Anomary() == null)
		{
			// ����
			m_anomalyManager.AnomalySet();
		}
		// �ٕς����鎞
		else if (m_anomalyManager.Anomary())
		{
			// �~�X
			m_anomalyManager.AnomalyInit();
		}
	}

	// ��������
	private void FallCheck()
	{
		// �ٕς����鎞
		if (m_anomalyManager.Anomary())
		{
			// ����
			m_anomalyManager.AnomalySet();
		}
		// �ٕς��Ȃ���
		else if (m_anomalyManager.Anomary() == null)
		{
			// �~�X
			m_anomalyManager.AnomalyInit();
		}
	}
}
