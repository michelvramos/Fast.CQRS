using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject.service
{
    public sealed class FakeService
    {
        public bool IsAdult(int age)
        {
            return age > 21;
        }
        public async Task<string> DownloadData(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public int CountPrimeNumbers(int limit, CancellationToken cancellationToken)
        {
            int counter = 0;

            for (int i = 1; i < limit; i += 2)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return 0;
                }

                int mod = (int)(Math.Sqrt(i) + 1);

                if (checkDivisors(i, mod))
                {
                    counter++;
                }

            }

            return counter;
        }

        private bool checkDivisors(int n, int mod)
        {
            for (int j = 3; j < mod; j += 2)
            {
                if ((n % j) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
