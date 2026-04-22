using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics;

public class Tilemap
{
    private readonly Tileset _tileset;
    private readonly int[] _tiles;

    //Gets the total number of rows in this tilemap
    public int Rows { get; }
    //Gets the total number of columns in this tilemap
    public int Coloumns { get; }
    //Gets the total number of tiles in this tilemap
    public i

}