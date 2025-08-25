public class HexTile
{
    public int Q { get; set; }
    public int R { get; set; }
    public TileType TileType { get; set; }

    public int DiceNumber { get; set; }


    public HexTile(int q, int r, TileType tileType, int diceNumber)
    {
        Q = q;
        R = r;
        TileType = tileType;
        DiceNumber = diceNumber;
    }
    
}