namespace PhysicsSim;

internal class Program
{
	static void Main(string[] args)
	{	
		using (var re = new Renderer(800, 600, "Renderer OpenGL"))
		{
			re.Run();
		}
	}
}