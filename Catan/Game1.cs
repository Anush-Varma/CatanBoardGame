using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace Catan;

public class Game1 : Core
{
    private Texture2D _test;
    private Texture2D _WheatHex;
    private Texture2D _WoodHex;
    private Texture2D _BrickHex;
    private Texture2D _SheepHex;
    private Texture2D _StoneHex;
    private Texture2D _VolcanoHex;
    private Texture2D _InhabitableHex;
    private Texture2D _OceanHex;


    private float _hexScale = 0.5f;
    private Vector2 _boardCenter;
    private Vector2 _hexOrigin;
    private float _scaledHalfWidth;
    private float _scaledHalfHeight;
    private float _tileWidthCorrection;
    private float _diagonalTileHeightCorrection;
    private float _verticalTileHeightCorrection;
    private float _halfHexHeight;
    private float _hexTextureWidth;
    private float _hexTextureHeight;


    private HexBoard _board;
    private int _boardSize = 2;
    private bool _boardGenerated = false;

    public Game1() : base("Catan", 1250, 700, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize(); // Should Never be removed
        Window.ClientSizeChanged += (sender, e) =>
        {
            _boardGenerated = false;
        };

    }

    /// <summary>
    /// Load textures, sound effects and other game assets here.
    /// </summary>
    protected override void LoadContent()
    {
        base.LoadContent(); // Should Never be removed

        _test = Content.Load<Texture2D>("images/OceanHex");

        _WheatHex = Content.Load<Texture2D>("images/WheatHex");
        _WoodHex = Content.Load<Texture2D>("images/WoodHex");
        _BrickHex = Content.Load<Texture2D>("images/BrickHex");
        _SheepHex = Content.Load<Texture2D>("images/SheepHex");
        _StoneHex = Content.Load<Texture2D>("images/StoneHex");
        _VolcanoHex = Content.Load<Texture2D>("images/VolcanoHex");
        _InhabitableHex = Content.Load<Texture2D>("images/InhabitableHex");
        _OceanHex = Content.Load<Texture2D>("images/OceanHex");

        _hexTextureHeight = _VolcanoHex.Height;
        _hexTextureWidth = _VolcanoHex.Width;

        _hexOrigin = new Vector2(_hexTextureWidth, _hexTextureHeight) * 0.5f;

        _scaledHalfWidth = _hexTextureWidth * _hexScale;
        _scaledHalfHeight = _hexTextureHeight * _hexScale;

        _tileWidthCorrection = 30f;
        _diagonalTileHeightCorrection = 20f;
        _verticalTileHeightCorrection = 40f;
        _halfHexHeight = _scaledHalfHeight * 0.5f;

        _board = new HexBoard();

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    private void DrawHex(Texture2D hexTexture, Vector2 position, float depth)
    {
        SpriteBatch.Draw(hexTexture, position, null, Color.White, 0.0f, _hexOrigin, _hexScale, SpriteEffects.None, depth);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        _boardCenter = new Vector2(Window.ClientBounds.Width * 0.5f, Window.ClientBounds.Height * 0.5f);


        if (!_boardGenerated)
        {
            _board.Generate(_boardSize, _boardCenter, _hexTextureWidth, _hexTextureHeight, _hexScale, _tileWidthCorrection, _diagonalTileHeightCorrection, _verticalTileHeightCorrection);

            _boardGenerated = true;
        }

        SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);


        foreach (var tile in _board.Tiles.Values)
        {
            float depth = 0.5f + tile.Position.Y / Window.ClientBounds.Height * 0.5f;

            depth = Math.Clamp(depth, 0f, 1f);
            DrawHex(_SheepHex, tile.Position, depth);
        }

        SpriteBatch.End();


        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
