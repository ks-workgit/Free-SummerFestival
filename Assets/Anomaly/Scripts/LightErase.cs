using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightErase : MonoBehaviour
{
    [SerializeField] private Light[] m_targetLight;

	private void OnEnable()
	{
		foreach (var obj in m_targetLight)
		{
			// ライトを消す
			obj.enabled = false;
		}
	}

	private void OnDisable()
	{
		foreach (var obj in m_targetLight)
		{
			// ライトを点ける
			obj.enabled = true;
		}
	}
}
