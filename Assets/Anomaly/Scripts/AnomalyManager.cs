using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
	// 現在のフロアの数字
	[SerializeField] private int m_currentNum;
	// 全ての異変のリスト
	[SerializeField] private List<GameObject> m_allAnomalyList = new List<GameObject>();
	// 異変の選択肢
	[SerializeField] private List<GameObject> m_selectAnomalyList = new List<GameObject>();
	// 現在の異変
	[SerializeField] private GameObject m_anomaly;
	// クリアする階層
	[SerializeField] private int m_clearFloor;

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
	public void AnomalyInit()
	{
		// 異変の選択肢の中身を全て削除
		m_selectAnomalyList.Clear();

		// 再度、異変を全て選択肢に登録
		for (int i = 0; i < m_allAnomalyList.Count; i++)
		{
			m_selectAnomalyList.Add(m_allAnomalyList[i]);
		}

		AnomalySet();

		m_currentNum = 0;
	}

	// 異変を選んでセットする
	public void AnomalySet()
	{
		m_currentNum++;

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

		if (m_currentNum == m_clearFloor)
		{
			return;
		}

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

	// 現在の異変を返す
	public GameObject Anomary()
	{
		return m_anomaly;
	}
}
