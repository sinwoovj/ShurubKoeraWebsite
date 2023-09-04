using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FirstPersonMove : MonoBehaviour
{
    public float moveSpeed = 2.0f; // �̵� �ӵ�
    public float dashmoveSpeed = 6.0f;
    void Update()
    {
        KeyboardMove();
    }
    void KeyboardMove()
    {
        // WASD Ű �Ǵ� ȭ��ǥŰ�� �̵����� ����
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        // �̵����� * �ӵ� * �����Ӵ��� �ð��� ���ؼ� ī�޶��� Ʈ�������� �̵�
        var loc = dir * (Input.GetKey(KeyCode.LeftShift) ? dashmoveSpeed : moveSpeed) * Time.deltaTime;
        transform.Translate(loc);
    }
}