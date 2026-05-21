namespace System.Text.Json;

internal static class AppContextSwitchHelper
{
	private static readonly bool s_isSourceGenReflectionFallbackEnabled = AppContext.TryGetSwitch("System.Text.Json.Serialization.EnableSourceGenReflectionFallback", out var flag) && flag;

	public static bool IsSourceGenReflectionFallbackEnabled => s_isSourceGenReflectionFallbackEnabled;
}
