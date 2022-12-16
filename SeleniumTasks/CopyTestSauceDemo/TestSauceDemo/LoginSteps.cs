using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSauceDemo.StepDefinitions;

namespace TestSauceDemo
{
    public class LoginSteps
    {
        public void Login()
        {

            SaucedemoStepDefination step = new SaucedemoStepDefination();
            step.GivenILaunchTheSaucedemoApplication();
            step.WhenIEnterTheStandard_User("standard_user");
            step.WhenIAlsoEnterTheSecret_Sauce("secret_sauce");
            step.WhenClickTheLoginButton();
            step.ThenLoginPageIsDisplayed();
        }
        public void Cart()
        {
            InventoryStepDefination step = new InventoryStepDefination();
            step.GivenIAmInInventoryPage();
            step.WhenIClickAddToCartButton();
            step.WhenIClickCartIcon();
            step.ThenCartPageIsDisplayed();
        }
    }
}
