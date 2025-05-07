using System;
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

public abstract class AAnimal
{
    public abstract void AbstractMakeNoise();

    public virtual void VirtualMakeNoise()
    {
        Debug.Log("VirtualMakeNoise Not Overriden");
    }
}

public class Cat : AAnimal
{
    public override void AbstractMakeNoise()
    {
        throw new NotImplementedException();
    }

    public override void VirtualMakeNoise()
    {
        Debug.Log("Meow");
    }
}

public class Dog : AAnimal
{
    public override void AbstractMakeNoise()
    {
        throw new NotImplementedException();
    }

    public override void VirtualMakeNoise()
    {
        Debug.Log("Woof");
    }
}

public class Bird : AAnimal
{
    public override void AbstractMakeNoise()
    {
        throw new NotImplementedException();
    }

    public override void VirtualMakeNoise()
    {
        base.VirtualMakeNoise();
        
        Debug.Log("Chirp");
    }
}


public class OOP : MonoBehaviour
{
    private List<Cat> CatList;
    private List<Dog> DogList;
    private List<Bird> BirdList;

    private List<AAnimal> AnimalList;

    private List<MonoBehaviour> Components;
    
    private void Start()
    {
        Cat catExample = new Cat();
        Dog dogExample = new Dog();
        Bird birdExample = new Bird();
        
        catExample.VirtualMakeNoise();
        dogExample.VirtualMakeNoise();
        birdExample.VirtualMakeNoise();
        
        //AnimalList.Add(catExample);
        //AnimalList.Add(dogExample);
        //AnimalList.Add(birdExample);
        
        //CatList.Add(catExample);
        //CatList.Add(dogExample);
        
        //Components.Add(new Variables());
        //Components.Add(new OOP());
        
        //Components.Add(new Cat());

        StartCoroutine(WaitingExample());
    }

    private IEnumerator WaitingExample()
    {
        Debug.Log("Started Coroutine A");
        
        yield return new WaitForSeconds(1.0f);

        Debug.Log("Started Coroutine B");

        yield return StartCoroutine(WaitOnSecondCoroutine());

        Debug.Log("Ended Coroutine B");
        
        Debug.Log("Ended Coroutine A");

    }

    private IEnumerator WaitOnSecondCoroutine()
    {
        // TIme Dilation
        Time.timeScale *= 2;

        Debug.Log("Coroutine B - Waiting");

        // Affected by time dialtion
        yield return new WaitForSeconds(1);

        Debug.Log("Coroutine B - Waiting");

        // Unnafected by time dilation
        yield return new WaitForSecondsRealtime(1);

        yield return new WaitUntil(new Func<bool>(WaitForCondition));
    }

    /*
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        
        // Add Initialization Code Here
    }
    */

    private bool WaitForCondition()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}

