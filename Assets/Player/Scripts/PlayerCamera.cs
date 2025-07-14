using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform m_neck;		// �v���C���[�̎��Transform���w��
    [SerializeField] private float m_sensitivity;	// �}�E�X���x
    [SerializeField] private float m_minVertical;	// ���_�̍ŏ��p�x�i�c�̉�]�����j
    [SerializeField] private float m_maxVertical;   // ���_�̍ő�p�x�i�c�̉�]�����j
	[SerializeField] private float m_armLength;	// Ray�̋���

    private float m_rotationX = 0f;	// �c�����̉�]�p�x

	private GameObject m_buttonObject;	// �{�^���I�u�W�F�N�g��Ԃ��p

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	private void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * m_sensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * m_sensitivity;

		// �̂̍��E�̉�]
		transform.Rotate(0, mouseX, 0);

		// ��̏㉺�̉�]
		m_rotationX -= mouseY;	// �}�E�X��Y�����̓��͂ɂ���ďc�����̉�]���X�V
		m_rotationX = Mathf.Clamp(m_rotationX, m_minVertical, m_maxVertical);	// ��]�p�x���w�肳�ꂽ�͈͂ɐ���
		m_neck.localRotation = Quaternion.Euler(m_rotationX, 0, 0); // ��̉�]��ݒ肵�A�c�����̂݉�]������

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// �{�^���Ƀq�b�g������
			if (Physics.Raycast(ray, out RaycastHit hit, m_armLength) && hit.collider.tag == "ElevatorButton")
			{
				// �q�b�g�����I�u�W�F�N�g���{�^���I�u�W�F�N�g�ɑ��
				m_buttonObject = hit.collider.gameObject;
			}
			else
			{
				m_buttonObject = null;
			}
		}
	}

	// �q�b�g�����{�^���I�u�W�F�N�g��Ԃ�
	public GameObject GetButton()
	{
		return m_buttonObject;
	}
}
