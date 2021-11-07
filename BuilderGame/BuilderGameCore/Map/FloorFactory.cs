using Microsoft.Xna.Framework.Graphics;
using SBad.Map;
using SBad.Visual.Sprites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BuilderGameCore.Map
{
    public class FloorFactory
    {
        public TextureFrameStore TextureFrameStore { get; }
        private readonly Dictionary<(int, int), GraphicFloorTile> tiles;
        private readonly FloorPlan floorPlan;

        public FloorFactory(TextureFrameStore textureFrameStore)
        {
            TextureFrameStore = textureFrameStore;
            tiles = new Dictionary<(int, int), GraphicFloorTile>();
            floorPlan = new FloorPlan();
        }

        public void AddStoneTile(int x, int y)
        {
            var floorTile = new FloorTile(x, y, 1);
            var sprite = new PictureSprite(TextureFrameStore["stone-tile"])
                .SetPosition(new Microsoft.Xna.Framework.Vector2(x, y))
                .SetSize(48,48);
            var tile = new GraphicFloorTile(floorTile, sprite);
            tiles[(x, y)] = tile;
            floorPlan.FloorTiles.Add(tile.FloorTile);
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            tiles.Keys.ToList().ForEach(x => tiles[x].Draw(spriteBatch));
        }
    }
}
