using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour 
{
	public float detectionRadius;
	string currentColor = null;
	public LayerMask layer;
	public Sprite purpleSprite, greenSprite, orangeSprite, yellowSprite, blueSprite, redSprite;
	Inventory playerInventory; 
	void Start()
	{
		playerInventory = transform.GetComponent<Inventory>();
	}
	// Use this for initialization
	void Update()
	{
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
				Destroy(found.gameObject);
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
		if (Input.GetKeyDown(KeyCode.R))
		{
			applyPaint();
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
		bool Red = false, Blue = false, Yellow = false;
		List<Bucket> currentPaint = transform.GetComponent<Inventory>().getBucketList();
		for (int i = 0; i < currentPaint.Count; i++)
		{
			if (currentPaint[i].color == "Red")
			{
				Red = true;
			}
			if (currentPaint[i].color == "Blue")
			{
				Blue = true;
				print("Beep");
			}
			if (currentPaint[i].color == "Yellow")
			{
				Yellow = true;
			}
			print(currentPaint[i].color);
		}
		print(Blue);
		if(currentColor == null)
		{
			if (Red)
			{
				if (Red & Yellow)
				{
					transform.GetComponent<SpriteRenderer>().sprite = orangeSprite;
				}
				else if (Red & Blue)
				{
					transform.GetComponent<SpriteRenderer>().sprite = purpleSprite;
				}
				else
					transform.GetComponent<SpriteRenderer>().sprite = redSprite;
			}
			else if (Yellow)
			{
				if (Yellow & Blue)
				{
					transform.GetComponent<SpriteRenderer>().sprite = greenSprite;
				}
				else
					transform.GetComponent<SpriteRenderer>().sprite = yellowSprite;
			}
			else if (Blue)
			{
				transform.GetComponent<SpriteRenderer>().sprite = blueSprite;
			}
			else
				print("Fuck");
		}

	}
	void clearPaint()
	{

	}
}
