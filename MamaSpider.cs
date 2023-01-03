using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Silent_Void
{
    class MamaSpider : Spider
    {
        public static new Texture2D texture;
        public MamaSpider(Vector2 pos, float rad) : base(texture, pos, rad)
        {
            base.size = new Vector2(72, 72);
            hitBoxSize = size - new Vector2(10, 10);
            base.hp = 3;
            base.speed = 7;
        }

        public override void OnDeath()
        {
            for (int i = 0; i < 3; i++)
            {
                Spider spider = new Spider(this.pos, (float)(Enemy.rnd.NextDouble() * Math.PI * 2));
                spider.vel = new Vector2((float)Math.Cos(spider.rad), (float)Math.Sin(spider.rad)) * spider.speed;
                game.planes.Add(spider);
            }
            base.OnDeath();
        }
        public override void OnHit()
        {
            Spider spider = new Spider(this.pos, (float)(Enemy.rnd.NextDouble() * Math.PI * 2));
            spider.vel = new Vector2((float)Math.Cos(spider.rad), (float)Math.Sin(spider.rad)) * spider.speed;
            game.planes.Add(spider);
            base.OnHit();
        }
    }
}