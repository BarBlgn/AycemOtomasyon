using AycemOtomasyon.DTO;
using AycemOtomasyon.DTO.Enum;
using AycemOtomasyon.DTO.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.Repository
{
    class OrderRepository
    {
        public static bool CreateOrder(OrderDTO orderDTO)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var order = new Order
                {
                    OrderId = Guid.NewGuid(),
                    OrderQuantity = 0,
                    OrderExpiryDate = orderDTO.OrderExpiryDate,
                    // ModifierRoleId = orderDTO.ModifierRoleId,
                    CompanyId = orderDTO.CompanyId
                };


                entities.Order.Add(order);
                result = entities.SaveChanges() > 0;

                var newId = order.OrderId;

                if (orderDTO.Items != null)
                {
                    foreach (var item in orderDTO.Items)
                    {
                        var orderItem = new OrderItem
                        {
                            OrderId = newId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            ColourId = item.ColourId,
                            OrderItemId = item.OrderItemId
                        };

                        entities.OrderItem.Add(orderItem);
                    }

                    entities.SaveChanges();
                }


                if (orderDTO.Products != null)
                {
                    foreach (var product in orderDTO.Products)
                    {
                        var porduct = new Porduct
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,

                        };
                        entities.Porduct.Add(porduct);
                        entities.SaveChanges();
                    }


                    //if (orderDTO.Companies != null) {
                    //     foreach (var companies in orderDTO.Companies)
                    //     {
                    //         var company = new Company
                    //         {
                    //             CompanyId = companies.CompanyId,
                    //             CompanyName = companies.CompanyName,
                    //             CompanyTelNo = companies.CompanyTelNo
                    //         };
                    //         entities.Company.Add(company);
                    //         entities.SaveChanges();
                    //     }

                    // }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public static List<OrderGrid> GetOrderList(Guid? companyId = null, Guid? productId = null, DateTime? orderDate = null)
        {
            var result = new List<OrderGrid>();

            try
            {
                var entities = new AycemEntities();

                var query = entities.OrderItem.Include("Colour")
                                              .Include("Order")
                                              .Include("Order.Company")
                                              .Include("Porduct")
                                              .Where(o => o.OrderId != null);

                if (companyId.HasValue && companyId.Value != Guid.Empty)
                {
                    query = query.Where(q => q.Order.CompanyId == companyId.Value);
                }

                if (productId.HasValue && productId.Value != Guid.Empty)
                {
                    query = query.Where(q => q.ProductId == productId.Value);
                }

                if (orderDate.HasValue && orderDate.Value != DateTime.MinValue)
                {
                    query = query.Where(q => q.Order.OrderExpiryDate <= orderDate.Value);
                }

                result = query.Select(s => new OrderGrid
                {
                    OrderItemId = s.OrderItemId,
                    CompanyName = s.Order.Company.CompanyName,
                    ProductName = s.Porduct.ProductName,
                    ColorName = s.Colour.ColourName,
                    Status = s.Status.Value,
                    Quantity = s.Quantity
                }).ToList();

                result.ForEach(x => x.OrderItemStatus = ((OrderItemStatus)x.Status).GetDescription());
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static List<OrderDTO> ShowOrders(OrderDTO orderDTO)
        {
            var result = new List<OrderDTO>();

            try
            {
                AycemEntities entities = new AycemEntities();


                result = entities.Order.Include("Porduct").Include("OrderItem").Select(u => new OrderDTO
                {
                    OrderId = u.OrderId,
                    CompanyId = u.CompanyId,
                    OrderExpiryDate = u.OrderExpiryDate,
                    Items = u.OrderItem.Where(oi => oi.OrderId == u.OrderId).Select(oi => new OrderItemDTO
                    {
                        Quantity = oi.Quantity,
                        ProductId = oi.ProductId,
                        Product = new PorductDTO
                        {

                            ProductName = oi.Porduct.ProductName,
                        }
                    }).ToList(),

                }).ToList();
                // }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool DeleteOrder(Guid orderId)
        {
            var result = false;
            var entities = new AycemEntities();
            var order = entities.Order.Where(p => p.OrderId == orderId).Select(p => p).FirstOrDefault();
            entities.Order.Remove(order);
            entities.SaveChanges();
            return result;

        }

        public static bool ChangeOrderItemStatus(Guid orderItemId, OrderItemStatus status)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var orderItem = entities.OrderItem.FirstOrDefault(o => o.OrderItemId == orderItemId);

                if (orderItem != null)
                {
                    orderItem.Status = status.ToInt();
                    result = entities.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
