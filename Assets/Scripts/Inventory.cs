using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	int keys;
	List<Bucket> currentBuckets;
	// Use this for initialization
	void Start () 
	{
		keys = 0;
		currentBuckets = new List<Bucket>();
	}
	// Update is called once per frame
	void Update () {
		
	}
	public int getKeys()
	{
		return keys;
	}
	public void addKeyToInventory()
	{
		keys++;
	}
	public void addBucketToInventory(Bucket newBucket)
	{
		currentBuckets.Add(newBucket);
		print("Added: " + newBucket.color);
	}

	public List<Bucket> getBucketList()
	{
		return currentBuckets;
	}
}
