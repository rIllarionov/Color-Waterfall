using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private float _timePerSpawn;
    
    private List<GameObject> _cubes;//используем для хранения всех заспавненых кубов

    private void Awake()
    {
        _cubes = new List<GameObject>();
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 20; i > 0; i--)
        {
            for (int j = 0; j < 20; j++)
            {
                var spawnPossition = new Vector3(j, 0.4f, i);
                _cubes.Add(Instantiate(_prefab,spawnPossition, Quaternion.identity,_parent));
                yield return new WaitForSeconds(_timePerSpawn);
            }
        }
        
    }
    
    public List<GameObject> GetCubesArray()
    {
        return _cubes;
    }
}
