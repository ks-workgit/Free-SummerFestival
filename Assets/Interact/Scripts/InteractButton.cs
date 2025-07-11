using System;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
	[SerializeField] private Transform m_player;
	[SerializeField] private Animator m_animator;
	[SerializeField] private GameObject m_button;
	//[SerializeField] private PlayerController m_playerController;
	[SerializeField] private PlayerCamera m_playerCamera;
	[SerializeField] private InteractElevator m_interactElevator;
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

		if (Input.GetMouseButtonDown(0) && m_playerCamera.GetButton() == m_button/*&& m_interactElevator.GetCanPush()*/)
		{
			m_pushCount = 0;
			
			if (!m_isOpen)
			{
				m_animator.Play("ElevatorOpen");
				//await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));
				m_isOpen = true;
			}
			else
			{
				m_animator.Play("ElevatorClose");
				//await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));
				m_isOpen = false;
			}
			await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));
			m_pushCount = 1;
		}
	}

	public bool GetIsOpen()
	{
		return m_isOpen;
	}
}
