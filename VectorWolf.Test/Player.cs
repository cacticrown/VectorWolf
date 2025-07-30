using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorWolf.Collisions;
using VectorWolf.Graphics.Renderers;
using VectorWolf.Graphics;
using VectorWolf.Utils;
using Microsoft.Xna.Framework;

namespace VectorWolf.Test;

public class Player : Entity
{
    private Texture2D _pixel;

    public Rectangle Rect = new Rectangle(0, 0, 50, 50);
    public Color Color = Color.Black;

    public RectangleCollider Collider = new RectangleCollider();

    public float Speed = 150f;

    public override void OnSceneStart()
    {
        _pixel = new Texture2D(RenderContext.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        Collider.Size = new Vector2(Rect.Width, Rect.Height);
        AddComponent(Collider);
    }

    public override void Update()
    {
        if (Input.KeyDown(Keys.D))
        {
            Position.X += Speed * Time.DeltaTime;
        }
        if (Input.KeyDown(Keys.A))
        {
            Position.X -= Speed * Time.DeltaTime;
        }
        if (Input.KeyDown(Keys.W))
        {
            Position.Y -= Speed * Time.DeltaTime;
        }
        if (Input.KeyDown(Keys.S))
        {
            Position.Y += Speed * Time.DeltaTime;
        }

        Rect.X = (int)Position.X;
        Rect.Y = (int)Position.Y;
    }

    public override void Draw()
    {
        RenderContext.SpriteBatch.Draw(_pixel, Rect, Color);
    }
}
