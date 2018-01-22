using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour 
{
	public float detectionRadius;
	public LayerMask layer;

	Inventory playerInventory; 
	void Start()
	{
		playerInventory = transform.GetComponent<Inventory>();
	}
	// Use this for initialization
	void Update(){
		Collider2D found = Physics2D.OverlapCircle(transform.position, detectionRadius, layer);
		if (found)
		{
			if(found.CompareTag("Bucket"))
			{
				Bucket foundBucket = found.GetComponentInParent<Bucket>();
				if (foundBucket != null)
				{
					print("This exists, and is the color: " + foundBucket.color);
				}
				playerInventory.addBucketToInventory(foundBucket);
				Destroy(found.gameObject);
			}
			else if(found.CompareTag("Well"))
			{
				//Enable button to clean yourself off
				clearPaint();
			}
			else if(found.CompareTag("Key"))
			{
				playerInventory.addKeyToInventory();
				//Remove key
			}
			else if(found.CompareTag("Exit"))
			{
				if(playerInventory.getKeys() == 3)
				{
					print("YOU WIN YOU FUCK");
					//Load Scene of win screen
				}
			}
		}
		//if(Input.GetKeyDown(key: "G"))
		//{
			//Pick-up items

			//Send out raycast, nearest item to the player is the one interacted with

			//if(item == Key)
				//pickup and add to inventory
			//if(item == bucket)
				//pickup and add to visible inventory
			//if(item == well)
				//remove all current coats of paint
		//}
		//if(Input.GetKeyDown(key: "E"))
		//{
			//Player applies coat of paint
			//Display progress bar that updates
			//Upon update completion, do the following
			//Check if previous coat of paint was present
				//If yes, apply mix between two colors
				//If no, apply color
		//}
	}

	void applyPaint()
	{

	}
	void clearPaint()
	{

	}
}
