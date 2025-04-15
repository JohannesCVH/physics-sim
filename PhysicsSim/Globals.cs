namespace PhysicsSim;

internal static class Globals
{
	public const int WINDOW_WIDTH = 768;
	public const int WINDOW_HEIGHT = 768;
	public const int WINDOW_WIDTH_HALF = WINDOW_WIDTH / 2;
	public const int WINDOW_HEIGHT_HALF = WINDOW_HEIGHT / 2;
	public static float WINDOW_ASPECT = (float)WINDOW_WIDTH / WINDOW_HEIGHT;
	public const float WORLD_SIZE = 100.0f;
	public static bool ENABLE_ROTATION = false;
	public static DateTime SETTING_CHANGE_LAST_UPDATED = DateTime.Now;

    public static List<Entity> ENTITIES = new List<Entity>();
    public static Entity? ACTIVE_ENTITY = null;
    public static DateTime ACTIVE_ENTITY_LAST_SET = DateTime.Now;
}