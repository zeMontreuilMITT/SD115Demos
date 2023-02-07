using Microsoft.AspNetCore.Mvc;

namespace SD115Demos.Controllers
{
    public class CalculatorController: Controller
    {
        public IActionResult Add(int operandOne, int operandTwo)
        {
            ViewBag.Outcome = operandOne + operandTwo;
            return View("Result");
        }

        public IActionResult Subtract(int operandOne, int operandTwo) 
        {
            ViewBag.Outcome = operandOne - operandTwo;
            return View("Result");
        }

        public IActionResult Divide(int operandOne, int operandTwo)
        {
            ViewBag.Outcome = operandOne / operandTwo;
            return View("Result");
        }

        public IActionResult Multiply(int operandOne, int operandTwo)
        {
            ViewBag.Outcome = operandOne * operandTwo;
            return View("Result");
        }
    }
}
