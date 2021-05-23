using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace monoMVC
{
   public class PaginatedList<T> : List<T>
   {
	public int PageIndex { get; private set; }
	public int TotalPages { get; private set; }

	public PaginatedList(List<T> items, int count, int currentPage, int pageSize)
	{
		PageIndex = currentPage;
		TotalPages = (int)Math.Ceiling(decimal.Divide(count, pageSize));

		this.AddRange(items);
	}
             
	public static async Task<PaginatedList<T>> CreateAsync(List<T> source, int count, int currentPage, int pageSize)
	{
		return new PaginatedList<T> (source, count, currentPage, pageSize);
	}

   }
}
