using UnityEngine;

public class Room
{
	public string name;
	public bool active;
	public float sizeX;
	public float sizeY;
	public Vector2 position;

	public Room(string name, float x, float y, Vector2 position)
	{
		this.name = name;
		sizeX = x;
		sizeY = y;
		this.position = position;
	}
}

public class DungeonGenerator : MonoBehaviour
{
	[SerializeField] private GameObject[] roomObjects;
	[SerializeField] private int roomCount;
	private ExtensionNode[] extensionNodes;
	private Room[] rooms;
	
	private void Start()
	{
		GenerateRooms();
		CreateMap();
	}

	private void GenerateRooms()
	{
		rooms = new Room[roomObjects.Length];
		for (var i = 0; i < roomObjects.Length; i++)
		{
			rooms[i] = new Room(roomObjects[i].name, roomObjects[i].transform.localScale.x, roomObjects[i].transform.localScale.z, new Vector2());
		}
	}

	private void CreateMap()
	{
		while (true)
		{
			extensionNodes = FindObjectsOfType<ExtensionNode>();

			if (extensionNodes.Length >= roomCount) return;

			var currentnumber = Random.Range(0, rooms.Length);
			if (!extensionNodes[currentnumber].CanExtend(rooms[currentnumber].sizeY)) continue;
			//if (IsColliding) continue;
			Destroy(extensionNodes[currentnumber].gameObject);
			Instantiate(roomObjects[Random.Range(0, roomObjects.Length)], extensionNodes[currentnumber].transform.position, extensionNodes[currentnumber].transform.rotation);
		}
	}
}
