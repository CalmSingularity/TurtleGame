using System;
using Microsoft.SmallBasic.Library;

namespace TurtleGame
{
	class Program
	{
		static void Main(string[] args)
		{
			GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
			Turtle.PenUp();
			Turtle.Speed = 2;

			GraphicsWindow.BrushColor = "Red";
			int mealSize = 10;
			var meal = Shapes.AddRectangle(mealSize, mealSize);
			int mealX = 200, mealY = 200;
			Shapes.Move(meal, mealX, mealY);

			Random rand = new Random();

			while (true)
			{
				Turtle.Move(10);

				// check if Turtle collides with meal:
				if (Turtle.X >= mealX && Turtle.X <= mealX + mealSize 
					&& Turtle.Y >= mealY && Turtle.Y <= mealY + mealSize)
				{
					mealX = rand.Next(0, GraphicsWindow.Width);
					mealY = rand.Next(0, GraphicsWindow.Height);
					Shapes.Move(meal, mealX, mealY);  // move meal away from Turtle
					Turtle.Speed++;
				}
			}
		}

		private static void GraphicsWindow_KeyDown()
		{
			if (GraphicsWindow.LastKey == "Up")
			{
				Turtle.Angle = 0;
			}
			else if (GraphicsWindow.LastKey == "Right")
			{
				Turtle.Angle = 90;
			}
			else if (GraphicsWindow.LastKey == "Down")
			{
				Turtle.Angle = 180;
			}
			else if (GraphicsWindow.LastKey == "Left")
			{
				Turtle.Angle = 270;
			}
			
		}
	}
}
