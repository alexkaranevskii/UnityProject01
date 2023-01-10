using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Geek
{
    public class ListExecuteObjectController: IEnumerable, IEnumerator, IDisposable
    {
        private int _index = -1;
        private IExecute[] _interactiveObject; // ������ �������� ���������� �������, ������� ��������� ��������� IExecute
        private List<IExecute> temp;  
        public int Length { get { return _interactiveObject.Length; } }

        public object Current => _interactiveObject[0];
     // public object Current => _interactiveObject[_index];

    
        public IExecute[] InteractiveObject 
        { 
            get => _interactiveObject; 
            set => _interactiveObject = value; 
        }

        // �����������
        
        public ListExecuteObjectController(Bonus[] bonuses)
        {
            for (int i = 0; i < bonuses.Length; i++)
            {
                if (bonuses[i] is IExecute intObject)
                {
                    AddExecuteObject(intObject);
                }
            }
        
        }
 
        // ����� ���������� ����������� �������� - �������
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
     

        // ��������� ���������� IEnumerable, IEnumerator
        /// 

        public bool MoveNext()
        {
            if(_index == Length -1)
            {
                return false;
            }
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // ��������� ��������� IDisposable
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
