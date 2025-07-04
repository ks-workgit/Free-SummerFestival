using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractElevator : MonoBehaviour
{
	private bool m_canPush;

	private void Start()
	{
		m_canPush = true;
	}

	public void Opening()
	{
		m_canPush = false;
	}

	public void Closing()
	{
		m_canPush = true;
	}

	public bool Animating()
	{
		return m_canPush;
	}
}
