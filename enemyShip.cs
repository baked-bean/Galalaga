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
    class enemyShip
    {
           public enemyShip(Vector2 newPos, Texture2D shipTexture)
        {
            position = new Vector2(100,100);
           home = newPos;
           enemyStance = stance.inactive;
           enemyTexture = shipTexture;
        }
              
        public enum stance{arriving, attacking, idling,inactive};

        public void setPos(Vector2 passedIn)
        {
            position = passedIn;
        }

        public Vector2 getPos()
        {
            Vector2 hold = position;
            return hold;
        }

        public void move(float x, float y)
        {
            switch (enemyStance)
            {
                case stance.inactive:
                    enemyStance = stance.arriving;

                    break;

                case stance.arriving:

                    break;
                case stance.attacking:

                    break;
                case stance.idling:


                    break;

            }
        }
        
        public stance getStance()
        {
            return enemyStance;
        }

        public void setStance(stance passedIn)
        {
            enemyStance = passedIn;
        }

        public Rectangle getRect()
        {
            return new Rectangle((int)position.X, (int)position.Y, 25, 25);
        }

        public Texture2D getTexture()
        {
            return enemyTexture;
        }

        private Vector2 home;
        private Vector2 position;
        private stance enemyStance;
        private Texture2D enemyTexture;    

    }
}
