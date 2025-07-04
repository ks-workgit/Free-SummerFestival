using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
	[SerializeField] private Transform m_player;
	[SerializeField] private Animator m_animator;
	[SerializeField] private float m_distance;
	private bool m_isOpen;

	[SerializeField] private InteractElevator m_elevator;

	private void Start()
	{
		m_isOpen = false;
	}

	private void OnMouseDown()
	{
		float distance = Vector3.Distance(m_player.position, transform.position);

		if (distance < m_distance)
		{
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
		}
	}

	
}
