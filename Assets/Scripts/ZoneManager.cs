using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridCellSlot;

public class ZoneManager : MonoBehaviour
{
    public enum ZoneType
    {
        Pink,
        Blue,
        Yellow,
        Intersection,
        WhiteBlock
    }

    public GameObject[] pinkZones;
    public GameObject[] blueZones;
    public GameObject[] yellowZones;
    public GameObject[] intersectionZones;
    public GameObject[] whiteBlockZones;

    
    public Dictionary<ZoneType, List<GameObject>> zoneObjects = new();

    public bool IsInZone(GameObject gameObject, ZoneType zoneType)
    {
        // Check if the game object is within the specified zone
        if (zoneObjects.ContainsKey(zoneType))
        {
            List<GameObject> objectsInZone = zoneObjects[zoneType];
            return objectsInZone.Contains(gameObject);
        }
        return false;
    }
    void Start()
    {
        
        foreach (ZoneType zone in System.Enum.GetValues(typeof(ZoneType)))
        {
            zoneObjects[zone] = new List<GameObject>();
        }

        // Add the zone GameObjects to the dictionary
        foreach (GameObject zone in pinkZones)
        {
            zoneObjects[ZoneType.Pink].Add(zone);
        }
        foreach (GameObject zone in blueZones)
        {
            zoneObjects[ZoneType.Blue].Add(zone);
        }
        foreach (GameObject zone in yellowZones)
        {
            zoneObjects[ZoneType.Yellow].Add(zone);
        }
        foreach (GameObject zone in intersectionZones)
        {
            zoneObjects[ZoneType.Intersection].Add(zone);
        }
        foreach (GameObject zone in whiteBlockZones)
        {
            zoneObjects[ZoneType.WhiteBlock].Add(zone);
        }
    }
}
