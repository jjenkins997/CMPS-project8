// Jahzah Jenkins Tomas Parker
// C00227447 C00409618
// CMPS 358
// project #8


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
namespace p8_c00227447_c00409618.Pages;

public class index : PageModel
{
    private readonly ILogger<index> _logger;

    public index(ILogger<index> logger)
    {
        _logger = logger;
    }
    
    public void OnGet()
    {
        
    }
    [BindProperty]
    public string discontinued { get; set; }
    
    [BindProperty]
    public string Country { get; set; }
    
    [BindProperty]
    public string supplyCountry { get; set; }
    
    [BindProperty]
    public string supplier { get; set; }
    
    [BindProperty]
    public string orderNumber { get; set; }
}

public static class discontinuedList
{
    public static string listDiscontinued(string decoy)
    {
        if (decoy != "decoy")
        {
            return "";
        }
        else
        {
            using (var db = new Smallbusiness())
            {
                //get products where IsDiscontinued == 1 meaning true
                var results = from n in db.Products where n.IsDiscontinued.ToString() == "1" select n;
                if (results.Count() == 0)
                {
                    return "";
                }
                string discontinued = "";
                foreach (var c in results)
                    discontinued += $"{c.ProductName}, ";
                return discontinued;
            }
        }
    }
}

public static class customerInformation
{
    public static string countryCustomers(string country)
    {
        using (var db = new Smallbusiness())
        {
            //find customer data the matches the given country
            var results = from n in db.Customers where n.Country == country select n;
            if (results.Count() == 0)
            {
                return "";
            }
            string customers = "";
            foreach (var c in results)
                customers += $"{c.FirstName + " " + c.LastName + " " + c.Phone}, ";
            return customers;
        }
    }
}

public static class supplierInformation
{
    public static string countrySuppliers(string country)
    {
        using (var db = new Smallbusiness())
        {
            //get supplier data that matches the given country
            var results = from n in db.Suppliers where n.Country == country select n;
            if (results.Count() == 0)
            {
                return "";
            }
            
            string suppliers = "";
            foreach (var c in results)
                suppliers += $"{c.Id + " " + c.CompanyName + " " + c.Phone + " " + ((String.IsNullOrEmpty(c.Fax) ? "No Fax Machine " : c.Fax + " ")) + c.City}, ";
            return suppliers;
        }
    }
}

public static class productInfo
{
    public static string getProductInfo(string supplier)
    {
        using (var db = new Smallbusiness())
        {
            //join the tables set supplier id equal to supplierId in products where the product isnt discontinued
            var results = from s in db.Suppliers join p in db.Products 
                on s.Id equals p.SupplierId where s.CompanyName == supplier where p.IsDiscontinued.ToString() == "0" select p;
            if (results.Count() == 0)
            {
                return "";
            }
            string products = "";
            foreach (var c in results)
                products += $"{c.ProductName + " " + "Unit Price: " +Encoding.UTF8.GetString(c.UnitPrice) + " " + c.Package}, ";
            return products;
        }
    }
}

public static class orderInfo
{
    public static string getOrder(string orderNumber)
    {
        using (var db = new Smallbusiness())
        {
            //join order and order item then join that new table with product and then finally that table with customer
            var results = from order in db.Orders
                join orderitem in db.OrderItems
                    on order.Id equals orderitem.OrderId
                join product in db.Products on orderitem.ProductId equals product.Id
                join customer in db.Customers on order.CustomerId equals customer.Id
                where order.OrderNumber == orderNumber
                select new {order, orderitem, product, customer};
            if (results.Count() == 0)
            {
                return "";
            }
            //Display the Name Just once instead of every iteration
            string orderString = "";
            foreach (var c in results)
            {
                orderString += $"{c.customer.FirstName + " " + c.customer.LastName +": "} ";
                break;
            }
              
            //display name, unit price, and total
            foreach (var c in results)
                orderString +=
                    $"{c.product.ProductName + " Unit Price: " + Encoding.UTF8.GetString(c.orderitem.UnitPrice) + " Quantity: " + c.orderitem.Quantity + " Subtotal: " + double.Parse(Encoding.UTF8.GetString(c.orderitem.UnitPrice)) * Convert.ToDouble(c.orderitem.Quantity) + " | "}";
            //display total amount once
            foreach (var c in results)
            {
                 orderString += $"{"Total Amount: " + Encoding.UTF8.GetString(c.order.TotalAmount)}";
                 break;
            }
               
            return orderString;
        }
    }
}