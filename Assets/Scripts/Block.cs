using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _point;

    public static event Action<int> _additionalPoint;

    public static event Action<GameObject> _deleteInList; 

    private void OnDestroy()
    {
        _deleteInList?.Invoke(gameObject);
        _additionalPoint?.Invoke(_point);
    }
}
