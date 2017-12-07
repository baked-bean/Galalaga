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
    class projectile
    {
        public projectile(Vector2 startPos, Texture2D passedInTexture)
        {
            texture = passedInTexture;
            position = startPos;
        }
        public Vector2 move(int speed)
        {
            position = new Vector2(position.X, position.Y + speed);
            return position;
        }
        public Rectangle getRect()
        {
            Rectangle hold = rectangle;
            return hold;
        }
        public Texture2D getTexture()
        {
            Texture2D hold = texture;
            return hold;
        }
   
        private Rectangle rectangle;
        private Texture2D texture;
        private Vector2 position;
    }
}
