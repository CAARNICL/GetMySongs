using Newtonsoft.Json;
using SmuleLib.HttpClientProgress;
using SmuleLib.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmuleLib
{
    public class SmuleClient
    {
        private HttpClient _httpClient;

        public SmuleClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(@"https://www.smule.com") };
        }
        public SmuleClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async System.Threading.Tasks.Task<Profile> GetProfileAsync(string theName)
        {
            try
            {
                //_httpClient = new HttpClient { BaseAddress = new Uri(@"https://www.smule.com") };
                var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, @"/" + theName));
                var resstring = await response.Content.ReadAsStringAsync();

                int start = resstring.IndexOf("<script>");
                int end = resstring.IndexOf("</script>");

                //Cut the right data
                string script = resstring.Substring(start, (end - start) - 2);
                script = script.Remove(0, 29);

                start = script.IndexOf("Profile: ") + 9;
                end = script.IndexOf("Settings:");

                string profile = script.Substring(start, (end - start));
                profile = profile.TrimEnd();
                profile = profile.Remove(profile.Length - 1, 1);
                Profile profileData = JsonConvert.DeserializeObject<Profile>(profile);
                return profileData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async System.Threading.Tasks.Task<List<List>> GetFavoritesAsync(string theName, string from, string size)
        {
            List<List> returnList = new List<List>();

            Favorites currentFavorites = new Favorites();
                var res3 = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, @"/" + theName + "/favorites/json?offset=" + from + "&size="+ size)).ConfigureAwait(false);
                var retstream = await res3.Content.ReadAsStringAsync();
                currentFavorites = JsonConvert.DeserializeObject<Favorites>(retstream);
                returnList.AddRange(currentFavorites.list);


            return returnList;
        }

        public async System.Threading.Tasks.Task<List<List>> GetFavoritesAsync(string theName, string from)
        {
            List<List> returnList = new List<List>();

            Favorites currentFavorites = new Favorites();
                var res3 = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, @"/" + theName + "/favorites/json?offset=" + from + "&size=200")).ConfigureAwait(false);
                var retstream = await res3.Content.ReadAsStringAsync();
                currentFavorites = JsonConvert.DeserializeObject<Favorites>(retstream);
                returnList.AddRange(currentFavorites.list);


            return returnList;
        }

        public async System.Threading.Tasks.Task<List<List>> GetFavoritesAsync(string theName, int theSize = -1)
        {
            List<List> returnList = new List<List>();

            Favorites currentFavorites = new Favorites();
            while(currentFavorites.next_offset != -1 || (returnList.Count < theSize || theSize != -1))
            {
                var res3 = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, @"/" + theName + "/favorites/json?offset=" + currentFavorites.next_offset + "&size=200")).ConfigureAwait(false);
                var retstream = await res3.Content.ReadAsStringAsync();
                currentFavorites = JsonConvert.DeserializeObject<Favorites>(retstream);
                returnList.AddRange(currentFavorites.list);
            };


            return returnList;
        }


        public async void DownloadSong(Song toDownload, string theDirectory)
        {
            // foreach(SmuleSong song in theDownloadList)
            // {
            var res = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, toDownload.Link)).ConfigureAwait(false);

            var responseStream = await res.Content.ReadAsStringAsync();
            {
                string UriTag = "twitter:player:stream\" content=\"";
                int startIndex = responseStream.IndexOf(UriTag) + UriTag.Length;
                int endIndex = responseStream.IndexOf("\">", startIndex);
                int length = endIndex - startIndex;
                string uri = responseStream.Substring(startIndex, length);
                uri = uri.Replace("amp;", "");

                using (Stream output = File.OpenWrite(theDirectory + toDownload.Titel + ".mp4"))
                using (HttpClient client2 = new HttpClient())
                {
                    var res2 = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri)).ConfigureAwait(false);

                    var input = await res2.Content.ReadAsStreamAsync();

                    using (var streamReader = new StreamReader(input))
                    {
                        //string all = streamReader.ReadToEnd();
                        streamReader.BaseStream.CopyTo(output);
                    }
                }
                //   }
            }
        }
        /*
        public async void DownloadSong(string theUri, string theTitle)
        {
            /*string path = Path.Combine(thePath, theTitle + ".mp4");
            using (Stream output = File.OpenWrite(path))
            {
                var res2 = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri)).ConfigureAwait(false);

                var input = await res2.Content.ReadAsStreamAsync();

                using (var streamReader = new StreamReader(input))
                {
                    //string all = streamReader.ReadToEnd();
                    streamReader.BaseStream.CopyTo(output);
                }
            }
        }*/
        public async Task DownloadSong(string theUri, string theTitle, string thePath, IProgress<float> progress = null)
        {
            // foreach(SmuleSong song in theDownloadList)
            // {
            var res = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, theUri)).ConfigureAwait(false);

            var responseStream = await res.Content.ReadAsStringAsync();
            {
                string UriTag = "twitter:player:stream\" content=\"";
                string UriTag2 = "twitter:player\" content=\"";
                if (responseStream.IndexOf(UriTag) == -1)
                    UriTag = UriTag2;
                int startIndex = responseStream.IndexOf(UriTag) + UriTag.Length;
                int endIndex = responseStream.IndexOf("\">", startIndex);
                int length = endIndex - startIndex;
                string uri = responseStream.Substring(startIndex, length);
                uri = uri.Replace("amp;", "");

                string path = Path.Combine(thePath, theTitle + ".mp4");
                try
                {

                    using (var file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                        await _httpClient.DownloadDataAsync(uri, file, progress);

                    /*
                    using (Stream output = File.Create(path))
                    using (HttpClient client2 = new HttpClient())
                    {
                       
                        var res2 = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri)).ConfigureAwait(false);
                        
                        var input = await res2.Content.ReadAsStreamAsync();

                        using (var streamReader = new StreamReader(input))
                        {
                            Stream baseStream = streamReader.BaseStream;
                            
                            long total = baseStream.Length;
                            long oneper = (long)(total * 0.01);
                            byte[] buf = new byte[oneper];
                            double i = 0.0;
                            do
                            {
                                long lastPos = baseStream.Position;
                                if (total - lastPos < oneper)
                                    oneper = total - lastPos;
                                int readed = baseStream.Read(buf, 0, (int)oneper);
                                output..Write(buf, (int)lastPos, (int)oneper);
                                buf.Initialize();
                                i += 1;
                                progress?.Report(i);
                            } while (baseStream.Position < baseStream.Length);
                            output.Flush();
                            //baseStream.
                            /* new Progress
                            Stream baseStream = reader.BaseStream;
                            long length = baseStream.Length;

                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Length > 8 && line.Substring(0, 4) == "080,")
                                {
                                    string strCode = line.Substring(4, 4);

                                    if (listBoxCodes.FindStringExact(strCode) == -1)
                                        listBoxCodes.Items.Add(strCode);
                                    else
                                        listBoxDuplicates.Items.Add(strCode);
                                }

                                progressBar.Value = baseStream.Position / length * 100;
                                // Add code to update your progress bar UI
                            }
                            
                            //string all = streamReader.ReadToEnd();
                            //streamReader.BaseStream.CopyTo(output);
                        }*/
                    //}
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //ToDo
                    //Illegal Characters in Filenames
                        //string temp = System.Text.RegularExpressions.Regex.Replace(theTitle, @"[^0-9a-zA-Z .;.,_-]", string.Empty);
                        //await DownloadSong(theUri, temp, thePath);
                }
                //   }
            }
        }
    }
}
