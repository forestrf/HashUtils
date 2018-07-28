namespace HashUtils {
	public class Crc32 {
		public static readonly Crc32 CRC32 = new Crc32(0xedb88320);
		public static readonly Crc32 CRC32C = new Crc32(0x82f63b78);

		private readonly uint[] _table = new uint[256];

		public Crc32(uint poly) {
			for (uint i = 0; i < 256; i++) {
				uint res = i;
				for (int k = 0; k < 8; k++) res = (res & 1) == 1 ? poly ^ (res >> 1) : (res >> 1);
				_table[i] = res;
			}
		}

		public uint Calculate(byte[] buffer, int offset, int length) {
			uint crc = ~0u;
			while (--length >= 0)
				crc = _table[(crc ^ buffer[offset++]) & 0xff] ^ crc >> 8;
			return crc ^ 0xffffffff;
		}
	}
}
