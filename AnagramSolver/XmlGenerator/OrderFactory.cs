using OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlGenerator
{
    public class OrderFactory
    {
        public PurchaseOrderType GetOrders()
        {
            PurchaseOrderType order = new PurchaseOrderType
            {
                ShipTo = new USAddress[]
                {
                    new USAddress
                    {
                        name = "John",
                        street = "WolfStreet",
                        city = "LA",
                        state = "WhoKnows",
                        country = "US",
                        zip = "4444"
                    },
                    new USAddress
                    {
                        name = "Bryan",
                        street = "WolfStreet",
                        city = "LA",
                        state = "WhoKnows",
                        country = "US",
                        zip = "4444"
                    }
                },
                BillTo = new USAddress
                {
                    name = "John",
                    street = "WolfStreet",
                    city = "LA",
                    state = "WhoKnows",
                    country = "US",
                    zip = "4444"
                },
                OrderDate = DateTime.Now,
                OrderDateSpecified = true
            };
            return order;
        }
    }
}
