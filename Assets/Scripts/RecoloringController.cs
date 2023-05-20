
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringController : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private float _timePerNextCubeRecoloring;
    
    private Recoloring [] _cubes; //массив всех объектов умеющих перекрашиваться у родителя
    public void StartRecoloring()
    {
        if (_cubes!=null)
        {
            StartCoroutine(StartER());//запускаем корутину
        }
    }
    
    public void GetRecoloringObjects()
    {
        _cubes = _parent.GetComponentsInChildren<Recoloring>();//нашли и записали в массив
    }

    public IEnumerator StartER()
    {
        var nextColor = GenerateNextColor(); //сгенерировали цвет для всех объектов
        
        for (int i = 0; i < _cubes.Length-1; i++) //идем по длинне всего массива
        {
            _cubes[i].StartChangingColor(nextColor);//запускаем у каждого объекта метод и передаем ему наш цвет
            yield return new WaitForSeconds(_timePerNextCubeRecoloring);
        }
    }
    
    private Color GenerateNextColor()
    {
        return Random.ColorHSV(0f, 1f, 0.8f, 1f, 0f, 1f);
    }
    
}
