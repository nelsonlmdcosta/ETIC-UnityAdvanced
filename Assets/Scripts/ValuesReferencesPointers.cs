using UnityEngine;

public class WrappedInt
{
    public int SomeIntegerWrappedInObject;
}


public class ValuesReferencesPointers : MonoBehaviour
{
    private void Update()
    {
        int SomeInteger = 0;
        WrappedInt wrappedInt = new WrappedInt();
        
        Debug.Log(SomeInteger);

        PassByValueExample(ref SomeInteger);
            
        Debug.Log(SomeInteger);
        
        
        
        
        
        Debug.Log("///////////////////////////");

        
        
        
        
        
        Debug.Log(wrappedInt.SomeIntegerWrappedInObject);

        PassByReferenceExample(wrappedInt);
            
        Debug.Log(wrappedInt.SomeIntegerWrappedInObject);

        
    }

    public void PassByValueExample( ref int Integer ) 
    {

        Integer += 1;

    }

//   public void PassByValueExample( out int Integer )
//   {
//       
//       Integer += 1;

//   }
    
    public void PassByReferenceExample(WrappedInt Integer)
    {
        Integer.SomeIntegerWrappedInObject += 1;
    }
}
