using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class VillageGenerator : MonoBehaviour 
{
	public Slider trees;
	public Slider houses;

	public Text houseText;
	public Text treeText;

	private  int houseCount = 1;
	private  int treeCount = 1;

	GameObject[] housePositions;
	GameObject[] treePositions;

	System.Random rand = new System.Random();

	public void Generate () 
	{
		if (housePositions != null) {
			foreach (GameObject pos in housePositions) {
				if (pos != null) {
					Destroy (pos);
				}
			}
		}
		if (treePositions != null) {
			foreach (GameObject pos in treePositions) {
				if (pos != null) {
					Destroy (pos);
				}
			}
		}

		housePositions = new GameObject[houseCount];
		treePositions = new GameObject[treeCount];

		int HouseCounter = houseCount;
		int TreeCounter = treeCount;

		while((HouseCounter >0 || TreeCounter>0))
		{
			int ranndd = rand.Next (0, 10);
			if (!(ranndd == 1)|| TreeCounter == 0)
			{
				if (HouseCounter != 0) 
				{
					GameObject newHouse = GameObject.Instantiate (Resources.Load ("HouseBase"), new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
					newHouse.transform.Rotate (0, rand.Next (1, 360), 0);
					HouseGenerator houseBuilder = newHouse.GetComponent<HouseGenerator> ();
					houseBuilder.widthA = rand.Next (1, 5);
					houseBuilder.widthB = rand.Next (1, 5);
					houseBuilder.height = rand.Next (3, 7);
					houseBuilder._size = (float)Math.Sqrt ((houseBuilder.widthA * houseBuilder.widthA) + (houseBuilder.widthB * houseBuilder.widthB));

					houseBuilder.BuildAHouse ();
					housePositions [houseCount - HouseCounter] = newHouse;
					HouseCounter--;

					Vector3 direction = new Vector3 (rand.Next (-100, 100), 0, rand.Next (-100, 100)).normalized;

					while (IsOverlap (newHouse, true))
					{
						newHouse.transform.Translate (direction); // move til you find a free spot
					}

					newHouse.GetComponent<HouseGenerator>().AddWindowss();
				}
			} 
			if(ranndd == 1 || HouseCounter == 0 ) 
			{
				if (TreeCounter != 0)
				{
					GameObject tree = GameObject.Instantiate (Resources.Load ("Tree"), new Vector3(0,1.2f,0) , new Quaternion (0, 0, 0, 0)) as GameObject;
					treePositions [treeCount - TreeCounter] = tree;
					TreeCounter--;

					Vector3 direction = new Vector3 (rand.Next (-100, 100), 0, rand.Next (-100, 100)).normalized;
					direction *= 0.5f;
					while (IsOverlap (tree, false))
					{
						tree.transform.Translate (direction); // move til you find a free spot
					}
				}
			}

		}
	}

	private bool IsOverlap(GameObject reference, bool house) //returns true if object reference overlaps with other objects
	{
		bool overlaps = false;

		foreach (GameObject pos in housePositions)
		{
			if (pos != null && !pos.Equals (reference)) 
			{
				if (house)
				{
					if ((reference.transform.position - pos.transform.position).magnitude < pos.GetComponent<HouseGenerator> ()._size + reference.GetComponent<HouseGenerator> ()._size) 
					{ 
						overlaps = true;
					}
				} 
				else 
				{
					if ((reference.transform.position - pos.transform.position).magnitude < pos.GetComponent<HouseGenerator> ()._size + 2) 
					{ 
						overlaps = true;
					}
				}
			} 
		}
		foreach (GameObject pos in treePositions)
		{
			if (pos != null && !pos.Equals (reference)) 
			{
				if (house) 
				{
					if ((reference.transform.position - pos.transform.position).magnitude < 2 + reference.GetComponent<HouseGenerator> ()._size) 
					{ 
						overlaps = true;	
					}
				} 
				else
				{
					if ((reference.transform.position - pos.transform.position).magnitude < 2 + 2) 
					{ 
						overlaps = true;	
					}
				}
			} 
		}
		return  overlaps;
	}

	public void UpdateInputValues()
	{
		houseCount = (int)houses.value;
		treeCount = (int)trees.value;

		houseText.text = "Houses: " + houseCount;
		treeText.text = "Trees: " + treeCount;
	}
}
