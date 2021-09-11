using System;
using System.Collections;

namespace AECS2{
	internal sealed class TrackedArray<T> : IDisposable{
		private T[] data;
		private BitArray hasElement;
		private bool disposed;

		public TrackedArray(int initialCapacity){
			if(initialCapacity < 0)
				throw new ArgumentException("Initial capacity was too small", nameof(initialCapacity));

			data = initialCapacity == 0 ? Array.Empty<T>() : new T[initialCapacity];
			hasElement = new BitArray(initialCapacity);
		}

		public int Length => data.Length;

		public int Count{ get; private set; }

		public T this[int index] => hasElement.Get(index) ? data[index] : default;

		public void Set(T value, out int freeIndex){
			freeIndex = FindFreeIndex();
			if(freeIndex < 0){
				freeIndex = Count;
				Array.Resize(ref data, Count * 2);
				hasElement.Length = hasElement.Count * 2;
			}

			data[freeIndex] = value;
			hasElement.Set(freeIndex, true);

			Count++;
		}

		public bool HasElement(int index)
			=> hasElement.Get(index);

		private int FindFreeIndex(){
			for(int i = 0; i < hasElement.Count; i++)
				if(!hasElement.Get(i))
					return i;

			return -1;
		}

		private void Dispose(bool disposing){
			if(!disposed){
				disposed = true;

				if(disposing){
					T t = default;
					if(t is IDisposable){
						for(int i = 0; i < Length; i++)
							if(hasElement.Get(i))
								(data[i] as IDisposable).Dispose();
					}
				}

				data = null;
				hasElement = null;
			}
		}

		~TrackedArray() => Dispose(false);

		public void Dispose(){
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
