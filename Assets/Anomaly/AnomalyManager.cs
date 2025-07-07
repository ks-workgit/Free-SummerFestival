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

	// �ٕς̏�����
	private void AnomalyInit()
	{
		// �ٕς̑I�����̒��g��S�č폜
		m_selectAnomalyList.Clear();

		// �ēx�A�ٕς�S�đI�����ɓo�^
		m_selectAnomalyList = m_allAnomalyList;

		AnomalySet();
	}

	// �ٕς�I��ŃZ�b�g����
	private void AnomalySet()
	{
		// ��x�S�Ăٕ̈ς��\��
		for (int i = 0; i < m_allAnomalyList.Count; i++)
		{
			m_allAnomalyList[i].SetActive(false);
		}

		// �O��Ɠ����ٕς�����΁A�I�������珜�O����
		if (m_anomaly)
		{
			m_selectAnomalyList.Remove(m_anomaly);
		}

		// ���݂ٕ̈ς���x��ɂ���
		m_anomaly = null;

		// 7���̊m���ňٕς�����
		var random = Random.Range(0, 10);
		if (random > 3)
		{
			// �I�������烉���_���ňٕς�I��
			var num = Random.Range(0, m_selectAnomalyList.Count);
			// ���݂ٕ̈ςɃZ�b�g
			m_anomaly = m_selectAnomalyList[num];
			// �I�񂾈ٕς�\������
			m_anomaly.SetActive(true);
		}
	}
}
