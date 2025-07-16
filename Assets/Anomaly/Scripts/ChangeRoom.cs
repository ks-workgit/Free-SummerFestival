using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
	[SerializeField] private opencloseDoor m_closeDoorLeft, m_closeDoorRight;
	[SerializeField] private Transform m_player;

	private void OnEnable()
	{
		Debug.Log("アクティブ");
		m_closeDoorLeft.Player = m_player;
		m_closeDoorRight.Player = null;
	}

	private void OnDisable()
	{
		m_closeDoorLeft.Player = null;
		m_closeDoorRight.Player = m_player;
	}
}
