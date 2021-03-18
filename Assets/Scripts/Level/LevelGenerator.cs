using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private Player _player;
    [SerializeField] private int _radius;
    [SerializeField] private int _cellSize;

    private HashSet<Vector3Int> _collisionsMatrix = new HashSet<Vector3Int>();

    private void FixedUpdate()
    {
        FillRadius(_player.transform.position);
    }

    private void FillRadius(Vector3 center)
    {
        var fillAreaCenter = WorldToGridPosition(center);

        for (int x= -_radius; x < _radius; x++)
        {
            TryCreateOnGridLayer(GridLayer.Ground, fillAreaCenter + new Vector3Int(x, 0, (int)center.z));
            TryCreateOnGridLayer(GridLayer.OnGround, fillAreaCenter + new Vector3Int(x, 0, (int)center.z));
        }
    }

    private void TryCreateOnGridLayer(GridLayer layer, Vector3Int gridPosition)
    {
        gridPosition.y = (int)layer;

        if (_collisionsMatrix.Contains(gridPosition))
            return;
        else
            _collisionsMatrix.Add(gridPosition);

        var template = GetRandomTemplate(layer);

        if (template == null)
            return;

        var position = GridToWorldPosition(gridPosition);

        Instantiate(template, position, Quaternion.identity, transform);
    }

    private GridObject GetRandomTemplate(GridLayer layer)
    {
        var variants = _templates.Where(template => template.Layer == layer);

        if (variants.Count() == 1)
            return variants.First();

        foreach (var template in variants)
        {
            if (template.SpawnChance > Random.Range(0, 100))
            {
                return template;
            }
        }

        return null;
    }

    private Vector3 GridToWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize,
            gridPosition.z * _cellSize);
    }

    private Vector3Int WorldToGridPosition(Vector3 worldPosition)
    {
        return new Vector3Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize),
            (int)(worldPosition.z / _cellSize));
    }
}