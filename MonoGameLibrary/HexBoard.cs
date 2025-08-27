using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class HexBoard
{
    public Dictionary<(int, int), HexTile> Tiles = new Dictionary<(int, int), HexTile>();

    public void AddTile(HexTile tile)
    {
        Tiles[(tile.Q, tile.R)] = tile;
    }

    public void Generate(int size, Vector2 center, float textureWidth,
                float textureHeight, float scale, float tileWidthCorrection,
                float diagonalTileHeightCorrection, float verticalTileHeightCorrection)
    {
        Tiles.Clear();

        float hexWidth = textureWidth * scale;
        float hexHeight = textureHeight * scale;
        float halfHexHeight = hexHeight * 0.5f;


        var vecQPosition = new Vector2(0f, hexHeight - verticalTileHeightCorrection);
        var vecRPosition = new Vector2(hexWidth - tileWidthCorrection, halfHexHeight - diagonalTileHeightCorrection);

        // axial board circle iteration: produces 1 + 3 * size * (size * 1)


        // loops though hex shaped q and r coord values.
        // if size is 1 them goes through -1, 0, 1: 2 tiles + 3 tiles + 2 tiles = 7
        for (int q = -size; q <= size; q++)
        {
            int rMin = System.Math.Max(-size, -q - size);
            int rMax = System.Math.Min(size, -q + size);

            for (int r = rMin; r <= rMax; r++)
            {
                var tile = new HexTile(q, r, default(TileType), 0);
                tile.Position = center + vecQPosition * q + vecRPosition * r;
                Tiles[(q, r)] = tile;

            }
        }


    }


}