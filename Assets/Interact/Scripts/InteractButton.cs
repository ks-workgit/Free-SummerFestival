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

		// ボタンを押したとき
		if (Input.GetMouseButtonDown(0) && m_playerCamera.GetButton() == m_button)
		{
			m_pushCount = 0;
			
			// ドアの開閉
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

	// ドアの開閉フラグを取得する
	public void SetIsOpen(bool isOpen)
	{
		m_isOpen = isOpen;
	}

	// ドアの開閉フラグを返す
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

	// アニメーションを返す
	public Animator GetAnimator()
	{
		return m_animator;
	}
}
