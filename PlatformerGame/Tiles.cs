using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PlatformerGame
{
    internal class Tiles : GameObject
    {
        private static List<Platform> platformList = new List<Platform>();
        public static List<Platform> PlatformList { get { return platformList; } set { platformList = value; } }

        private static List<FloorSpikes> obstacleList = new List<FloorSpikes>();
        public static List<FloorSpikes> ObstacleList { get { return obstacleList; } set { obstacleList = value; } }

        public Tiles(Texture2D texture, Rectangle hitBox) : base(texture, hitBox)
        {

        }
    }
}
