using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform m_neck;		// プレイヤーの首のTransformを指定
    [SerializeField] private float m_sensitivity;	// マウス感度
    [SerializeField] private float m_minVertical;	// 視点の最小角度（縦の回転制限）
    [SerializeField] private float m_maxVertical;   // 視点の最大角度（縦の回転制限）
	[SerializeField] private float m_armLength;	// Rayの距離

    private float m_rotationX = 0f;	// 縦方向の回転角度

	private GameObject m_buttonObject;	// ボタンオブジェクトを返す用

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	private void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * m_sensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * m_sensitivity;

		// 体の左右の回転
		transform.Rotate(0, mouseX, 0);

		// 首の上下の回転
		m_rotationX -= mouseY;	// マウスのY方向の入力によって縦方向の回転を更新
		m_rotationX = Mathf.Clamp(m_rotationX, m_minVertical, m_maxVertical);	// 回転角度を指定された範囲に制限
		m_neck.localRotation = Quaternion.Euler(m_rotationX, 0, 0); // 首の回転を設定し、縦方向のみ回転させる

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// ボタンにヒットしたら
			if (Physics.Raycast(ray, out RaycastHit hit, m_armLength) && hit.collider.tag == "ElevatorButton")
			{
				// ヒットしたオブジェクトをボタンオブジェクトに代入
				m_buttonObject = hit.collider.gameObject;
			}
			else
			{
				m_buttonObject = null;
			}
		}
	}

	// ヒットしたボタンオブジェクトを返す
	public GameObject GetButton()
	{
		return m_buttonObject;
	}
}
