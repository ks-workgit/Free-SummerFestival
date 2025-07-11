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
    private bool m_isStay;

	private void Start()
	{
        m_velocity = new Vector3(0, 0, 0);
		m_isGrounded = false;
        m_isStay = false;
	}

	private void Update()
	{
        m_isGrounded = m_controller.isGrounded;

        // ���n���Ă���ꍇ�͗������x�����Z�b�g
        if (m_isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = 0f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // ���[�J�����W�����[���h���W�ɕϊ����Ĉړ��������v�Z
        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0, y).normalized);

        // ����/�����̈ړ��ʂ���Z
        moveDirection *= Input.GetKey(KeyCode.LeftShift) ? m_dashSpeed : m_walkSpeed;

        // �d�͂����Z
        m_velocity.y += m_gravity * Time.deltaTime;

        // �ړ��Əd�͂���x��Move�ŏ���
        m_controller.Move((moveDirection + m_velocity) * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ElevatorSensor"))
        {
            m_isStay = true;
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("ElevatorSensor"))
		{
			m_isStay = false;
		}
	}

    public bool GetIsStay()
    {
        return m_isStay;
    }
}
