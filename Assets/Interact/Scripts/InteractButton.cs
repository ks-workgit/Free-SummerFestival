using System;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
	[SerializeField] private Animator m_animator;
	[SerializeField] private GameObject m_button;
	[SerializeField] private PlayerCamera m_playerCamera;
	private bool m_isOpen;
	private int m_pushCount = 1;
	private bool m_isPush;

	private void Start()
	{
		m_isOpen = false;
		m_isPush = false;
	}

	private void Update()
	{
		if (m_pushCount == 0)
		{
			return;
		}

		// �{�^�����������Ƃ�
		if (Input.GetMouseButtonDown(0) && m_playerCamera.GetButton() == m_button)
		{
			m_pushCount = 0;
			
			// �h�A�̊J��
			if (!m_isOpen)
			{
				m_animator.Play("ElevatorOpen");
				m_isOpen = true;
			}
			else
			{
				m_animator.Play("ElevatorClose");
				m_isOpen = false;
				m_isPush = true;
			}
		}
	}

	// �h�A�̊J�t���O���擾����
	public void SetIsOpen(bool isOpen)
	{
		m_isOpen = isOpen;
	}

	// �h�A�̊J�t���O��Ԃ�
	public bool GetIsOpen()
	{
		return m_isOpen;
	}

	public bool GetIsPush()
	{
		return m_isPush;
	}

	public void SetIsPush(bool isPush)
	{
		m_isPush = isPush;
	}

	public void SetPushCount(int count)
	{
		m_pushCount = count;
	}

	// �A�j���[�V������Ԃ�
	public Animator GetAnimator()
	{
		return m_animator;
	}
}
