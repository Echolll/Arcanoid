using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _point;

    public static event Action<int> _additionalPoint;

    private void OnDestroy()
    {
        _additionalPoint?.Invoke(_point);
    }
}
