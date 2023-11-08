using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{  
    [SerializeField] private SelectGame _selectGame;

    [SerializeField] List<GameObject> _blockList;
    [SerializeField] List<Material> _materialList;
    [SerializeField] Vector3 _fieldSize;
    [SerializeField] Vector3 _startPostion;

    private void Start()
    {
        GenerateBlock();
    }

    private void ChangeColor()
    {
        for (int i = 0; i < _blockList.Count; i++)
        {
            GameObject obj = _blockList[i];
            int randomNumber = Random.Range(0, _materialList.Count);
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
                    var block = Instantiate(gameObjectBlock, _startPostion + new Vector3(x, y, z), Quaternion.identity);
                    block.transform.parent = parentObject.transform;
                    _blockList.Add(block);                  
                }
            }
        }
        
        ChangeColor();
    }

    private void GameEnded()
    {

    }
}
