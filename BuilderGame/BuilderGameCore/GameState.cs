using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Engine;
using SBad.Visual.Sprites;

namespace BuilderGameCore
{
    public class GameState : IGameState
    {
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public TextureFrameStore TextureFrameStore { get; set; }
        public GameTime GameTime { get; set; }
        public InputState InputState { get; set; } = new InputState();
        public InputState OldInputState { get; set; }
    }
}
