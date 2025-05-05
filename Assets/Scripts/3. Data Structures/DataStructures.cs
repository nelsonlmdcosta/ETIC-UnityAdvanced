using UnityEngine;
using System.Collections.Generic;

// Data structures are very useful to hold data of any type in them in a nice long sequence to access really easily
public class DataStructures : MonoBehaviour
{
    // Most basic type, it's a static block of memory that doesn't grow and can store any type into it, can be serialized easily by unity
    [SerializeField] private int[] ArrayExample = null;

    // Same as before, but it's dynamically sized! So it'll make space for new elements, but can be more expensive to use.
    [SerializeField] private List<int> ListExample = null;

    // Cannot be serialized by default but it allows for easy control of data, first element in is the first element out of it, like a real life queue for your favorite coffee :p
    [SerializeField] private Queue<int> QueueExample = null;

    // Cannot be serialized by default but it allows you to easily control data, where the first element is the last out, like the dogpile you suffered from your cousins back in the day :p 
    [SerializeField] private Stack<int> StackExample = null;

    // Cannot be serialized by default either but it allows you to have a <Key, Value> sort of data structure, which you can hold an ID and save a value associated to it
    // Imagine <string, bool> where it could be <"HasPlayedCutscene", true> 
    [SerializeField] private Dictionary<int, int> DictionaryExample = null;
}
