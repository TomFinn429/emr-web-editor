using System.Runtime.Versioning;
using System.Threading.Tasks;
using zzz;

namespace DCSoft.WASM;

[SupportedOSPlatform("browser")]
internal class Prograss
{
	public static void BuildStringsCode()
	{
	}

	public static void BuildDCSRCode()
	{
	}

	public static async Task Main(string[] args)
	{
		z0ZzZzjpj z0ZzZzjpj = z0ZzZzjpj.z0eek(args);
		z0ZzZzkpj b2 = z0ZzZzjpj.z0rek();
		await z0ZzZzroj.z0uek(z0ZzZzjpj.z0tek().z0oz_jiejie20260327142557());
		WASMStarter.z0iek();
		Task task = b2.z0eek();
		z0ZzZzimk.z0krk = z0ZzZzroj.z0oek();
		z0ZzZzpij.z0eek(z0ZzZzimk.z0krk);
		WriterControlForWASM.z0byk = WASMJSRuntime.z0rek;
		z0ZzZzboj.z0rek(WriterControlForWASM.z0byk);
		z0ZzZzroj.z0eek();
		await task;
	}
}
