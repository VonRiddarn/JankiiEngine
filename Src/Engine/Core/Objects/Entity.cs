
namespace JankiiEngine;

public abstract class Entity
{
	static int _nextInstanceId = 0;

	public int InstanceId { get; set; }
	public bool IsEnabled { get; set; } = true;
	public bool IsDestroyed { get; set; } = false;

	public Entity()
	{
		InstanceId = _nextInstanceId++;
	}


	// ----- ----- -----
	//		  API
	// ----- ----- -----
	public abstract void Update();
	public virtual void OnInitialize() { }
	public abstract void OnEnable();
	public virtual void OnDestroy() { }
	public virtual void Draw(IRenderer renderer) { }
}