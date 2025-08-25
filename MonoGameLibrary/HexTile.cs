public class HexTile
{
    private int _q; 
    private int _r; 
    private int _s;
    private TileType _tileType;
    

    public HexTile(int q, int r, int s, TileType tileType)
    {
        _q = q;
        _r = r;
        _s = s;
        _tileType = tileType;
    }
    
}