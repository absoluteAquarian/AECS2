using System;
using System.Collections.Generic;

namespace AECS2.Systems{
	public abstract class SystemBase : IDisposable{
		private Queue<SystemMessage> messages;
		private bool disposed;

		public SystemBase(){
			messages = new Queue<SystemMessage>();
		}

		public abstract void PreUpdate(int worldIndex);

		public abstract void Update(int entityIndex, int worldIndex);

		public abstract void PostUpdate(int worldIndex);

		public void AddMessage(int sendingSystem, object data)
			=> messages.Enqueue(new SystemMessage(sendingSystem, data));

		protected virtual void Dispose(bool disposing){
			if(!disposed){
				disposed = true;

				if(disposing)
					messages.Clear();

				messages = null;
			}
		}

		~SystemBase() => Dispose(false);

		public void Dispose(){
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
