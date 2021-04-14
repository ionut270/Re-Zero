using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DarkManager : MonoBehaviour
{
    public Tilemap DarkMap;
    public Tilemap BlurredMap;
    public Tilemap BackGroundMap;
    TilemapRenderer tilemap1;
    TilemapRenderer tilemap2;
    public PlayerController player;
    private Vector3 BackMapSize;
    public Tile DarkTile;
    public Tile BlurredTile;
    private enum Locations {ground,sky,cave };
    private Locations loc = Locations.ground;

    void Start()
    {
        DarkMap.origin = new Vector3Int(BackGroundMap.cellBounds.xMin, BackGroundMap.cellBounds.yMin, BackGroundMap.cellBounds.z);
        DarkMap.size = new Vector3Int(BackGroundMap.size.x, BackGroundMap.size.y, BackGroundMap.size.z);
        BlurredMap.origin = new Vector3Int(BackGroundMap.origin.x, BackGroundMap.origin.y, BackGroundMap.origin.z);
        BlurredMap.size = new Vector3Int(BackGroundMap.size.x, BackGroundMap.size.y, BackGroundMap.size.z);

        foreach (Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }
        foreach (Vector3Int p in BlurredMap.cellBounds.allPositionsWithin)
        {
            BlurredMap.SetTile(p, BlurredTile);
        }
        string nameT;
        foreach (Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            var tType = DarkMap.GetTile(p).GetType();
        }

        tilemap1 = DarkMap.GetComponent<TilemapRenderer>();
        tilemap2 = BlurredMap.GetComponent<TilemapRenderer>();
        tilemap1.enabled = false;
        tilemap2.enabled = false;
    }

    void Update()
    {
        this.stateHandler();
        checkUnderground();
    }

    private void stateHandler() {
        
        if (player.transform.position.y > 0){ 
            this.loc = Locations.ground;
            }else
            if (player.transform.position.y < 0){
            this.loc = Locations.cave;
            }  
    }
    void checkUnderground() {
      switch(loc)
       {      case Locations.cave:
                tilemap1.enabled = true;
                tilemap2.enabled = true;
                break;
             case Locations.ground:
                tilemap1.enabled = false;
                tilemap2.enabled = false;
                break;
        }
    }
    
}
