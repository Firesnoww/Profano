using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public int numberOfRooms = 10;
    public int roomWidth = 10;
    public int roomHeight = 10;
    public GameObject roomPrefab;
    public GameObject doorPrefab;

    public int randomNum;
    private void Start()
    {
        GenerateRooms();
    }

    private void GenerateRooms()
    {
        Vector3 currentRoomPosition = Vector3.zero;
        for (int i = 0; i < numberOfRooms; i++)
        {
            // Instanciar la habitación
            GameObject newRoom = Instantiate(roomPrefab, currentRoomPosition, Quaternion.identity, transform);
            newRoom.name = "Room " + (i + 1);

            // Generar puerta a la siguiente habitación
            if (i < numberOfRooms - 1)
            {
                Vector3 doorPosition = currentRoomPosition + new Vector3(roomWidth / 2, 0, roomHeight);
                GameObject newDoor = Instantiate(doorPrefab, doorPosition, Quaternion.identity, newRoom.transform);
                newDoor.name = "Door to Room " + (i + 2);
            }

            // Actualizar la posición para la siguiente habitación
            NumAlea();
            currentRoomPosition += new Vector3(randomNum, 0, 0);
        }
    }

    private void NumAlea() { randomNum = Random.Range(-2, 2);  }
}

