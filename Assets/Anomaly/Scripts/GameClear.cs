using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField] private AnomalyManager m_anomalyManager;
	[SerializeField] private GameObject[] m_hiddenObject;

	private void Update()
	{
		// 現在のフロアがクリアフロアよりも大きくなった時
		if (m_anomalyManager.GetCurrentNum() > m_anomalyManager.GetClearFloor())
		{
			// 全て非表示にする
			foreach (var obj in m_hiddenObject)
			{
				obj.SetActive(false);
			}
		}
	}
}
