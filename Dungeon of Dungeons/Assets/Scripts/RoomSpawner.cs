using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates templates;
    int randomNumber;
    public bool spawned;

    private void Start()
    {
        templates = GameObject.FindObjectOfType<RoomTemplates>().GetComponent<RoomTemplates>();
        Invoke("spawn", 0.2f);
    }
    private void spawn()
    {
        if(spawned == false)
        {
            switch (openingDirection)
            {
                case 1:
                    randomNumber = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[randomNumber], transform.position, templates.topRooms[randomNumber].transform.rotation);
                    
                    break;
                case 2:
                    randomNumber = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[randomNumber], transform.position, templates.bottomRooms[randomNumber].transform.rotation);

                    break;
                case 3:
                    randomNumber = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[randomNumber], transform.position, templates.rightRooms[randomNumber].transform.rotation);

                    break;
                case 4:
                    randomNumber = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[randomNumber], transform.position, templates.leftRooms[randomNumber].transform.rotation);

                    break;

            }
            
            spawned = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>() != null) 
            {
                if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
                {
                    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            
            spawned = true;
        }
    }
    
}
