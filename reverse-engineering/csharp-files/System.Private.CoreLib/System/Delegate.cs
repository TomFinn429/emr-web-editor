using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System;

[StructLayout((LayoutKind)0)]
public abstract class Delegate : ICloneable, ISerializable
{
	private nint method_ptr;

	private nint invoke_impl;

	private object _target;

	private nint method;

	private nint delegate_trampoline;

	private nint extra_arg;

	private nint method_code;

	private nint interp_method;

	private nint interp_invoke_impl;

	private MethodInfo method_info;

	private MethodInfo original_method_info;

	private DelegateData data;

	private bool method_is_virtual;

	private bool bound;

	public MethodInfo Method => GetMethodImpl();

	public static Delegate CreateDelegate(Type P_0, object? P_1, MethodInfo P_2, bool P_3)
	{
		return CreateDelegate(P_0, P_1, P_2, P_3, true);
	}

	public static Delegate? CreateDelegate(Type P_0, MethodInfo P_1, bool P_2)
	{
		return CreateDelegate(P_0, null, P_1, P_2, false);
	}

	private static Delegate CreateDelegate(Type P_0, object P_1, MethodInfo P_2, bool P_3, bool P_4)
	{
		ArgumentNullException.ThrowIfNull(P_0, "type");
		ArgumentNullException.ThrowIfNull(P_2, "method");
		RuntimeType runtimeType = P_0 as RuntimeType;
		if ((object)runtimeType == null)
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "type");
		}
		if (!(P_2 is RuntimeMethodInfo) && !(P_2 is DynamicMethod))
		{
			throw new ArgumentException("Argument_MustBeRuntimeMethodInfo", "method");
		}
		if (!runtimeType.IsDelegate())
		{
			throw new ArgumentException("Arg_MustBeDelegate", "type");
		}
		if (!IsMatchingCandidate(runtimeType, P_1, P_2, P_4, out var delegateData))
		{
			if (P_3)
			{
				throw new ArgumentException("Arg_DlgtTargMeth");
			}
			return null;
		}
		Delegate obj = CreateDelegate_internal(new QCallTypeHandle(ref runtimeType), P_1, P_2, P_3);
		if (obj != null)
		{
			obj.original_method_info = P_2;
			obj.data = delegateData;
		}
		return obj;
	}

	private static bool IsMatchingCandidate(RuntimeType P_0, object P_1, MethodInfo P_2, bool P_3, out DelegateData P_4)
	{
		MethodInfo delegateInvokeMethod = GetDelegateInvokeMethod(P_0);
		if (delegateInvokeMethod == null || !IsReturnTypeMatch(delegateInvokeMethod.ReturnType, P_2.ReturnType))
		{
			P_4 = null;
			return false;
		}
		ParameterInfo[] parametersInternal = delegateInvokeMethod.GetParametersInternal();
		ParameterInfo[] parametersInternal2 = P_2.GetParametersInternal();
		bool flag;
		if (P_1 != null)
		{
			flag = (P_2.IsStatic ? (parametersInternal2.Length == parametersInternal.Length + 1) : (parametersInternal2.Length == parametersInternal.Length));
		}
		else if (!P_2.IsStatic)
		{
			flag = parametersInternal2.Length + 1 == parametersInternal.Length;
			if (!flag)
			{
				flag = parametersInternal2.Length == parametersInternal.Length;
			}
		}
		else
		{
			flag = parametersInternal2.Length == parametersInternal.Length;
			if (!flag)
			{
				flag = parametersInternal2.Length == parametersInternal.Length + 1;
			}
		}
		if (!flag)
		{
			P_4 = null;
			return false;
		}
		P_4 = new DelegateData();
		bool flag2;
		if (P_1 != null)
		{
			if (!P_2.IsStatic)
			{
				flag2 = IsArgumentTypeMatchWithThis(P_1.GetType(), P_2.DeclaringType, true);
				for (int i = 0; i < parametersInternal2.Length; i++)
				{
					flag2 &= IsArgumentTypeMatch(parametersInternal[i].ParameterType, parametersInternal2[i].ParameterType);
				}
			}
			else
			{
				flag2 = IsArgumentTypeMatch(P_1.GetType(), parametersInternal2[0].ParameterType);
				for (int j = 1; j < parametersInternal2.Length; j++)
				{
					flag2 &= IsArgumentTypeMatch(parametersInternal[j - 1].ParameterType, parametersInternal2[j].ParameterType);
				}
				P_4.curried_first_arg = true;
			}
		}
		else if (!P_2.IsStatic)
		{
			if (parametersInternal2.Length + 1 == parametersInternal.Length)
			{
				flag2 = IsArgumentTypeMatchWithThis(parametersInternal[0].ParameterType, P_2.DeclaringType, false);
				for (int k = 0; k < parametersInternal2.Length; k++)
				{
					flag2 &= IsArgumentTypeMatch(parametersInternal[k + 1].ParameterType, parametersInternal2[k].ParameterType);
				}
			}
			else
			{
				flag2 = P_3;
				for (int l = 0; l < parametersInternal2.Length; l++)
				{
					flag2 &= IsArgumentTypeMatch(parametersInternal[l].ParameterType, parametersInternal2[l].ParameterType);
				}
			}
		}
		else if (parametersInternal.Length + 1 == parametersInternal2.Length)
		{
			flag2 = !parametersInternal2[0].ParameterType.IsValueType && !parametersInternal2[0].ParameterType.IsByRef && P_3;
			for (int m = 0; m < parametersInternal.Length; m++)
			{
				flag2 &= IsArgumentTypeMatch(parametersInternal[m].ParameterType, parametersInternal2[m + 1].ParameterType);
			}
			P_4.curried_first_arg = true;
		}
		else
		{
			flag2 = true;
			for (int n = 0; n < parametersInternal2.Length; n++)
			{
				flag2 &= IsArgumentTypeMatch(parametersInternal[n].ParameterType, parametersInternal2[n].ParameterType);
			}
		}
		return flag2;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "ILLinker will never remove the Invoke method from delegates.")]
	private static MethodInfo GetDelegateInvokeMethod(RuntimeType P_0)
	{
		return P_0.GetMethod("Invoke");
	}

	private static bool IsReturnTypeMatch(Type P_0, Type P_1)
	{
		bool flag = P_1 == P_0;
		if (!flag)
		{
			if (!P_1.IsValueType && P_0.IsAssignableFrom(P_1))
			{
				flag = true;
			}
			else
			{
				bool isEnum = P_0.IsEnum;
				bool isEnum2 = P_1.IsEnum;
				if (isEnum2 && isEnum)
				{
					flag = Enum.GetUnderlyingType(P_0) == Enum.GetUnderlyingType(P_1);
				}
				else if (isEnum && Enum.GetUnderlyingType(P_0) == P_1)
				{
					flag = true;
				}
				else if (isEnum2 && Enum.GetUnderlyingType(P_1) == P_0)
				{
					flag = true;
				}
			}
		}
		return flag;
	}

	private static bool IsArgumentTypeMatch(Type P_0, Type P_1)
	{
		bool flag = P_0 == P_1;
		if (!flag && !P_1.IsValueType && P_1.IsAssignableFrom(P_0))
		{
			flag = true;
		}
		if (!flag)
		{
			if (P_0.IsEnum && Enum.GetUnderlyingType(P_0) == P_1)
			{
				flag = true;
			}
			else if (P_1.IsEnum && Enum.GetUnderlyingType(P_1) == P_0)
			{
				flag = true;
			}
		}
		return flag;
	}

	private static bool IsArgumentTypeMatchWithThis(Type P_0, Type P_1, bool P_2)
	{
		if (P_1.IsValueType)
		{
			return (P_0.IsByRef && P_0.GetElementType() == P_1) || (P_2 && P_0 == P_1);
		}
		return P_0 == P_1 || P_1.IsAssignableFrom(P_0);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is Delegate obj) || !InternalEqualTypes(this, P_0))
		{
			return false;
		}
		if (obj._target == _target && obj.Method == Method)
		{
			if (obj.data != null || data != null)
			{
				if (obj.data != null && data != null)
				{
					if (obj.data.target_type == data.target_type)
					{
						return obj.data.method_name == data.method_name;
					}
					return false;
				}
				if (obj.data != null)
				{
					return (object)obj.data.target_type == null;
				}
				if (data != null)
				{
					return (object)data.target_type == null;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		MethodInfo methodInfo = Method;
		return ((methodInfo != null) ? methodInfo.GetHashCode() : GetType().GetHashCode()) ^ RuntimeHelpers.GetHashCode(_target);
	}

	protected virtual MethodInfo GetMethodImpl()
	{
		if (method_info != null)
		{
			return method_info;
		}
		if (method != IntPtr.Zero)
		{
			if (!method_is_virtual)
			{
				method_info = (MethodInfo)RuntimeMethodInfo.GetMethodFromHandleNoGenericCheck(new RuntimeMethodHandle(method));
			}
			else
			{
				method_info = GetVirtualMethod_internal();
			}
		}
		return method_info;
	}

	private static bool InternalEqualTypes(object P_0, object P_1)
	{
		return P_0.GetType() == P_1.GetType();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Delegate CreateDelegate_internal(QCallTypeHandle P_0, object P_1, MethodInfo P_2, bool P_3);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern MethodInfo GetVirtualMethod_internal();

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public static Delegate CreateDelegate(Type P_0, object? P_1, MethodInfo P_2)
	{
		return CreateDelegate(P_0, P_1, P_2, true);
	}

	public static Delegate CreateDelegate(Type P_0, MethodInfo P_1)
	{
		return CreateDelegate(P_0, P_1, true);
	}

	public virtual void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		throw new PlatformNotSupportedException();
	}
}
