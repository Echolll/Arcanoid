using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayer : Players
{  
    private void Update() => OnMove();

    public override void OnMove()
    {
        float _speed = 5f;
        var inputMoveDirection = _input.Moving.SecondPlayer.ReadValue<Vector3>();

        float AxisX = inputMoveDirection.x * _speed * Time.deltaTime;
        float AxisY = inputMoveDirection.y * _speed * Time.deltaTime;

        var moveDirection = new Vector3(AxisX, AxisY, 0);
        transform.Translate(moveDirection);
    }
}

