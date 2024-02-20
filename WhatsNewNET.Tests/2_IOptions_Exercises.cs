using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WhatsNewNET.Tests
{

    public class IOptions_Exercises
    {
        public IOptions_Exercises()
        {
            
        }

        /// <summary>
        /// Exercise 1:
        /// Create a strongly typed model behind the configuration provided
        ///
        /// Hints:
        ///     * use MemoryStream & Encoding.ASCII.GetBytes() to insert the json into a ConfigurationBuilder.
        ///     * ConfigurationBuilder can be used to create IConfiguration.
        ///     * Use IServiceCollection & configure and bind methods.
        ///
        /// Goal of this exercise
        ///     * Resolve the strongly typed model & validate that everything is populated.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Exercise_1()
        {
            var json = "{}"; //"{\"Test\":\"Test\",\"MySettingsNested\":{\"Settings123\":\"Settings123\",\"MySettingsNestedWithinNested\":{\"SomethingElse\":\"SomethingElse\"}}}";

            
        }


        /// <summary>
        /// Exercise 2:
        /// Repeat of exercise 1, create a web api project & implement this in startup.
        /// Play a bit with the settings & try to break it. think about what would be nice & what wouldn't be.
        /// 
        /// Goals of this exercise:
        ///  * Implement startup.cs that uses the similar settings & and combine it with ValidateOnStart() and attributes like [Required]
        ///  * See how the service can't start up if the values are empty.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Exercise_2()
        {
            
        }
    }
}
