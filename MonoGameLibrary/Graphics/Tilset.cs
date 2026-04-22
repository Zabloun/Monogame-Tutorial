namespace MonoGameLibrary.Graphics;

public class Tileset
{
    private readonly TextureRegion[] _tiles;

    //Gets the width, in pixels of each tile in this tileset.
    public int TileWidth { get; }

    //Gets the height, in pixels of each tile in this tileset.
    public int TileHeight { get; }

    //Get the total number of columns in this tileset.
    public int Coloumns { get; }

    //Gets the total number of rows in this tileset.
    public int Rows { get; }

    //Gets the total number of tiles in this tileset.
    public int Count { get; }

    /// <summary>
    /// Creates a new tileset based on the given texture region with the specified
    /// tile width and height.
    /// </summary>
    /// <param name="textureRegion">The texture region that contains the tiles for the tileset.</param>
    /// <param name="tileWidth">The width of each tile in the tileset.</param>
    /// <param name="tileHeight">The height of each tile in the tileset.</param>
    public Tileset(TextureRegion textureRegion, int tileWidth, int tileHeight)
    {
        TileHeight = tileHeight;
        TileWidth = tileWidth;
        Coloumns = textureRegion.Width / TileWidth;
        Rows = textureRegion.Height / tileHeight;
        Count = Coloumns * Rows;

        _tiles = new TextureRegion[Count];

        for (int i = 0; i < Count; i++)
        {
            int x = i % Coloumns * tileWidth;
            int y = i / Coloumns * TileHeight;
            _tiles[i] = new TextureRegion(textureRegion.Texture, textureRegion.SourceRectangle.X + x, textureRegion.SourceRectangle.Y + y, tileWidth, tileHeight);
        }

    }
    /// <summary>
    /// Gets the texture region for the tile from this tileset at the given index.
    /// </summary>
    /// <param name="index">The index of the texture region in this tile set.</param>
    /// <returns>The texture region for the tile form this tileset at the given index.</returns>
    public TextureRegion GetTile(int index) => _tiles[index];

    /// <summary>
    /// Gets the texture region for the tile from this tileset at the given location.
    /// </summary>
    /// <param name="column">The column in this tileset of the texture region.</param>
    /// <param name="row">The row in this tileset of the texture region.</param>
    /// <returns>The texture region for the tile from this tileset at given location.</returns>
    public TextureRegion GetTile(int column, int row)
    {
        int index = row * column + column;
        return GetTile(index);
    }

}