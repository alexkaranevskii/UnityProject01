using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBonusWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed; // скорость перемещения

    private Transform[] _points;

    private int _currentPoint; // текущая точка

    
    void Start()
    {
        _points = new Transform[_path.childCount]; // Создадим массив для хранения всех точек,
                                                   // далее через цикл все точки переберем. 
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }


    void Update()
    {
        Transform target = _points[_currentPoint]; // каждый кадр мы будем доставать target - текущая позиция
                                                   // направление движения мы находим вычитая из позиции цели (куда мы идем) нашу текущую позицию
        var direction = (target.position - transform.position).normalized;
        // двигаться будем при помощи MoveTowards и направления движения
        // откуда мы идем     куда идем      скорость перемещения
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        // если новая позиция стала равняться итоговой позиции мы начинаем увеличивать  _currentPoint на единицу

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
        // Каждый кадр мы двигаемся, когда достигли цели, мы переключаемся на слудующую точку
    }
}
