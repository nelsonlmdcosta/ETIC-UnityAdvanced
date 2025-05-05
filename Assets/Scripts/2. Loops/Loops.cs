using System.Collections.Generic;
using UnityEngine;


public class Loops : MonoBehaviour
{
    private List<int> ListOfInts = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    // We Use Loops To Iterate Multiple Times Over Similar Code
    // Simple Examples, but you can use variables and length of data structures to be able to handle all this dynamically
    public void Start()
    {
        ForLoopExample();
        ForEachLoopExample();
        
        WhileLoopExample();
        DoWhileLoopExample();
    }

    // You should be using for loops for the majority of examples, they are fast and direct accessors
    private void ForLoopExample()
    {
        for (int i = 0; i < ListOfInts.Count; ++i)
        {
            Debug.Log($"For Loop Example: { ListOfInts[i] }");
        }
    }
    
    // Foreaches are syntatic sugar which makes them easy to write but a newbie pitfall, which can generate garbage
    // and cause lag spikes in games, also they're slower than for loops for the most part.
    private void ForEachLoopExample()
    {
        foreach (var CurrentInt in ListOfInts)
        {
            Debug.Log($"Foreach Loop Example: { CurrentInt }");
        }
    }

    
    // This is a for loop specialized in a condition, so it'll keep iterating as long as the given condition is true
    // Worth noting it executes the condition first before the code in it's body
    private void WhileLoopExample()
    {
        int i = 0;
        while ( i++ < ListOfInts.Count )
        {
            Debug.Log($"While Example: { ListOfInts[i] }");
        }
    }

    // Same as above, but executes the body first then the 
    private void DoWhileLoopExample()
    {
        int i = 0;
        do
        {
            Debug.Log($"Do While Example: { ListOfInts[i] }");
        }
        while ( ++i < ListOfInts.Count ) ;

    }


}
