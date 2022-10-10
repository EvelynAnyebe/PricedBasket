using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
     public class MessageManager
    { /// Static class to handle all message display to the user

        /**
         * <summary>
         * Generic print method. TO DO: can be customized to appear nicely
         * </summary>
         * 
         */
        public static void Print<T>(T message)
        {
            Console.WriteLine(message);
        }


        // Exception handling and error logging
      
        /**
         * <summary>
         * Prints custom message for errors and exceptions in the application
         * </summary>
         *
         * <param name="error">The error type</param>
         * <param name="customMessage">A custom message to override the global message to this error type.</param>
         * 
         * <return void></return>
         */
        public static void LogError(Constants.ErrorType error,string customMessage=null)
        {
            Console.WriteLine("\nError!!\n----------------------\n");
            // Get the error message from the enum and print
            if (string.IsNullOrEmpty(customMessage)){
                //Enum.TryParse(error, true, out Constants.ErrorType key);
                Console.WriteLine(Constants.ErrorMessages[error]);
            }
            else
            {
                Console.WriteLine(customMessage);
                Console.WriteLine("\n----------------------\n");
            }
        }
       
    }

}
