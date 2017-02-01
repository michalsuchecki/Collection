using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using MyInflatables.Helpers;
using Xunit.Abstractions;

namespace MyInflatables.Tests
{
    public class Class1
    {
        ICollection<string> filenames;
        private ITestOutputHelper output;

        public Class1(ITestOutputHelper output)
        {
            this.output = output;

            filenames = new List<string>();

            filenames.Add("83324NP_Intex_Intex_Log_Mattress_0.jpg");
            filenames.Add("83324NP_Intex_Intex_Log_Mattress_1.jpg");
            filenames.Add("83324NP_Intex_Intex_Log_Mattress_2.jpg");
            filenames.Add("83324NP_Intex_Intex_Log_Mattress_3.jpg");
            filenames.Add("83324NP_Intex_Intex_Log_Mattress_4.jpg");
            filenames.Add("83324NP_Intex_Intex_Log_Mattress_5.jpg");
        }

        [Theory]
        [InlineData("83324NP_Intex_Intex_Log_Mattress")]
        void Test_CountAllFilesStartingWithPrefix(string prefix)
        {
            var images = filenames.Where(s => s.StartsWith(prefix)).ToList();
            Assert.Equal(images.Count, 6);
        }

        [Theory]
        [InlineData("83324NP", 0)]
        [InlineData("81334NP", 6)]
        void Test_RemovingAllFilesStartingWithPrefix(string prefix, int expected)
        {
            var images = filenames.Where(s => !s.StartsWith(prefix)).ToList();
            Assert.Equal(images.Count, expected);
        }

        [Theory]
        [InlineData("83324NP_Intex_Intex_Log_Mattress_2.jpg", 5, new string[] { "83324NP_Intex_Intex_Log_Mattress_0.jpg", "83324NP_Intex_Intex_Log_Mattress_1.jpg", "83324NP_Intex_Intex_Log_Mattress_2.jpg", "83324NP_Intex_Intex_Log_Mattress_3.jpg", "83324NP_Intex_Intex_Log_Mattress_4.jpg"})]
        void Test_RemovingOneItemFromMiddleAndCheckIfOthersAreRenamed(string filename, int expected, string[] remaining)
        {
            if(filenames.Contains(filename))
            {
                var value = 0;
                Int32.TryParse(filename.Split('_').LastOrDefault(), out value);

                Assert.Equal(2, value);
            }
        }
    }
}
