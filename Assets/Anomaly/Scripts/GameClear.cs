using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField] private AnomalyManager m_anomalyManager;
	[SerializeField] private GameObject[] m_hiddenObject;
	[SerializeField] private GameObject m_visibleObject;

	private bool m_isClear = false;

	private void Start()
	{
		m_visibleObject.SetActive(false);
	}

	private void Update()
	{
		// 現在のフロアがクリアフロアよりも大きくなった時
		if (m_anomalyManager.GetCurrentNum() > m_anomalyManager.GetClearFloor())
		{
			// ステージを全て非表示にする
			foreach (var obj in m_hiddenObject)
			{
				obj.SetActive(false);
			}

			// 異変を全て非表示にする
			foreach (var anomaly in m_anomalyManager.GetAnomalyList())
			{
				anomaly.SetActive(false);
			}

			// クリアオブジェクトを表示
			m_visibleObject.SetActive(true);

			m_isClear = true;
		}
	}

	public bool GetIsClear()
	{
		return m_isClear;
	}
}
