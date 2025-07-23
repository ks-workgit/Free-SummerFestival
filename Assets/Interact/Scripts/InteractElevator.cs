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
	[SerializeField] private BoxCollider m_boxCollider;
	[SerializeField] private Material m_interactMaterial;
	[SerializeField] private Material m_defaultMaterial;

	private float m_waitTime = 5f;	// �G���x�[�^�[�����Ă���J���܂ł̎���
	private int m_pushCount = 1;	//�{�^�����������
	private bool m_up = false;

	private async void Update()
	{
		// �G���x�[�^�[����o���Ƃ�
		if (!m_playerController.GetIsStay())
		{
			m_pushCount = 1;
			m_interactButton.SetPushCount(m_pushCount);
			m_riseButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;
			m_fallButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;
		}

		// �G���x�[�^�[����ď㏸�{�^���������Ă����ꍇ
		if (m_interactButton.GetIsPush() && m_up)
		{
			Debug.Log("�㏸");
			m_boxCollider.isTrigger = false;
			m_interactButton.SetIsPush(false);
			m_riseButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;

			await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));  // ���b�҂�

			RiseCheck();    // ������ꍇ�ٕ̈ς̔���

			m_animator.Play("ElevatorOpen");    // �J���A�j���[�V�����Đ�
			m_interactButton.SetIsOpen(true);   // �J�t���O��true�ɂ���
			m_boxCollider.isTrigger = true;
		}
		// �G���x�[�^�[����ĉ��~�{�^���������Ă����ꍇ
		if (m_interactButton.GetIsPush() && !m_up)
		{
			Debug.Log("���~");
			m_boxCollider.isTrigger = false;
			m_interactButton.SetIsPush(false);
			m_fallButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;

			await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));  // ���b�҂�

			FallCheck();    // �������ꍇ�ٕ̈ς̔���

			m_animator.Play("ElevatorOpen");    // �J���A�j���[�V�����Đ�
			m_interactButton.SetIsOpen(true);   // �J�t���O��true�ɂ���
			m_boxCollider.isTrigger = true;
		}

		if (m_pushCount == 0)
		{
			return;
		}

		// �{�^�����������Ƃ�
		if (Input.GetMouseButtonDown(0) && m_playerCamera.GetButton())
		{
			// �㏸�{�^���̏ꍇ
			if (m_playerCamera.GetButton() == m_riseButton)
			{
				m_up = true;
				m_pushCount = 0;
				m_riseButton.GetComponent<MeshRenderer>().material = m_interactMaterial;
				Debug.Log("�㏸�{�^��!!!");
				m_animator.Play("ElevatorOpen");	// �J���A�j���[�V�����Đ�
				m_interactButton.SetIsOpen(true);   // �J�t���O��true�ɂ���
			}
			// ���~�{�^���̏ꍇ
			else if (m_playerCamera.GetButton() == m_fallButton)
			{
				m_up = false;
				m_pushCount = 0;
				m_fallButton.GetComponent<MeshRenderer>().material = m_interactMaterial;
				Debug.Log("���~�{�^��!!!");
				m_animator.Play("ElevatorOpen");   // �J���A�j���[�V�����Đ�
				m_interactButton.SetIsOpen(true);  // �J�t���O��true�ɂ���
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

	public bool GetUp()
	{
		return m_up;
	}
}
