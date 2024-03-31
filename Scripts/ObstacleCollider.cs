using System.Collections; // Imports System.Collections namespace
using System.Collections.Generic; // Imports System.Collections.Generic namespace
using UnityEngine; // Imports UnityEngine namespace

public class ObstacleCollider : MonoBehaviour // Class for handling obstacle collisions
{
    void Start() // Called before the first frame update
    {
        // Initialization code here
    }

    private void OnTriggerEnter2D(Collider2D collision) // Called when the Collider2D other enters the trigger (2D physics only)
    {
        if (collision.tag == "Border") // Checks if the collided object has the tag "Border"
        {
            Destroy(this.gameObject); // Destroys the game object this script is attached to
        }
    }
}
