using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] private GridLayer _layer;
    [SerializeField] private int _spawnChance;

    public int SpawnChance => _spawnChance;

    public GridLayer Layer => _layer;
}
