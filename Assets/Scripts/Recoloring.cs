
using System.Collections;
using UnityEngine;


public class Recoloring : MonoBehaviour
{
    [SerializeField] private float _recoloringTime;
    private Renderer _renderer;
    private Color _startColor;
    private Color _nextColor;
    private float _recoloringTimer;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    
    private IEnumerator ChangeColor()
    {
        _recoloringTimer = 0;//обнуляем таймер
        
        while (_recoloringTimer<_recoloringTime) // пока таймер не стал равен заданному времени
        {
            _recoloringTimer += Time.deltaTime; //накапливаем время

            var progress = _recoloringTimer / _recoloringTime;
            var currentColor = Color.Lerp(_startColor, _nextColor, progress);
            _renderer.material.color = currentColor;

            yield return null;//сдвинули цвет и ждем следующий кадр
        }
    }
    public void StartChangingColor(Color nextColor)
    {
        _startColor = _renderer.material.color;
        _nextColor = nextColor;
        StartCoroutine(ChangeColor());
    }
}
