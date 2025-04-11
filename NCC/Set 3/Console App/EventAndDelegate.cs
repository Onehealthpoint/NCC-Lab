using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set3_Q1Q3
{
    class EventAndDelegate
    {
        public delegate void ButtonClickHandler(string message);

        public class Button
        {
            public event ButtonClickHandler Click;
            public void OnClick()
            {
                Click?.Invoke("Submit Button clicked!");
            }
        }

        public static void Run()
        {
            Console.WriteLine("Event and Delegate Demo \n");
            Button submitButton = new Button();
            submitButton.Click += (message) => Console.WriteLine(message);
            submitButton.OnClick();
        }
    }
}
