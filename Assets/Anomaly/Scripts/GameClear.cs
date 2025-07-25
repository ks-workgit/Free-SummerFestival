using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField] private AnomalyManager m_anomalyManager;

	private void Update()
	{
		m_anomalyManager.GetCurrentNum();
	}
}
