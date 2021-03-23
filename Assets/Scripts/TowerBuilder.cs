using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _colors;
    public List<Block> Build()
    {
        var blocks = new List<Block>();
        Transform currentPoint = _buildPoint;

        for (var i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return blocks;
    }

    private Block BuildBlock(Transform buildPoint)
    {
        return Instantiate(_block, GetBuildPoint(buildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform point)
    {
        return new Vector3(_buildPoint.position.x, point.position.y + point.localScale.y / 2 + _block.transform.localScale.y / 2, _buildPoint.position.z);
    }
}
