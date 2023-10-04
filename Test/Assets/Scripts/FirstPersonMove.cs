using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FirstPersonMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 2.0f; // 이동 속도
    public float dashmoveSpeed = 6.0f;
    public bool frontHaveObstruction = false;
    public float raycastLength = 1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        frontHaveObstruction = false;
        RaycastHit[] hit;
        hit = Physics.RaycastAll(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * raycastLength, Color.red);
        for(int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.name.Contains("Wall"))
            {
                frontHaveObstruction = true;
                Debug.Log("충돌!");
            }
        }
    }
    void FixedUpdate()
    {
        // WASD 키 또는 화살표키의 이동량을 측정
        Vector3 m_Input = new Vector3(
            Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        // 이동방향 * 속도 * 프레임단위 시간을 곱해서 카메라의 트랜스폼을 이동
        float m_speed = Input.GetKey(KeyCode.LeftShift) && !frontHaveObstruction ? dashmoveSpeed : moveSpeed;
        transform.Translate(m_Input * Time.deltaTime * m_speed);
    }
}