using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private RecoloringController _recoloringController;//ссылка на перекрашиватель
    public UnityEvent AllCubeSpawned;//событие 
    
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private float _timePerSpawn;
    
    private void Awake()
    {
        AllCubeSpawned.AddListener(_recoloringController.GetRecoloringObjects);//подписываемся на метод по сбору детишек
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
                Instantiate(_prefab,spawnPossition, Quaternion.identity,_parent);
                yield return new WaitForSeconds(_timePerSpawn);
            }
        }
        AllCubeSpawned.Invoke();//когда все кубы заспавнились вызываем метод.
    }
    
}
