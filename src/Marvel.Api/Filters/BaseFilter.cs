using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Marvel.Api.Filters
{
    [Flags]
    public enum OrderResult
    {
        [Description("name")]
        NameAscending = 0x00,

        [Description("modified")]
        ModifiedAscending = 0x01,

        [Description("-name")]
        NameDescending = 0x02,

        [Description("-modified")]
        ModifiedDescending = 0x04
    }

    public class BaseFilter
    {
        private OrderResult _orderBy;

        public void OrderBy(OrderResult order)
        {
            if ((order & _orderBy) == 0)
                _orderBy |= order;
        }

        /// <summary>
        /// Order the result set by a field or fields
        /// </summary>
        public string ResultSetOrder
        {
            get
            {
                var result = new List<string>();
                foreach (OrderResult order in Enum.GetValues(typeof(OrderResult)))
                {
                    if ((_orderBy & order) != 0)
                        result.Add(order.GetDescription());
                }

                if (result.Count == 0)
                    return string.Empty;

                return string.Join(",", result.ToArray());
            }
        }

        /// <summary>
        /// Limit the result set to the specified number of resources.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Skip the specified number of resources in the result set.
        /// </summary>
        public int? Offset { get; set; }
    }
}
