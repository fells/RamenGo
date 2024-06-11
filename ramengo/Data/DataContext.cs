using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ramengo.Models;
using System.IO;

namespace ramengo.Data
{
    static public class DataContext
    {

        public static readonly Dictionary<string, object> localStorage = new()
        {
            #region broth
            {
                "1",
                
                new Broth
                {
                    Id = 1,
                    Name = "Shio",
                    ImageInactive = "https://tech.redventures.com.br/icons/shio/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/shio/active.svg",
                    Description = "Simple like the seawater, nothing more",
                    Price = 10
                }
            },
             {
                "2",

                new Broth
                {
                    Id = 2,
                    Name = "Shoyu",
                    ImageInactive = "https://tech.redventures.com.br/icons/shoyu/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/shoyu/active.svg",
                    Description = "A rich soy sauce base",
                    Price = 12
                }
            },
              {
                "3",

                new Broth
                {
                    Id = 3,
                    Name = "Miso",
                    ImageInactive = "https://tech.redventures.com.br/icons/miso/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/miso/active.svg",
                    Description = "Fermented soybean paste",
                    Price = 14
                }
            },
            #endregion broth
            #region protein
              {
                "4",

               new Protein
                {
                    Id = 4,
                    Name = "Chashu",
                    ImageInactive = "https://tech.redventures.com.br/icons/chashu/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/chashu/active.svg",
                    Description = "A sliced flavourful pork meat with a selection of seasoned vegetables.",
                    Price = 10
                }
            },
              {
                "5",

                new Protein
                {
                    Id = 5,
                    Name = "Tofu",
                    ImageInactive = "https://tech.redventures.com.br/icons/tofu/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/tofu/active.svg",
                    Description = "Soft tofu pieces",
                    Price = 8
                }
            },
              {
                "6",

                new Protein
                {
                    Id = 6,
                    Name = "Chicken",
                    ImageInactive = "https://tech.redventures.com.br/icons/chicken/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/chicken/active.svg",
                    Description = "Grilled chicken breast",
                    Price = 9
                }
            },
            #endregion protein
        };
    }
}
