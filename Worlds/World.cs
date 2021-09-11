using AECS2.Components;
using AECS2.Enitities;
using AECS2.Systems;
using System;
using System.Collections;

namespace AECS2.Worlds{
	public sealed class World{
		public static class WorldTable{
			internal static World[] worlds;

			public static World DefaultWorld => worlds?.Length > 0 ? worlds[0] : throw new InvalidOperationException("World table has not been initialized");

			public static World GetWorld(int index){
				if(worlds is null)
					throw new InvalidOperationException("World table has not been initialized");

				if(index < 0 || index >= worlds.Length)
					throw new IndexOutOfRangeException("World index was outside the range of valid values");

				World world = worlds[index];

				return world ?? throw new NullReferenceException("World has not been initialized yet");
			}
		}

		internal TrackedArray<Entity> entityTable;
		internal TrackedArray<Component> componentTable;
		internal TrackedArray<SystemBase> systemTable;

		public World(){
			entityTable = new TrackedArray<Entity>(8);
			componentTable = new TrackedArray<Component>(8);
			systemTable = new TrackedArray<SystemBase>(8);
		}

		internal void AddEntity(ref Entity entity){
			entityTable.Set(entity, out int freeIndex);
			entity.tableIndex = freeIndex;
		}

		public bool HasEntity(Entity entity){
			for(int i = 0; i < entityTable.Length; i++){
				if(entityTable[i] == entity)
					return true;
			}

			return false;
		}
	}
}
