using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Players : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int _health => _maxHealth;

    protected PlayersControl _input;

    private void Awake()
    {
        _input = new PlayersControl();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public abstract void OnMove();
}
