using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Geek
{
    public class ListExecuteObjectController
    {
        private IExecute[] _interactiveObject; // ������ �������� ���������� �������, ������� ��������� ��������� IExecute
        public int Length { get { return _interactiveObject.Length; } }   
        public IExecute[] InteractiveObject { get => _interactiveObject; set => _interactiveObject = value; }

       

        // �����������
        public ListExecuteObjectController()
        {

        }

        // ����� ���������� ����������� ��������
        public void AddExecuteObject(IExecute execute)
        {
            if(InteractiveObject == null)
            {
                InteractiveObject = new[] {execute };
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);
            InteractiveObject[Length - 1] = execute;
        }
    }
}
