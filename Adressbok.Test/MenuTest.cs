using Adressbok.Models;
using Adressbok.Solutions;

namespace Adressbok.Test
{
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void Add_Contact_To_List_Test()
        {



            //Arrange - Setup
            Menu menu = new Menu();
            Contact contact = new Contact();


            //Act - Action
            menu.contacts.Add(contact);



            //Assert - Evaluation
            Assert.AreEqual(1, menu.contacts.Count);


        }
    }
}