using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace zzz;

public static class z0ZzZznok
{
	private static readonly Type z0rek = typeof(Math);

	private static readonly Dictionary<Type, Type> z0tek = new Dictionary<Type, Type>();

	private static readonly Dictionary<string, Type> z0yek = new Dictionary<string, Type>();

	private static readonly Dictionary<Type, Type> z0uek = new Dictionary<Type, Type>();

	public static bool IsStdAssembly(Assembly asm)
	{
		if (asm == null)
		{
			throw new ArgumentNullException("asm");
		}
		if (asm.GetType().Namespace == "System.Reflection.Emit")
		{
			return false;
		}
		string text = null;
		try
		{
			text = asm.Location;
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.ToString());
			return false;
		}
		if (text == null || text.Length == 0)
		{
			return false;
		}
		string fullName = asm.FullName;
		if (fullName == null || fullName.Equals("System", StringComparison.OrdinalIgnoreCase) || fullName.StartsWith("System.", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}

	public static Type GetCollectionItemType(Type rootType, bool checkAddMethod)
	{
		if (rootType == null)
		{
			throw new ArgumentNullException("rootType");
		}
		if (rootType.IsPrimitive || rootType.IsEnum)
		{
			return null;
		}
		if (rootType == typeof(string))
		{
			return null;
		}
		if (rootType.IsArray)
		{
			if (checkAddMethod)
			{
				return null;
			}
			Type elementType = rootType.GetElementType();
			if (elementType != null && (elementType.IsPrimitive || elementType == typeof(string) || elementType == typeof(DateTime) || elementType == typeof(decimal)))
			{
				return null;
			}
		}
		if (typeof(z0ZzZzoah).IsAssignableFrom(rootType))
		{
			return null;
		}
		Type result2;
		if (checkAddMethod)
		{
			if (z0tek.TryGetValue(rootType, out var result))
			{
				return result;
			}
		}
		else if (z0uek.TryGetValue(rootType, out result2))
		{
			return result2;
		}
		if (rootType == typeof(z0ZzZzpah))
		{
			z0tek[rootType] = null;
			z0uek[rootType] = typeof(z0ZzZzpah);
			if (checkAddMethod)
			{
				return null;
			}
			return typeof(z0ZzZzpah);
		}
		if (rootType.IsArray)
		{
			z0tek[rootType] = null;
			z0uek[rootType] = rootType.GetElementType();
			if (checkAddMethod)
			{
				return null;
			}
			return rootType.GetElementType();
		}
		bool flag = false;
		Type[] interfaces = rootType.GetInterfaces();
		if (interfaces != null)
		{
			Type[] array = interfaces;
			foreach (Type type in array)
			{
				if (typeof(IEnumerable).IsAssignableFrom(type))
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			z0uek[rootType] = null;
			z0tek[rootType] = null;
			return null;
		}
		Type type2 = null;
		MemberInfo[] defaultMembers = rootType.GetDefaultMembers();
		if (defaultMembers != null)
		{
			MemberInfo[] array2 = defaultMembers;
			foreach (MemberInfo memberInfo in array2)
			{
				if (!(memberInfo is PropertyInfo) || !((PropertyInfo)memberInfo).CanRead)
				{
					continue;
				}
				type2 = ((PropertyInfo)memberInfo).PropertyType;
				if (checkAddMethod)
				{
					MethodInfo[] methods = rootType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
					foreach (MethodInfo methodInfo in methods)
					{
						if (string.Compare(methodInfo.Name, "Add", true) != 0)
						{
							continue;
						}
						ParameterInfo[] parameters = methodInfo.GetParameters();
						if (parameters == null || parameters.Length != 1 || !(parameters[0].ParameterType == type2))
						{
							continue;
						}
						goto IL_0261;
					}
					continue;
				}
				goto IL_0261;
				IL_0261:
				if (type2 != null)
				{
					z0uek[rootType] = type2;
					if (checkAddMethod)
					{
						z0tek[rootType] = type2;
					}
				}
				return type2;
			}
		}
		return null;
	}

	public static Type GetTypeByName(string typeName)
	{
		if (typeName == null || typeName.Trim().Length == 0)
		{
			return null;
		}
		if (z0yek.TryGetValue(typeName, out var type))
		{
			if (type == z0rek)
			{
				return null;
			}
			return type;
		}
		Type type2 = Type.GetType(typeName, false, true);
		if (type2 != null)
		{
			z0yek[typeName] = type2;
			return type2;
		}
		string text = typeName.Trim();
		int num = typeName.IndexOf(',');
		string text2 = null;
		if (num > 0)
		{
			text2 = typeName.Substring(num + 1).Trim();
			text = typeName.Substring(0, num).Trim();
		}
		else
		{
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			Type type3 = callingAssembly.GetType(typeName, false, true);
			if (type3 == null && typeName.IndexOf('.') < 0)
			{
				Type[] exportedTypes = callingAssembly.GetExportedTypes();
				foreach (Type type4 in exportedTypes)
				{
					if (string.Compare(type4.Name, typeName, true) == 0)
					{
						type3 = type4;
						break;
					}
				}
			}
			if (type3 != null)
			{
				z0yek[typeName] = type3;
				return type3;
			}
		}
		List<Assembly> assemblies = GetAssemblies(inluceSystem: true);
		foreach (Assembly item in assemblies)
		{
			if (text2 == null || string.Compare(text2, item.GetName().Name, true) == 0)
			{
				Type type5 = item.GetType(text, false, true);
				if (type5 != null)
				{
					z0yek[typeName] = type5;
					return type5;
				}
			}
		}
		typeof(EventArgs).Assembly.GetType(text, false, true);
		foreach (Assembly item2 in assemblies)
		{
			Type type6 = item2.GetType(text, false, true);
			if (type6 != null)
			{
				z0yek[typeName] = type6;
				return type6;
			}
		}
		z0yek[typeName] = z0rek;
		return null;
	}

	public static List<Assembly> GetAssemblies(bool inluceSystem, bool includeTempAssembly = false)
	{
		List<Assembly> list = new List<Assembly>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			if (!(assembly.GetType().Namespace == "System.Reflection.Emit") && (inluceSystem || !IsStdAssembly(assembly)))
			{
				list.Add(assembly);
			}
		}
		if (!list.Contains(typeof(z0ZzZznok).Assembly))
		{
			list.Add(typeof(z0ZzZznok).Assembly);
		}
		if (list.Count > 0)
		{
			list.Sort(new z0ZzZzpok());
		}
		return list;
	}

	public static string z0eek(string p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\"");
		foreach (char c in p0)
		{
			switch (c)
			{
			case '\r':
				stringBuilder.Append("\\r");
				break;
			case '\n':
				stringBuilder.Append("\\n");
				break;
			case '"':
				stringBuilder.Append("\\\"");
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		stringBuilder.Append("\"");
		return stringBuilder.ToString();
	}

	public static string GetTypeFullName(Type type)
	{
		if (type == null)
		{
			return null;
		}
		string text = type.FullName + "," + type.Assembly.GetName().Name;
		z0yek[text] = type;
		return text;
	}
}
