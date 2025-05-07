using System;
using UnityEngine;
using UnityEngine.Events;

public class Delegates : MonoBehaviour
{
    public delegate void DelegateExample();

    public DelegateExample MyDelegateVariable;
    
    public delegate void DelegateExampleTwo(int SomeInt);

    public DelegateExampleTwo MyDelegateVariableTwoc;

    public Action<int> SomeAction;

    public UnityEvent UnityEvent;

    private void Start()
    {
        MyDelegateVariable += DelegateOne;

        MyDelegateVariableTwoc += DelegateTwo;
        
        
        MyDelegateVariable?.Invoke();
        
        MyDelegateVariableTwoc?.Invoke(10);


        MyDelegateVariable += DelegateThree;
        MyDelegateVariable?.Invoke();

        MyDelegateVariable -= DelegateOne;
        
        MyDelegateVariable?.Invoke();

        SomeAction += DelegateTwo;
        SomeAction?.Invoke(5);

        UnityEvent.AddListener(DelegateOne);
        UnityEvent.AddListener(DelegateThree);
        
        UnityEvent?.Invoke();

    }

    private void DelegateOne()
    {
        Debug.Log("Delgate 1");
    }

    private void DelegateThree()
    {
        Debug.Log("Delgate 3");
    }

    private void DelegateTwo(int Value)
    {
        Debug.Log($"Delegate 2 With Value {Value}");
    }
    
    
    
    
    
    
    

}
