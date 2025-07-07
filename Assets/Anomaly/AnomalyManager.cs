using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    [SerializeField] private int m_currentNum;

    [SerializeField] private List<GameObject> m_allAnomalyList = new List<GameObject>();

    [SerializeField] private List<GameObject> m_selectAnomalyList = new List<GameObject>();

	[SerializeField] private GameObject m_anomaly;

	private void Start()
	{
		AnomalyInit();

		if (m_anomaly)
		{
			m_anomaly.SetActive(false);
			m_anomaly = null;
		}
	}

	// 異変の初期化
	private void AnomalyInit()
	{
		// 異変の選択肢の中身を全て削除
		m_selectAnomalyList.Clear();

		// 再度、異変を全て選択肢に登録
		m_selectAnomalyList = m_allAnomalyList;

		AnomalySet();
	}

	// 異変を選んでセットする
	private void AnomalySet()
	{
		// 一度全ての異変を非表示
		for (int i = 0; i < m_allAnomalyList.Count; i++)
		{
			m_allAnomalyList[i].SetActive(false);
		}

		// 前回と同じ異変があれば、選択肢から除外する
		if (m_anomaly)
		{
			m_selectAnomalyList.Remove(m_anomaly);
		}

		// 現在の異変を一度空にする
		m_anomaly = null;

		// 7割の確率で異変が発生
		var random = Random.Range(0, 10);
		if (random > 3)
		{
			// 選択肢からランダムで異変を選ぶ
			var num = Random.Range(0, m_selectAnomalyList.Count);
			// 現在の異変にセット
			m_anomaly = m_selectAnomalyList[num];
			// 選んだ異変を表示する
			m_anomaly.SetActive(true);
		}
	}
}
