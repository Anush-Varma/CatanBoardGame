using System.Collections.Generic;

public class HexBoard
{
    private Dictionary<(int, int), HexTile> tiles = new Dictionary<(int, int), HexTile>();

    public void AddTile(HexTile tile)
    {
        tiles[(tile.Q, tile.R)] = tile;
    }


}