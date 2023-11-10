using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 stoppingVelocity;
    [Header("—корость м€ча:")]
    public Vector3 currentVelocity;
    public float  _currectSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _additionalSpeed;
    [Header("—тартова€ позици€ м€ча:")]
    [SerializeField] Transform _startPos;

    public static event Action _hit;

    void Update()
    {       
        transform.Translate(currentVelocity * Time.deltaTime * _currectSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {             
            Vector3 platformNormal = collision.contacts[0].normal;          
            currentVelocity = Vector3.Reflect(currentVelocity, platformNormal);
            
            if (collision.gameObject.CompareTag("Block"))
            {
                Destroy(collision.gameObject);
                _currectSpeed += _additionalSpeed;
                _currectSpeed = Mathf.Clamp(_currectSpeed, 0, _maxSpeed);
            }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            _hit?.Invoke();
            currentVelocity = stoppingVelocity;
            transform.SetParent(_startPos, false);
            transform.position = _startPos.transform.position + new Vector3(0, 0, -2);
            transform.Rotate(0, 180, 0);
        }
    }

}
