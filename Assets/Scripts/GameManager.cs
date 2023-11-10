using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("��� ����:")]
    [Tooltip("����� ����:")][SerializeField] private SelectGame _selectGame;

    [Header("�����:")]
    [Tooltip("������ ������:")][SerializeField] List<GameObject> _blockList;

    [Header("���������")]
    [Tooltip("������ ����������:")][SerializeField] List<Material> _materialList;

    [Header("���� ��� ��������� �����:")]
    [Tooltip("������ ����:")][SerializeField] Vector3 _fieldSize;
    [Tooltip("��������� �������:")][SerializeField] Vector3 _startPostion;
    [Tooltip("��������� ������� �������")][SerializeField] Vector2 _randomRotate;

    [Tooltip("������ �� �����:")][SerializeField] GameObject _gameObject;
    
    private int _currectPoint;

    private void Start()
    {
        GenerateBlock();
        GameType(_selectGame);
    }

    private void OnEnable()
    {
        Block._deleteInList += OnDeleteObject;
        Players._gameOver += GameEnded;
        Block._additionalPoint += AddPoint;
    }

    private void OnDisable()
    {
        Block._deleteInList -= OnDeleteObject;
        Players._gameOver -= GameEnded;
        Block._additionalPoint -= AddPoint;
    }

    private void GameType(SelectGame mode)
    {
        if(mode == SelectGame.Coop)
        {
            _gameObject.SetActive(false);
        }
        else
        {
            _gameObject.SetActive(true);
        }
    }

    private void ChangeColor()
    {
        for (int i = 0; i < _blockList.Count; i++)
        {
            GameObject obj = _blockList[i];
            int randomNumber = UnityEngine.Random.Range(0, _materialList.Count);
            obj.gameObject.GetComponent<MeshRenderer>().material = _materialList[randomNumber];
            obj.name = $"Block {i}";
        }
    }

    [ContextMenu("GenerateBlock")]
    public void GenerateBlock()
    {
        var gameObjectBlock = Resources.Load<GameObject>("Prefabs/Block");
        var parentObject = GameObject.Find("Wall");

        for (int z = 0; z < _fieldSize.z + 1; z++)
        {
            for (int x = 0; x < _fieldSize.x + 1; x++)
            {
                for (int y = 0; y < _fieldSize.x + 1; y++)
                {
                    float rotateX = UnityEngine.Random.Range(0, _randomRotate.x);
                    float rotateY = UnityEngine.Random.Range(0, _randomRotate.y);
                    var block = Instantiate(gameObjectBlock, _startPostion + new Vector3(x, y , z), Quaternion.Euler(rotateX, rotateY, 0));
                    block.transform.parent = parentObject.transform;
                    _blockList.Add(block);                  
                }
            }
        }
        
        ChangeColor();
    }

    private void AddPoint(int point)
    {
        _currectPoint += point;
    }

    private void OnDeleteObject(GameObject obj)
    {
        if(_blockList.Contains(obj))
        {
            _blockList.Remove(obj);
            if( _blockList.Count == 0 )
            {
                GameEnded("���� ���������! �� ��������!");
            }
        }
    }

    private void GameEnded(string message)
    {       
        Debug.Log(message);
        Debug.Log($"{_currectPoint} ����� ��������!");
        EditorApplication.isPlaying = false;
    }
}
