using System;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
	[SerializeField] private Transform m_player;
	[SerializeField] private Animator m_animator;
	[SerializeField] private float m_distance;
	private float m_waitTime = 1f;
	private bool m_isOpen;

	private void Start()
	{
		m_isOpen = false;
	}

	private async void OnMouseDown()
	{
		float distance = Vector3.Distance(m_player.position, transform.position);

		if (distance < m_distance)
		{
			if (!m_isOpen)
			{
				m_animator.Play("ElevatorOpen");
				await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));
				m_isOpen = true;
			}
			else
			{
				m_animator.Play("ElevatorClose");
				await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));
				m_isOpen = false;
			}
		}
	}
}
