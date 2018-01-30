using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour 
{
	public float detectionRadius;
	[HideInInspector]
	public string currentColor = null;
	public LayerMask layer;
	public Sprite purpleSprite, greenSprite, orangeSprite, yellowSprite, blueSprite, redSprite;
	public Bucket blueBucket, redBucket, yellowBucket;
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

				playerInventory.addBucketToInventory(foundBucket);
				Destroy(found.gameObject);
			}
			else if(found.CompareTag("Well"))
			{
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
			}
			if (currentPaint[i].color == "Yellow")
			{
				Yellow = true;
			}
			print(currentPaint[i].color);
		}
		print(Blue);
		print(currentColor);
		//if(currentColor == null)
		//{
			if (Red)
			{
				if (Red & Yellow)
				{
					currentColor = "Orange";
					transform.GetComponent<SpriteRenderer>().sprite = orangeSprite;
				}
				else if (Red & Blue)
				{
					currentColor = "Purple";
					transform.GetComponent<SpriteRenderer>().sprite = purpleSprite;
				}
				else
					currentColor = "Red";
					transform.GetComponent<SpriteRenderer>().sprite = redSprite;
			}
			else if (Yellow)
			{
				if (Yellow & Blue)
				{
					currentColor = "Green";
					transform.GetComponent<SpriteRenderer>().sprite = greenSprite;
				}
				else
					currentColor = "Yellow";
					transform.GetComponent<SpriteRenderer>().sprite = yellowSprite;
			}
			else if (Blue)
			{
				currentColor = "Blue";
				transform.GetComponent<SpriteRenderer>().sprite = blueSprite;
			}
			else
				print("Fuck");
	//}

	}
	void clearPaint()
	{
	//	currentColor = null;
	//	Vector2 blueBucketPos = new Vector2(-4.92977f, -1.64967f);
	//	Bucket newBlueBucket = (Bucket)Instantiate(blueBucket, blueBucketPos, Quaternion.identity);

	//	Vector2 yellowBucketPos = new Vector2(6.217075f, -4.19303f);
	//	Bucket newYellowBucket = (Bucket)Instantiate(yellowBucket, yellowBucketPos, Quaternion.identity);

	//	Vector2 redBucketPos = new Vector2(0f, 0.75f);
	//	Bucket newRedBucket = (Bucket)Instantiate(redBucket, redBucketPos, Quaternion.identity);
	}
}
