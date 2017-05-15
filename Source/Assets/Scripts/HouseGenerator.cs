using UnityEngine;
using System.Collections;
using System;
using UnityEngine;

/// <summary>
/// Quad generator.
/// Apply this to an empty gameobject and run the project.
/// It will generate a quad. You need to apply a material to the MeshRenderer yourself.
/// </summary>

[RequireComponent(typeof(MeshRenderer))] //not really needed .. just a convenience
[RequireComponent(typeof(MeshFilter))]
public class HouseGenerator : MonoBehaviour
{
	[SerializeField]
	public float height = 3;

	[SerializeField]
	public float widthA = 2;

	[SerializeField]
	public float widthB = 2;


	public float _size;
	Material houseMaterial;

	public void BuildAHouse() 
	{
		MeshBuilder meshBuilder = new MeshBuilder();
		System.Random randd = new System.Random ();
		int material = randd.Next (1, 4);

		switch (material)
		{
		case 1:
			houseMaterial = Resources.Load ("housematerial", typeof(Material)) as Material;
			break;
		case 2:
			houseMaterial = Resources.Load ("housematerial2", typeof(Material)) as Material;
			break;
		case 3:
			houseMaterial = Resources.Load ("housematerial3", typeof(Material)) as Material;
			break;
		}

	
		gameObject.GetComponent<Renderer>().material = houseMaterial;

		//Front
		int v0 = meshBuilder.AddVertex (new Vector3(0, (height/3)*2, 0), new Vector2( 1, 0.5f));        
		int v1 = meshBuilder.AddVertex (new Vector3(widthA, (height/3)*2, 0), new Vector2( 0, 0.5f));  
		int v2 = meshBuilder.AddVertex (new Vector3(widthA, 0 , 0), new Vector2( 0, 0)); 
		int v3 = meshBuilder.AddVertex (new Vector3(0, 0, 0), new Vector2(1, 0));  

		//Back
		int v4 = meshBuilder.AddVertex (new Vector3(0, (height/3)*2, widthB), new Vector2( 0, 0.5f));  
		int v5 = meshBuilder.AddVertex (new Vector3(widthA, (height/3)*2, widthB), new Vector2( 1, 0.5f)); 
		int v6 = meshBuilder.AddVertex (new Vector3(widthA, 0, widthB), new Vector2( 1, 0)); 
		int v7 = meshBuilder.AddVertex (new Vector3(0, 0, widthB), new Vector2( 0, 0));  

		//Right 
		int v8 = meshBuilder.AddVertex (new Vector3(widthA, (height/3)*2, 0), new Vector2( 0, 0.5f)); 
		int v9 = meshBuilder.AddVertex (new Vector3(widthA, 0, 0), new Vector2( 0, 0));  
		int v10 = meshBuilder.AddVertex (new Vector3(widthA, (height/3)*2, widthB), new Vector2( 1, 0.5f)); 
		int v11 = meshBuilder.AddVertex (new Vector3(widthA, 0, widthB), new Vector2( 1, 0));  

		//Left 
		int v12 = meshBuilder.AddVertex (new Vector3( 0, (height/3)*2, 0), new Vector2( 0, 0.5f)); 
		int v13 = meshBuilder.AddVertex (new Vector3( 0, 0 , 0), new Vector2( 0, 0));  
		int v14 = meshBuilder.AddVertex (new Vector3( 0, (height/3)*2, widthB), new Vector2( 1, 0.5f)); 
		int v15 = meshBuilder.AddVertex (new Vector3( 0, 0, widthB), new Vector2( 1, 0));  

		//Roof A
		int v16 = meshBuilder.AddVertex (new Vector3(widthA, (height/3)*2, 0), new Vector2( 0, 0.5f)); 
		int v17 = meshBuilder.AddVertex (new Vector3( 0,  (height/3)*2, 0), new Vector2( 1, 0.5f)); 
		int v18 = meshBuilder.AddVertex (new Vector3(widthA/2, height, widthB/2), new Vector2( 0.5f, 1f)); 

		//Roof B
		int v19 = meshBuilder.AddVertex (new Vector3( widthA, (height/3)*2, 0), new Vector2( 0, 0.5f)); 
		int v20 = meshBuilder.AddVertex (new Vector3( widthA,  (height/3)*2, widthB), new Vector2( 1, 0.5f)); 
		int v21 = meshBuilder.AddVertex (new Vector3(widthA/2, height, widthB/2), new Vector2( 0.5f, 1f)); 

		//Roof C
		int v22 = meshBuilder.AddVertex (new Vector3( 0, (height/3)*2, widthB), new Vector2( 0, 0.5f)); 
		int v23 = meshBuilder.AddVertex (new Vector3( widthA, (height/3)*2, widthB), new Vector2( 1, 0.5f)); 
		int v24 = meshBuilder.AddVertex (new Vector3(widthA/2, height, widthB/2), new Vector2( 0.5f, 1f)); 

		//Roof D
		int v25 = meshBuilder.AddVertex (new Vector3( 0, (height/3)*2, 0), new Vector2( 0, 0.5f)); 
		int v26 = meshBuilder.AddVertex (new Vector3( 0,  (height/3)*2, widthB), new Vector2( 1, 0.5f)); 
		int v27 = meshBuilder.AddVertex (new Vector3(widthA/2, height, widthB/2), new Vector2( 0.5f, 1f)); 

		//Front
		meshBuilder.AddTriangle (v0, v1, v3);
		meshBuilder.AddTriangle (v1, v2, v3);

		//Back
		meshBuilder.AddTriangle (v5, v4, v7);
		meshBuilder.AddTriangle (v6, v5, v7);

		//Right
		meshBuilder.AddTriangle (v9, v8, v10);
		meshBuilder.AddTriangle (v9, v10, v11);

		//Left
		meshBuilder.AddTriangle (v12, v13, v14);
		meshBuilder.AddTriangle (v14, v13, v15);

		//Roof
		meshBuilder.AddTriangle (v16, v17, v18);
		meshBuilder.AddTriangle (v19, v21, v20);
		meshBuilder.AddTriangle (v22, v23, v24);
		meshBuilder.AddTriangle (v24, v25, v26);

		MeshFilter meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = meshBuilder.CreateMesh ();


	}

	public void AddWindowss()
	{
		GameObject door = GameObject.Instantiate (Resources.Load ("WindowBase"), transform.position, transform.rotation) as GameObject;
		door.GetComponent<WindowGenerator> ().MakeWindows (widthA, widthB, height);
		door.transform.parent = gameObject.transform;
	}
}
