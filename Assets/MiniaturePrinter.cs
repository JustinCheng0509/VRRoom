using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniaturePrinter : MonoBehaviour
{
    public GameObject creationRoot; // The root GameObject of the user's 3D creation
    public Transform tableTop; // The target position on the table where the miniature will be placed
    public float miniatureScale = 0.1f; // Scale factor for the miniature version
    // Start is called before the first frame update
    public void PrintMiniature()
    {
        {
            // Duplicate the 3D creation
            GameObject miniature = Instantiate(creationRoot, tableTop.position, Quaternion.identity);

            // Scale down the duplicate to make it a miniature
            miniature.transform.localScale *= miniatureScale;

            // Optionally, adjust the position or rotation as needed
            // miniature.transform.position = CalculatePositionForNewMiniature();
            // miniature.transform.rotation = Quaternion.Euler(0, 0, 0);

            // If your 3D creations are very complex, consider implementing additional optimizations
        }
    }
}
