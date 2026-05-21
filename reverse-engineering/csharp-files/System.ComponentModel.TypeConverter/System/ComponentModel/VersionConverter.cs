using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel;

public class VersionConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			try
			{
				return Version.Parse(text);
			}
			catch (Exception ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", text, "Version"), ex);
			}
		}
		if (P_2 is Version version)
		{
			return new Version(version.Major, version.Minor, version.Build, version.Revision);
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		ArgumentNullException.ThrowIfNull(P_3, "destinationType");
		if (P_2 is Version version)
		{
			if (P_3 == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = typeof(Version).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[4]
				{
					typeof(int),
					typeof(int),
					typeof(int),
					typeof(int)
				}, null);
				return new InstanceDescriptor(constructor, new object[4] { version.Major, version.Minor, version.Build, version.Revision });
			}
			if (P_3 == typeof(string))
			{
				return version.ToString();
			}
			if (P_3 == typeof(Version))
			{
				return new Version(version.Major, version.Minor, version.Build, version.Revision);
			}
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
