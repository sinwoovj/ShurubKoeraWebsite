using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FirstPersonMove : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 이동 속도
    public float dashmoveSpeed = 6.0f;
    void Update()
    {
        KeyboardMove();
    }
    void KeyboardMove()
    {
        // WASD 키 또는 화살표키의 이동량을 측정
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        // 이동방향 * 속도 * 프레임단위 시간을 곱해서 카메라의 트랜스폼을 이동
        var loc = dir * (Input.GetKey(KeyCode.LeftShift) ? dashmoveSpeed : moveSpeed) * Time.deltaTime;
        transform.Translate(loc);
    }
}