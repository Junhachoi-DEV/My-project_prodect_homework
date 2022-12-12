using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outliner : MonoBehaviour
{
    Material outline;

    Renderer renderers;
    List<Material> materialList = new List<Material>();

    void OnMouseEnter()
    {
        renderers = GetComponent<Renderer>();
        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outline);

        renderers.materials = materialList.ToArray();
    }
    void OnMouseExit()
    {
        renderers = GetComponent<Renderer>();
        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Remove(outline);

        renderers.materials = materialList.ToArray();
    }

    void Start()
    {
        outline = new Material(Shader.Find("Draw/OutlineShader"));
    }


    
}
