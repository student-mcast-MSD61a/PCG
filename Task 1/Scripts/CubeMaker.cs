using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class CubeMaker : MonoBehaviour
{
    [SerializeField]
    private Vector3 size = Vector3.one;

    [SerializeField]
    private int meshSize = 6;

    private List<Material> materialsList;

    // Update is called once per frame
    void Update()
    {
        //1. initialise MeshFilter
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();

        //2. initialise MeshBuilder
        MeshBuilder meshBuilder = new MeshBuilder(meshSize);


        //4. build our cube

        //top vertices
        Vector3 t0 = new Vector3(size.x, size.y, -size.z); // top left point
        Vector3 t1 = new Vector3(-size.x, size.y, -size.z); // top right point
        Vector3 t2 = new Vector3(-size.x, size.y, size.z); //bottom right point of top square
        Vector3 t3 = new Vector3(size.x, size.y, size.z); // bottom left point of top square

        //bottom vertices
        Vector3 b0 = new Vector3(size.x, -size.y, -size.z); // bottom left point
        Vector3 b1 = new Vector3(-size.x, -size.y, -size.z); // bottom right point
        Vector3 b2 = new Vector3(-size.x, -size.y, size.z); //bottom right point of bottom square
        Vector3 b3 = new Vector3(size.x, -size.y, size.z); // bottom left point of bottom square


        //top square
        meshBuilder.BuildTriangle(t0, t1, t2, 0);
        meshBuilder.BuildTriangle(t0, t2, t3, 0);

        //bottom square
        meshBuilder.BuildTriangle(b2, b1, b0, 1);
        meshBuilder.BuildTriangle(b3, b2, b0, 1);


        //back square
        meshBuilder.BuildTriangle(b0, t1, t0, 2);
        meshBuilder.BuildTriangle(b0, b1, t1, 2);


        //left-side square
        meshBuilder.BuildTriangle(b1, t2, t1, 3);
        meshBuilder.BuildTriangle(b1, b2, t2, 3);


        //right-side square
        meshBuilder.BuildTriangle(b2, t3, t2, 4);
        meshBuilder.BuildTriangle(b2, b3, t3, 4);

        //front square
        meshBuilder.BuildTriangle(b3, t0, t3, 5);
        meshBuilder.BuildTriangle(b3, b0, t0, 5);


        //3. set mesh filter's mesh to the mesh generated from our mesh builder
        meshFilter.mesh = meshBuilder.CreateMesh();


        //5. Assign materials to the mesh renderer's materials list
        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        AddMaterials();
        meshRenderer.materials = materialsList.ToArray();
    }

    private void AddMaterials()
    {

        Material blackMaterial = new Material(Shader.Find("Specular"));
        blackMaterial.color = Color.black;

        Material blueMaterial = new Material(Shader.Find("Specular"));
        blueMaterial.color = Color.blue;

        Material greenMaterial = new Material(Shader.Find("Specular"));
        greenMaterial.color = Color.green;

        Material magentaMaterial = new Material(Shader.Find("Specular"));
        magentaMaterial.color = Color.magenta;

        Material yellowMaterial = new Material(Shader.Find("Specular"));
        yellowMaterial.color = Color.yellow;

        Material whiteMaterial = new Material(Shader.Find("Specular"));
        whiteMaterial.color = Color.white;

        materialsList = new List<Material>();
        materialsList.Add(whiteMaterial);
        materialsList.Add(blueMaterial);
        materialsList.Add(greenMaterial);
        materialsList.Add(magentaMaterial);
        materialsList.Add(yellowMaterial);
        materialsList.Add(blackMaterial);
    }
}
