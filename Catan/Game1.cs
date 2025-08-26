using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace Catan;

public class Game1 : Core
{
    private Texture2D _test;


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




    public Game1() : base("Catan", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize(); // Should Never be removed
    }

    /// <summary>
    /// Load textures, sound effects and other game assets here.
    /// </summary>
    protected override void LoadContent()
    {

        // TODO: use this.Content to load your game content here
        base.LoadContent(); // Should Never be removed
        _test = Content.Load<Texture2D>("images/WheatHex");

        _hexTextureHeight = _test.Height;
        _hexTextureWidth = _test.Width;

        _hexOrigin = new Vector2(_hexTextureWidth, _hexTextureHeight) * 0.5f;

        _scaledHalfWidth = _hexTextureWidth * _hexScale;
        _scaledHalfHeight = _hexTextureHeight * _hexScale;

        _tileWidthCorrection = 29f;
        _diagonalTileHeightCorrection = 4f;
        _verticalTileHeightCorrection = 8f;
        _halfHexHeight = _scaledHalfHeight * 0.5f;

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


        SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);

        var centreHex = _boardCenter;
        var topHex = _boardCenter - new Vector2(0, _scaledHalfHeight - _verticalTileHeightCorrection);
        var bottomHex = _boardCenter + new Vector2(0, _scaledHalfHeight - _verticalTileHeightCorrection);
        var topLeftHex = _boardCenter - new Vector2(_scaledHalfWidth - _tileWidthCorrection, _halfHexHeight - _diagonalTileHeightCorrection);
        var topRightHex = _boardCenter + new Vector2(_scaledHalfWidth - _tileWidthCorrection, -_halfHexHeight + _diagonalTileHeightCorrection);
        var bottomLeftHex = _boardCenter - new Vector2(_scaledHalfWidth - _tileWidthCorrection, -_halfHexHeight + _diagonalTileHeightCorrection);
        var bottomRightHex = _boardCenter + new Vector2(_scaledHalfWidth - _tileWidthCorrection, _halfHexHeight - _diagonalTileHeightCorrection);

        DrawHex(_test, centreHex, 0.7f);
        DrawHex(_test, topHex, 0.3f);
        DrawHex(_test, bottomHex, 1.0f);
        DrawHex(_test, topLeftHex, 0.5f);
        DrawHex(_test, topRightHex, 0.5f);
        DrawHex(_test, bottomLeftHex, 0.8f);
        DrawHex(_test, bottomRightHex, 0.8f);


        // SpriteBatch.Draw(_test, new Vector2(Window.ClientBounds.Width * 0.5f, (Window.ClientBounds.Height * 0.5f) + _test.Height * 0.5f - 8), null, Color.White, 0.0f, new Vector2(_test.Width, _test.Height) * 0.5f, 0.5f, SpriteEffects.None, 0.1f);

        // SpriteBatch.Draw(_test, new Vector2(Window.ClientBounds.Width * 0.5f, Window.ClientBounds.Height * 0.5f), null, Color.White, 0.0f, new Vector2(_test.Width, _test.Height) * 0.5f, 0.5f, SpriteEffects.None, 1.0f);

        // SpriteBatch.Draw(_test, new Vector2((Window.ClientBounds.Width * 0.5f) + (_test.Width * 0.5f) - 29, (Window.ClientBounds.Height * 0.5f) - _test.Height * 0.25f + 4), null, Color.White, 0.0f, new Vector2(_test.Width, _test.Height) * 0.5f, 0.5f, SpriteEffects.None, 0.2f);

        // SpriteBatch.Draw(_test, new Vector2((Window.ClientBounds.Width * 0.5f) + ((_test.Width * 0.5f) - 29) * 2, Window.ClientBounds.Height * 0.5f), null, Color.White, 0.0f, new Vector2(_test.Width, _test.Height) * 0.5f, 0.5f, SpriteEffects.None, 1.0f);


        SpriteBatch.End();


        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
