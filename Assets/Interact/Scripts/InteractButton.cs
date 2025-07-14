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
	private float m_waitTime = 1f;
	private bool m_isOpen;
	private int m_pushCount = 1;

	private void Start()
	{
		m_isOpen = false;
	}

	private async void Update()
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
			}
			await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));
			m_pushCount = 1;
		}
	}

	// �h�A�̊J�t���O���擾����
	public void SetIsOpen(bool isOpen)
	{
		m_isOpen = isOpen;
	}

	// �A�j���[�V������Ԃ�
	public Animator GetAnimator()
	{
		return m_animator;
	}
}
