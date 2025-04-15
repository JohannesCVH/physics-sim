using SFML.Graphics;
using SFML.System;
using SFML.Window;

using static PhysicsSim.Globals;
using static PhysicsSim.Input;

namespace PhysicsSim;

internal class Program
{
	static void Main(string[] args)
	{	
		var videoMode = new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT);
		var window = new RenderWindow(videoMode, "Hello Physics Sim");
		View view = new View(new Vector2f(0f,0f), new Vector2f(WORLD_SIZE*2, WORLD_SIZE*2));
		window.SetView(view);
		window.SetFramerateLimit(30);
		window.SetVerticalSyncEnabled(true);
		window.KeyPressed += Window_KeyPressed!;
		window.MouseButtonPressed += Window_MouseButtonPressed!;
		window.MouseButtonReleased += Window_MouseButtonReleased!;
		
		// ENTITIES.Add(new EntityCircle(new Vector2f(-50.0f, 0.0f), 15f));
		// ENTITIES[0].Velocity = new Vector2f(-1.0f, 1.0f);
		
		Random rand = new Random();
		for (int i = 0; i < 20; i++)
		{
			ENTITIES.Add(new EntityCircle(new Vector2f(rand.Next(-(int)WORLD_SIZE, (int)WORLD_SIZE), rand.Next(-(int)WORLD_SIZE, (int)WORLD_SIZE)), rand.Next(5, 10)));
			ENTITIES[i].Velocity = new Vector2f((float)rand.NextDouble() * 2 - 1, (float)rand.NextDouble() * 2 - 1);
		}
		
		while (window.IsOpen)
		{
			window.DispatchEvents();
			window.Clear();
			
			if (MOUSE_LEFT_BTN_PRESSED && ACTIVE_ENTITY != null)
			{
				Vector2f mousePos = Mouse.GetPosition(window).ToWorldSpace();
				ACTIVE_ENTITY!.Position = mousePos;
				// Console.WriteLine($"Entity Pos: {ACTIVE_ENTITY.Position}");
			}
			
			for (int i = 0; i < ENTITIES.Count; i++)
			{
				ENTITIES[i].Update();
				
				var norm = ENTITIES[i].Position.Normalize();
				var sp = norm.ToScreenSpace();
				window.Draw(ENTITIES[i].Generate(sp));
			}
			
			window.Display();
		}
	}
}