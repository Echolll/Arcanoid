using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FirstPlayer : Players
{
    [Header("—тартова€ скорость м€ча:")]
    [SerializeField,Range(1,5)] private float _startingBallSpeed;
    [Header("—сылка на м€чь:")]
    [SerializeField] private GameObject _ball;

    
    private void OnEnable()
    {
        _input.Enable();
        _input.Moving.StartGame.performed += callBackContext => OnGameStart();
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Moving.StartGame.performed -= callBackContext => OnGameStart();
    }
   
    private void Update() => OnMove();

    public override void OnMove()
    {           
            var inputMoveDirection = _input.Moving.FirstPlayer.ReadValue<Vector3>();
            float AxisX = inputMoveDirection.x * _speed * Time.deltaTime;
            float AxisY = inputMoveDirection.y * _speed * Time.deltaTime;

            var moveDirection = new Vector3(AxisX, AxisY, 0);
            transform.Translate(moveDirection);     
    }

    private void OnGameStart()
    {
        var obj = _ball.GetComponent<BallController>();
        transform.GetChild(0).SetParent(null);
        obj.currentVelocity.z += -_startingBallSpeed;
    }
}
