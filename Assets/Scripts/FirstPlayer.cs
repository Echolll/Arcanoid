using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FirstPlayer : Players
{
    private void Update() => OnMove();

    public override void OnMove()
    {
            float _speed = 5f;

            var inputMoveDirection = _input.Moving.FirstPlayer.ReadValue<Vector3>();
            float AxisX = inputMoveDirection.x * _speed * Time.deltaTime;
            float AxisY = inputMoveDirection.y * _speed * Time.deltaTime;

            var moveDirection = new Vector3(AxisX, AxisY, 0);
            transform.Translate(moveDirection);     
    }
}
