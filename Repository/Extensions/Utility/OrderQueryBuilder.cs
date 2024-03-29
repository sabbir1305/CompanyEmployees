﻿using Repository.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions.Utility
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Split(',');
            var propertyInfos = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | 
                System.Reflection.BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrEmpty(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];

                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(SortingConstants.EndWithDesc) ? SortingConstants.Descending : SortingConstants.Ascending;
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}");

            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' '); 
            return orderQuery;
        }
    }
}
