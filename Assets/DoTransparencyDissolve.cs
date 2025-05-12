using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTransparencyDissolve : MonoBehaviour
{
    MeshRenderer MeshRenderingComponent;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderingComponent = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float CutoffValue = Mathf.Sin(Time.time);

        CutoffValue = CutoffValue / 2;
        CutoffValue += 0.5f;

        MeshRenderingComponent.material.SetFloat("_TransparencyCutoff", CutoffValue);
    }


}
