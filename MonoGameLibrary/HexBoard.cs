using System.Collections.Generic;

public class HexBoard
{
    public Dictionary<(int, int), HexTile> Tiles = new Dictionary<(int, int), HexTile>();

    public void AddTile(HexTile tile)
    {
        Tiles[(tile.Q, tile.R)] = tile;
    }


}