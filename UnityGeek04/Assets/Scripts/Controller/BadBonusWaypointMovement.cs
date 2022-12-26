using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBonusWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed; // �������� �����������

    private Transform[] _points;

    private int _currentPoint; // ������� �����

    
    void Start()
    {
        _points = new Transform[_path.childCount]; // �������� ������ ��� �������� ���� �����,
                                                   // ����� ����� ���� ��� ����� ���������. 
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }


    void Update()
    {
        Transform target = _points[_currentPoint]; // ������ ���� �� ����� ��������� target - ������� �������
                                                   // ����������� �������� �� ������� ������� �� ������� ���� (���� �� ����) ���� ������� �������
        var direction = (target.position - transform.position).normalized;
        // ��������� ����� ��� ������ MoveTowards � ����������� ��������
        // ������ �� ����     ���� ����      �������� �����������
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        // ���� ����� ������� ����� ��������� �������� ������� �� �������� �����������  _currentPoint �� �������

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
        // ������ ���� �� ���������, ����� �������� ����, �� ������������� �� ��������� �����
    }
}
