using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outliner : MonoBehaviour
{
    Material outline;

    Renderer renderers;
    List<Material> materialList = new List<Material>();

    check_controller check;

    void Start()
    {
        outline = new Material(Shader.Find("Draw/OutlineShader"));
        check = FindObjectOfType<check_controller>();
        renderers = GetComponent<Renderer>();
    }
    private void Update()
    {
        check_eff();
    }
    private void check_eff()
    {
        if (check.check_effect_obj())
        {
            

            materialList.Clear();
            materialList.AddRange(renderers.sharedMaterials);
            materialList.Add(outline);

            renderers.materials = materialList.ToArray();
        }
        else
        {
            

            materialList.Clear();
            materialList.AddRange(renderers.sharedMaterials);
            materialList.Remove(outline);

            renderers.materials = materialList.ToArray();
        }
    }
}
