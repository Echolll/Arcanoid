using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 initialVelocity = new Vector3(1f, 0f, 0f); // ��������� �������� ����
    private Vector3 currentVelocity; // ������� �������� ����

    void Start()
    {
        currentVelocity = initialVelocity;
    }

    void Update()
    {
        // ������� ��� � ������� ���������
        transform.Translate(currentVelocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MainCamera"))
        {
            // ���������� ������� � �����������, � ������� ���������� ���
            Vector3 platformNormal = collision.contacts[0].normal;

            // �������� �������� ���� ������������ �������
            currentVelocity = Vector3.Reflect(currentVelocity, platformNormal);
        }
    }
}
