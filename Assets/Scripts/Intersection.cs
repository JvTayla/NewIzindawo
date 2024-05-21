using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    // Reference to the IntersectionManager script
    private IntersectionManager intersectionManager;

    // List to store pieces currently in the intersection
    private List<GameObject> piecesInIntersection = new List<GameObject>();

    // Dictionary to store placeholders and their occupancy status
    private Dictionary<Transform, GameObject> placeholderOccupancy = new Dictionary<Transform, GameObject>();


    // Method to initialize IntersectionManager reference and placeholders
    private void Start()
    {
        intersectionManager = GameObject.FindObjectOfType<IntersectionManager>();

        // Find placeholders within the intersection
        foreach (Transform child in transform)
        {
            if (child.CompareTag("PlaceHolder"))
            {
                //placeholders.Add(child);
                placeholderOccupancy[child] = null; // Initialize as unoccupied
            }
        }
    }

    // Method to add a piece to the intersection and mark the placeholder as occupied
    public void AddPieceToPlaceholder(GameObject piece, Transform placeholder)
    {
        piecesInIntersection.Add(piece);
        placeholderOccupancy[placeholder] = piece; // Mark the placeholder as occupied
    }

    // Method to remove a piece from the intersection
    public void RemovePieceFromIntersection(GameObject piece)
    {
        piecesInIntersection.Remove(piece);

        // Find the placeholder that the piece occupied and mark it as unoccupied
        foreach (var entry in placeholderOccupancy)
        {
            if (entry.Value == piece)
            {
                placeholderOccupancy[entry.Key] = null;
                break;
            }
        }
    }

    // Method to check if the intersection is full
    public bool IsIntersectionFull()
    {
        //return piecesInIntersection.Count >= 3;
        return piecesInIntersection.Count >= placeholderOccupancy.Count;

    }

    // Method to get pieces currently in the intersection
    public List<GameObject> GetPiecesInIntersection()
    {
        return piecesInIntersection;
    }

    // Method to check for adjacent pieces and trigger movement bonus
    public void CheckForAdjacentPieces(GameObject[] pieces)
    {
        intersectionManager.CheckForAdjacentPieces(gameObject, pieces);
    }

    // Method to get placeholders in the intersection
    public List<Transform> GetPlaceholders()
    {
        List<Transform> placeholders = new List<Transform>(placeholderOccupancy.Keys);
        return placeholders;
    }

    // Method to check if a placeholder is occupied
    public bool IsPlaceholderOccupied(Transform placeholder)
    {
        return placeholderOccupancy[placeholder] != null;
    }
}
