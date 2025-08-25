using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace Catan;

public class Game1 : Core
{
    private Texture2D _test;

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
        // base.LoadContent(); // Should Never be removed
        _test = Content.Load<Texture2D>("images/WheatHex");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin();
        SpriteBatch.Draw(_test, new Vector2(    // position
            (Window.ClientBounds.Width * 0.5f) - (_test.Width * 0.5f),
            (Window.ClientBounds.Height * 0.5f) - (_test.Height * 0.5f)), null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
        SpriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
