using System.Collections.Generic;

namespace AECS2.Systems{
	public abstract class SystemBase{
		private Queue<SystemMessage> messages;

		public SystemBase(){
			messages = new Queue<SystemMessage>();
		}

		public abstract void PreUpdate(int worldIndex);

		public abstract void Update(int entityIndex, int worldIndex);

		public abstract void PostUpdate(int worldIndex);

		public void AddMessage(SystemMessage message)
			=> messages.Enqueue(message);

		public void AddMessage(object data)
			=> messages.Enqueue(new SystemMessage(data));
	}
}
