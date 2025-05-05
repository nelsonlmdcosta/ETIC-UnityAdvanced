using System;
using System.Text;
using UnityEngine;

// Just add this to a gameobjec to see what variables are visible and which arent
// Note: Visit 4. OOP folder to see why the usage of privates and publics
public class Variables : MonoBehaviour
{
    // Variables
    // Basic Types
    
    // Integers hold whole numbers
    private int BasicIntergerType = 1;
    
    // Floats hold decimal numbers in general
    private float BasicFloatingPointType = 0.0f;
    
    // Strings Hold Letters
    private string BasicStringType = "Hello World! :D";
    
    // ComplexTypes
    // We can hold onto more complex objects that we create!
    private Vector3 ComplexTypeReference = Vector3.zero;

    // Even Components!
    private Animator AniamtorComponentReference = null;
    
    // -----------------------------------------------------------------------------------------------------------------
    // This is all great and all but this needs to be tweakable numbers in the editor!
    // -----------------------------------------------------------------------------------------------------------------
    
    // We could use public but it's really bad practice and cause you a lot of headaches down the line, so instead we use a SerializeField Attribute
    // This is a nono
    public int ExposedType;
    // Use this instead please, Serialization is a funny word that means how and what you save/load into the program at runtime
    [SerializeField] private int BetterExposedType;
    
    // That said if you need to access the variable you can just use a "PropertyAccessor" these are OK to be public as the variable is hidden
    // Really useful for things such as the Singletons too!
    public int IntegerPropertyAccessor
    {
        get { return BetterExposedType; }
        set { BetterExposedType = value; }
    }

    // That said if it's a simpel accessor as the above, then we can just simplify the variable and property accessor declaration and fit it all in one!
    // When we tag it with the "SerializeField" we just need to add an extra bit at the begining to tel it to serialize the hidden variable
    [field: SerializeField] public int EvenBetterPropertyAccessor { get; set; }

    // Notes: With string we avoid the + as it creates a lot of reallocated memory everytime you add the + between strings, so we use 
    // string interpolation to avoid this
    private void Start()
    {
        string Hello = "Hello";
        string World = " World!";
        string SmilieFace = " :D";
        
        // We can add strings together to put them together
        // Though this is nasty
        BasicStringType = Hello + World + SmilieFace;

        // This is far better to use when possible
        BasicStringType = $"{Hello}{World}{SmilieFace}";
        
        // To do it properly we can also use the StringBuilder This is always better than the + concatenation
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(Hello);
        stringBuilder.Append(World);
        stringBuilder.Append(SmilieFace);
        string FinalString = stringBuilder.ToString();
    }
}
