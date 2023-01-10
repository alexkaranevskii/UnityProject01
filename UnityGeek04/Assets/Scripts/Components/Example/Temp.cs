using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Temp : MonoBehaviour
{
    struct User
    {
        public string name;
        public int health;
        public int id;
    }

    public delegate int TestDelegate(int value1, int value2);

    public TestDelegate summ;
    public TestDelegate sub;
    public TestDelegate div;
    public TestDelegate mult;

    static int SomeMethod1(int a, int b)
    {
        Debug.Log("summ: " + (a + b));
        return a + b;
    }

    static int SomeMethod2(int a, int b)
    {
        Debug.Log("substract: " + (a - b));
        return a - b;
    }

    static int SomeMethod3(int a, int b)
    {
        Debug.Log("divide: " + (a / b));
        return a / b;
    }

    static int SomeMethod4(int a, int b)
    {
        Debug.Log("multiply: " + (a * b));
        return a * b;
    }


    void Start()
    {
        User user = new User();
        user.name = "Test";
        user.health = 100;
        Debug.Log(user.name);

        summ = SomeMethod1;
        sub = SomeMethod2;
        div = SomeMethod3;
        mult = SomeMethod4;

        div += SomeMethod1;
        div += SomeMethod2;
        div += SomeMethod3;
        div += SomeMethod4;
        div -= SomeMethod3;

      //  ArrayList tempArrayList = new ArrayList() { 12, 12, "ýé!" };
      //  tempArrayList.Add("test string");
      //  tempArrayList.Add(47);
     //   tempArrayList.Add('F');
     //   tempArrayList.Clear();

     //   List<int> 

    }

 
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            int temp = div.Invoke(100, 50);
            Debug.Log(temp);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            int temp = div.Invoke(1100, 250);
            Debug.Log(temp);
        }

    }
}
