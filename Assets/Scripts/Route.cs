using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Transform[] connectedNodes;
    public List<Transform> nodeList = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        FillNodes();

        for (int i = 0; i < nodeList.Count; i++)
        {
            Vector2 currentPos = nodeList[i].position;

            // Draw connections to connected nodes
            foreach (Transform connectedNode in connectedNodes)
            {
                Gizmos.DrawLine(currentPos, connectedNode.position);
            }
        }
    }

    void FillNodes()
    {
        nodeList.Clear();

        // Add the current transform to the list
        nodeList.Add(transform);

        // Add the connected nodes to the list
        foreach (Transform connectedNode in connectedNodes)
        {
            nodeList.Add(connectedNode);
        }
    }
}
