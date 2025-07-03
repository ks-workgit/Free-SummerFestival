using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_walkSpeed;
    [SerializeField] private float m_dashSpeed;
    [SerializeField] private float m_gravity;
    [SerializeField] private CharacterController m_controller;

    private Vector3 m_velocity;
    private bool m_isGrounded;

	private void Start()
	{
        m_velocity = new Vector3(0, 0, 0);
		m_isGrounded = false;
	}

	private void Update()
	{
        m_isGrounded = m_controller.isGrounded;

        // 着地している場合は落下速度をリセット
        if (m_isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = 0f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // ローカル座標をワールド座標に変換して移動方向を計算
        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0, y).normalized);

        // 走る/歩くの移動量を乗算
        moveDirection *= Input.GetKey(KeyCode.LeftShift) ? m_dashSpeed : m_walkSpeed;

        // 重力を加算
        m_velocity.y += m_gravity * Time.deltaTime;

        // 移動と重力を一度のMoveで処理
        m_controller.Move((moveDirection + m_velocity) * Time.deltaTime);
	}
}
