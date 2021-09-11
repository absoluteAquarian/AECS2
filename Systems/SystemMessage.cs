namespace AECS2.Systems{
	public struct SystemMessage{
		public readonly object data;
		public readonly int sourceSystem;

		public SystemMessage(int srcSystem, object data){
			sourceSystem = srcSystem;
			this.data = data;
		}
	}
}
