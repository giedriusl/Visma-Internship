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
                        zip = "unzip"
                    },
                    new USAddress
                    {
                        name = "Bryan",
                        street = "WolfStreet",
                        city = "LA",
                        state = "WhoKnows",
                        country = "US",
                        zip = "unzip"
                    },
                    new USAddress
                    {
                        name = "Marry",
                        street = "WolfStreet",
                        city = "LA",
                        state = "WhoKnows",
                        country = "US",
                        zip = "unzip"
                    },
                    new USAddress
                    {
                        name = "NameIt",
                        street = "WolfStreet",
                        city = "LA",
                        state = "WhoKnows",
                        country = "US",
                        zip = "unzip"
                    }
                },
                BillTo = new USAddress
                {
                    name = "John",
                    street = "WolfStreet",
                    city = "LA",
                    state = "WhoKnows",
                    country = "US",
                    zip = "unzip"
                },
                OrderDate = DateTime.Now,
                OrderDateSpecified = true
            };
            return order;
        }
    }
}
