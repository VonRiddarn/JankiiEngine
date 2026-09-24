
namespace JankiiEngine;

public abstract class Entity
{
	static Game? _currentGame = null;
	static int _nextInstanceId = 0;

	public int InstanceId { get; set; }
	public bool IsEnabled { get; set; } = true;
	public bool IsDestroyed { get; private set; } = false;

	public Entity()
	{
		InstanceId = _nextInstanceId++;
	}

	public void Destroy()
	{
		IsDestroyed = true;
	}

	public static Entity Instantiate(Entity entity)
	{
		_currentGame?.Instantiate_Entity_Internal(entity);
		return entity;
	}

	public static Entity Destroy(Entity entity)
	{
		entity.OnDestroy();
		_currentGame?.Destroy_Entity_Internal(entity);
		return entity;
	}

	internal static void Set_Game_Internal(Game game) => _currentGame = game;

	// ----- ----- -----
	//		  API
	// ----- ----- -----
	public abstract void OnEnable();
	public abstract void OnDisable();
	public abstract void Update();
	public virtual void OnInitialize() { }
	public virtual void OnDestroy() { }
	public virtual void Draw(IRenderer renderer) { }
}