using System;
using System.Collections;

namespace AECS2.Components{
	public struct Component{
		internal static class Cache<T>{
			private static TrackedArray<T> data;

			static Cache(){
				data = new TrackedArray<T>(4);
			}

			public static Component SetComponent(T value){
				data.Set(value, out int free);

				return new Component(){ cacheIndex = free };
			}

			public static T GetComponent(int index)
				=> data[index];

			public static bool ComponentIsSet(int index)
				=> data.HasElement(index);
		}

		internal int cacheIndex;
	}
}
