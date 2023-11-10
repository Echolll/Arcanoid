using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Players : MonoBehaviour
{
    private int _maxHealth = 5;
    private int _damage = 1;
    [Header("Скорость платформы:")]
    [SerializeField,Range(5,15)] protected float _speed = 5f;
    
    protected PlayersControl _input;

    public static event Action <string> _gameOver;

    private void Awake()
    {
        Debug.Log(_maxHealth);
        _input = new PlayersControl();
        Debug.Log("Движение : WASD , Начать игру: Space");
    }

    private void OnEnable()
    {
        BallController._hit += OnHit;
        _input.Enable();
    }

    private void OnDisable()
    {
        BallController._hit -= OnHit;
        _input.Disable();
    }

    private void OnHit()
    {
        if(_maxHealth < 0)
        {
            _gameOver?.Invoke("Вы проиграли!");
        }

        _maxHealth -= _damage;
        Debug.Log($"Осталось мячей {_maxHealth}");
    }

    public abstract void OnMove();
}
