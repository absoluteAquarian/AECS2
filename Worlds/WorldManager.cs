using AECS2.Enitities;

namespace AECS2.Worlds{
	public static class WorldManager{
		public class WorldInfo{
			public Entity[] entities;

		}

		public static WorldInfo[] worlds;

		public static WorldInfo DefaultWorld => worlds?.Length > 0 ? worlds[0] : null;
	}
}
