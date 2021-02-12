using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class PyramidMaker : MonoBehaviour
{
    [SerializeField]
    private float pyramidSize = 5f;

    private int subMeshSize = 4;

    // Update is called once per frame
    void Update()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();

        MeshBuilder meshBuilder = new MeshBuilder(subMeshSize);

        //Add Points
        Vector3 top = new Vector3(0, pyramidSize, 0);

        Vector3 base0 = Quaternion.AngleAxis(0f, Vector3.up) * Vector3.forward * pyramidSize;

        Vector3 base1 = Quaternion.AngleAxis(240f, Vector3.up) * Vector3.forward * pyramidSize;

        Vector3 base2 = Quaternion.AngleAxis(120f, Vector3.up) * Vector3.forward * pyramidSize;


        //Build the triangles for our pyramid
        meshBuilder.BuildTriangle(base0, base1, base2, 0);

        meshBuilder.BuildTriangle(base1, base0, top, 1);

        meshBuilder.BuildTriangle(base2, top, base0, 2);

        meshBuilder.BuildTriangle(top, base2, base1, 3);

        meshFilter.mesh = meshBuilder.CreateMesh();

        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.materials = MaterialsList().ToArray();
    }

    private List<Material> MaterialsList()
    {
        List<Material> materialsList = new List<Material>();

        Material redMaterial = new Material(Shader.Find("Specular"));
        redMaterial.color = Color.red;

        Material greenMaterial = new Material(Shader.Find("Specular"));
        greenMaterial.color = Color.green;

        Material blueMaterial = new Material(Shader.Find("Specular"));
        blueMaterial.color = Color.blue;

        Material yellowMaterial = new Material(Shader.Find("Specular"));
        yellowMaterial.color = Color.yellow;

        materialsList.Add(redMaterial);
        materialsList.Add(greenMaterial);
        materialsList.Add(blueMaterial);
        materialsList.Add(yellowMaterial);

        return materialsList;
    }
}
