using Microsoft.Xna.Framework.Graphics;
using SBad.Map;
using SBad.Visual.Sprites;

namespace BuilderGameCore.Map
{
    public class GraphicFloorTile
    {
        public FloorTile FloorTile { get; }
        public ISprite Sprite { get; }

        public GraphicFloorTile(FloorTile floorTile, ISprite sprite)
        {
            FloorTile = floorTile;
            Sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch) => Sprite.Draw(spriteBatch);
    }
}
