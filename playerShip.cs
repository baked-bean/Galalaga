using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Galalalaga
{
    class playerShip
    {
       public playerShip() 
        {
            playerPos = new Vector2(200, 200);
            playerRect = new Rectangle(400, 200, 50, 50);
        }
        public Vector2 getPlayerPos()
        {
            Vector2 hold = playerPos;
            return hold;
        }
       public Rectangle getPlayerRect()
        {
            Rectangle hold = playerRect;
            return hold;
        }
       public void setPlayerPos(float x, float y)
       {
           playerPos = new Vector2(x, y);
           playerRect = new Rectangle((int)playerPos.X, (int)playerPos.Y, 50, 50);
       }
        private
            Vector2 playerPos;
            Rectangle playerRect;
           
    }
}
