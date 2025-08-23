using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureClear : MonoBehaviour
{
    [SerializeField] GameObject[] m_furniture;

    private void OnEnable()
    {
        foreach (var obj in m_furniture)
        {
            obj.SetActive(false);
        }
    }

    private void OnDisable()
    {
        foreach (var obj in m_furniture)
        {
            obj.SetActive(true);
        }
    }
}
