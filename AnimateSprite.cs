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

namespace GameTest
{
    class AnimateSprite
    {
        float time,
            frameChangeRate;
        int currentFrame,
            defaultFrame,
            animation,
            maxFrames,
            spriteHeight,
            spriteWidth;
        bool reversed;
        Rectangle spriteSelectRect;
        Texture2D spriteSheet;
        GameTime timer;

        public AnimateSprite(float frameChangeRate, int currentFrame, int defaultFrame,
            int animation, int maxFrames, int spriteWidth, int spriteHeight)
        {
            reversed = false;
            timer = new GameTime();
            time = 0.000f;
            this.frameChangeRate = frameChangeRate;
            this.currentFrame = currentFrame;
            this.defaultFrame = defaultFrame;
            this.animation = animation;
            this.maxFrames = maxFrames;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;

            spriteSelectRect = new Rectangle(currentFrame * spriteWidth, animation * spriteHeight,
                spriteWidth, spriteHeight); 
        }


        public Rectangle SpriteSelectRect
        {
            get
            {
                return spriteSelectRect;
            }
        }
        public void ChangeSprite(int input, float time)
        {
            // Takes in the time of the last update
            this.time += time;

            // Checks the directional input
            if (input == 1)
            {
                // Checks whether a new frame is needed
                if (this.time > 1f)
                {
                    // Checks if the
                    if (reversed)
                    {
                        currentFrame--;
                        this.time = 0;

                        if (currentFrame == 0)
                        {
                            reversed = false;
                        }
                    }
                    else if (!reversed)
                    {
                        currentFrame++;
                        this.time = 0;
                    }
                }
            }

            if (currentFrame > maxFrames &&
                input == 1)
            {
                currentFrame = 1;
                reversed = true;
            }
            else if (currentFrame > maxFrames &&
                input != 1)
            {
                currentFrame = 1;
            }

            UpdateSpriteSelectRect();
        }
        private void UpdateSpriteSelectRect()
        {
            spriteSelectRect.X = currentFrame * spriteWidth;
        }
    }
}
