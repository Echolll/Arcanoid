using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 initialVelocity = new Vector3(1f, 0f, 0f); // Ќачальна€ скорость м€ча
    private Vector3 currentVelocity; // “екуща€ скорость м€ча

    void Start()
    {
        currentVelocity = initialVelocity;
    }

    void Update()
    {
        // ƒвигаем м€ч с текущей скоростью
        transform.Translate(currentVelocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MainCamera"))
        {
            // ќпределите нормаль к поверхности, с которой столкнулс€ м€ч
            Vector3 platformNormal = collision.contacts[0].normal;

            // ќтразите скорость м€ча относительно нормали
            currentVelocity = Vector3.Reflect(currentVelocity, platformNormal);
        }
    }
}
