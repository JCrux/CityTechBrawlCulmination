using UnityEngine;
using System.Collections;

public class CameraControllerV2 : MonoBehaviour
{
	//public Transform player;

	//private Camera_Shake_Script Camera_Shake;

	public GameObject HP_Bento;
	public GameObject Player;
	public float maxLeftPos;
	public float maxRightPos;

	public float playerDistance_x;

	public float xPos;
	public float yPos;

	public float xPos_Offset;
	public float yPos_Offset;
	public float zPos_Offset;

	public float Cam_speed;
	// Use this for initialization
	void Start()
	{
		//Camera_Shake = FindObjectOfType<Camera_Shake_Script>();

		//maxLeftPos = GameObject.Find ("LeftWall").transform.position.x+8;
		//maxRightPos = GameObject.Find ("RightWall").transform.position.x-8;

	}

	// Update is called once per frame

	void FixedUpdate()
	{
		if (xPos >= maxRightPos)
		{

			xPos = maxRightPos;
		/*	if (!Camera_Shake.isShaking)
			{
				//transform.position = new Vector3 (xPos + xPos_Offset, yPos + yPos_Offset, zPos_Offset);
				transform.position = Vector3.Lerp(transform.position, new Vector3(xPos + xPos_Offset, yPos + yPos_Offset, zPos_Offset), Cam_speed);
			} */
		}
		else if (xPos <= maxLeftPos)
		{

			xPos = maxLeftPos;
			/* if (!Camera_Shake.isShaking)
			{
				//transform.position = new Vector3 (xPos + xPos_Offset, yPos + yPos_Offset,  zPos_Offset);
				transform.position = Vector3.Lerp(transform.position, new Vector3(xPos + xPos_Offset, yPos + yPos_Offset, zPos_Offset), Cam_speed);

			} */
			
		}
		else
		{

			/* if (!Camera_Shake.isShaking)
			{
				//transform.position = new Vector3 (xPos+ xPos_Offset, yPos + yPos_Offset,  zPos_Offset);
				transform.position = Vector3.Lerp(transform.position, new Vector3(xPos + xPos_Offset, yPos + yPos_Offset, zPos_Offset), Cam_speed);
			} */
		}
	}

	void Update()
	{
		//transform.position = new Vector3(player.position.x, -2.2f, transform.position.z);

		if (!HP_Bento || !Player)
		{
			if (GameObject.FindGameObjectWithTag("Player"))
			{
				HP_Bento = GameObject.FindGameObjectWithTag("Player").gameObject;
			}
			if (GameObject.FindGameObjectWithTag("Player2"))
			{
				Player = GameObject.FindGameObjectWithTag("Player2").gameObject;
			}
		}
		else if (HP_Bento.activeSelf && !Player.activeSelf)
		{
			xPos = HP_Bento.transform.position.x;
			yPos = HP_Bento.transform.position.y + 0.78f;
		}
		else if (Player.activeSelf && !HP_Bento.activeSelf)
		{
			xPos = HP_Bento.transform.position.x;
			yPos = Player.transform.position.y + 0.78f;
		}
		else
		{

			playerDistance_x = Mathf.Abs(HP_Bento.transform.position.x - Player.transform.position.x);

			xPos = (HP_Bento.transform.position.x + Player.transform.position.x) / 2;
			yPos = ((HP_Bento.transform.position.y + Player.transform.position.y)) / 4;
		}




		//transform.localScale = new Vector3 ( (1*zPos_Offset)/8 ,  (1*zPos_Offset)/8, 1);

	}
}