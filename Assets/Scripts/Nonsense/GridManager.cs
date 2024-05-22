using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

        // Define the grid dimensions
        public int gridSizeX = 5;
        public int gridSizeY = 5;

        // Yellow, Pink, and Blue grids
        public List<Vector2> yellowGrid = new List<Vector2>();
        public List<Vector2> pinkGrid = new List<Vector2>();
        public List<Vector2> blueGrid = new List<Vector2>();

        // heart zones for each color
        public List<Vector2> yellowHeartZone = new List<Vector2>();
        public List<Vector2> pinkHeartZone = new List<Vector2>();
        public List<Vector2> blueHeartZone = new List<Vector2>();

        // Initialize the grids and heart zones
        void Start()
        {
            // Initialize the Yellow grid
            yellowGrid.Add(new Vector2(0, 1));
            yellowGrid.Add(new Vector2(0, 2));
            yellowGrid.Add(new Vector2(0, 3));
            yellowGrid.Add(new Vector2(0, 4));
            yellowGrid.Add(new Vector2(1, 0));
            yellowGrid.Add(new Vector2(1, 1));
            yellowGrid.Add(new Vector2(1, 2));
            yellowGrid.Add(new Vector2(1, 3));
            yellowGrid.Add(new Vector2(1, 4));
            yellowGrid.Add(new Vector2(2, 0));
            yellowGrid.Add(new Vector2(2, 1));
            yellowGrid.Add(new Vector2(2, 2));
            yellowGrid.Add(new Vector2(2, 3));
            yellowGrid.Add(new Vector2(2, 4));
            yellowGrid.Add(new Vector2(3, 0));
            yellowGrid.Add(new Vector2(3, 1));
            yellowGrid.Add(new Vector2(3, 2));
            yellowGrid.Add(new Vector2(3, 3));
            yellowGrid.Add(new Vector2(3, 4));
            yellowGrid.Add(new Vector2(4, 0));
            yellowGrid.Add(new Vector2(4, 1));
            yellowGrid.Add(new Vector2(4, 2));
            yellowGrid.Add(new Vector2(4, 3));

            pinkGrid.Add(new Vector2(0, 1));
            pinkGrid.Add(new Vector2(0, 2));
            pinkGrid.Add(new Vector2(0, 3));
            pinkGrid.Add(new Vector2(0, 4));
            pinkGrid.Add(new Vector2(1, 0));
            pinkGrid.Add(new Vector2(1, 1));
            pinkGrid.Add(new Vector2(1, 2));
            pinkGrid.Add(new Vector2(1, 3));
            pinkGrid.Add(new Vector2(1, 4));
            pinkGrid.Add(new Vector2(2, 0));
            pinkGrid.Add(new Vector2(2, 1));
            pinkGrid.Add(new Vector2(2, 2));
            pinkGrid.Add(new Vector2(2, 3));
            pinkGrid.Add(new Vector2(2, 4));
            pinkGrid.Add(new Vector2(3, 0));
            pinkGrid.Add(new Vector2(3, 1));
            pinkGrid.Add(new Vector2(3, 2));
            pinkGrid.Add(new Vector2(3, 3));
            pinkGrid.Add(new Vector2(3, 4));
            pinkGrid.Add(new Vector2(4, 0));
            pinkGrid.Add(new Vector2(4, 1));
            pinkGrid.Add(new Vector2(4, 2));
            pinkGrid.Add(new Vector2(4, 3));
         
            blueGrid.Add(new Vector2(0, 1));
            blueGrid.Add(new Vector2(0, 2));
            blueGrid.Add(new Vector2(0, 3));
            blueGrid.Add(new Vector2(0, 4));
            blueGrid.Add(new Vector2(1, 0));
            blueGrid.Add(new Vector2(1, 1));
            blueGrid.Add(new Vector2(1, 1)); 
            blueGrid.Add(new Vector2(1, 2));
            blueGrid.Add(new Vector2(1, 3));
            blueGrid.Add(new Vector2(1, 4));
            blueGrid.Add(new Vector2(2, 0));
            blueGrid.Add(new Vector2(2, 1));
            blueGrid.Add(new Vector2(2, 2));
            blueGrid.Add(new Vector2(2, 3));
            blueGrid.Add(new Vector2(2, 4));
            blueGrid.Add(new Vector2(3, 0));
            blueGrid.Add(new Vector2(3, 1));
            blueGrid.Add(new Vector2(3, 2));
            blueGrid.Add(new Vector2(3, 3));
            blueGrid.Add(new Vector2(3, 4));
            blueGrid.Add(new Vector2(4, 0));
            blueGrid.Add(new Vector2(4, 1));
            blueGrid.Add(new Vector2(4, 2));
            blueGrid.Add(new Vector2(4, 3));
           

            // Initialize the Yellow heart zone
            yellowHeartZone.Add(new Vector2(1, 1));
            yellowHeartZone.Add(new Vector2(1, 2));
            yellowHeartZone.Add(new Vector2(2, 1)); 
            yellowHeartZone.Add(new Vector2(2, 2));
            yellowHeartZone.Add(new Vector2(2, 3));
            yellowHeartZone.Add(new Vector2(3, 1));
            yellowHeartZone.Add(new Vector2(3, 1));
            yellowHeartZone.Add(new Vector2(3, 3));



           // Initialize the Pink heart zone
            pinkHeartZone.Add(new Vector2(1, 1));
            pinkHeartZone.Add(new Vector2(1, 2));
            pinkHeartZone.Add(new Vector2(2, 1));
            pinkHeartZone.Add(new Vector2(2, 2));
            pinkHeartZone.Add(new Vector2(2, 3));
            pinkHeartZone.Add(new Vector2(3, 1));
            pinkHeartZone.Add(new Vector2(3, 1));
            pinkHeartZone.Add(new Vector2(3, 3));

            // Initialize the Blue heart zone

            blueHeartZone.Add(new Vector2(1, 1));
            blueHeartZone.Add(new Vector2(1, 2));
            blueHeartZone.Add(new Vector2(2, 1));
            blueHeartZone.Add(new Vector2(2, 2));
            blueHeartZone.Add(new Vector2(2, 3));
            blueHeartZone.Add(new Vector2(3, 1));
            blueHeartZone.Add(new Vector2(3, 1));
            blueHeartZone.Add(new Vector2(3, 3));

            // Add the Blue heart zone coordinates here
    }

    // Check if a position is within a specific grid
    public bool IsInGrid(Vector2 position, List<Vector2> grid)
        {
            return grid.Contains(position);
        
        }

        // Check if a position is within a specific heart zone
        public bool IsInHeartZone(Vector2 position, List<Vector2> heartZone)
        {
            return heartZone.Contains(position);
        }
    
}
