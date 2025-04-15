using SFML.System;
using SFML.Window;

using static PhysicsSim.Globals;

namespace PhysicsSim;

public static class Input
{
    public static bool MOUSE_LEFT_BTN_PRESSED = false;
    public static Vector2f MOUSE_POS = new Vector2f(0.0f, 0.0f);
    
    public static void Window_KeyPressed(object sender, KeyEventArgs eventArgs)
	{
		var window = (Window)sender;
			
		switch(eventArgs.Code)
		{
			case Keyboard.Key.Escape:
				window.Close();
				break;
		}
	}
    
    public static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs eventArgs)
	{
		var window = (Window)sender;
		
		switch(eventArgs.Button)
		{
			case Mouse.Button.Left:
                MOUSE_LEFT_BTN_PRESSED = true;
				if (ACTIVE_ENTITY == null && (DateTime.Now - ACTIVE_ENTITY_LAST_SET).TotalMilliseconds > 100)
				{
                    Vector2f mousePos = Mouse.GetPosition(window).ToWorldSpace();
					SelectEntity(mousePos);
					ACTIVE_ENTITY_LAST_SET = DateTime.Now;
				}
				break;
		}
	}
	
	public static void Window_MouseButtonReleased(object sender, MouseButtonEventArgs eventArgs)
	{
		switch(eventArgs.Button)
		{
			case Mouse.Button.Left:
                MOUSE_LEFT_BTN_PRESSED = false;
                ACTIVE_ENTITY = null;
                ACTIVE_ENTITY_LAST_SET = DateTime.Now;
				break;
		}
	}
    
    public static bool SelectEntity(Vector2f mousePos)
    {       
        for (int i = 0; i < ENTITIES.Count; i++)
        {
            if (ENTITIES[i].IsInside(mousePos))
            {
                ACTIVE_ENTITY = ENTITIES[i];
                Console.WriteLine($"Selected entity: {i}");
                return true;
            }
        }
        
        return false;
    }
}