namespace System.Xml.Schema;

internal abstract class XmlValueConverter
{
	public abstract bool ToBoolean(long P_0);

	public abstract bool ToBoolean(int P_0);

	public abstract bool ToBoolean(double P_0);

	public abstract bool ToBoolean(DateTime P_0);

	public abstract bool ToBoolean(string P_0);

	public abstract bool ToBoolean(object P_0);

	public abstract int ToInt32(bool P_0);

	public abstract int ToInt32(long P_0);

	public abstract int ToInt32(double P_0);

	public abstract int ToInt32(DateTime P_0);

	public abstract int ToInt32(string P_0);

	public abstract int ToInt32(object P_0);

	public abstract long ToInt64(bool P_0);

	public abstract long ToInt64(int P_0);

	public abstract long ToInt64(double P_0);

	public abstract long ToInt64(DateTime P_0);

	public abstract long ToInt64(string P_0);

	public abstract long ToInt64(object P_0);

	public abstract decimal ToDecimal(string P_0);

	public abstract decimal ToDecimal(object P_0);

	public abstract double ToDouble(bool P_0);

	public abstract double ToDouble(int P_0);

	public abstract double ToDouble(long P_0);

	public abstract double ToDouble(DateTime P_0);

	public abstract double ToDouble(string P_0);

	public abstract double ToDouble(object P_0);

	public abstract float ToSingle(double P_0);

	public abstract float ToSingle(string P_0);

	public abstract float ToSingle(object P_0);

	public abstract DateTime ToDateTime(bool P_0);

	public abstract DateTime ToDateTime(int P_0);

	public abstract DateTime ToDateTime(long P_0);

	public abstract DateTime ToDateTime(double P_0);

	public abstract DateTime ToDateTime(DateTimeOffset P_0);

	public abstract DateTime ToDateTime(string P_0);

	public abstract DateTime ToDateTime(object P_0);

	public abstract DateTimeOffset ToDateTimeOffset(DateTime P_0);

	public abstract DateTimeOffset ToDateTimeOffset(string P_0);

	public abstract DateTimeOffset ToDateTimeOffset(object P_0);

	public abstract string ToString(bool P_0);

	public abstract string ToString(int P_0);

	public abstract string ToString(long P_0);

	public abstract string ToString(decimal P_0);

	public abstract string ToString(float P_0);

	public abstract string ToString(double P_0);

	public abstract string ToString(DateTime P_0);

	public abstract string ToString(DateTimeOffset P_0);

	public abstract string ToString(object P_0);

	public abstract string ToString(object P_0, IXmlNamespaceResolver P_1);

	public abstract object ChangeType(bool P_0, Type P_1);

	public abstract object ChangeType(int P_0, Type P_1);

	public abstract object ChangeType(long P_0, Type P_1);

	public abstract object ChangeType(decimal P_0, Type P_1);

	public abstract object ChangeType(double P_0, Type P_1);

	public abstract object ChangeType(DateTime P_0, Type P_1);

	public abstract object ChangeType(string P_0, Type P_1, IXmlNamespaceResolver P_2);

	public abstract object ChangeType(object P_0, Type P_1);

	public abstract object ChangeType(object P_0, Type P_1, IXmlNamespaceResolver P_2);
}
