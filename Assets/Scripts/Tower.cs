using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public UnityAction<int> sizeChanged;
 
    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();
        foreach(var block in _blocks)
        {
            block.HitBullet += OnBlockHit;
        }
        sizeChanged?.Invoke(_blocks.Count);
    }

    private void OnBlockHit(Block hitBlock)
    {
        _blocks.Remove(hitBlock);
        sizeChanged?.Invoke(_blocks.Count);
        if(_blocks.Count == 0)
        {
            DisplayWinMesage();
        }
        foreach(var block in _blocks)
        {
            var hitBlockTransform = hitBlock.transform;
            var hitBlockPosition = hitBlockTransform.position;
            var hitBlockScale = hitBlockTransform.localScale;
            block.transform.position = new Vector3(hitBlockPosition.x, block.transform.position.y - hitBlockScale.y, hitBlockPosition.z);
        }
    }

    private void DisplayWinMesage()
    {
        Debug.Log("You won");
    }
}
