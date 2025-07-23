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

	private float m_waitTime = 5f;	// エレベーターが閉じてから開くまでの時間
	private int m_pushCount = 1;	//ボタンを押せる回数
	private bool m_up = false;

	private async void Update()
	{
		// エレベーターから出たとき
		if (!m_playerController.GetIsStay())
		{
			m_pushCount = 1;
			m_interactButton.SetPushCount(m_pushCount);
			m_riseButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;
			m_fallButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;
		}

		// エレベーターを閉じて上昇ボタンを押していた場合
		if (m_interactButton.GetIsPush() && m_up)
		{
			Debug.Log("上昇");
			m_boxCollider.isTrigger = false;
			m_interactButton.SetIsPush(false);
			m_riseButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;

			await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));  // 数秒待つ

			RiseCheck();    // 上った場合の異変の判定

			m_animator.Play("ElevatorOpen");    // 開くアニメーション再生
			m_interactButton.SetIsOpen(true);   // 開閉フラグをtrueにする
			m_boxCollider.isTrigger = true;
		}
		// エレベーターを閉じて下降ボタンを押していた場合
		if (m_interactButton.GetIsPush() && !m_up)
		{
			Debug.Log("下降");
			m_boxCollider.isTrigger = false;
			m_interactButton.SetIsPush(false);
			m_fallButton.GetComponent<MeshRenderer>().material = m_defaultMaterial;

			await UniTask.Delay(TimeSpan.FromSeconds(m_waitTime));  // 数秒待つ

			FallCheck();    // 下った場合の異変の判定

			m_animator.Play("ElevatorOpen");    // 開くアニメーション再生
			m_interactButton.SetIsOpen(true);   // 開閉フラグをtrueにする
			m_boxCollider.isTrigger = true;
		}

		if (m_pushCount == 0)
		{
			return;
		}

		// ボタンを押したとき
		if (Input.GetMouseButtonDown(0) && m_playerCamera.GetButton())
		{
			// 上昇ボタンの場合
			if (m_playerCamera.GetButton() == m_riseButton)
			{
				m_up = true;
				m_pushCount = 0;
				m_riseButton.GetComponent<MeshRenderer>().material = m_interactMaterial;
				Debug.Log("上昇ボタン!!!");
				m_animator.Play("ElevatorOpen");	// 開くアニメーション再生
				m_interactButton.SetIsOpen(true);   // 開閉フラグをtrueにする
			}
			// 下降ボタンの場合
			else if (m_playerCamera.GetButton() == m_fallButton)
			{
				m_up = false;
				m_pushCount = 0;
				m_fallButton.GetComponent<MeshRenderer>().material = m_interactMaterial;
				Debug.Log("下降ボタン!!!");
				m_animator.Play("ElevatorOpen");   // 開くアニメーション再生
				m_interactButton.SetIsOpen(true);  // 開閉フラグをtrueにする
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

	public bool GetUp()
	{
		return m_up;
	}
}
