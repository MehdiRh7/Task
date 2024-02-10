using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Infrastructures.Generator
{
    public class OtpCode
    {
        public string Generate()
        {
            var key = KeyGeneration.GenerateRandomKey(20);
            var totp = new Totp(key,30,OtpHashMode.Sha1,4);
            var otp = totp.ComputeTotp();

            return otp.ToString();
		}
        
    }
}
