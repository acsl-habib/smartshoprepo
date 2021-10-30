using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShop.DataLib.Models.Constants
{
    public enum DiscountAmountType { Flat = 1, PerOrderAmount }
    public enum DiscountRuleType { NoRule = 1, MinOrderValue }
    public enum ConfigurationValueType { Single=1, Collection}
    public enum OrderStatus {  Pending=1, Confirmed, Paid, Picked, Onway, Delivered, Cancelled}
}
