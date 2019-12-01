using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int number_of_plays;
    public int number_of_tries;

    public int size1;
    public int size2;
    public int size3;

    public List<int> stack1;
    public List<int> stack2;
    public List<int> stack3;
    public List<int> obj1;
    public List<int> obj2;
    public List<int> obj3;

    public TMPro.TextMeshProUGUI parabens;

    // Start is called before the first frame update
    void Start()
    {
        stack1 = new List<int>();
        stack2 = new List<int>();
        stack3 = new List<int>();

        obj1 = new List<int>();
        obj1.Add(1);
        size1 = 0;

        obj2 = new List<int>();
        obj2.Add(0);
        size2 = 0;

        obj3 = new List<int>();
        obj3.Add(2);
        size3 = 0;

        Debug.Log(obj1.Equals(obj2));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (object o in stack1)
        {
            print(o);
        }
        bool equal1 = CompareThen(stack1, obj1);
        bool equal2 = CompareThen(stack2, obj2);
        bool equal3 = CompareThen(stack3, obj3);
        if (equal1 && equal2 && equal3)
        {
            parabens.enabled = true;
        }
    }
    bool CompareThen(List<int> list1, List<int> list2)
    {
        for (int i = 0; i < list1.Count && i < list2.Count; i++)
        {
            if (!Object.Equals(list1[i], list2[i]))
                return false;
        }

        if (list1.Count > list2.Count)
            return false;

        if (list2.Count > list1.Count)
            return false;
        return true;
    }
}
    
    
    
