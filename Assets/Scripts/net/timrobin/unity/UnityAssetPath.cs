using System.IO;
using net.timrobin.extensions;

namespace net.timrobin.unity {
	public struct UnityAssetPath {
		private readonly string path;
		private readonly string fileExtension;

		public UnityAssetPath(string pathIncludingExtension) : this(
			Path.ChangeExtension(pathIncludingExtension, null),
			Path.GetExtension(pathIncludingExtension)
		) { }

		public UnityAssetPath(string path, string fileExtension) {
			this.path = trim_leading_assets_prefix(path);
			this.fileExtension = add_leading_period(fileExtension);
		}

		private static string trim_leading_assets_prefix(string path) {
			path = path.replace_backslashes_with_forward_slashes();

			var pathParts = path.Split('/');

			if (pathParts.Length > 0 && pathParts[0] == "Assets") {
				path = string.Join("/", pathParts, 1, pathParts.Length - 1);
			}

			return path;
		}

		private static string add_leading_period(string extension) {
			if (extension.Length > 0 && extension[0] != '.') {
				return "." + extension;
			}
			else {
				return extension;
			}
		}

		public string ToString(bool includeAssetsPrefix = false, bool includeExtension = false) {
			string result = path;

			if (includeAssetsPrefix) {
				result = "Assets/" + path;
			}

			if (includeExtension) {
				result += fileExtension;
			}

			return result;
		}

		public string ToDebugString() {
			return $"[{GetType()}: {ToString(true, true)}]";
		}
	}
}