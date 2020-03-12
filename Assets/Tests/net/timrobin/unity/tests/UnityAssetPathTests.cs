using NUnit.Framework;

namespace net.timrobin.unity.tests
{
	public class UnityAssetPathTests
	{
		[Test]
		public void Returns_filename() {
			string filename = "filename";

			var file = new UnityAssetPath(filename);

			Assert.That(file.ToString(), Is.EqualTo(filename));
		}

		[Test]
		public void Returns_path() {
			string filename = "this/is/a/path";

			var file = new UnityAssetPath(filename);

			Assert.That(file.ToString(), Is.EqualTo(filename));
		}

		[TestCase("fileName")]
		[TestCase("this/is/a/path")]
		public void Adds_leading_assets_prefix(string filename) {
			var file = new UnityAssetPath(filename);

			Assert.That(file.ToString(includeAssetsPrefix: true), Is.EqualTo("Assets/" + filename));
		}

		[TestCase("fileName.fbx")]
		[TestCase("this/is/a/path.fbx")]
		public void Adds_file_extension(string filename) {
			var file = new UnityAssetPath(filename);

			Assert.That(file.ToString(includeExtension: true), Is.EqualTo(filename));
		}

		[TestCase("fileName.fbx")]
		[TestCase("this/is/a/path.fbx")]
		public void Adds_leading_assets_refix_and_file_extension(string filename) {
			var file = new UnityAssetPath(filename);

			Assert.That(file.ToString(includeAssetsPrefix:true, includeExtension: true), Is.EqualTo("Assets/" + filename));
		}

		[Test]
		public void Converts_backslashes_to_forward_slashes() {
			string filename = "this\\is\\a\\path";
			string expectedFileName = "this/is/a/path";

			var file = new UnityAssetPath(filename);

			Assert.That(file.ToString(), Is.EqualTo(expectedFileName));
		}

		[Test]
		public void Converts_mixed_slashes_to_forward_slashes() {
			string filename = "this\\is/a\\path";
			string expectedFileName = "this/is/a/path";

			var file = new UnityAssetPath(filename);

			Assert.That(file.ToString(), Is.EqualTo(expectedFileName));
		}

		[TestCase("fileName")]
		[TestCase("this/is/a/path")]
		public void Strips_leading_assets_prefix(string filename) {
			var file = new UnityAssetPath("Assets/" + filename);

			Assert.That(file.ToString(), Is.EqualTo(filename));
		}

		[TestCase("fileName")]
		[TestCase("this/is/a/path")]
		public void Doesnt_double_add_leading_assets_prefix(string filename) {
			var file = new UnityAssetPath("Assets/" + filename);

			Assert.That(file.ToString(includeAssetsPrefix: true), Is.EqualTo("Assets/" + filename));
		}

		[TestCase("fileName")]
		[TestCase("this/is/a/path")]
		public void Strips_file_extension(string filename) {
			var file = new UnityAssetPath(filename + ".fbx");

			Assert.That(file.ToString(), Is.EqualTo(filename));
		}

		[Test]
		public void Adds_period_to_file_extension() {
			var file = new UnityAssetPath("file", "fbx");

			Assert.That(file.ToString(includeExtension:true), Is.EqualTo("file.fbx"));
		}

		[Test]
		public void Doesnt_double_add_period_to_file_extension() {
			var file = new UnityAssetPath("file", ".fbx");

			Assert.That(file.ToString(includeExtension:true), Is.EqualTo("file.fbx"));
		}
	}
}