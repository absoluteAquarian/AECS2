using AECS2.Worlds;

namespace AECS2.Enitities{
	public struct Entity{
		public static class Cache{
			public static T GetComponent<T>(int worldIndex, int entityIndex){
				World world = World.WorldTable.GetWorld(worldIndex);

				
			}

			public static Entity CreateEntity(int worldIndex){
				//Ensure that the world is valid
				World world = World.WorldTable.GetWorld(worldIndex);

				Entity entity = new(){ id = nextID++ };

				world.AddEntity(ref entity);

				return entity;
			}
		}

		internal int id;
		private static int nextID = 1;

		internal int tableIndex;

		public int ID => id;

		public override bool Equals(object obj)
			=> obj is Entity entity && id == entity.id;

		public override int GetHashCode() => id;

		public override string ToString() => $"Entity #{id}";

		public static bool operator ==(Entity first, Entity second)
			=> first.id == second.id;

		public static bool operator !=(Entity first, Entity second)
			=> first.id != second.id;
	}
}
