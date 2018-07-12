using NUnit.Framework;

namespace HashUtils.Tests {
	[TestFixture]
	public class CrcTest {
		private static readonly string loremIpsum = 
			"Lorem ipsum dolor sit amet, consectetur adipiscing elit.Quisque scelerisque diam ac lectus tristique scelerisque.Nullam commodo accumsan elementum.Nullam non aliquam felis.Praesent commodo magna id ex ultricies lobortis.Aenean tincidunt a leo sed accumsan. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Fusce iaculis augue in viverra tempor." +
			"Integer mattis ipsum eu dolor auctor, et tristique diam scelerisque. Duis volutpat pretium orci, eu porta nibh molestie ac.Praesent imperdiet quam et posuere rutrum. Morbi fermentum faucibus purus, dictum blandit nisl molestie ut.Nullam ac scelerisque odio. Vestibulum imperdiet vitae turpis quis laoreet. Nullam eu condimentum enim, euismod bibendum risus.Donec bibendum felis nisi, at rhoncus leo venenatis quis.Duis scelerisque malesuada facilisis. Mauris laoreet metus neque, pellentesque porta lectus convallis quis.Aenean vestibulum ultrices felis eu fermentum. Aliquam commodo nec mauris sit amet vehicula.Aenean id ipsum eu massa hendrerit placerat.Sed vestibulum diam at tellus hendrerit, ac sagittis enim consequat. Curabitur hendrerit ac dolor egestas ultrices. Cras eu nulla viverra purus rutrum rutrum non ac arcu." +
			"Nullam sed justo eget nisl posuere bibendum.Vestibulum egestas purus quis tincidunt pellentesque. Quisque dolor diam, imperdiet in congue vitae, fermentum et ex.Cras ac erat erat. Nulla facilisi. Ut vel gravida turpis. Curabitur eleifend porttitor dolor ac interdum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur posuere mi ut egestas mattis.Curabitur vitae ante libero.Maecenas ornare diam lorem. Cras placerat finibus purus ut sollicitudin. Fusce vel lorem enim. Maecenas ac gravida sem, sed interdum sapien.Morbi suscipit orci justo, eget laoreet turpis semper non.Mauris finibus est ut elit dictum, id hendrerit lectus ornare." +
			"Nulla porta auctor orci et accumsan. Praesent augue quam, pretium vel diam at, consequat placerat ante.Fusce sollicitudin condimentum iaculis. Praesent sapien elit, fermentum non diam quis, aliquet pretium dui.Nam molestie tincidunt mauris nec pretium. Suspendisse eu metus nibh. Aenean et turpis vel augue ultrices hendrerit eu pharetra nulla. Integer a ultricies nibh. Phasellus ac tellus erat. Pellentesque semper purus ut leo egestas, vitae vehicula dui molestie. Sed ut tortor et ipsum egestas hendrerit eget eu purus. Vivamus sed pharetra ex. Nullam rhoncus commodo ornare. Integer non consequat tellus." +
			"Morbi sodales enim aliquam neque sagittis, vitae accumsan lectus rhoncus. Quisque gravida pretium dolor non ultrices. Etiam facilisis scelerisque sem, nec ornare felis lacinia non.Ut mollis posuere magna quis semper. Ut vitae sem semper, iaculis dolor sit amet, lacinia lorem. Fusce bibendum egestas ultrices. Integer consequat posuere varius. Sed a lectus elit. Fusce ullamcorper suscipit auctor. Nullam eu porta magna, vitae interdum odio.Vestibulum convallis diam nulla, sed pharetra est ultrices eget.Nam ut sapien vehicula, tempor risus eu, imperdiet metus. Aenean faucibus diam id elit iaculis, molestie tincidunt magna mattis. Fusce ut velit at eros lacinia semper.Vestibulum ac iaculis diam. Sed in mi a nunc venenatis malesuada sed non lectus. ";

		[Test]
		public void TestLargeStringCrc32() {
			var bytes = System.Text.Encoding.UTF8.GetBytes(loremIpsum);
			Assert.AreEqual(3218680538u, Crc32.CRC32.Calculate(bytes, 0, bytes.Length));
			Assert.AreEqual(2106602027u, Crc32.CRC32.Calculate(bytes, 1, bytes.Length - 1));
			Assert.AreEqual(2563173001u, Crc32.CRC32.Calculate(bytes, 1, bytes.Length - 2));
		}

		[Test]
		public void TestLargeStringCrc32c() {
			var bytes = System.Text.Encoding.UTF8.GetBytes(loremIpsum);
			Assert.AreEqual(3305283819u, Crc32.CRC32C.Calculate(bytes, 0, bytes.Length));
			Assert.AreEqual(1948601350u, Crc32.CRC32C.Calculate(bytes, 1, bytes.Length - 1));
			Assert.AreEqual(4193828646u, Crc32.CRC32C.Calculate(bytes, 1, bytes.Length - 2));
		}
	}
}
