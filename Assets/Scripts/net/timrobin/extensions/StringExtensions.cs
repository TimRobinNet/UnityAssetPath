namespace net.timrobin.extensions {
	public static class StringExtensions {
		public static string replace_backslashes_with_forward_slashes(this string s) {
			return s.Replace('\\', '/');
		}
	}
}