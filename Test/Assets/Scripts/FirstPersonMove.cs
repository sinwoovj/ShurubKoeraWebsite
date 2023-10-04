using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FirstPersonMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 2.0f; // �̵� �ӵ�
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
                Debug.Log("�浹!");
            }
        }
    }
    void FixedUpdate()
    {
        // WASD Ű �Ǵ� ȭ��ǥŰ�� �̵����� ����
        Vector3 m_Input = new Vector3(
            Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        // �̵����� * �ӵ� * �����Ӵ��� �ð��� ���ؼ� ī�޶��� Ʈ�������� �̵�
        float m_speed = Input.GetKey(KeyCode.LeftShift) && !frontHaveObstruction ? dashmoveSpeed : moveSpeed;
        transform.Translate(m_Input * Time.deltaTime * m_speed);
    }
}