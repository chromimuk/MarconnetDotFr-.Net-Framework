using System;

namespace MarconnetDotFr_DernierFM.Models
{
    public class LastFMCredentials
    {
        public string APIKey { get; private set; }
        public string SharedSecret { get; private set; }

        public LastFMCredentials(string apiKey, string sharedSecret)
        {
            if (apiKey == null)
                throw new ArgumentNullException(apiKey);
            if (sharedSecret == null)
                throw new ArgumentNullException(sharedSecret);

            APIKey = apiKey;
            SharedSecret = sharedSecret;
        }
    }
}