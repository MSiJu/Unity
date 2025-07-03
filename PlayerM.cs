using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    // �p�����[�^
    public float moveSpeed = 5f;           // �ړ����x
    public float gravity = -9.8f;        // �d�͉����x
    public CharacterController controller;  // �ړ��Ɏg��CharacterController

    // ���Z�p�ϐ�
    private Vector3 velocity;       // �����x��ێ�����ϐ�
    private bool isGrounded;        // �n�ʂɒ��n���Ă��邩�ǂ����̃t���O�ϐ�

    // �Q�[�������s�����Update�֐�
    void Update()
    {
        // ���n��Ԃ̃`�F�b�N
        isGrounded = controller.isGrounded;

        // ���n���Ă���ꍇ�͗������x�����Z�b�g
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // �n�ʂɒ������ꍇ�A���x�����Z�b�g
        }

        // ���͂̎擾
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ���[�J�����W�����[���h���W�ɕϊ����Ĉړ��������v�Z
        Vector3 moveDirection = transform.TransformDirection(new Vector3(h, 0, v)) * moveSpeed;

        // �d�͂����Z
        velocity.y += gravity * Time.deltaTime;

        // �ړ��Əd�͂���x��controller.Move�ŏ���
        controller.Move((moveDirection + velocity) * Time.deltaTime);
    }
}
