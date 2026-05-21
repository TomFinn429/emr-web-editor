using System.Collections.Generic;

namespace DCSoft.Writer.Dom;

public class DCChartDataItemList : List<DCChartDataItem>
{
	internal string z0rek;

	internal List<DCChartDataItemList> z0eek()
	{
		List<DCChartDataItemList> list = new List<DCChartDataItemList>();
		DCChartDataItemList dCChartDataItemList = null;
		using List<DCChartDataItem>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DCChartDataItem current = enumerator.Current;
			if (dCChartDataItemList == null || dCChartDataItemList.z0rek != current.SeriesName)
			{
				dCChartDataItemList = new DCChartDataItemList();
				dCChartDataItemList.z0rek = current.SeriesName;
				list.Add(dCChartDataItemList);
			}
			dCChartDataItemList.Add(current);
		}
		return list;
	}
}
