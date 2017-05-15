using UnityEngine;
using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))] //not really needed .. just a convenience
[RequireComponent(typeof(MeshFilter))]
public class WindowGenerator : MonoBehaviour
{
	int v1;
	int v2;
	int v3;
	int v4;
	int v10;
	int v20;
	int v30;
	int v40;
	int v100;
	int v200;
	int v300;
	int v400;
	int v1000;
	int v2000;
	int v3000;
	int v4000;
	float widthA;
	float widthB;
	float height;

	public void MakeWindows(float _widthA, float _widthB, float _height) 
	{
		widthA = _widthA;
		widthB = _widthB;
		height = _height;

		MeshBuilder meshBuilder = new MeshBuilder();

		System.Random randd = new System.Random ();
		int windowCount = randd.Next (0, 5);

		switch(windowCount)
		{
		case 0:
			break;
		case 1: //make 1 window
			makeWindowA(meshBuilder);
		     break;
		case 2://make 2 window
			makeWindowA(meshBuilder);
			makeWindowB(meshBuilder);
			break;
		case 3://make 3 window
			makeWindowA(meshBuilder);
			makeWindowB(meshBuilder);
			makeWindowC(meshBuilder);
			break;
		case 4://make 4 window
			makeWindowA(meshBuilder);
			makeWindowB(meshBuilder);
			makeWindowC(meshBuilder);
			makeWindowD(meshBuilder);
			break;
		}
			
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = meshBuilder.CreateMesh ();
	}

	private void makeWindowA(MeshBuilder meshBuilder)
	{
		v1 = meshBuilder.AddVertex (new Vector3 (-0.01f, height / 3, ((widthB / 3) * 2)), new Vector2 (0, 0));
		v2 = meshBuilder.AddVertex (new Vector3 (-0.01f, height / 3, (widthB / 3)), new Vector2 (1, 0));
		v3 = meshBuilder.AddVertex (new Vector3 (-0.01f, height / 2, ((widthB / 3) * 2)), new Vector2 (0, 1));
		v4 = meshBuilder.AddVertex (new Vector3 (-0.01f, height / 2, (widthB / 3)), new Vector2 (1, 1));
		meshBuilder.AddTriangle (v2, v1, v3);
		meshBuilder.AddTriangle (v2, v3, v4);
	}
	private void makeWindowB(MeshBuilder meshBuilder)
	{
		v10 = meshBuilder.AddVertex (new Vector3 ((widthA / 3) * 2, height / 3, -0.01f), new Vector2 (0, 0));
		v20 = meshBuilder.AddVertex (new Vector3 (widthA / 3, height / 3, -0.01f), new Vector2 (1, 0));
		v30 = meshBuilder.AddVertex (new Vector3 ((widthA / 3) * 2, height / 2, -0.01f), new Vector2 (0, 1));
		v40 = meshBuilder.AddVertex (new Vector3 (widthA / 3, height / 2, -0.01f), new Vector2 (1, 1));
		meshBuilder.AddTriangle (v10, v20, v30);
		meshBuilder.AddTriangle (v30, v20, v40);
	}
	private void makeWindowC(MeshBuilder meshBuilder)
	{
		v100 = meshBuilder.AddVertex (new Vector3 ((widthA / 3) * 2, height / 3, widthB + 0.01f), new Vector2 (0, 0));
		v200 = meshBuilder.AddVertex (new Vector3 (widthA / 3, height / 3,  widthB + 0.01f), new Vector2 (1, 0));
		v300 = meshBuilder.AddVertex (new Vector3 ((widthA / 3) * 2, height / 2,  widthB + 0.01f), new Vector2 (0, 1));
		v400 = meshBuilder.AddVertex (new Vector3 (widthA / 3, height / 2,  widthB + 0.01f), new Vector2 (1, 1));
		meshBuilder.AddTriangle (v200, v100, v300);
		meshBuilder.AddTriangle (v200, v300, v400);
	}
	private void makeWindowD(MeshBuilder meshBuilder)
	{
		v1000 = meshBuilder.AddVertex (new Vector3 (widthA + 0.01f, height / 3, ((widthB / 3) * 2)), new Vector2 (0, 0));
		v2000 = meshBuilder.AddVertex (new Vector3 (widthA + 0.01f, height / 3, (widthB / 3)), new Vector2 (1, 0));
		v3000 = meshBuilder.AddVertex (new Vector3 (widthA + 0.01f, height / 2, ((widthB / 3) * 2)), new Vector2 (0, 1));
		v4000 = meshBuilder.AddVertex (new Vector3 (widthA + 0.01f, height / 2, (widthB / 3)), new Vector2 (1, 1));
		meshBuilder.AddTriangle (v1000, v2000, v3000);
		meshBuilder.AddTriangle (v3000, v2000, v4000);
	}
}
