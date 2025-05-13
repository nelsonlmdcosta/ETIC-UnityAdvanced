using UnityEngine;

public class ChangeBallColor : MonoBehaviour
{
    public void ChangeColor(Color ColorToChangeTo)
    {
        GetComponent<MeshRenderer>().material.SetColor("_BaseColor", ColorToChangeTo);
    }
}
