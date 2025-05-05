using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test
{
    /*
    public Test(Example obj)
    {
        obj.Age += 1;

        obj.PropertyAccessorExampleForAge += 1.0f;

        var test = obj.PropertyAccessorExampleForAgeV1;
        obj.PropertyAccessorExampleForAgeV1 = 1.0f;

        //Debug.Log(obj.ExampleString);
    }
    */
}

/*
public class DerivedExample : Example
{
    DerivedExample()
    {
        //AgeF += 0.0f;
        
        Debug.Log(ExampleString);
    }
}
*/

public class OOP : MonoBehaviour
{
    // Variables
    // Basic Types
    private int BasicIntergerType;
    
    // I Will Kill You
    public int Age;

    [SerializeField] private float AgeF = 10.0f;

    
    [field: SerializeField] public float PropertyAccessorExampleForAgeV1 { get; set; }
    
    public float PropertyAccessorExampleForAge
    {
        get { return AgeF; }
        set { AgeF = value; }
    }

    protected string ExampleString;

    private List<int> Numbers = new List<int>(100);
    private IEnumerator Start()
    {
        for (int i = 0; i < Numbers.Count; ++i)
        {
            Numbers[i] = i;
        }

        IncrementingExample();

        Debug.LogError("Part 1");
        yield return new WaitForSeconds(3.0f);
        Debug.LogError("Part 2");
        
    }

    private void Update()
    {
        //ForLoopExample();
        //ForeachLoopExample();
    }

    private void IncrementingExample()
    {
        int someInteger = 0;

        Debug.Log(someInteger);     // 0
        Debug.Log(++someInteger);   // 1
        Debug.Log(someInteger++);   // 1
        Debug.Log(someInteger);     // 2
        
        //Debug.Log(++someInteger);   // 1

        // Debug.Log(++someInteger);
        //someInteger += 1;
        //Debug.Log(someInteger);     // 2
        
        // Debug.Log(someInteger++);
        //D/ebug.Log(someInteger);     // 2
        //someInteger += 1;

    }

    private void ForLoopExample()
    {
       
        for (int i = 0; i < Numbers.Count; ++i)
        {
            Numbers[i] += 1;
        }
    }
    
    private void ForeachLoopExample()
    {
        foreach (int CurrentNumber in Numbers)
        {
            //CurrentNumber += 1;
        }
    }
    
    private Test ProcessData()
    {
        // Reference Counting
        return null;//new Test(this);
    }
}
