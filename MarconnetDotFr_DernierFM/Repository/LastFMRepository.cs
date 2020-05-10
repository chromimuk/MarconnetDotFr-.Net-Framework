using MarconnetDotFr_DernierFM.Models;
using MarconnetDotFr_DernierFM.Models.DAO;
using MarconnetDotFr_DernierFM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarconnetDotFr_DernierFM.Repository
{
    public class LastFMRepository : ILastFMRepository
    {
        private const string baseAddress = "http://ws.audioscrobbler.com/2.0/";

        private readonly LastFMCredentials _lastFMCredentials;

        public LastFMRepository(LastFMCredentials lastFMCredentials)
        {
            _lastFMCredentials = lastFMCredentials;
        }

        public LastFMRepository()
        {
        }

        public async Task<IEnumerable<LastFMAlbum>> GetFavouriteLastFMAlbumsAsync(string username, int limit, string period)
        {
            string userGetUserTopAlbumsURL = $"/2.0/?method=user.gettopalbums&user={username}&limit={limit}&period={period}&api_key={_lastFMCredentials.APIKey}";

            Task<string> data = Query(userGetUserTopAlbumsURL);
            string xmlData = await data;

            XDocument xdoc = XDocument.Parse(xmlData);
            IEnumerable<XElement> elements = xdoc.Descendants("lfm").Descendants("topalbums").Descendants("album");

            IList<LastFMAlbum> lastFMAlbums = new List<LastFMAlbum>();
            foreach (XElement element in elements)
            {
                LastFMAlbumXMLDao dao = new LastFMAlbumXMLDao(element);
                LastFMAlbum lastFMAlbum = new LastFMAlbum(dao);
                lastFMAlbums.Add(lastFMAlbum);
            }

            return lastFMAlbums;
        }

        public async Task<LastFMUser> GetLastFMUserAsync(string username)
        {
            string userGetUserInfoURL = $"/2.0/?method=user.getinfo&user={username}&api_key={_lastFMCredentials.APIKey}";

            Task<string> data = Query(userGetUserInfoURL);
            string xmlData = await data;

            XDocument xdoc = XDocument.Parse(xmlData);
            IEnumerable<XElement> elements = xdoc.Descendants("lfm").Descendants("user");
            LastFMUserXMLDAO dao = new LastFMUserXMLDAO(elements.First());
            LastFMUser lastFMUser = new LastFMUser(dao);

            return lastFMUser;
        }

        private async Task<string> Query(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}