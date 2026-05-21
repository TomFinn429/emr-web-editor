using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Runtime.InteropServices.JavaScript;

[SupportedOSPlatform("browser")]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class JSMarshalerType
{
	internal JSFunctionBinding.JSBindingType _signatureType;

	[CompilerGenerated]
	private static readonly JSMarshalerType _003CVoid_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Void
	});

	[CompilerGenerated]
	private static readonly JSMarshalerType _003CChar_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Char
	});

	[CompilerGenerated]
	private static readonly JSMarshalerType _003CInt16_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Int16
	});

	[CompilerGenerated]
	private static readonly JSMarshalerType _003CInt52_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Int52
	});

	[CompilerGenerated]
	private static readonly JSMarshalerType _003CBigInt64_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.BigInt64
	});

	[CompilerGenerated]
	private static readonly JSMarshalerType _003CDateTimeOffset_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.DateTimeOffset
	});

	[CompilerGenerated]
	private static readonly JSMarshalerType _003C_task_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Task
	});

	[CompilerGenerated]
	private static readonly JSMarshalerType _003C_action_003Ek__BackingField = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Action
	});

	public static JSMarshalerType Discard { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Discard
	});

	public static JSMarshalerType Boolean { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Boolean
	});

	public static JSMarshalerType Byte { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Byte
	});

	public static JSMarshalerType Int32 { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Int32
	});

	public static JSMarshalerType Double { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Double
	});

	public static JSMarshalerType Single { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Single
	});

	public static JSMarshalerType IntPtr { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.IntPtr
	});

	public static JSMarshalerType JSObject { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.JSObject
	});

	public static JSMarshalerType Object { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Object
	});

	public static JSMarshalerType String { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.String
	});

	public static JSMarshalerType Exception { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.Exception
	});

	public static JSMarshalerType DateTime { get; } = new JSMarshalerType(new JSFunctionBinding.JSBindingType
	{
		Type = MarshalerType.DateTime
	});

	private JSMarshalerType(JSFunctionBinding.JSBindingType P_0)
	{
		_signatureType = P_0;
	}

	public static JSMarshalerType Task(JSMarshalerType P_0)
	{
		CheckTask(P_0);
		return new JSMarshalerType(new JSFunctionBinding.JSBindingType
		{
			Type = MarshalerType.Task,
			ResultMarshalerType = P_0._signatureType.Type
		});
	}

	public static JSMarshalerType Array(JSMarshalerType P_0)
	{
		CheckArray(P_0);
		return new JSMarshalerType(new JSFunctionBinding.JSBindingType
		{
			Type = MarshalerType.Array,
			Arg1MarshalerType = P_0._signatureType.Type
		});
	}

	public static JSMarshalerType Span(JSMarshalerType P_0)
	{
		CheckArraySegment(P_0);
		return new JSMarshalerType(new JSFunctionBinding.JSBindingType
		{
			Type = MarshalerType.Span,
			Arg1MarshalerType = P_0._signatureType.Type
		});
	}

	internal static void CheckArray(JSMarshalerType P_0)
	{
		MarshalerType type = P_0._signatureType.Type;
		if (type == MarshalerType.Byte || type == MarshalerType.Int32 || type == MarshalerType.Double || type == MarshalerType.String || type == MarshalerType.Object || type == MarshalerType.JSObject)
		{
			return;
		}
		throw new ArgumentException("Bad array element type");
	}

	internal static void CheckArraySegment(JSMarshalerType P_0)
	{
		MarshalerType type = P_0._signatureType.Type;
		if (type == MarshalerType.Byte || type == MarshalerType.Int32 || type == MarshalerType.Double)
		{
			return;
		}
		throw new ArgumentException("Bad array element type");
	}

	internal static void CheckTask(JSMarshalerType P_0)
	{
		MarshalerType type = P_0._signatureType.Type;
		if (type == MarshalerType.Array || type == MarshalerType.ArraySegment || type == MarshalerType.Span || type == MarshalerType.Task || type == MarshalerType.Action || type == MarshalerType.Function)
		{
			throw new ArgumentException("Bad task result type");
		}
	}
}
