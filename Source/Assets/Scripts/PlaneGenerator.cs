using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))] //not really needed .. just a convenience
[RequireComponent(typeof(MeshFilter))]
public class PlaneGenerator : MonoBehaviour
{
	const int WIDTH = 4;
	const int HEIGHT = 3;
	
	private void Start () {
		
		MeshBuilder meshBuilder = new MeshBuilder();
		
		for (int j=0; j<=HEIGHT; j++)
		{
			for (int i=0; i<=WIDTH; i++)
			{
				float x = (i - (WIDTH / 2.0f));
				float y = -(j - (HEIGHT / 2.0f));
				float z = 0.0f;
				meshBuilder.AddVertex (new Vector3(x,  y, z), new Vector2(0, 0));
			}
		}

		for (int j=0; j<HEIGHT; j++)
		{
			for (int i=0; i<WIDTH; i++)
			{
				int index = j * (WIDTH+1) + i;
				meshBuilder.AddTriangle (index, index + 1, index + WIDTH + 2);
				meshBuilder.AddTriangle (index, index + WIDTH + 2, index + WIDTH + 1);
			}
		}
		
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = meshBuilder.CreateMesh ();
	}
}
