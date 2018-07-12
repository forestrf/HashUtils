using BBuffer;
using System;
using System.Text;

namespace HashUtils {
	public static class HMAC_SHA1 {
		public static int KEY_BYTE_LENGTH = 1024;

		[ThreadStatic]
		private static byte[] keyBytes, tmp1, tmp2, tmp3;
		[ThreadStatic]
		private static int keyLength;
		[ThreadStatic]
		private static uint[] tmp4;

		public static void ComputeHmacSha1(string key, ByteBuffer data, byte[] dst, int dstOffset) {
			if (null == keyBytes) keyBytes = new byte[KEY_BYTE_LENGTH];
			keyLength = Encoding.UTF8.GetBytes(key, 0, key.Length, keyBytes, 0);
			ComputeHmacSha1(new ByteBuffer(keyBytes, 0, keyLength), data, dst, dstOffset);
		}

		public static void ComputeHmacSha1(ByteBuffer key, ByteBuffer data, byte[] dst, int dstOffset) {
			SHA.ComputeHMAC_SHA1(key, data, new ByteBuffer(dst, dstOffset, 20), ref tmp1, ref tmp2, ref tmp3, ref tmp4);
		}

		public static void ComputeHmacSha256(string key, ByteBuffer data, byte[] dst, int dstOffset) {
			if (null == keyBytes) keyBytes = new byte[KEY_BYTE_LENGTH];
			keyLength = Encoding.UTF8.GetBytes(key, 0, key.Length, keyBytes, 0);
			ComputeHmacSha256(new ByteBuffer(keyBytes, 0, keyLength), data, dst, dstOffset);
		}

		public static void ComputeHmacSha256(ByteBuffer key, ByteBuffer data, byte[] dst, int dstOffset) {
			SHA.ComputeHMAC_SHA256(key, data, new ByteBuffer(dst, dstOffset, 32), ref tmp1, ref tmp2, ref tmp3, ref tmp4);
		}

		public static void ComputeSHA1(byte[] input, int inputLength, byte[] output20, int outputOffset) {
			SHA.ComputeSHA1(input, inputLength, output20, outputOffset, ref tmp1, ref tmp4);
		}

		public static void ComputeSHA256(byte[] input, int inputLength, byte[] output32, int outputOffset) {
			SHA.ComputeSHA256(input, inputLength, output32, outputOffset, ref tmp1, ref tmp4);
		}
	}
}
