using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 stoppingVelocity;
    [Header("—корость м€ча:")]
    public Vector3 currentVelocity;
    [Header("—тартова€ позици€ м€ча:")]
    [SerializeField] Transform _startPos;

    public static event Action _hit;

    void Update()
    {       
        transform.Translate(currentVelocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MainCamera"))
        {          
            Vector3 platformNormal = collision.contacts[0].normal;          
            currentVelocity = Vector3.Reflect(currentVelocity, platformNormal);
            
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            Vector3 platformNormal = collision.contacts[0].normal;
            currentVelocity = Vector3.Reflect(currentVelocity, platformNormal);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        _hit?.Invoke();

        currentVelocity = stoppingVelocity;
        transform.SetParent(_startPos, false);
        transform.position = _startPos.transform.position + new Vector3(0,0,-2);
        transform.Rotate(0,180,0);

    }

}
