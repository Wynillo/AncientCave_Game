using System.Collections.Generic;
using AncientCave.GameCore.Components;
using AncientCave.GameCore.Entities;

namespace AncientCave.Main.Services
{
    public class Tile
    {
        public enum TileType
        {
            Grass,
            Sand,
            Water,
            Mountain
        }

        public PositionComponent Position { get; set; }
        public RenderComponent Render { get; set; }
        public TileType Type { get; set; }

        // New: entities that are currently on this tile
        public List<Entity> OccupyingEntities { get; set; }

        // New: logic to let an entity enter this tile
        public void EnterTile(Entity entity)
        {
            // Add logic here: check if tile type allows entity to enter, etc.
            OccupyingEntities.Add(entity);
        }

        // New: logic to let an entity leave this tile
        public void LeaveTile(Entity entity)
        {
            // Add logic here: check if entity is on this tile, etc.
            OccupyingEntities.Remove(entity);
        }
    }

    public class TileService
    {
        private Tile[,] _tileGrid;

        public TileService(int width, int height)
        {
            _tileGrid = new Tile[width, height];
        }

        // Rest of the TileService class would be same from last example
        // ...
    }
}