using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorWolf.Collisions;
using VectorWolf.Graphics;
using VectorWolf.Utils;

namespace VectorWolf.Test;

public class Coin : Entity
{
    private Texture2D _pixel;

    public Rectangle Rect = new Rectangle(0, 0, 35, 35);
    public Color Color = Color.Gold;

    public RectangleCollider Collider = new RectangleCollider();

    public const float Speed = 150f;
    Player Player;

    public override void OnSceneStart()
    {
        _pixel = new Texture2D(RenderContext.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        Player = Scene.GetEntity<Player>();

        AddComponent(Collider);
    }

    public override void Update()
    {
        Collider.Size = new Vector2(Rect.Width, Rect.Height);
        Collider.Entity = this;

        if (Collider.CollideWith(Player.Collider))
        {
            while (Collider.CollideWith(Player.Collider))
                Position = new Vector2(Randomizer.Randomize(-200, 200), Randomizer.Randomize(-150, 150));
        }
    }

    public override void Draw()
    {
        Rect.X = (int)Position.X;
        Rect.Y = (int)Position.Y;
        RenderContext.SpriteBatch.Draw(_pixel, Rect, Color);
    }
}
