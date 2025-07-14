using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractElevator : MonoBehaviour
{
	[SerializeField] private AnomalyManager m_anomalyManager;
	[SerializeField] private GameObject m_riseButton, m_fallButton;
	[SerializeField] private PlayerController m_playerController;
	[SerializeField] private PlayerCamera m_playerCamera;
	[SerializeField] private InteractButton m_interactButton;
	[SerializeField] private Animator m_animator;

	private float m_waitTime = 5f;
	private int m_pushCount = 1;

	private async void Update()
	{
		// �G���x�[�^�[����o���Ƃ�
		if (!m_playerController.GetIsStay())
		{
			m_pushCount = 1;
		}

		if (m_pushCount == 0)
		{
			return;
		}

		// �{�^�����������Ƃ�
		if (Input.GetMouseButtonDown(0) && m_playerCamera.GetButton())
		{
			m_pushCount = 0;

			// �㏸�{�^���̏ꍇ
			if (m_playerCamera.GetButton() == m_riseButton)
			{
				m_animator.Play("ElevatorClose");	// ����A�j���[�V�����Đ�
				m_interactButton.SetIsOpen(false);	// �J�t���O��false�ɂ���

				await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));	// ���b�҂�

				RiseCheck();	// ������ꍇ�ٕ̈ς̔���

				m_animator.Play("ElevatorOpen");	// �J���A�j���[�V�����Đ�
				m_interactButton.SetIsOpen(true);	// �J�t���O��true�ɂ���
			}
			// ���~�{�^���̏ꍇ
			else if (m_playerCamera.GetButton() == m_fallButton)
			{
				m_animator.Play("ElevatorClose");   // ����A�j���[�V�����Đ�
				m_interactButton.SetIsOpen(false);  // �J�t���O��false�ɂ���

				await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));  // ���b�҂�

				FallCheck();    // �������ꍇ�ٕ̈ς̔���

				m_animator.Play("ElevatorOpen");    // �J���A�j���[�V�����Đ�
				m_interactButton.SetIsOpen(true);   // �J�t���O��true�ɂ���
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
