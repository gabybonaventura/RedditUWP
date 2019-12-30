using System.Collections.Generic;
using RedditUWP.API.Interfaces;
using RedditUWP.Entities;
using RestSharp;
using RedditUWP.API.Models;
using AutoMapper;

namespace RedditUWP.API
{
    public class APIManagement : IAPIManagement
    {
        private IMapper mapper;

        public APIManagement(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int ContentLenght { get; set; }

        public List<RedditPost> GetRedditPost()
        {
            var limit = 50;
            var client = new RestClient("https://www.reddit.com");
            var request = new RestRequest($"top/.json", Method.GET);
            request.AddParameter("limit", limit);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var redditPostApi = RedditPostsApi.FromJson(content);
            var redditPost = mapper.Map<List<RedditPost>>(redditPostApi.Data.Children);

            return redditPost;
        }
    }
}
