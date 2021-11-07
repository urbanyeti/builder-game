using BuilderGameCore.Map;
using BuilderGameCore.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SBad.Engine;
using SBad.Visual.Sprites;
using SBad.Visual.UI;
using SBad.Visual.UI.Buttons;
using System;

namespace BuilderGameCore
{
    public class BuilderGame : Game
    {
        private readonly GameState _gameState;
        private readonly InputManager _inputManager;
        private FloorFactory _floorFactory;
        public Window Menu { get; set; }

        public BuilderGame()
        {
            _gameState = new GameState
            {
                GraphicsDeviceManager = new GraphicsDeviceManager(this)
            };
            _inputManager = new InputManager(_gameState);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _gameState.TextureFrameStore = new TextureFrameStore();
            _inputManager.LeftButtonPressed += InputManager_LeftButtonPressed;
            _inputManager.KeyboardKeyPressed += InputManager_KeyboardKeyPressed;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameState.SpriteBatch = new SpriteBatch(GraphicsDevice);
            _gameState.TextureFrameStore.AddTextureFrame("stone-tile", new TextureFrame(
                Content.Load<Texture2D>("TileA2_PHC_General-Flooring"),
                new Rectangle(288, 48, 96, 96)));

            _gameState.TextureFrameStore.AddTextureFrame("button", new TextureFrame(
                Content.Load<Texture2D>("frame_c2_01"),
                new Rectangle(0, 0, 163, 163)));

            var pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            _gameState.TextureFrameStore.AddTextureFrame("pixel", 
                new TextureFrame(pixel, new Rectangle(0,0,1,1)));

            _floorFactory = new FloorFactory(_gameState.TextureFrameStore);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _floorFactory.AddStoneTile(i*48, j*48);
                }
            }

            Menu = new Window
            {
                Width = 800,
                Height = 96,
                Position = new Vector2(0, 384),
                BorderColor = Color.Black,
                BorderWidth = 5
            };

            var div = new Div
            {
                Color = Color.LightGray,
                AutoWidth = true,
                AutoHeight = true
            };

            Menu.AddDiv(div);

            div.AddRow(SBad.Visual.Alignment.Left, new SBad.Visual.Padding(0,0,0,0));

            ButtonFactory buttonFactory = new ButtonFactory(div.Rows[0], new ActionButtonBuilder(_gameState.TextureFrameStore));
            buttonFactory.Build("action-menu", 0, ButtonLayout.LeftToRight, ButtonClicked);
            var button = buttonFactory.Execute();
            div.Rows[0].AddElement(button);
        }

        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update();

            _inputManager.CheckKeyboardState();
            _inputManager.CheckMouseState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _gameState.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _floorFactory.Draw(_gameState.SpriteBatch);
            Menu.Draw(_gameState.SpriteBatch, _gameState.TextureFrameStore);
            base.Draw(gameTime);
            _gameState.SpriteBatch.End();
        }

        public void ButtonClicked(IButton button)
        {
            Console.WriteLine("Button Clicked!");
        }

        private void InputManager_LeftButtonPressed(object sender, InputManager.LeftButtonPressedEventArgs e)
        {
            Menu.Buttons.ForEach(x =>
            {
                if (x.BoundaryBox.Contains(_gameState.InputState.MouseState.Position))
                {
                    x.Action.Invoke(x);
                }
            });
        }

        private void InputManager_KeyboardKeyPressed(object sender, InputManager.KeyboardKeyPressedEventArgs e)
        {
            if (e.Key == Keys.Escape)
            {
                Exit();
            }
        }
    }
}
