using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    class PersonnesBLL
    {

        /*
         * For the ProductsBLL class we need to add a total of seven methods:
GetProducts() – returns all products
GetProductByProductID(productID) – returns the product with the specified product ID
GetProductsByCategoryID(categoryID) – returns all products from the specified category
GetProductsBySupplier(supplierID) – returns all products from the specified supplier
AddProduct(productName, supplierID, categoryID, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued) – inserts a new product into the database using the values passed-in; returns the ProductID value of the newly inserted record
UpdateProduct(productName, supplierID, categoryID, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued, productID) – updates an existing product in the database using the passed-in values; returns True if precisely one row was updated, False otherwise
DeleteProduct(productID) – deletes the specified product from the database
         * */

        // (string m, string pwd, string n, string pr, string t)


        public void GetPersonnes()  // Retoure toutes les personnes
        {
        }

        public void GetPersonneByMail(string m)
        {
        }

        public void GetPersonnesByNom(string n)
        {
        }

        public void GetPersonnesByPrenom(string p)
        {
        }

        public void GetPersonnesByType(string t)
        {
        }
    }
}
