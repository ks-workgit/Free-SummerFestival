using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
	// ���݂̃t���A�̐���
	[SerializeField] private int m_currentNum;
	// �S�Ăٕ̈ς̃��X�g
	[SerializeField] private List<GameObject> m_allAnomalyList = new List<GameObject>();
	// �ٕς̑I����
	[SerializeField] private List<GameObject> m_selectAnomalyList = new List<GameObject>();
	// ���݂ٕ̈�
	[SerializeField] private GameObject m_anomaly;
	// �N���A����K�w
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

	// �ٕς̏�����
	public void AnomalyInit()
	{
		// �ٕς̑I�����̒��g��S�č폜
		m_selectAnomalyList.Clear();

		// �ēx�A�ٕς�S�đI�����ɓo�^
		for (int i = 0; i < m_allAnomalyList.Count; i++)
		{
			m_selectAnomalyList.Add(m_allAnomalyList[i]);
		}

		AnomalySet();

		m_currentNum = 0;
	}

	// �ٕς�I��ŃZ�b�g����
	public void AnomalySet()
	{
		m_currentNum++;

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

		if (m_currentNum == m_clearFloor)
		{
			return;
		}

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

	// ���݂ٕ̈ς�Ԃ�
	public GameObject Anomary()
	{
		return m_anomaly;
	}
}
